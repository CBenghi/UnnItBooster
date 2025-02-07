using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using StudentsFetcher.StudentMarking;
using UnnFunctions.Models;

namespace UnnItBooster.StudentMarking;

internal class ExcelPersistence
{
	private static string[] StandardHeaders = new string[] {
		"Prog",
		"StudentId",
		"Name",
		"Surname",
		"Email",
		"PaperId",
		"Marks",
	};

	private static string[] StandardHeadersBackField = new string[] {
		"SUB_ID",
		"SUB_NumericUserID",
		"SUB_FirstName",
		"SUB_LastName",
		"SUB_email",
		"SUB_PaperID",
	};

	public static void Write(MarkingConfig _config)
	{
		IWorkbook workbook = new XSSFWorkbook();
		ISheet sheet = workbook.CreateSheet("Marks");

		int iRow = 0;
		// header
		//
		IRow row = sheet.CreateRow(iRow++);
		int iCol = 0;
		foreach (var header in StandardHeaders)
		{
			ICell cell = row.CreateCell(iCol++);
			cell.SetCellValue(header);
		}
		int componentStart = iCol - 1;
		var comps = _config.GetMarkCalculator();
		// component headers
		row = sheet.CreateRow(iRow++);
		iCol = componentStart;
        foreach (var comp in comps.Marks)
        {
			ICell cell = row.CreateCell(iCol++);
			cell.SetCellValue($"{comp.id} - {comp.Name}");
		}
		var TotalMarkCol = iCol;

		// perc
		XSSFCellStyle percentageStyle = (XSSFCellStyle)workbook.CreateCellStyle();
		percentageStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0%");

		row = sheet.CreateRow(iRow++);
		iCol = componentStart;
		foreach (var comp in comps.Marks)
		{
			ICell cell = row.CreateCell(iCol++);
			cell.SetCellValue(comp.percent / 100.0);
			cell.CellStyle = percentageStyle;
		}

		// desc 
		XSSFCellStyle wrappedText = (XSSFCellStyle)workbook.CreateCellStyle();
		wrappedText.WrapText = true;
		row = sheet.CreateRow(iRow++);
		row.Height = (short)2300;
		iCol = componentStart;
		foreach (var comp in comps.Marks)
		{
			ICell cell = row.CreateCell(iCol++);
			cell.SetCellValue($"{comp.Description}");
			cell.CellStyle = wrappedText;
		}

		// individual marks
		//
		var students = _config.GetDataTable("select * from TB_Submissions");
		foreach (DataRow sourceRow in students.Rows)
		{
			row = sheet.CreateRow(iRow++);
			iCol = 0;
			iCol = WriteStudentInfo(row, iCol, sourceRow);
		}

		// format columns

		for (int i = 0; i < componentStart; i++) 
			sheet.AutoSizeColumn(i);
		for (int i = componentStart; i < TotalMarkCol; i++) 
			sheet.SetColumnWidth(i, 256 * 30);
		
		// writing (overwrites)
		var name = GetMarksFileName(_config);
		using var stream = new FileStream(name, FileMode.Create, FileAccess.Write);
		workbook.Write(stream, false);
	}

	private static int WriteStudentInfo(IRow row, int iCol, DataRow sourceRow)
	{
		foreach (var item in StandardHeadersBackField)
		{
			ICell cell = row.CreateCell(iCol++);
			cell.SetCellValue(sourceRow[item].ToString());
		}
		return iCol;
	}

	private static string GetMarksFileName(MarkingConfig config)
	{
		const string MarksFileName = "marks.xlsx";
		FileInfo f = new FileInfo(config.DbName);
		if (f.Exists)
		{
			return Path.Combine(f.Directory.FullName, MarksFileName);	
		}
		return string.Empty;
	}

	public class Component
	{
		public int ProgNumber { get; set; }
		public int ColNumber { get; set; }
	}

	internal static string ReadComponents(MarkingConfig config, string excelName)
	{
		if (!ExcelFunctions.TryReadExcel(excelName, out var excelWorkbook, out string report))
			return report;
		ISheet sheet = excelWorkbook.GetSheet("Marks");
		if (sheet is null)
			return $"Marks sheet not found in '{excelName}'";
		
		var sb = new StringBuilder();
		bool processing = false;
		int StudentCount = 0;
		int ComponentMarkCount = 0;
		var components = new List<Component>();
		for (int rowId = 0; rowId <= sheet.LastRowNum; rowId++)
		{
			var row = sheet.GetRow(rowId);
			if (row == null) //null is when the row only contains empty cells 
				continue;
			if (!processing)
			{
				var first = row.GetCell(0);
				if (first == null)
					continue;
				if (first.StringCellValue == "Prog")
				{
					processing = true;
					for (int colId = 1; colId < row.LastCellNum; colId++)
					{
						var cVal = row.GetCell(colId).StringCellValue;
						if (cVal.StartsWith("#"))
						{
							var cpVal = cVal.Substring(1);
							if (int.TryParse(cpVal, out var component))
							{
								sb.AppendLine($"Header #{component} on column {colId}"); ;
								components.Add(new Component() { ProgNumber = component, ColNumber = colId });
							}
						}
					}
				}
			}
			else
			{
				var studcell = row.GetCell(0);
				if (studcell == null)
					continue;
				var studProg = row.GetCell(0).StringCellValue;
				if (string.IsNullOrEmpty(studProg) || !int.TryParse(studProg, out var progId))
					continue;
				// var studId = row.GetCell(1).StringCellValue;
				bool thisStudent = false;
				foreach (var component in components)
				{
					var cell = row.GetCell(component.ColNumber);
					if (cell == null)
						continue;
					int mark = 0;
					if (cell.CellType == CellType.String)
					{
						var val = cell.StringCellValue;
						if (string.IsNullOrEmpty(val) || !int.TryParse(val, out mark))
							continue;
					}
					else if (cell.CellType == CellType.Numeric)
					{
						mark = Convert.ToInt32(cell.NumericCellValue);
					}
					else if (cell.CellType == CellType.Formula)
					{
						mark = Convert.ToInt32(cell.NumericCellValue);
					}
					else
						continue;
					config.SetStudentComponentMark(progId, component.ProgNumber, mark, true);					
					thisStudent = true;
					ComponentMarkCount++;
				}
				if (thisStudent)
					StudentCount++;
			}
		}
		if (!processing)
		{
			sb.AppendLine("No suitable headers");
		}
		else
		{
			sb.AppendLine($"Found {ComponentMarkCount} components in {StudentCount} different students");
		}
		return sb.ToString();
	}
}
