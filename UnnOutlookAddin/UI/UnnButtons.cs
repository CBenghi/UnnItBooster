using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;

namespace UnnOutlookAddin.UI
{
    public partial class UnnButtons
    {
        private void UnnButtons_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnClassify_Click(object sender, RibbonControlEventArgs e)
        {
            var messageEditor = new MessageActions(e.Control.Context);

            var explorer = e.Control.Context as Outlook.Explorer;
            if (explorer is null)
                return;

            foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
            {
                if (selectedMailMessage.SenderHasStudentId())
                {
                    messageEditor.SetCategory(selectedMailMessage, "Students");
                    
                }
            }
        }
    }
}
