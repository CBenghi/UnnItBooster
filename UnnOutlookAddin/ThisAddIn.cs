using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Linq;
using UnnItBooster.Models;

namespace UnnOutlookAddin
{
	public partial class ThisAddIn
	{
		Outlook.Explorer _currentExplorer;
		Outlook.NameSpace outlookNameSpace;
		Outlook.MAPIFolder inbox;
		Outlook.Items items;

		private void ThisAddIn_Startup(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.ClassifyOnNewItem)
			{
				outlookNameSpace = Application.GetNamespace("MAPI");
				inbox = outlookNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

				items = inbox.Items;
				items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(AutomaticClassificationHandler);
			}

			// registering events of selection change
			_currentExplorer = Application.ActiveExplorer();
			_currentExplorer.SelectionChange += CurrentExplorer_Event;


			// display the Students pane
			//
			Repository = new StudentsRepository(Properties.Settings.Default.StudentsFolder);
			myStudentComponent = new UI.UnnStudent(Repository);
			var myCustomTaskPane = CustomTaskPanes.Add(myStudentComponent, "UnnStudentPane");
			myCustomTaskPane.Visible = true;
		}

		internal static StudentsRepository Repository;

		UI.UnnStudent myStudentComponent = null;

		private void AutomaticClassificationHandler(object Item)
		{
			if (Item is Outlook.MailItem emailItem)
			{
				if (emailItem.UnRead)
				{
					var messageEditor = new MessageEditor(_currentExplorer);
					emailItem.Categorize(messageEditor, Repository);
				}
			}
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

		#endregion
	}
}
