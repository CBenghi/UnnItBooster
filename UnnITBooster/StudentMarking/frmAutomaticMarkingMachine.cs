using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LateBindingTest;
using StudentsFetcher.Properties;
using StudentsFetcher.Turnitin;
using StudentsFetcher.Webdata;
using UnnFunctions.MCRF;
using ZedGraph;

namespace StudentsFetcher.StudentMarking
{
    [AMMFormAttributes(ButtonText = "Automatic marking machine", Order = 1)] 
    public partial class FrmAutomaticMarkingMachine : Form
    {
        private ClsConfig _config;

        public FrmAutomaticMarkingMachine()
        {
            InitializeComponent();
            LoadSettings();
        }
        
        #region marking
        
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
        }

        private void UpdateStudentMarksUi()
        {
            foreach (var item in flComponents.Controls)
            {
                var creset = item as ucComponentMark;
                creset.Unset();
            }

            if (GetStudentNumber() != -1)
            {
                var sql = "select * from TB_Marks where MARK_ptr_Submission = " + GetStudentNumber();
                var dt = _config.GetDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    var cmp = Convert.ToInt32(item["MARK_ptr_Component"]);
                    var val = Convert.ToInt32(item["MARK_Value"]);

                    // MARK_ptr_Component
                    // MARK_Value

                    if (cmp == -1)
                        cmp = 0;
                    
                    var m = flComponents.Controls[cmp] as ucComponentMark;
                    m.TabStop = false;
                    m.MarkValue = val;
                }
                cmdSaveMarks.BackColor = Color.Transparent;
            }
        }

        private void UpdateStudentReport()
        {
            if (GetStudentNumber() != -1)
            {
                txtStudentreport.Text = _config.GetStudentReport(GetStudentNumber(), chkSendModerationNotice.Checked);
                UpdateDocumentsList();

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

                var mc =  _config.GetMarkCalculator();
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

        private void UpdateDocumentsList()
        {
            cmbDocuments.Items.Clear();
            var stud = _config.GetStudentRow(GetStudentNumber());
            if (stud == null)
                return;
            var sId = stud["sub_userid"].ToString();
            var folderName = _config.GetFolderName();

            // this submission files
            var validFiles = GetValidFiles(folderName, sId).ToArray();
            cmbDocuments.Items.AddRange(validFiles);

            var other = folderName + relFolder.Text;
            var d = new DirectoryInfo(other);
            var otherFiles = GetValidFiles(other, sId).ToArray();
            if (otherFiles.Length == 1)
            {
                cmdCompare.Tag = otherFiles[0];
                cmdCompare.Enabled = true;
            }
            else
                cmdCompare.Enabled = false;


            if (cmbDocuments.Items.Count > 0)
            {
                cmbDocuments.SelectedIndex = 0;
            }

            cmbDocuments.ForeColor = 
                cmbDocuments.Items.Count > 1 
                ? Color.Red 
                : Color.Black;

        }

        private List<string> GetValidFiles(string fname, string sId)
        {
            var validFiles = new List<string>();
            var d = new DirectoryInfo(fname);
            if (!d.Exists)
                return validFiles;
            var dirs = d.GetDirectories();
            
            foreach (var item in dirs)
            {
                var files = item.GetFiles(sId + "*.*");
                foreach (var file in files)
                {
                    var subfile = Path.Combine(item.Name, file.Name);
                    validFiles.Add(subfile);
                    
                }
            }
            return validFiles;
        }

        private int GetStudentNumber()
        {
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
                var m = Regex.Match(txtSearch.Text, "component (\\d+) (\\d+) (.*)");
                var m2 = Regex.Match(txtSearch.Text, "marks (\\d+)");
                var m3 = Regex.Match(txtSearch.Text, "ids");
                var m4 = Regex.Match(txtSearch.Text, @"WhoGotComment (\d+)");
                var m5 = Regex.Match(txtSearch.Text, @"Remove (\d+)");
                if (m.Success)
                {
                    AddComponent(m);
                    UpdateComponents();
                }
                else if (m2.Success)
                {
                    GetMarks(m2);
                }
                else if (m3.Success)
                {
                    GetIds();
                }
                else if (m4.Success)
                {
                    GetCommentUse(m4);
                }

                else if (m5.Success)
                {
                    RemoveComment(m5);
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
                else if (txtSearch.Text == "help")
                {
                    txtLibReport.Text =
                        "component <order#> <percent> <Name>\r\n" +
                        "marks <component#>\r\n" +
                        "   use 'marks 0' for MCRF\r\n" +
                        "   required ids in textbox (one per row)\r\n " +
                        "CommentCount\r\n" +
                        "   SELECT count(scom_id) as count, SCOM_ptr_Submission FROM TB_SubComments group by SCOM_ptr_Submission order by count(scom_id) desc\r\n" +
                        "WhoGotComment <#>\r\n" +
                        "   lists students that got a specific comment in their feedback\r\n " +
                        "ids\r\n" +
                        "   produces 2 list of ids (numeric and alfanumeric versions)\r\n" +
                        "WriteFeedbackFile\r\n" +
                        "   writes student feedback each in an individual file\r\n" +
                        "mcrfcheck\r\n" +
                        "   grabs the values copied from an MCRF cut and paste and tidies it up\r\n" +
                        "missing\r\n" +
                        "   finds marks not added to mcrf (use all relevant lists)" +
                        "   required ids in textbox (one per row, e.g. '11039298/1')\r\n ";


                }
                else
                {
                    SearchCommentInLibrary();
                }
            }
        }

        private void WriteFeedbackFile()
        {
            var folderName = Path.Combine(_config.GetFolderName(), "Feedback");
            var di = new DirectoryInfo(folderName);
            if (!di.Exists)
                di.Create();
            var sql = "select  *, (SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks from tb_submissions";
            var dt = _config.GetDataTable(sql);

            foreach (DataRow item in dt.Rows)
            {
                var id = Convert.ToInt32(item["SUB_id"]);
                var stringId = item["SUB_UserId"].ToString();
                var fi = new FileInfo(Path.Combine(folderName, stringId + ".txt"));
                using (var w = fi.CreateText())
                {
                    w.WriteLine(_config.GetStudentReport(id, chkSendModerationNotice.Checked));
                }
            }
        }

        private void CleanMcrf()
        {
            McrfTextParser p = new McrfTextParser();
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

            txtLibReport.Text = "Submissions:\r\n";
            var sql = "delete from TB_SubComments where "
                      + "SCOM_ptr_Submission = " + GetStudentNumber() 
                      +" AND SCOM_ptr_Comment = " + m5.Groups[1].Value;


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

                var rEx = new Regex("" + lookForId +@"/(\d)");

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
            var sql = "SELECT SCOM_ptr_Submission FROM TB_SubComments where SCOM_ptr_comment = " + m4.Groups[1].Value;
            var dt = _config.GetDataTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                txtLibReport.Text += item[0] + "\r\n";
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

        private void GetMarks(Match m)
        {
            // string component = m.Groups[1].ToString();
            var ids = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
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
                txtStudentreport.Text += string.Format("{0}\t{1}\r\n", idWithSlash, result);
            }
        }

        private void AddComponent(Match m)
        {
            string sql;
            var compOrder = m.Groups[1].ToString();
            var compPercent = m.Groups[2].ToString();
            var compTitle = m.Groups[3].ToString();

            sql = "delete from TB_Components where CPNT_Order = " + compOrder;
            _config.Execute(sql);

            sql = "insert into TB_Components (CPNT_Order, CPNT_Percent, CPNT_Name) values (" +
                compOrder + ", " +
                compPercent + ", " +
                "'" + compTitle.Trim().Replace("'", "''") + "' " +
                ")";
            _config.Execute(sql);
        }

        private void SearchCommentInLibrary()
        {
            var bExtended = false;
            txtLibReport.Text = "Problem";
            var sarr = txtSearch.Text.Split(';');
            if (sarr.Count() == 0)
                return;

            var sql = "select * from TB_Comments where ";
            if (sarr.Count() == 1)
            {
                sql += "COMM_Text like '%" + sarr[0] + "%'";
                if (sarr[0].EndsWith("+"))
                {
                    var val = sarr[0].Substring(0, sarr[0].Length - 1);
                    sql = "select * from QComments where SCOM_AddNote like '%" + val + "%'";
                    bExtended = true;
                }
            }
            else if (sarr.Count() > 1)
            {
                sql += "[COMM_section] like '%" + sarr[0] + "%' ";
                txtSection.Text = sarr[0].ToUpper();
                if (sarr[1].Length > 0)
                {
                    txtArea.Text = sarr[1].ToUpper();
                    sql += "and [COMM_Area] like '%" + sarr[1] + "%' ";
                }
                if (sarr.Length > 2 && sarr[2].Length > 0)
                {
                    sql += "and [COMM_Text] like '%" + sarr[2] + "%' ";
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
            var reference = -1;
            var isok = Int32.TryParse(txtTextOrPointer.Text, out reference);
            if (!isok)
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
            txtTextOrPointer.Text = "";
            txtAdditionalNote.Text = "";
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // txtTextOrPointer.SelectAll();
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
            }
        }

        private void txtExcelFileName_TextChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            if (!File.Exists(txtExcelFileName.Text))
                return;
            _config = new ClsConfig();
            _config.DbName = txtExcelFileName.Text;
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            // combo 
        
            cmbComponentComment.Items.Clear();
            var cid = new comboId { text = "<general>", value = -1, percent = 0};
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
                    var c = new comboId
                    { 
                        text = item["CPNT_Name"].ToString(), 
                        value = order, 
                        percent = ipercent 
                    };
                    // cmbComponentMark.Items.Add(c);
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

        void cmp_onUserChange(object sender, EventArgs e)
        {
            cmdSaveMarks.BackColor = Color.Red;
        }

        class comboId
        {
            public string text;
            public int value;
            public int percent;

            public override string ToString()
            {
                return string.Format("{0} (#{1} - {2}%)", text, value, percent);
            }
        }

        //int GetComponent()
        //{
        //    int iComponent = -1;
        //    if (cmbComponentMark.SelectedItem != null)
        //    {
        //        iComponent = ((comboId)cmbComponentMark.SelectedItem).value;
        //    }
        //    return iComponent;
        //}

        int GetComponentComment()
        {
            var iComponent = -1;
            if (cmbComponentComment.SelectedItem != null)
            {
                iComponent = ((comboId)cmbComponentComment.SelectedItem).value;
            }
            return iComponent;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (GetStudentNumber() == -1)
            {
                MessageBox.Show("Need student");
                return;
            }

            if (false)
            {
                //int iComponent = GetComponent();

                //string sql = "";
                //sql = "delete from TB_Marks " +
                //    "where MARK_ptr_Submission = " + GetStudentNumber() + " " +
                //    "and MARK_ptr_Component = " + iComponent;
                //Config.Execute(sql);

                //int markvalue;
                //bool isvalid = int.TryParse(txtMarkValue.Text, out markvalue);
                //if (isvalid)
                //{
                //    sql = "insert into TB_Marks (MARK_ptr_Submission, MARK_ptr_Component, MARK_Value) " +
                //            "values (" +
                //        GetStudentNumber() + ", " +
                //        iComponent + ", " +
                //        txtMarkValue.Text +
                //        ")";
                //    Config.Execute(sql);
                //}
            }
            var sql = "";
            sql = "delete from TB_Marks " +
                  "where MARK_ptr_Submission = " + GetStudentNumber();
            _config.Execute(sql);

            foreach (var comp in flComponents.Controls)
            {
                var c = comp as ucComponentMark;
                if (c.IsSet)
                {
                    var markvalue = c.MarkValue;
                    var iComponent = c.Id;


                    sql = "insert into TB_Marks (MARK_ptr_Submission, MARK_ptr_Component, MARK_Value, MARK_Date) " +
                          "values (" +
                          GetStudentNumber() + ", " +
                          iComponent + ", " +
                          markvalue + "," +
                          "datetime('now')" +
                          ")";
                    _config.Execute(sql);
                }  
            }
            cmdSaveMarks.BackColor = Color.Transparent;


            UpdateStudentReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbDocuments.Text != "")
            {
                var fullname = Path.Combine(
                    _config.GetFolderName(),
                    cmbDocuments.Text);
                Process.Start(fullname);
            }
        }
    
        #endregion


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
    
            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            var app = new OutlookEmailerLateBinding();
            var replacements = GetReplacementList(txtEmailBody.Text);
            foreach (ListViewItem studentId in lstEmailSendSelection.Items)
            {
                if (!studentId.Checked)
                    continue;

                var iStudentId = (int)studentId.Tag;
                DataRow row;
                var emailtext = Emailtext(replacements, iStudentId, mcalc, out row);
                var DestEmail = row["SUB_email"].ToString();

                if (!chkEmailDryRun.Checked)
                    app.SendOutlookEmail(DestEmail, txtEmailSubject.Text, emailtext);
                else
                    Debug.WriteLine(emailtext);
            }

            MessageBox.Show("Done");
        }

        private string Emailtext(int iStudentId)
        {
            var mcalc = _config.GetMarkCalculator();
            var replacements = GetReplacementList(txtEmailBody.Text);
            DataRow row;
            var emailtext = Emailtext(replacements, iStudentId, mcalc, out row);
            return emailtext;
        }

        private string Emailtext(IEnumerable<string> replacements, int iStudentId, MarksCalculator mcalc, out DataRow row)
        {
            var emailtext = txtEmailBody.Text;
            row = _config.GetStudentRow(iStudentId);
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
                    {
                        var p = new Programme(row["SUB_NumericUserId"].ToString());
                        repvalue = p.ShortMarksReport();
                    }
                        break;
                    default:
                        try
                        {
                            repvalue = row[item].ToString();
                        }
                        catch (Exception ex)
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

        public void Boh()
        {
            //string[] wholenames = wholename.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //string firstnames = wholenames[1];
            //string[] firstnamesA = firstnames.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string firstname = firstnamesA[0];

            //string tutorName = row["Tutor"].ToString().ToLower();
            //string[] tArr = tutorName.Split(new char[] { ' ' });
            //string tName = textInfo.ToTitleCase(tArr[1] + " " + tArr[0]);
        }

        private void cmdGetData_Click(object sender, EventArgs e)
        {
            if (!chkImportComponents.Checked && !chkCommentLib.Checked && !chkImportSubmissions.Checked)
                return;

            var sql = "";
            sql += string.Format( "ATTACH \"{0}\" AS {1}; ", txtSourceDataFile.Text, "OTHERDB");
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
                sql += "insert into TB_Submissions (SUB_LastName, SUB_FirstName, SUB_UserID, SUB_TurnitinUserID, SUB_NumericUserID, SUB_email, SUB_Title, SUB_PaperID, SUB_DateUploaded, SUB_Grade, SUB_Overlap, SUB_InternetOverlap, SUB_PublicationsOverlap, SUB_StudentPapersOverlap) select SUB_LastName, SUB_FirstName, SUB_UserID, SUB_TurnitinUserID, SUB_NumericUserID, SUB_email, SUB_Title, SUB_PaperID, SUB_DateUploaded, SUB_Grade, SUB_Overlap, SUB_InternetOverlap, SUB_PublicationsOverlap, SUB_StudentPapersOverlap from OTHERDB.TB_Submissions; ";
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

        private void button5_Click(object sender, EventArgs e)
        {
            MoveStudent(1);
        }

        private void MoveStudent(int Delta)
        {
            var iSN = GetStudentNumber();
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

        private void cmdGetImages_Click(object sender, EventArgs e)
        {
            var filesDir = Path.Combine(folder, "Pics");
            var dt = _config.GetDataTable("SELECT * from tb_submissions");
            var iOk = 0;
            var iErr = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (GetImage(filesDir, item["SUB_NumericUserID"].ToString()))
                    iOk++;
                else
                {
                    iErr++;
                }
            }
            MessageBox.Show(string.Format("OK: {0}\r\nErr:{1}", iOk, iErr), "Info", MessageBoxButtons.OK);
        }

        private string folder
        {
            get
            {
                return new FileInfo(txtExcelFileName.Text).DirectoryName;
            }
        }

        static internal bool GetImage(string destfolder, string sid)
        {
            var req = new WebClient();
            var url = string.Format(@"http://nuweb2.northumbria.ac.uk/photoids/{0}.jpg", sid);


            var destfilename = sid + ".jpg";

            if (!Directory.Exists(destfolder))
                Directory.CreateDirectory(destfolder);
            destfilename = Path.Combine(destfolder, destfilename);
            try
            {
                if (!File.Exists(destfilename))
                {
                    req.DownloadFile(url, destfilename);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
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
            var NumId = numeriCuserID + ".jpg";
            var filesDir = StudentsData.PictureFolder;
            var fullName = Path.Combine(filesDir, NumId);
            if (File.Exists(fullName))
                StudImage.Load(fullName);
            else
                StudImage.Image = null;
        }

        private void txtTextOrPointer_OnCtrlEnter()
        {
            DoAdd();
        }

        private void txtAdditionalNote_OnCtrlEnter()
        {
            DoAdd();
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
            txtEmailBody.Text =
@"Dear {SUB_FirstName}, 
as we have recently marked your XXXX submission, I'm now writing to inform you of the outcome. 
At this stage your mark is unconfirmed; marks become confirmed after the Progression and Awards Board for your programme, that is scheduled for the XXXXX.
Your marks will be visible on formal trascripts shortly after that.

Please find your feedback and unconfirmed mark after my signature.

Best regards, 
Claudio 

{MarkReport}";
        }
       
        private void cmdOpenOther_Click(object sender, EventArgs e)
        {
            if (cmdCompare.Tag == null)
                return;
            var fullname = Path.Combine(_config.GetFolderName() + relFolder.Text, cmdCompare.Tag.ToString());
            Process.Start(fullname);       
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            var com1 = Path.Combine(_config.GetFolderName(), cmbDocuments.Text);
            var com2 = Path.Combine(_config.GetFolderName() + relFolder.Text, cmdCompare.Tag.ToString());

            var pars = string.Format("\"{0}\" \"{1}\"", com1, com2);

            Process.Start(
                @"C:\Program Files (x86)\WinMerge\WinMergeU.exe",
                pars
                );
        }

        private void btnCompleteData_Click(object sender, EventArgs e)
        {
            int cntOk = 0;
            int cntErr = 0;
            var dt = _config.GetDataTable("select * from tb_submissions");
            foreach (DataRow dataRow in dt.Rows)
            {
                var email = dataRow["SUB_email"].ToString();
                var numericId = dataRow["SUB_NumericUserId"].ToString();
                var northumbriaStringId = dataRow["SUB_UserId"].ToString();
                var uid = dataRow["SUB_Id"].ToString();
                if (!string.IsNullOrWhiteSpace(email))
                    continue;
                var sRes = new StudentResolver();
                var student = sRes.ResolveById(northumbriaStringId);
                if (student == null)
                {
                    cntErr++;
                    continue;
                }


                var sql = "UPDATE TB_Submissions " +
                    $"SET SUB_email = '{student.Email}', " +
                    $"SUB_NumericUserId = '{student.NumericStudentId}' " +
                    $"WHERE SUB_Id = {uid} ";

                _config.Execute(sql);

                cntOk++;
            }
            MessageBox.Show($"Ok: {cntOk} Err: {cntErr}");



        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
                return;
            var excelName = openFileDialog1.FileName;

            if (!File.Exists(excelName))
            {
                MessageBox.Show("Excel File not found");
                return;
            }

            var con =
                new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelName +
                                    ";Extended Properties=Excel 8.0;"); // Extended Properties=Excel 8.0;
            con.Open();
            var da = new OleDbDataAdapter("select * from [Sheet1$]", con);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            var iInserted = 0;
            foreach (DataRow row in dt.Rows)
            {
                
                var uid = row["User ID"].ToString();

                var existing = _config.GetStudentRow(uid);
                if (existing != null)
                    continue;

                var sql =
                    "insert into TB_Submissions (SUB_LastName, SUB_FirstName , SUB_UserID, SUB_TurnitinUserID, SUB_Title, SUB_PaperID, SUB_DateUploaded, SUB_Grade, SUB_Overlap, SUB_InternetOverlap, SUB_PublicationsOverlap, SUB_StudentPapersOverlap) " +
                    "values ('" + row["Last Name"].ToString().Replace("'", "''") + "','" +
                    row["First Name"].ToString().Replace("'", "''") + "','"
                    + row["User ID"].ToString().Replace("'", "''") + "','" +
                    row["Turnitin User ID"].ToString().Replace("'", "''") + "','" +
                    row["Title"].ToString().Replace("'", "''") + "','" + row["Paper ID"].ToString().Replace("'", "''") +
                    "','" + row["Date Uploaded"].ToString().Replace("'", "''") + "','" +
                    row["Grade"].ToString().Replace("'", "''") + "','" + row["Overlap"].ToString().Replace("'", "''") +
                    "','" + row["Internet Overlap"].ToString().Replace("'", "''") + "','" +
                    row["Publications Overlap"].ToString().Replace("'", "''") + "'," +
                    "'" + row["Student Papers Overlap"].ToString().Replace("'", "''") + "'" +
                    //"'" + row["User ID"].ToString().NumericUserID.Replace("'", "''") + "'," +
                    //"'" + row["User ID"].ToString().Email.Replace("'", "''") + "'" +
                    ")";

                _config.Execute(sql);
                iInserted++;
            }

            MessageBox.Show(
                string.Format("{0} students added", iInserted)
                );
        }

        private void cmdGetFiles_Click(object sender, EventArgs e)
        {
            string filesDir = Path.Combine(folder, _config.BareName);
            DirectoryInfo d = new DirectoryInfo(filesDir);
            if (!d.Exists)
            {
                d.Create();
            }

             var dt = _config.GetDataTable(
                    "select  * from tb_submissions");

            var iCnt = 0;

            foreach (DataRow item in dt.Rows)
            {
                var minSub = new TurnitInSubmission(
                    item["SUB_UserId"].ToString(),
                    item["SUB_PaperId"].ToString(),
                    item["SUB_Title"].ToString()
                    );

                if (minSub.DownloadDocument(filesDir, elpSessionId.Text))
                    iCnt++;
            }
            MessageBox.Show(iCnt + " documents downloaded");
        }

        private void elpSessionId_TextChanged(object sender, EventArgs e)
        {
            var r = Regex.Match(elpSessionId.Text, "session-id=([^&]*)");
            var val = r.Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(val))
            {
                elpSessionId.Text = val;
            }
            cmdGetFiles.Enabled = (elpSessionId.Text.Length == 32);
        }
    }
}
