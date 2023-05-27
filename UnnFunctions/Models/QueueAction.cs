using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnnFunctions.Models
{

	public class QueueAction
	{
		[Flags]
		public enum ActionRequiredData
		{
			none = 0,
			photos = 1,
			studentEmail = 2,
			studentPersonalEmail = 4,
			studentPhone = 8,
			studentTranscript = 16,
		}

		public enum ActionSource
		{
			studentsList,
			studentsListWithPictures,
			studentDetails,
			studentTranscript,
		}

		public QueueAction(Uri page, ActionRequiredData required, ActionSource source, string collection, string? studentId = null)
		{
			Page = page;
			DataRequired = required;
			DataSource = source;
			Collection = collection;
			StudentId = studentId;
		}

		public string? StudentId { get; set; } = null;
		public string Collection { get; set; }
		public ActionRequiredData DataRequired { get; set; }
		public Uri Page { get; set; }
		public ActionSource DataSource { get; set; }

		internal Uri GetReltiveUri(string rel)
		{
			// create the full uri by combining the base and relative 
			return new Uri(Page, rel);
		}
	}
}
