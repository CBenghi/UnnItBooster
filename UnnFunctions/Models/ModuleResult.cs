using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UnnFunctions.Models
{
	[DebuggerDisplay("{Code} Credits:{Credits} {ActualMark} {AgreedMark}")]
	public class ModuleResult
	{
		public string Title { get; set; } 
		public string Code { get; set; }
		public string Year { get; set; }
		public string Extra { get; set; }
		public string Level { get; set; }
		public string Credits { get; set; }
		public string ActualResult { get; set; }
		public string ActualMark { get; set; }
		public string AgreedResult { get; set; }
		public string AgreedMark { get; set; }
		public string Result { get; set; }

		public string GetMarkString()
		{
			// prioritising agreed result
			if (!string.IsNullOrEmpty(AgreedMark))
				return AgreedMark;
			return ActualMark;
		}

		public bool TryGetMark(out int mark, out int credits)
		{
			credits = 0;
			if (!string.IsNullOrEmpty(Credits))
			{
				int.TryParse(Credits, out credits);
			}
			var t = GetMarkString();
			if (string.IsNullOrEmpty(t))
			{
				mark = -1;
				return false;
			}
			return int.TryParse(t, out mark);
		}
	}
}
