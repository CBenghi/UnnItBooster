﻿using NPOI.OpenXmlFormats.Dml.Chart;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnnItBooster.Models;

namespace UnnFunctions.Models.DelegatedMarks;

public class DelegatedMarkResponse
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
		public string SubmissionId { get; set; } = "";
		public List<ComponentMark> Components { get; set; } = new();
	}

	public string MarkerEmail { get; set; }
	public string StudentId { get; set; }

	public int GetMark()
	{
		return Response.Components.Sum(x => x.Mark);
	}


	public MarkerResponse Response { get; } = new();

	public DelegatedMarkResponse(string markerEmail, string studentId, MarkerResponse response)
	{
		MarkerEmail = markerEmail;
		StudentId = studentId;
		Response = response;
	}

	public DelegatedMarkResponse(string markerEmail, string studentId, string submissionId, string comment, IEnumerable<ComponentMark> components)
	{
		MarkerEmail = markerEmail;
		StudentId = studentId;
		Response.SubmissionId = submissionId;
		Response.Comment = comment;
		Response.Components = components.ToList();
	}

	public static IEnumerable<DelegatedMarkResponse> GetMarks(int componentCount, XSSFWorkbook workbook, out string report)
	{
		ISheet sheet = workbook.GetSheet("Project marks");

		if (sheet is null)
			return RetError("Marks sheet not found", out report);
		var ret = new List<DelegatedMarkResponse>();
		var row = sheet.GetRow(0);
		var sheetMarkerMail = string.Empty;
		var firstCell = row?.GetCell(2);
		if (firstCell is not null)
			sheetMarkerMail = firstCell.StringCellValue.Trim();
		row = sheet.GetRow(4);
		var t = GetComponentsMax(row, componentCount);
		if (t is null)
			return RetError("No max values", out report);
		int rowId = 7;
		List<string> studentIds = new List<string>();
		do
		{
			var studRow = sheet.GetRow(rowId++);
			if (studRow == null)
				break;
			var thisRowMarker = sheetMarkerMail;
			if (string.IsNullOrWhiteSpace(sheetMarkerMail))
			{
				var h = GetMarker(studRow);
				if (h is null)
					continue;
				thisRowMarker = h;
			}
			var stud = GetStudent(studRow);
			if (stud is null)
				break;
			string submissionID = GetCellString(studRow, 3) ?? "";
			var marks = GetStudentMarks(studRow, t.Count);
			if (marks is null)
				continue;
			var comment = GetComment(studRow, t.Count);
			var mks = ComponentMark.GetMarks(marks, t);
			if (mks is null)
				continue;
			var newV = new DelegatedMarkResponse(thisRowMarker, stud, submissionID, comment, mks);
			ret.Add(newV);
		} while (true);

		report = "";
		return ret;
	}

	private static string? GetMarker(IRow studRow)
	{
		string ret = GetCellString(studRow, 0);
		if (string.IsNullOrEmpty(ret))
		{
			return null;
		}
		return ret;
	}

	private static string GetComment(IRow studRow, int count)
	{
		return GetCellString(studRow, count + 5);
	}

	private static List<int>? GetStudentMarks(IRow studRow, int count)
	{
		int iCol = 5;
		var marks = new List<int>();
		for (int i = 0; i < count; i++)
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
		if (cell is null)
			return "";
		var ret = "";
		if (cell.CellType == CellType.String)
			ret = cell.StringCellValue;
		else if (cell.CellType == CellType.Numeric)
			ret = cell.NumericCellValue.ToString();
		return ret;
	}

	private static List<int>? GetComponentsMax(IRow row, int componentCount)
	{
		var ret = new List<int>();
		int i = 5;
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

	private static IEnumerable<DelegatedMarkResponse> RetError(string reportVal, out string report)
	{
		report = reportVal;
		return Enumerable.Empty<DelegatedMarkResponse>();
	}

	public static string Report(IEnumerable<DelegatedMarkResponse> marks, bool extended = false, IEnumerable<string>? componentNames = null)
	{
		var sb = new StringBuilder();
		if (extended)
		{
			sb.AppendLine("## Received Marks\r\n");
		}
		if (componentNames is not null)
		{
			var concatenatedCompNames = string.Join(" | ", componentNames.Skip(1));
			var tableSpacer = string.Join(" | ", componentNames.Skip(1).Select(x => " :---: "));
			if (!string.IsNullOrEmpty(concatenatedCompNames))
			{
				sb.AppendLine($"| marker role | total mark | {concatenatedCompNames} | marker |");
				sb.AppendLine($"| --- | :---: | {tableSpacer} | --- |");
			}
		}
		foreach (var response in marks)
		{
			var tabComponents = string.Join(" | ", response.Response.Components.Select(x => x.ToString()));
			var comm = string.IsNullOrWhiteSpace(response.Response.Comment) ? "<no comment>" : response.Response.Comment;
			if (response is DelegatedMarkResponseFull fullResp)
			{
				sb.AppendLine(
					extended
					? $"| {fullResp.MarkerRole} | {response.GetMark()} | {tabComponents} | {response.MarkerEmail} |"
					: $"| {response.MarkerEmail} | {response.GetMark()} | {response.StudentId} | {tabComponents} | {comm} |"
					);
			}
			else
			{
				sb.AppendLine(
					extended
					? $"| {response.GetMark()} | {tabComponents} | {response.MarkerEmail} |"
					: $"| {response.MarkerEmail} | {response.GetMark()} | {response.StudentId} | {tabComponents} | {comm} |"
					);
			}
		}
		if (extended)
		{
			sb.AppendLine();
			sb.AppendLine(ModuleResult.Describe(marks.Select(x => x.GetMark())));

			sb.AppendLine();
			sb.AppendLine("Comments:");
			foreach (var response in marks)
			{
				if (string.IsNullOrWhiteSpace(response.Response.Comment))
					continue;
				var comm = string.IsNullOrWhiteSpace(response.Response.Comment) ? "<no comment>" : response.Response.Comment;
				sb.AppendLine(
					response is DelegatedMarkResponseFull fullResp
					? $"{response.MarkerEmail}\t{fullResp.MarkerRole}:\r\n{comm}\r\n"
					: $"{response.MarkerEmail}:\r\n{comm}\r\n"
					);
			}
		}
		return sb.ToString();
	}

	public static string ReportOutcomeSimulation(List<DelegatedMarkResponseFull> delegMarks, IEnumerable<ModuleResult> transcriptResults, int credits, int assignedMark = -1)
	{
		var sb = new StringBuilder();

		sb.AppendLine($"Simulation assuming {credits} credits");

		foreach (var response in delegMarks)
		{
			var mark = response.GetMark();
			var ret = ReportOption(transcriptResults, credits, mark, response.MarkerRole, out _);
			sb.AppendLine(ret);
		}
		if (delegMarks.Any())
		{
			var delegAverage = delegMarks.Select(x => x.GetMark()).Average();
			sb.AppendLine(ReportOption(transcriptResults, credits, delegAverage, "markers average", out _));
		}
		sb.AppendLine();
		sb.AppendLine("Marking range sensitivity analysis");
		sb.AppendLine(ReportOption(transcriptResults, credits, 50, "if bare pass", out var prevClassification));
		for (int i = 51; i <= 100; i++)
		{
			var buffer = ReportOption(transcriptResults, credits, i, "next level up", out var thisClassification);
			if (thisClassification != prevClassification || i == 100)
			{
				sb.AppendLine(buffer);
				prevClassification = thisClassification;
			}
			if (prevClassification == "Distinction")
				break;
		}
		if (assignedMark != -1)
		{
			sb.AppendLine();
			sb.AppendLine("=============");
			sb.AppendLine("Current mark:");
			sb.AppendLine(ReportOption(transcriptResults, credits, assignedMark, "Assigned mark", out _));
			var tmp = transcriptResults.Concat([new ModuleResult()
			{
				 ActualMark = assignedMark.ToString(),
				 Level = "7",
				 ActualResult = "P",
				 Credits = credits.ToString()
			}]
			);
			sb.AppendLine(Student.ReportTranscriptClassificationChart(tmp));
		}
		return sb.ToString();
	}

	private static string ReportOption(IEnumerable<ModuleResult> startingMarks, int credits, double mark, string optionName, out string classification)
	{
		int integerMark = (int)Math.Ceiling(mark);
		if (integerMark < 50)
		{
			classification = "FAIL";
			string failReport = $"option: {integerMark}, Average: N/A over N/A total credits, {optionName}\t{classification}";
			return failReport;
		}
		var tmpRes = new ModuleResult() { AgreedMark = integerMark.ToString(), Credits = credits.ToString() };
		var range = startingMarks.Concat([tmpRes]);
		var average = ModuleResult.WeightedAverage(range, out var matCred, out classification, out var compensatedCode);
		string thisReport = $"option: {integerMark}, Average: {average:0.00} over {matCred} total credits, {optionName}\t{classification}";
		if (compensatedCode != string.Empty)
			thisReport = $"option: {integerMark}, Average: {average:0.00} over {matCred} total credits, {optionName}\t{classification}, compensated on {compensatedCode}";
		return thisReport;
	}


}
