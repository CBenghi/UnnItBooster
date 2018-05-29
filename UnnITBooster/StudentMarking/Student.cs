using System;
using System.IO;

namespace StudentsFetcher.StudentMarking
{
    class Student
    {
        public string Context;
        public string Surname;
        public string Forename;
        public string RouteCode;
        public string NumericStudentId;
        public string CourseYear;
        public string Email;
        public DateTime CourseStart = DateTime.MinValue;
        public DateTime CourseFinish = DateTime.MinValue;

        public bool Matches(string filter)
        {
            if (Context == filter)
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