using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnnFunctions.Models;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions
{
	public class eVision
	{
		enum HeaderStyle
		{
			notFound,
			full, // starts with Ac Year
			withPhotos, // starts with ID
			Tutor
		}

		public static Student? GetStudentFromIndividualSource(string htmlSource, QueueAction context)
		{
			var email = GetField("University Email", htmlSource);
			
			// there's a bit that goes something like <td>19017284/1</td>
			// 
			Regex getId = new Regex("<td>(?<Id>\\d{8})/\\d</td>");
			var stringID = string.Empty;
			var idR = getId.Match(htmlSource);
			if (idR.Success)
			{
				stringID = idR.Groups["Id"].Value;
			}

			if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(stringID))
			{
				return null;
			}

			var st = new Student();
			st.Email = email;
			st.NumericStudentId = stringID;
			st.FullName = GetField("Name", htmlSource);
			if (context.DataRequired.HasFlag(QueueAction.ActionRequiredData.studentPersonalEmail))
			{
				var othermail = GetField("Personal Email", htmlSource);
				if (!string.IsNullOrEmpty(othermail))
					st.AddAlternativeEmail(othermail!);
			}
			if (context.DataRequired.HasFlag(QueueAction.ActionRequiredData.studentPhone))
			{
				var phone = GetField("UK Mobile Number", htmlSource);
				if (string.IsNullOrEmpty(phone))
					phone = GetField("Other Contact Number", htmlSource);
				st.Phone = phone;
			}
			return st;
		}

		private static string? GetField(string fieldName, string htmlSource)
		{
			var regex = GetRegex(fieldName);
			var m = regex.Match(htmlSource);
			if (m.Success)
				return m.Groups["Match"].Value;
			return null;
		}






		// gets a part of the html that looks like 
		//
		//<div class="sv-form-group">
		//	<p class="sv-col-sm-3 sv-static-text"> <- starts here
		//		Name
		//	</p>
		//	<div class="sv-col-sm-9">
		//		<p class="sv-form-control-static">
		//			Giannis Vagenas
		//		</p>
		//	</div>
		//</div>
		public static Regex GetRegex(string tag)
		{
			// >space
			// tag
			// space<
			// any non greedy
			// static">
			// CAPTURE (non greedy
			// </p>
			// var ret = new Regex( @">[\s\n\r]+Name[\s\r\n]+<.*?static"">[\r\n\s]*(?<Name>.*?)[\r\n\s]*</p>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			var re2 = new Regex($@">[\s\n\r]+{tag}[\s\r\n]+<.*?static"">[\r\n\s]*(?<Match>.*?)[\r\n\s]*</p>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			return re2;
		}

		public static IEnumerable<QueueAction> GetTranscriptPageFromIndividualSource(string htmlSource, QueueAction context)
		{
			// initial marker
			// non greedy match any until url .*?
			// 
			var t = new Regex("""
					\$\("#tab-tabs-7a"\)\.one\( "click".*?url: "(?<link>[^"]*)"
					""", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			var ms = t.Matches(htmlSource);
			foreach (Match m in ms)
			{
				if (m.Success)
				{
					string rel = m.Groups["link"].Value;
					var uri = context.GetReltiveUri(rel);
					yield return new QueueAction(uri, context.DataRequired, QueueAction.ActionSource.studentTranscript, context.Collection);
				}
			}
		}

		public static IEnumerable<QueueAction> GetStudentIndividualSource(string htmlSource, QueueAction context)
		{
			// document.location.href='../run/SIW_YGSL.start_url?
			var t1 = new Regex("(?<studentId>\\d{8})/\\d</td>.+?document\\.location\\.href='(?<link>\\.\\./run/SIW_YGSL\\.start_url\\?([^']+))';");
			var t = new Regex("document\\.location\\.href='(?<link>\\.\\./run/SIW_YGSL\\.start_url\\?([^']+))';");
			var ms = t1.Matches(htmlSource);
			foreach (Match m in ms)
			{
				if (m.Success)
				{
					string rel = m.Groups["link"].Value;
					string stud = m.Groups["studentId"].Value;
					var uri = context.GetReltiveUri(rel);
					yield return new QueueAction(uri, context.DataRequired, QueueAction.ActionSource.studentDetails, context.Collection, stud);
				}
			}
		}

		public static IEnumerable<QueueAction> GetStudentPicurePage(string htmlSource, QueueAction context)
		{
			var t = new Regex("<a href=\"(?<link>\\.\\./run/SIW_YGSL.start_url\\?(.+))\"");

			var m = t.Match(htmlSource);
			if (m.Success)
			{
				string rel = m.Groups["link"].Value;
				var uri = context.GetReltiveUri(rel);
				yield return new QueueAction(uri, context.DataRequired, QueueAction.ActionSource.studentsListWithPictures, context.Collection);
			}
		}

		/// <summary>
		/// Gets the student list from the HTML taken from the evision list.
		/// </summary>
		/// <param name="htmlSource">any container that includes the TRs of the table</param>
		/// <returns>Information of the students</returns>
		public static IEnumerable<Student> GetStudentsFromEvisionHtml(string htmlSource)
		{
			var students = new List<Student>();

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(htmlSource);
			HeaderStyle detectedStyle = HeaderStyle.notFound;
			HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//tr");
			if (rows is null)
			{
				MessageBoxShow("No rows");
				return Enumerable.Empty<Student>();
			}
			foreach (var row in rows)
			{
				var headers = row.SelectNodes("th");
				if (headers != null)
				{
					if (headers[0].InnerText == "Student Course Join Code")
					{
						detectedStyle = HeaderStyle.Tutor;
						continue;
					}
					else if (headers[0].InnerText == "ID")
					{
						detectedStyle = HeaderStyle.withPhotos;
						continue;
					}
					else if (headers[0].InnerText == "Ac Year")
					{
						detectedStyle = HeaderStyle.full;
						continue;
					}
					continue;
				}
				if (detectedStyle == HeaderStyle.notFound)
				{
					MessageBoxShow("Header not found in clipboard");
					return Enumerable.Empty<Student>();
				}
				var cols = row.SelectNodes("td");
				if (cols is null)
					continue;

				Student? s = null;
				if (detectedStyle == HeaderStyle.withPhotos)
				{
					s = new();
					s.NumericStudentId = HtmlEntity.DeEntitize(cols[0].InnerText).Trim();
					GetNameAndDssr(s, cols[1]);
					s.Email = HtmlEntity.DeEntitize(cols[3].InnerText).Trim();
				}
				else if (detectedStyle == HeaderStyle.full)
				{
					s = new();
					s.NumericStudentId = HtmlEntity.DeEntitize(cols[7].InnerText).Trim();
					GetNameAndDssr(s, cols[8]);
					s.Route = HtmlEntity.DeEntitize(cols[6].InnerText).Trim();
					s.CourseYear = HtmlEntity.DeEntitize(cols[0].InnerText).Trim();
					s.Occurrence = HtmlEntity.DeEntitize(cols[3].InnerText).Trim();
					s.Module = HtmlEntity.DeEntitize(cols[1].InnerText).Trim();
				}
				else if (detectedStyle == HeaderStyle.Tutor)
				{
					s = new();
					s.NumericStudentId = HtmlEntity.DeEntitize(cols[0].InnerText).Trim();
					s.Forename = HtmlEntity.DeEntitize(cols[1].InnerText).Trim();
					s.Surname = HtmlEntity.DeEntitize(cols[2].InnerText).Trim();
					s.Route = HtmlEntity.DeEntitize(cols[7].InnerText).Trim();
					s.Module = "Tutor";
				}
				if (s!=null)
				{
					students.Add(s);
				}
			}
			return students;
		}

		private static void MessageBoxShow(string v)
		{
			Debug.WriteLine(v);
		}

		private static void GetNameAndDssr(Student s, HtmlNode nameCell)
		{
			var nameText = nameCell.ChildNodes[0]; // the first text

			s.FullName = HtmlEntity.DeEntitize(nameText.InnerText).Trim();
			if (nameCell.ChildNodes.Any(x => x.Name == "span" && x.InnerText.Contains("DSSR")))
			{
				s.DSSR = true;
			}
		}

		public static Student? GetStudentTranscript(string htmlSource, QueueAction callingAction)
		{
			// get the student id
			// get the accordion class
			// children are in sequence
			//   h3, where we get the year
			//   div for the content of the year

			var doc = new HtmlAgilityPack.HtmlDocument();
			if (doc is null)
				return null;
			doc.LoadHtml(htmlSource);
			// get the table header for the student number
			//
			var head = doc.DocumentNode.SelectNodes("//table[@id='tabhead7a']").FirstOrDefault();
			if (head == null)
				return null;
			var r = new Regex(
				"""
				<td>(?<id>\d{8})/\d</td>
				""", RegexOptions.Singleline | RegexOptions.IgnoreCase
				);
			var m = r.Match(head.InnerHtml);
			if (!m.Success)
				return null;
			var accordion = doc.DocumentNode.SelectNodes("//div[@id='SMR_accordion']").FirstOrDefault();
			if (accordion == null)
				return null;
			string year = "";
			var st = new Student() { NumericStudentId = m.Groups["id"].Value };
			foreach (var sub in accordion.ChildNodes)
			{
				if (sub.Name == "h3")
				{
					year = sub.FirstChild.InnerText.Trim();
				}
				else if (sub.Name == "div")
				{
					var modules = sub.SelectNodes("div[@class='sv-row']");
					foreach (var module in modules)
					{
						ModuleResult res = new ModuleResult();
						res.Year = year;
						var fields = module.SelectNodes("div");
						foreach (var field in fields)
						{
							var txt = Clean(field);
							EvaluateField(ref res, txt);
						}
						if (res.TryGetMark(out _, out _))
							st.SetModuleMark(res);
					}
				}
			}
			return st;
		}

		private static void EvaluateField(ref ModuleResult res, string txt)
		{
			var array = txt.Split(new[] { ':' });
			if (array.Length != 2)
				return;
			var key = array[0].Trim();
			var val = array[1].Trim();
			if (string.IsNullOrEmpty(val))
				return;
			res ??= new ModuleResult();
			switch (key) 
			{
				case "Plus Minus Module Code":
					res.Code = val;
					break;
				case "Module Name":
					res.Title = val;
					break;
				case "Occurrence":
				case "Period":
					if (string.IsNullOrEmpty(res.Extra))
						res.Extra = val;
					else
						res.Extra += $" {val}";
					break;
				case "Level":
					res.Level = val;
					break;
				case "Actual Mark":
					res.ActualMark = val;
					break;
				case "Actual Grade":
					res.ActualResult = val;
					break;
				case "Agreed Mark":
					res.AgreedMark = val;
					break;
				case "Agreed Grade":
					res.AgreedResult = val;
					break;
				case "Credits":
					res.Credits = val;
					break;
				case "Result":
					res.Result = val;
					break;
				default:
					break;
			}
		}

		private static string Clean(HtmlNode field)
		{
			var t = HtmlEntity.DeEntitize(field.InnerText).Trim();
			t = t.Replace("\t", " ");
			t = t.Replace("\r", " ");
			t = t.Replace("\n", " ");
			t = t.Replace((char)160, ' '); // this is a non breaking space, not just a space hex a0
			while (t.Contains("  "))
				t = t.Replace("  ", " ");
			return t;
		}
	}
}


