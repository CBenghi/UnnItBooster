using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;
using UnnOutlookAddin.MailManagement;

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

			//// tracking of new email creation?
			//if (false)
			//{
			//    _inspectors = Application.Inspectors;
			//    _inspectors.NewInspector += Inspectors_NewInspector;
			//}

			// registering events of selection change
			_currentExplorer = Application.ActiveExplorer();
			_currentExplorer.SelectionChange += CurrentExplorer_Event;


			// display the Students pane
			//
			myStudentComponent = new UI.UnnStudent();
			var myCustomTaskPane = CustomTaskPanes.Add(myStudentComponent, "UnnStudentPane");
			myCustomTaskPane.Visible = true;
		}

		UI.UnnStudent myStudentComponent = null;

		private void AutomaticClassificationHandler(object Item)
		{
			if (Item is Outlook.MailItem emailItem)
			{
				if (emailItem.UnRead)
				{
					var messageEditor = new MessageEditor(_currentExplorer);
					emailItem.Categorize(messageEditor);
				}
			}
		}

		private void CurrentExplorer_Event()
		{
			var selectedFolder = Application.ActiveExplorer().CurrentFolder;
			var expMessage = "Your current folder is " + selectedFolder.Name + ".\n";
			var itemMessage = "Item is unknown.";
			try
			{
				if (Application.ActiveExplorer().Selection.Count > 0)
				{
					object selObject = Application.ActiveExplorer().Selection[1];
					if (selObject is Outlook.MailItem mailItem)
					{
						// itemMessage = "The item is an e-mail message. The subject is " + mailItem.Subject + ".";
						myStudentComponent.SetMessage(mailItem);
					}
					//else if (selObject is Outlook.ContactItem)
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
				}
				expMessage += itemMessage;
			}
			catch (Exception ex)
			{
				expMessage = ex.Message;
			}
			// MessageBox.Show(expMessage);
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
