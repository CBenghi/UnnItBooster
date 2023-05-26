using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnnItBooster.Models;
using UnnOutlookAddin.MailManagement;
using System.Collections.Generic;
using UnnOutlookAddin.Actions;
using StudentsFetcher.StudentMarking;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnFunctions.ModelConversions;
using Microsoft.Office.Interop.Outlook;

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
			CmbFolder.Items.Clear();
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

		Outlook.MailItem currentMailItem = null;

		internal async void SetMessageAsync(Outlook.MailItem mailItem)
		{
			currentMailItem = mailItem;
			var snd = MessageClassificationExtensions.GetSenderEmailAddress(mailItem);
			var txt = SetEmail(snd);
			var folder = mailItem.Parent as Outlook.MAPIFolder;
			if (folder != null)
				txt += $"\r\nFolder: {folder.Name}";
			txtInformation.Text = txt;
		}

		IEnumerable<Outlook.MailItem> GetConversationItems(Outlook.MailItem mailItem)
		{
			var ret = new List<Outlook.MailItem>();
			
			// Determine the store of the mail item. 
			var folder = mailItem.Parent as Outlook.Folder;
			var store = folder.Store;
			if (store.IsConversationEnabled == true)
			{
				// Obtain a Conversation object. 
				Outlook.Conversation conv = mailItem.GetConversation();
				if (conv != null)
				{
			
					try // Obtain root items and enumerate the conversation. 
					{
						var simpleRootItems = conv.GetRootItems();
						foreach (object item in simpleRootItems)
						{
							if (item is Outlook.MailItem mail)
							{
								ret.Add(mail);
								Outlook.Folder inFolder = mail.Parent as Outlook.Folder;
								
								ret.AddRange(EnumerateConversation(item, conv));
							}
						}
					}
					catch (System.Exception ex)
					{
						
					}
				}
			}
			return ret;
		}

		List<Outlook.MailItem> EnumerateConversation(object item, Outlook.Conversation conversation)
		{
			List<Outlook.MailItem> list = new List<Outlook.MailItem>();
			Outlook.SimpleItems items = conversation.GetChildren(item);
			if (items.Count > 0)
			{
				foreach (object myItem in items)
				{
					if (myItem is Outlook.MailItem mailItem)
					{
						list.Add(mailItem);
						Outlook.Folder inFolder = mailItem.Parent as Outlook.Folder;
					}
					// Continue recursion. 
					list.AddRange(EnumerateConversation(myItem, conversation));
				}
			}
			return list;
		}
		
		private void ButtonThread_Click(object sender, EventArgs e)
		{
			if (currentMailItem == null)
				return;
			var mailItems = GetConversationItems(currentMailItem).ToList();
			

			txtInformation.Text += "\r\n\r\n";
			List<Student> students = new List<Student>();
			foreach (var mailItem in mailItems)
			{
				students.AddRange(mailItem.GetAllStudents());
				Outlook.Folder inFolder = mailItem.Parent as Outlook.Folder;
				var senderName = mailItem.Sender is null ? "Undefined sender" : mailItem.Sender.Name;
				txtInformation.Text += $"{mailItem.Subject} in folder {inFolder.Name} - {senderName}\r\n";				
			}

			var distinctStudents = students.GroupBy(x => x.NumericStudentId).Select(x => x.First()).ToList();
			cmbAction.Items.Clear();
			if (!distinctStudents.Any())
				return;

			txtInformation.Text += "\r\n" + StringStudentCollection.PersistString(distinctStudents);
			var lst = new List<ComboAction>();
			foreach (var st in distinctStudents)
			{
				lst.AddRange(ComboAction.From(st));
			}
			cmbAction.Items.AddRange(lst.ToArray());
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
				case ComboAction.Tp.ShowImage:
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

		private void CmdFolder_Click(object sender, EventArgs e)
		{
			if (CmbFolder.SelectedItem != null)
			{
				if (CmbFolder.SelectedItem is ComboAction item && item.ActionType == ComboAction.Tp.MoveToFolder && item.Tag is Outlook.Folder fld && currentMailItem != null)
					currentMailItem.Move(fld);				
				return;
			}
			CmbFolder.Items.Clear();
			if (currentMailItem is null)
				return;
			var threadMessages = GetConversationItems(currentMailItem).ToList();
			var folders = threadMessages.Where(x => x.Parent is Outlook.Folder).Select(x => x.Parent).OfType<Outlook.Folder>().ToList(); 
			var distFolders = folders.GroupBy(p => p.Name)
					  .Select(g => g.First())
					  .ToList();

			foreach ( var folder in distFolders) 
			{
				ComboAction act = ComboAction.From(folder);
				if (folder.Name != "Inbox" && folder.Name != "Sent Items")
				{
					CmbFolder.Items.Add(act);
				}
			}
			var senderEmail = MessageClassificationExtensions.GetSenderEmailAddress(currentMailItem);
			var conts = _repository.GetContainersFor(senderEmail);
			foreach (var container in conts)
			{
				if (string.IsNullOrEmpty(container.OutlookFolder))
					continue;
				var f = Globals.ThisAddIn.GetFolder(container.OutlookFolder);
				if (f != null) 
                {
					CmbFolder.Items.Add(
						ComboAction.From(f)
						);
				}
            }
			if (CmbFolder.Items.Count > 0)
			{
				CmbFolder.SelectedItem = CmbFolder.Items[0];
			}
		}

	}
}
