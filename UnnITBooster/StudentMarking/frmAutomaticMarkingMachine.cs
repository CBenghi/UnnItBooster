using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LateBindingTest;
using StudentsFetcher;
using StudentsFetcher.Properties;
using StudentsFetcher.StudentMarking;
using ZedGraph;

namespace StudentMarking
{
    [AMMFormAttributes(ButtonText = "Automatic marking machine", Order = 1)] 
    public partial class frmAutomaticMarkingMachine : Form
    {
        private clsConfig Config;

        public frmAutomaticMarkingMachine()
        {
            InitializeComponent();
            LoadSettings();
        }

        

        #region marking
        


        void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateStudentUI();
            }
        }

        private void UpdateStudentUI()
        {
            UpdateStudentReport();
            UpdateStudentMarksUI();
        }

        private void UpdateStudentMarksUI()
        {
            foreach (var item in flComponents.Controls)
            {
                ucComponentMark creset = item as ucComponentMark;
                creset.Unset();
            }

            if (GetStudentNumber() != -1)
            {
                string sql = "select * from TB_Marks where MARK_ptr_Submission = " + GetStudentNumber();
                DataTable dt = Config.GetDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    int cmp = Convert.ToInt32(item["MARK_ptr_Component"]);
                    int val = Convert.ToInt32(item["MARK_Value"]);

                    // MARK_ptr_Component
                    // MARK_Value

                    if (cmp == -1)
                        cmp = 0;
                    
                    ucComponentMark m = flComponents.Controls[cmp] as ucComponentMark;
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
                txtStudentreport.Text = Config.GetStudentReport(GetStudentNumber(), chkSendModerationNotice.Checked);
                UpdateDocumentsList();

                // show student picure.
                
                DataTable dt = Config.GetDataTable("SELECT SUB_NumericUserId from tb_submissions where SUB_Id = " + GetStudentNumber());
                if (dt.Rows.Count == 1)
                {
                    string numeriCuserID = dt.Rows[0][0].ToString();
                    ShowUserImage(numeriCuserID);
                }
                
            }
            else
            {
                string sql = "select  *, (SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks from tb_submissions";
                if (txtStudentId.Text != "")
                {
                    sql += " where " +
                        "SUB_LastName like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                        "SUB_FirstName like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                        "SUB_UserID like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                        "SUB_NumericUserID like '%" + txtStudentId.Text.Replace("'", "''") + "%' OR " +
                        "SUB_email like '%" + txtStudentId.Text.Replace("'", "''") + "%'";
                }

                var mc =  Config.GetMarkCalculator();
                

                StringBuilder sb = new StringBuilder();
                DataTable dt = Config.GetDataTable(sql);
                foreach (DataRow item in dt.Rows)
                {
                    int totmark = mc.GetFinalMark(item["SUB_NumericUserId"].ToString(), Config);

                    sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{5}\t{4}\t{6}\r\n", 
                        item["SUB_id"],
                        item["SUB_LastName"],
                        item["SUB_FirstName"],
                        item["SUB_UserID"],
                        item["MARKS"],
                        item["SUB_NumericUserID"],
                        totmark
                        );
                }

                sb.AppendFormat("\r\n\r\n");


                foreach (DataRow item in dt.Rows)
                {
                    int id = Convert.ToInt32(item["SUB_id"]);
                    sb.Append(Config.GetStudentReport(id, chkSendModerationNotice.Checked));
                }
                txtStudentreport.Text = sb.ToString();

            }
        }

        private void UpdateDocumentsList()
        {
            cmbDocuments.Items.Clear();
            DataRow stud = Config.GetStudentRow(GetStudentNumber());
            if (stud == null)
                return;
            string sId = stud["sub_userid"].ToString();
            DirectoryInfo d = new DirectoryInfo(Config.GetFolderName());
            List<string> fls = new List<string>();
            var dirs = d.GetDirectories();
            foreach (var item in dirs)
            {
                var files = item.GetFiles(sId + "*.*");
                foreach (var file in files)
                {
                    string subfile = Path.Combine(item.Name, file.Name);
                    cmbDocuments.Items.Add(subfile);
                }
            }
            if (cmbDocuments.Items.Count > 0)
            {
                cmbDocuments.SelectedIndex = 0;
            }
        }

        private int GetStudentNumber()
        {
            try
            {
                int i = Convert.ToInt32(txtStudentId.Text);
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
                Match m = Regex.Match(txtSearch.Text, "component (\\d+) (\\d+) (.*)");
                Match m2 = Regex.Match(txtSearch.Text, "marks (\\d+)");
                Match m3 = Regex.Match(txtSearch.Text, "ids");
                Match m4 = Regex.Match(txtSearch.Text, @"WhoGotComment (\d+)");
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
                else if (txtSearch.Text == "missing")
                {
                    FindMissing();
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

        private void FindMissing()
        {
            var allIds = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            txtStudentreport.Text += "Missing report:\r\n";
            txtStudentreport.Text += "==============:\r\n";
            string sql = "SELECT * FROM TB_Submissions";
            var dt = Config.GetDataTable(sql);
            foreach (DataRow r in dt.Rows)
            {
                string lookForID = r["sub_numericUserId"].ToString();

                Regex rEx = new Regex("" + lookForID +@"/(\d)");

                bool bFound = false;
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
                    txtStudentreport.Text += lookForID + " (#" + r["sub_ID"] + ") missing\r\n";
                }
            }
        }

        private void GetCommentUse(Match m4)
        {
            txtLibReport.Text = "Submissions:\r\n";
            string sql = "SELECT SCOM_ptr_Submission FROM TB_SubComments where SCOM_ptr_comment = " + m4.Groups[1].Value;
            var dt = Config.GetDataTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                txtLibReport.Text += item[0] + "\r\n";
            }
        }

        private void GetIds()
        {
            txtLibReport.Text = "";
            string sql = "SELECT sub_userid, sub_numericUserId FROM TB_Submissions";
            var dt = Config.GetDataTable(sql);
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
            string[] ids = txtLibReport.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var markgen = Config.GetMarkCalculator();

            foreach (var idWithSlash in ids)
            {
                string result = "";
                string[] idParts = idWithSlash.Split(new[] { "/" }, StringSplitOptions.None);
                if (idParts.Length == 2)
                {
                    string id = idParts[0];
                    result = markgen.GetFinalMark(id, Config).ToString();
                }
                txtStudentreport.Text += string.Format("{0}\t{1}\r\n", idWithSlash, result);
            }
        }

        private void AddComponent(Match m)
        {
            string sql;
            string compOrder = m.Groups[1].ToString();
            string compPercent = m.Groups[2].ToString();
            string compTitle = m.Groups[3].ToString();

            sql = "delete from TB_Components where CPNT_Order = " + compOrder;
            Config.Execute(sql);

            sql = "insert into TB_Components (CPNT_Order, CPNT_Percent, CPNT_Name) values (" +
                compOrder + ", " +
                compPercent + ", " +
                "'" + compTitle.Trim().Replace("'", "''") + "' " +
                ")";
            Config.Execute(sql);
        }

        private void SearchCommentInLibrary()
        {
            bool bExtended = false;
            txtLibReport.Text = "Problem";
            string[] sarr = txtSearch.Text.Split(';');
            if (sarr.Count() == 0)
                return;

            string sql = "select * from TB_Comments where ";
            if (sarr.Count() == 1)
            {
                sql += "COMM_Text like '%" + sarr[0] + "%'";
                if (sarr[0].EndsWith("+"))
                {
                    string val = sarr[0].Substring(0, sarr[0].Length - 1);
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

            StringBuilder sb = new StringBuilder();
            DataTable dt = Config.GetDataTable(sql);
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
            var con = Config.GetConn();

            string sql;
            int reference = -1;
            bool isok = Int32.TryParse(txtTextOrPointer.Text, out reference);
            if (!isok)
            {
                reference = -1;
                SQLiteConnection c = Config.GetConn();
                c.Open();
                if (txtTextOrPointer.Text == "")
                {
                    reference = Config.ExecuteScalar("SELECT comm_id FROM TB_Comments where comm_text = ''", c);
                }
                if (reference == -1)
                {
                    sql = "insert into TB_Comments ([COMM_Section],[COMM_Area],[COMM_Text]) values " +
                        "('" + txtSection.Text.Replace("'", "''") + "','" + txtArea.Text.Replace("'", "''") + "','" + txtTextOrPointer.Text.Replace("'", "''") + "')";
                    Config.Execute(sql, c);

                    reference = Config.ExecuteScalar("SELECT last_insert_rowid()", c);
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
            Config.Execute(sql);

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
            Config = new clsConfig();
            Config.DbName = txtExcelFileName.Text;
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            // combo 
        
            cmbComponentComment.Items.Clear();
            comboId cid = new comboId { text = "<general>", value = -1, percent = 0};
            cmbComponentComment.Items.Add(cid);
            

            flComponents.Controls.Clear();

            ucComponentMark cmp = new ucComponentMark();
            cmp.ComponentName = "<General>";
            cmp.Id = -1;
            cmp.onUserChange += cmp_onUserChange;
            cmp.TabStop = false;
            flComponents.Controls.Add(cmp);
            cmp.TabStop = false;

            // 
            try
            {
                DataTable dt = Config.GetDataTable("select * from TB_Components order by CPNT_Order");
                foreach (DataRow item in dt.Rows)
                {
                    int order = Convert.ToInt32(item["CPNT_Order"]);
                    int ipercent = Convert.ToInt32(item["CPNT_Percent"]);
                    comboId c = new comboId
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
                string e = ex.Message;
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
            int iComponent = -1;
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
            string sql = "";
            sql = "delete from TB_Marks " +
                  "where MARK_ptr_Submission = " + GetStudentNumber();
            Config.Execute(sql);

            foreach (var comp in flComponents.Controls)
            {
                ucComponentMark c = comp as ucComponentMark;
                if (c.IsSet)
                {
                    int markvalue = c.MarkValue;
                    int iComponent = c.Id;


                    sql = "insert into TB_Marks (MARK_ptr_Submission, MARK_ptr_Component, MARK_Value, MARK_Date) " +
                          "values (" +
                          GetStudentNumber() + ", " +
                          iComponent + ", " +
                          markvalue + "," +
                          "datetime('now')" +
                          ")";
                    Config.Execute(sql);
                }  
            }
            cmdSaveMarks.BackColor = Color.Transparent;


            UpdateStudentReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbDocuments.Text != "")
            {
                string fullname = Path.Combine(
                    Config.GetFolderName(),
                    cmbDocuments.Text);
                Process.Start(fullname);
            }
        }
    
        #endregion


        List<string> GetReplacementList(string emailbody)
        {
            List<string> ret = new List<string>();

            MatchCollection mts = Regex.Matches(emailbody, "{([^}]*)}");
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
            
            var mcalc = Config.GetMarkCalculator();
    
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            OutlookEmailerLateBinding app = new OutlookEmailerLateBinding();
            List<string> replacements = GetReplacementList(txtEmailBody.Text);
            foreach (ListViewItem studentId in lstEmailSendSelection.Items)
            {
                if (!studentId.Checked)
                    continue;

                int iStudentId = (int)studentId.Tag;
                DataRow row;
                var emailtext = Emailtext(replacements, iStudentId, mcalc, out row);
                string DestEmail = row["SUB_email"].ToString();

                if (!chkEmailDryRun.Checked)
                    app.SendOutlookEmail(DestEmail, txtEmailSubject.Text, emailtext);
                else
                    Debug.WriteLine(emailtext);
            }

            MessageBox.Show("Done");
        }

        private string Emailtext(int iStudentId)
        {
            var mcalc = Config.GetMarkCalculator();
            List<string> replacements = GetReplacementList(txtEmailBody.Text);
            DataRow row;
            var emailtext = Emailtext(replacements, iStudentId, mcalc, out row);
            return emailtext;
        }

        private string Emailtext(IEnumerable<string> replacements, int iStudentId, MarksCalculator mcalc, out DataRow row)
        {
            string emailtext = txtEmailBody.Text;
            row = Config.GetStudentRow(iStudentId);
            foreach (string item in replacements)
            {
                var repvalue = "";
                switch (item)
                {
                    case "MarkReport":
                        repvalue = Config.GetStudentReport(iStudentId, chkSendModerationNotice.Checked);
                        break;
                    case "FinalMark":
                        repvalue = mcalc.GetFinalMark(row["SUB_NumericUserId"].ToString(), Config).ToString();
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
            var mcalc = Config.GetMarkCalculator();
            lstEmailSendSelection.Items.Clear();
            try
            {
                DataTable dt = Config.GetDataTable(
                    "select  *, " +
                    "(SELECT count(*) FROM tb_marks WHERE mark_ptr_submission=sub_id) as marks, " +
                    "(SELECT count(*) FROM TB_SubComments WHERE scom_ptr_submission=sub_id) as NumComments, " +
                    "(SELECT max(MARK_Date) FROM tb_marks WHERE mark_ptr_submission=sub_id) as markDate " +
                    "from tb_submissions");

                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = string.Format("{0} {1}", item["SUB_FirstName"], item["SUB_LastName"]);
                    lvi.Tag = Convert.ToInt32(item["SUB_Id"]);
                    lvi.SubItems.Add(item["marks"].ToString()); 
                    string numUID = item["SUB_NumericUserId"].ToString();
                    lvi.SubItems.Add(mcalc.GetFinalMark(numUID, Config).ToString());
                    lvi.SubItems.Add(lvi.Tag + " " + item["markDate"]);
                    lvi.SubItems.Add(item["NumComments"].ToString());

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
            if (!chkImportComponents.Checked && !chkCommentLib.Checked)
                return;

            string sql = "";
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

            sql += string.Format("DETACH {0}; ", "OTHERDB");
            Config.Execute(sql);

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
            int[] Groups = new int[10];

            var mcalc = Config.GetMarkCalculator();
            string sql = "SELECT sub_userid, sub_numericUserId FROM TB_Submissions";
            var dt = Config.GetDataTable(sql);
            foreach (DataRow rw in dt.Rows)
            {
                var mk = mcalc.GetFinalMark(rw[1].ToString(), Config);
                int m = mk / 10;
                Groups[m]++;
            }

            PointPairList list = new PointPairList();
            for (int i = 0; i < 10; i++)
            {
                double x = i * 10 + 5;
                list.Add(x, Groups[i]);
            }

            var gPane = zedGraphControl1.GraphPane;
            gPane.CurveList.Clear();
            BarItem myCurve = gPane.AddBar("Marks", list, Color.Blue);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoveStudent(1);
        }

        private void MoveStudent(int Delta)
        {
            int iSN = GetStudentNumber();
            if (iSN == -1)
            {
                iSN = 0;
            }
            iSN += Delta;
            txtStudentId.Text = iSN.ToString();
            UpdateStudentUI();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveStudent(-1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
            string filesDir = Path.Combine(folder, "Pics");
            DataTable dt = Config.GetDataTable("SELECT * from tb_submissions");
            int iOk = 0;
            int iErr = 0;
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
                int iShort = (int)lstEmailSendSelection.SelectedItems[0].Tag;
                DataTable dt = Config.GetDataTable("SELECT SUB_NumericUserId from tb_submissions where SUB_Id = " + iShort);
                if (dt.Rows.Count == 1)
                {
                    string numeriCuserID = dt.Rows[0][0].ToString();
                    ShowUserImage(numeriCuserID);
                }
                // preview email
                txtEmailPreview.Text = Emailtext(iShort);
            }
        }

        private void ShowUserImage(string numeriCuserID)
        {
            string NumId = numeriCuserID + ".jpg";
            string filesDir = Path.Combine(folder, "Pics");
            string fullName = Path.Combine(filesDir, NumId);
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

        #region emailing



        #endregion
    }
}
