using System;
using System.Windows.Forms;

namespace StudentsFetcher
{
    public partial class frmLists : Form
    {
        public frmLists()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportServer.ReportServerCall rsc = new ReportServer.ReportServerCall("/Student data/Student Route Classlist with Photos");
            rsc.AddParameter("School", "50");
            //rsc.AddParameter("Course", "14FBET-N");
            rsc.AddParameter("Route", "CPR6");
            rsc.AddParameter("Route", "PRM6");
            
            //for (int i = 0; i < 33; i++)
            //{
            //    rsc.AddParameter("Block", i.ToString());
            //}
            rsc.AddParameter("Route", "1");
            rsc.AddParameter("Route", "11");
            rsc.AddParameter("Route", "12");
            rsc.AddParameter("Route", "2");
            rsc.AddParameter("Route", "21");
            rsc.AddParameter("Route", "22");
            rsc.AddParameter("Route", "3");
            rsc.AddParameter("Route", "31");
            rsc.AddParameter("Route", "32");
            rsc.AddParameter("Route", "4");
            rsc.AddParameter("Route", "41");
            rsc.AddParameter("Route", "42");
            rsc.AddParameter("Route", "5");
            rsc.AddParameter("Route", "51");
            rsc.AddParameter("Route", "52");
            rsc.AddParameter("Route", "6");
            rsc.AddParameter("Route", "61");
            rsc.AddParameter("Route", "62");
            rsc.AddParameter("Route", "7");
            rsc.AddParameter("Route", "71");
            rsc.AddParameter("Route", "72");
            rsc.AddParameter("Route", "81");
            rsc.AddParameter("Route", "82");
            rsc.AddParameter("Route", "91");
            rsc.AddParameter("Route", "92");
            
            // rsc.AddParameter("Status", "E");


            string url = rsc.GetEncodedUrl();
            string s = ReportServer.getSqlReport(url);
        }
    }
}
