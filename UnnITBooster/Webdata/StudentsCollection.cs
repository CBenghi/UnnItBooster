using StudentsFetcher.StudentMarking;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudentsFetcher.Webdata
{
	public class StudentsCollection
    {
        public string DataFolder => Properties.Settings.Default.StudentsFolder;

        public IEnumerable<string> GetCollections()
        {
            foreach (var item in ConfigurationFolder.GetDirectories())
            {
                yield return item.Name;
            }
		}

        List<Student> _students = new List<Student>();

        internal IEnumerable<Student> Students
        {
            get
            {
                return _students;
            }
        }

        public StudentsCollection()
        {
            LoadStudents();
        }

        Dictionary<string, string> _routes = new Dictionary<string, string>();

        readonly WebClient _webClient = new WebClient { UseDefaultCredentials = true };

        static internal DirectoryInfo ConfigurationFolder
        {
            get
            {
                var di = new DirectoryInfo(Properties.Settings.Default.StudentsFolder);
                if (!di.Exists)
                {
                    di = new DirectoryInfo(".");
                }
                return di;
            }
        }

        internal Student GetStudentById(string numericStudentId)
        {
            foreach (var item in _students)
            {
                if (item.NumericStudentId == numericStudentId)
                    return item;
            }
            return null;
        }

        private void AddRoutes(FileInfo file)
        {
            if (file == null)
                return;
            var doc = XDocument.Load(file.FullName);
            var rows = doc.Descendants("route");
            foreach (var xElement in rows)
            {
                var rCode = xElement.Element("routeCode").Value;
                if (_routes.ContainsKey(rCode))
                    continue;
                _routes.Add(rCode, xElement.Element("routeTitle").Value);
            }
        }

        static internal string PictureFolder
        {
            get
            {
                return Path.Combine(ConfigurationFolder.FullName, "Pictures");
            }
        }

        internal string GetPrettyRoute(string routeCode)
        {
            if (_routes.ContainsKey(routeCode))
                return _routes[routeCode];
            return routeCode;
        }

        internal IEnumerable<Student> LoadStudents(CheckedListBox list = null)
        {
            _students.Clear();
            _routes.Clear();

            if (list != null)
            {

                foreach (var checkedItem in list.CheckedItems)
                {
                    var stFile = ConfigurationFolder.GetFiles(checkedItem + ".stud.xml").FirstOrDefault();
                    _students.AddRange(StudentResolver.GetStudents(stFile));

                    var sRt = ConfigurationFolder.GetFiles(checkedItem + ".routes.xml").FirstOrDefault();
                    AddRoutes(sRt);
                }
            }
            else
            {
                foreach (var studFile in ConfigurationFolder.GetFiles("*.stud.xml"))
                {
                    _students.AddRange(StudentResolver.GetStudents(studFile));
                }
                foreach (var routeFile in ConfigurationFolder.GetFiles("*.routes.xml"))
                {
                    AddRoutes(routeFile);
                }
            }

            return _students;
        }
    }
}
