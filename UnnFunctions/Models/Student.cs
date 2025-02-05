using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnnFunctions.Models;

namespace UnnItBooster.Models
{
	public static class StringExtensions
	{
		public static bool Matches(this string source, string toCheck)
		{
			return source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}
	
	[DebuggerDisplay("{FullName} {NumericStudentId} {Email}")]
	public class Student
	{
		public string? FullName { get; set; }
		private string? surname;
		public string? Surname
		{
			get => surname;
			set
			{
				if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(FullName))
				{
					if (FullName!.EndsWith(value, StringComparison.OrdinalIgnoreCase))
					{
						var index = FullName.IndexOf(value, StringComparison.OrdinalIgnoreCase);
						var fn = FullName.Substring(0, index).Trim();
						if (!string.IsNullOrEmpty(fn) && string.IsNullOrEmpty(forename))
							forename = fn;
					}
				}
				else if (!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(FullName))
				{
					FullName = value;
				}
				surname = value;
			}
		}
		public string? Forename
		{
			get => forename;
			set
			{
				forename = value;
			}
		}
		public string? Route { get; set; }

		private string numericStudentId = string.Empty;
		private string? forename;

		/// <summary>
		/// Best attempt at presenting the student ID with 8 numeric digits only.
		/// </summary>
		public string NumericStudentId
		{
			get => numericStudentId;
			set
			{
				if (value.StartsWith("w") || value.StartsWith("W"))
				{
					numericStudentId = value.Substring(1);
					return;
				}

				if (value.Contains("/"))
				{
					numericStudentId = value.Substring(0, value.IndexOf('/'));
					return;
				}
				numericStudentId = value;
			}
		}
		public string? CourseYear { get; set; } = string.Empty;
		public string? Occurrence { get; set; } = string.Empty;
		public string? Module { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string? EmailByStudentID =>  string.IsNullOrWhiteSpace(NumericStudentId) ? null : $"w{NumericStudentId}@northumbria.ac.uk";

		public List<string>? AlternativeEmails { get; set; } = null;

		public bool AddAlternativeEmail(string newEmail)
		{
			if (string.IsNullOrWhiteSpace(newEmail))
				return false;
			if (AlternativeEmails == null)
			{
				AlternativeEmails = new List<string> { newEmail };
			}
			else
				AlternativeEmails.Add(newEmail);
			return true;
		}

		public void RemoveAlternativeEmail(string email)
		{
			AlternativeEmails?.Remove(email);
			if (AlternativeEmails != null && !AlternativeEmails.Any())
				AlternativeEmails = null;
		}

		public bool DSSR { get; set; } = false;
		public string? Phone { get; internal set; }

		public bool Matches(string filter)
		{
			if (FullName is not null && FullName.Matches(filter))
				return true;
			if (Surname != null && Surname.Matches(filter))
				return true;
			if (Forename != null && Forename.Matches(filter))
				return true;
			if (NumericStudentId != null && NumericStudentId.Matches(filter))
				return true;
			if (Phone != null && Phone.Matches(filter))
				return true;
			if (Email != null && Email.Matches(filter))
				return true;
			if (AlternativeEmails is not null && AlternativeEmails.Any(x=>x.Matches(filter)))
				return true;
			return false;
		}

		public string PictureName(string pictureFolder)
		{
			return Path.Combine(pictureFolder, string.Format("{0}.jpg", NumericStudentId));
		}

		public List<ModuleResult>? TranscriptResults { get; set; }

		public bool HasEmail(string seekEmail)
		{
			if (Email is not null && Email.ToLowerInvariant() == seekEmail.ToLowerInvariant())
				return true;
			if (EmailByStudentID is not null && EmailByStudentID.ToLowerInvariant() == seekEmail.ToLowerInvariant())
				return true;
			if (AlternativeEmails == null)
				return false;
			return AlternativeEmails.Any(x => x.ToLowerInvariant() == seekEmail.ToLowerInvariant());
		}

		internal void SetModuleMark(ModuleResult res)
		{
			if (TranscriptResults == null)
				TranscriptResults = new List<ModuleResult>();
			TranscriptResults.RemoveAll(x => x.Code == res.Code);
			TranscriptResults.Add(res);
		}

		public string GetFullName()
		{
			if (!string.IsNullOrEmpty(Forename) || !string.IsNullOrEmpty(Surname))
				return $"{Forename} {Surname}";
			else if (FullName is null)
				return "";
			return FullName;
		}

		public string ReportTranscript()
		{
			StringBuilder sb = new StringBuilder();
			if (TranscriptResults is not null)
			{
				string yr = "";
				foreach (var transcript in TranscriptResults.OrderBy(x => x.Year))
				{
					if (transcript.Year != yr)
					{
						sb.AppendLine($"");
						yr = transcript.Year;
						sb.AppendLine($"{yr}");
					}
					sb.AppendLine($"{transcript.Year} Lvl:{transcript.Level} {transcript.Code} Mark: {transcript.GetMarkString()} ({transcript.Title} {transcript.Credits} credits with code {transcript.GetCodesString()}).");
				}
				var res = ModuleResult.WeightedAverage(TranscriptResults, out var credits);
				if (res > 0)
				{
					sb.AppendLine($"\r\nWeighed average {res:0.0}% over {credits} credits\r\n");
				}
				sb.AppendLine("Legenda:");
				foreach (var code in UsedCodes().Distinct())
				{
					ModuleResult.Report(sb, code);
				}
			}
			else
			{
				sb.AppendLine("Empty transcript");
			}
			return sb.ToString();
		}

		public IEnumerable<string> UsedCodes()
		{
			if (TranscriptResults != null)
			{
				foreach (var tr in TranscriptResults)
				{
					yield return tr.ActualResult;
					yield return tr.AgreedResult;
					yield return tr.Result;
				}
			}
		}
	}
}