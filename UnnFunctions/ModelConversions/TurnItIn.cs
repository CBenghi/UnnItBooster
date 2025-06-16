using LumenWorks.Framework.IO.Csv;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using StudentsFetcher.StudentMarking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnnFunctions.Formats;
using UnnItBooster.Models;

namespace UnnItBooster.ModelConversions;

public partial class TurnItIn
{
	public const string GradebookStandardName = "Coursework submission-Learning Analytics.xlsx";

	public static IEnumerable<Student> GetStudentsFromGradebook(string csvSource)
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

	internal static DataTable GetData(SQLiteConnection c, string sql)
	{
		var dt = new DataTable();
		try
		{
			using var dbCommand = new SQLiteCommand(sql, c);
			using var da = new SQLiteDataAdapter(dbCommand);
			da.Fill(dt);
		}
		catch (Exception ex)
		{
			dt.TableName = "ErrorTable";
			dt.Columns.Add("ErrorName", typeof(string));
			var r = dt.NewRow();
			r[0] = ex.Message;
			dt.Rows.Add(r);
		}
		return dt;
	}

	private static bool EnsureField(SQLiteConnection c, string tableName, string fieldName, string fieldType, string fieldInit)
	{
		using var tab = GetData(c, "PRAGMA table_info(" + tableName + ");");
		if (tab.Rows.Count == 0)
			throw new Exception("Error in parsing SQLITE database structure.");

		if (!tab.Select($"name = '{fieldName}'").Any())
		{
			var sqlCreate = $"alter table {tableName} Add Column {fieldName} {fieldType}";
			ExecuteSql(c, sqlCreate);

			if (string.IsNullOrEmpty(fieldInit))
				return true;
			var sqlUpdate = $"update {tableName} set {fieldName} = {fieldInit}";
			ExecuteSql(c, sqlUpdate);
			return true;
		}
		return false;
	}

	private static void ExecuteSql(SQLiteConnection c, string sql)
	{
		using var cmd = new SQLiteCommand(c) { CommandText = sql };
		cmd.ExecuteNonQuery();
	}

	public static void UpgradeDatabase(SQLiteConnection c)
	{
		EnsureField(c, "TB_Submissions", "SUB_ElpSite", "TEXT default NULL", "NULL");
		ExecuteSql(c, TB_MarkersSql);
		EnsureField(c, "TB_Submissions", "SUB_ElpSite", "TEXT default NULL", "NULL");
		EnsureField(c, "TB_Markers", "MRKR_MarkerRole", "TEXT default NULL", "NULL");

		// ensure indices
		var sql = "CREATE INDEX IF NOT EXISTS sub_userid on TB_Submissions(SUB_UserID)";
		ExecuteSql(c, sql);

		ExecuteSql(c, createFullymarkedView);

	}

	public static void UpgradeDatabase(string fullname)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");
		using var c = new SQLiteConnection("Data source=" + filename + ";");
		UpgradeDatabase(c);
	}

	const string TB_MarkersSql = "CREATE TABLE IF NOT EXISTS TB_Markers (" +
				 "MRKR_ID INTEGER PRIMARY KEY, " +
				 "MRKR_ptr_SubmissionUserID TEXT, " +
				 "MRKR_MarkerEmail TEXT, " +
				 "MRKR_MarkerName TEXT, " +
				 "MRKR_MarkerRole TEXT, " +
				 "MRKR_Response TEXT " +
				 ")";

	private static void CreateDatabase(string fullname)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");
		using var c = new SQLiteConnection("Data source=" + filename + ";");
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
				"SUB_StudentPapersOverlap text," +
				"SUB_ElpSite text" +
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

			cmd.CommandText = TB_MarkersSql;
			cmd.ExecuteNonQuery();

			cmd.CommandText = createFullymarkedView;
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

	static string createFullymarkedView =
		"""
		CREATE VIEW if not exists QFullyMarkedPapers AS 
		SELECT MARK_ptr_Submission,
			(SELECT min(MARK_ptr_Component) = -1 FROM TB_Marks as SEC WHERE MAIN.MARK_ptr_Submission = SEC.MARK_ptr_Submission and MARK_ptr_Component < 0 ) AS HasMarkOverride,
			(SELECT count(MARK_ptr_Component) = (select count(*) from TB_Components)
			FROM TB_Marks as SEC WHERE MAIN.MARK_ptr_Submission = SEC.MARK_ptr_Submission and MARK_ptr_Component >0 ) AS HasAllComponents
		FROM TB_Marks as MAIN
		GROUP BY MARK_ptr_Submission
		HAVING HasMarkOverride = 1 OR HasAllComponents = 1
		""";

	public static IEnumerable<TurnitInSubmission> GetSubmissionsFromLearningAnalytics(FileInfo learningAnalytics, StudentsRepository repo)
	{
		using var learningAnalyticsPackage = Excel.OpenWorkbook(learningAnalytics);
		if (learningAnalyticsPackage is null)
			return Enumerable.Empty<TurnitInSubmission>();
		// prepare question dictionary
		var lst = new List<TurnitInSubmission>();
		UpdateStudentInfo(ref lst, learningAnalyticsPackage, repo);
		UpdateStudentSubmissionId(ref lst, learningAnalyticsPackage, repo);
		return lst;
	}

	private static void UpdateStudentSubmissionId(ref List<TurnitInSubmission> lst, IWorkbook package, StudentsRepository repo)
	{
		// Rubric Form - Qualitative
		var table = package.GetSheetByName("Rubric Form - Qualitative");
		if (table is null)
			return;

		if (table.GetCellText("B1") != "Email")
			return;
		if (table.GetCellText("C1") != "Paper id")
			return;

		int i = 2;
		while (true)
		{
			var email = table.GetCellText($"B{i}");
			if (string.IsNullOrEmpty(email))
				return;
			var seek = lst.FirstOrDefault(x => x.Email == email);
			if (seek is null)
			{
				seek = new TurnitInSubmission();
				lst.Add(seek);
			}

			seek.Email = table.GetCellText($"B{i}");
			seek.PaperId = table.GetCellText($"C{i}");
			SyncSubmissionProperties(seek, repo);
			i++;
		}
	}

	private static void SyncSubmissionProperties(TurnitInSubmission submissionTuUpdate, StudentsRepository sourceRepository)
	{
		var stude = sourceRepository.Students.FirstOrDefault(x => x.HasEmail(submissionTuUpdate.Email));
		if (stude is null)
		{
			var studes = sourceRepository.Students.Where(x => x.FullName is not null && x.FullName.Equals(submissionTuUpdate.FullName, System.StringComparison.OrdinalIgnoreCase));
			foreach (var student in studes)
			{
				sourceRepository.AddAlternativeEmail(student, submissionTuUpdate.Email);
			}
			stude = studes.FirstOrDefault();
		}
		if (stude is not null)
		{
			SyncSubmissionProperties(submissionTuUpdate, stude);
		}
	}

	private static void SyncSubmissionProperties(TurnitInSubmission submissionTuUpdate, Student sourceStudent)
	{
		if (!string.IsNullOrEmpty(sourceStudent.Forename))
			submissionTuUpdate.FirstName = sourceStudent.Forename!;
		if (string.IsNullOrEmpty(submissionTuUpdate.Email) && !string.IsNullOrEmpty(sourceStudent.Email))
			submissionTuUpdate.Email = sourceStudent.Email!;
		if (!string.IsNullOrEmpty(sourceStudent.Surname))
			submissionTuUpdate.LastName = sourceStudent.Surname!;
		if (!string.IsNullOrEmpty(sourceStudent.NumericStudentId))
		{
			submissionTuUpdate.UserId = sourceStudent.NumericStudentId;
			submissionTuUpdate.NumericUserId = sourceStudent.NumericStudentId;
		}
	}

	/// <summary>
	/// Gets full name and paper information
	/// </summary>
	private static void UpdateStudentInfo(ref List<TurnitInSubmission> lst, IWorkbook package, StudentsRepository repo)
	{
		var table = package.GetSheetByName("Submissions");
		if (table is null)
			return;
		int i = 1;
		do
		{
			var magicNumber = table.GetCellText($"A{i}");
			if (magicNumber == "Student submissions")
				break;
			i++;
		} while (i < 100);

		if (i == 100)
			return;
		i += 2; // skip headers

		while (true)
		{
			var email = table.GetCellText($"B{i}");
			if (string.IsNullOrEmpty(email))
				return;
			var seek = lst.FirstOrDefault(x => x.Email == email);
			if (seek is null)
			{
				seek = new TurnitInSubmission();
				lst.Add(seek);
			}
			seek.FullName = table.GetCellText($"A{i}");
			seek.Email = table.GetCellText($"B{i}");
			seek.DateUploaded = table.GetCellText($"C{i}");
			seek.Overlap = table.GetCellText($"D{i}");
			seek.InternetOverlap = table.GetCellText($"E{i}");
			seek.PublicationsOverlap = table.GetCellText($"F{i}");
			seek.StudentPapersOverlap = table.GetCellText($"G{i}");

			SyncSubmissionProperties(seek, repo);
			i++;
		}
	}

	public static void PopulateDatabase(string fullname, IEnumerable<TurnitInSubmission> submissions, string elpSiteCode)
	{
		var filename = Path.ChangeExtension(fullname, "sqlite");

		if (!File.Exists(filename))
			CreateDatabase(fullname);

		var c = new SQLiteConnection("Data source=" + filename + ";");
		c.Open();
		foreach (var item in submissions)
		{
			var vc = TurnitInSubmission.GetSqlCouples(item, elpSiteCode);
			var flds = string.Join(", ", vc.Select(x => x.Field));
			var vals = string.Join(", ", vc.Select(x => x.GetValue()));
			var sql = $"insert into TB_Submissions ({flds}) values ({vals})";
			var cmd = new SQLiteCommand(sql, c);
			cmd.ExecuteNonQuery();
		}
		c.Close();
	}

	public static string UpdateDatabase(string fullname, List<TurnitInSubmission> submissions, string elpSiteCode)
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
			var vc = TurnitInSubmission.GetSqlCouples(item, elpSiteCode).Where(x => !string.IsNullOrWhiteSpace(x.Value));
			if (!string.IsNullOrEmpty(elpSiteCode))
			{
				vc = vc.ToList().Append(new SqlCouple("SUB_ElpSite", elpSiteCode));
			}
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

	public static IEnumerable<SubmittedFile> GetFilesFromManifest(FileInfo manifest)
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
				var fullPath = Path.Combine(manifest.Directory!.FullName, t);
				if (!File.Exists(fullPath))
				{
					// maybe the name has been cut
					var nm = Regex.Match(t, "^(?<documentId>\\d+)");
					if (nm.Success)
					{
						var ext = Path.GetExtension(fullPath);
						var found = manifest.Directory.GetFiles($"{nm.Groups["documentId"].Value}*{ext}");
						if (found.Length == 1)
						{
							fullPath = found.First().FullName;
						}
						else
							continue;
					}
					else
					{
						continue;
					}
				}
				var subId = t.Substring(0, t.IndexOf(" "));
				yield return new SubmittedFile(fullPath, subId);
			}
			else if (line == "Files")
				processFiles = true;
		}
	}

	public static IEnumerable<TurnitInSubmission> GetSubmissionsFromCollection(IStudentCollection coll)
	{
		var lst = new List<TurnitInSubmission>();
		foreach (var student in coll.Students)
		{
			TurnitInSubmission t = new TurnitInSubmission();
			lst.Add(t);
			SyncSubmissionProperties(t, student);
		}
		return lst;
	}
}
