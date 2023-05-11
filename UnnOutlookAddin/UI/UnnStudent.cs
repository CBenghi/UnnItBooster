using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnnItBooster.Models;

namespace UnnOutlookAddin.UI
{
    public partial class UnnStudent : UserControl
    {
        public UnnStudent()
        {
            InitializeComponent();
			repository = StudentsRepository.GetRespository();
			SystemReport();
		}

		private void SystemReport()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Students folder: {repository.ConfigurationFolder.FullName}");
			stringBuilder.AppendLine($"");
			stringBuilder.AppendLine($"Collections:");
			foreach (var coll in repository.GetCollections())
			{
				stringBuilder.AppendLine($"- {coll.Name} ({coll.Students.Count})");
			}
			txtSystemInfo.Text = stringBuilder.ToString();
		}

		StudentsRepository repository;

		public void SetEmail(string email)
        {
			SetPicture(false);
			var students = repository.Students.Where(x => x.Email == email).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Found: {students.Count} students.");
			stringBuilder.AppendLine($"");
			foreach (var stud in students)
			{
				if (string.IsNullOrEmpty(imagePath))
					repository.HasImage(stud, out imagePath);
				stringBuilder.AppendLine($"{stud.NumericStudentId}");
				stringBuilder.AppendLine($"{stud.Route} {stud.CourseYear}");
				stringBuilder.AppendLine($"{stud.Occurrence}");
				stringBuilder.AppendLine($"{stud.Module}");
				stringBuilder.AppendLine($"First: {stud.Forename}");
				stringBuilder.AppendLine($"Last: {stud.Surname}");
				stringBuilder.AppendLine($"Full: {stud.FullName}");
				stringBuilder.AppendLine();
			}
			txtInformation.Text = stringBuilder.ToString();
		}

		string imagePath = null;

		private void SetPicture(bool viewPicture)
		{
			if (viewPicture && !string.IsNullOrWhiteSpace(imagePath))
			{
				txtInformation.Visible = false;
				StudImage.Visible = true;
				StudImage.Load(imagePath);
			}
            else
            {
				imagePath = null;
				txtInformation.Visible = true;
				StudImage.Visible = false;
			}
        }

		private void label2_Click(object sender, EventArgs e)
		{
			repository.Reload();
			SystemReport();
		}

		private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SetPicture(txtInformation.Visible);
		}
	}
}
