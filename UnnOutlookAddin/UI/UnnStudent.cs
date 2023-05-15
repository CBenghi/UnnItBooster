using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnnItBooster.Models;
using Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnnOutlookAddin.UI
{
	public partial class UnnStudent : UserControl
	{
		public UnnStudent()
		{
			InitializeComponent();
			SystemReport();
		}

		private void SystemReport()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Students folder: {repository.ConfigurationFolder.FullName}");
			stringBuilder.AppendLine($"");
			stringBuilder.AppendLine($"Collections:");
			foreach (var coll in repository.GetPersonCollections())
			{
				stringBuilder.AppendLine($"- {coll.Name} ({coll.Students.Count})");
			}
			txtSystemInfo.Text = stringBuilder.ToString();
		}

		private StudentsRepository repository => StudentsRepository.Repo;

		private string SetEmail(string email)
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
			return stringBuilder.ToString();
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

		private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SetPicture(txtInformation.Visible);
		}

		

		internal async void SetMessageAsync(MailItem mailItem)
		{
			var snd = MessageClassificationExtensions.GetSenderEmailAddress(mailItem);
			var txt = SetEmail(snd);
			var folder = mailItem.Parent as MAPIFolder;
			if (folder != null)
				txt += $"\r\nFolder: {folder.Name}";
			txtInformation.Text = txt;
			// await EvaluateConversationAsync(mailItem);
		}

		private async Task<bool> EvaluateConversationAsync(MailItem mailItem)
		{
			var ret = await Task.Run(() =>
			{
				//var conversation = mailItem.GetConversation();
				//if (conversation == null)
				//	return false;
				//var children = conversation.GetChildren(conversation);
				DemoConversation(mailItem);
				return true;
			});
			return ret;
		}

		void DemoConversation(MailItem mailItem)
		{

			// Determine the store of the mail item. 
			var folder = mailItem.Parent as Folder;
			var store = folder.Store;
			if (store.IsConversationEnabled == true)
			{
				// Obtain a Conversation object. 
				Conversation conv = mailItem.GetConversation();
				// Check for null Conversation. 
				if (conv != null)
				{
					// Obtain Table that contains rows for each item in the conversation. 
					//var table = conv.GetTable();
					//Debug.WriteLine($"Conversation Items Count: {table.GetRowCount()}");
					//Debug.WriteLine("Conversation Items from Table:");
					//while (!table.EndOfTable)
					//{
					//	Row nextRow = table.GetNextRow();
					//	Debug.WriteLine($"{nextRow["Subject"]} Modified: {nextRow["LastModificationTime"]}");
					//}
					Debug.Write("=== Conversation Items from Root: ");
					// Obtain root items and enumerate the conversation. 
					try
					{
						var simpleItems = conv.GetRootItems();
						foreach (object item in simpleItems)
						{
							// In this example, only enumerate MailItem type.
							// Other types such as PostItem or MeetingItem 
							// can appear in the conversation. 
							if (item is MailItem mail)
							{
								Folder inFolder = mail.Parent as Folder;
								Debug.WriteLine($"{mail.Subject} in folder `{inFolder.Name}` by {mail.Sender.Name}");
								// Call EnumerateConversation 
								// to access child nodes of root items. 
								EnumerateConversation(item, conv);
							}
							else
							{
								Debug.WriteLine($"Not implemented type: {item.GetType()}");
							}

						}
					}
					catch (System.Exception ex)
					{
						Debug.WriteLine($"{ex.Message}");
					}
					
				}
			}
		}


		void EnumerateConversation(object item, Conversation conversation, int indentation = 0)
		{
			var indent = new string(' ', indentation * 2);
			SimpleItems items = conversation.GetChildren(item);
			if (items.Count > 0)
			{
				foreach (object myItem in items)
				{
					if (myItem is MailItem mailItem)
					{
						Folder inFolder = mailItem.Parent as Folder;
						string msg = $"{indent}{mailItem.Subject} in folder {inFolder.Name} - {mailItem.Sender.Name}";
						Debug.WriteLine(msg);
					}
					// Continue recursion. 
					EnumerateConversation(myItem, conversation, indentation + 1);
				}
			}
			else if (indentation == 0) 
			{
				Debug.WriteLine("No children");
			}
		}


	}
}
