using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnnOutlookAddin.MailManagement
{
    public static class MessageExtensions
    {
        static Regex regexStudentEmailPattern = new Regex(@"smtp:([a-zA-Z]\d{4,})@", RegexOptions.Compiled);

        internal static bool SenderHasStudentId(this MailItem mail)
        {
            return !string.IsNullOrEmpty(mail.GetSenderStudentId());
        }

        static string GetSenderStudentId(this MailItem mail)
        {
            foreach (var emailaddress in mail.GetSenderEmailAddresses())
            {
                var m = regexStudentEmailPattern.Match(emailaddress);
                if (m.Success)
                {
                    return m.Groups[1].Value;
                }
            }
            return string.Empty;
        }

        public static IEnumerable<string> GetSenderEmailAddresses(this MailItem mail)
        {
            AddressEntry sender = mail.Sender;
            if (sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeUserAddressEntry 
                || sender.AddressEntryUserType == OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
            {
                ExchangeUser exchUser = sender.GetExchangeUser();
                if (exchUser != null)
                {
                    yield return exchUser.PrimarySmtpAddress;

                    const string PR_EMS_AB_PROXY_ADDRESSES = "http://schemas.microsoft.com/mapi/proptag/0x800F101E";
                    var addresses = exchUser.PropertyAccessor.GetProperty(PR_EMS_AB_PROXY_ADDRESSES) as string[];

                    foreach (var address in addresses)
                    {
                        yield return address;
                    }
                }
            }
            else
            {
                yield return mail.SenderEmailAddress;
            }
        }


        public static string GetSenderEmailAddress(this MailItem mail)
        {
            return mail.GetSenderEmailAddresses().FirstOrDefault();
        }
    }
}