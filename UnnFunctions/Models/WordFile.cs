using NPOI.OpenXmlFormats;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnnFunctions.Models
{

	public class WordFile
	{
		private FileInfo file;
		public WordFile(FileInfo f)
		{
			file = f;
		}

		public string GetText()
		{
			var sb = new StringBuilder();
			foreach (var par in GetParagraphs())
			{
				sb.AppendLine(par);
			}
			return sb.ToString();
		}

		public IEnumerable<string> GetInlinReferences()
		{
			var parags = GetParagraphs();
			var reflist = GetReferenceList(parags);
			foreach (var item in parags)
			{
				if (reflist.Contains(item)) // we want to exclude elements from the reference list
					continue;
				foreach (var reference in GetReferencesFrom(item))
				{
					yield return reference;
				}
			}
		}

		public IEnumerable<string> GetReferenceList(IEnumerable<string>? paragraphs = null)
		{
			Regex refHeader = new Regex(@"^(?<ParNumber>[\d\.\s]*)Reference[s]?$", RegexOptions.IgnoreCase);
			Regex keepCapture = new Regex(@".+[\( \.,]\d{4}[a-z]?[\) \.,].+", RegexOptions.IgnoreCase);
			bool isCapturing = false;
			if (paragraphs == null)
				paragraphs = GetParagraphs();
			foreach (var paragraph in paragraphs)
			{
				if (!isCapturing)
				{
					if (paragraph.Contains("REFERENCE"))
					{ // this is used when debugging, the match should be resolved in the regex
						// isCapturing = true;
					}
					if (refHeader.IsMatch(paragraph))
					{
						isCapturing = true;
					}
				}
				else if (isCapturing)
				{
					if (!keepCapture.IsMatch(paragraph)) // no more capture
					{
						yield break;
					}
					yield return paragraph;
				}


			}
			yield break;
		}

		private static IEnumerable<string> GetReferencesFrom(string origItem)
		{
			var item = origItem;
			//char ct = '-';
			//Debug.WriteLine((int)ct);
			Regex cleanOpenPar = new Regex(@"\({2,}");
			Regex cleanClosePar = new Regex(@"\){2,}");
			item = cleanOpenPar.Replace(item, "(");
			item = cleanClosePar.Replace(item, ")");
			Regex parenthesisWithYear = new Regex(@"\((?<insidePar>[^\)]*\b\d{4}[a-z]?\b[^\)]*)\)");
			Regex startsWithYear = new Regex(@"^\d{4}[a-z]?\b.*?$");
			Regex invalid = new Regex(@"^[\x2D0-9]*$", RegexOptions.None);
			// \p{Lu} is uppercase \p{Ll} is lowercase \p{L} is any
			Regex namesBeforeBracket = new Regex(@"(?<citation>([\p{Lu}][\p{L}\.]+(\s|and|et|al\.|,)*?)+)\s*$", RegexOptions.CultureInvariant);

			Regex removePage = new Regex(@"[\s,]*(p\.|pp\.|pag\.)\s*\d+([\s -]\d+)?", RegexOptions.IgnoreCase);
			Regex removeDoublespace = new Regex(@"[\s]+", RegexOptions.IgnoreCase);

			foreach (Match match in parenthesisWithYear.Matches(item))
			{
				var initialValue = match.Groups["insidePar"].Value;
				var values = initialValue.Split(';').Select(value => value.Trim());
				foreach (var singleValue in values)
				{
					var tmpValue = singleValue;
					var beforeMatch = item.Substring(0, match.Index);
					if (startsWithYear.IsMatch(tmpValue))
					{
						var capitalMatch = namesBeforeBracket.Match(beforeMatch);
						if (capitalMatch.Success)
						{
							tmpValue = $"{capitalMatch.Groups["citation"].Value.Trim([' ', ','])}, {tmpValue}";
						}
					}
					tmpValue = removePage.Replace(tmpValue, "");
					tmpValue = removeDoublespace.Replace(tmpValue, " ");
					tmpValue = tmpValue.Replace(" et al. ", " et al., ");
					tmpValue = tmpValue.Replace(" ,", ",");
					tmpValue = tmpValue.Replace(" & ", " and ");
					if (tmpValue == "1987–2005")
					{

					}
					if (invalid.IsMatch(tmpValue))
					{
						Debug.WriteLine($"Invalid reference result for `{initialValue}` - context: `{beforeMatch.Substring(Math.Max(0, beforeMatch.Length - 25))}{initialValue}`");
						continue;
					}
					yield return tmpValue;
				}
			}
		}

		private List<string>? parags;

		public IEnumerable<string> GetParagraphs()
		{
			try
			{
				if (parags is null)
				{
					using var fileStream = File.OpenRead(file.FullName);
					using var doc = new XWPFDocument(fileStream);
					parags = GetComponentsText(doc).ToList();
				}
				return parags ?? Enumerable.Empty<string>();
			}
			catch (Exception ex)
			{
				return [$"Error: {ex.Message}"];
			}
		}

		private class HitStat
		{
			public HitStat(int initialHitCount)
			{
				HitCount = initialHitCount;
			}

			public int HitCount { get; set; } = 0;
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


		public bool Exists
		{
			get
			{
				if (!file.Exists)
					return false;
				return file.Extension.ToLower() == ".docx";
			}
		}

		public IEnumerable<ImageFile> GetImages()
		{
			using ZipArchive archive = ZipFile.OpenRead(file.FullName);
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (!IsImageName(entry.FullName))
					continue;
				var tempName = Path.Combine(
						Path.GetTempPath(),
						$"{Guid.NewGuid()}{Path.GetExtension(entry.Name)}"
						);
				entry.ExtractToFile(tempName);
				yield return new ImageFile(entry.FullName);
				
				//using (var img = SixLabors.Fonts.im Image.FromFile(tempName))
				//{
				//	var t = new ImageFile(entry.FullName, img);
				//	yield return t;
				//}
				File.Delete(tempName);
			}
		}

		internal IEnumerable<string> WriteTempImages(IEnumerable<ImageFile> fnd)
		{
			using ZipArchive archive = ZipFile.OpenRead(file.FullName);
			var names = fnd.Select(x => x.Name);
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (!names.Contains(entry.FullName))
					continue;
				var tempName = Path.Combine(
						Path.GetTempPath(),
						$"{Guid.NewGuid()}{Path.GetExtension(entry.Name)}"
						);
				entry.ExtractToFile(tempName);
				yield return tempName;
			}
		}

		private bool IsImageName(string fullName)
		{
			var ext = Path.GetExtension(fullName).ToLowerInvariant();
			switch (ext)
			{
				case ".gif":
				case ".png":
				case ".bmp":
				case ".jpg":
				case ".jpeg":
					return true;
				default:
					break;
			}
			return false;

		}

		public static IEnumerable<string> CleanReferences(IEnumerable<string> refs)
		{
			yield break;
			Regex r = new Regex(@"^\((?<simpleRef>.+)\)$");
			foreach (var referenceString in refs)
			{
				var m = r.Match(referenceString);
				if (m.Success)
				{

				}
				// if (.IsMatch(referenceString))
			}
		}
	}
}
