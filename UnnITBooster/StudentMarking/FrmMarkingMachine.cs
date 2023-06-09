using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LateBindingTest;
using StudentsFetcher.Properties;
using UnnFunctions.MCRF;
using UnnItBooster.Models;
using UnnItBooster.ModelConversions;
using ZedGraph;
using System.IO.Compression;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using UnnItBooster.StudentMarking;
using NPOI.OpenXmlFormats.Encryption;

namespace StudentsFetcher.StudentMarking;

[AmmFormAttributes("Marking machine", 1)]
public partial class FrmMarkingMachine : Form
{
    private MarkingConfig _config;
    readonly StudentsRepository studentRepository;

    public FrmMarkingMachine()
    {
        InitializeComponent();
        LoadSettings();
        studentRepository = new StudentsRepository(Settings.Default.StudentsFolder);
    }

    void txtStudentId_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            UpdateStudentUi();
        }
    }

    private void UpdateStudentUi()
    {
        UpdateStudentReport();
        UpdateStudentMarksUi();
        if (ChkAutoStat.Checked)
        {
			ReportTranscript();
		}
	}

    private void UpdateStudentMarksUi()
	{
		foreach (var creset in flComponents.Controls.OfType<ucComponentMark>())
			creset.Unset();
		var studNumber = GetStudentNumber();
		if (studNumber != -1)
		{
			var sql = $"select * from TB_Marks where MARK_ptr_Submission = {studNumber}";
			var dt = _config.GetDataTable(sql);
			foreach (DataRow item in dt.Rows)
			{
				var cmp = Convert.ToInt32(item["MARK_ptr_Component"]);
				var val = Convert.ToInt32(item["MARK_Value"]);

				if (cmp == -1)
					cmp = 0;

				var m = flComponents.Controls[cmp] as ucComponentMark;
				if (m is not null)
				{
					m.TabStop = false;
					m.MarkValue = val;
				}
			}
			cmdSaveMarks.BackColor = Color.Transparent;

		}
	}

	private void UpdateMark(int studNumber)
	{
        var calc = _config.GetMark(studNumber);
		LblMark.Text = calc == -1 ? "-" :  $"{calc}%";
	}

	private void UpdateStudentReport()
    {
        var studNumber = GetStudentNumber();
		UpdateMark(studNumber);
		if (studNumber != -1)
        {
            var submission = GetCurrentSubmission();
            if (submission is null)
            {
                txtStudentreport.Text = "none";
                return;
            }
            txtStudentreport.Text = _config.GetStudentReport(GetStudentNumber(), chkSendModerationNotice.Checked);
            UpdateDocumentsList(submission);
            // show student picure.
            var dt = _config.GetDataTable("SELECT SUB_NumericUserId from tb_submissions where SUB_Id = " + GetStudentNumber());
            if (dt.Rows.Count == 1)
            {
                var numericUserId = dt.Rows[0][0].ToString();
                ShowUserImage(numericUserId);
            }
        }
        else
        {
            // searches for a student by name or other methods
            var sql = "select  *, (SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks from tb_submissions";
            if (txtStudentId.Text != "")
            {
                sql += " where " +
                    "SUB_LastName like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                    "SUB_FirstName like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                    "SUB_UserID like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                    "SUB_NumericUserID like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                    "SUB_email like '%" + txtStudentId.Text.Replace("'", "''") + "%'";
            }

            var dt = _config.GetDataTable(sql);
            if (dt.Rows.Count == 1)
            {
                txtStudentId.Text = dt.Rows[0]["SUB_id"].ToString();
                UpdateStudentReport();
                return;
            }

            var mc = _config.GetMarkCalculator();
            var sb = new StringBuilder();
            var sbDataUpload = new StringBuilder();
            foreach (DataRow item in dt.Rows)
            {
                var totmark = mc.GetFinalMark(item["SUB_NumericUserId"].ToString(), _config);

                sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{5}\t{4}\t{6}\r\n",
                    item["SUB_id"],
                    item["SUB_LastName"],
                    item["SUB_FirstName"],
                    item["SUB_UserID"],
                    item["MARKS"],
                    item["SUB_NumericUserID"],
                    totmark
                    );

                sbDataUpload.AppendFormat("\"{0}\"\t\"{1}\"\t\"{2}\"\t\"{3}\"\t\"{5}\"\t\t\t\"{4}.00\"\n",
                    item["SUB_LastName"],
                    item["SUB_FirstName"],
                    item["SUB_UserID"],
                    item["SUB_NumericUserID"],
                    totmark,
                    item["SUB_email"]
                    );
            }

            sb.AppendFormat("\r\n\r\n");
            sb.Append(sbDataUpload);
            sb.AppendFormat("\r\n\r\n");

            foreach (DataRow item in dt.Rows)
            {
                var id = Convert.ToInt32(item["SUB_id"]);
                sb.Append(_config.GetStudentReport(id, chkSendModerationNotice.Checked));
            }
            txtStudentreport.Text = sb.ToString();
        }
    }

    private TurnitInSubmission? GetCurrentSubmission()
    {
        var numb = GetStudentNumber();
        if (numb == -1)
            return null;
        var r = _config.GetStudentRow(numb);
        if (r == null)
            return null;
        return TurnitInSubmission.FromRow(r);
    }

    private void UpdateDocumentsList(TurnitInSubmission submission)
    {
        cmbDocuments.Items.Clear();
        // todo: populate document
        cmbDocuments.Items.Add(submission.Title);
        if (!string.IsNullOrEmpty(submission.Title))
            cmbDocuments.SelectedIndex = 0;
    }

    private int GetStudentNumber()
    {
        if (_config == null || !File.Exists(_config.DbName))
            return -1;
        try
        {
            var i = Convert.ToInt32(txtStudentId.Text);
            if (i > 999)
                return -1;
            return i;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var addComponentMatch = Regex.Match(txtSearch.Text, "component (\\d+) (\\d+) (.*)", RegexOptions.IgnoreCase);
			var setComponentCommentMatch = Regex.Match(txtSearch.Text, "componentComment (\\d+) (.*)", RegexOptions.IgnoreCase);
			var idsMatch = Regex.Match(txtSearch.Text, "ids", RegexOptions.IgnoreCase);
            var editMatch = Regex.Match(txtSearch.Text, "^edit (?<par>last|\\?|\\d+)$", RegexOptions.IgnoreCase);
			var whoGotMatch = Regex.Match(txtSearch.Text, @"WhoGotComment (\d+)", RegexOptions.IgnoreCase);
			var removeMatch = Regex.Match(txtSearch.Text, @"Remove (\d+)", RegexOptions.IgnoreCase);
			var levelMatch = Regex.Match(txtSearch.Text, @"setlevel (?<level>ug|pg)", RegexOptions.IgnoreCase);
            if (addComponentMatch.Success)
            {
                AddComponent(addComponentMatch);
                UpdateComponents();
            }
            else if (editMatch.Success)
            {
                EditLoad(editMatch.Groups["par"].Value);
            }
            else if (setComponentCommentMatch.Success)
            {
                int order = Convert.ToInt32(setComponentCommentMatch.Groups[1].Value);
                string comment = setComponentCommentMatch.Groups[2].Value;
                _config.SetComponentComment(order, comment);
                UpdateComponents();
            }
			else if (levelMatch.Success)
			{
                SetLevel(levelMatch);
			}
			else if (idsMatch.Success)
            {
                GetIds();
            }
            else if (whoGotMatch.Success)
            {
                GetCommentUse(whoGotMatch);
            }
            else if (removeMatch.Success)
            {
                RemoveComment(removeMatch);
            }
            else if (txtSearch.Text == "missing")
            {
                FindMissing();
            }
            else if (txtSearch.Text == "WriteFeedbackFile")
            {
                WriteFeedbackFile();
            }
            else if (txtSearch.Text == "mcrfcheck")
            {
				CleanMcrf();
			}
			else if (txtSearch.Text.Equals("marks", StringComparison.OrdinalIgnoreCase))
            {
				GetMarks();
			}
			else if (txtSearch.Text.Equals("turnitinsort", StringComparison.OrdinalIgnoreCase))
			{
				GetTurnitinOrder();
			}
			else if (txtSearch.Text == "stat" || txtSearch.Text == "stats" || txtSearch.Text == "transcript")
			{
				ReportTranscript();
			}
			else if (txtSearch.Text == "help")
            {
                txtLibReport.Text = """
                    component <order#> <percent> <Name>
                        Create a new marking compoenent

                    componentComment <order#> <comment> 
                        Add comment in the form: - {0} ability to ..., no quotes

                    edit last
                        preloads the last comment to be modified

                    edit <Id#>
                        preloads the comment of type #Id for the current student to be modified

                    marks
                       if ids in textbox (one per row), used to fill MCRF with selected IDs
                       otherwise produces all available marks

                    turnitinsort
                        produces the order of entries like turnitin would
                        Entries are then browsed +/- buttons as long as the text `turnitinsort` remains in the command line

                    Remove <commentId>
                       removes the comment from the current student by the ID of the comment

                    WhoGotComment <#>
                       lists students that got a specific comment in their feedback

                    stat|stats|transcript
                       Provides student transcript information, if available

                    setlevel [ug|pg]
                       determines the verbal conversion of marks at 40 to sufficient or inadequate

                    ids
                       produces 2 list of ids (numeric and alfanumeric versions)

                    WriteFeedbackFile
                       writes student feedback each in an individual file (subfolder named Feedback)

                    mcrfcheck
                       grabs the values copied from an MCRF cut and paste and tidies it up

                    missing
                       finds marks not added to mcrf (use all relevant lists)   
                       requires ids in textbox (one per row, e.g. '11039298/1') 
                    """;
            }
            else
            {
                SearchCommentInLibrary();
            }
        }
    }

	private void GetTurnitinOrder()
	{
        StringBuilder stringBuilder = new StringBuilder();
        var res = _config.GetDataTable("SELECT SUB_ID, SUB_LastName, SUB_Overlap from TB_Submissions order by cast (SUB_Overlap as INT) , SUB_LastName");
        foreach (DataRow row in res.Rows)
        {
            stringBuilder.AppendLine(row[0].ToString());
        }
        txtLibReport.Text = stringBuilder.ToString();
	}

	private void SetLevel(Match levelMatch)
	{
        var m = levelMatch.Groups["level"].Value;
        switch (m)
        {
            case "ug":
				_config.MarkAbility = new Dictionary<string, string>
				{
					{"1", "little or no"},
					{"2", "little or no"},
					{"3", "little or no"},
					{"4", "sufficient"},
					{"5", "adequate"},
					{"6", "good"},
					{"7", "excellent"},
					{"8", "outstanding"},
					{"9", "exceptional"}
				};
                txtLibReport.Text = "Level set to under-graduate.";
				break;
            case "pg":
            default:
                _config.MarkAbility = new Dictionary<string, string>
                {
                    {"1", "little or no"},
                    {"2", "little or no"},
                    {"3", "little or no"},
                    {"4", "inadequate"},
                    {"5", "adequate"},
                    {"6", "good"},
                    {"7", "excellent"},
                    {"8", "outstanding"},
                    {"9", "exceptional"}
                };
				txtLibReport.Text = "Level set to post-graduate.";
				break;
        }
    }

	private void ReportTranscript()
	{
        var t = GetCurrentSubmission();
		if (t is null)
		{
			txtLibReport.Text = "need selected student record";
			return;
		}
        var student = studentRepository.GetStudentById(t.NumericUserId);
        if (student is null)
        {
			txtLibReport.Text = "No student found in repository";
            return;
		}
		txtLibReport.Text = student.ReportTranscript(); 
	}

	private void EditLoad(string value)
	{
        var sql = "select TB_SubComments.*, TB_Comments.* from TB_SubComments inner join TB_Comments on SCOM_ptr_Comment = COMM_ID ";
        if (value == "?")
        {
			sql += $"where SCOM_ptr_Submission = {GetStudentNumber()}";
            var existing = _config.GetDataTable(sql);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow iterRow in existing.Rows)
            {
                sb.AppendLine($"{iterRow["COMM_ID"]}, {iterRow["COMM_Section"]} / {iterRow["COMM_Area"]}\r\n");
                sb.AppendLine($"{iterRow["COMM_Text"]}\r\n");
                sb.AppendLine($"{iterRow["SCOM_AddNote"]}\r\n");
            }
			txtLibReport.Text = sb.ToString();
			return;
		}
        if (value == "last")
        {
            sql += "order by SCOM_ID desc limit 1";
        }
        else
            sql += $"where SCOM_ptr_Submission = {GetStudentNumber()} and SCOM_ptr_Comment = {value}";
        var row = _config.GetRow(sql);
        if (row != null)
        {
            txtTextOrPointer.Text = $"{row["SCOM_ptr_Comment"]}\r\n{row["COMM_Text"]}";
            txtAdditionalNote.Text = $"{row["SCOM_AddNote"]}";
            txtArea.Text = $"{row["COMM_Area"]}";
            txtSection.Text = $"{row["COMM_Section"]}";
		}
	}

	private void WriteFeedbackFile()
    {
        var feedBackfolderName = Path.Combine(_config.GetFolderName(), "Feedback");
        var di = new DirectoryInfo(feedBackfolderName);
        if (!di.Exists)
            di.Create();
        var sql = "select *, (SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks from tb_submissions";
        var dt = _config.GetDataTable(sql);

        foreach (DataRow item in dt.Rows)
        {
            var id = Convert.ToInt32(item["SUB_id"]);
            var stringId = item["SUB_UserId"].ToString();
            var fi = new FileInfo(Path.Combine(feedBackfolderName, stringId + ".txt"));
            using var w = fi.CreateText();
            w.WriteLine(_config.GetStudentReport(id, chkSendModerationNotice.Checked));
        }
    }

    private void CleanMcrf()
    {
        var p = new McrfTextParser();
        var t = p.ParseComponents(txtStudentreport.Text, 2);
        txtLibReport.Text = t;
    }

    private void RemoveComment(Match m5)
    {
        if (GetStudentNumber() == -1)
        {
            MessageBox.Show("Need student");
            return;
        }
        var sql = $"""
            delete from TB_SubComments where SCOM_ptr_Submission = {GetStudentNumber()} 
            AND SCOM_ptr_Comment = {m5.Groups[1].Value}
            """;
        _config.Execute(sql);
        UpdateStudentReport();
    }

    private void FindMissing()
    {
        var allIds = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        txtStudentreport.Text += "Missing report:\r\n";
        txtStudentreport.Text += "==============:\r\n";
        var sql = "SELECT * FROM TB_Submissions";
        var dt = _config.GetDataTable(sql);
        foreach (DataRow r in dt.Rows)
        {
            var lookForId = r["sub_numericUserId"].ToString();

            var rEx = new Regex("" + lookForId + @"/(\d)");

            var bFound = false;
            foreach (var reqId in allIds)
            {
                if (rEx.IsMatch(reqId))
                {
                    bFound = true;
                    break;
                }
            }
            if (!bFound)
            {
                txtStudentreport.Text += lookForId + " (#" + r["sub_ID"] + ") missing\r\n";
            }
        }
    }

    private void GetCommentUse(Match m4)
    {
        txtLibReport.Text = "Submissions:\r\n";
        var sql = "SELECT SCOM_ptr_Submission, TB_Submissions.SUB_UserID FROM TB_SubComments inner join TB_Submissions on SCOM_ptr_Submission = SUB_ID where SCOM_ptr_comment = " + m4.Groups[1].Value;
        var dt = _config.GetDataTable(sql);
        var reqIds = new List<string>();
        foreach (DataRow item in dt.Rows)
        {
            txtLibReport.Text += $"{item[0]}\t{item[1]}\r\n";
            // this submission's files
            reqIds.Add(item[1].ToString());
        }
    }

    private void GetIds()
    {
        txtLibReport.Text = "";
        var sql = "SELECT sub_userid, sub_numericUserId FROM TB_Submissions";
        var dt = _config.GetDataTable(sql);
        foreach (DataRow item in dt.Rows)
        {
            txtLibReport.Text += item[0] + "\r\n";
        }

        txtLibReport.Text += "\r\n====Alternate version:\r\n\r\n";
        foreach (DataRow item in dt.Rows)
        {
            txtLibReport.Text += item[1] + "\r\n";
        }
    }

    private void GetMarks()
    {
        string[] ids;
		if (string.IsNullOrWhiteSpace(txtLibReport.Text))
			ids = _config.GetStudentIds();
        else
            ids = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
        
            
        var markgen = _config.GetMarkCalculator();
        foreach (var idWithSlash in ids)
        {
            var result = "";
            var idParts = idWithSlash.Split(new[] { "/" }, StringSplitOptions.None);
            if (idParts.Length == 2)
            {
                var id = idParts[0];
                result = markgen.GetFinalMark(id, _config).ToString();
            }
            else if (idWithSlash.Length == 8)
            {
				// idWithSlash does not have the slash
				result = markgen.GetFinalMark(idWithSlash, _config).ToString();
			}
            txtStudentreport.Text += $"{idWithSlash}\t{result}\r\n";
        }
    }

    private void AddComponent(Match m)
    {
        string sql;
        var compOrder = m.Groups[1].ToString();
        var compPercent = m.Groups[2].ToString();
        var compTitle = m.Groups[3].ToString();

        sql = $"delete from TB_Components where CPNT_Order = {compOrder}";
        _config.Execute(sql);

        sql = $"""
            insert into 
            TB_Components (CPNT_Order, CPNT_Percent, CPNT_Name) 
            values ({compOrder}, {compPercent}, '{compTitle.Trim().Replace("'", "''")}')
            """;
        _config.Execute(sql);
    }

    private void SearchCommentInLibrary()
    {
        
        var bExtended = false;
        txtLibReport.Text = "Problem";
        var sarr = txtSearch.Text.Split(';');
        if (sarr.Count() == 0)
            return;
		if (_config == null)
			return;

		var sql = "select * from TB_Comments where ";
        if (sarr.Count() == 1)
        {
            sql += $"COMM_Text like '%{sarr[0]}%'";
            if (sarr[0].EndsWith("+"))
            {
                var val = sarr[0].Substring(0, sarr[0].Length - 1);
                sql = $"select * from QComments where SCOM_AddNote like '%{val}%'";
                bExtended = true;
            }
        }
        else if (sarr.Count() > 1)
        {
            sql += $"[COMM_section] like '%{sarr[0]}%' ";
            txtSection.Text = sarr[0].ToUpper();
            if (sarr[1].Length > 0)
            {
                txtArea.Text = sarr[1].ToUpper();
                sql += $"and [COMM_Area] like '%{sarr[1]}%' ";
            }
            if (sarr.Length > 2 && sarr[2].Length > 0)
            {
                sql += $"and [COMM_Text] like '%{sarr[2]}%' ";
            }
        }

        var sb = new StringBuilder();
        var dt = _config.GetDataTable(sql);
        foreach (DataRow item in dt.Rows)
        {
            sb.AppendFormat("{0}: ({2}/{3})\r\n{1}\r\n\r\n",
                item["COMM_Id"],
                item["COMM_Text"],
                item["COMM_section"],
                item["COMM_Area"]
                );

            if (bExtended)
            {
                sb.AppendFormat("{0}\r\n\r\n",
                item["SCOM_AddNote"]
                );
            }
        }
        txtLibReport.Text = sb.ToString();
    }

    private void cmdAdd_Click(object sender, EventArgs e)
    {
        DoAdd();
    }

    private void DoAdd()
    {
        if (GetStudentNumber() == -1)
        {
            MessageBox.Show("Need student");
            return;
        }
        var con = _config.GetConn();

        string sql;
		var isNumber = int.TryParse(txtTextOrPointer.Text, out int reference);
		string line1 = txtTextOrPointer.Text.Split(new[] { '\r', '\n' }).FirstOrDefault();
        var isFirstLineNumber = int.TryParse(line1, out var firstLineNumber);

		if (isFirstLineNumber && !isNumber)
		{
			var nt = txtTextOrPointer.Text.Substring(line1.Length).Replace("'", "''");
			nt = nt.Trim('\n', '\r', ' ');
			// we are using the first line to store the id of the comment, but we are going to edit it
			sql = "update TB_Comments set " +
					$"[COMM_Section] = '{txtSection.Text.Replace("'", "''")}'," +
					$"[COMM_Area] = '{txtArea.Text.Replace("'", "''")}'," +
					$"[COMM_Text] = '{nt}' " +
					$"Where COMM_ID = {firstLineNumber}";
			_config.Execute(sql);

			sql = $"delete from TB_SubComments where SCOM_ptr_Comment = {firstLineNumber} and SCOM_ptr_Submission = {GetStudentNumber()} ";
			_config.Execute(sql);
			reference = firstLineNumber;
		}
		else if (!isNumber)
        {
            reference = -1;
            var c = _config.GetConn();
            c.Open();
            if (txtTextOrPointer.Text == "")
            {
                reference = _config.ExecuteScalar("SELECT comm_id FROM TB_Comments where comm_text = ''", c);
            }
            if (reference == -1)
            {
                sql = "insert into TB_Comments ([COMM_Section],[COMM_Area],[COMM_Text]) values " +
                    "('" + txtSection.Text.Replace("'", "''") + "','" + txtArea.Text.Replace("'", "''") + "','" + txtTextOrPointer.Text.Replace("'", "''") + "')";
                _config.Execute(sql, c);

                reference = _config.ExecuteScalar("SELECT last_insert_rowid()", c);
            }
            c.Close();
        }
         

        sql = "insert into TB_SubComments (" +
                "SCOM_ptr_Submission, " +
                "SCOM_ptr_Comment, " +
                "SCOM_ptr_Component, " +
                "SCOM_AddNote) " +
            "values (" +
                GetStudentNumber() + "," +
                reference + "," +
                GetComponentComment() + "," +
                "'" + txtAdditionalNote.Text.Replace("'", "''") + "'" +
            ")";
        _config.Execute(sql);

        UpdateStudentReport();
        UpdateSectionCombo();
        txtTextOrPointer.Text = "";
        txtAdditionalNote.Text = "";
        txtSearch.SelectAll();
        txtSearch.Focus();
    }

	private void UpdateSectionCombo()
	{
        txtSection.Items.Clear();
        var vals = _config.GetDataTable("select distinct COMM_Section from TB_Comments order by COMM_Section");
        foreach (DataRow row in vals.Rows)
        {
            txtSection.Items.Add(row[0].ToString());
        }
	}

	private void label1_Click(object sender, EventArgs e)
    {
        txtTextOrPointer.Focus();
    }

    private void label2_Click(object sender, EventArgs e)
    {
        // txtAdditionalNote.SelectAll();
        txtAdditionalNote.Focus();
    }

    private void txtTextOrPointer_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && e.Modifiers.HasFlag(Keys.Control))
        {
            e.Handled = true;
            DoAdd();
            txtTextOrPointer.Text = "";
        }
    }

    private void cmdSelectFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.DefaultExt = "sqlite";
        openFileDialog1.Multiselect = false;
        openFileDialog1.ShowDialog();
        if (openFileDialog1.FileName != "")
        {
            txtExcelFileName.Text = openFileDialog1.FileName;
            var f = new FileInfo(openFileDialog1.FileName);
            var g = f.Directory.GetFiles(TurnItIn.GradebookStandardName).FirstOrDefault();
            if (g != null)
                txtSourceTurnitin.Text = g.FullName;


        }
    }

    private void txtExcelFileName_TextChanged(object? sender, EventArgs? e)
    {
        Reload();
    }

    private void Reload()
    {
        if (!File.Exists(txtExcelFileName.Text))
            return;
        _config = new MarkingConfig(txtExcelFileName.Text);
        UpdateComponents();
        UpdateSectionCombo();
    }

    private void UpdateComponents()
    {
        // combo 

        cmbComponentComment.Items.Clear();
        var cid = new ComboId("<general>", 0, -1);
        cmbComponentComment.Items.Add(cid);


        flComponents.Controls.Clear();

        var cmp = new ucComponentMark();
        cmp.ComponentName = "<General>";
        cmp.Id = -1;
        cmp.onUserChange += cmp_onUserChange;
        cmp.TabStop = false;
        flComponents.Controls.Add(cmp);
        cmp.TabStop = false;

        // 
        try
        {
            var dt = _config.GetDataTable("select * from TB_Components order by CPNT_Order");
            foreach (DataRow item in dt.Rows)
            {
                var order = Convert.ToInt32(item["CPNT_Order"]);
                var ipercent = Convert.ToInt32(item["CPNT_Percent"]);
                var c = new ComboId(
                    item["CPNT_Name"].ToString(),
                    ipercent,
                    order
                );
                cmbComponentComment.Items.Add(c);

                cmp = new ucComponentMark();
                cmp.ComponentName = item["CPNT_Name"] + " (" + ipercent + "%)";
                cmp.Id = order;
                cmp.onUserChange += cmp_onUserChange;
                flComponents.Controls.Add(cmp);
            }
        }
        catch (Exception ex)
        {
            var e = ex.Message;
        }
    }

    void cmp_onUserChange(object? sender, EventArgs? e)
    {
        cmdSaveMarks.BackColor = Color.Red;
    }

    int GetComponentComment()
    {
        var iComponent = -1;
        if (cmbComponentComment.SelectedItem != null)
        {
            iComponent = ((ComboId)cmbComponentComment.SelectedItem).value;
        }
        return iComponent;
    }

    private void CmdSaveMarks_Click(object sender, EventArgs e)
    {
        var stud = GetStudentNumber();
		if (stud == -1)
        {
            MessageBox.Show("Need student");
            return;
        }
        var sql = $"delete from TB_Marks where MARK_ptr_Submission = {stud}";
        _config.Execute(sql);
        foreach (var comp in flComponents.Controls.OfType<ucComponentMark>())
        {
            if (comp.IsSet)
            {
                _config.SetStudentComponentMark(GetStudentNumber(), comp.Id, comp.MarkValue, false);
            }
        }
        cmdSaveMarks.BackColor = Color.Transparent;
        UpdateStudentReport();
    }

    private void Open_Click(object sender, EventArgs e)
    {
        if (cmbDocuments.Text != "")
        {
            var fullname = Path.Combine(
                _config.GetFolderName(),
                cmbDocuments.Text);
            Process.Start(fullname);
        }
    }

    List<string> GetReplacementList(string emailbody)
    {
        var ret = new List<string>();

        var mts = Regex.Matches(emailbody, "{([^}]*)}");
        foreach (Match match in mts)
        {
            ret.Add(match.Groups[1].ToString());
        }
        return ret;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (txtEmailSubject.Text == "")
        {
            MessageBox.Show("Subject is empty.");
            return;
        }

        var mcalc = _config.GetMarkCalculator();
        var app = new OutlookLateBindingEmailer();
        var replacements = GetReplacementList(txtEmailBody.Text);
        foreach (ListViewItem studentId in lstEmailSendSelection.Items)
        {
            if (!studentId.Checked)
                continue;

            var iStudentId = (int)studentId.Tag;
            var emailtext = Emailtext(replacements, iStudentId, mcalc, out var row);
            if (row is not null)
            {
                var DestEmail = row["SUB_email"].ToString();
                if (!chkEmailDryRun.Checked)
                    app.SendOutlookEmail(DestEmail, txtEmailSubject.Text, emailtext);
                else
                    Debug.WriteLine(emailtext);
            }
        }
        MessageBox.Show("Done");
    }

    private string Emailtext(int iStudentId)
    {
        var mcalc = _config.GetMarkCalculator();
        var replacements = GetReplacementList(txtEmailBody.Text);
        var emailtext = Emailtext(replacements, iStudentId, mcalc, out _);
        return emailtext;
    }

    private string Emailtext(IEnumerable<string> replacements, int iStudentId, MarksCalculator mcalc, out DataRow? row)
    {
        var emailtext = txtEmailBody.Text;
        row = _config.GetStudentRow(iStudentId);
        if (row is null)
            return emailtext;
        foreach (var item in replacements)
        {
            var repvalue = "";
            switch (item)
            {
                case "MarkReport":
                    repvalue = _config.GetStudentReport(iStudentId, chkSendModerationNotice.Checked);
                    break;
                case "FinalMark":
                    repvalue = mcalc.GetFinalMark(row["SUB_NumericUserId"].ToString(), _config).ToString();
                    break;
                case "AllMarks":
                    break;
                default:
                    try
                    {
                        repvalue = row[item].ToString();
                    }
                    catch
                    {
                    }
                    break;
            }
            emailtext = emailtext.Replace("{" + item + "}", repvalue);
        }
        return emailtext;
    }

    private void cmdEmailRefreshStudents_Click(object sender, EventArgs e)
    {
        var mcalc = _config.GetMarkCalculator();
        lstEmailSendSelection.Items.Clear();
        try
        {
            var dt = _config.GetDataTable(
                "select  *, " +
                "(SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks, " +
                "(SELECT count(*) FROM TB_SubComments WHERE scom_ptr_submission=sub_id) as NumComments, " +
                "(SELECT max(MARK_Date) FROM tb_marks WHERE mark_ptr_submission=sub_id) as markDate " +
                "from tb_submissions");

            foreach (DataRow item in dt.Rows)
            {
                var lvi = new ListViewItem();
                lvi.Text = string.Format("{0} {1}", item["SUB_FirstName"], item["SUB_LastName"]);
                lvi.Tag = Convert.ToInt32(item["SUB_Id"]);
                lvi.SubItems.Add(item["marks"].ToString());
                var numUID = item["SUB_NumericUserId"].ToString();
                lvi.SubItems.Add(mcalc.GetFinalMark(numUID, _config).ToString());
                lvi.SubItems.Add(lvi.Tag + " " + item["markDate"]);
                lvi.SubItems.Add(item["NumComments"].ToString());
                lvi.SubItems.Add(
                    string.Format("Overalp: {0} Internet: {1} Pub: {2} Student: {3}",
                        item["SUB_Overlap"],
                        item["SUB_InternetOverlap"],
                        item["SUB_PublicationsOverlap"],
                        item["SUB_StudentPapersOverlap"]
                        ));

                lstEmailSendSelection.Items.Add(lvi);
                // lstEmailSendSelection.Items.Add(numUID);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void cmdGetData_Click(object sender, EventArgs e)
    {
        if (!chkImportComponents.Checked && !chkCommentLib.Checked && !chkImportSubmissions.Checked)
            return;

        var sql = "";
        sql += string.Format("ATTACH \"{0}\" AS {1}; ", txtSourceDataFile.Text, "OTHERDB");
        // Config.Execute(sql);

        if (chkCommentLib.Checked)
        {
            sql += "insert into tb_comments (COMM_Section, COMM_Area, COMM_Text) select  COMM_Section, COMM_Area, COMM_Text from OTHERDB.tb_comments; ";
            // Config.Execute(sql);
        }

        if (chkImportComponents.Checked)
        {
            sql += "insert into TB_Components select * from OTHERDB.TB_Components; ";
            //Config.Execute(sql);
        }

        if (chkImportSubmissions.Checked)
        {
            var submissionFields = string.Join(", ", TurnitInSubmission.Fields);
            sql += "insert into TB_Submissions (" +
                $"{submissionFields}" +
                ") select " +
                $"{submissionFields}" +
                "from OTHERDB.TB_Submissions; ";
            //Config.Execute(sql);
        }

        sql += string.Format("DETACH {0}; ", "OTHERDB");
        _config.Execute(sql);

        txtExcelFileName_TextChanged(null, null);

        MessageBox.Show("Done");
    }

    private void cmdSourceDataFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.DefaultExt = "sqlite";
        openFileDialog1.Multiselect = false;
        openFileDialog1.ShowDialog();
        if (openFileDialog1.FileName != "")
        {
            txtSourceDataFile.Text = openFileDialog1.FileName;
        }
    }

    private void cmdReload_Click(object sender, EventArgs e)
    {
        Reload();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        var Groups = new int[10];

        var mcalc = _config.GetMarkCalculator();
        var sql = "SELECT sub_userid, sub_numericUserId FROM TB_Submissions";
        var dt = _config.GetDataTable(sql);
        foreach (DataRow rw in dt.Rows)
        {
            var mk = mcalc.GetFinalMark(rw[1].ToString(), _config);
            var m = mk / 10;
            Groups[m]++;
        }

        var list = new PointPairList();
        for (var i = 0; i < 10; i++)
        {
            double x = i * 10 + 5;
            list.Add(x, Groups[i]);
        }

        var gPane = zedGraphControl1.GraphPane;
        gPane.CurveList.Clear();
        var myCurve = gPane.AddBar("Marks", list, Color.Blue);
        zedGraphControl1.AxisChange();
        zedGraphControl1.Refresh();
    }

    private void Next_Click(object sender, EventArgs e)
    {
        MoveStudent(1);
    }

    private void MoveStudent(int Delta)
    {
		var iSN = GetStudentNumber();
		if (txtSearch.Text.Equals("turnitinsort", StringComparison.OrdinalIgnoreCase))
        {
            var arr = txtLibReport.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            var idx = arr.IndexOf(iSN.ToString());
            if (idx == -1)
                return;
            idx += Delta;
            if (idx < 0 || idx >= arr.Count)
                return;
            txtStudentId.Text = arr[idx].ToString();
			UpdateStudentUi();
			return; 
        }
        if (iSN == -1)
        {
            iSN = 0;
        }
        iSN += Delta;
        txtStudentId.Text = iSN.ToString();
        UpdateStudentUi();
    }

    private void button6_Click(object sender, EventArgs e)
    {
        MoveStudent(-1);
    }

    private void cmdSelectAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lstEmailSendSelection.Items)
        {
            item.Checked = true;
        }
    }

    private void lstEmailSendSelection_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (lstEmailSendSelection.SelectedIndices.Count > 0)
        {
            // show picture
            var iShort = (int)lstEmailSendSelection.SelectedItems[0].Tag;
            var dt = _config.GetDataTable("SELECT SUB_NumericUserId from tb_submissions where SUB_Id = " + iShort);
            if (dt.Rows.Count == 1)
            {
                var numeriCuserID = dt.Rows[0][0].ToString();
                ShowUserImage(numeriCuserID);
            }
            // preview email
            txtEmailPreview.Text = Emailtext(iShort);
        }
    }

    private void ShowUserImage(string numeriCuserID)
    {
        var student = studentRepository.GetStudentById(numeriCuserID);
        if (student is not null && studentRepository.HasImage(student, out var imagePath))
            StudImage.Load(imagePath);
        else
            StudImage.Image = null;
    }

    private void cmdSaveEmail_Click(object sender, EventArgs e)
    {
        SaveSettings();
    }

    private void SaveSettings()
    {
        Settings.Default.emailBodyMarking = txtEmailBody.Text;
        Settings.Default.emailSubject = txtEmailSubject.Text;
        Settings.Default.Save();
    }

    private void LoadSettings()
    {
        txtEmailBody.Text = Settings.Default.emailBodyMarking;
        txtEmailSubject.Text = Settings.Default.emailSubject;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        txtEmailBody.Text = """
            Dear {SUB_FirstName}, 
            as we have recently marked your submission for XXXX, I'm now writing to inform you of the outcome. 
            At this stage your mark is unconfirmed; marks become confirmed after the Progression and Awards Board for your programme, that is scheduled for the XXXXX.
            Your marks will be visible on formal trascripts shortly after that.

            Please find your feedback and unconfirmed mark after my signature.

            Best regards, 
            Claudio 

            {MarkReport}
            """;
    }

    private void Button7_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSourceTurnitin.Text))
            return;
        var f = new FileInfo(txtSourceTurnitin.Text);
        if (!f.Exists)
            return;
        var destFile = Path.ChangeExtension(f.FullName, "sqlite");
        var repository = new StudentsRepository(Settings.Default.StudentsFolder);
        var submissions = TurnItIn.GetSubmissionsFromLearningAnalytics(f, repository).ToList();
        TurnItIn.PopulateDatabase(destFile, submissions);
        txtExcelFileName.Text = destFile;
        Reload();
    }

    private void BtnCompleteData_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSourceTurnitin.Text))
            return;
        var f = new FileInfo(txtSourceTurnitin.Text);
        if (!f.Exists)
            return;
        var repository = new StudentsRepository(Settings.Default.StudentsFolder);
        var submissions = TurnItIn.GetSubmissionsFromLearningAnalytics(f, repository).ToList();
        txtReport.Text = TurnItIn.UpdateDatabase(txtExcelFileName.Text, submissions);
        Reload();
    }

    private void button8_Click(object sender, EventArgs e)
    {
        openFileDialog1.DefaultExt = "sqlite";
        openFileDialog1.Multiselect = false;
        openFileDialog1.ShowDialog();
        if (openFileDialog1.FileName != "")
        {
            txtSourceTurnitin.Text = openFileDialog1.FileName;
        }
    }

    private void button9_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        var folderName = _config.GetFolderName();
        var folder = new DirectoryInfo(folderName);
        int shortened = 0;

        foreach (var zipPath in folder.GetFiles("*.zip"))
        {
            if (zipPath == null)
                return;
            var extractPath = zipPath.FullName.ToLowerInvariant().Replace(".zip", "");
            var outDir = new DirectoryInfo(extractPath);
            outDir.Create();
            using ZipArchive archive = ZipFile.OpenRead(zipPath.FullName);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                Debug.WriteLine(entry.FullName);
                // Gets the full path to ensure that relative segments are removed.
                string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));
                // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                // are case-insensitive.
                if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal)
                    && !File.Exists(destinationPath)
                    )
                {
                    FileInfo f = new FileInfo(destinationPath);
                    if (!f.Directory.Exists)
                    {
                        f.Directory.Create();
                    }
                    if (destinationPath.Length > 255)
                    {
                        var max = 256
							- f.Extension.Length
                            - f.Directory.FullName.Length
                            - 4 // -CUT mark
                            - 4; // dots and slashes?
                        // var name = 
                        var name = f.Name.Substring(0, max);
						destinationPath = Path.Combine(f.Directory.FullName, $"{name}-CUT{f.Extension}"); // extension has dot
						sb.AppendLine($"SHORTENED: {entry.FullName} to {destinationPath}");
                        shortened++;
					}
                    entry.ExtractToFile(destinationPath);
                    sb.AppendLine($"Extracted: {destinationPath}");
                }
            }
        }

        sb.AppendLine($"shortened {shortened} file names;");
        txtReport.Text = sb.ToString();
    }

    private void Button10_Click(object sender, EventArgs e)
    {
        var folderName = _config.GetFolderName();
        var folder = new DirectoryInfo(folderName);
        var manifests = folder.GetFiles("manifest.txt", SearchOption.AllDirectories);

        txtReport.Text = "";
        foreach (var manifest in manifests)
        {
            var files = TurnItIn.GetFilesFromManifest(manifest).ToList();
            txtReport.Text += _config.UpdateDatabase(files);
        }
    }

    private void BtnOpenFolder_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtExcelFileName.Text))
            return;
        var f = new FileInfo(txtExcelFileName.Text);
        if (f.Exists)
            Process.Start(f.Directory.FullName);
    }

	private void BtnExportExcel_Click(object sender, EventArgs e)
	{
        ExcelPersistence.Write(_config);
	}

	private void button11_Click(object sender, EventArgs e)
	{
        var vals = txtSection.Items.OfType<string>().Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        if (string.IsNullOrWhiteSpace(txtSection.Text))
        {
            // get the first
            var f = vals.FirstOrDefault();
            if (f != null)
            {
                txtSection.Text = f;
				txtTextOrPointer.Focus();
			}
            return;
        }
        else
        {
            if (!vals.Any())
                return;
            var idx = vals.IndexOf(txtSection.Text) + 1;
            if (idx >= vals.Count)
                idx = 0;
            txtSection.Text = vals[idx];
            txtTextOrPointer.Focus();
        }
	}

	private void button12_Click(object sender, EventArgs e)
	{
        var htmlContent =
            """
			Version:0.9
			StartHTML:0000000192
			EndHTML:0000005886
			StartFragment:0000000228
			EndFragment:0000005850
			SourceURL:https://ev.turnitinuk.com/app/carta/en_us/?u=1519823&o=207253836&lang=en_us
			<html>
				<body>
					<!--StartFragment-->
					[CONT]
					<!--EndFragment-->
				</body>
			</html>
			""";

        var bold =
			"""
            <p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
            	<span style="box-sizing: border-box; font-weight: bold;">[CONT]</span>
            </p>
            """;
		var plain =
			"""
            <p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">[CONT]</p>
            """;

		var sb = new StringBuilder();
        var sub = GetCurrentSubmission();
        if (sub == null)
            return;
		_config.GetStudentFeedback(GetStudentNumber(), chkSendModerationNotice.Checked, sb, sub);
        var report = sb.ToString();
        var lines = report.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        StringBuilder reportLines = new StringBuilder();
        foreach (var line in lines)
        {
            if (line.StartsWith("#"))
            {
                reportLines.AppendLine(bold.Replace("[CONT]", line));
            }
            else
            {
                reportLines.AppendLine(plain.Replace("[CONT]", line));
            }
        }
        var tot = htmlContent.Replace("[CONT]", reportLines.ToString());
		Clipboard.SetText(tot, TextDataFormat.Html);
	}

	private void BtnImportExcel_Click(object sender, EventArgs e)
	{
        if (string.IsNullOrWhiteSpace(TxtExcelComponentSource.Text) || !File.Exists(TxtExcelComponentSource.Text))
        {
			openFileDialog1.DefaultExt = "xlsx";
			openFileDialog1.Multiselect = false;
			openFileDialog1.ShowDialog();
			if (openFileDialog1.FileName != "")
			{
				TxtExcelComponentSource.Text = openFileDialog1.FileName;
			}
            return;
		}
        string excelName = TxtExcelComponentSource.Text;
        txtReport.Text = ExcelPersistence.ReadComponents(_config, excelName);
	}
}
