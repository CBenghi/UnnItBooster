using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Diagnostics;

namespace LateBindingTest
{
    class OutlookEmailerLateBinding
    {
        private object oApp;
        private object oNameSpace;
        private object oOutboxFolder;

        public OutlookEmailerLateBinding()
        {
            Type outlook_app_type;
            object[] parameter = new object[1];
            //Get the excel object
            outlook_app_type = Type.GetTypeFromProgID("Outlook.Application");
            if (outlook_app_type == null)
                return;
            //Create instance of excel
            oApp = Activator.CreateInstance(outlook_app_type);
            //Set the parameter which u want to set
            parameter[0] = "MAPI";
            //Set the Visible property
            oNameSpace = outlook_app_type.InvokeMember("GetNamespace", BindingFlags.InvokeMethod, null, oApp, parameter);

            var Logon_parameter = new object[4] { null, null, true, true };
            oNameSpace.GetType().InvokeMember("Logon", BindingFlags.InvokeMethod, null, oNameSpace, Logon_parameter);

            var GetDefaultFolder_parameter = new object[1] { 6 };
            oOutboxFolder = oNameSpace.GetType().InvokeMember("GetDefaultFolder", BindingFlags.InvokeMethod, null, oNameSpace, GetDefaultFolder_parameter);

            // Console.WriteLine("Press enter to exit");
        }

        public static void Send()
        {
            //Variable
            try
            {
                OutlookEmailerLateBinding app = new OutlookEmailerLateBinding();
                app.SendOutlookEmail("claudio.benghi@gmail.com", "Test 1 2 3", "Test message. Testing.");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Stack {0} ", e.Message);
            }

            Console.ReadLine();
        }

        public void SendOutlookEmail(string toValue, string subjectValue, string bodyValue, string cc = "")
        {
            var CreateItem_parameter = new object[1] { 0 };
            object oMailItem = oApp.GetType().InvokeMember("CreateItem", BindingFlags.InvokeMethod, null, oApp, CreateItem_parameter);

            var mail_item_type = oMailItem.GetType();
            mail_item_type.InvokeMember("To", BindingFlags.SetProperty, null, oMailItem, new object[] { toValue });
            mail_item_type.InvokeMember("Subject", BindingFlags.SetProperty, null, oMailItem, new object[] { subjectValue });
            mail_item_type.InvokeMember("Body", BindingFlags.SetProperty, null, oMailItem, new object[] { bodyValue });
            mail_item_type.InvokeMember("Send", BindingFlags.InvokeMethod, null, oMailItem, null);
            if (!string.IsNullOrEmpty(cc))
            {
                // mail_item_type.InvokeMember("CC", BindingFlags.SetProperty, null, oMailItem, new object[] { cc });
            }
        }
    }
}