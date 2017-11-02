using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UnnOutlookAddin.UI
{
    public partial class UnnButtons
    {
        private void UnnButtons_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnClassify_Click(object sender, RibbonControlEventArgs e)
        {
            var messageEditor = new MessageEditor(e.Control.Context);

            var explorer = e.Control.Context as Outlook.Explorer;
            if (explorer == null)
                return;

            foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
            {
                selectedMailMessage.Categorize(messageEditor);
            }
        }

        private void CopyId_Click(object sender, RibbonControlEventArgs e)
        {
            CopyUserId(e);
        }

        private static void CopyUserId(RibbonControlEventArgs e, bool numberOnly = false)
        {
            var explorer = e.Control.Context as Outlook.Explorer;
            if (explorer == null)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
            {
                var id = selectedMailMessage.GetUserProperty(MessageExtensions.userIdPropertyName);
                if (numberOnly)
                {
                    id = Unn.Students.StudentId.NumericFromString(id);
                }
                sb.AppendLine(id);
            }
            Clipboard.SetText(sb.ToString());
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            CopyUserId(e, true);
        }
    }
}
