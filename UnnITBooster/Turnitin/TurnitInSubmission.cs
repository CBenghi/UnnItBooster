using System;
using System.Net;
using System.Text.RegularExpressions;

namespace StudentsFetcher.Turnitin
{
    class TurnitInSubmission
    {
        public string FirstName = "";
        public string LastName = "";
        public string UserID = "";
        public string TurnitinUserID = "";
        public string Title = "";
        public string PaperID = "";
        public string DateUploaded = "";
        public string Grade = "";
        public string Overlap = "";
        public string InternetOverlap = "";
        public string PublicationsOverlap = "";
        public string StudentPapersOverlap = "";

        public string NumericUserID = "";
        public string Email = "";

        //enum ItemFormat
        //{
        //    OriginalFormat,
        //    Pdf
        //}

        //public string GetUrl(ItemFormat format)
        public string GetUrl(string folder, string SessionId)
        {
            WebClient req = new WebClient();
            string url = "https://submit.ac.uk/paper_download.asp?r=96.8644370479907&svr=6&session-id=" + SessionId + "&lang=en_us&svr=6&oid=" + PaperID + "&fe=pdf&fn=.pdf&session-id=" + SessionId + "&type=paper&p=1";

            string destfilename = UserID + "_" + Title.Replace('/','_')  + ".pdf";
            try 
	        {
                System.IO.FileInfo f = new System.IO.FileInfo(destfilename);
	        }
	        catch (Exception)
	        {
                string originalname = Regex.Match(url, "&fn=([^&]*)").Groups[1].ToString();
                destfilename = UserID;
	        }
            
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);
            destfilename = System.IO.Path.Combine(folder, destfilename);
           
            if (!System.IO.File.Exists(destfilename))
                req.DownloadFile(url, destfilename);

            return "";           
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
                    this.UserID = Value;
                    break;
                case "Turnitin User ID":
                    this.TurnitinUserID = Value;
                    break;
                case "Title":
                    this.Title = Value;
                    break;
                case "Date Uploaded":
                    this.DateUploaded = Value;
                    break;
                case "Paper ID":
                    this.PaperID = Value;
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
