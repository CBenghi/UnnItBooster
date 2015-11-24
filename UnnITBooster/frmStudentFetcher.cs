using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;

namespace StudentsFetcher
{
    [AMMFormAttributes(ButtonText = "Get student or students transcript")] 
    public partial class frmStudentFetcher : Form
    {
        public frmStudentFetcher()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "Ready";
            cmbReportType.SelectedIndex = 0;
        }

        void Sample()
        {
            //DirectoryEntry adFolderObject = new DirectoryEntry();
            //DirectorySearcher adSearcher = new DirectorySearcher(adFolderObject);

            //adSearcher.SearchScope = SearchScope.Subtree;
            //adSearcher.Filter = "(& (mailnickname=*) (| (&(objectCategory=person)(objectClass=user)(!(homeMDB=*))(!(msExchHomeServerName=*)))(&(objectCategory=person)(objectClass=user)(|(homeMDB=*)(msExchHomeServerName=*))) ))";

            //foreach (SearchResult adObject in adSearcher.FindAll())
            //{
            //    Console.WriteLine("CN={0}, Path={1}", adObject.Properties["CN"][0], adObject.Path);
            //}

            string userName = "daniel.t.thompson@northumbria.ac.uk"; // "sgmk2";

            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();

            if (result == null)
            {
                
            }
            else
            {
                    
            }
        }

        private bool bWorking = false;
        private bool bCancel = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bWorking)
            {
                bWorking = true;
                cmdGoCancel.Text = "Cancel";
                if (cmbReportType.Text == "Averages")
                    txtResults.Text = "StudentName\tStudent Id\tOverall\tLevel 4\tLevel 5\tLevel 6\tLevel 7\tLevel 8\r\n";
                else if (cmbReportType.Text == "Marks")
                    txtResults.Text = "StudentName\tStudent Id\tMark\tStatus\tCredits\tCode\tLevel\tTitle\r\n";
                else if (cmbReportType.Text == "DissertationOrProjectMark")
                    txtResults.Text = "Student Id\tMark\r\n";

                string[] t = txtSource.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int countd = 0; countd < t.Length; countd++)
                {
                    if (bCancel)
                        break;
                    string sid = t[countd];
                    if (sid.Trim() == string.Empty)
                        continue;

                    toolStripStatusLabel1.Text = "Fetching " + sid + " (" + (countd + 1) + " of " + t.Length + ")";
                    Programme p = new Programme(sid);
                    p.FetchMarks();
                    if (p.Marks != null)
                        ReportMarks(p);
                    Application.DoEvents();
                    this.Refresh();
                }
                if (bCancel)
                    toolStripStatusLabel1.Text = "Canceled";
                else
                    toolStripStatusLabel1.Text = "Done";

                cmdGoCancel.Text = "Go, fetch!";
                bWorking = false;
                bCancel = false;
            }
            else
            {
                bCancel = true;
            }
            // FetchAndReport("07022609/1");
        }

        private void ReportMarks(Programme p)
        {
            StringBuilder sb = new StringBuilder();
            
            if (cmbReportType.Text == "Averages")
            {
                sb.Append(p.StudentName + "\t");
                sb.Append(p.CodeDetailed + "\t");
                sb.Append(Marking.getstat(p.Marks, -1) + "\t");
                for (int Level = 4; Level < 9; Level++)
                {
                    sb.Append(Marking.getstat(p.Marks, Level) + "\t");
                }
                sb.Append("\r\n");
                
            }
            else if (cmbReportType.Text == "Marks")
            {
                try
                {
                    foreach (Marking mk in p.Marks)
                    {
                        sb.Append(
                            p.StudentName + "\t" +
                            p.CodeDetailed + "\t" +
                            mk.Mark + "\t" +
                            mk.MarkStatus + "\t" +
                            mk.Credits + "\t" +
                            mk.Code + "\t" +
                            mk.Level + "\t" +
                            mk.Title + "\t" +
                            "\r\n"
                            );
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
            else if (cmbReportType.Text == "DissertationOrProjectMark")
            {
                IEnumerable<int> query = from s in p.Marks
                                            where s.Credits == 60
                                            select s.Mark;
                sb.Append(
                    p.CodeDetailed + "\t" +
                    query.FirstOrDefault().ToString() + "\r\n");
            }
            txtResults.Text += sb.ToString();
            
            // Console.WriteLine(sb.ToString());
        }
                
        



        private void button1_Click(object sender, EventArgs e)
        {
            Sample();

            // textBox2.SelectAll();
            Clipboard.SetText(txtResults.Text);
            toolStripStatusLabel1.Text = "Copied to clipboard";
        }
    }
}
