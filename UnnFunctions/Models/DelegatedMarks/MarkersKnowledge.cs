using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnnFunctions.Models.DelegatedMarks
{
	public class MarkersKnowledge
	{
		public static List<MarkersKnowledge>? _markersCollection = null;
		public string First { get; set; }
		public string Last { get; set; }
		public string Email { get; set; }

		public static MarkersKnowledge? GetMarker(string anyfield)
		{
			var candidates = MarkersCollection.Where(m =>
				m.First.Equals(anyfield, StringComparison.OrdinalIgnoreCase) ||
				m.Last.Equals(anyfield, StringComparison.OrdinalIgnoreCase) ||
				m.Email.Equals(anyfield, StringComparison.OrdinalIgnoreCase)
			).ToList();
			if (candidates.Count == 1)
			{
				return candidates[0];
			}
			return null;
		}


		public MarkersKnowledge(string LastNameCommaFirst, string email)
		{
			var parts = LastNameCommaFirst.Split([","], StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length != 2)
			{
				throw new Exception("Invalid markers knowledge configuration");
			}
			First = parts[1].Trim();
			Last = parts[0].Trim();
			Email = email;
		}

		public static IList<MarkersKnowledge> MarkersCollection
		{
			get
			{
				_markersCollection ??= InitializeMarkers();
				return _markersCollection;
			}
		}

		private static List<MarkersKnowledge> InitializeMarkers()
		{
			var t = new List<MarkersKnowledge>();
			t.Add(new MarkersKnowledge("Anyigor, Kelechi", "kelechi.anyigor@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Benghi, Claudio", "claudio.benghi@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Butt, Talib", "t.e.butt@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Doukari, Omar", "omar.doukari@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Elysee, Ray", "ray.elysee@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Gbadamosi, Abdul", "abdul.gbadamosi@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Littlemore, Michelle", "michelle.littlemore@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Maqbool, Rashid", "rashid.maqbool@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Martinez-Rodriguez, Pablo", "pablo.rodriguez@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Ponton, Hazel", "hazel.ponton@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Rathnasinghe, Akila", "akila.rathnasinghe1@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Samwinga, Victor", "victor.samwinga@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Suliman, Ala", "ala.suliman@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Tindall, Jess", "jess.tindall@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Umer, Waleed", "waleed.umer@northumbria.ac.uk"));
			t.Add(new MarkersKnowledge("Alwan, Zaid", "zaid.alwan@northumbria.ac.uk"));
			return t;
		}
	}
}
