using LumenWorks.Framework.IO.Csv;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions
{
	public class Elp
	{
		public static IEnumerable<Student>? GetStudentsFromAnalyticsContent(string text)
		{
			using TextReader sr = new StringReader(text);
			return GetStudents(sr);
		}

		public static IEnumerable<Student> GetStudentsFromAnalyticsFile(string filefullName)
		{
			// open the file "data.csv" which is a CSV file with headers
			var t = new StreamReader(filefullName);
			return GetStudents(t);
		}

		private static IEnumerable<Student> GetStudents(TextReader t)
		{
			var students = new List<Student>();
			using (var csv = new CachedCsvReader(t, true))
			{
				// Field headers will automatically be used as column names
				var iLast = csv.GetFieldIndex("Surname");
				var iFirst = csv.GetFieldIndex("First Name");
				var idWithW = csv.GetFieldIndex("Username");

				if (iLast == -1
					|| iFirst == -1
					|| idWithW == -1
					)
					return Enumerable.Empty<Student>();

				foreach (var row in csv)
				{
					var student = new Student
					{
						Surname = row[iLast],
						Forename = row[iFirst],
						NumericStudentId = row[idWithW]
					};
					if (!student.NumericStudentId.StartsWith("sgmk2"))
						students.Add(student);
				}
			}
			return students;
		}
	}
}