using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig;

namespace UnnFunctions.Models.SubmissionContent
{
	internal class PdfContent : IContentProvider
	{
		public PdfContent(FileInfo f)
		{
			file = f;
		}

		FileInfo file;

		public bool Exists => file.Exists && file.Extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase);

		public IEnumerable<string> GetParagraphsSimple()
		{
			using PdfDocument document = PdfDocument.Open(file.FullName);
			foreach (var page in document.GetPages())
			{
				yield return page.Text;
			}
		}	
		
		public IEnumerable<string> GetParagraphs()
		{
			using PdfDocument document = PdfDocument.Open(file.FullName);
			foreach (var page in document.GetPages())
			{
				var lines = page.GetWords()
			   .GroupBy(w => Math.Round(w.BoundingBox.Bottom, 1)) // Group by line Y-position
			   .OrderByDescending(g => g.Key) // Top to bottom
			   .Select(g => string.Join(" ", g.OrderBy(w => w.BoundingBox.Left).Select(w => w.Text)))
			   .ToList();

				var paragraphs = GroupLinesIntoParagraphs(lines);

				foreach (var para in paragraphs)
				{
					yield return para;
				}
			}
		}

		static List<string> GroupLinesIntoParagraphs(List<string> lines)
		{
			var paragraphs = new List<string>();
			var currentPara = "";

			for (int i = 0; i < lines.Count; i++)
			{
				string line = lines[i].Trim();

				if (string.IsNullOrWhiteSpace(line)) continue;

				if (currentPara.Length > 0)
					currentPara += " " + line;
				else
					currentPara = line;

				bool isLastLine = (i == lines.Count - 1);

				// Heuristic: if next line is more than 1 empty line or has a large vertical gap (not detectable here),
				// consider this the end of a paragraph.
				bool isParaEnd = isLastLine || lines[i + 1].StartsWith("  ") || line.EndsWith(".") || line.EndsWith(":");

				if (isParaEnd)
				{
					paragraphs.Add(currentPara.Trim());
					currentPara = "";
				}
			}

			if (currentPara.Length > 0)
				paragraphs.Add(currentPara.Trim());

			return paragraphs;
		}
	}
}