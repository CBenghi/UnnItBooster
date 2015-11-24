using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using StudentsFetcher.TimeTabling;

namespace StudentsFetcher
{
    [AMMFormAttributes(ButtonText = "Timetable")] 
    public partial class frmTimeTable : Form
    {
        public frmTimeTable()
        {
            InitializeComponent();

            DataLoad();
        }

        SerializableDictionary<string, Cal> dic;

        private void DataLoad()
        {
            string filename = "LastData.xml";
            if (File.Exists(filename))
            {
                XmlSerializer ser = new XmlSerializer(typeof(SerializableDictionary<string, Cal>));
                string read = File.ReadAllText(filename);
                dic = (SerializableDictionary<string, Cal>)Utf8XML.XMLDeserializer(ser, read);
            }
        }

        private void DataWebGet()
        {
            

            string[] studs = txtStudentId.Text.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries
                );
            
            
            foreach (var item in studs)
            {
                
                Cal c = Cal.getStudent(item, (int)nudFromWeek.Value, (int)nudToWeek.Value);
                dic.Add(item, c);
                // DebugReport(ts, item, c);
            }

            XmlSerializer ser = new XmlSerializer(typeof(SerializableDictionary<string, Cal>));
            var s = Utf8XML.XMLSerializer(ser, dic);
            using (TextWriter writer = File.CreateText("LastData.xml"))
            {
                writer.Write(s);
            }
        }

        private static void DebugReport(TimeSlot[] ts, string item, Cal c)
        {
            string stud = item + "\t";
            foreach (var tst in ts)
            {
                bool free = c.IsFreeOn(tst);
                bool bPossible = free;

                if (bPossible)
                {
                    if (c.IsDayFree(tst.dayOfWeek))
                        bPossible = false;
                }

                if (bPossible)
                {
                    int aft = c.ContinuousStretchAfter(tst);
                    int bef = c.ContinuousStretchBefore(tst);
                    int totSlot = aft + 2 + bef;
                    if (totSlot > 4)
                        bPossible = false;
                }

                if (bPossible)
                    stud += "True\t";
                else
                    stud += "\t";
            }
            Debug.WriteLine(stud);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataWebGet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSlot[] ts = new TimeSlot[]
            {
                new TimeSlot(CalItem.GetDay("Monday"), 16, 18),
                new TimeSlot(CalItem.GetDay("Wednesday"), 17, 19),
                new TimeSlot(CalItem.GetDay("Friday"), 9, 11),
                new TimeSlot(CalItem.GetDay("Friday"), 11, 13),
                new TimeSlot(CalItem.GetDay("Friday"), 15, 17),
            };

            foreach (var item in dic.Keys)
            {
                DebugReport(ts, item, dic[item]);
            }
        }
    }
}
