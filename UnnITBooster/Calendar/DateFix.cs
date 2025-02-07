using System;
using System.IO;
using System.Windows.Forms;

namespace StudentsFetcher.Calendar
{
	[AmmFormAttributes("Fix file dates")]
	public partial class DateFix : Form
	{
		public DateFix()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			var n = @"C:\Users\Claudio\Dropbox (Northumbria University)\Amsterdam\Courses\AT7026 - People in project management\Module Box\AT7026 - Internal and External Sample Moderation Form (MOD3) 001.docx";
			File.SetLastWriteTime(n, new DateTime(2019, 01, 22, 15, 07, 20));

			var d = @"C:\Users\Claudio\Dropbox (Northumbria University)\Amsterdam\Courses\AT7026 - People in project management\Module Box\ForInternalModeration";
			var fls = Directory.EnumerateFiles(d);
			var rand = new Random();
			foreach (var fl in fls)
			{
				int h = Convert.ToInt32(12 + rand.NextDouble() * 7);
				int m = Convert.ToInt32(0 + rand.NextDouble() * 57);
				int s = Convert.ToInt32(0 + rand.NextDouble() * 57);
				File.SetLastWriteTime(fl, new DateTime(2019, 01, 15, h, m, s));
			}
		}
	}
}
