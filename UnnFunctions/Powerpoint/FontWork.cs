using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UnnFunctions.Powerpoint
{
	public class FontWork : FontWorkBase
	{
		public static FontWork? FromFile(string file)
		{
			if (!File.Exists(file))
				return null;			
			FontWork work = new FontWork(file);
			return work;
		}

		public FontWork(string file) : base(file) 
		{
			
		}

		public class FontInfo
		{
			public FontInfo(string name, XElement element, string entry)
			{
				FontName = name;
				Element = element;
				EntryFullName = entry;
			}

			public string FontName { get; }
			public XElement Element { get; }
			public string EntryFullName { get; }
		}


		public IList<FontInfo> GetFonts(string? path = null)
		{
			var ret = new List<FontInfo>();	
			using var archive = pptx();
			foreach (var entry in archive.Entries.ToList())
			{
				if (!string.IsNullOrEmpty(path) && !entry.FullName.Contains(path))
					continue;
				if (!entry.Name.EndsWith(".xml"))
					continue;
				if (entry.FullName.Contains("ppt/theme/"))
					continue;
				using Stream entryStream = entry.Open();
				XDocument xmlDoc = XDocument.Load(entryStream);
				// Console.WriteLine(xmlDoc);
				var elements = xmlDoc.Descendants().Where(e => e.Attributes().Any(x => x.Name.LocalName == "typeface"));
				foreach (var element in elements)
				{
					var fontName = element.Attribute("typeface").Value;
					if (fontName.StartsWith("+")) // ignore special fonts
						continue;
					ret.Add(new FontInfo(fontName, element, entry.FullName));
				}
			}
			return ret;
		}

		public class ReplaceXml
		{
			public ReplaceXml(string fullName, XDocument xmlDoc)
			{
				FullName = fullName;
				XmlDoc = xmlDoc;
			}

			public string FullName { get; }
			public XDocument XmlDoc { get; }
		}


		public List<ReplaceXml> RemoveFonts(IEnumerable<string> fonts, string? path = null, Microsoft.Extensions.Logging.ILogger logger = null)
		{
			var ret = new List<ReplaceXml>();
			string[] removeNames = ["latin", "cs", "ea"];
			var entries = GetFonts(path).GroupBy(x => x.EntryFullName).ToList();
			using var archive = pptx();
			foreach (var entryGroup in entries)
			{
				var entryFullName = entryGroup.Key;
				// var archive = entry.Archive;
				XDocument? xmlDoc = null;
				using (Stream entryStream = archive.GetEntry(entryFullName).Open())
				{
					xmlDoc = XDocument.Load(entryStream);
				}
				if (xmlDoc is null)
					continue;
				List<XElement> nodes = GetRemoveNodes(fonts, removeNames, xmlDoc);
				if (!nodes.Any())
					continue;			
				logger.LogDebug("Found {nodes} nodes in {name}", nodes.Count, entryFullName);
				nodes.Remove();
				ret.Add(new ReplaceXml(entryFullName, xmlDoc));
			}
			return ret;
		}

		private static List<XElement> GetRemoveNodes(IEnumerable<string> fonts, string[] removeNodeTypes, XDocument? xmlDoc)
		{
			return xmlDoc.Descendants().Where(e =>
								removeNodeTypes.Contains(e.Name.LocalName)
								&&
								e.Attributes().Any(x =>
									x.Name.LocalName == "typeface"
									&& fonts.Contains(x.Value)
								)).ToList();
		}

		public void Replace(IEnumerable<ReplaceXml> replacements, ILogger? logger)
		{
			using var archive = pptx();
			foreach (var rep in replacements)
			{
				logger?.LogDebug("replacing Entry {removingEntry}", rep.FullName); 
				archive.GetEntry(rep.FullName).Delete();

				var newE = archive.CreateEntry(rep.FullName, CompressionLevel.Fastest);
				using StreamWriter writer = new StreamWriter(newE.Open());
				rep.XmlDoc.Save(writer);
			}
		}
	}
}
