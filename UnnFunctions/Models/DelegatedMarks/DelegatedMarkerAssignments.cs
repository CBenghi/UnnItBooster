using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnnFunctions.Models.DelegatedMarks;

/// <summary>
/// Defines the assignment of submission to a single marker identified by name and email
/// </summary>
public class DelegatedMarkerAssignments
{
	public DelegatedMarkerAssignments(string markMail, string markName)
	{
		MarkerEmail = markMail;
		MarkerName = markName;
	}

	public string MarkerEmail { get; set; }
	public string MarkerName { get; set; }
	public List<MarkingAssignmentSubmissionInformation> Details { get; set; } = new();

	internal void Add(MarkingAssignmentSubmissionInformation markingAssignmentDetail)
	{
		Details.Add(markingAssignmentDetail);
	}

	internal string FixFile(FileInfo dest, int componentCount)
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Preparing {dest.Name}.");
		using var readFile = new FileStream(dest.FullName, FileMode.Open, FileAccess.Read);
		var workbook = new XSSFWorkbook(readFile);
		readFile.Close();
		ISheet sheet = workbook.GetSheetAt(0);
		IRow row = sheet.GetRow(0);
		ICell cell = row.GetCell(2);
		cell.SetCellValue(MarkerEmail);

		ICellStyle unlockedCellStyle = workbook.CreateCellStyle();
		unlockedCellStyle.IsLocked = false;

		int iRow = 7; // starting at row 8
					  // if we are updating an existing file we need not write the
					  // row if has already the marks

		// get all the student IDs already written

		var outstandingDetails = Details.ToList();
		const int RowMax = 39;
		while (iRow < RowMax)
		{
			row = sheet.GetRow(iRow);
			var studentId = row.GetCell(2).StringCellValue;
			if (studentId != null && studentId.Length > 0)
			{
				var existing = outstandingDetails.FirstOrDefault(d => $"w{d.StudentId}" == studentId);
				if (existing != null)
				{
					// already there so remove from the list
					//
					outstandingDetails.Remove(existing);
				}
			}
			else
			{
				// we have reached a blank row so stop looking
				//
				break;
			}
			iRow++;
		}
		
		foreach (var det in outstandingDetails)
		{
			row = sheet.GetRow(iRow++);
			row.GetCell(1).SetCellValue(det.ElpId);
			row.GetCell(2).SetCellValue($"w{det.StudentId}");
			row.GetCell(3).SetCellValue(det.StudentEmail);
			row.GetCell(4).SetCellValue(det.SubmissionId);

			// the marking cells need to be unlocked
			//
			for (int i = 0; i < componentCount; i++)
			{
				var thiscell = row.GetCell(5 + i);
				if (thiscell != null)
					thiscell.CellStyle = unlockedCellStyle;
				else
					sb.AppendLine($"problem with null cell at row: {iRow - 1} col: {5+i}");
			}

			// get the cell style of the comment and make it unlocked
			//

			var commentCell = row.GetCell(5 + componentCount);
			var newCellStyle = workbook.CreateCellStyle();
			newCellStyle.CloneStyleFrom(commentCell.CellStyle);
			newCellStyle.IsLocked = false;
			commentCell.CellStyle = newCellStyle;
		}
		// sheet.ShiftRows(39, 39, iRow - 39, true, false);
		while (iRow < RowMax)
		{
			row = sheet.GetRow(iRow++);
			// 11 includes the comment
			for (int i = 0; i < 7; i++)
			{
				var thiscell = row.GetCell(5 + componentCount + i);
				thiscell.SetBlank();
			}
		}
		//sheet.ProtectSheet(""); // locks all cells except the unlocked
		dest.Delete();
		using var file = new FileStream(dest.FullName, FileMode.Create, FileAccess.Write);
		workbook.Write(file, false);

		return sb.ToString();
	}
}

