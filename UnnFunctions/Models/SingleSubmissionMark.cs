using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using System.Drawing.Drawing2D;

namespace UnnFunctions.Models;

public class SingleSubmissionMark
{
	public class ComponentMark
	{
		public int Mark { get; set; }
		public int OutOf { get; set; }

		public override string ToString()
		{
			var t = OutOf.ToString().Length;
			var mk = Mark.ToString().PadLeft(t);
			return $"{mk}/{OutOf}";
		}

		public static List<ComponentMark>? GetMarks(IList<int> marks, IList<int> maxValues)
		{
			if (marks.Count != maxValues.Count)
				return null;
			var mks = new List<ComponentMark>();
			for (int i = 0; i < marks.Count; i++)
			{
				mks.Add(new ComponentMark() { Mark = marks[i], OutOf = maxValues[i] });
			}
			return mks;
		}
	}

	public class MarkerResponse
	{
		public string Comment { get; set; } = "";
		public List<ComponentMark> Components { get; set; } = new();
	}

	public string MarkerEmail { get; set; }
	public string StudentId { get; set; }
	public string SubmissionId { get; set; }

	public int GetMark()
	{
		return Response.Components.Sum(x => x.Mark);
	}
	

	public MarkerResponse Response { get; } = new();

	public SingleSubmissionMark(string markerEmail, string studentId, string submissionId, string comment, IEnumerable<ComponentMark> components)
    {
		MarkerEmail = markerEmail;	
		StudentId = studentId;
		SubmissionId = submissionId;
		Response.Comment = comment;
		Response.Components = components.ToList();
	}

	public static IEnumerable<SingleSubmissionMark> GetMarks(XSSFWorkbook workbook, out string report)
	{
		ISheet sheet = workbook.GetSheet("Project marks");
		
		if (sheet is null)
			return RetError("Marks sheet not found", out report);
		var ret = new List<SingleSubmissionMark>();
		var row = sheet.GetRow(0);
		if (row == null) //null is when the row only contains empty cells 
			return RetError("No valid row 0", out report);
		var firstCell = row.GetCell(2);
		if (firstCell == null)
			return RetError("No valid marker email cell", out report);
		var markerMail = firstCell.StringCellValue;
		row = sheet.GetRow(4);
		var t = GetComponentsMax(row);
		if (t is null)
			return RetError("No max values", out report);
		int rowId = 7;
		List<string> studentIds = new List<string>();
		do
		{
			var studRow = sheet.GetRow(rowId++);
			if (studRow == null)
				break;
			var stud = GetStudent(studRow);
			if (stud is null)
				break;
			var marks = GetStudentMarks(studRow, t.Count);
			if (marks is null)
				continue;
			var comment = GetComment(studRow, t.Count);
			var mks = ComponentMark.GetMarks(marks, t);
			if (mks is null)
				continue;
			var newV = new SingleSubmissionMark(markerMail, stud, "", comment, mks);
			ret.Add(newV);
		} while (true);

		report = "";
		return ret;
	}

	private static string GetComment(IRow studRow, int count)
	{
		return GetCellString(studRow, count + 4);
	}

	private static List<int>? GetStudentMarks(IRow studRow, int count)
	{
		int iCol = 4;
		var marks = new List<int>();
		for (int i = 0; i<count; i++)
		{
			var cell = studRow.GetCell(iCol + i);
			if (cell is null || cell.CellType != CellType.Numeric)
				return null;
			marks.Add((int)cell.NumericCellValue);
		}
		if (marks.Count != count)
			return null;
		return marks;
	}

	private static string? GetStudent(IRow studRow)
	{
		string ret = GetCellString(studRow, 2);
		ret = ret.Trim(['w', ' ']);
		if (ret.Length != 8)
			return null;
		return ret;
	}

	private static string GetCellString(IRow studRow, int col)
	{
		var cell = studRow.GetCell(col);
		var ret = "";
		if (cell.CellType == CellType.String)
			ret = cell.StringCellValue;
		else if (cell.CellType == CellType.Numeric)
			ret = cell.NumericCellValue.ToString();
		return ret;
	}

	private static List<int>? GetComponentsMax(IRow row)
	{
		var ret = new List<int>();
		int i = 4;
		do
		{
			var cell = row.GetCell(i++);
			if (cell is null)
				return null;
			if (cell.CellType != CellType.Numeric)
				break;
			var componentValue = cell.NumericCellValue;
			ret.Add((int)componentValue);		
		} while (true);
		
		var checkcell = row.GetCell(i++);
		if (checkcell is null)
			return null;
		if (checkcell.CellType != CellType.Formula)
			return null;
		if (checkcell.NumericCellValue != 100)
			return null;
		return ret;
	}

	private static IEnumerable<SingleSubmissionMark> RetError(string reportVal, out string report)
	{
		report = reportVal;
		return Enumerable.Empty<SingleSubmissionMark>();
	}

	public static string Report(IEnumerable<SingleSubmissionMark> marks)
	{
		StringBuilder sb = new StringBuilder();
		foreach (SingleSubmissionMark mark in marks)
		{
			var mks = string.Join(
					"\t",
					mark.Response.Components.Select(x => x.ToString())
					);
			sb.AppendLine($"{mark.MarkerEmail}\t{mark.GetMark()}\t{mark.StudentId}\t{mks}\t{mark.Response.Comment}");
		}
		return sb.ToString();
	}
}
