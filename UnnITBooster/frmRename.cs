using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentsFetcher
{
	[AmmFormAttributes("Bulk file rename")]
	public partial class frmRename : Form
	{
		public frmRename()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var i = 1;
			var d = new DirectoryInfo(txtFolder.Text);
			var files = d.GetFiles("*.*", SearchOption.AllDirectories).ToArray();
			foreach (var file in files)
			{
				var found = false;
				string newFileName = "";
				while (!found)
				{
					var fileName = i.ToString() + file.Extension;
					newFileName = Path.Combine(file.DirectoryName, fileName);
					found = !File.Exists(newFileName);
					i++;
				}
				file.MoveTo(newFileName);
			}
		}
	}
}
