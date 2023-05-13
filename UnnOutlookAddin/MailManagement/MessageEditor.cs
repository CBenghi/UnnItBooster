using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace UnnOutlookAddin.MailManagement
{
	public class MessageEditor
	{

		Outlook.Explorer _explorer;

		public MessageEditor(Outlook.Explorer explorer)
		{
			_explorer = explorer;
		}

		public void SetCategory(Outlook.MailItem mailItem, string Category)
		{
			mailItem.Categories = Category;
			mailItem.Save();
		}

		private void EnumerateCategories()
		{
			Outlook.Categories categories = _explorer.Application.Session.Categories;
			foreach (Outlook.Category category in categories)
			{
				Debug.WriteLine(category.Name);
				Debug.WriteLine(category.CategoryID);
			}
		}

		private void AddACategory()
		{
			Outlook.Categories categories = _explorer.Application.Session.Categories;
			if (!CategoryExists("ISV"))
			{
				Outlook.Category category = categories.Add("ISV", Outlook.OlCategoryColor.olCategoryColorDarkBlue, Outlook.OlCategoryShortcutKey.olCategoryShortcutKeyCtrlF11);
			}
		}

		private bool CategoryExists(string categoryName)
		{
			try
			{
				Outlook.Category category = _explorer.Application.Session.Categories[categoryName];
				if (category != null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch { return false; }
		}


		public void MoveMessage(IEnumerable<Outlook.MailItem> items, string destFolderName)
		{
			Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)_explorer.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
			if (inBox == null)
				return;

			Outlook.MAPIFolder destFolder = inBox.Folders[destFolderName];
			if (destFolder == null)
				return;

			foreach (var eMail in items)
			{
				try
				{
					if (eMail == null)
					{
						continue;
					}
					eMail.Move(destFolder);
				}
				catch (Exception)
				{

				}
			}
		}
	}
}