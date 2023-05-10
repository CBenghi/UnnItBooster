using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.OleDb;
using StudentsFetcher.Turnitin;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using StudentsFetcher.Webdata;

namespace StudentsFetcher
{
    [AMMFormAttributes(ButtonText = "Prepare AMM Database", Order = 0)] 
    public partial class frmTurnitIn : Form
    {
        public frmTurnitIn()
        {
            InitializeComponent();
        }

        CookieAwareWebClient wc = new CookieAwareWebClient();


        List<TurnitInSubmission> students = new List<TurnitInSubmission>();

        private string fullname
        {
            get
            {
                return txtExcelFileName.Text;
            }
        }

        private string folder
        {
            get
            {
                return new FileInfo(fullname).DirectoryName;
            }
        }

        private string filename
        {
            get
            {
                return new FileInfo(fullname).Name;
            }
        }

        private string ReportName
        {
            get
            {
                var ReportName = Regex.Match(filename, "Inbox_Report_(.*).xls").Groups[1].ToString();
                if (ReportName == "")
                    ReportName = "Files";
                return ReportName;
            }

        }

        private void cmdFetch_Click(object sender, EventArgs e)
        {
            students.Clear();

            if (!File.Exists(fullname))
            {
                MessageBox.Show("Excel File not found");
                return;
            }

            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullname + ";Extended Properties=Excel 8.0;"); // Extended Properties=Excel 8.0;
            con.Open();
            var da = new OleDbDataAdapter("select * from [Sheet1$]", con);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();


            foreach (DataRow row in dt.Rows)
            {
                var stud = new TurnitInSubmission();
                foreach (DataColumn col in dt.Columns)
                {
                    var val = row[col.ColumnName].ToString();
                    if (val != string.Empty)
                    {
                        stud.SetProp(val, col.ColumnName);
                    }
                }
                students.Add(stud);
            }

            MessageBox.Show(
                string.Format("{0} submissions found", students.Count)
                );

            if (students.Count > 0)
                cmdMakeDatabase.Enabled = true;

        }

        private void PopulateDatabase(string fullname)
        {
            var filename = Path.ChangeExtension(fullname, "sqlite");
            var c = new SQLiteConnection("Data source=" + filename + ";");
            SQLiteCommand cmd;
            string sql;
            c.Open();
            foreach (var item in students)
            {
                sql = "insert into TB_Submissions (SUB_LastName, SUB_FirstName , SUB_UserID, SUB_TurnitinUserID, SUB_Title, SUB_PaperID, SUB_DateUploaded, SUB_Grade, SUB_Overlap, SUB_InternetOverlap, SUB_PublicationsOverlap, SUB_StudentPapersOverlap, SUB_NumericUserID, SUB_email) " +
                    "values ('" + item.LastName.Replace("'", "''") + "','" + item.FirstName.Replace("'", "''") + "','" + item.UserId.Replace("'", "''") + "','" + item.TurnitinUserId.Replace("'", "''") + "','" + item.Title.Replace("'", "''") + "','" + item.PaperId.Replace("'", "''") + "','" + item.DateUploaded.Replace("'", "''") + "','" + item.Grade.Replace("'", "''") + "','" + item.Overlap.Replace("'", "''") + "','" + item.InternetOverlap.Replace("'", "''") + "','" + item.PublicationsOverlap.Replace("'", "''") + "'," + 
                    "'" + item.StudentPapersOverlap.Replace("'", "''") + "',"  +
                    "'" + item.NumericUserId.Replace("'", "''") + "'," +
                    "'" + item.Email.Replace("'", "''") + "'" +
                    ")";
                cmd = new SQLiteCommand(sql, c);
                cmd.ExecuteNonQuery();
            }
            c.Close();
        }

        private void CreateDatabase(string fullname)
        {
            var filename = Path.ChangeExtension(fullname, "sqlite");
            var c = new SQLiteConnection("Data source=" + filename + ";");
            SQLiteCommand cmd;
            string sql;
            c.Open();
            try
            {
                cmd = new SQLiteCommand(c);
                
                sql = "CREATE TABLE IF NOT EXISTS TB_Submissions (" +
                    "SUB_ID INTEGER PRIMARY KEY, " +
                    "SUB_LastName text, " +
                    "SUB_FirstName text, " +
                    "SUB_UserID text, " +
                    "SUB_TurnitinUserID text, " +
                    "SUB_NumericUserID text, " +
                    "SUB_email text, " +
                    "SUB_Title text, " +
                    "SUB_PaperID text, " +
                    "SUB_DateUploaded text, " +
                    "SUB_Grade text, " +
                    "SUB_Overlap text, " +
                    "SUB_InternetOverlap text, " +
                    "SUB_PublicationsOverlap text, " +
                    "SUB_StudentPapersOverlap text" +
                    ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS TB_Marks (" +
                    "MARK_ID INTEGER PRIMARY KEY, " +
                    "MARK_ptr_Submission INT, " +
                    "MARK_ptr_Component INT, " +
                    "MARK_Value INT, " +
                    "MARK_Date DATETIME" +
                    ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS TB_Submissions (" +
                    "SUB_ID INTEGER PRIMARY KEY, " +
                    "SUB_LastName text, " +
                    "SUB_FirstName text, " +
                    "SUB_UserID text, " +
                    "SUB_TurnitinUserID text, " +
                    "SUB_Title text, " +
                    "SUB_PaperID text, " +
                    "SUB_DateUploaded text, " +
                    "SUB_Grade text, " +
                    "SUB_Overlap text, " +
                    "SUB_InternetOverlap text, " +
                    "SUB_PublicationsOverlap text, " +
                    "SUB_StudentPapersOverlap text" +
                    ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS TB_Comments (" +
                     "COMM_ID INTEGER PRIMARY KEY, " +
                     "COMM_Section text, " +
                     "COMM_Area text, " +
                     "COMM_Text text" +
                     ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS TB_SubComments (" +
                     "SCOM_ID INTEGER PRIMARY KEY, " +
                     "SCOM_ptr_Submission INTEGER, " +
                     "SCOM_ptr_Comment INTEGER, " +
                     "SCOM_ptr_Component INTEGER, " +
                     "SCOM_AddNote text" +
                     ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS TB_Components (" +
                     "CPNT_ID INTEGER PRIMARY KEY, " +
                     "CPNT_Order INTEGER, " +
                     "CPNT_Name TEXT, " +
                     "CPNT_Percent INTeger, " +
                     "CPNT_Comment TEXT" +
                     ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "CREATE VIEW if not exists QComments AS " +
                    "SELECT * FROM (TB_SubComments INNER JOIN TB_Comments " +
                    "on SCOM_ptr_Comment = COMM_ID) left join TB_Components " +
                    "on SCOM_ptr_Component = CPNT_ID";
                Clipboard.SetText(sql);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

            }
            catch { }

           
            c.Close();
        }

        public static string getWebData(string url)
        {
            var req = new WebClient();
            req.Credentials = CredentialCache.DefaultCredentials;
            var retval = "";
            try
            {
                retval = Encoding.UTF8.GetString(req.DownloadData(url));
            }
            catch (System.Net.WebException webexc)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching: " + url);
                var s = webexc.Response.GetResponseStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching: " + url);
                Clipboard.SetText(url);
            }
            return retval;
        }

        private void txtTunrintinUrl_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Regex.Match(txtTunrintinUrl.Text, "session-id=([^&]*)").Groups[1].ToString();
            
        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                txtExcelFileName.Text = openFileDialog1.FileName;
            }
        }
        
        string _urlLoginPage = "https://elp.northumbria.ac.uk/webapps/login/?action=relogin";
        string _urlSuccessfulLoginPage = "https://elp.northumbria.ac.uk/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_2_1";
        string _urlStudentSearchFormSubmitter = "";

        internal enum Modes
        {
            Undefined,
            SearchingUser,
            GettingUserData,
        }

        internal Modes CurrentMode = Modes.Undefined;


        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine(e.Url);
        }

        private void cmdUseThisForm_Click(object sender, EventArgs e)
        {
            
        }

        private void makeDatabase_Click(object sender, EventArgs e)
        {
            CreateDatabase(fullname);
            PopulateDatabase(fullname);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var filesDir = Path.Combine(folder, ReportName);
            foreach (var item in students)
            {
                var d = new DirectoryInfo(filesDir);
                if (!d.Exists)
                {
                    d.Create();
                }
                var ret = d.GetFiles(item.UserId + "*.*");
                if (ret.Length == 0)
                {
                    txtReport.Text += "Attempting " + item.FirstName + " " + item.LastName + "... ";
                    txtReport.Refresh();
                    var res = item.DownloadDocument(filesDir, textBox1.Text);
                    txtReport.Text += (res ? "Ok" : "=== ERROR ===") + "\r\n";
                    txtReport.Refresh();
                }
            }
            txtReport.Text += "Completed.";
        }


 
        private string fd_PageUrl = "";
        private string fd_fieldname = "";
        private string fd_otherparams = "";
        // private string 
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 32)
                cmdGetFiles.Enabled = false;
            else
                cmdGetFiles.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var s = "https://elp.northumbria.ac.uk/webapps/unn-managementsuite-bb_bb60/module/check_enrolments.jsp?tab_tab_group_id=_2_1&module_id=_788_1&tabURL=/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_2_1&tabId=_2_1&forwardUrl=index.jsp";
        }
        
    }
}
