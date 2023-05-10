using StudentsFetcher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
    class StudentResolver
    {
        readonly WebClient _webClient = new WebClient { UseDefaultCredentials = true };

        StudentsRepository _stud;

        public StudentResolver()
        {
            _stud = new StudentsRepository(Settings.Default.StudentsFolder);
		}

        internal Student ResolveById(string letterStartingId)
        {
            Student std = null;
            var numericOnlyId = Unn.Students.StudentId.NumericFromString(letterStartingId);
            if (std == null)
                std = _stud.GetStudentById(numericOnlyId);
            if (std == null && !string.IsNullOrEmpty(numericOnlyId))
                std = GetStudentByIdViaWheel(numericOnlyId);

            return std;
        }

        private Student GetStudentByIdViaWheel(string numericId)
        {
            try
            {
                var url = $"http://wheel.northumbria.ac.uk/amfphp/services/unn/getStudentsByIDorNameXML.php?fieldName=studentID&searchString={numericId}";
                var s = _webClient.DownloadString(url);
                var d = XDocument.Parse(s);
                var stds = GetStudents(d, "");
                var std = stds.FirstOrDefault();
                return std;
            }
            catch (Exception)
            {
                return null;
            }            
        }


        /// <summary>
        /// provide fullname with first names first
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="verifyId"></param>
        /// <returns></returns>
        internal Student ResolveByName(string fullName, string backgroundeDesc, string verifyId = "")
        {
            var arr = fullName.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var startingItem = arr.Length;

            while (startingItem > 1)
            {
                var howManyItems = arr.Length - startingItem + 1;
                var tarr = new string[howManyItems];
                Array.Copy(arr, arr.Length - howManyItems, tarr, 0, howManyItems);
                var lastName = string.Join(" ", tarr);

                var url = "http://wheel.northumbria.ac.uk/amfphp/services/unn/" +
                          $"getStudentsByIDorNameXML.php?fieldName=studentname&searchString={lastName}" +
                          "&contains=true" +
                          "";
                var s = _webClient.DownloadString(url);
                var d = XDocument.Parse(s);
                var stud = GetStudents(d, backgroundeDesc);

                if (!string.IsNullOrEmpty(verifyId))
                {
                    foreach (var student in stud)
                    {
                        if (student.NumericStudentId == verifyId)
                            return student;
                    }
                }
                if (stud.Count == 1)
                    return stud.FirstOrDefault();
                startingItem--;
            }
            return null;
        }

        // ReSharper disable once InconsistentNaming
        private const string MISSINGFIELD = "<Missing>";

        private static string GetField(XContainer el, string fieldName)
        {
            var fld = el.Element(fieldName);
            return fld?.Value ?? MISSINGFIELD;
        }

        internal static List<Student> GetStudents(FileInfo xmlFile)
        {
            var modName = xmlFile.Name.Replace(".stud.xml", "");
            if (!xmlFile.Exists)
                return null;
            
            var doc = XDocument.Load(xmlFile.FullName);

            return GetStudents(doc, modName);
        }

        private static List<Student> GetStudents(XDocument doc, string modName)
        {
            var rows = doc.Descendants("student").Select(el => new Student
            {
                Surname = GetField(el, "surname"),
                Forename = GetField(el, "forename"),
                Route = GetField(el, "routeCode"),
                NumericStudentId = GetField(el, "studentid"),
                CourseYear = GetField(el, "courseyear"),
                Email = GetField(el, "email"),
                

            }).ToList();

            //foreach (var item in rows)
            //{
            //    frmAutomaticMarkingMachine.GetImage(folder, item.Studentid);
            //}
            return rows;
        }

        private static DateTime GetDate(XElement el, string fieldName)
        {
            var dateString = GetField(el, fieldName);
            DateTime d;
            return DateTime.TryParse(dateString, out d) ? d : DateTime.MinValue;
        }
    }
}
