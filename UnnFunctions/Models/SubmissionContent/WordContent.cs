using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnnFunctions.Models.SubmissionContent
{
	internal class WordContent : IContentProvider
	{
		public WordContent(FileInfo f) 
		{
			file = f;
		}

		FileInfo file;

		public bool Exists => file.Exists && file.Extension.Equals(".docx", StringComparison.OrdinalIgnoreCase);

		public IEnumerable<string> GetParagraphs()
		{
			try
			{
				using var fileStream = File.OpenRead(file.FullName);
				using var doc = new XWPFDocument(fileStream);
				return GetComponentsText(doc).ToList();				
			}
			catch (Exception ex)
			{
				return [$"Error: {ex.Message}"];
			}
		}

		private static IEnumerable<string> GetComponentsText(XWPFDocument doc)
		{
			Dictionary<string, HitStat> ignoredTypes = [];
			var result = new List<string>();
			foreach (var bodyElement in doc.BodyElements)
			{
				if (bodyElement is XWPFParagraph paragraph)
				{
					result.Add(paragraph.Text);
					continue;
				}
				if (bodyElement is XWPFSDT unknown)
				{
					var cont = unknown.Content.Text;
					var lines = cont.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
					foreach (var line in lines)
					{
						result.Add(line);
					}
					continue;
				}
				// what types are not managed by the code
				if (bodyElement is not XWPFTable table)
				{
					var tb = bodyElement.GetType();
					var typeName = tb.FullName;
					if (ignoredTypes.TryGetValue(typeName, out var found))
						found.HitCount++;
					else
						ignoredTypes.Add(typeName, new HitStat(1));
					continue;
				}

				foreach (var row in table.Rows)
				{
					var tableLine = new StringBuilder();
					foreach (var cell in row.GetTableCells())
					{
						foreach (var cellParagraph in cell.Paragraphs)
						{
							tableLine.Append(cellParagraph.Text);
							tableLine.Append("| ");
						}
					}
					result.Add(tableLine.ToString());
				}
			}
			foreach (var ignoredType in ignoredTypes)
			{
				result.Add($"Ignored {ignoredType.Value.HitCount}: {ignoredType.Key}");
			}
			return result;
		}

		private class HitStat
		{
			public HitStat(int initialHitCount)
			{
				HitCount = initialHitCount;
			}

			public int HitCount { get; set; } = 0;
		}

	}
}