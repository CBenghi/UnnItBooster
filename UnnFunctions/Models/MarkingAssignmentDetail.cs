namespace StudentsFetcher.StudentMarking;

/// <summary>
/// details of the assignment of a single submission to a marker
/// </summary>
public class MarkingAssignmentDetail
{
	public MarkingAssignmentDetail(string studentId, string studentPaper, string studentPortal, string markingRole, string studentEmail)
	{
		StudentId = studentId;
		SubmissionId = studentPaper;
		ElpId = studentPortal;
		MarkingRole = markingRole;
		StudentEmail = studentEmail;
	}

	public string StudentId { get; set; }
	public string SubmissionId { get; set; }
	public string StudentEmail { get; set; }
	public string ElpId { get; set; }
	public string MarkingRole { get; set; }
}
