using System.Collections.Generic;
using System.Linq;

namespace StudentsFetcher.StudentMarking;

public class MarksCollection
{
	public List<MarkRange> Ranges { get; set; } = new();
	public int MaxCount
	{
		get
		{
			return Ranges.Max(x => x.Count);
		}
	}

	public bool Add(int mark)
	{
		var range = Ranges.FirstOrDefault(x => x.Includes(mark));
		if (range == null)
			return false;
		range.Count = range.Count + 1;
		return true;
	}

	public enum Grouping
	{
		Classification,
		HalfClassification,
		Detailed,
		Individual
	}

	public static MarksCollection Initialize(Grouping type)
	{
		var ret = new MarksCollection();
		switch (type)
		{
			case Grouping.Detailed:

				ret.Ranges.Add(new MarkRange(0, 0));
				ret.Ranges.Add(new MarkRange(1, 29));
				for (int i = 3; i < 9; i++)
				{
					var dec = i * 10;
					ret.Ranges.Add(new MarkRange(dec, dec + 2));
					ret.Ranges.Add(new MarkRange(dec + 3, dec + 6));
					ret.Ranges.Add(new MarkRange(dec + 7, dec + 9));
				}
				ret.Ranges.Add(new MarkRange(90, 100));
				break;

			case Grouping.HalfClassification:

				ret.Ranges.Add(new MarkRange(0, 0));
				ret.Ranges.Add(new MarkRange(1, 29));
				for (int i = 3; i < 9; i++)
				{
					var dec = i * 10;
					ret.Ranges.Add(new MarkRange(dec, dec + 4));
					ret.Ranges.Add(new MarkRange(dec + 5, dec + 9));
				}
				ret.Ranges.Add(new MarkRange(90, 100));
				break;

			case Grouping.Individual:
				for (int i = 0; i < 100; i++)
				{
					ret.Ranges.Add(new MarkRange(i, i));
				}
				break;
			default:
				ret.Ranges.Add(new MarkRange(0, 9));
				ret.Ranges.Add(new MarkRange(10, 19));
				ret.Ranges.Add(new MarkRange(20, 29));
				ret.Ranges.Add(new MarkRange(30, 39));
				ret.Ranges.Add(new MarkRange(40, 49));
				ret.Ranges.Add(new MarkRange(50, 59));
				ret.Ranges.Add(new MarkRange(60, 69));
				ret.Ranges.Add(new MarkRange(70, 79));
				ret.Ranges.Add(new MarkRange(80, 89));
				ret.Ranges.Add(new MarkRange(90, 100));
				break;
		}
		return ret;
	}

	internal void RemoveZeros()
	{
		Ranges.RemoveAll(x => x.Includes(0));
	}
}
