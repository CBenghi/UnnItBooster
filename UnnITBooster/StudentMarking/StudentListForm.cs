using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UnnFunctions.ModelConversions;
using UnnFunctions.Models;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
	[AmmFormAttributes("Student list", 2)]
	public partial class StudentListForm : Form
	{
		private StudentsRepository studentsRepo => UnnToolsConfiguration.Settings.StudentsRepository;

		Student? displayedStudent = null;

		public StudentListForm()
		{
			InitializeComponent();
			txtFolder.Text = studentsRepo.ConfigurationFolder.FullName;
			UpdateStudentList();
			RefreshModulesList();
		}

		private void SaveSettings()
		{
			var set = UnnToolsConfiguration.Settings;
			set.StudentRepositoryFolder = txtFolder.Text;
			set.Save();
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
				// list all students
				foreach (var studentColl in studentsRepo.StudentsAndCollection)
				{
					AddStudent(studentColl);
				}
			}
			else
			{
				// list matches only
				foreach (var studentAndColl in studentsRepo.StudentsAndCollection.Where(pair => 
					pair.student.Matches(flt)
					|| pair.collectionName.Matches(flt)
					))
				{
					AddStudent(studentAndColl);
				}
			}
			// if there is no student but a valid id, we offer to download a photo
			BtnDisplayWebPhoto.Visible = lstStudents.Items.Count == 0 && StudentsRepository.IsNumericUserId(txtSearch.Text);
		}

		private void AddStudent((Student student, string collectionName) studentAndCollection)
		{
			ListViewItem li = StudentToListItem(studentAndCollection.student);

			var extra = studentAndCollection.collectionName;
			if (studentAndCollection.student.TranscriptResults.Any())
			{
				extra += $" Transcript: {studentAndCollection.student.TranscriptResults.Count}";
			}

			li.SubItems.Add(extra);
			lstStudents.Items.Add(li);
		}

		private void AddStudent(Student student)
		{
			ListViewItem li = StudentToListItem(student);
			lstStudents.Items.Add(li);
		}

		private static ListViewItem StudentToListItem(Student student)
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
			return li;
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
			if (lstStudents.SelectedItems.Count > 1)
			{
				txtStudentInfo.Text = txtStudentInfo.Text + Environment.NewLine + $"Count: {lstStudents.SelectedItems.Count}";
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
				GroupDownloadImage.Visible = false;
			}
			else
			{
				GroupDownloadImage.Visible = true;
				StudImage.Image = null;
			}

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
						sb.AppendLine($"Alternative email: {item}");
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
			txtInputSource.Text = GetFile();
		}

		private string GetFile()
		{
			using var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				return openFileDialog.FileName;
			}
			return "";
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
			IEnumerable<string> items = GetSelectedCollectionNames();
			studentsRepo.Reload(items);
			UpdateStudentList();
		}

		private IEnumerable<string> GetSelectedCollectionNames()
		{
			var r = new Regex(@"(.*) - \d+");
			var items = lstModules.CheckedItems.Cast<string>().Select(x => r.Match(x).Groups[1].Value);
			return items;
		}

		private void BtnAddEmail_Click(object sender, EventArgs e)
		{
			if (displayedStudent == null)
				return;
			var students = studentsRepo.AddAlternativeEmail(
				displayedStudent,
				txtAlternativeEmail.Text
				);
			if (students > 0)
			{
				txtAlternativeEmail.Text = $"{students} found";
			}
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

		private IEnumerable<Student> GetSelectedStudents()
		{
			foreach (var item in lstStudents.SelectedItems.OfType<ListViewItem>())
				if (item.Tag is Student stud)
					yield return stud;
		}

		private void BtnGetSelectedStudents_Click(object sender, EventArgs e)
		{
			var tallyTry = 0;
			var tallySuccess = 0;
			foreach (var stud in GetSelectedStudents())
			{
				tallyTry++;
				if (studentsRepo.TryGetExtraImage(stud.NumericStudentId, out var image, txtContainerName.Text))
					tallySuccess++;
			}
			MessageBox.Show($"Attempted image for {tallyTry}; {tallySuccess} found.");
		}

		private void button9_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var code in GetAllCodes().Distinct().OrderBy(x => x))
			{
				ModuleResult.Report(sb, code);
			}
			txtReport.Text = sb.ToString();
		}

		private IEnumerable<string> GetAllCodes()
		{
			foreach (var s in studentsRepo.Students)
			{
				foreach (var item in s.UsedCodes())
				{
					yield return item;
				}
			}
		}

		private void BtnSelectEmails_Click(object sender, EventArgs e)
		{
			var sb = new StringBuilder();
			foreach (var student in GetSelectedStudents())
			{
				sb.Append($"{student.Email}; ");
			}
			txtStudentInfo.Text = sb.ToString();
		}

		private void BtnDisplayWebPhoto_Click(object sender, EventArgs e)
		{
			StudImage.LoadAsync(StudentsRepository.GetImageUrl(txtSearch.Text));
		}

		private void BtnGetPhotos_Click(object sender, EventArgs e)
		{
			int tallySuccess = 0;
			foreach (var collection in GetSelectedCollectionNames())
			{
				var coll = studentsRepo.GetPersonCollections().FirstOrDefault(x => x.Name == collection);
				if (coll is null)
					continue;
				foreach (Student stud in coll.Students)
				{
					if (studentsRepo.TryGetExtraImage(stud.NumericStudentId, out var image, collection))
						tallySuccess++;
				}
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			var sel = GetSelectedCollections();
			if (sel.Count != 1)
			{
				MessageBox.Show("Check one, and only one collection.");
				return;
			}
			var se = sel.First();
			se.OutlookFolder = textBox2.Text;
			se.Save();
		}

		private List<IStudentCollection> GetSelectedCollections()
		{
			var collNames = GetSelectedCollectionNames().ToList();
			return studentsRepo.GetPersonCollections().Where(x => collNames.Contains(x.Name)).ToList();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			elpAnalyticsSource.Text = GetFile();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			var f = new FileInfo(elpAnalyticsSource.Text);
			IEnumerable<Student>? students = null;
			if (f.Exists)
				students = UnnItBooster.ModelConversions.Elp.GetStudentsFromAnalyticsFile(f.FullName);
			else if (elpAnalyticsSource.Text.StartsWith("Surname,First Name,Username"))
				students = UnnItBooster.ModelConversions.Elp.GetStudentsFromAnalyticsContent(elpAnalyticsSource.Text);
			if (students is null)
				return;
			txtReport.Text = studentsRepo.ConsiderNewStudents(students, txtModuleCode.Text);
			RefreshModulesList();
		}
	}
}