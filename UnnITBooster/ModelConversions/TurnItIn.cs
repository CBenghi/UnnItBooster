using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using System;
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
				Student student = new Student();
				student.Surname = row[iLast];
				student.Forename = row[iFirst];
				student.NumericStudentId = row[idWithW];
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
	}

	internal static IEnumerable<TurnitInSubmission> GetSubmissionsFromLearningAnalytics(FileInfo learningAnalytics)
	{
		var repo = StudentsRepository.GetRespository();

		using (var package = new ExcelPackage(learningAnalytics))
		{
			// prepare question dictionary
			var table = package.Workbook.Worksheets.FirstOrDefault(x=>x.Name == "Submissions");
			if (table is null)
				yield break;

			int i = 0;
			do
			{
				var magicNumber = table.Cells[$"A{i}"].Text;
				if (magicNumber == "Student submissions")
					break;
				i++;
			} while (i < 100);
			
			if (i == 100)
				yield break;

			i += 2; // skip headers
			while (true)
			{
				var t  = new TurnitInSubmission();
				t.Email = table.Cells[$"B{i}"].Text;
				t.DateUploaded  = table.Cells[$"C{i}"].Text;
				t.Overlap = table.Cells[$"D{i}"].Text;
				t.InternetOverlap = table.Cells[$"E{i}"].Text;
				t.PublicationsOverlap = table.Cells[$"F{i}"].Text;
				t.StudentPapersOverlap = table.Cells[$"G{i}"].Text;
				if (string.IsNullOrEmpty(t.DateUploaded))
					yield break;

				var stude = repo.Students.FirstOrDefault(x => x.Email == t.Email);
				t.FirstName = stude.Forename;
				t.LastName = stude.Surname;
				t.UserId = stude.NumericStudentId;
				t.NumericUserId = stude.NumericStudentId;

				yield return t;
				i++;
			}
		}
		
	}

	internal static void PopulateDatabase(string fullname, IEnumerable<TurnitInSubmission> thestudents)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");

		if (!File.Exists(filename))
			CreateDatabase(fullname);
		
		var c = new SQLiteConnection("Data source=" + filename + ";");	
		c.Open();
		foreach (var item in thestudents)
		{
			var vc = new[]
			{
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
			var flds = string.Join(", ", vc.Select(x => x.Field));
			var vals = string.Join(", ", vc.Select(x => x.GetValue()));
			var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
			var cmd = new SQLiteCommand(sql, c);
			cmd.ExecuteNonQuery();
		}
		c.Close();
	}
}
