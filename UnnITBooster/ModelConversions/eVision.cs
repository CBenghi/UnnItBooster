using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions
{
	internal class eVision
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
		internal static IEnumerable<Student> GetStudentsFromEvisionClipboard(string htmlSource)
		{
			var students = new List<Student>();

			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(htmlSource);
			HeaderStyle detectedStyle = HeaderStyle.notFound;
			HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//tr");
			if (rows is null)
			{
				MessageBox.Show("No rows");
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
					MessageBox.Show("Header not found in clipboard");
					return Enumerable.Empty<Student>();
				}
				var cols = row.SelectNodes("td");
				if (cols is null)
					continue;

				var s = new Student();
				if (detectedStyle == HeaderStyle.withPhotos)
				{
					s.NumericStudentId = System.Web.HttpUtility.HtmlDecode(cols[0].InnerText).Trim();
					GetNameAndDssr(s, cols[1]);
					s.Email = System.Web.HttpUtility.HtmlDecode(cols[3].InnerText).Trim();
				}
				else if (detectedStyle == HeaderStyle.full)
				{
					s.NumericStudentId = System.Web.HttpUtility.HtmlDecode(cols[7].InnerText).Trim();
					GetNameAndDssr(s, cols[8]);
					s.Route = System.Web.HttpUtility.HtmlDecode(cols[6].InnerText).Trim();
					s.CourseYear = System.Web.HttpUtility.HtmlDecode(cols[0].InnerText).Trim();
					s.Occurrence = System.Web.HttpUtility.HtmlDecode(cols[3].InnerText).Trim();
					s.Module = System.Web.HttpUtility.HtmlDecode(cols[1].InnerText).Trim();
				}
				students.Add(s);
			}
			return students;
		}

		private static void GetNameAndDssr(Student s, HtmlNode nameCell)
		{
			var nameText = nameCell.ChildNodes[0]; // the first text

			s.FullName = System.Web.HttpUtility.HtmlDecode(nameText.InnerText).Trim();
			if (nameCell.ChildNodes.Any(x => x.Name == "span" && x.InnerText.Contains("DSSR")))
			{
				s.DSSR = true;
			}
		}
	}
}
