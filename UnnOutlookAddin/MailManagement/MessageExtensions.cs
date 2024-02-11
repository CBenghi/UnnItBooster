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
		/// <summary>
		/// string starting with smtp
		/// </summary>
		static readonly Regex regexStudentEmailPattern = new Regex(@"smtp:([a-zA-Z]\d{4,})@", RegexOptions.Compiled);
		/// <summary>
		/// simple student email pattern
		/// </summary>
		static readonly Regex regexSimpleEmailPattern = new Regex(@"([a-zA-Z]\d{4,})@", RegexOptions.Compiled);

		internal static bool SenderHasStudentId(this Outlook.MailItem mail, out string id)
		{
			var emails = mail.GetSenderEmailAddresses();
			return HasStudentId(emails, out id);
		}

		internal static bool HasStudentId(this Outlook.AddressEntry entry, out string id)
		{
			var emails = entry.GetAllEmailAddresses().ToList();
			if (!emails.Any())
			{
				if (entry.Name.Contains("@")) // this should contain the email
                    emails.Add(entry.Name); 
			}
			return HasStudentId(emails, out id);
		}

		private static bool HasStudentId(IEnumerable<string> emails, out string id)
		{
			id = GetStudentIdFromEmails(emails);
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
		
		

		private static string GetStudentIdFromEmails(IEnumerable<string> emails)
		{
			foreach (var emailaddress in emails)
			{

				var m = regexStudentEmailPattern.Match(emailaddress);
				if (m.Success)
				{
					return m.Groups[1].Value;
				}

				var m2 = regexSimpleEmailPattern.Match(emailaddress);
				if (m2.Success)
				{
					return m2.Groups[1].Value;
				}

			}
			return string.Empty;
		}

		public static IEnumerable<string> GetSenderEmailAddresses(this Outlook.MailItem mail)
		{
			Outlook.AddressEntry sender = mail.Sender;
			var t = GetAllEmailAddresses(sender).ToList();
			if (!t.Any())
				yield return mail.SenderEmailAddress;
			else
			{
				foreach (var item in t)
				{
					yield return item;
				}
			}
		}

		internal static IEnumerable<Student> GetAllStudents(this Outlook.MailItem mail)
		{
			var ts = GetStudent(mail.Sender);
			if (ts != null)
				yield return ts;
			foreach (Outlook.Recipient recip in mail.Recipients)
			{
				var t = GetStudent(recip.AddressEntry);
				if (t!= null)
					yield return t;
			}
		}


		private static Student GetStudent(Outlook.AddressEntry entry)
		{
			if (entry == null)
				return null;
			var user = entry.GetExchangeUser();
			if (user != null && entry.HasStudentId(out var id))
			{
				var s = new Student()
				{
					Forename = user.FirstName,
					Surname = user.LastName,
					Email = user.PrimarySmtpAddress,
				};
				s.Route = user.JobTitle;
				s.NumericStudentId = id;
				// txtInformation.Text += $"{user.FirstName}\t{user.LastName}\t{user.Name}\t{user.PrimarySmtpAddress}\t{id}\t{user.JobTitle}\r\n";
				return s;
			}
			return null;
		}

		private static IEnumerable<string> GetAllEmailAddresses(this Outlook.AddressEntry sender)
		{
            if ( sender is null)
            {
                yield break;
            }
            if (sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
				|| sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
			{
				Outlook.ExchangeUser exchUser = sender.GetExchangeUser();
				if (exchUser != null)
				{
					yield return exchUser.PrimarySmtpAddress;

					List<string> addresses = new List<string>() { "fail@OutlookError.com" };
					const string PR_EMS_AB_PROXY_ADDRESSES = "http://schemas.microsoft.com/mapi/proptag/0x800F101E";
					try
					{
						var addressesA = exchUser.PropertyAccessor.GetProperty(PR_EMS_AB_PROXY_ADDRESSES) as string[];
						addresses.Clear();
						addresses.AddRange(addressesA);
					}
					catch (Exception) // just swallow
					{

					}
					foreach (var address in addresses)
					{
						yield return address;
					}

				}
			}
		}

		public static string GetSenderEmailAddress(this Outlook.MailItem mail)
		{
			return mail.GetSenderEmailAddresses().FirstOrDefault();
		}
	}
}