using System;
using System.Net;
using System.Text.RegularExpressions;

namespace StudentsFetcher.Turnitin
{
    class TurnitInSubmission
    {
        public string FirstName = "";
        public string LastName = "";
        public string UserId = "";
        public string TurnitinUserId = "";
        public string Title = "";
        public string PaperId = "";
        public string DateUploaded = "";
        public string Grade = "";
        public string Overlap = "";
        public string InternetOverlap = "";
        public string PublicationsOverlap = "";
        public string StudentPapersOverlap = "";

        public string NumericUserId = "";
        public string Email = "";
        
        public TurnitInSubmission()
        { }

        public TurnitInSubmission(string userId, string paperId, string paperTitle)
        {
            UserId = userId;
            PaperId = paperId;
            Title = paperTitle;
        }

        //public string GetUrl(ItemFormat format)
        public bool DownloadDocument(string folder, string sessionId)
        {
            if (!CanDownloadFile())
                return false;
            var req = new WebClient();
            var url = "https://submit.ac.uk/paper_download.asp?r=96.8644370479907&svr=6&session-id=" + sessionId + "&lang=en_us&svr=6&oid=" + PaperId + "&fe=pdf&fn=.pdf&session-id=" + sessionId + "&type=paper&p=1";
            url = "https://www.turnitinuk.com/pdf_download.asp?r=64.9048690964243&svr=07&session-id=" + sessionId + "&lang=en_us&svr=6&oid=" + PaperId + "&fe=pdf&fn=.pdf&session-id=" + sessionId + "&type=paper&p=1";

            // var  a = "https://www.turnitinuk.com/download_file.asp?r=64.9048690964243&svr=07&session-id=f59647dc5a1fc37854166dedbd2865f1&lang=en_us&type=paper&oid=51027190&fn=&session-id=&p=1"; 
            // /pdf_download.asp?r=76.6607112328153&svr=08&session-id=f59647dc5a1fc37854166dedbd2865f1&lang=en_us&svr=08&oid=49460823&fe=pdf&fn=.pdf&session-id=f59647dc5a1fc37854166dedbd2865f1&type=paper'

            var destfilename = UserId + "_" + Title.Replace('/','_')  + ".pdf";
            try 
	        {
                var f = new System.IO.FileInfo(destfilename);
	        }
	        catch (Exception)
	        {
                // var originalname = Regex.Match(url, "&fn=([^&]*)").Groups[1].ToString();
                destfilename = UserId + ".pdf";
	        }
            
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            if (destfilename.Length  + folder.Length > 259)
                destfilename = UserId + ".pdf"; ;
            
            destfilename = System.IO.Path.Combine(folder, destfilename);
           
            if (!System.IO.File.Exists(destfilename))
                req.DownloadFile(url, destfilename);

            return true;           
        }

        internal bool CanDownloadFile()
        {
            if (string.IsNullOrWhiteSpace(UserId))
                return false;
            if (string.IsNullOrWhiteSpace(Title))
                return false;
            if (string.IsNullOrWhiteSpace(PaperId))
                return false;
            return true;
        }

        internal void SetProp(string Value, string PropertyName)
        {
            switch (PropertyName)
            {
                case "Last Name":
                    this.LastName = Value;
                    break;
                case "First Name":
                    this.FirstName = Value;
                    break;
                case "User ID":
                    this.UserId = Value;
                    break;
                case "Turnitin User ID":
                    this.TurnitinUserId = Value;
                    break;
                case "Title":
                    this.Title = Value;
                    break;
                case "Date Uploaded":
                    this.DateUploaded = Value;
                    break;
                case "Paper ID":
                    this.PaperId = Value;
                    break;
                case "Grade":
                    this.Grade = Value;
                    break;
                case "Overlap":
                    this.Overlap = Value;
                    break;
                case "Internet Overlap":
                    this.InternetOverlap = Value;
                    break;
                case "Publications Overlap":
                    this.PublicationsOverlap = Value;
                    break;
                case "Student Papers Overlap":
                    this.StudentPapersOverlap = Value;
                    break;
                default:
                    break;
            }
        }
    }
}
