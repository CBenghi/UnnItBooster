namespace UnnItBooster.ModelConversions;

internal class SqlCouple
{
	public SqlCouple(string fld, string val)
	{
		Field = fld;
		Value = val;
	}
	public string Field { get; set; }
	public string Value { get; set; }

	internal string GetValue()
	{
		return "'" + Value.Replace("'", "''") + "'";
	}
	internal string GetSetCommand()
	{
		return $"{Field} = {GetValue()}";
	}
}

	
