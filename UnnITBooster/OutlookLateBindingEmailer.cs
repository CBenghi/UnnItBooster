using System;
using System.Reflection;

namespace LateBindingTest
{
	internal class OutlookLateBindingEmailer
	{
		private readonly object? oApp;

		public OutlookLateBindingEmailer()
		{
			Type outlook_app_type;
			//Get the excel object
			outlook_app_type = Type.GetTypeFromProgID("Outlook.Application");
			if (outlook_app_type == null)
				return;
			oApp = Activator.CreateInstance(outlook_app_type);
			if (oApp is null)
				return;

			object[] parameter = new object[] { "MAPI" };
			var oNameSpace = outlook_app_type.InvokeMember("GetNamespace", BindingFlags.InvokeMethod, null, oApp, parameter);

			var Logon_parameter = new object?[4] { null, null, true, true };
			oNameSpace.GetType().InvokeMember("Logon", BindingFlags.InvokeMethod, null, oNameSpace, Logon_parameter);

			var GetDefaultFolder_parameter = new object[] { 6 };
			_ = oNameSpace.GetType().InvokeMember("GetDefaultFolder", BindingFlags.InvokeMethod, null, oNameSpace, GetDefaultFolder_parameter);
		}

		public void SendOutlookEmail(string toValue, string subjectValue, string bodyValue, string cc = "")
		{
			if (oApp is null)
				return;
			var CreateItem_parameter = new object[1] { 0 };
			object oMailItem = oApp.GetType()
				.InvokeMember("CreateItem", BindingFlags.InvokeMethod, null, oApp, CreateItem_parameter);

			var mail_item_type = oMailItem.GetType();
			mail_item_type.InvokeMember("To", BindingFlags.SetProperty, null, oMailItem, new object[] { toValue });
			mail_item_type.InvokeMember("Subject", BindingFlags.SetProperty, null, oMailItem,
				new object[] { subjectValue });
			mail_item_type.InvokeMember("Body", BindingFlags.SetProperty, null, oMailItem, new object[] { bodyValue });
			mail_item_type.InvokeMember("Send", BindingFlags.InvokeMethod, null, oMailItem, null);
			//if (!string.IsNullOrEmpty(cc))
			//{
			//    mail_item_type.InvokeMember("CC", BindingFlags.SetProperty, null, oMailItem, new object[] { cc });
			//}
		}
	}
}