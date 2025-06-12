using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnnItBooster.StudentMarking
{
	class RepetitionAnalyzer
	{
		internal static void Report(List<string> items, StringBuilder sb)
		{
			sb.AppendLine("Report clustering: ");
			sb.AppendLine();

			// Dictionary to store the indices of each string
			Dictionary<string, List<int>> positions = new Dictionary<string, List<int>>();

			// Step 1: Collect indices for each unique string
			for (int i = 0; i < items.Count; i++)
			{
				string item = items[i];
				if (!positions.ContainsKey(item))
					positions[item] = new List<int>();
				positions[item].Add(i);
			}

			// Step 2: Analyze clustering
			foreach (var entry in positions)
			{
				var item = entry.Key;
				var indices = entry.Value;

				if (indices.Count > 1)
				{
					var gaps = new List<int>();
					for (int i = 0; i < indices.Count - 1; i++)
					{
						gaps.Add(indices[i + 1] - indices[i]);
					}

					var averageGap = gaps.Average();

					sb.AppendLine($"Item '{item}' has average gap of {averageGap} [{string.Join(", ", indices)}]");
				}
			}
		}
	}
}