#nullable enable

using System.Collections.Concurrent;

namespace StudentsFetcher.StudentMarking;

class ComboId
{
    public ComboId(string text, int percentValue, int order)
    {
        Text = text;
        value = percentValue;
        position = order;
    }

    public string Text { get; private set; }
    public int value { get; private set; }
	public int position { get; private set; }

	public override string ToString()
    {
        return $"{Text} (#{position} - {value}%)";
    }
}


