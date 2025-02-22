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
			stringBuilder.AppendLine();
			stringBuilder.AppendLine($"Collections:");
			foreach (var coll in Repository.GetPersonCollections())
			{
				stringBuilder.AppendLine($"- {coll.Name} ({coll.Students.Count})");
			}
			stringBuilder.AppendLine();

			var ctn = Repository.StudentsByCollection(x =>
				string.IsNullOrEmpty(x.Surname)
				|| string.IsNullOrEmpty(x.Forename)
				).ToArray();
			if (ctn.Length > 0)
			{
				stringBuilder.AppendLine($"WARNING: {ctn.Length} students have null or empty name or last name.");
				stringBuilder.AppendLine($"WARNING: This can be fixed with the command above.");
				if (ctn.Length < 20)
				{
					foreach (var item in ctn)
					{
						var stud = item.student;
						stringBuilder.AppendLine($"- {item.collection.Name} {stud.Email}, {stud.FullName}, {stud.NumericStudentId}.");
					}
				}
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

			var students = Repository.StudentsByCollection(x => x.HasEmail(email)).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Found: {students.Count} student records.");
			stringBuilder.AppendLine();
			foreach (var pair in students)
			{
				var stud = pair.student;
				stringBuilder.AppendLine($"=== Collection: {pair.collection.Name}, {pair.collection.OutlookFolder}");
				if (string.IsNullOrEmpty(imagePath))
					Repository.HasImage(stud, out imagePath);
				stringBuilder.AppendLine($"ID: w{stud.NumericStudentId} {stud.NumericStudentId}");
				stringBuilder.AppendLine($"Route/Year: {stud.Route} {stud.CourseYear}");
				stringBuilder.AppendLine($"Occurrence: {stud.Occurrence}");
				stringBuilder.AppendLine($"Module: {stud.Module}");
				stringBuilder.AppendLine($"First: {stud.Forename}");
				stringBuilder.AppendLine($"Last: {stud.Surname}");
				stringBuilder.AppendLine($"Full: {stud.FullName}");
				stringBuilder.AppendLine();
				if (stud.TranscriptResults.Any())
				{
					var transcriptLines = stud.ReportTranscript(false).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
					foreach (var line in transcriptLines)
					{
						stringBuilder.AppendLine($"  {line}");
					}
					stringBuilder.AppendLine();
				}
			}
			return stringBuilder.ToString();
		}

		string imagePath = null;

		private void SetPicture(bool viewPicture)
		{
			if (viewPicture && !string.IsNullOrWhiteSpace(imagePath))
			{
				StudImage.Visible = true;
				StudImage.Load(imagePath);
			}
			else
			{
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
			// provide basic information
			//
			currentMailItem = mailItem;
			var snd = MessageClassificationExtensions.GetSenderEmailAddress(mailItem);
			var folder = mailItem.Parent as Outlook.MAPIFolder;
			var txt = "";
			if (folder != null)
				txt += $"Folder: {folder.Name}\r\n";
			txt += SetEmail(snd);
			txtInformation.Text = txt;

			// evaluate thread
			//
			PopulateComboActions();
		}

		IEnumerable<Outlook.MailItem> GetConversationItems(Outlook.MailItem mailItem)
		{
			var ret = new List<Outlook.MailItem>();
			ret.Add(mailItem);

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
					catch (Exception)
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
			txtInformation.Text += PopulateComboActions().ToString();
			MessageBox.Show("Any IDs found have been listed in the information tab.");
		}

		private StringBuilder PopulateComboActions()
		{
			StringBuilder sb = new StringBuilder();
			if (currentMailItem == null)
			{
				sb.Append("No current mail item.");
				return sb;
			}
			List<Student> distinctStudents = GetDistinctThreadStudents(sb);
			cmbAction.Items.Clear();
			if (!distinctStudents.Any())
			{
				sb.AppendLine("No student");
				return sb;
			}

			sb.Append("\r\n" + StringStudentCollection.PersistString(distinctStudents));
			var lst = new List<ComboAction>();
			foreach (var st in distinctStudents)
			{
				lst.AddRange(ComboAction.From(st));
			}
			cmbAction.Items.AddRange(lst.ToArray());
			if (cmbAction.Items.Count > 0)
				cmbAction.SelectedIndex = cmbAction.Items.Count - 1;

			return sb;
		}

		private List<Student> GetDistinctThreadStudents(StringBuilder sb = null)
		{
			var mailItems = GetConversationItems(currentMailItem).ToList();
			sb?.Append("\r\n\r\n");
			List<Student> students = new List<Student>();
			foreach (var mailItem in mailItems)
			{
				students.AddRange(mailItem.GetAllStudents());
				Outlook.Folder inFolder = mailItem.Parent as Outlook.Folder;
				var senderName = mailItem.Sender is null ? "Undefined sender" : mailItem.Sender.Name;
				sb?.Append($"{mailItem.Subject} in folder {inFolder.Name} - {senderName}\r\n");
			}

			var distinctStudents = students.GroupBy(x => x.NumericStudentId).Select(x => x.First()).ToList();
			return distinctStudents;
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
					{
						var t = new StudentListForm();
						t.SetSearch((string)item.Tag);
						t.Show();
					}
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

			foreach (var folder in distFolders)
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
				else
				{
					txtInformation.Text += $"\r\nOutlook Folder {container.OutlookFolder} not found.";
				}
			}
			if (CmbFolder.Items.Count > 0)
			{
				CmbFolder.SelectedItem = CmbFolder.Items[0];
			}
		}

		private void BtnSolveStudentName_Click(object sender, EventArgs e)
		{
			string prompt = "This routine looks for all students in the repository and tries to resolve their name, based on their email address.";
			var ret = MessageBox.Show(prompt, "Continue?", MessageBoxButtons.YesNoCancel);
			if (ret != DialogResult.Yes)
			{
				txtSystemInfo.Text = "Cancelled";
				return;
			}
			StringBuilder sb = new StringBuilder();
			var attemptedEmail = new List<string>();
			var attemptedStudents = new List<Student>();
			foreach (var unnamedStudent in ThisAddIn.StudentsRepository.Students)
			{
				if (!string.IsNullOrEmpty(unnamedStudent.Forename))
					continue;
				if (string.IsNullOrEmpty(unnamedStudent.Email))
					continue;
				if (attemptedEmail.Contains(unnamedStudent.Email))
					continue;
				sb.Append($"Item to attempt: {unnamedStudent.Email}");
				attemptedEmail.Add(unnamedStudent.Email);

				var user = Globals.ThisAddIn.GetUser(unnamedStudent.Email);
				if (user == null)
					continue;
				var studentWithName = new Student()
				{
					Forename = user.FirstName,
					Surname = user.LastName,
					Email = unnamedStudent.Email,
					NumericStudentId = unnamedStudent.NumericStudentId,
				};
				if (string.IsNullOrEmpty(unnamedStudent.Route))
				{
					studentWithName.Route = user.JobTitle;
				}
				attemptedStudents.Add(studentWithName);
			}
			foreach (var stud in attemptedStudents)
			{
				var cnt = ThisAddIn.StudentsRepository.UpdateStudentInfo(stud);
				sb.AppendLine($"Updating: {stud.Email} (<{stud.Forename}> <{stud.Surname}>) updatedrecords: {cnt}");
			}
			txtSystemInfo.Text = sb.ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string prompt = "This routine looks for all students in email thread and creates a collection to be saved to disk.";
			var ret = MessageBox.Show(prompt, "Continue?", MessageBoxButtons.YesNoCancel);

			if (string.IsNullOrEmpty(txtCollection.Name))
			{
				txtSystemInfo.Text = "Collection name cannot be empty.";
				return;
			}
			if (!Repository.IsValidNewCollectionName(txtCollection.Text, out var returnd))
			{
				txtSystemInfo.Text = $"Invalid new collection name '{txtCollection.Text}'.";
				return;
			}
			if (ret != DialogResult.Yes)
			{
				txtSystemInfo.Text = "Cancelled";
				return;
			}
			var distinctStudents = GetDistinctThreadStudents();
			txtSystemInfo.Text = Repository.ConsiderNewStudents(distinctStudents, txtCollection.Text);
		}
	}
}
