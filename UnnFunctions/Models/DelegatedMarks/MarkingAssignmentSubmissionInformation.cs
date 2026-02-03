using System.Data;
using System;

namespace UnnFunctions.Models.DelegatedMarks;

/// <summary>
/// details of the assignment of a single submission to a marker
/// </summary>
public class MarkingAssignmentSubmissionInformation
{
	public MarkingAssignmentSubmissionInformation(string studentId, string studentPaper, string studentPortal, string markingRole, string studentEmail, string markerEmail)
	{
		StudentId = string.IsNullOrWhiteSpace(studentId) ? "<missing id>" : studentId;
		SubmissionId = string.IsNullOrWhiteSpace(studentPaper) ? "<missing submission>" : studentPaper;
		ElpId = studentPortal;
		MarkingRole = markingRole;
		StudentEmail = studentEmail;
		MarkerEmail = markerEmail;
	}

	public string StudentId { get; set; }
	public string SubmissionId { get; set; }
	public string StudentEmail { get; set; }
	public string MarkerEmail { get; set; }
	public string ElpId { get; set; }
	public string MarkingRole { get; set; }

	public static MarkingAssignmentSubmissionInformation GetFromDataRow(DataRow row, out string markMail, out string markName)
	{
		markMail = row["MRKR_MarkerEmail"].ToString()!;
		markName = row["MRKR_MarkerName"].ToString()!;
		var studentId = row["MRKR_ptr_SubmissionUserID"] is not DBNull ? row["MRKR_ptr_SubmissionUserID"].ToString()! : "<missing id>";
		var studentPaper = row["SUB_PaperID"] is not DBNull ? row["SUB_PaperID"].ToString()! : "<missing submission>";
		var studentPortal = row["SUB_ElpSite"] is not DBNull ? row["SUB_ElpSite"].ToString()! : "<undefined>";
		var markerRole = row["MRKR_MarkerRole"] is not DBNull ? row["MRKR_MarkerRole"].ToString()! : "<undefined role>";
		var studentEmail = row["SUB_email"] is not DBNull ? row["SUB_email"].ToString()! : "<undefined email>";
		var thisRow = new MarkingAssignmentSubmissionInformation(
			studentId, studentPaper, studentPortal, markerRole, studentEmail, markMail
			);
		return thisRow;
	}
}
