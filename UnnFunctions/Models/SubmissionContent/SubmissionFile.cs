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
using System.Threading;

namespace UnnFunctions.Models.SubmissionContent
{
	public class SubmissionFile
	{
		private FileInfo file;
		private IContentProvider? contentProvider = null;
		public SubmissionFile(FileInfo f)
		{
			file = f;
			if (file.Extension.ToLower() == ".docx")
				contentProvider = new WordContent(file);
			else if (file.Extension.ToLower() == ".pdf")
				contentProvider = new PdfContent(file);
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
			foreach (var paragraphText in parags)
			{
				if (reflist.Contains(paragraphText)) // we want to exclude elements from the reference list
					continue;
				foreach (var reference in GetInlineReferencesFromParagraph(paragraphText))
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

		public static IEnumerable<string> GetInlineReferencesFromParagraph(string paragraphText)
		{
			var editedParagraphText = paragraphText;
			//char ct = '-';
			//Debug.WriteLine((int)ct);
			Regex cleanOpenPar = new Regex(@"\({2,}");
			Regex cleanClosePar = new Regex(@"\){2,}");
			editedParagraphText = cleanOpenPar.Replace(editedParagraphText, "(");
			editedParagraphText = cleanClosePar.Replace(editedParagraphText, ")");
			Regex parenthesisWithYear = new Regex(@"\((?<insidePar>[^\)]*\b\d{4}[a-z]?\b[^\)]*)\)");
			Regex startsWithYear = new Regex(@"^\d{4}[a-z]?\b.*?$");
			Regex invalid = new Regex(@"^[\x2D0-9]*$", RegexOptions.None);
			// \p{Lu} is uppercase \p{Ll} is lowercase \p{L} is any
			Regex namesBeforeBracket = new Regex(@"(?<citation>([\p{Lu}][\p{L}\.'’-]+(\s|and|et|al\.|,)*?)+)\s*$", RegexOptions.CultureInvariant);

			Regex removePage = new Regex(@"[\s,]*(p\.|pp\.|pag\.)\s*\d+([\s -]\d+)?", RegexOptions.IgnoreCase);
			Regex removeDoublespace = new Regex(@"[\s]+", RegexOptions.IgnoreCase);

			foreach (Match match in parenthesisWithYear.Matches(editedParagraphText))
			{
				var initialValue = match.Groups["insidePar"].Value;
				var values = initialValue.Split(';').Select(value => value.Trim());
				foreach (var singleValue in values)
				{
					var tmpValue = singleValue;
					var beforeMatch = editedParagraphText.Substring(0, match.Index);
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
			if (parags != null)
				return parags;
			if (contentProvider is not null)
				parags = contentProvider.GetParagraphs().ToList();
			return parags ?? Enumerable.Empty<string>();			
		}

		public bool Exists
		{
			get
			{
				if (contentProvider is not null)
					return contentProvider.Exists;
				return false;
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
