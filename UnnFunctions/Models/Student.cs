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
		public string OutlookAddress { get; set; } = string.Empty;
		public string? EmailByStudentID => string.IsNullOrWhiteSpace(NumericStudentId) ? null : $"w{NumericStudentId}@northumbria.ac.uk";

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
			if (AlternativeEmails is not null && AlternativeEmails.Any(x => x.Matches(filter)))
				return true;
			return false;
		}

		public string PictureName(string pictureFolder)
		{
			return Path.Combine(pictureFolder, string.Format("{0}.jpg", NumericStudentId));
		}

		public List<ModuleResult> TranscriptResults { get; set; } = new();


		public IEnumerable<string> AllEmails()
		{
			if (!string.IsNullOrEmpty(Email))
				yield return Email!;
			if (!string.IsNullOrEmpty(EmailByStudentID))
				yield return EmailByStudentID!;
			if (AlternativeEmails is null)
				yield break;
			foreach (var alt in AlternativeEmails)
			{
				if (!string.IsNullOrEmpty(alt))
					yield return alt!;
			}
		}

		public bool HasEmail(string? seekEmail)
		{
			if (seekEmail is null)
				return false;
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

		public static string ReportTranscriptClassificationChart(IEnumerable<ModuleResult>? transcript)
		{
			if (transcript is null || !transcript.Any())
				return string.Empty;
			var sb = new StringBuilder();
			if (transcript is not null)
			{
				foreach (var levelMarks in transcript.GroupBy(x => x.Level))
				{
					sb.AppendLine($"Chart at level: {levelMarks.Key}");
					AppendChart(sb, levelMarks);
				}
			}
			sb.AppendLine();
			return sb.ToString();
		}

		private static void AppendChart(StringBuilder sb, IEnumerable<ModuleResult> enumerable)
		{
			var c = new chart();
			foreach (var item in enumerable)
			{
				c.Add(item);
			}
			c.ReportTo(sb);
		}

		class chart
		{
			internal int[] MarksAtBand = new int[10];

			internal List<string> failures = new();

			internal void Add(ModuleResult item)
			{
				if (!item.TryGetMark(out var mk, out var credits))
				{
					return;
				}
				if (credits == 0)
				{
					failures.Add(item.ActualMark);
				}
				var mkBand = Convert.ToInt32(Math.Floor((double)mk / 10));
				MarksAtBand[mkBand] += credits;
			}

			internal void ReportTo(StringBuilder sb)
			{
				int minRange = 10;
				int maxRange = 0;
				for (int i = 9; i >= 0; i--)
				{
					if (MarksAtBand[i] > 0)
					{
						minRange = Math.Min(i, minRange);
						maxRange = Math.Max(i, maxRange);
					}
				}
				for (int i = maxRange; i >= minRange; i--)
				{
					sb.AppendLine($"{Desc(i)}\t{Bar(MarksAtBand[i])}\t{MarksAtBand[i]}");
				}
				if (failures.Any())
					sb.AppendLine($"Fails: {string.Join(", ", failures.ToArray())}");
			}

			private string Bar(int credits)
			{
				var mx = MarksAtBand.Max() / 10;
				var count = credits / 10;

				return new string('#', count)
					+ new string('_', mx - count);
			}

			private string Desc(int i)
			{
				return (i * 10).ToString("##");
			}
		}

		public string ReportTranscript(bool addLegenda = true)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"ID: {NumericStudentId} - {Forename} {Surname?.ToUpper()} - {FullName}");
			if (TranscriptResults is not null)
			{
				string yr = "";
				foreach (var transcript in TranscriptResults.OrderBy(x => x.Year))
				{
					if (transcript.Year != yr)
					{
						if (yr != "")
							sb.AppendLine($"");
						yr = transcript.Year;
						sb.AppendLine($"{yr}");
					}
					if (!addLegenda)
						sb.AppendLine($"{transcript.Year} Lvl:{transcript.Level} {transcript.Code} Mark: {transcript.GetMarkString()} ({transcript.Credits} credits {transcript.Title} with {transcript.GetResultCodesShortDescription()}).");
					else
						sb.AppendLine($"{transcript.Year} Lvl:{transcript.Level} {transcript.Code} Mark: {transcript.GetMarkString()} ({transcript.Credits} credits {transcript.Title} with code {transcript.GetResultCodesString()}).");
				}
				var res = ModuleResult.WeightedAverage(TranscriptResults, out var credits, out _, out var compensatedCode);
				if (res > 0)
				{
					var cmp = compensatedCode == string.Empty ? "" : $" compensated on {compensatedCode}";
					sb.AppendLine($"\r\nWeighted average {res:0.0}% over {credits} credits{cmp}\r\n");
				}
				if (addLegenda)
				{
					sb.AppendLine("Legenda:");
					foreach (var code in UsedCodes().Distinct())
					{
						ModuleResult.Report(sb, code);
					}
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

		public IEnumerable<string> OutlookSenders()
		{
			if (!string.IsNullOrEmpty(OutlookAddress))
				yield return OutlookAddress;
			if (AlternativeEmails is not null)
			{
				foreach (var altEm in AlternativeEmails)
				{
					yield return altEm;
				}
			}
		}
	}
}