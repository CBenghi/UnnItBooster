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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var s = e.Url.ToString();
            System.Diagnostics.Debug.WriteLine(s);
            // return;

            //_urlSuccessfulLoginPage = "--https://elp.northumbria.ac.uk/webapps/portal/execute/topframe?tab_tab_group_id=_2_1&frameSize=LARGE";
            if (CurrentMode == Modes.SearchingUser)
            {
                CurrentMode = Modes.GettingUserData;
                webBrowser1.Document.Forms[1].InvokeMember("submit");
            }
            else if (s == _urlSuccessfulLoginPage)
            {
                try
                {
                    if (webBrowser1.Url.ToString() != _urlSuccessfulLoginPage)
                    {
                        webBrowser1.Navigate(_urlSuccessfulLoginPage);
                        return;
                    }
                    var cont = webBrowser1.DocumentText;
                    var studid = Regex.Match(cont, "href=\"([^\"]*).*check enr.*", RegexOptions.IgnoreCase).Groups[1].ToString();
                    // students[fd_CurrentId].NumericUserID = studid;
                    var newurl = e.Url.GetLeftPart(UriPartial.Authority);
                    newurl += studid;
                    // e.Url.PathAndQuery = studid;
                    _urlStudentSearchFormSubmitter = newurl;
                    cmdGetFurtherData.Enabled = true;
                }
                catch (Exception)
                {

                }
            }
            else if (s == _urlStudentSearchFormSubmitter)
            {
                // id=userInfoSearchText
                var nxt = GetNext();
                if (nxt != "")
                {
                    // post next search
                    CurrentMode = Modes.SearchingUser;
                    webBrowser1.Document.GetElementById("userInfoSearchText").SetAttribute("value", nxt);
                    webBrowser1.Document.Forms[0].InvokeMember("submit");
                }
                
            }
            else if (CurrentMode == Modes.GettingUserData)
            {
                try
                {
                    var cont = webBrowser1.DocumentText;
                    var studid = Regex.Match(cont, "Student id[^\\d]*(\\d*)", RegexOptions.IgnoreCase).Groups[1].ToString();
                    students[fd_CurrentId].NumericUserId = studid;

                    var email = Regex.Match(cont, "Email Address:([^<]*<[^>]*>){0,2}\\s*([^<]*)", RegexOptions.IgnoreCase).Groups[2].ToString();
                    students[fd_CurrentId].Email = email;
                }
                catch (Exception)
                {

                }
                finally
                {
                    GetNextFurtherData();
                }
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
            webBrowser1.Navigate(txtUrl.Text);
            
        }

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
                    item.DownloadDocument(filesDir, textBox1.Text);
                }
            }
        }


 
        private string fd_PageUrl = "";
        private string fd_fieldname = "";
        private string fd_otherparams = "";
        private int fd_CurrentId = -1;
        // private string 
        private void button3_Click(object sender, EventArgs e)
        {
            fd_CurrentId = -1;
            GetNextFurtherData();
        }


        private string GetNext()
        {
            if (fd_CurrentId < 0)
                return "";
            if (fd_CurrentId < students.Count)
            {
                return students[fd_CurrentId].UserId;
            }
            return "";
        }

        private void GetNextFurtherData()
        {
            fd_CurrentId++;
            if (fd_CurrentId < students.Count)
            {
                CurrentMode = Modes.Undefined;
                webBrowser1.Navigate(_urlStudentSearchFormSubmitter);
                
            }
            else
            {
                MessageBox.Show("Completed");
            }
        }

        private void frmTurnitIn_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(_urlLoginPage);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 32)
                cmdGetFiles.Enabled = false;
            else
                cmdGetFiles.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = "https://elp.northumbria.ac.uk/webapps/unn-managementsuite-bb_bb60/module/check_enrolments.jsp?tab_tab_group_id=_2_1&module_id=_788_1&tabURL=/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_2_1&tabId=_2_1&forwardUrl=index.jsp";

            var PostDataStr =
                "tab_tab_group_id=_2_1&" +
                "module_id=_788_1&" +
                "tabURL=/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_2_1&" +
                "action=SEARCH&" +
                "numResults=25&" +
                "my_user_id=w11025490";
            var PostDataByte = Encoding.UTF8.GetBytes(PostDataStr);
            var AdditionalHeaders = "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine;
            webBrowser1.Navigate(
                fd_PageUrl, 
                "", 
                PostDataByte, 
                AdditionalHeaders
                );      
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var s = "https://elp.northumbria.ac.uk/webapps/unn-managementsuite-bb_bb60/module/check_enrolments.jsp?tab_tab_group_id=_2_1&module_id=_788_1&tabURL=/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_2_1&tabId=_2_1&forwardUrl=index.jsp";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
