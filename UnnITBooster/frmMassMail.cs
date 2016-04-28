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
            Reload();
        }



        private void Reload()
        {
            var f = new FileInfo(txtExcelFileName.Text);
            if (!f.Exists)
                return;
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + f.FullName + ";Extended Properties=Excel 8.0;"); // Extended Properties=Excel 8.0;
            con.Open();
            var da = new OleDbDataAdapter("select * from [Sheet1$]", con);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();

            // var columns = dt.Columns;

            UpdateUI(dt);
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
            Regex emaiRegex = new Regex(".+@.+\\..+");
            lstEmailSendSelection.Items.Clear();
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
                    var emailtext = Emailtext(replacements, row);
                    var destEmail = row[cmbEmailField.Text].ToString();
                    if (!chkEmailDryRun.Checked)
                        app.SendOutlookEmail(destEmail, txtEmailSubject.Text, emailtext, txtEmailCC.Text);
                    else
                        Debug.WriteLine(emailtext);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Done.");
        }


        private string Emailtext(IEnumerable<string> replacements, DataRow row)
        {
            var emailtext = txtEmailBody.Text;
            
            foreach (var item in replacements)
            {
                var repvalue = "";
                repvalue = row[item].ToString();
                var oValue = row[item];
                if (oValue.GetType() == typeof (double))
                {
                    repvalue = Math.Ceiling((double) oValue).ToString();
                }

                
                emailtext = emailtext.Replace("{" + item + "}", repvalue);
            }
            return emailtext;
        }

       

        private void cmdReload_Click(object sender, EventArgs e)
        {
            Reload();
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
                var emailtext = Emailtext(replacements, row);
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
    }
}
