using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Windows.Forms;

namespace StudentsFetcher
{
    class ReportServer
    {
        public static string getSqlReport(string url)
        {
            if (url == null)
                return "";
            WebClient req = new WebClient();
            req.Credentials = CredentialCache.DefaultCredentials;
            string retval = "";
            try
            {
                retval = Encoding.UTF8.GetString(req.DownloadData(url));
            }
            catch (System.Net.WebException webexc)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching: " + url);
                // Stream s = webexc.Response.GetResponseStream();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching: " + url);
                Clipboard.SetText(url);
            }
            return retval;
        }


        public class ReportServerCall
        {
            public string ReportPath { get; set; }

            private const string BaseCall = "http://gloucesterroad/ReportServer/Pages/ReportViewer.aspx?";

            public ReportServerCall(string path)
            {
                ReportPath = path;
            }

            private const string BaseParameters = "&rs%3aParameterLanguage=&rc%3aParameters=Collapsed&rs%3aFormat=XML";
            
            internal string GetEncodedUrl()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(BaseCall);
                sb.Append(HttpUtility.UrlEncode(ReportPath));
                sb.Append(BaseParameters);
                foreach (var item in Parameters)
	            {
                    sb.Append("&" + item.ParamName + "=" + HttpUtility.UrlEncode(item.ParamValue));
	            }
                return sb.ToString();
            }

            private class Param
            {
                public string ParamName;
                public string ParamValue;
            }

            private List<Param> Parameters = new List<Param>();

            internal void AddParameter(string name, string sval)
            {
                Param p = new Param();
                p.ParamName = name;
                p.ParamValue = sval;
                Parameters.Add(p);
            }
        }
    }
}
