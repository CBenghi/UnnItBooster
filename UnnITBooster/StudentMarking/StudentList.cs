using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using LateBindingTest;
using StudentMarking;

namespace StudentsFetcher.StudentMarking
{
    [AMMFormAttributes(ButtonText = "Student list", Order = -5)] 
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
            txtFolder.Text = Properties.Settings.Default.StudentsFolder;
            RefreshModulesList();
            StudentsLoad();
        }
        
        private void SaveSettings()
        {
            Properties.Settings.Default.StudentsFolder = txtFolder.Text;
            Properties.Settings.Default.Save();
        }

        private DirectoryInfo ConfigurationFolder
        {
            get
            {
                var txt = txtFolder.Text;
                var di = new DirectoryInfo(txt);
                if (!di.Exists)
                {
                    di = new DirectoryInfo(".");
                }
                return di;
            }
        }

        readonly WebClient _webClient = new WebClient { UseDefaultCredentials = true };

        private void DwonloadFile(string moduleCode)
        {
            var fileName = moduleCode + ".stud.xml";
            fileName = Path.Combine(ConfigurationFolder.FullName, fileName);
            // i think semster = 3 means both
            var url = string.Format(
                    @"http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsOnModuleXML.php?moduleCode={0}&semester=3",
                    moduleCode);
            _webClient.DownloadFile(url, fileName);


            fileName = moduleCode + ".routes.xml";
            fileName = Path.Combine(ConfigurationFolder.FullName, fileName);
            // i think semster = 3 means both
            url = string.Format(
                    @"http://wheel.northumbria.ac.uk/amfphp/services/unn/getModuleRoutesUsingXML.php?moduleCode={0}",
                    moduleCode);
            _webClient.DownloadFile(url, fileName);
            // more commands: view-source:http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentModulesXML.php?studentID=16030596
            // view-source:http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsByIDorName.php?studentID=16030596
            // this used to work and does not anymore: http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsByIDorNameXML.php?fieldName=studentID&searchString=12024427
            // this used to work and does not anymore: http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsByIDorNameXML.php?fieldName=studentName&searchString=asda

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentsLoad();
        }

        List<Student> _students = new List<Student>();
        Dictionary<string, string> _routes = new Dictionary<string, string>();

        private void StudentsLoad()
        {
            _students.Clear();
            _routes.Clear();
            
            foreach (var checkedItem in lstModules.CheckedItems)
            {
                var stFile = ConfigurationFolder.GetFiles(checkedItem + ".stud.xml").FirstOrDefault();
                _students.AddRange(StudentResolver.GetStudents(stFile));

                var sRt = ConfigurationFolder.GetFiles(checkedItem + ".routes.xml").FirstOrDefault();
                AddRoutes(sRt);

            }

            lstStudents.Items.Clear();
            foreach (var student in _students)
            {
                // sb.AppendFormat("{0}\t{1}\r\n", student.Forename, student.Module);
                AddStudent(student);
            }       

        }

        private void AddRoutes(FileInfo file)
        {
            if (file == null)
                return;
            var doc = XDocument.Load(file.FullName);
            var rows = doc.Descendants("route");
            foreach (var xElement in rows)
            {
                var rCode = xElement.Element("routeCode").Value;
                if (_routes.ContainsKey(rCode))
                    continue;
                _routes.Add(rCode, xElement.Element("routeTitle").Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtModuleCode.Text.Length != 6)
            {
                MessageBox.Show("Nothing done");
                return;
            }
            DwonloadFile(txtModuleCode.Text);
            MessageBox.Show("Done");           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();
            var flt = txtSearch.Text.Trim();
            if (flt == "")
            {
                foreach (var student in _students)
                {
                    AddStudent(student);
                }
            }
            foreach (var student in _students.Where(student => student.Matches(flt)))
            {
                AddStudent(student);
            }
        }

        private void AddStudent(Student student)
        {
            var li = new ListViewItem
            {
                Text = string.Format("{0} {1}", student.Forename, student.Surname),
                Tag = student
            };
            li.SubItems.Add(student.Context);
            li.SubItems.Add(student.Studentid);
            li.SubItems.Add(student.Email);
            if (_routes.ContainsKey(student.RouteCode))
                li.SubItems.Add(_routes[student.RouteCode]);
            else
                li.SubItems.Add(student.RouteCode);

            li.SubItems.Add(student.CourseStart != DateTime.MinValue ? student.CourseStart.ToShortDateString() : "");
            li.SubItems.Add(student.CourseFinish != DateTime.MinValue ? student.CourseFinish.ToShortDateString() : "");


            lstStudents.Items.Add(li);
        }

        private void lstStudents_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStudentInfo.Text = "";
            foreach (var selectedItem in lstStudents.SelectedItems)
            {
                var lvi = selectedItem as ListViewItem;
                if (lvi == null)
                    continue;
                TryShowStudent(lvi);
            }
        }

        private void TryShowStudent(ListViewItem lvi)
        {
            var st = lvi.Tag as Student;
            if (st == null)
                return;
            TryShowStudent(st);
        }

        string PictureFolder
        {
            get
            {
                return Path.Combine(ConfigurationFolder.FullName, "Pictures");
            }
        }

        private void TryShowStudent(Student st)
        {
            // load the picture
            var fname = st.PictureName(PictureFolder);
            if (!File.Exists(fname))
                FrmAutomaticMarkingMachine.GetImage(PictureFolder, st.Studentid);
            if (File.Exists(fname))
            {
                try
                {
                    StudImage.Load(fname);
                }
                catch 
                { }
            }
            else
                StudImage.Image = null;

            if (lstStudents.SelectedItems.Count == 1)
            {

                // var outlook = new OutlookEmailerLateBinding();
                var sb = new StringBuilder();
                sb.AppendFormat("{0} {1}\r\n", st.Forename, st.Surname);
                sb.AppendFormat("First Name: {0}\r\n", st.Forename);
                sb.AppendFormat("{0} {1}\r\n", st.Studentid, st.RouteCode);
                sb.AppendFormat("{0}\r\n\r\n", st.Email);

                sb.AppendFormat("OneLine:\t{0}\t{1}\t{2}\t{3}\r\n", st.Forename, st.Surname, st.Studentid, st.Email);

                txtStudentInfo.Text = sb.ToString();
            }
            else
            {
                var sb = new StringBuilder();

                var Cohort = (_routes.ContainsKey(st.RouteCode)) 
                    ? _routes[st.RouteCode]
                    : st.RouteCode;

                sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\r\n", st.Forename, st.Surname, st.Studentid, Cohort, st.Email);

                txtStudentInfo.Text += sb.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshModulesList();
        }

        private void RefreshModulesList()
        {
            lstModules.Items.Clear();
            foreach (var file in ConfigurationFolder.GetFiles("*.stud.xml"))
            {
                var modname = file.Name.Substring(0, 6);
                lstModules.Items.Add(modname);
            }

            for (var i = 0; i < lstModules.Items.Count; i++)
                lstModules.SetItemChecked(i, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstModules.Items.Count; i++)
            {
                lstModules.SetItemChecked(i, false);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var s = new StudentResolver();

            var stds = new List<Student>();

            foreach (var oneLine in txtStudents.Lines)
            {
                var lineAsArr = oneLine.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
                var cnt = lineAsArr.Count();
                if (cnt < 6)
                    continue;

                var fullName = lineAsArr[1];
                var completeId = lineAsArr[0];
                if (completeId.Contains("/"))
                {
                    completeId = completeId.Substring(0, completeId.IndexOf("/"));
                }               
                var stud = s.ResolveByName(fullName, "TUTEES", completeId);
                if (stud == null)
                {
                    stud = new Student()
                    {
                        Surname = fullName,
                        Studentid = completeId,
                        Context = "TUTEES",
                        RouteCode = lineAsArr[5] + " " + lineAsArr[2],
                        
                    };
                }
                    
                
                stud.CourseStart = DateTime.Parse(lineAsArr[3]);
                stud.CourseFinish = DateTime.Parse(lineAsArr[4]);

                stds.Add(stud);
                _students.Add(stud);
                AddStudent(stud);
            }

            var tuteesFileName = Path.Combine(ConfigurationFolder.FullName, "TUTEES.stud.xml");
            StudentResolver.WriteList(stds, tuteesFileName);
        }

        private void txtStudents_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var s = new StudentResolver();
            var st = s.ResolveByName("Ampuan Nurul Atikah Ampuan Mumali", "freeSearch");

        }
    }
}
