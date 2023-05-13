using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsFetcher
{
	[AmmFormAttributes("Match lists", 4)]
	public partial class frmMatchLists : Form
	{
		public frmMatchLists()
		{
			InitializeComponent();
		}


		private void Go_Click(object sender, EventArgs e)
		{
			txtMatched.Text = "";

			int MatchDigits = Convert.ToInt32(nudChars.Value);

			string[] MainArray = txtMain.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
			string[] RepoArray = txtToMatch.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

			foreach (var mainString in MainArray)
			{
				string[] ret = FindMatches(mainString, RepoArray, MatchDigits);
				txtMatched.Text += string.Format("{0}\t{1}\r\n", mainString, string.Join("\t", ret));
			}
		}

		private string[] FindMatches(string mainString, string[] RepoArray, int MatchDigits)
		{
			List<string> ret = new List<string>();
			string toFind = Sub(mainString, MatchDigits);
			if (toFind != "")
			{
				foreach (var item in RepoArray)
				{
					var repoget = Sub(item, MatchDigits);
					if (toFind == repoget)
						ret.Add(item);
				}
			}
			return ret.ToArray();
		}

		private string Sub(string SourceString, int MatchDigits)
		{
			SourceString = SourceString.Trim();
			if (SourceString.Length < MatchDigits)
				return "";
			string val = SourceString.Substring(SourceString.Length - MatchDigits, MatchDigits);
			return val;
		}

		private void cmdCopyClip_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(txtMatched.Text);
		}

		private void cmdSwap_Click(object sender, EventArgs e)
		{
			string tmp = txtMain.Text;
			txtMain.Text = txtToMatch.Text;
			txtToMatch.Text = tmp;
		}

		private void matchByContains_Click(object sender, EventArgs e)
		{
			txtMatched.Text = "";
			string[] MainArray = txtMain.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			string[] RepoArray = txtToMatch.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			foreach (var mainString in MainArray)
			{
				if (mainString == "")
				{
					txtMatched.Text += "\r\n";
					continue;
				}
				string[] ret = RepoArray.Where(x => x.Contains(mainString)).ToArray();
				txtMatched.Text += string.Format($"{mainString}\t{string.Join("\t", ret)}\r\n");
			}
		}
	}
}
