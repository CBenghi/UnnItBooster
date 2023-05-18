using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnnItBooster.Models;
using Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Collections.Generic;
using UnnOutlookAddin.Actions;
using StudentsFetcher.StudentMarking;
using System.Security.Cryptography;
// using System.Diagnostics;

namespace UnnOutlookAddin.UI
{
	public partial class UnnStudent : UserControl
	{
		public UnnStudent(StudentsRepository repository)
		{
			InitializeComponent();
			_repository = repository;
			SystemReport();
		}

		private void SystemReport()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Students folder: {Repository.ConfigurationFolder.FullName}");
			stringBuilder.AppendLine($"");
			stringBuilder.AppendLine($"Collections:");
			foreach (var coll in Repository.GetPersonCollections())
			{
				stringBuilder.AppendLine($"- {coll.Name} ({coll.Students.Count})");
			}
			txtSystemInfo.Text = stringBuilder.ToString();
		}

		private StudentsRepository _repository = null;
		internal StudentsRepository Repository 
		{ 
			get
			{
				return _repository;				
			}
		}

		private string SetEmail(string email)
		{
			SetPicture(false);
			var students = Repository.Students.Where(x => x.Email == email).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Found: {students.Count} students.");
			stringBuilder.AppendLine($"");
			foreach (var stud in students)
			{
				if (string.IsNullOrEmpty(imagePath))
					Repository.HasImage(stud, out imagePath);
				stringBuilder.AppendLine($"{stud.NumericStudentId}");
				stringBuilder.AppendLine($"{stud.Route} {stud.CourseYear}");
				stringBuilder.AppendLine($"{stud.Occurrence}");
				stringBuilder.AppendLine($"{stud.Module}");
				stringBuilder.AppendLine($"First: {stud.Forename}");
				stringBuilder.AppendLine($"Last: {stud.Surname}");
				stringBuilder.AppendLine($"Full: {stud.FullName}");
				stringBuilder.AppendLine();
				stringBuilder.Append(stud.ReportTranscript());
			}
			return stringBuilder.ToString();
		}

		string imagePath = null;

		private void SetPicture(bool viewPicture)
		{
			if (viewPicture && !string.IsNullOrWhiteSpace(imagePath))
			{
				groupBox1.Visible = false;
				StudImage.Visible = true;
				StudImage.Load(imagePath);
			}
			else
			{
				imagePath = null;
				groupBox1.Visible = true;
				StudImage.Visible = false;
			}
		}

		private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SetPicture(txtInformation.Visible);
		}

		MailItem currentMailItem = null;

		internal async void SetMessageAsync(MailItem mailItem)
		{
			currentMailItem = mailItem;
			var snd = MessageClassificationExtensions.GetSenderEmailAddress(mailItem);
			var txt = SetEmail(snd);
			var folder = mailItem.Parent as MAPIFolder;
			if (folder != null)
				txt += $"\r\nFolder: {folder.Name}";
			txtInformation.Text = txt;
		}

		string DemoConversation(MailItem mailItem, out IEnumerable<ComboAction> actions)
		{
			var ret = new List<ComboAction>();
			StringBuilder sb = new StringBuilder();
			// Determine the store of the mail item. 
			var folder = mailItem.Parent as Folder;
			var store = folder.Store;
			if (store.IsConversationEnabled == true)
			{
				// Obtain a Conversation object. 
				Conversation conv = mailItem.GetConversation();
				if (conv != null)
				{
					sb.AppendLine("=== Root Conversation Items: ");
					try // Obtain root items and enumerate the conversation. 
					{
						var simpleRootItems = conv.GetRootItems();
						foreach (object item in simpleRootItems)
						{
							if (item is MailItem mail)
							{
								ret.AddRange(ComboAction.From(mail));
								Folder inFolder = mail.Parent as Folder;
								sb.AppendLine($"{mail.Subject} in folder `{inFolder.Name}` by {mail.Sender.Name}");
								ret.AddRange(EnumerateConversation(item, conv, sb));
							}
							else
								sb.AppendLine($"Not implemented type: {item.GetType()}");							
						}
					}
					catch (System.Exception ex)
					{
						sb.AppendLine($"{ex.Message}");
					}
				}
			}
			actions = ret;
			return sb.ToString();
		}


		List<ComboAction> EnumerateConversation(object item, Conversation conversation, StringBuilder sb, int indentation = 0)
		{
			List<ComboAction> list = new List<ComboAction>();
			var indent = new string(' ', indentation * 2);
			SimpleItems items = conversation.GetChildren(item);
			if (items.Count > 0)
			{
				foreach (object myItem in items)
				{
					if (myItem is MailItem mailItem)
					{
						list.AddRange(ComboAction.From(mailItem));
						Folder inFolder = mailItem.Parent as Folder;
						string msg = $"{indent}{mailItem.Subject} in folder {inFolder.Name} - {mailItem.Sender.Name}";
						sb.AppendLine(msg);
					}
					// Continue recursion. 
					list.AddRange(EnumerateConversation(myItem, conversation, sb, indentation + 1));
				}
			}
			else if (indentation == 0) 
			{
				sb.AppendLine("No children");
			}
			return list;
		}

		private void ButtonThread_Click(object sender, EventArgs e)
		{
			if (currentMailItem == null)
				return;
			txtInformation.Text += "\r\n\r\n" + DemoConversation(currentMailItem, out var actions);
			cmbAction.Items.Clear();
			cmbAction.Items.AddRange(actions.ToArray());
		}

		private void ButtonToggleWrap_Click(object sender, EventArgs e)
		{
			txtInformation.WordWrap = !txtInformation.WordWrap;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!(cmbAction.SelectedItem is ComboAction item))
				return;
			switch (item.ActionType)
			{
				case ComboAction.Tp.Search:
					var t = new StudentListForm();
					t.SetSearch((string)item.Tag);
					t.Show();
					break;
				case ComboAction.Tp.Image:
					if (!Repository.HasImage((string)item.Tag, out var image))
						Repository.TryGetExtraImage((string)item.Tag, out image);
					if (!string.IsNullOrEmpty(image))
					{
						imagePath = image;
						SetPicture(true);
					}
					break;
			}
		}
	}
}
