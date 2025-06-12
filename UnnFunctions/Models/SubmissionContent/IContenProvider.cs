using System;
using System.Collections.Generic;
using System.Text;

namespace UnnFunctions.Models.SubmissionContent
{
	internal interface IContentProvider
	{
		bool Exists { get; }

		public IEnumerable<string> GetParagraphs();
	}
}
