using System;

namespace UnnFunctions.Models
{

	public class QueueAction : IEquatable<QueueAction>
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

		public QueueAction(Uri page, ActionRequiredData required, ActionSource source, string targetCollection, string? studentId = null)
		{
			Page = page;
			DataRequired = required;
			DataSource = source;
			DestinationCollection = targetCollection;
			StudentId = studentId;
		}

		public string? StudentId { get; set; } = null;
		public string DestinationCollection { get; set; }
		public ActionRequiredData DataRequired { get; set; }
		public Uri Page { get; set; }
		public ActionSource DataSource { get; set; }

		internal Uri GetReltiveUri(string rel)
		{
			// create the full uri by combining the base and relative 
			return new Uri(Page, rel);
		}

		public override int GetHashCode()
		{
			return (Page.AbsoluteUri, DataRequired, DataSource, DestinationCollection, StudentId).GetHashCode();
		}

		public bool Equals(QueueAction other)
		{
			if (this is null || other is null)
				return false;
			return (Page.AbsoluteUri, DataRequired, DataSource, DestinationCollection, StudentId).Equals(
				(other.Page.AbsoluteUri, other.DataRequired, other.DataSource, other.DestinationCollection, other.StudentId)
				);
		}
	}
}
