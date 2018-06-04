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
using StudentsFetcher.Webdata;

namespace StudentsFetcher.StudentMarking
{
    [AMMFormAttributes(ButtonText = "Student list", Order = -5)] 
    public partial class StudentList : Form
    {
        private StudentsData studentsRepo;

        public StudentList()
        {
            InitializeComponent();
            studentsRepo = new StudentsData();
            txtFolder.Text = studentsRepo.DataFolder;

            var studs = studentsRepo.LoadStudents();

            UpdateStudentList();
            RefreshModulesList();
        }
        
        private void SaveSettings()
        {
            Properties.Settings.Default.StudentsFolder = txtFolder.Text;
            Properties.Settings.Default.Save();
            studentsRepo = new StudentsData();
        }

        public void SetSearch(string uid)
        {
            txtSearch.Text = uid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentsRepo.LoadStudents(lstModules);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtModuleCode.Text.Length != 6)
            {
                MessageBox.Show("Nothing done");
                return;
            }
            studentsRepo.DwonloadFile(txtModuleCode.Text);
            MessageBox.Show("Done");           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateStudentList();
        }

        private void UpdateStudentList()
        {
            lstStudents.Items.Clear();
            var flt = txtSearch.Text.Trim();
            if (flt == "")
            {
                foreach (var student in studentsRepo.Students)
                {
                    AddStudent(student);
                }
            }
            else
            {
                foreach (var student in studentsRepo.Students.Where(student => student.Matches(flt)))
                {
                    AddStudent(student);
                }
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
            li.SubItems.Add(student.NumericStudentId);
            li.SubItems.Add(student.Email);
            li.SubItems.Add(studentsRepo.GetPrettyRoute(student.RouteCode));
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
        
        private void TryShowStudent(Student st)
        {
            // load the picture
            var fname = st.PictureName(StudentsData.PictureFolder);
            if (!File.Exists(fname))
                FrmAutomaticMarkingMachine.GetImage(StudentsData.PictureFolder, st.NumericStudentId);
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
                sb.AppendFormat("{0} {1}\r\n", st.NumericStudentId, st.RouteCode);
                sb.AppendFormat("{0}\r\n\r\n", st.Email);

                sb.AppendFormat("OneLine:\t{0}\t{1}\t{2}\t{3}\r\n", st.Forename, st.Surname, st.NumericStudentId, st.Email);

                txtStudentInfo.Text = sb.ToString();
            }
            else
            {
                var sb = new StringBuilder();
                var Cohort = studentsRepo.GetPrettyRoute(st.RouteCode);
                sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\r\n", st.Forename, st.Surname, st.NumericStudentId, Cohort, st.Email);
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
            foreach (var file in StudentsData.ConfigurationFolder.GetFiles("*.stud.xml"))
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
            MessageBox.Show("code suspended. fixme.");
            //var s = new StudentResolver();
            //var stds = new List<Student>();

            //foreach (var oneLine in txtStudents.Lines)
            //{
            //    var lineAsArr = oneLine.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
            //    var cnt = lineAsArr.Count();
            //    if (cnt < 6)
            //        continue;

            //    var fullName = lineAsArr[1];
            //    var completeId = lineAsArr[0];
            //    if (completeId.Contains("/"))
            //    {
            //        completeId = completeId.Substring(0, completeId.IndexOf("/"));
            //    }               
            //    var stud = s.ResolveByName(fullName, "TUTEES", completeId);
            //    if (stud == null)
            //    {
            //        stud = new Student()
            //        {
            //            Surname = fullName,
            //            Studentid = completeId,
            //            Context = "TUTEES",
            //            RouteCode = lineAsArr[5] + " " + lineAsArr[2],
                        
            //        };
            //    }
                    
                
            //    stud.CourseStart = DateTime.Parse(lineAsArr[3]);
            //    stud.CourseFinish = DateTime.Parse(lineAsArr[4]);

            //    stds.Add(stud);
            //    _students.Add(stud);
            //    AddStudent(stud);
            //}

            //var tuteesFileName = Path.Combine(ConfigurationFolder.FullName, "TUTEES.stud.xml");
            //StudentResolver.WriteList(stds, tuteesFileName);
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
