using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;
using UnnOutlookAddin.MailManagement;

namespace UnnOutlookAddin
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors _inspectors;
        Outlook.Explorer _currentExplorer;

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            
            // tracking of new email creation?
            if (false)
            {
                _inspectors = Application.Inspectors;
                _inspectors.NewInspector += Inspectors_NewInspector;
            }

            // registering events of selection change
            if (false)
            {
                _currentExplorer = Application.ActiveExplorer();
                _currentExplorer.SelectionChange += CurrentExplorer_Event;
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
                    if (selObject is Outlook.MailItem)
                    {
                        var mailItem = selObject as Outlook.MailItem;
                        // itemMessage = "The item is an e-mail message. The subject is " + mailItem.Subject + ".";
                        var add = mailItem.SenderEmailAddress;
                        var snd = MessageExtensions.GetSenderEmailAddress(mailItem);
                        // mailItem.Display(false);
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
                expMessage = expMessage + itemMessage;
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
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                // Debug.WriteLine(mailItem.ReceivedByEntryID);
                if (mailItem.EntryID == null)
                {
                    mailItem.Subject = "This text was added by using code";
                    mailItem.Body = "This text was added by using code";
                }
            }
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
