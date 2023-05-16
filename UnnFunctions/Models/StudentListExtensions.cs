using System.Collections.Generic;
using System.Linq;

namespace UnnItBooster.Models;
public static class StudentListExtensions
{
	/// <summary>
	/// Merge information by student id
	/// </summary>
	public static IEnumerable<Student> MergeInformation(this IEnumerable<Student> baseCollection, IEnumerable<Student> otherCollection)
	{
		var noChange = baseCollection.Where(x => x.NumericStudentId == string.Empty);
		var Enrich = baseCollection.Where(x => x.NumericStudentId != string.Empty).ToDictionary(x => x.NumericStudentId, x => x);
		var extra = new List<Student>();
		foreach (var source in otherCollection)
		{
			if (source.NumericStudentId == string.Empty || !Enrich.TryGetValue(source.NumericStudentId, out var dest))
			{
				// if cant search or cant find
				extra.Add(source);
				continue;
			}
			if (!string.IsNullOrEmpty(source.Email) && dest.Email != source.Email)
				dest.Email = source.Email;
			if (!string.IsNullOrEmpty(source.Surname) && dest.Surname != source.Surname)
				dest.Surname = source.Surname;
			if (!string.IsNullOrEmpty(source.Forename) && dest.Forename != source.Forename)
				dest.Forename = source.Forename;
		}
		return Enrich.Values.Union(noChange).Union(extra);
	}
}
