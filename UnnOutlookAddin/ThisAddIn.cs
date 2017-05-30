using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;
using Office = Microsoft.Office.Core;

namespace UnnOutlookAddin
{
    public partial class ThisAddIn
    {
        Inspectors _inspectors;
        Explorer _currentExplorer;

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            if (false)
            {
                _inspectors = Application.Inspectors;
                _inspectors.NewInspector +=
                    Inspectors_NewInspector;
            }

            // selection change

            _currentExplorer = Application.ActiveExplorer();
            _currentExplorer.SelectionChange += CurrentExplorer_Event;


        }

        private string getSenderEmailAddress(MailItem mail)
        {
            AddressEntry sender = mail.Sender;
            string SenderEmailAddress = "";

            if (sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeUserAddressEntry ||
                sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
            {
                ExchangeUser exchUser = sender.GetExchangeUser();
                if (exchUser != null)
                {
                    SenderEmailAddress = exchUser.PrimarySmtpAddress;
                    const string PR_EMS_AB_PROXY_ADDRESSES = "http://schemas.microsoft.com/mapi/proptag/0x800F101E";
                    var addresses = exchUser.PropertyAccessor.GetProperty(PR_EMS_AB_PROXY_ADDRESSES) as string[];

                    var r = new Regex(@"smtp:(\w\d{4,})@");
                    foreach (var address in addresses)
                    {
                        var m = r.Match(address);
                        if (m.Success)
                        {
                            // we've got a student address
                            var id = m.Groups[1].Value;
                        }    
                    }
                }
            }
            else
            {
                SenderEmailAddress = mail.SenderEmailAddress;
            }
            return SenderEmailAddress;
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
                    if (selObject is MailItem)
                    {
                        var mailItem = selObject as MailItem;
                        // itemMessage = "The item is an e-mail message. The subject is " + mailItem.Subject + ".";
                        var add = mailItem.SenderEmailAddress;
                        var snd = getSenderEmailAddress(mailItem);


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

        void Inspectors_NewInspector(Inspector Inspector)
        {
            MailItem mailItem = Inspector.CurrentItem as MailItem;
            if (mailItem != null)
            {
                Debug.WriteLine(mailItem.ReceivedByEntryID);
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
