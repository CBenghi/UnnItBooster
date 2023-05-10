using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions
{
	internal class TurnItIn
	{
		internal static IEnumerable<Student> GetStudentsFromGradebook(string csvSource)
		{
			// open the file "data.csv" which is a CSV file with headers
			List<Student> students = new List<Student>();	
			using (var csv = new CachedCsvReader(new StreamReader(csvSource), true))
			{
				// Field headers will automatically be used as column names
				var iLast = csv.GetFieldIndex("Last Name");
				var iFirst = csv.GetFieldIndex("First Name");
				var idWithW = csv.GetFieldIndex("Username");

				if (iLast == -1
					|| iFirst == -1
					|| idWithW == -1
					)
					return Enumerable.Empty<Student>();

				foreach (var row in csv)
				{
					
					Student student = new Student();
					student.Surname = row[iLast];
					student.Forename = row[iFirst];
					student.NumericStudentId = row[idWithW];
					if (!student.NumericStudentId.StartsWith("sgmk2"))
						students.Add(student);
				}

			}
			return students;
		}
	}
}
