using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using UnnOutlookAddin.MailManagement;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using StudentsFetcher.StudentMarking;

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
            var t = getId(e, numberOnly);
            Clipboard.SetText(t);
        }

        private static string getId(RibbonControlEventArgs e, bool numberOnly = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in GetUserIds(e, numberOnly))
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }

        private static IEnumerable<string> GetUserIds(RibbonControlEventArgs e, bool numberOnly)
        {
            var explorer = e.Control.Context as Outlook.Explorer;
            if (explorer == null)
                yield break;
            foreach (var selectedMailMessage in explorer.Selection.OfType<Outlook.MailItem>())
            {
                var id = selectedMailMessage.GetUserProperty(MessageExtensions.userIdPropertyName);
                if (numberOnly)
                {
                    id = Unn.Students.StudentId.NumericFromString(id);
                }
                yield return id;
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            CopyUserId(e, true);
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            frmSettings s = new frmSettings();
            s.ShowDialog();
        }

        private void btnPerson_Click(object sender, RibbonControlEventArgs e)
        {
            var uid = GetUserIds(e, true).FirstOrDefault();
            if (string.IsNullOrEmpty(uid))
                return;
            var t = new StudentList();
            t.SetSearch(uid);
            t.Show();
        }
    }
}
