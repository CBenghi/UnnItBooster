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
    }
}
