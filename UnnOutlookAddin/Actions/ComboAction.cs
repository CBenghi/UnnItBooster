﻿using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using UnnItBooster.Models;
using UnnOutlookAddin.MailManagement;

namespace UnnOutlookAddin.Actions
{
	internal class ComboAction
	{
		public static IEnumerable<ComboAction> From(Student st)
		{
			if (st == null)
				yield break;
			var Name = st.GetFullName();
			yield return new ComboAction()
			{
				ActionType = Tp.Search,
				Text = $"Search: {Name} ({st.NumericStudentId})",
				Tag = st.NumericStudentId,
			};
			yield return new ComboAction()
			{
				ActionType = Tp.ShowImage,
				Text = $"Display: {Name} ({st.NumericStudentId})",
				Tag = st.NumericStudentId,
			};
		}

		public static IEnumerable<ComboAction> From(MailItem mail)
		{
			if (MessageClassificationExtensions.SenderHasStudentId(mail, out var studentId))
			{
				if (studentId.StartsWith("w"))
					studentId = studentId.Substring(1);
				yield return new ComboAction()
				{
					ActionType = Tp.Search,
					Text = $"Search: {mail.Sender.Name} ({studentId})",
					Tag = studentId,
				};

				yield return new ComboAction()
				{
					ActionType = Tp.ShowImage,
					Text = $"Display: {mail.Sender.Name} ({studentId})",
					Tag = studentId,
				};
			}
		}

		public enum Tp
		{
			Search,
			ShowImage,
			MoveToFolder
		}

		public string Text { get; set; }
		public Tp ActionType { get; set; }
		public object Tag { get; set; }

		public override string ToString()
		{
			return Text;
		}

		internal static ComboAction CreateMoveToFolder(Folder folder)
		{
			ComboAction ret = new ComboAction
			{
				Text = folder.Name,
				ActionType = ComboAction.Tp.MoveToFolder,
				Tag = folder
			};
			return ret;
		}
	}
}
