using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using StudentsFetcher.StudentMarking;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions;

internal class TurnItIn
{
	internal static IEnumerable<Student> GetStudentsFromGradebook(string csvSource)
	{
		// open the file "data.csv" which is a CSV file with headers
		List<Student> students = new List<Student>();
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
				"SUB_TurnitinUserID text, " +
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

			sql = "CREATE TABLE IF NOT EXISTS TB_Submissions (" +
				"SUB_ID INTEGER PRIMARY KEY, " +
				"SUB_LastName text, " +
				"SUB_FirstName text, " +
				"SUB_UserID text, " +
				"SUB_TurnitinUserID text, " +
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

	private class SqlCouple
	{
		public SqlCouple(string fld, string val)
		{
			Field = fld;
			Value = val;
		}
		public string Field { get; set; }
		public string Value { get; set; }

		internal string GetValue()
		{
			return "'" + Value.Replace("'", "''") + "'";
		}
		internal string GetSetCommand()
		{
			return $"{Field} = {GetValue()}";
		}
	}

	internal static IEnumerable<TurnitInSubmission> GetSubmissionsFromLearningAnalytics(FileInfo learningAnalytics)
	{
		var repo = StudentsRepository.GetRespository();

		using var package = new ExcelPackage(learningAnalytics);
		// prepare question dictionary
		List<TurnitInSubmission> lst = new List<TurnitInSubmission>();
		UpdateStudentInfo(ref lst, package, repo);
		UpdateStudentSubmissionId(ref lst, package, repo);
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
		var stude = repo.Students.FirstOrDefault(x => x.Email == seek.Email);
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
		int i = 0;
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
			var vc = GetSqlCouples(item);
			var flds = string.Join(", ", vc.Select(x => x.Field));
			var vals = string.Join(", ", vc.Select(x => x.GetValue()));
			var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
			var cmd = new SQLiteCommand(sql, c);
			cmd.ExecuteNonQuery();
		}
		c.Close();
	}

	internal static void UpdateDatabase(string fullname, List<TurnitInSubmission> submissions)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");
		if (!File.Exists(filename))
			return;

		using var c = new SQLiteConnection("Data source=" + filename + ";");
		c.Open();
		var ids = "select SUB_email from TB_Submissions";
		var existingEmails = MarkingConfig.GetVector(ids, c);
		foreach (var item in submissions)
		{
			var vc = GetSqlCouples(item);
			if (existingEmails.Contains(item.Email))
			{
				// update
				var flds = string.Join(", ", vc.Select(x => x.GetSetCommand()));
				var sql = $"UPDATE TB_Submissions SET {flds} WHERE SUB_email = '{item.Email}'";
				var cmd = new SQLiteCommand(sql, c);
				cmd.ExecuteNonQuery();
			}
			else
			{
				// insert
				var flds = string.Join(", ", vc.Select(x => x.Field));
				var vals = string.Join(", ", vc.Select(x => x.GetValue()));
				var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
				var cmd = new SQLiteCommand(sql, c);
				cmd.ExecuteNonQuery();
			}
		}
		c.Close();
	}

	private static SqlCouple[] GetSqlCouples(TurnitInSubmission item)
	{
		return new[] {
			new SqlCouple("SUB_LastName", item.LastName),
			new SqlCouple("SUB_FirstName", item.FirstName),
			new SqlCouple("SUB_UserID",  item.UserId),
			new SqlCouple("SUB_TurnitinUserID",  item.TurnitinUserId),
			new SqlCouple("SUB_Title",  item.Title),
			new SqlCouple("SUB_PaperID", item.PaperId),
			new SqlCouple("SUB_DateUploaded",  item.DateUploaded),
			new SqlCouple("SUB_Grade",  item.Grade),
			new SqlCouple("SUB_Overlap",  item.Overlap),
			new SqlCouple("SUB_InternetOverlap",  item.InternetOverlap),
			new SqlCouple("SUB_PublicationsOverlap",  item.PublicationsOverlap),
			new SqlCouple("SUB_StudentPapersOverlap",  item.StudentPapersOverlap),
			new SqlCouple("SUB_NumericUserID",  item.NumericUserId),
			new SqlCouple("SUB_email", item.Email)
			};
	}
}
