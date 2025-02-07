using System;
using System.Windows.Forms;

namespace UnnOutlookAddin
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
			LoadSettings();
		}

		private void LoadSettings()
		{
			txtConfigFolder.Text = Properties.Settings.Default.StudentsFolder;
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.StudentsFolder = txtConfigFolder.Text;
			Properties.Settings.Default.Save();
			Close();
		}
	}
}
