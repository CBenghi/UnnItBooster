using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnItBooster.Models;

namespace UnnFunctions.ModelConversions
{
	public static class StringStudentCollection
	{
		private const string Header = "NumericStudentId\tForename\tSurname\tRoute\tEmail";

		public static string PersistString(IEnumerable<Student> distinctStudents)
		{
			if (!distinctStudents.Any()) 
				return string.Empty;
			var sb = new StringBuilder();
			sb.AppendLine(Header);
			foreach (var st in distinctStudents)
			{
				sb.AppendLine($"{st.NumericStudentId}\t{st.Forename}\t{st.Surname}\t{st.Route}\t{st.Email}");
			}
			return sb.ToString();
		}

		public static IEnumerable<Student> UnpersistString(string persisted)
		{
			if (string.IsNullOrWhiteSpace(persisted))
				yield break;
			if (!persisted.StartsWith(Header))
				yield break;
			var cleanLines = new[] { '\n', '\r' };
			var split = persisted.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var cnt = Header.Split('\t').Length;
			foreach (var line in split)
			{
				if (line is null)
					continue;
				if (line.StartsWith(Header))
					continue;
				var proc = line.Trim(cleanLines);
				var pars = proc.Split('\t');
				if (pars.Length != cnt)
					continue;

				Student student = new Student
				{
					NumericStudentId = pars[0],
					Forename = pars[1],
					Surname = pars[2],
					Route = pars[3],
					Email = pars[4],
				};
				yield return student;
			}
		}

	}
}
