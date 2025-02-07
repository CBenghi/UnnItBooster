#nullable enable

namespace StudentsFetcher.StudentMarking;

class ComboTag
{
	public ComboTag(string text, object tag)
	{
		Text = text;
		Tag = tag;
	}

	public string Text { get; private set; }
	public object Tag { get; private set; }

	
	public override string ToString()
	{
		return Text;
	}
}


