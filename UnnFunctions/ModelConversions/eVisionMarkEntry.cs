using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnnFunctions.ModelConversions
{
	public class eVisionMarkEntry
	{
		public class MarkFields
		{
			public MarkFields(string rowId, string userId)
			{
				StudentId = userId;
				MarkTextId = $"msa_mrk_widget_MRK.1-{rowId}-1";
				GradeTextId = $"msa_mrk_widget_GRD.1-{rowId}-1";
			}

			public string StudentId { get; set; } 
			public string MarkTextId { get; set; }
			public string GradeTextId { get; set; }
		}

		public static IEnumerable<MarkFields> GetEntries(string htmlSource)
		{
			// because agilitypack has a problem we use pure regex
			// there's content that looks like:


			// <span id="msa_mrk_widget_ROW1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>21013004/1</td>
			// later on 
			// <input type="text" name="msa_mrk_widget_MRK.1-1-1" id="msa_mrk_widget_MRK.1-1-1" value=""
			// and
			// 	<input type="text" name="msa_mrk_widget_GRD.1-1-1" id="msa_mrk_widget_GRD.1-1-1" value=""
			// and the number of the row is always the number in between the id 1-THIS-1

			Regex r = new Regex("msa_mrk_widget_ROW(?<RowId>\\d+)\".+?(?<userId>\\d{8})/\\d");
			foreach (Match match in r.Matches(htmlSource))
			{
				yield return new MarkFields(
					match.Groups["RowId"].Value,
					match.Groups["userId"].Value
					);
			}
		}

		/// <summary>
		/// returns a dictionary where key is student and value is mark (both strings)
		/// </summary>
		public static Dictionary<string, string> FromTabSeparated(string mcrfMarks)
		{
			var ret = new Dictionary<string, string>();
			var lines = mcrfMarks.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var line in lines) {
				var arr = line.Split(new[] { '\t', ' ' });
				if (arr.Length != 2)
					continue;
				var stud = arr[0].Trim();
				var mark = arr[1].Trim();
				if (ret.ContainsKey(stud)) 
					continue;
				ret.Add(stud, mark);
			}
			return ret;
		}
	}
}
