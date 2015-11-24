using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LateBindingTest;
using System.Globalization;
using System.Threading;

namespace StudentMarking
{
    public partial class frmReporting : Form
    {
        private clsConfig clsConfig;

        public frmReporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string mainFolder = clsConfig.GetFolderName() + @"Reports\";

            string sql = "select * from Students";
            var studs = clsConfig.GetDataTable(sql);
            foreach (DataRow dr in studs.Rows)
            {
                if (dr["MarkFinal"] != DBNull.Value)
                {
                    string studId = dr["UserID"].ToString().Trim();
                    string thisdir = Path.Combine(mainFolder, studId);
                    if (!Directory.Exists(thisdir))
                    {
                        Directory.CreateDirectory(thisdir);
                    }
                    if (Directory.Exists(thisdir))
                    {
                        int numberId = Convert.ToInt32(dr["Stud_ID"]);
                        string JustFileName = string.Format("{0} {1} {2}.txt",
                            dr["LastName"].ToString(),
                            dr["FirstName"].ToString(),
                            dr["UserID"].ToString()
                            );
                        // create a writer and open the file
                        string fullname = Path.Combine(thisdir, JustFileName);
                        TextWriter tw = new StreamWriter(fullname);
                        string srep = clsConfig.GetStudentReport(numberId, false);

                        txtReport.Text += srep;
                        
                        tw.Write(srep);

                        // close the stream
                        tw.Close();
                    }
                    else
                    {
                        sb.AppendFormat("not found: {0}", studId);
                    }
                }
            }
        }

        private string emailBody = @"
Dear {FirstName},

The marking and moderation process for BE1013 has been completed a few days ago.
Since I'm experiencing technical problems in the upload of the marks to the eLP I'm sending out this email to inform you of the outcomes without further delays.
Please find your feedback after my signature; I'll be uploading the information to the eLP as soon as I can, apologies for the delay.

Best regards,
Claudio

---
{Feedback}
";

        private void SendMail_Click(object sender, EventArgs e)
        {

            var v = MessageBox.Show("Ready to send emails?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (v != System.Windows.Forms.DialogResult.Yes)
                return;

            string sql = "select * from Qemails";
            var studs = clsConfig.GetDataTable(sql);

            
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            OutlookEmailerLateBinding app = new OutlookEmailerLateBinding();

            foreach (DataRow row in studs.Rows)
            {
                string DestEmail = row["email"].ToString();
                string emailtext = emailBody;

                //string sname = row["name"].ToString().ToLower();
                //string wholename = textInfo.ToTitleCase(sname);
                //string[] wholenames = wholename.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string firstnames = row["FirstName"].ToString().ToLower();
                string[] firstnamesA = firstnames.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstname = firstnamesA[0];

                int thisId = (int)row["Stud_Id"];

                emailtext = emailtext.Replace("{FirstName}", textInfo.ToTitleCase(firstname));
                emailtext = emailtext.Replace("{Feedback}", clsConfig.GetStudentReport(thisId, false));
                txtReport.Text += emailtext;
                txtReport.Text += "\r\n====================\r\n";
                app.SendOutlookEmail(DestEmail, "BE1013 mark", emailtext);
            }
        }
    }
}
