using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using StudentsFetcher.StudentMarking;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions;

internal partial class TurnItIn
{
	public const string GradebookStandardName = "Coursework submission-Learning Analytics.xlsx";

	internal static IEnumerable<Student> GetStudentsFromGradebook(string csvSource)
	{
		// open the file "data.csv" which is a CSV file with headers
		var students = new List<Student>();
		using (var csv = new CachedCsvReader(new StreamReader(csvSource), true))
		{
			// Field headers will automatically be used as column names
			var iLast = csv.GetFieldIndex("Last Name");
			var iFirst = csv.GetFieldIndex("First Name");
			var idWithW = csv.GetFieldIndex("Username");

			if (iLast == -1
				|| iFirst == -1
				|| idWithW == -1
				)
				return Enumerable.Empty<Student>();

			foreach (var row in csv)
			{
				var student = new Student
				{
					Surname = row[iLast],
					Forename = row[iFirst],
					NumericStudentId = row[idWithW]
				};
				if (!student.NumericStudentId.StartsWith("sgmk2"))
					students.Add(student);
			}
		}
		return students;
	}

	private static void CreateDatabase(string fullname)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");
		var c = new SQLiteConnection("Data source=" + filename + ";");
		SQLiteCommand cmd;
		string sql;
		c.Open();
		try
		{
			cmd = new SQLiteCommand(c);

			sql = "CREATE TABLE IF NOT EXISTS TB_Submissions (" +
				"SUB_ID INTEGER PRIMARY KEY, " +
				"SUB_LastName text, " +
				"SUB_FirstName text, " +
				"SUB_UserID text, " +
				"SUB_NumericUserID text, " +
				"SUB_email text, " +
				"SUB_Title text, " +
				"SUB_PaperID text, " +
				"SUB_DateUploaded text, " +
				"SUB_Grade text, " +
				"SUB_Overlap text, " +
				"SUB_InternetOverlap text, " +
				"SUB_PublicationsOverlap text, " +
				"SUB_StudentPapersOverlap text" +
				")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "CREATE TABLE IF NOT EXISTS TB_Marks (" +
				"MARK_ID INTEGER PRIMARY KEY, " +
				"MARK_ptr_Submission INT, " +
				"MARK_ptr_Component INT, " +
				"MARK_Value INT, " +
				"MARK_Date DATETIME" +
				")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "CREATE TABLE IF NOT EXISTS TB_Comments (" +
				 "COMM_ID INTEGER PRIMARY KEY, " +
				 "COMM_Section text, " +
				 "COMM_Area text, " +
				 "COMM_Text text" +
				 ")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "CREATE TABLE IF NOT EXISTS TB_SubComments (" +
				 "SCOM_ID INTEGER PRIMARY KEY, " +
				 "SCOM_ptr_Submission INTEGER, " +
				 "SCOM_ptr_Comment INTEGER, " +
				 "SCOM_ptr_Component INTEGER, " +
				 "SCOM_AddNote text" +
				 ")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "CREATE TABLE IF NOT EXISTS TB_Components (" +
				 "CPNT_ID INTEGER PRIMARY KEY, " +
				 "CPNT_Order INTEGER, " +
				 "CPNT_Name TEXT, " +
				 "CPNT_Percent INTeger, " +
				 "CPNT_Comment TEXT" +
				 ")";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			sql = "CREATE VIEW if not exists QComments AS " +
				"SELECT * FROM (TB_SubComments INNER JOIN TB_Comments " +
				"on SCOM_ptr_Comment = COMM_ID) left join TB_Components " +
				"on SCOM_ptr_Component = CPNT_ID";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
		}
		catch { }
		c.Close();
	}

	internal static IEnumerable<TurnitInSubmission> GetSubmissionsFromLearningAnalytics(FileInfo learningAnalytics)
	{
		using var package = new ExcelPackage(learningAnalytics);
		// prepare question dictionary
		var lst = new List<TurnitInSubmission>();
		UpdateStudentInfo(ref lst, package, StudentsRepository.Repo);
		UpdateStudentSubmissionId(ref lst, package, StudentsRepository.Repo);
		return lst;
	}

	private static void UpdateStudentSubmissionId(ref List<TurnitInSubmission> lst, ExcelPackage package, StudentsRepository repo)
	{
		// Rubric Form - Qualitative
		var table = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Rubric Form - Qualitative");
		if (table is null)
			return;

		if (table.Cells[$"B1"].Text != "Email")
			return;
		if (table.Cells[$"C1"].Text != "Paper id")
			return;

		int i = 2;
		while (true)
		{
			var email = table.Cells[$"B{i}"].Text;
			if (string.IsNullOrEmpty(email))
				return;
			var seek = lst.FirstOrDefault(x => x.Email == email);
			if (seek is null)
			{
				seek = new TurnitInSubmission();
				lst.Add(seek);
			}

			seek.Email = table.Cells[$"B{i}"].Text;
			seek.PaperId = table.Cells[$"C{i}"].Text;
			SyncStudentProperties(repo, seek);
			i++;
		}
	}

	private static void SyncStudentProperties(StudentsRepository repo, TurnitInSubmission seek)
	{
		var stude = repo.Students.FirstOrDefault(x => x.HasEmail(seek.Email));
		if (stude is null)
		{
			stude = repo.Students.FirstOrDefault(x => x.FullName is not null && x.FullName.Equals(seek.FullName, System.StringComparison.OrdinalIgnoreCase));
			if (stude != null)
				repo.AddAlternativeEmail(stude, seek.Email);
		}
		if (stude is not null)
		{
			if (!string.IsNullOrEmpty(stude.Forename))
				seek.FirstName = stude.Forename!;
			if (!string.IsNullOrEmpty(stude.Surname))
				seek.LastName = stude.Surname!;
			if (!string.IsNullOrEmpty(stude.NumericStudentId))
			{
				seek.UserId = stude.NumericStudentId;
				seek.NumericUserId = stude.NumericStudentId;
			}
		}
	}

	private static void UpdateStudentInfo(ref List<TurnitInSubmission> lst, ExcelPackage package, StudentsRepository repo)
	{
		var table = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Submissions");
		if (table is null)
			return;
		int i = 1;
		do
		{
			var magicNumber = table.Cells[$"A{i}"].Text;
			if (magicNumber == "Student submissions")
				break;
			i++;
		} while (i < 100);

		if (i == 100)
			return;
		i += 2; // skip headers

		while (true)
		{
			var email = table.Cells[$"B{i}"].Text;
			if (string.IsNullOrEmpty(email))
				return;
			var seek = lst.FirstOrDefault(x => x.Email == email);
			if (seek is null)
			{
				seek = new TurnitInSubmission();
				lst.Add(seek);
			}
			seek.FullName = table.Cells[$"A{i}"].Text;
			seek.Email = table.Cells[$"B{i}"].Text;
			seek.DateUploaded = table.Cells[$"C{i}"].Text;
			seek.Overlap = table.Cells[$"D{i}"].Text;
			seek.InternetOverlap = table.Cells[$"E{i}"].Text;
			seek.PublicationsOverlap = table.Cells[$"F{i}"].Text;
			seek.StudentPapersOverlap = table.Cells[$"G{i}"].Text;

			SyncStudentProperties(repo, seek);
			i++;
		}
	}

	internal static void PopulateDatabase(string fullname, IEnumerable<TurnitInSubmission> submissions)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");

		if (!File.Exists(filename))
			CreateDatabase(fullname);

		var c = new SQLiteConnection("Data source=" + filename + ";");
		c.Open();
		foreach (var item in submissions)
		{
			var vc = TurnitInSubmission.GetSqlCouples(item);
			var flds = string.Join(", ", vc.Select(x => x.Field));
			var vals = string.Join(", ", vc.Select(x => x.GetValue()));
			var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
			var cmd = new SQLiteCommand(sql, c);
			cmd.ExecuteNonQuery();
		}
		c.Close();
	}

	internal static string UpdateDatabase(string fullname, List<TurnitInSubmission> submissions)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");
		if (!File.Exists(filename))
			return "not found";

		using var c = new SQLiteConnection("Data source=" + filename + ";");
		c.Open();
		var ids = "select SUB_email from TB_Submissions";
		var existingEmails = MarkingConfig.GetVector(ids, c);

		int prevCount = existingEmails.Count;
		int tallyUpdate = 0;
		int tallyAdd = 0;

		var sb = new StringBuilder();

		foreach (var item in submissions)
		{
			var vc = TurnitInSubmission.GetSqlCouples(item).Where(x => !string.IsNullOrWhiteSpace(x.Value));
			if (existingEmails.Contains(item.Email))
			{
				// update
				var flds = string.Join(", ", vc.Select(x => x.GetSetCommand()));
				var sql = $"UPDATE TB_Submissions SET {flds} WHERE SUB_email = '{item.Email}'";
				var cmd = new SQLiteCommand(sql, c);
				cmd.ExecuteNonQuery();
				tallyUpdate++;
				sb.AppendLine($"{item.Email} updated");
			}
			else
			{
				// insert
				var flds = string.Join(", ", vc.Select(x => x.Field));
				var vals = string.Join(", ", vc.Select(x => x.GetValue()));
				var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
				var cmd = new SQLiteCommand(sql, c);
				cmd.ExecuteNonQuery();
				tallyAdd++;
				sb.AppendLine($"{item.Email} added");
			}
		}
		c.Close();
		sb.AppendLine($"===");
		sb.AppendLine($"Existing: {prevCount}");
		sb.AppendLine($"Modified: {tallyUpdate}");
		sb.AppendLine($"Added   : {tallyAdd}");
		sb.AppendLine($"Total   : {tallyUpdate + tallyAdd}");
		return sb.ToString();
	}

	internal static IEnumerable<SubmittedFile> GetFilesFromManifest(FileInfo manifest)
	{
		if (!manifest.Exists)
			yield break;
		var lines = File.ReadAllLines(manifest.FullName);
		var processFiles = false;
		var split = new[] { " - SUCCESS" };
		foreach (var line in lines)
		{
			if (processFiles == true)
			{
				var procline = line.Trim();
				if (!procline.EndsWith(" - SUCCESS"))
					continue;
				var t = procline.Split(split, System.StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
				if (t == null)
					continue;
				var fullPath = Path.Combine(manifest.Directory.FullName, t);
				if (!File.Exists(fullPath))
					continue;
				var subId = t.Substring(0, t.IndexOf(" "));
				yield return new SubmittedFile(fullPath, subId);
			}
			else if (line == "Files")
				processFiles = true;
		}
	}
}
