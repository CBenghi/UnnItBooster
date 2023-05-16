using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions
{
	//public static class MessageBox
	//{
	//	public static void Show(string s)
	//	{
	//		Debug.WriteLine(s);
	//	}
	//}

	public class eVision
	{
		enum HeaderStyle
		{
			notFound,
			full, // starts with Ac Year
			withPhotos // starts with ID
		}

		/// <summary>
		/// /// Gets the student list from the HTML taken from the evision list.
		/// </summary>
		/// <param name="htmlSource">any container that includes the TRs of the table</param>
		/// <returns>Information of the students</returns>
		public static IEnumerable<Student> GetStudentsFromEvisionClipboard(string htmlSource)
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
				if (!(headers is null))
				{
					if (headers[0].InnerText == "ID")
					{
						detectedStyle = HeaderStyle.withPhotos;
						continue;
					}
					if (headers[0].InnerText == "Ac Year")
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

				var s = new Student();
				if (detectedStyle == HeaderStyle.withPhotos)
				{
					s.NumericStudentId =  HtmlEntity.DeEntitize(cols[0].InnerText).Trim();
					GetNameAndDssr(s, cols[1]);
					s.Email = HtmlEntity.DeEntitize(cols[3].InnerText).Trim();
				}
				else if (detectedStyle == HeaderStyle.full)
				{
					s.NumericStudentId = HtmlEntity.DeEntitize(cols[7].InnerText).Trim();
					GetNameAndDssr(s, cols[8]);
					s.Route = HtmlEntity.DeEntitize(cols[6].InnerText).Trim();
					s.CourseYear = HtmlEntity.DeEntitize(cols[0].InnerText).Trim();
					s.Occurrence = HtmlEntity.DeEntitize(cols[3].InnerText).Trim();
					s.Module = HtmlEntity.DeEntitize(cols[1].InnerText).Trim();
				}
				students.Add(s);
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
	}
}


