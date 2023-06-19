using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnnFunctions.Models
{
	public class TurnitinHtmlReports
	{
		public static void Merge(FileInfo html, FileInfo referenceDet, string name, double hardCodedScale)
		{
			if (html == null || referenceDet == null) 
				return;
			if (!html.Exists || !referenceDet.Exists)
				return;
			if (html.Directory is null)
				return;
			var dic = TunritinReferencePage.FromFile(referenceDet);
			if (dic == null) 
				return;

			FileInfo f = new FileInfo(Path.Combine(
				html.Directory.FullName, $"Joined detection {name}.html"
				));
			if (f.Exists)
				f.Delete();
			var htmlLines = File.ReadAllLines(html.FullName);
			if (!htmlLines.Any())
				return;

			
			Regex pageLine = new Regex("alt=\"Page (?<page>\\d+)\"");
			TunritinReferencePage? currentRefPageContent = null;
			using var w = f.CreateText();
			foreach (var sourceLine in htmlLines)
			{
				var line = sourceLine;
				var plm = pageLine.Match(sourceLine);	
				if (plm.Success)
				{
					if (!int.TryParse(plm.Groups["page"].Value, out var pg))
						return;
					dic.TryGetValue(pg, out currentRefPageContent);
				}
				else if (TunritinAiPage.IsTransformLine(sourceLine, out _))
				{
					// here we attempt to pre-compute the scaling so it can be printed (due to chrome quirkness with background scaling
					line = TunritinAiPage.ComputeScaling(sourceLine);
				}
				else if (sourceLine == "</div>")
				{
					if (currentRefPageContent != null)
						currentRefPageContent.WriteTo(w, hardCodedScale);					
				}
				w.WriteLine(line);
			}
		}
	}

	internal class TunritinAiPage
	{
		private class Scaler
		{
			private double scale;

			public Scaler(double scale)
			{
				this.scale = scale;
			}

			public string Replace(Match m)
			{
				if (!double.TryParse(m.Groups["value"].Value, out var val))
					return m.Value;
				return m.Value.Replace(m.Groups["value"].Value, (val * scale).ToString());
			}
		}

		static Regex scaleR = new Regex("scale\\((?<scale>[\\d\\.]+)\\);");

		static string[] properties = new[] { "top", "left", "width", "height" };

		public static string ComputeScaling(string scaleTransform)
		{
			if (!IsTransformLine(scaleTransform, out var scale))
				return scaleTransform;
			// fix the scale
			var line = scaleR.Replace(scaleTransform, "scale(1.0);");
			Scaler scaler = new Scaler(scale);
			var eval = new MatchEvaluator(scaler.Replace);
			// now fix the measures
			foreach (var prop in properties)
			{
				var p = new Regex($"{prop}: (?<value>[\\d\\.]+)px;");
				line = p.Replace(line, eval);
			}
			return line;
		}

		

		public static bool IsTransformLine(string s, out double scale)
		{
			var scm = scaleR.Match(s);
			if (!scm.Success)
			{
				scale = 1;
				return false;
			}
			if (!double.TryParse(scm.Groups["scale"].Value, out scale))
			{
				scale = 1;
				return false;
			}
			return true;
		}

		
	}

	internal class TunritinReferencePage
	{
		public TunritinReferencePage(int pg)
		{
			Page = pg;
		}

		public int Page { get; }

		internal static Dictionary<int, TunritinReferencePage>? FromFile(FileInfo referenceFile)
		{
			var ret = new Dictionary<int, TunritinReferencePage> ();
			var txtLines = File.ReadAllLines(referenceFile.FullName);

			TunritinReferencePage? page = null;
			foreach ( var line in txtLines ) 
			{ 
				if (line == "")
				{
					// ignore
				}
				else if (line.StartsWith("== Page "))
				{
					if (!int.TryParse(line.Substring(8), out var pg))
						return null;
					page = new TunritinReferencePage(pg);
					if (ret.ContainsKey(pg))
						return null;
					ret.Add(pg, page);
				}
				else 
				{
					if (page is null)
						return null;
					if (line.StartsWith("area: "))
						page.SetArea(line.Substring(6));					
					else if (line.StartsWith("transform: "))
						page.SetTransform(line.Substring(11));
				}
				
			}

			return ret;
		}

		private void SetTransform(string v)
		{
			Regex r = new Regex("scale\\((?<scale>[\\d\\.]+)\\)");
			var m = r.Match(v);
			if (!m.Success)
				return;
			if (!double.TryParse(m.Groups["scale"].Value, out var t))
				return;
			scale = 1/t;
		}

		private double scale = 0;

		public double Scale => scale;

		private class Dimension
		{
			public Dimension(int t, int l, int h, int w)
			{
				H = h;
				W = w;
				Top = t;
				Left = l;
			}

			internal int Top { get; set; }
			internal int Left { get; set; }
			internal int H { get; set; }
			internal int W { get; set; }

			internal static Dimension? From(string dimensionString)
			{
				var arr = dimensionString.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (arr.Length != 4)
					return null;
				if (!int.TryParse(arr[0], out var t))
					return null;
				if (!int.TryParse(arr[1], out var l))
					return null;
				if (!int.TryParse(arr[2], out var h))
					return null;
				if (!int.TryParse(arr[3], out var w))
					return null;
				return new Dimension(t,l,h,w);

			}
		}

		private void SetArea(string dimensionString)
		{
			Dimension? d = Dimension.From(dimensionString);
			if (d == null)
				return;
			Areas.Add(d);
		}

		internal void WriteTo(StreamWriter w, double hardCodeScaling)
		{
			if (!Areas.Any())
				return;
			w.WriteLine("<tii-doc-simple-glyph-layer>");
			w.WriteLine("<div class=\"react-wc-mount-point undefined\">");
			w.WriteLine($"""<div class="referenceScaling" >""");
			foreach (var area in Areas)
			{
				w.WriteLine($"""<div class="region reference-region" style="top: {area.Top * hardCodeScaling}px; left: {area.Left * hardCodeScaling}px; width: {area.W * hardCodeScaling}px; height: {area.H * hardCodeScaling}px; position: absolute;"></div>""");
			}
			w.WriteLine();
			w.WriteLine("</div>");
			w.WriteLine("</div>");
			w.WriteLine("</tii-doc-simple-glyph-layer>");
		}

		List<Dimension> Areas = new List<Dimension>();

	}


}
