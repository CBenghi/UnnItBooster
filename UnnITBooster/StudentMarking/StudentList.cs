using System;
using System.Collections.Generic;
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
            StudentsLoad();
        }

        private class Student
        {
            public string Module;
            public string Surname;
            public string Forename;
            public string RouteCode;
            public string Studentid;
            public string CourseYear;
            public string Email;

            public bool Matches(string filter)
            {
                if (Module == filter)
                    return true;
                if (
                    Surname.Contains(filter)
                    || Forename.Contains(filter)
                    )
                    return true;
                return 
                    Studentid.Contains(filter) 
                    || Email.Contains(filter);
            }

            public string PictureName(string pictureFolder)
            {
                return Path.Combine(pictureFolder, String.Format("{0}.jpg", Studentid));
            }
        }

        private List<Student> GetModuleStudents(FileInfo file)
        {
            var modName = file.Name.Replace(".stud.xml", "");
            var doc = XDocument.Load(file.FullName);
            var rows = doc.Descendants("student").Select(el => new Student
            {
                Module = modName,
                Surname = GetField(el, "surname"),
                Forename = GetField(el, "forename"),
                RouteCode = GetField(el, "routeCode"),
                Studentid = GetField(el, "studentid"),
                CourseYear = GetField(el, "courseyear"),
                Email = GetField(el, "email")
            }).ToList();

            //foreach (var item in rows)
            //{
            //    frmAutomaticMarkingMachine.GetImage(folder, item.Studentid);
            //}
            return rows;
        }

        private static string GetField(XContainer el, string fieldName)
        {
            var fld = el.Element(fieldName);
            return fld != null 
                ? fld.Value 
                : "<Missing>";
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.StudentsFolder = txtFolder.Text;
            Properties.Settings.Default.Save();
        }

        private DirectoryInfo Folder
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

        private void DwonloadFile(string moduleCode)
        {
            var c = new WebClient {UseDefaultCredentials = true};
            var fileName = moduleCode + ".stud.xml";
            fileName = Path.Combine(Folder.FullName, fileName);
            // i think semster = 3 means both
            var url = string.Format(
                    @"http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsOnModuleXML.php?moduleCode={0}&semester=3",
                    moduleCode);
            c.DownloadFile(url, fileName);


            fileName = moduleCode + ".routes.xml";
            fileName = Path.Combine(Folder.FullName, fileName);
            // i think semster = 3 means both
            url = string.Format(
                    @"http://wheel.northumbria.ac.uk/amfphp/services/unn/getModuleRoutesUsingXML.php?moduleCode={0}",
                    moduleCode);
            c.DownloadFile(url, fileName);
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
            foreach (var file in Folder.GetFiles("*.stud.xml"))
            {
                _students.AddRange(GetModuleStudents(file));
            }
            foreach (var file in Folder.GetFiles("*.routes.xml"))
            {
                AddRoutes(file);
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
            li.SubItems.Add(student.Module);
            li.SubItems.Add(student.Studentid);
            li.SubItems.Add(student.Email);
            if (_routes.ContainsKey(student.RouteCode))
                li.SubItems.Add(_routes[student.RouteCode]);
            lstStudents.Items.Add(li);
        }

        private void lstStudents_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                return Path.Combine(Folder.FullName, "Pictures");
            }
        }

        private void TryShowStudent(Student st)
        {
            // load the picture
            var fname = st.PictureName(PictureFolder);
            if (!File.Exists(fname))
                FrmAutomaticMarkingMachine.GetImage(PictureFolder, st.Studentid);
            if (File.Exists(fname))
                StudImage.Load(fname);
            else
                StudImage.Image = null;

            // todo:  list emails 
            // var outlook = new OutlookEmailerLateBinding();
            var sb = new StringBuilder();
            sb.AppendFormat("{0} {1}\r\n", st.Forename, st.Surname);
            sb.AppendFormat("{0} {1}\r\n", st.Studentid, st.RouteCode);
            sb.AppendFormat("{0}\r\n", st.Email);

            txtStudentInfo.Text = sb.ToString();

        }
    }
}
