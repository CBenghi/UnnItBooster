using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LateBindingTest;

namespace StudentsFetcher.StudentMarking
{
    public partial class FrmReporting : Form
    {
        private ClsConfig clsConfig;

        public FrmReporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var mainFolder = clsConfig.GetFolderName() + @"Reports\";

            const string sql = "select * from Students";
            var studs = clsConfig.GetDataTable(sql);
            foreach (DataRow dr in studs.Rows)
            {
                if (dr["MarkFinal"] != DBNull.Value)
                {
                    var studId = dr["UserID"].ToString().Trim();
                    var thisdir = Path.Combine(mainFolder, studId);
                    if (!Directory.Exists(thisdir))
                    {
                        Directory.CreateDirectory(thisdir);
                    }
                    if (Directory.Exists(thisdir))
                    {
                        var numberId = Convert.ToInt32(dr["Stud_ID"]);
                        var justFileName = string.Format("{0} {1} {2}.txt",
                            dr["LastName"],
                            dr["FirstName"],
                            dr["UserID"]
                            );
                        // create a writer and open the file
                        var fullname = Path.Combine(thisdir, justFileName);
                        TextWriter tw = new StreamWriter(fullname);
                        var srep = clsConfig.GetStudentReport(numberId, false);

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

        private readonly string emailBody = @"
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
            if (v != DialogResult.Yes)
                return;

            var sql = "select * from Qemails";
            var studs = clsConfig.GetDataTable(sql);

            
            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            var app = new OutlookEmailerLateBinding();

            foreach (DataRow row in studs.Rows)
            {
                var destEmail = row["email"].ToString();
                var emailtext = emailBody;

                //string sname = row["name"].ToString().ToLower();
                //string wholename = textInfo.ToTitleCase(sname);
                //string[] wholenames = wholename.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var firstnames = row["FirstName"].ToString().ToLower();
                var firstnamesA = firstnames.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstname = firstnamesA[0];

                var thisId = (int)row["Stud_Id"];

                emailtext = emailtext.Replace("{FirstName}", textInfo.ToTitleCase(firstname));
                emailtext = emailtext.Replace("{Feedback}", clsConfig.GetStudentReport(thisId, false));
                txtReport.Text += emailtext;
                txtReport.Text += "\r\n====================\r\n";
                app.SendOutlookEmail(destEmail, "BE1013 mark", emailtext);
            }
        }
    }
}
