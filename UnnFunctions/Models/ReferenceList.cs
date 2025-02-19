using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnnFunctions.Models
{
	public class ReferenceList
	{
		string[] references;

		HashSet<string> matchedReferences = new();

		public ReferenceList(string text)
		{
			text = text.Replace("\u00A0", " "); // non breaking space replacement
			text = text.Replace("\t", " ");      // tab replaced
			references = text.Split(
				Environment.NewLine.ToCharArray(), 
				StringSplitOptions.RemoveEmptyEntries
				).Distinct().ToArray();
		}

		public object ReferenceCount => references.Length;

		public IEnumerable<string> GetUnreferenced()
		{
			return references.Except(matchedReferences);
		}

		public bool TryGetMatchingReferences(string referenceCitation, out IEnumerable<string> refs)
		{
			var rs = new List<string>();
			var cit = GetCitationParts(referenceCitation);
			if (cit.Count < 1)
			{
				refs = [];	
				return false;
			}
			foreach (var reference in references)
			{
				if (IsMatch(cit, reference))
				{
					rs.Add(reference);
					if (!matchedReferences.Contains(reference))
						matchedReferences.Add(reference);
				}
			}
			refs = rs;
			return rs.Any();
		}

		private List<string> GetCitationParts(string referenceCitation)
		{
			// referenceCitation = referenceCitation.Replace(" et al.", "");
			referenceCitation = referenceCitation.Replace(" and ", ", ");
			var t = referenceCitation.Split([","], StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim());
			return t.ToList();
		}

		private bool IsMatch(IEnumerable<string> requiredParts, string reference)
		{
			var pts = requiredParts.ToArray();
			for (int i = 0; i < pts.Length; i++)
			{
				var part = pts[i];
				bool found;
				if (i == 0 || part.EndsWith(" et al."))
				{
					var firstAuthor = part.Replace(" et al.", "");
					// must be the first name in the reference
					found = reference.IndexOf(firstAuthor, StringComparison.OrdinalIgnoreCase) == 0;
				}
				else
				{
					found = reference.IndexOf(part, StringComparison.OrdinalIgnoreCase) >= 0;
				}
				if (!found)
					return false;
			}
			
			return true;
		}
	}
}
