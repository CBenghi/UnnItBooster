using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnItBooster.Models;

namespace UnnFunctions.Models
{
	public class ModerationCollection
	{
		private List<ModerationEntry> entries { get; set; } = new();

		public void Add(ModerationEntry t)
		{
			entries.Add(t);
		}

		public string Report()
		{
			var validMarks = entries.Where(x => x.Totmark > 0).Count();
			StringBuilder sb = new StringBuilder();	
			var req = Math.Ceiling(Math.Sqrt(entries.Count));
			req = Math.Max(req, 6);
			req = Math.Min(req, validMarks);
			var each = (validMarks-1) / (req - 1);
			
			sb.AppendLine($"Total submissions: {entries.Count}, Sample size: {req}, Submissions with a mark: {validMarks}.");
			// sb.AppendLine($"Selecting one in {each} submissions."); 
			sb.AppendLine();

			sb.AppendLine("InternalId\tUserId\tFirstName\tLastName\tPaperId\tMark\tSelected\tSelected Id");
			int progInt = 0;
			double progDbl = 0;
			int nextHit = 0;
			foreach (var entry in entries.OrderBy(x=>x.Totmark))
			{
				var selected = "";
				if (entry.Totmark > 0)
				{
					if (progInt++ == nextHit)
					{
						selected = "yes";
						progDbl += each;
						try
						{
							nextHit = Convert.ToInt32(Math.Round(progDbl)); // when just one it crashes cause infintiy
						}
						catch (Exception)
						{

						}
						
					}
				}
				var selectedId = (selected == "yes") ? entry.Sub.InternalShortId.ToString() : "";
				sb.AppendLine($"{entry.Sub.InternalShortId}\t{entry.Sub.NumericUserId}\t{entry.Sub.FirstName}\t{entry.Sub.LastName}\t{entry.Sub.PaperId}\t{entry.Totmark}%\t{selected}\t{selectedId}");
			}
			return sb.ToString();
		}
	}
	public class ModerationEntry
	{
		public ModerationEntry(TurnitInSubmission sub, int totmark)
		{
			Sub = sub;
			Totmark = totmark;
		}

		public TurnitInSubmission Sub { get; }
		public int Totmark { get; }
	}
}
