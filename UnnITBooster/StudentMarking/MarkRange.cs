using System.Diagnostics;
namespace StudentsFetcher.StudentMarking;

[DebuggerDisplay("Range {Min}-{Max}: {Count}")]
public class MarkRange
{
	public MarkRange(int min, int max)
	{
		Min = min;
		Max = max;
	}

	public int Min { get; set; }
	public int Max { get; set; }
	public int Count { get; set; } = 0;
	public double Place
	{
		get
		{
			if (Min < 0 || Max > 100)
				return 100;
			return (Max + Min) / 2.0;
		}
	}

	public string Description
	{
		get
		{
			if (Count == 0)
				return "";
			if (Min < 0 || Max > 100)
				return "unmarked";
			if (Min == Max)
				return $"{Min}";
			return $"{Min}:{Max}";
		}
	}

	public bool Includes(int Mark)
	{
		var found = Mark >= Min && Mark <= Max;
		return found;
	}
}