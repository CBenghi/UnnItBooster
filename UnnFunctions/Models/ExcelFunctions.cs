using NPOI.XSSF.UserModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace UnnFunctions.Models
{
	public class ExcelFunctions
	{
		public static bool TryReadExcel(string excelName, [NotNullWhen(true)] out XSSFWorkbook? hssfwb, out string report)
		{
			var fi = new FileInfo(excelName);
			if (!fi.Exists)
			{
				hssfwb = null;
				report = $"File not found '{excelName}'";
				return false;
			}
			if (IsFileLocked(fi))
			{
				hssfwb = null;
				report = $"File is locked '{excelName}'";
				return false;
			}
			using var file = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
			hssfwb = new XSSFWorkbook(file);
			file.Close();
			report = "Ok";
			return true;
		}

		static bool IsFileLocked(FileInfo file)
		{
			try
			{
				using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
				stream.Close();
			}
			catch (IOException)
			{
				//the file is unavailable because it is:
				//still being written to
				//or being processed by another thread
				//or does not exist (has already been processed)
				return true;
			}

			//file is not locked
			return false;
		}
	}
}
