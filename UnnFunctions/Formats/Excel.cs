using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace UnnFunctions.Formats
{
	public static class Excel
	{
		public static string GetCellText(this ISheet sheet, string cellRef)
		{
			// Convert "C3" to column index 2, row index 2 (0-based)
			var match = Regex.Match(cellRef.ToUpper(), @"^([A-Z]+)(\d+)$");
			if (!match.Success)
			{
				Debug.WriteLine($"Invalid cell reference: {cellRef}");
				return "";
			}

			string colLetters = match.Groups[1].Value;
			int rowIndex = int.Parse(match.Groups[2].Value) - 1;

			int colIndex = 0;
			foreach (char c in colLetters)
			{
				colIndex = colIndex * 26 + (c - 'A' + 1);
			}
			colIndex--; // convert to 0-based

			var row = sheet.GetRow(rowIndex);
			var cell = row?.GetCell(colIndex);
			return cell?.ToString() ?? ""; // or use a more precise cell value method
		}

		public static ISheet GetSheetByName(this IWorkbook excel, string sheetName)
		{
			var t = excel.GetSheet(sheetName);
			return t;
		}

		public static IWorkbook OpenWorkbook(FileInfo fileInfo)
		{
			var filePath = fileInfo.FullName;
			using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				if (Path.GetExtension(filePath).Equals(".xls", StringComparison.OrdinalIgnoreCase))
				{
					return new HSSFWorkbook(file);
				}
				else if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
				{
					return new XSSFWorkbook(file);
				}
				else
				{
					throw new ArgumentException("The file is not a valid Excel file (.xls or .xlsx).");
				}
			}
		}


	}
}
