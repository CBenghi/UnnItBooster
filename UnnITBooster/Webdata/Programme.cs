using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace StudentsFetcher
{
    class Programme
    {
        public List<Marking> Marks { get; set; }

        /// <summary>
        /// Capable of fetching and storing the marks for a student programme.
        /// </summary>
        /// <param name="DetailedCode">The numeric student code without slash</param>
        public Programme(string DetailedCode)
        {
            CodeDetailed = DetailedCode;            
        }
        public string CodeDetailed { get; set; }
        public string StudentName;
        public string ProgrammeMode;
        public string ProgrammeName;

        internal void FetchMarks()
        {
            string IndividualUrl = getMarksUrl();
            if (IndividualUrl == string.Empty)
                return;
            string individualReport = ReportServer.getSqlReport(IndividualUrl);
            if (individualReport == "")
                return;
            try
            {
                string xml = individualReport.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(new StringReader(xml));

                var tab1 = xmlDoc.GetElementsByTagName("table1");
                XmlElement tab1_1 = (XmlElement)tab1[0];
                XmlNodeList detailName = tab1_1.GetElementsByTagName("Detail", "Transcript");
                StudentName = detailName[0].Attributes["stu_surn"].Value;
                ProgrammeMode = detailName[0].Attributes["fca_name"].Value;


                var tab2 = xmlDoc.GetElementsByTagName("table2");
                XmlElement tab2_1 = (XmlElement)tab2[0];
                XmlNodeList detailTab2 = tab2_1.GetElementsByTagName("Detail", "Transcript");
                ProgrammeName = detailTab2[0].Attributes["textbox10"].Value;
                
                var tab3 = xmlDoc.GetElementsByTagName("table3");
                XmlElement tab3_1 = (XmlElement)tab3[0];
                XmlNodeList details = tab3_1.GetElementsByTagName("Detail", "Transcript");
                Marks = new List<Marking>();

                foreach (XmlElement item in details)
                {
                    Marking mk = new Marking();
                    mk.Credits = Convert.ToInt32(item.Attributes["smr_cred"].Value);
                    string[] MarkSplit = item.Attributes["smr_agrm"].Value.Split(new string[] { " " }, StringSplitOptions.None);
                    string mark = MarkSplit[0];
                    try
                    {
                        mk.Mark = Convert.ToInt32(mark);
                        mk.MarkStatus = MarkSplit[1];
                    }
                    catch
                    {
                    }
                    mk.Level = Convert.ToInt32(item.Attributes["smr_levc"].Value);
                    mk.Code = Convert.ToString(item.Attributes["mod_code"].Value);
                    string moduleName = item.Attributes["textbox17"].Value;
                    mk.Title = moduleName;
                    Marks.Add(mk);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           
        }

        private string baseId
        {
            get
            {
                string[] arrId = CodeDetailed.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                if (arrId[0] == string.Empty)
                    return "";
                return arrId[0];
            }
        }

        private string getMarksUrl()
        {
            string reportsource = "http://gloucesterroad/ReportServer?%2fStudent+Data%2fStudent+Programmes+from+ID&rs%3aCommand=Render&rs%3aFormat=XML&StuID=" + baseId;
            string xml = ReportServer.getSqlReport(reportsource);
            if (xml == "")
                return "";
            xml = xml.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(xml));
            var detail = xmlDoc.GetElementsByTagName("Detail");

            if (detail.Count == 0)
                return "";

            var thedetail = detail[0];
            string sYear = thedetail.Attributes["sce_ayrc"].Value; // = m.Groups["Year"].ToString().Replace("/","%2f");
            string sFamily = thedetail.Attributes["sce_crsc"].Value;
            string sRoute = thedetail.Attributes["sce_rouc"].Value;
            string sBlock = thedetail.Attributes["sce_blok"].Value;
            string sOccur = thedetail.Attributes["sce_occl"].Value;
            string sId = thedetail.Attributes["sce_scjc"].Value;

            string school = "50";
            if (sRoute == "ENM6")
                school = "16";

            ReportServer.ReportServerCall rsc = new ReportServer.ReportServerCall("/Progression and Awards/SMRF and Transcript/Transcript");
            rsc.AddParameter("Year", sYear);
            rsc.AddParameter("School", school);
            rsc.AddParameter("Course", sFamily);
            rsc.AddParameter("Route", sRoute);
            rsc.AddParameter("Block", sBlock);
            rsc.AddParameter("Occurrence", sOccur);
            rsc.AddParameter("Student_ID", sId);
            string v = rsc.GetEncodedUrl();

            return v;
        }

        internal string ShortMarksReport()
        {
            StringBuilder sb = new StringBuilder();
            if (Marks == null)
                this.FetchMarks();
            if (Marks == null)
            {
                Debug.WriteLine("Break here");
            }
            foreach (var mk in Marks)
            {
                sb.AppendFormat("Module: {0} {1} Mark: {2} ({3})\r\n", mk.Code, mk.Title, mk.Mark, mk.MarkStatus);
            }
            return sb.ToString();
        }
    }
}
