using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using UnnFunctions.ModelConversions;
using UnnFunctions.Models;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
	[AmmFormAttributes("Student list", 2)]
	public partial class StudentListForm : Form
	{
		private StudentsRepository studentsRepo;

		Student? displayedStudent = null;

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
				Text = student.GetFullName(),
				Tag = student
			};
			li.SubItems.Add(student.Route);
			li.SubItems.Add(student.NumericStudentId);
			li.SubItems.Add(student.Email);
			li.SubItems.Add($"{student.Module} {student.Occurrence}");
			li.SubItems.Add(student.DSSR ? "DSSR" : "");
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
				displayedStudent = st;
				var sb = new StringBuilder();
				sb.AppendLine($"{st.Forename} {st.Surname}\r\n");
				sb.AppendLine($"First Name: {st.Forename}\r\n");
				sb.AppendLine($"{st.NumericStudentId} {st.Route}\r\n");
				sb.AppendLine($"{st.Email}");
				if (st.AlternativeEmails != null)
				{
					foreach (var item in st.AlternativeEmails)
					{
						sb.AppendLine($"Alternative email: {st.Email}");
					}
				}
				sb.AppendLine($"");
				sb.AppendLine($"OneLine:\t{st.Forename}\t{st.Surname}\t{st.NumericStudentId}\t{st.Email}");
				sb.Append(st.ReportTranscript());

				txtStudentInfo.Text = sb.ToString();
			}
			else
			{
				displayedStudent = null;
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
			foreach (var coll in studentsRepo.GetPersonCollections())
				lstModules.Items.Add($"{coll.Name} - {coll.Students.Count}");

			for (var i = 0; i < lstModules.Items.Count; i++)
				lstModules.SetItemChecked(i, true);

			UpdateStudentList();
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
			var students = UnnItBooster.ModelConversions.eVision.GetStudentsFromEvisionHtml(Clipboard.GetText());
			txtReport.Text = studentsRepo.ConsiderNewStudents(students, txtModuleCode.Text);
			RefreshModulesList();
		}

		

		private void cmdSelectSource_Click(object sender, EventArgs e)
		{
			using var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				txtInputSource.Text = openFileDialog.FileName;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var f = new FileInfo(txtInputSource.Text);
			if (!f.Exists)
				return;
			var students = UnnItBooster.ModelConversions.TurnItIn.GetStudentsFromGradebook(f.FullName);
			txtReport.Text = studentsRepo.ConsiderNewStudents(students, txtModuleCode.Text);
			RefreshModulesList();
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			var r = new Regex(@"(.*) - \d+");
			var items = lstModules.CheckedItems.Cast<string>().Select(x => r.Match(x).Groups[1].Value);
			studentsRepo.Reload(items);
			UpdateStudentList();
		}

		private void BtnAddEmail_Click(object sender, EventArgs e)
		{
			if (displayedStudent == null)
				return;
			studentsRepo.AddAlternativeEmail(
				displayedStudent,
				txtAlternativeEmail.Text
				);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			var students = StringStudentCollection.UnpersistString(Clipboard.GetText());
			txtReport.Text = studentsRepo.ConsiderNewStudents(students, txtModuleCode.Text);
			RefreshModulesList();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (displayedStudent == null)
				return;
			if (studentsRepo.TryGetExtraImage(displayedStudent.NumericStudentId, out var image, txtContainerName.Text))
			{
				StudImage.Load(image);
			}
		}

		private void BtnGetSelectedStudents_Click(object sender, EventArgs e)
		{
			var tallyTry = 0;
			var tallySuccess = 0;
			foreach (var item in lstStudents.SelectedItems.OfType<ListViewItem>())
			{
				if (item.Tag is Student stud)
				{
					tallyTry++;
					if (studentsRepo.TryGetExtraImage(stud.NumericStudentId, out var image, txtContainerName.Text))
						tallySuccess++;
				}
			}
			MessageBox.Show($"Attempted image for {tallyTry}; {tallySuccess} found.");			
		}

		private void button9_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var code in GetAllCodes().Distinct().OrderBy(x=>x))
			{
				ModuleResult.Report(sb, code);
			}
			txtReport.Text = sb.ToString();	
		}

		private IEnumerable<string> GetAllCodes()
		{
			foreach (var s in studentsRepo.Students)
			{
				foreach(var item in s.UsedCodes())
				{
					yield return item;
				}
			}
		}
	}
}
