using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LateBindingTest;
using StudentsFetcher.Properties;
using UnnFunctions.MCRF;
using UnnItBooster.Models;
using UnnItBooster.ModelConversions;
using ZedGraph;
using System.IO.Compression;
using UnnItBooster.StudentMarking;
using MathNet.Numerics;
using UnnFunctions.Models;
using System.Security.Cryptography.Xml;
using System.Runtime.Serialization.Formatters;
using MathNet.Numerics.Statistics;

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
        if (studNumber == -1)
        {
			LblMark.Text  = "-";
            return;
        }
        var calc = _config.GetMark(studNumber, ChkRoundupX9.Checked);
		LblMark.Text = calc == -1 ? "-" :  $"{calc}%";
	}

	private void UpdateStudentReport()
    {
        if (_config == null)
        {
            txtStudentreport.Text = "No config.";
			return;
        }
        LblOverlap.Text = "-";
        LblOverlap.ForeColor = Color.Black;
        
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
            LblOverlap.Text= $"Overlap: {submission.Overlap}%";
            if (int.TryParse(submission.Overlap, out var ovl))
            {
                if (ovl >= OverlapThreshold)
                    LblOverlap.ForeColor = Color.Red;
            }

            txtStudentreport.Text = _config.GetStudentReport(GetStudentNumber(), chkSendModerationNotice.Checked, ChkCommNumber.Checked);
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
			sb.AppendLine($"SUB_id\tSUB_LastName\tSUB_FirstName\tSUB_PaperID\tSUB_NumericUserID\tMARKS\ttotmark");
			foreach (DataRow item in dt.Rows)
            {
                int subId = Convert.ToInt32(item["SUB_id"].ToString());
				var totmark = mc.GetFinalMark(subId, _config, true);
                sb.AppendLine($"{item["SUB_id"]}\t{item["SUB_LastName"]}\t{item["SUB_FirstName"]}\t{item["SUB_PaperID"]}\t{item["SUB_NumericUserID"]}\t{item["MARKS"]}\t{totmark}");
                sbDataUpload.AppendFormat($"\"{item["SUB_LastName"]}\"\t\"{item["SUB_FirstName"]}\"\t\"{item["SUB_UserID"]}\"\t\"{item["SUB_NumericUserID"]}\"\t\"{item["SUB_email"]}\"\t\t\t\"{totmark}.00\"\n");
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
        return _config.GetStudentSubmission(numb);
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
        txtStudentId.Visible = true;
		if (e.KeyCode == Keys.Enter)
        {
            var addComponentMatch = Regex.Match(txtSearch.Text, "component (\\d+) (\\d+) (.*)", RegexOptions.IgnoreCase);
			var setComponentCommentMatch = Regex.Match(txtSearch.Text, "componentComment (\\d+) (.*)", RegexOptions.IgnoreCase);
			var idsMatch = Regex.Match(txtSearch.Text, "ids", RegexOptions.IgnoreCase);
            var editMatch = Regex.Match(txtSearch.Text, "^edit (?<par>last|\\?|\\d+)$", RegexOptions.IgnoreCase);
			var whoGotMatch = Regex.Match(txtSearch.Text, @"(WhoGotComment|WhoGot\w?) (?<commentId>\d+)", RegexOptions.IgnoreCase);
			var removeMatch = Regex.Match(txtSearch.Text, @"Remove (\d+)", RegexOptions.IgnoreCase);
			var levelMatch = Regex.Match(txtSearch.Text, @"setlevel (?<level>ug|pg)", RegexOptions.IgnoreCase);
			var selectModerationMatch = Regex.Match(txtSearch.Text, @"SelectModeration *(?<name>.*)$", RegexOptions.IgnoreCase);
			var associateMarkerMatch = Regex.Match(txtSearch.Text, @"^Associate ?Marker[s]?$", RegexOptions.IgnoreCase);
			var reportMarkerMatch = Regex.Match(txtSearch.Text, @"^Report ?Marker[s]?(\s+(?<options>-missing|-marks)?)?$", RegexOptions.IgnoreCase);
			var importMarksMatch = Regex.Match(txtSearch.Text, @"^Import ?Marker[s]?$", RegexOptions.IgnoreCase);
			var markingExcelsMatch = Regex.Match(txtSearch.Text, @"^Create ?MarkingFiles +(?<excelFileName>.*)$", RegexOptions.IgnoreCase);
            if (addComponentMatch.Success)
            {
                AddComponent(addComponentMatch);
                UpdateComponents();
            }
            else if (importMarksMatch.Success)
            {
                _config.GetExcelMarkedEntries(out var marks);
				txtLibReport.Text = SingleSubmissionMark.Report(marks);
			}
            else if (markingExcelsMatch.Success)
            {
                txtLibReport.Text = CreateExcelMarkers(markingExcelsMatch);
            }
			else if (reportMarkerMatch.Success)
			{
                var option = reportMarkerMatch.Groups["options"].Value;
                switch (option)
                {
                    case "-missing":
						var assignments = _config.GetMarkingAssignments();
                        _ = _config.GetExcelMarkedEntries(out var marks);
						txtLibReport.Text = ReportMarkersAvailability(assignments, marks);
						break;
					case "-marks":
						_ = _config.GetExcelMarkedEntries(out var marksToEvaluate);
						txtLibReport.Text = ReportMarkersMarks(_config.GetMarkingAssignmentsByStudents(), marksToEvaluate);
						break;
					default:
				        ReportMarkers();
                        break;
                }
			}
			else if (associateMarkerMatch.Success)
            {
                AssociateMarkers();
				ReportMarkers();
			}
			else if (editMatch.Success)
            {
                EditLoad(editMatch.Groups["par"].Value);
            }
            else if (selectModerationMatch.Success)
            {
				SelectModeration(selectModerationMatch.Groups["name"].Value);
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
			else if (
                txtSearch.Text.Equals("marks", StringComparison.OrdinalIgnoreCase)
                || txtSearch.Text.Equals("marks with emails", StringComparison.OrdinalIgnoreCase)
				)
            {
				GetMarks(txtSearch.Text);
			}
			else if (txtSearch.Text.Equals("turnitinsort", StringComparison.OrdinalIgnoreCase))
			{
				txtStudentId.Visible = false;
				GetTurnitinOrder();
			}
			else if (
                txtSearch.Text.Equals("stat", StringComparison.OrdinalIgnoreCase)
                || txtSearch.Text.Equals("stats", StringComparison.OrdinalIgnoreCase)
				|| txtSearch.Text.Equals("transcript", StringComparison.OrdinalIgnoreCase)
                )
			{
				ReportTranscript();
			}
			else if (txtSearch.Text.Equals("imagematch", StringComparison.OrdinalIgnoreCase))
			{
                txtLibReport.Text = _config?.ReportImageMatch(cmbDocuments.Text);
			}
			else if (txtSearch.Text.Equals("PrepareModeration", StringComparison.OrdinalIgnoreCase))
			{
                PrepareModeration();
			}
			else if (txtSearch.Text == "help")
            {
                txtLibReport.Text = """
                    component <order#> <percent> <Name>
                        Create a new marking compoenent

                    componentComment <order#> <comment> 
                        Add comment in the form: - {0} ability to ..., no quotes

                    edit last / ? / <Id#>
                        last: preloads the last comment to be modified
                        ? : reports the applied comments (and relative ids)                    
                        <Id#>: preloads the comment of type #Id for the current student to be modified

                    marks
                        if NumericUserIds in textbox (one per row), useful to fill MCRF 
                        otherwise produces all available marks
                        use 'marks with emails' to add the email address to the output

                    turnitinsort
                        produces the order of entries like turnitin would
                        Entries are then browsed +/- buttons as long as the text `turnitinsort` remains in the command line

                    Remove <commentId>
                       removes the comment from the current student by the ID of the comment

                    WhoGotComment <#>
                       lists students that got a specific comment in their feedback

                    stat|stats|transcript
                       Provides transcript information for the selected student, if available

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
                    
                    imagematch
                       identifies for images in the current word file and searches the others for same content

                    selectModeration
                        prepares the list of students to perform moderation
                        e.g. selectModeration KA7065

                    prepareModeration
                        prepares the moderation information for the student ShortIDs listed in the central part of the UI

                    Associate Markers
                        adds markers depending on the data below the command with the following structure:
                        <studentId> <markerEmail> <MarkerRole> <MarkerName>
                        22049588 ala.suliman@northumbria.ac.uk Supervisor Ala Suliman

                    Report Markers
                        Creates a report with marker association to submissions and missing entries

                    Create MarkingFiles <excelFileName>
                        creates a file ready to receive individual marker feedback
                        e.g. Create MarkingFiles markingTemplate.xlsx

                    Import Markers
                        reads externally marked excel files back into the database

                    <normal search>
                        separate text from section/area with `;`
                        ending the first term with a + searches in the pesonal text as well
                    """;
            }
            else
            {
                SearchCommentInLibrary();
                txtTextOrPointer.Focus();
            }
        }
        else if (e.KeyCode == Keys.ControlKey)
        {

        }
        else if (e.KeyCode == Keys.Back && e.Control)
        {
            txtSearch.Text = "";
            e.SuppressKeyPress = true;
        }
    }

	private string ReportMarkersMarks(IEnumerable<(string StudentId, string MarkerEmail, string MarkerRole)> enumerable, IEnumerable<SingleSubmissionMark> marksToEvaluate)
	{
		var sb = new StringBuilder();

        var dicStudentToMarkers = enumerable.GroupBy(x=>x.StudentId).ToDictionary(x=>x.Key, x=>x.Select(y=>(y.MarkerEmail, y.MarkerRole)).ToList()); 
		var marksGroups = marksToEvaluate.GroupBy(x => x.StudentId).ToList();

        int tallyCompleted = 0;
        int tallyPartial = 0;
        var stats = new List<DescriptiveStatistics>();

        foreach (var marksGroup in marksGroups)
        {
            bool studentCompleted = true;
            dicStudentToMarkers.TryGetValue(marksGroup.Key, out var assignedMarkers);
            sb.AppendLine($"Student: {marksGroup.Key}");
            foreach (var mark in marksGroup)
            {
                var m = mark.MarkerEmail;
                var assignemnt = assignedMarkers.First(x => x.MarkerEmail == m);
                sb.AppendLine($"- {mark.GetMark()} - {mark.MarkerEmail} - {assignemnt.MarkerRole} - {mark.Response.Comment}");
                assignedMarkers?.Remove(assignemnt); // if one is found we remove it from the list
            }
            if (assignedMarkers is not null)
            {
                if (assignedMarkers.Any())
                {
                    studentCompleted = false;
                }
                foreach (var item in assignedMarkers)
                {
                    sb.AppendLine($"- <missing> - {item}");
                }
            }
            var doubleMarks = marksGroup.Select(x => (double)x.GetMark());
            if (doubleMarks.Count() > 1)
            {
                stats.Add(new DescriptiveStatistics(doubleMarks));
			}

            if (studentCompleted)
                tallyCompleted++;
            else
                tallyPartial++;
			sb.AppendLine();
        }
		sb.AppendLine($"Completed: {tallyCompleted}");
		sb.AppendLine($"Partial:   {tallyPartial}");
		sb.AppendLine($"Missing:   {dicStudentToMarkers.Count() - tallyPartial - tallyCompleted}");
		sb.AppendLine($"Total:   {dicStudentToMarkers.Count()}");
		sb.AppendLine();
		sb.AppendLine($"Stats");
        foreach (var series in stats.OrderBy(x => x.Maximum - x.Minimum))
        {
            // sb.AppendLine($"- mean {series.Mean}, variance: {series.Variance}, stdev: {series.StandardDeviation}");
            sb.AppendLine($"- Mean: {series.Mean}, Minimum: {series.Minimum}, Maximum: {series.Maximum}, StDev: {series.StandardDeviation:0.##}, Range: {series.Maximum - series.Minimum}");
		}
		return sb.ToString();
	}

	private string ReportMarkersAvailability(IEnumerable<MarkingAssignment> assignments, IEnumerable<SingleSubmissionMark> marks)
	{
        var sb = new StringBuilder();
        var m = marks.GroupBy(x => x.MarkerEmail).ToDictionary(g => g.Key, g => g.ToList());
        foreach (var assignment in assignments)
        {
			if (!m.TryGetValue(assignment.MarkerEmail, out var marked))
			{
				sb.AppendLine($"Missing DATASET from: {assignment.MarkerEmail}");
			}
			else
			{
				foreach (var singleStudent in assignment.Details)
				{
                    if (!marked.Any(x => x.StudentId == singleStudent.StudentId))
                    {
                        sb.AppendLine($"Missing mark for: {assignment.MarkerEmail}, {singleStudent.StudentId}, {singleStudent.SubmissionId}");
                    }
				}
			}
		}
        return sb.ToString();
	}

	private string CreateExcelMarkers(Match markingExcelsMatch)
	{
        var f = markingExcelsMatch.Groups["excelFileName"].Value;
        var fl = _config.GetLocalizedPathFrom(f);
        if (fl == null)
            return "matching template not found.";
        if (!fl.Exists)
            return "Excel file template not found.";
        return _config.CreateExcelMarkingFilesFrom(fl);
	}

	private void ReportMarkers()
	{
        txtLibReport.Text = _config.ReportMarkers();
	}

	private void AssociateMarkers()
	{
        if (string.IsNullOrWhiteSpace(txtLibReport.Text))
            return;
        var assignments = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var r = new Regex(@"^(?<studId>\d+)\t+(?<email>[^ ]+)\t+(?<role>[^ ]+)\t+(?<name>.+)");
        foreach (var assignment in assignments)
        {
            var m = r.Match(assignment);
            if (m.Success)
            {
                var studId = m.Groups["studId"].Value;
                var mrkrEmail = m.Groups["email"].Value;
                var mrkrRole = m.Groups["role"].Value;
                var mrkrName = m.Groups["name"].Value;
                _config.EnsureMarker(studId,  mrkrEmail, mrkrName, mrkrRole);
            }
        }
	}

	private void SelectModeration(string name)
	{
        if (name == string.Empty)
        {
            txtStudentreport.Text = "Specify name of student collection to determine route.";
            return;
		}
        var studcoll = studentRepository.GetPersonCollections().FirstOrDefault(x => x.Name.Contains(name));

		var sb = new StringBuilder();
		if (studcoll == null)
		{
            sb.AppendLine("Student collection not found.");
		}
		var collections = new Dictionary<string, ModerationCollection>();
		var mc = _config.GetMarkCalculator();
		foreach (var sub in _config.GetStudentSubmissions())
        {
            //var stud = studentRepository.GetStudentById(sub.NumericUserId);
            var grp = "Not found";
            var stud = studentRepository.GetStudentById(sub.NumericUserId, studcoll);
            if (stud is not null)
            {
				grp = $"{stud.CourseYear} {stud.Occurrence}";
                if (string.IsNullOrWhiteSpace(grp))
                {
                    grp = "No data";
				}
            }
            var totmark = mc.GetFinalMark(sub.InternalShortId, _config, true);
            var t = new ModerationEntry(sub, totmark);

            if (!collections.TryGetValue(grp, out var collection))
            {
                collection = new ModerationCollection();
                collections.Add(grp, collection);
            }
            collection.Add(t);
		}
        
        foreach (var collectionPair in collections)
        {
            sb.AppendLine(collectionPair.Key);
            sb.AppendLine();
            sb.AppendLine(collectionPair.Value.Report());
        }
        txtStudentreport.Text = sb.ToString();
	}

	private void PrepareModeration()
	{
        if (_config == null)
            return;
        StringBuilder errBuilder = new StringBuilder(); 
		StringBuilder sb = new StringBuilder();
        var ids = GetSimpleIds().ToList();
        errBuilder.AppendLine($"{ids.Count} to process.");
        errBuilder.AppendLine();

		sb.AppendLine("# Selected sample");

		var mc = _config.GetMarkCalculator();
		sb.AppendLine($"| SUB_NumericUserID | SUB_FirstName | SUB_LastName | SUB_PaperID | Mark         |");
		sb.AppendLine($"| ----------------- | ------------- | ------------ | ----------- | ------------ |");
		foreach (var item in ids)
        {
			var totmark = mc.GetFinalMark(item, _config, true);
            var sub = _config.GetStudentSubmission(item);
            if (sub is not null)
                sb.AppendLine($"| {sub.NumericUserId} | {sub.FirstName}| {sub.LastName}  | {sub.PaperId} | {totmark}% |");
            else
                sb.AppendLine($"Error: {item}");
		}
        sb.AppendLine();

		foreach (int item in ids)
        {
            var success = PrepareModeration(sb, item);
            if (!success)
                errBuilder.AppendLine($"Error on: {item}");

		}
		errBuilder.AppendLine(sb.ToString());
        txtStudentreport.Text = errBuilder.ToString();
	}

	private bool PrepareModeration(StringBuilder sb, int shortId)
	{
        // prepares the text, 
        sb.AppendLine(_config.GetStudentReport(shortId, false, false));
		// and copies the file to a custom folder
		var stud = _config.GetStudentSubmission(shortId);
        if (stud is null)
            return false;
		FileInfo f = new FileInfo(Path.Combine(_config.GetFolderName(), stud.Title));
        if (!f.Exists)
            return false;
		var destName = Path.Combine(_config.GetFolderName(), "ModF");
        if (!Directory.Exists(destName))
            Directory.CreateDirectory(destName);
        destName = Path.Combine(destName, f.Name);
        f.CopyTo(destName, true);
        return true;
	}

	private IEnumerable<int> GetSimpleIds()
	{
        var lines = txtLibReport.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line) && int.TryParse(line, out var simpleId))
            {
                yield return simpleId;
            }
        }
	}

	private void GetTurnitinOrder()
	{
        StringBuilder stringBuilder = new StringBuilder();
        var res = _config.GetDataTable("SELECT SUB_ID, SUB_LastName, SUB_Overlap from TB_Submissions order by cast (SUB_Overlap as INT) , SUB_LastName");
        //foreach (DataRow row in res.Rows)
        //{
        //    stringBuilder.AppendLine(row[0].ToString());
        //}
        for (int i = 51; i> 0;i--)
			stringBuilder.AppendLine(i.ToString());
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
					{"3", "insufficient"},
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
        var sql = "SELECT SCOM_ptr_Submission, TB_Submissions.SUB_UserID FROM TB_SubComments inner join TB_Submissions on SCOM_ptr_Submission = SUB_ID where SCOM_ptr_comment = " + m4.Groups["commentId"].Value;
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

    private void GetMarks(string text)
    {
        StringBuilder sb = new StringBuilder();
        string[] ids;
		if (string.IsNullOrWhiteSpace(txtLibReport.Text))
			ids = _config.GetStudentIds();
        else
            ids = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

        var WithEmail = text.ToLowerInvariant().Contains("email");
            
        var markgen = _config.GetMarkCalculator();
        foreach (var fullStringId in ids)
        {
			var idParts = fullStringId.Split(new[] { "/" }, StringSplitOptions.None);
			var useId = (idParts.Length == 2)
                ? idParts[0]
                : fullStringId;
			var	intId = _config.GetStudentShortId(useId, out string email);
            var result = markgen.GetFinalMark(intId, _config, true).ToString();
			if (!WithEmail)
                sb.AppendLine($"{fullStringId}\t{result}");
            else
                sb.AppendLine($"{fullStringId}\t{result}\t{email}");
        }
        txtStudentreport.Text = sb.ToString();


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

        sql += " order by COMM_section";


		var sb = new StringBuilder();
        var dt = _config.GetDataTable(sql);
        var section = "";
        foreach (DataRow item in dt.Rows)
        {
            var thisSection = item["COMM_section"].ToString();
            if (section != thisSection)
            {
                sb.AppendLine($"Section: {thisSection}\r\n");
                section = thisSection;
            }
            sb.AppendLine($"{item["COMM_Id"]}: (/{item["COMM_Area"]})");
			sb.AppendLine($"{item["COMM_Text"]}");
            if (bExtended)
                sb.AppendLine($"\r\nSubComment: {item["SCOM_AddNote"]}");
            sb.AppendLine();
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
        else
        {

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
                try
                {
					var desc = item["CPNT_Comment"].ToString();
                    cmp.ComponentDescription = desc;
				}
                catch (Exception)
                {
                }
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
                    repvalue = mcalc.GetFinalMark(iStudentId, _config, true).ToString();
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
        if (_config is null)
            return;
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
                int ProgressiveId = Convert.ToInt32(item["SUB_Id"]);
				string localDateTime = "";
                var date = item["markDate"];
                if (date is string s)
                {
                    DateTime convertedDate = DateTime.SpecifyKind(DateTime.Parse(s), DateTimeKind.Utc);
                    var local = convertedDate.ToLocalTime();
                    localDateTime = local.ToShortDateString() + " " + local.ToShortTimeString();
				}
				var lvi = new ListViewItem();
                lvi.Text = $"{item["SUB_FirstName"]} {item["SUB_LastName"]} ({ProgressiveId})";
                lvi.Tag = ProgressiveId;
				lvi.SubItems.Add(item["marks"].ToString());
                var numUID = item["SUB_NumericUserId"].ToString();
                lvi.SubItems.Add(mcalc.GetFinalMark(ProgressiveId, _config, true).ToString());
                lvi.SubItems.Add(localDateTime);
                lvi.SubItems.Add(item["NumComments"].ToString());
                lvi.SubItems.Add($"Overalp: {item["SUB_Overlap"]} Internet: {item["SUB_InternetOverlap"]} Pub: {item["SUB_PublicationsOverlap"]} Student: {item["SUB_StudentPapersOverlap"]}");

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
        var tag = ((ComboTag)CmbGrouping.SelectedItem).Tag;
        var mode = (MarksCollection.grouping)tag;
        var coll = MarksCollection.Initialize(mode);
        if (ChkExclude0.Checked)
            coll.RemoveZeros();
        if (ChkIncludeNoMark.Checked)
            coll.Ranges.Add(new MarkRange(-1, -1));
        var mcalc = _config.GetMarkCalculator();
        var sql = "SELECT sub_id, sub_userid, sub_numericUserId FROM TB_Submissions";
        var dt = _config.GetDataTable(sql);
        var collectionForStats = new List<double>();
        
        foreach (DataRow rw in dt.Rows)
        {
            if (!int.TryParse(rw[0].ToString(), out var id))
                continue;
            var isEven = id % 2 == 0;
            if (isEven && !ChkEvenRows.Checked)
                continue;
			if (!isEven && !ChkOddRows.Checked)
				continue;
			var mk = mcalc.GetFinalMark(id, _config, ChkRoundupX9.Checked);
            if (mk != -1)
            {
                mk += Convert.ToInt16(NudMarkOffset.Value);
                if (mk < 0)
                    mk = 0;
                if (mk > 100)
                    mk = 100;
            }
			coll.Add(mk);
            if (mk != -1)
                collectionForStats.Add(mk);
        }
        if (ChkExclude0.Checked)
            collectionForStats.RemoveAll(x => x == 0);

        var quartiles = MathNet.Numerics.Statistics.Statistics.FiveNumberSummary(collectionForStats);
        var quartileSize = new List<double>();
        for (int i = 1; i < quartiles.Length; i++)
        {
            quartileSize.Add(quartiles[i] - quartiles[i-1]);
        }
		txtReport.Text = 
            $"Mean = {MathNet.Numerics.Statistics.Statistics.Mean(collectionForStats)},\r\n" +
            $"StandardDeviation = {MathNet.Numerics.Statistics.Statistics.StandardDeviation(collectionForStats)},\r\n" +
            $"Skewness = {MathNet.Numerics.Statistics.Statistics.Skewness(collectionForStats)},\r\n" +
            $"Kurtosis = {MathNet.Numerics.Statistics.Statistics.Kurtosis(collectionForStats)} (normal distribution is 3),\r\n" +
            $"Quartiles = {string.Join(", ", quartiles.Select(x => x.ToString("0.00")))}, \r\n" +
            $"QuartileSized = {string.Join(", ", quartileSize.Select(x=>x.ToString("0.00")))}, \r\n";

		var list = new PointPairList();
        foreach (var grp in coll.Ranges)
        {
            list.Add(grp.Place, grp.Count, grp.Description);
            // list.Add(grp.Place, grp.Count);
		}
        var gPane = zedGraphControl1.GraphPane;
        gPane.CurveList.Clear();
        gPane.GraphObjList.Clear();
        var myBar = gPane.AddBar("Marks", list, Color.Blue);
        var max = coll.MaxCount;
        // adding labels
		for (int i = 0; i < myBar.Points.Count; i++)
		{
			TextObj barLabel = new TextObj(myBar.Points[i].Tag.ToString(), myBar.Points[i].X, myBar.Points[i].Y + 2);
			barLabel.FontSpec.Border.IsVisible = false;
            barLabel.FontSpec.Size = barLabel.FontSpec.Size / 2;
			gPane.GraphObjList.Add(barLabel);
		}

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
        var values = Enum.GetValues(typeof(MarksCollection.grouping)).OfType<MarksCollection.grouping>().Select(x => new ComboTag(x.ToString(), x));
        CmbGrouping.Items.AddRange(values.ToArray());
        CmbGrouping.SelectedIndex = 0;
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
        TurnItIn.PopulateDatabase(destFile, submissions, txtElpCode.Text);
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
        txtReport.Text = TurnItIn.UpdateDatabase(txtExcelFileName.Text, submissions, txtElpCode.Text);
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
                    if (File.Exists(destinationPath))
                        File.Delete(destinationPath);
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
        if (ToggleSection())
            txtTextOrPointer.Focus();
	}

    
    /// <returns>True if a successful value is toggled</returns>
	private bool ToggleSection()
	{
		var vals = txtSection.Items.OfType<string>().Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
		if (string.IsNullOrWhiteSpace(txtSection.Text))
		{
			// get the first
			var f = vals.FirstOrDefault();
			if (f != null)
			{
				txtSection.Text = f;
                return true;
			}
            return false;
		}
		else
		{
			if (!vals.Any())
				return false;
			var idx = vals.IndexOf(txtSection.Text) + 1;
			if (idx >= vals.Count)
				idx = 0;
			txtSection.Text = vals[idx];
            return true;
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

	private void txtTextOrPointer_OnCtrlTab()
	{
        txtAdditionalNote.Focus();
	}

	private void BtnEditLast_Click(object sender, EventArgs e)
	{
        EditLoad("last");
	}

	private void BtnShowStudentStat_Click(object sender, EventArgs e)
	{
		ReportTranscript();
	}

    private double OverlapThreshold
    {
        get
        {
            return (double)NudOverlap.Value;
        }
    }

    private bool txtTextOrPointer_OnCtrlKey(string key)
    {
		switch (key)
		{
			case "R, Control":
				ToggleSection();
				return true;
			case "S, Control":
				txtSearch.Focus();
				return true;
		}

		return false;
    }

    private void BtnMergeReport_Click(object sender, EventArgs e)
    {
        var scale = 1.0;
        if (double.TryParse(TxtScaleFactor.Text, out var scl))
            scale = scl;

        if (string.IsNullOrEmpty(TxtMergeReportFolder.Text))
        {
            openFileDialog1.DefaultExt = "html";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                FileInfo f = new FileInfo(openFileDialog1.FileName);
                if (!f.Exists)
                    return;
                TxtMergeReportFolder.Text = f.Directory.FullName;
            }
        }
        else if (Directory.Exists(TxtMergeReportFolder.Text))
        {
            DirectoryInfo d = new DirectoryInfo(TxtMergeReportFolder.Text);
            var htmls = d.GetFiles("AI Detection *.html");
            foreach (var html in htmls)
            {
                ProcessFile(html, scl);
            }
        }
        else if (File.Exists(TxtMergeReportFolder.Text))
        {
            var f = new FileInfo(TxtMergeReportFolder.Text);
			ProcessFile(f, scl);
		}
    }

	private void ProcessFile(FileInfo html, double scl)
	{
        DirectoryInfo d = html.Directory;
		var r = new Regex("AI Detection (?<name>.*)\\.html");
		var m = r.Match(html.Name);
		if (!m.Success)
			return;
		var name = m.Groups["name"].Value;
		var referenceDet = new FileInfo(Path.Combine(d.FullName, $"Reference Detection {name}.txt"));
		if (!referenceDet.Exists)
			return;
		TurnitinHtmlReports.Merge(html, referenceDet, name, scl);
	}

	internal void SetSqlFile(string v)
	{
        txtExcelFileName.Text = v;
        // Reload();
	}
}
