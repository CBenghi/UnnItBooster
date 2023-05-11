using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
	[AMMFormAttributes(ButtonText = "Student list", Order = -5)]
	public partial class StudentListForm : Form
	{
		private StudentsRepository studentsRepo;

		public StudentListForm()
		{
			InitializeComponent();
			studentsRepo = new StudentsRepository(Properties.Settings.Default.StudentsFolder);
			txtFolder.Text = studentsRepo.ConfigurationFolder.FullName;
			UpdateStudentList();
			RefreshModulesList();
		}

		private void SaveSettings()
		{
			Properties.Settings.Default.StudentsFolder = txtFolder.Text;
			Properties.Settings.Default.Save();
			studentsRepo = new StudentsRepository(Properties.Settings.Default.StudentsFolder);
		}

		public void SetSearch(string uid)
		{
			txtSearch.Text = uid;
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
			if (string.IsNullOrEmpty(flt))
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
			li.SubItems.Add(student.FullName);
			li.SubItems.Add(student.NumericStudentId);
			li.SubItems.Add(student.Email);
			li.SubItems.Add(student.Route);
			li.SubItems.Add(student.DSSR ? "DSSR" : "");
			li.SubItems.Add($"{student.Module} {student.Occurrence}");
			lstStudents.Items.Add(li);
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
			if (!(lvi.Tag is Student st))
				return;
			TryShowStudent(st);
		}

		private void TryShowStudent(Student st)
		{
			// load the picture
			if (studentsRepo.HasImage(st, out var image))
			{
				try
				{
					StudImage.Load(image);
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
				sb.AppendLine($"{st.Forename} {st.Surname}\r\n");
				sb.AppendLine($"First Name: {st.Forename}\r\n");
				sb.AppendLine($"{st.NumericStudentId} {st.Route}\r\n");
				sb.AppendLine($"{st.Email}");
				sb.AppendLine($"");
				sb.AppendLine($"OneLine:\t{st.Forename}\t{st.Surname}\t{st.NumericStudentId}\t{st.Email}");
				txtStudentInfo.Text = sb.ToString();
			}
			else
			{
				var sb = new StringBuilder();
				sb.AppendLine($"{st.Forename}\t{st.Surname}\t{st.NumericStudentId}\t{st.Route}\t{st.Email}");
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
			studentsRepo.Reload();
			foreach (var coll in studentsRepo.GetCollections())
				lstModules.Items.Add($"{coll.Name} - {coll.Students.Count}");
			
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

		private void button2_Click(object sender, EventArgs e)
		{
			var students = UnnItBooster.ModelConversions.eVision.GetStudentsFromEvisionClipboard(Clipboard.GetText());
			ConsiderNewStudents(students);
		}

		private void ConsiderNewStudents(IEnumerable<Student> students)
		{
			if (string.IsNullOrEmpty(txtModuleCode.Text))
			{
				txtReport.Text += $"No destination code.\r\n";
				return;
			}
			if (!students.Any())
			{
				txtReport.Text += $"No students to process.\r\n";
				return;
			}

			txtReport.Text += $"Processing {students.Count()} records.\r\n";
			var coll = studentsRepo.GetCollections().FirstOrDefault(x => x.Name == txtModuleCode.Text);
			if (coll is null)
			{
				if (studentsRepo.IsValidNewCollectionName(txtModuleCode.Text, out var containerFullName))
				{
					// if new and valid
					txtReport.Text += $"New container {containerFullName}\r\n";
					_ = StudentJsonCollection.Create(containerFullName, students);
				}
			}
			else
			{
				// if update and exists
				var studs = coll.Students.MergeInformation(students);
				coll.Students = studs.ToList();
				txtReport.Text += $"Merged in existing container, total of {studs.Count()} records.\r\n";
				coll.Save();
			}
			studentsRepo.Reload();
			RefreshModulesList();
		}

		private void cmdSelectSource_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					txtInputSource.Text = openFileDialog.FileName;					
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var f = new FileInfo(txtInputSource.Text);
			if (!f.Exists)
				return;
			var students = UnnItBooster.ModelConversions.TurnItIn.GetStudentsFromGradebook(f.FullName);

			ConsiderNewStudents(students);
		}
	}
}
