using System;
using System.IO;

namespace StudentsFetcher.StudentMarking
{
    class Student
    {
        public string FullName { get; set; }
        public string Surname { get; set; }
		public string Forename { get; set; }
		public string RouteCode { get; set; }
		public string NumericStudentId { get; set; }
		public string CourseYear { get; set; }
		public string Email { get; set; }
		public DateTime CourseStart { get; set; } = DateTime.MinValue;
        public DateTime CourseFinish { get; set; } = DateTime.MinValue;

        public bool Matches(string filter)
        {
            if (FullName == filter)
                return true;
            if (Surname != null && Surname.Contains(filter))
                return true;
            if (Forename != null && Forename.Contains(filter))
                return true;
            if (NumericStudentId != null && NumericStudentId.Contains(filter))
                return true;
            if (Email != null && Email.Contains(filter))
                return true;
            return false;
        }

        public string PictureName(string pictureFolder)
        {
            return Path.Combine(pictureFolder, String.Format("{0}.jpg", NumericStudentId));
        }
    }
}