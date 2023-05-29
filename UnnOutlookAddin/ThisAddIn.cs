using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Linq;
using UnnItBooster.Models;
using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnnOutlookAddin
{
	public partial class ThisAddIn
	{
		Outlook.Explorer _currentExplorer;
		Outlook.NameSpace _outlookNameSpace;
		Outlook.MAPIFolder _inbox;
		Outlook.Items _items;

		private void ThisAddIn_Startup(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.ClassifyOnNewItem)
			{
				_outlookNameSpace = Application.GetNamespace("MAPI");
				_inbox = _outlookNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

				_items = _inbox.Items;
				_items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(AutomaticClassificationHandler);
			}

			// registering events of selection change
			_currentExplorer = Application.ActiveExplorer();
			_currentExplorer.SelectionChange += CurrentExplorer_Event;


			// display the Students pane
			//
			StudentsRepository = new StudentsRepository(Properties.Settings.Default.StudentsFolder);
			myStudentComponent = new UI.UnnStudent(StudentsRepository);
			var myCustomTaskPane = CustomTaskPanes.Add(myStudentComponent, "UnnStudentPane");
			myCustomTaskPane.Visible = true;
		}

		internal static StudentsRepository StudentsRepository;

		UI.UnnStudent myStudentComponent = null;

		private void AutomaticClassificationHandler(object Item)
		{
			if (Item is Outlook.MailItem emailItem)
			{
				if (emailItem.UnRead)
				{
					var messageEditor = new MessageEditor(_currentExplorer);
					emailItem.Categorize(messageEditor, StudentsRepository);
				}
			}
		}

		internal ExchangeUser GetUser(string email)
		{
			var rec = _outlookNameSpace.CreateRecipient(email);
			if (rec == null)
				return null;
			rec.Resolve();
			var ae = rec.AddressEntry;
			if (ae != null)
				return ae.GetExchangeUser();
			return null;
		}

		string lastMailId = string.Empty;

		private void CurrentExplorer_Event()
		{
			var exp = Application.ActiveExplorer();
			// var selectedFolder = exp.CurrentFolder;
			//var expMessage = "Your current folder is " + selectedFolder.Name + ".\n";
			//var itemMessage = "Item is unknown.";
			if (exp.Selection.Count != 1)
				return;
			var mailItem = exp.Selection.OfType<Outlook.MailItem>().FirstOrDefault();
			if (mailItem is null)
				return;
			if (mailItem.EntryID != lastMailId)
			{
				lastMailId = mailItem.EntryID;
				myStudentComponent.SetMessageAsync(mailItem);
			}

			//try
			//{
			//	if (exp.Selection.Count > 0)
			//	{
			//		object selObject = Application.ActiveExplorer().Selection[1];
			//		if (selObject is Outlook.MailItem mailItem)
			//		{
			//			// itemMessage = "The item is an e-mail message. The subject is " + mailItem.Subject + ".";

			//		}
			//		//else if (selObject is Outlook.ContactItem)
			//{
			//    Outlook.ContactItem contactItem =
			//        (selObject as Outlook.ContactItem);
			//    itemMessage = "The item is a contact." +
			//                  " The full name is " + contactItem.Subject + ".";
			//    contactItem.Display(false);
			//}
			//else if (selObject is Outlook.AppointmentItem)
			//{
			//    Outlook.AppointmentItem apptItem =
			//        (selObject as Outlook.AppointmentItem);
			//    itemMessage = "The item is an appointment." +
			//                  " The subject is " + apptItem.Subject + ".";
			//}
			//else if (selObject is Outlook.TaskItem)
			//{
			//    Outlook.TaskItem taskItem =
			//        (selObject as Outlook.TaskItem);
			//    itemMessage = "The item is a task. The body is "
			//                  + taskItem.Body + ".";
			//}
			//else if (selObject is Outlook.MeetingItem)
			//{
			//    Outlook.MeetingItem meetingItem =
			//        (selObject as Outlook.MeetingItem);
			//    itemMessage = "The item is a meeting item. " +
			//                  "The subject is " + meetingItem.Subject + ".";
			//}
			//	}
			//	// expMessage += itemMessage;
			//}
			//catch (Exception ex)
			//{
			//	// expMessage = ex.Message;
			//}
			//// MessageBox.Show(expMessage);
		}

		private void ThisAddIn_Shutdown(object sender, EventArgs e)
		{
			// Note: Outlook no longer raises this event. If you have code that 
			// must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			Startup += ThisAddIn_Startup;
			Shutdown += ThisAddIn_Shutdown;
		}

		internal Folder GetFolder(string folderName)
		{
			var fldsrs = folderName.Split('/');
			var sub = fldsrs.Skip(1);
			foreach (var candidateFolder in _inbox.Folders.OfType<Folder>())
			{
				if (candidateFolder.Name == fldsrs[0])
				{
					if (sub.Any())
						return GetSubFolder(candidateFolder, sub);
					else 
						return candidateFolder;
				}
			}
			return null;
		}

		private Folder GetSubFolder(Folder startFolder, IEnumerable<string> path)
		{
			var search = path.First();
			var sub = path.Skip(1);
			foreach (var subF in startFolder.Folders.OfType<Folder>())
			{
				if (subF.Name == search)
				{
					if (sub.Any())
						return GetSubFolder(subF, sub);
					else
						return subF;
				}
			}
			return null;
		}

		#endregion
	}
}
