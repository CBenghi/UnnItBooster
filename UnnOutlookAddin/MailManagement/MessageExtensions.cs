using Outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnnItBooster.Models;

namespace UnnOutlookAddin.MailManagement
{
	public static class MessageClassificationExtensions
	{
		static readonly Regex regexStudentEmailPattern = new Regex(@"smtp:([a-zA-Z]\d{4,})@", RegexOptions.Compiled);

		internal static bool SenderHasStudentId(this Outlook.MailItem mail, out string id)
		{
			id = mail.GetSenderStudentId();
			return !string.IsNullOrEmpty(id);
		}

		internal static string GetUserProperty(this Outlook.MailItem mail, string propName)
		{
			Outlook.UserProperties mailUserProperties = null;
			Outlook.UserProperty mailUserProperty = null;
			try
			{
				mailUserProperties = mail.UserProperties;
				mailUserProperty = mailUserProperties.OfType<Outlook.UserProperty>().FirstOrDefault(x => x.Name == propName);
				if (mailUserProperty == null)
					return string.Empty;
				return mailUserProperty.Value;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
				return string.Empty;
			}
			finally
			{
				if (mailUserProperty != null)
					Marshal.ReleaseComObject(mailUserProperty);
				if (mailUserProperties != null)
					Marshal.ReleaseComObject(mailUserProperties);
			}
		}

		internal static void AddUserProperty(this Outlook.MailItem mail, string propName, string propValue)
		{
			Outlook.UserProperties mailUserProperties = null;
			Outlook.UserProperty mailUserProperty = null;
			try
			{
				mailUserProperties = mail.UserProperties;
				mailUserProperty = mailUserProperties.Add(propName, Outlook.OlUserPropertyType.olText, false, Outlook.OlFormatText.olFormatTextText);
				mailUserProperty.Value = propValue;
				mail.Save();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			finally
			{
				if (mailUserProperty != null)
					Marshal.ReleaseComObject(mailUserProperty);
				if (mailUserProperties != null)
					Marshal.ReleaseComObject(mailUserProperties);
			}
		}

		internal const string userIdPropertyName = "UnnStudentId";
		internal const string userIdNotFound = "-";

		internal static void Categorize(this Outlook.MailItem mail, MessageEditor messageEditor, StudentsRepository repo)
		{
			if (messageEditor == null)
				return;
			if (repo == null)
				return;
			string studentId;
			if (repo.TryGetStudentByEmail(mail.GetSenderEmailAddress(), out var st))
				studentId = st.NumericStudentId;
			else
				mail.SenderHasStudentId(out studentId);
			
			// tag if it is a student
			if (!string.IsNullOrEmpty(studentId))
			{
				messageEditor.SetCategory(mail, "Students");
				mail.AddUserProperty(userIdPropertyName, studentId);
			}
			else
			{
				mail.AddUserProperty(userIdPropertyName, userIdNotFound);
			}
		}

		static string GetSenderStudentId(this Outlook.MailItem mail)
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

		public static IEnumerable<string> GetSenderEmailAddresses(this Outlook.MailItem mail)
		{
			Outlook.AddressEntry sender = mail.Sender;
			if (sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
				|| sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
			{
				Outlook.ExchangeUser exchUser = sender.GetExchangeUser();
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

		public static string GetSenderEmailAddress(this Outlook.MailItem mail)
		{
			return mail.GetSenderEmailAddresses().FirstOrDefault();
		}
	}
}