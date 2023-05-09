using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using LateBindingTest;
using System.Threading;
using StudentsFetcher;
using System.Net;
using System.DirectoryServices;

namespace StudentMarking
{
    [AMMFormAttributes(ButtonText = "Mass mailing", Order = 3)] 
    public partial class frmMassMail : Form
    {
        

        public frmMassMail()
        {
            InitializeComponent();
            txtEmailBody.Text = StudentsFetcher.Properties.Settings.Default.emailBody;
            txtEmailSubject.Text = StudentsFetcher.Properties.Settings.Default.emailSubject;
            txtEmailCC.Text = StudentsFetcher.Properties.Settings.Default.emailCC;
            
        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "*.xlsx";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                txtExcelFileName.Text = openFileDialog1.FileName;
            }
        }

        private void txtExcelFileName_TextChanged(object sender, EventArgs e)
        {
            ReloadDb();
        }
        
        private OleDbConnection GetConn()
        {
            var f = GetExcelFileInfo();
            if (f == null)
                return null;
            if (!f.Exists)
                return null;
            OleDbConnection con = null;

            string[] options = new[]
            {
                //$@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={f.FullName};Extended Properties=Excel 8.0;",
                $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={f.FullName};Extended Properties=""Excel 12.0 Xml;HDR=YES"";",
                $@"Excel File={f.FullName};"
            };

            for (int i = 0; i < options.Length; i++)
            {
                string item = options[i];
                try
                {
                    con = new OleDbConnection(item); // Extended Properties=Excel 8.0;
                    con.Open();
                    return con;
                }
                catch (Exception)
                {

                }
            }
            return null;            
        }

        private FileInfo GetExcelFileInfo()
        {
            if (string.IsNullOrWhiteSpace(txtExcelFileName.Text))
                return null;
            var f = new FileInfo(txtExcelFileName.Text);
            return f;
        }

        private void ReloadDb()
        {
            using (var con = GetConn())
            {
                if (con == null)
                    return;
                var dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return ;
                }
                var excelSheets = new string[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                con.Close();
                cmbTableNames.DataSource = excelSheets;
            }
        }

        private void ReloadTable()
        {
            if (cmbTableNames.SelectedItem == null)
                return;
            var tbname = cmbTableNames.SelectedItem.ToString();
            using (var con = GetConn())
            {
                var cmd = $"select * from [{tbname}]";
                var da = new OleDbDataAdapter(cmd, con);
                var dt = new DataTable();
                da.Fill(dt);
                con.Close();
                UpdateUI(dt);
            }
        }

        private DataTable currenTable = null;

        private void UpdateUI(DataTable dt)
        {
            currenTable = dt;

            UpdateCombos();

            UpdateList();
            
        }

        private void UpdateCombos()
        {
            var curr = cmbEmailField.Text;
            cmbEmailField.Items.Clear();
            lstEmailSendSelection.Columns.Clear();
            lstEmailSendSelection.Columns.Add("FirstCol");
            foreach (DataColumn clm in currenTable.Columns)
            {
                if (string.IsNullOrEmpty(curr))
                {
                    if (clm.ColumnName.ToLowerInvariant().Contains(@"email"))
                    {
                        curr = clm.ColumnName.ToString();
                    }
                }
                cmbEmailField.Items.Add(clm.ColumnName.ToString());
                lstEmailSendSelection.Columns.Add(clm.ColumnName.ToString());
            }
            try
            {
                if (!string.IsNullOrEmpty(curr))
                    cmbEmailField.SelectedItem = curr;
            }
            catch (Exception)
            {
                
            }
            
        }

        private void UpdateList()
        {
            // a regex to get the email from text
            Regex emaiRegex = new Regex(".+@.+\\..+");
            lstEmailSendSelection.Items.Clear();
            if (currenTable == null)
                return;
            foreach (DataRow row in currenTable.Rows)
            {
                if (!string.IsNullOrEmpty(cmbEmailField.Text))
                {
                    if (!emaiRegex.IsMatch(row[cmbEmailField.Text].ToString()))
                        continue;
                }
                var lvi = new ListViewItem {Text = row[0].ToString(), Tag = row};
                foreach (var subitem in row.ItemArray)
                {
                    lvi.SubItems.Add(subitem.ToString());
                }
                lstEmailSendSelection.Items.Add(lvi);
            }
        }


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

            if (string.IsNullOrEmpty(cmbEmailField.Text))
            {
                MessageBox.Show("email field is invalid.");
                return;
            }
      
            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            var app = new OutlookEmailerLateBinding();
            var replacements = GetReplacementList(txtEmailBody.Text);
            foreach (ListViewItem studentId in lstEmailSendSelection.Items)
            {
                if (!studentId.Checked)
                    continue;

                var row = (DataRow)studentId.Tag;
                try
                {
                    string emailtext = GetMailBody(replacements, row);

                    var emailSubject = replaceFields(txtEmailSubject.Text, replacements, row);

                    var destEmail = row[cmbEmailField.Text].ToString();
                    if (chkEmailDryRun.Checked)
                        app.SendOutlookEmail("claudio.benghi@gmail.com", emailSubject, emailtext, txtEmailCC.Text);
                    else
                        app.SendOutlookEmail(destEmail, emailSubject, emailtext, txtEmailCC.Text);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Done.");
        }

        private string GetMailBody(List<string> replacements, DataRow row)
        {
            var ret = replaceFields(txtEmailBody.Text, replacements, row);
            var ex = GetExcelFileInfo();
            if (ex != null)
            {
                ret = replaceFile(ret, ex.Directory);
            }
            return ret;
        }

        private string replaceFile(string ret, DirectoryInfo directory)
        {
            Regex r = new Regex("FILE<<(.*)>>");
            foreach (Match m in r.Matches(ret))
            {
                var toRep = m.Groups[0].Value;
                var fname = m.Groups[1].Value;

                var fullFName = Path.Combine(directory.FullName, fname);
                string rep = "";
                FileInfo f = new FileInfo(fullFName);
                if (f.Exists)
                {
                    using (var reader = f.OpenText())
                    {
                        rep = reader.ReadToEnd();
                    }
                }
                ret = ret.Replace(toRep, rep);
            }
            return ret;
        }

        private string replaceFields(string emailtext, IEnumerable<string> replacements, DataRow row)
        {
            
            
            foreach (var item in replacements)
            {
                var repvalue = "";
                repvalue = row[item].ToString();
                repvalue = repvalue.Replace("\n", "\r\n");
                var oValue = row[item];
                if (oValue.GetType() == typeof (double))
                {
                    // repvalue = Math.Ceiling((double) oValue).ToString();
                    repvalue = Math.Round((double)oValue).ToString();
                }

                
                emailtext = emailtext.Replace("{" + item + "}", repvalue);
            }
            return emailtext;
        }
       
        private void cmdReload_Click(object sender, EventArgs e)
        {
            ReloadDb();
        }

        private void cmdSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstEmailSendSelection.Items)
            {
                item.Checked = true;
            }
        }

        private string folder
        {
            get
            {
                return new FileInfo(txtExcelFileName.Text).DirectoryName;
            }
        }

        private bool GetImage(string destfolder, string sid)
        {
            WebClient req = new WebClient();
            string url = string.Format(@"http://nuweb2.northumbria.ac.uk/photoids/{0}.jpg", sid);


            string destfilename = sid + ".jpg";

            if (!System.IO.Directory.Exists(destfolder))
                System.IO.Directory.CreateDirectory(destfolder);
            destfilename = System.IO.Path.Combine(destfolder, destfilename);
            try
            {
                if (!System.IO.File.Exists(destfilename))
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

        private void cmdEmailRefreshStudents_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void lstEmailSendSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmailSendSelection.SelectedItems.Count == 0)
                return;
            
            var row = lstEmailSendSelection.SelectedItems[0].Tag as DataRow;
            if (row == null)
                return;
            var replacements = GetReplacementList(txtEmailBody.Text);
            try
            {
                var emailtext = GetMailBody(replacements, row);
                txtEmailPreview.Text = emailtext;
            }
            catch (Exception exception)
            {
                txtEmailPreview.Text = "Error: " + exception.Message;
            }
        }

        private void txtEmailSubject_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            StudentsFetcher.Properties.Settings.Default.emailBody = txtEmailBody.Text;
            StudentsFetcher.Properties.Settings.Default.emailSubject = txtEmailSubject.Text;
            StudentsFetcher.Properties.Settings.Default.emailCC= txtEmailCC.Text;
            StudentsFetcher.Properties.Settings.Default.Save();
        }

        private void txtEmailBody_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #region emailing



        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            ReloadTable();
        }
    }
}
