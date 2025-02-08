using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UnnFunctions.Models
{
	[DebuggerDisplay("{Code} Credits:{Credits} {ActualMark} {AgreedMark}")]
	public class ModuleResult
	{
		public string Title { get; set; } = "";
		public string Code { get; set; } = "";
		public string Year { get; set; } = "";
		public string Extra { get; set; } = "";
		public string Level { get; set; } = "";
		public string Credits { get; set; } = "";
		public string ActualResult { get; set; } = "";
		public string ActualMark { get; set; } = "";
		public string AgreedResult { get; set; } = "";
		public string AgreedMark { get; set; } = "";
		public string Result { get; set; } = "";

		/// <summary>
		/// This prioritises the agreed mark over the actual mark
		/// </summary>
		/// <returns></returns>
		public string GetMarkString()
		{
			// prioritising agreed result
			if (!string.IsNullOrEmpty(AgreedMark))
				return AgreedMark;
			return ActualMark;
		}

		public bool TryGetMark(out int mark, out int credits)
		{
			credits = 0;
			if (!string.IsNullOrEmpty(Credits))
			{
				int.TryParse(Credits, out credits);
			}
			var t = GetMarkString();
			if (string.IsNullOrEmpty(t))
			{
				mark = -1;
				return false;
			}
			return int.TryParse(t, out mark);
		}

		public static double WeightedAverage(IEnumerable<ModuleResult> results, out int MaturedCredits)
		{
			var Tally = 0.0;
			MaturedCredits = 0;
			foreach (var result in results)
			{
				if (result.TryGetMark(out var mk, out var cred) && cred > 0)
				{
					Tally += mk * cred;
					MaturedCredits += cred;
				}
			}
			if (MaturedCredits > 0)
			{
				return Tally/MaturedCredits;
			}
			return 0;
		}

		public static bool TryGetResultDescription(string code, out string shortDesc, out string longDesc)
		{
			switch (code)
			{
				case "AM":
					shortDesc = "Academic Misconduct";
					longDesc = "Academic Misconduct proven or under investigation";
					return true;
				case "C":
					shortDesc = "Compensated";
					longDesc = "PAB has agreed that module can be compensated (ARTA 2.5, 3.6). Agreed module grade is overwritten by C and a mark of 40 (UG) or 50 (PG) is assigned to the module";
					return true;
				case "D":
					shortDesc = "Deferral?";
					longDesc = "This has a different definition in the document, but I think it should be read as deferral.";
					return true;
				case "F":
					shortDesc = "Fail";
					longDesc = "Automatically calculated when referral attempt has been failed or entered manually following the PAB where the module has been failed and there is no referral opportunity in the current stage (e.g. where the progression average requirements have not been met). The student may be permitted to re-register on the failed module in the next academic year.";
					return true;
				case "P":
					shortDesc = "Pass";
					longDesc = "Default code / grade for pass";
					return true;
				case "R":
					shortDesc = "Refer";
					longDesc = "Default code/grade for failed component/module";
					return true;
				case "RP":
					shortDesc = "Repeated module";
					longDesc = "Entered where a module has been repeated and is duplicated on the PAB Report. Overwriting the modulegrade by RP closes off the unwanted record and ensures that that particular module offering does not appear on the PAB Report and does not contribute to the level average calculation. RP is excluded from the statistical reports associated with the module/PAB as there is no direct correlationwith module pass or fail.";
					return true;
				case "TM":
					shortDesc = "Academic Misconduct";
					longDesc = "Academic Misconduct - students at Level 5 and above where Module Learning Outcomes have not been met,even if the module (mark) has been passed overall";
					return true;
				case "TP":
					shortDesc = "Academic Misconduct";
					longDesc = "Entered manually (overwriting the module and component grade of AM) when determined that modulelearning outcomes have been met and module passed. P is reported on SMRF/Transcript.";
					return true;
				case "WF":
					shortDesc = "Withdrawn – module failed";
					longDesc = "Module has been failed – no credit awarded. Outcome where 0WD has been entered for at least one assessment component.";
					return true;
				case "XP":
					shortDesc = "PEC and pass";
					longDesc = "Module has been passed although there are approved extenuating circumstances. PAB may apply discretion and decide to award MP with mark taken out of level average calculation or XP can stay on record to inform decision of subsequent PAB";
					return true;
				case "XR":
					shortDesc = "PEC and first sit";
					longDesc = "Calculated outcome for module with failed mark and PEC. This allows for another first sit attempt.";
					return true;
				case "ZP":
					shortDesc = "Covid/cyber Pass";
					longDesc = "Grade entered against a module mark. This will automatically populate the Actual and the Agreed Grade fields if there is a CD against a component however the student has passed the module overall. The SMR Grade field can also be overwritten with ZP if required, for example if the system automatically generates a P grade but it needs to be recorded that the student has had a CD code against one or more components.";
					return true;
				case "ZR":
					shortDesc = "Academic Misconduct";
					longDesc = "Module Defer/Refer (Covid/Cyber Incident TEC)";
					return true;
				default:
					shortDesc = "";
					longDesc = "";
					return false;
			}
		}

		public static void Report(StringBuilder sb, string code)
		{
			if (TryGetResultDescription(code, out string shortDesc, out string longDesc))
			{
				sb.AppendLine($"{code}: {shortDesc}\r\n{longDesc}\r\n");
			}
			else
			{
				sb.AppendLine($"MISSING CODE description for: {code}\r\n");
			}
		}

		internal string GetCodesString()
		{
			var codes = new List<string>() {
				ActualResult,
				AgreedResult,
				Result
			}.Distinct().ToArray();
			return string.Join(" / ", codes);
		}

		public static string Describe(IEnumerable<int> delegateMarks)
		{
			DescriptiveStatistics series = new DescriptiveStatistics(delegateMarks.Select(x => (double)x));
			return $"Mean: {series.Mean}, Minimum: {series.Minimum}, Maximum: {series.Maximum}, StDev: {series.StandardDeviation:0.##}, Range: {series.Maximum - series.Minimum}";
		}
	}
}
