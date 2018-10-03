using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StudentsFetcher
{
    [AMMFormAttributes(ButtonText = "Google calendar preparation")] 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = @"CalExport.txt";
            var diag = s.ShowDialog();

            if (diag != System.Windows.Forms.DialogResult.OK)
                return;
            
            TextWriter writeFile = new StreamWriter(s.FileName);
            Init(writeFile);
            string[] weeks = new string[] { };

            string[] appointments = txtSchedule.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string appointment in appointments)
            {

                if (appointment.StartsWith("weeks"))
                {
                    string weeklist = appointment.Substring(5);
                    weeklist = weeklist.Replace(" ", "");
                    weeks = weeklist.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    foreach (string week in weeks)
                    {
                        int intWeek = Convert.ToInt32(week);
                        if (intWeek > 4)
                            intWeek++;
                        int iCursor = 0;
                        string[] field = appointment.Split('-');
                        int iDaysAddToSunday = Convert.ToInt32(field[iCursor++]);
                        int iHour = Convert.ToInt32(field[iCursor++]);
                        int iHours = Convert.ToInt32(field[iCursor++]);
                        string sDesc = field[iCursor++];
                        string sLoc = field[iCursor++];
                        DateTime EventDay = dtWeek1.Value.AddDays(7 * (intWeek - 1) + iDaysAddToSunday - 1);
                        writeFile.Write(
                            AddeventAUAS(EventDay, iHour, iHours, sLoc, sDesc, "week " + week)
                            );
                    }
                }
            }
            writeFile.WriteLine("END:VCALENDAR");
            writeFile.Flush();
            writeFile.Close();
            writeFile = null;
        }

        private bool needRemoveHour(DateTime eventDay)
        {
            if (eventDay < dstchange.Value && chkIsSummer.Checked)
                return true;
            else if (eventDay > dstchange.Value && !chkIsSummer.Checked)
                return true;
            return false;
        }

        private void Init(TextWriter sb)
        {
            sb.WriteLine(@"BEGIN:VCALENDAR");
            sb.WriteLine(@"PRODID:-//Google Inc//Google Calendar 70.9054//EN");
            sb.WriteLine(@"VERSION:2.0");
            sb.WriteLine(@"CALSCALE:GREGORIAN");
            sb.WriteLine(@"METHOD:PUBLISH");
            sb.WriteLine(@"X-WR-TIMEZONE:Europe/London");
            sb.WriteLine(@"X-WR-CALDESC:");
        }

        string Addevent(DateTime day, int timeHour, int durationHours, string location, string name, string addtext)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("BEGIN:VEVENT\r\n");
            //DTSTART:20100921T120000Z
            //DTEND:20100921T130000Z
            
            sb.AppendFormat("DTSTART:{0}T{1}0000Z\r\n", day.ToString("yyyyMMdd"), timeHour.ToString("00"));
            sb.AppendFormat("DTEND:{0}T{1}0000Z\r\n", day.ToString("yyyyMMdd"), (timeHour + durationHours).ToString("00"));
            //sb.AppendFormat("DTSTAMP:20100923T080655Z\r\n");
            //sb.AppendLine("UID:35o3qebq626coohim9ctp78508@google.com");
            //sb.AppendFormat("CREATED:20100916T155837Z\r\n");
            sb.AppendFormat("DESCRIPTION:Automated lecture calendar " + addtext + "\r\n");
            //sb.AppendLine("LAST-MODIFIED:20100923T080639Z");
            sb.AppendFormat("LOCATION:" + location + "\r\n");
            sb.AppendFormat("SEQUENCE:0\r\n");
            sb.AppendFormat("STATUS:CONFIRMED\r\n");
            sb.AppendFormat("SUMMARY:" + name + "\r\n");
            sb.AppendFormat("TRANSP:OPAQUE\r\n");
            sb.AppendFormat("END:VEVENT\r\n");
            return sb.ToString();
        }

        string AddeventAUAS(DateTime day, int timeHour, int durationHours, string location, string name, string addtext)
        {
            day = day.AddHours(9);
            day = day.AddMinutes(20);

            bool needRemove = needRemoveHour(day);
            if (needRemove)
                day = day.AddHours(-1);

            // ams time
            day = day.AddHours(-1);

            while (--timeHour > 0)
            {
                day = day.AddMinutes(50);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("BEGIN:VEVENT\r\n");
            sb.Append($"DTSTART:{DropDayTime(day)}\r\n");
            for (int i = 0; i < durationHours; i++)
            {
                day = day.AddMinutes(50);
            }

            sb.Append($"DTEND:{DropDayTime(day)}\r\n");
            //sb.AppendFormat("DTSTAMP:20100923T080655Z\r\n");
            //sb.AppendLine("UID:35o3qebq626coohim9ctp78508@google.com");
            //sb.AppendFormat("CREATED:20100916T155837Z\r\n");
            sb.Append($"DESCRIPTION:Automated lecture calendar " + addtext + "\r\n");
            //sb.AppendLine("LAST-MODIFIED:20100923T080639Z");
            sb.Append($"LOCATION:" + location + "\r\n");
            sb.Append($"SEQUENCE:0\r\n");
            sb.Append($"STATUS:CONFIRMED\r\n");
            sb.Append($"SUMMARY:" + name + "\r\n");
            sb.Append($"TRANSP:OPAQUE\r\n");
            sb.Append($"END:VEVENT\r\n");
            return sb.ToString();
        }

        private string DropDayTime(DateTime day)
        {
            return $"{day:yyyyMMdd}T{day.Hour:00}{day.Minute:00}00Z";
        }
    }
}
