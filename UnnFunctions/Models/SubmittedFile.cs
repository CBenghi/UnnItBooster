using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnnItBooster.Models
{
	public record SubmittedFile
	{
		public SubmittedFile(string fullPath, string submissionId)
		{
			FullPath = fullPath;
			SubmissionId = submissionId;
		}

		public string FullPath { get; set; }
		public string SubmissionId { get; set; }
	}
}
