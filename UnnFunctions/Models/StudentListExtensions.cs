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
		try
		{
			var Enrich = baseCollection.Where(x => x.NumericStudentId != string.Empty).ToDictionary(x => x.NumericStudentId, x => x);
			var extra = new List<Student>();
			foreach (var sourceStudent in otherCollection)
			{
				if (sourceStudent.NumericStudentId == string.Empty || !Enrich.TryGetValue(sourceStudent.NumericStudentId, out var destinationStudent))
				{
					// if cant search or cant find
					extra.Add(sourceStudent);
					continue;
				}
				MergeInformation(destinationStudent, sourceStudent);
			}
			return Enrich.Values.Union(noChange).Union(extra);
		}
		catch (System.Exception)
		{
			return baseCollection;
		}		
	}

	public static void MergeInformation(this Student destinationStudent, Student sourceStudent)
	{
		if (!string.IsNullOrEmpty(sourceStudent.FullName) && destinationStudent.FullName != sourceStudent.FullName)
			destinationStudent.FullName = sourceStudent.FullName;
		if (!string.IsNullOrEmpty(sourceStudent.NumericStudentId) && destinationStudent.NumericStudentId != sourceStudent.NumericStudentId)
			destinationStudent.NumericStudentId = sourceStudent.NumericStudentId;
		if (!string.IsNullOrEmpty(sourceStudent.Email) && destinationStudent.Email != sourceStudent.Email)
			destinationStudent.Email = sourceStudent.Email;
		if (!string.IsNullOrEmpty(sourceStudent.Surname) && destinationStudent.Surname != sourceStudent.Surname)
			destinationStudent.Surname = sourceStudent.Surname;
		if (!string.IsNullOrEmpty(sourceStudent.Forename) && destinationStudent.Forename != sourceStudent.Forename)
			destinationStudent.Forename = sourceStudent.Forename;
		if (!string.IsNullOrEmpty(sourceStudent.Phone) && destinationStudent.Phone != sourceStudent.Phone)
			destinationStudent.Phone = sourceStudent.Phone;
		if (sourceStudent.AlternativeEmails is not null)
		{
			foreach (var altEmail in sourceStudent.AlternativeEmails)
			{
				if (destinationStudent.AlternativeEmails is null || !destinationStudent.AlternativeEmails.Contains(altEmail))
					destinationStudent.AddAlternativeEmail(altEmail);
			}
		}
		if (sourceStudent.TranscriptResults is not null)
		{
			foreach (var result in sourceStudent.TranscriptResults)
			{
				destinationStudent.SetModuleMark(result);
			}
		}
	}
}
