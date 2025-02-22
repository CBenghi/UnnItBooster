using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Windows.Forms;
using StudentsFetcher.StudentMarking;
using System.Diagnostics;
using UnnFunctions.Models;

namespace UnnOutlookAddin.UI
{
	public partial class UnnButtons
	{
		private void BtnClassify_Click(object sender, RibbonControlEventArgs e)
		{
			var messageEditor = new MessageEditor(e.Control.Context);

			var explorer = e.Control.Context as Outlook.Explorer;
			if (explorer == null)
				return;

			foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
			{
				selectedMailMessage.Categorize(messageEditor, ThisAddIn.StudentsRepository);
			}
		}

		private void CopyId_Click(object sender, RibbonControlEventArgs e)
		{
			CopyUserId(e);
		}

		private static void CopyUserId(RibbonControlEventArgs e, bool numberOnly = false)
		{
			var t = GetId(e, numberOnly);
			Clipboard.SetText(t);
		}

		private static string GetId(RibbonControlEventArgs e, bool numberOnly = false)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in GetUserIds(e, numberOnly))
			{
				sb.AppendLine(item);
			}
			return sb.ToString();
		}

		private static IEnumerable<string> GetUserIds(RibbonControlEventArgs e, bool numberOnly)
		{
			var explorer = e.Control.Context as Outlook.Explorer;
			if (explorer == null)
				yield break;
			foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
			{
				var id = selectedMailMessage.GetUserProperty(MessageClassificationExtensions.userIdPropertyName);
				if (numberOnly)
				{
					id = StudentCode.NumericFromString(id);
				}
				yield return id;
			}
		}

		private void CopyUserNumber_Click(object sender, RibbonControlEventArgs e)
		{
			CopyUserId(e, true);
		}

		private void BtnSettings_Click(object sender, RibbonControlEventArgs e)
		{
			frmSettings s = new frmSettings();
			s.ShowDialog();
		}

		private void BtnPerson_Click(object sender, RibbonControlEventArgs e)
		{
			try
			{
				var uid = GetUserIds(e, true).FirstOrDefault();
				var t = new StudentListForm();
				if (!string.IsNullOrEmpty(uid))
					t.SetSearch(uid);
				t.Show();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

		}
	}
}
