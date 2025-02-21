namespace UnnFunctions.Models.DelegatedMarks;

public class DelegatedMarkResponseFull : DelegatedMarkResponse
{
	public DelegatedMarkResponseFull(string markerName, string markerRole, string markerEmail, string studentId, MarkerResponse response)
		: base(markerEmail, studentId, response)
	{
		MarkerName = markerName;
		MarkerRole = markerRole;
	}
	public string MarkerName { get; set; }
	public string MarkerRole { get; set; }

}
