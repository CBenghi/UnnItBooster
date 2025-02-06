using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using UnnFunctions.Models;
using UnnItBooster.ModelConversions;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
	public partial class MarkingConfig
	{
		public MarkingConfig(string dbName)
		{
			DbName = dbName;
			using var c = GetConn();
			c.Open();
			TurnItIn.UpgradeDatabase(c);
			c.Close();
		}

		public string DbName { get; set; }

		public string? GetFolderName()
		{
			var f = new FileInfo(DbName);
			return f.DirectoryName;
		}

		public SQLiteConnection GetConn()
		{
			return new SQLiteConnection("Data source=" + DbName + ";");
		}

		public DataTable GetDataTable(string sql)
		{
			var c = GetConn();
			c.Open();
			var da = new SQLiteDataAdapter(sql, c);
			var dt = new DataTable();
			da.Fill(dt);
			c.Close();
			return dt;
		}

		internal List<string> GetVector(string sql)
		{
			var c = GetConn();
			c.Open();
			var t = GetVector(sql, c);
			c.Close();
			return t;
		}

		internal static List<string> GetVector(string sql, SQLiteConnection conn)
		{
			using var da = new SQLiteDataAdapter(sql, conn);
			using var dt = new DataTable();
			da.Fill(dt);
			var ret = new List<string>();
			foreach (DataRow item in dt.Rows)
			{
				ret.Add(item[0].ToString().Trim());
			}
			return ret;
		}

		public IEnumerable<TurnitInSubmission> GetStudentSubmissions()
		{
			var dt = GetDataTable("select * from TB_Submissions");
			foreach (DataRow item in dt.Rows)
			{
				if (item is null)
					continue;
				yield return TurnitInSubmission.FromRow(item);
			}
		}

		public TurnitInSubmission? GetStudentSubmission(int id)
		{
			var r = GetStudentRow(id);
			if (r is null)
				return null;
			return TurnitInSubmission.FromRow(r);
		}

		public DataRow? GetStudentRow(int id)
		{
			var sql = "select * from TB_Submissions where SUB_Id = " + id;
			var dt = GetDataTable(sql);
			return dt.Rows.Count == 1
				? dt.Rows[0]
				: null;
		}

		/// <summary>
		/// Changed using setlevel method
		/// </summary>
		public Dictionary<string, string> MarkAbility { get; set; } = new Dictionary<string, string>
			{
				{"1", "little or no"},
				{"2", "little or no"},
				{"3", "little or no"},
				{"4", "inadequate"},
				{"5", "adequate"},
				{"6", "good"},
				{"7", "excellent"},
				{"8", "outstanding"},
				{"9", "exceptional"}
			};

		public string GetStudentReport(int id, bool sendModerationNotice, bool includeCommentNumber = false)
		{
			var sb = new StringBuilder();
			var stud = GetStudentRow(id);
			if (stud == null)
			{
				return "";
			}
			var tin = TurnitInSubmission.FromRow(stud);
			sb.AppendLine($"# {tin.FirstName} {tin.LastName} {tin.NumericUserId}");
			sb.AppendLine();
			sb.AppendLine($"- email: {tin.Email} (#{id})");
			sb.AppendLine($"- Submission ID: {tin.PaperId}");
			sb.AppendLine($"- Submission Title: {tin.Title}");
			sb.AppendLine();
			GetStudentFeedback(id, sendModerationNotice, sb, tin, includeCommentNumber);
			var s = sb.ToString();
			return s;
		}

		public void GetStudentFeedback(int shortId, bool sendModerationNotice, StringBuilder sb, TurnitInSubmission? stud, bool includeCommentNumber = false)
		{
			var componentComments = "";
			sb.AppendLine("## Marking components:");
			sb.AppendLine("");

			var dt = GetDataTable("select * from (tb_submissions inner join tb_marks on mark_ptr_submission = sub_id) left join tb_components on mark_ptr_component = cpnt_id where MARK_Ptr_Submission = " + shortId + " order by cpnt_order");
			foreach (DataRow item in dt.Rows)
			{
				if (item["cpnt_order"] != DBNull.Value)
				{
					var cpntName = item["cpnt_name"].ToString();
					var order = Convert.ToInt32(item["cpnt_order"]);
					var mark = Convert.ToInt32(item["mark_value"]);
					var percent = Convert.ToInt32(item["cpnt_percent"]);

					if (order == -1)
						continue;

					sb.AppendFormat($"- Component {order}: {mark} (worth {percent}% of total mark for {cpntName})\r\n");

					if (mark > 10)
					{
						var commentTemplate = item["cpnt_comment"].ToString();
						if (commentTemplate.Contains(@"{0}"))
						{
							var bandMark = mark.ToString().Substring(0, 1);
							componentComments += string.Format(commentTemplate, MarkAbility[bandMark]) + "\r\n";
						}
					}
				}
				else
				{
					if (item["MARK_ptr_Component"].ToString() == "-1")
						continue;
					sb.AppendFormat("- Component {0}: {1}\r\n", item["MARK_ptr_Component"], item["MARK_Value"]);
				}
			}
			var totmark = GetMarkCalculator().GetFinalMark(shortId, this, true);
			if (totmark != -1)
				sb.AppendFormat("\r\nOverall mark: {0}%\r\n\r\n", totmark);
			
			var tmp = componentComments.Replace("\r\n", "").Trim();

			if (tmp != string.Empty)
			{
				sb.AppendFormat("## Comments:\r\n\r\n");
				sb.AppendFormat(componentComments);
			}
			// sb.AppendFormat("Feedback:\r\n\r\n");
			var sqlTable = $"select * from QComments where SCOM_Ptr_Submission = {shortId} order by cpnt_order, COMM_Section";
			dt = GetDataTable(sqlTable);
			var prevSection = "";
			foreach (DataRow item in dt.Rows)
			{
				var thisSection = item["CPNT_Name"].ToString().Trim();
				var sec = item["COMM_Section"].ToString();
				thisSection += string.IsNullOrEmpty(thisSection)
					? sec
					: $" / {sec}";


				if (prevSection != thisSection)
				{
					sb.AppendLine($"\r\n## {thisSection}\r\n");
					prevSection = thisSection;
				}
				string lastchar = "";
				var basecomment = item["COMM_Text"].ToString().Trim();
				if (!string.IsNullOrEmpty(basecomment))
				{
					lastchar = basecomment.Substring(basecomment.Length - 1);
					if (
						lastchar == "." ||
						lastchar == "?" ||
						lastchar == "!"
						)
					{
						basecomment = basecomment.Substring(0, basecomment.Length - 1);
					}
					else
					{
						lastchar = "";
					}
				}
				var addNote = item["SCOM_AddNote"].ToString().Trim();
				if (addNote.EndsWith("."))
					addNote = addNote.Substring(0, addNote.Length - 1);
				if (basecomment == "")
				{
					basecomment = addNote;
					addNote = "";
				}
				string thisComment;
				if (addNote.Length > 0)
				{
					thisComment = $" - {basecomment} ({addNote}){lastchar}";
				}
				else
				{
					thisComment = $" - {basecomment}{lastchar}";
				}
				if (includeCommentNumber)
				{
					thisComment += $" (Comm: {item["SCOM_ptr_Comment"]})";
				}
				sb.AppendLine(thisComment);
			}

			if (sendModerationNotice)
			{
				sb.AppendLine("---------------");
				sb.AppendLine();
				sb.AppendLine("Mark is subject to moderation, external examiner approval and confirmation by examination board");
			}
		}

		public void Execute(string sql, SQLiteConnection? c = null)
		{
			var bClose = false;
			if (c == null)
			{
				c = GetConn();
				c.Open();
				bClose = true;
			}
			var cm = new SQLiteCommand(sql, c);
			cm.ExecuteNonQuery();
			if (bClose)
				c.Close();
		}

		public int ExecuteScalar(string sql, SQLiteConnection? c = null)
		{
			var bClose = false;
			if (c == null)
			{
				c = GetConn();
				c.Open();
				bClose = true;
			}
			var id = new SQLiteCommand(sql, c);

			var o = id.ExecuteScalar();
			int reference;
			if (o != null)
				reference = Convert.ToInt32(o);
			else
				reference = -1;
			if (bClose)
				c.Close();
			return reference;
		}

		public MarksCalculator GetMarkCalculator()
		{
			var ret = new MarksCalculator();
			var dt = GetDataTable("Select * from TB_Components order by CPNT_Order");
			foreach (DataRow row in dt.Rows)
			{
				var m = new MarkComponent
				{
					id = Convert.ToInt32(row["CPNT_Id"]),
					percent = Convert.ToDouble(row["CPNT_Percent"]),
					Description = row["CPNT_Comment"].ToString(),
					Name = row["CPNT_Name"].ToString(),
				};
				ret.Marks.Add(m);
			}

			return ret;
		}

		public string UpdateDatabase(List<SubmittedFile> files)
		{
			var c = GetConn();
			c.Open();
			var ids = "select SUB_PaperId from TB_Submissions";
			var existingIds = GetVector(ids);

			int prevCount = existingIds.Count;
			int tallyUpdate = 0;
			int tallyNotFound = 0;

			var sb = new StringBuilder();
			foreach (var item in files)
			{
				var relative = item.FullPath.Substring(GetFolderName().Length);
				relative = relative.Trim(new[] { Path.DirectorySeparatorChar });
				var vc = new[] { new SqlCouple("SUB_Title", relative) };
				if (existingIds.Contains(item.SubmissionId))
				{
					// update
					var flds = string.Join(", ", vc.Select(x => x.GetSetCommand()));
					var sql = $"UPDATE TB_Submissions SET {flds} WHERE SUB_PaperId = '{item.SubmissionId}'";
					var cmd = new SQLiteCommand(sql, c);
					cmd.ExecuteNonQuery();
					tallyUpdate++;
				}
				else
				{
					tallyNotFound++;
					sb.AppendLine($"{item.SubmissionId} not found for {item.FullPath}");
				}
			}
			c.Close();
			sb.AppendLine($"===");
			sb.AppendLine($"Existing: {prevCount}");
			sb.AppendLine($"Modified: {tallyUpdate}");
			sb.AppendLine($"Missed  : {tallyNotFound}");
			return sb.ToString();
		}

		public void SetComponentComment(int order, string comment)
		{
			comment = comment.Replace("'", "''");
			var sql = $"update TB_Components set CPNT_Comment = '{comment}' where CPNT_Order = {order}";
			Execute(sql);
		}

		public DataRow? GetRow(string sql)
		{
			var dt = new DataTable();
			var c = GetConn();
			var da = new SQLiteDataAdapter(sql, c);
			da.Fill(dt);
			return dt.Rows.Count == 1
				? dt.Rows[0]
				: null;
		}

		public void SetStudentComponentMark(int iStudentNumber, int iComponent, int markvalue, bool deleteFirst)
		{
			if (deleteFirst)
			{
				var sqlDel = $"delete from TB_Marks where MARK_ptr_Submission = {iStudentNumber} and MARK_ptr_Component = {iComponent}";
				Execute(sqlDel);
			}
			var sql = "insert into TB_Marks (MARK_ptr_Submission, MARK_ptr_Component, MARK_Value, MARK_Date) " +
					  "values (" +
					  iStudentNumber + ", " +
					  iComponent + ", " +
					  markvalue + "," +
					  "datetime('now')" +
					  ")";
			Execute(sql);
		}

		public string[] GetStudentIds()
		{
			List<string> ids = new List<string>();
			var sql = "select SUB_NumericUserID from TB_Submissions";
			var datat = GetDataTable(sql);
			foreach (DataRow row in datat.Rows)
			{
				ids.Add(row[0].ToString());
			}
			return ids.ToArray();
		}

		/// <returns>-1 if no mark</returns>
		public int GetMark(int progressiveId, bool roundUpNines)
		{
			var mc = GetMarkCalculator();
			var totmark = mc.GetFinalMark(progressiveId, this, roundUpNines);
			return totmark;
		}

		public string ReportImageMatch(string relativeFileName)
		{
			FileInfo f = new FileInfo(Path.Combine(GetFolderName(), relativeFileName));
			WordFile w = new WordFile(f);
			if (!w.Exists)
				return "No word file";
			
			StringBuilder sb = new StringBuilder();
			var imageFiles = w.GetImages().ToList();
			sb.AppendLine($"Found {imageFiles.Count} images;");

			var ratios = imageFiles.Select(x => x.Ratio).ToList();
			foreach (var ratio in ratios)
			{
				sb.AppendLine($"Ratio: {ratio}");
			}

			foreach (var doc in GetDocumentFiles())
			{
				if (doc == relativeFileName)
					continue;
				FileInfo of = new FileInfo(Path.Combine(GetFolderName(), doc));
				WordFile ow = new WordFile(of);
				if (!ow.Exists)
					continue;
				
				var oImageFiles = ow.GetImages().ToList();
				var fnd = oImageFiles.Where(o => ratios.Contains(o.Ratio));
				if (fnd.Any())
				{
					sb.AppendLine($"Candidate for ratio in {doc}");
					foreach (var item in ow.WriteTempImages(fnd))
					{
						sb.AppendLine($" {item}");
					}
				}
			}
			return sb.ToString();
		}

		private IEnumerable<string> GetDocumentFiles()
		{
			var t = GetDataTable("select SUB_Title from TB_Submissions");
			foreach (DataRow row in t.Rows)
			{
				var title  = row[0].ToString();
				if (string.IsNullOrWhiteSpace(title))
					continue;
				yield return title;
			}
		}

		public int GetStudentShortId(string NumericUserId, out string email)
		{
			email = "";
			var s = $"select SUB_ID, SUB_email from TB_Submissions where cast(SUB_NumericUserID as int) = cast({NumericUserId} as int)";
			var dt = GetDataTable(s);
			if (dt.Rows.Count != 1)
				return -1;
			
			var r = dt.Rows[0];
			if (r is null)
				return -1;

			var id = r["SUB_ID"];
			if (id == DBNull.Value)
				return -1;
			if (!int.TryParse(id.ToString(), out var numeric))
				return -1;

			var tmpEmail = r["SUB_email"];
			if (tmpEmail is not null && tmpEmail != DBNull.Value)
				email = tmpEmail.ToString() ?? string.Empty;
			return numeric;
		}

		public void EnsureMarker(string studId, string mrkrEmail, string mrkrName, string role)
		{
			var sql = 
				$"""
				select * from TB_Markers where 
				MRKR_ptr_SubmissionUserID = '{studId}' and
				MRKR_MarkerEmail = '{mrkrEmail}' and
				MRKR_MarkerName = '{mrkrName}' and
				MRKR_MarkerRole = '{role}'
				""";
			var dt = GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return;
			sql =
				$"""
				insert into TB_Markers 
				(MRKR_ptr_SubmissionUserID, MRKR_MarkerEmail, MRKR_MarkerName, MRKR_MarkerRole)
				values 
				('{studId}', '{mrkrEmail}', '{mrkrName}', '{role}')
				""";
			Execute(sql);
		}

		public string ReportMarkers()
		{
			var sb = new StringBuilder();
			var ass = GetMarkingAssignments();
			
			sb.AppendLine("# Report by marker");
			sb.AppendLine();
			foreach (var assignment in ass)
			{
				sb.AppendLine($"{assignment.MarkerEmail}\t{assignment.MarkerName}");

				foreach (var item in assignment.Details)
				{
					sb.AppendLine($"\t{item.MarkingRole}\tw{item.StudentId}\t{item.SubmissionId}");
				}
			}
			sb.AppendLine();

			var sql =
				$"""
				select TB_Markers.*, TB_Submissions.* from 
				TB_Submissions LEFT JOIN TB_Markers
				on MRKR_ptr_SubmissionUserID = SUB_UserID
				order by SUB_email
				""";
			var dt = GetDataTable(sql);
			var lastReportMail = "";
			sb.AppendLine("# Report by student");
			sb.AppendLine();
			foreach (DataRow row in dt.Rows)
			{
				var studMail = $"{row["SUB_email"]}";
				var studName = $"{row["SUB_FirstName"]} {row["SUB_LastName"]}"; 
				var studId = row["SUB_UserId"] is not DBNull ? row["SUB_UserId"].ToString() : "<Null ID>";

				if (studMail != lastReportMail)
				{
					sb.AppendLine($"{studMail}\t{studId}\t{studName}");
					lastReportMail = studMail;
				}
				sb.AppendLine($"\t{row["MRKR_MarkerEmail"]}\t{row["MRKR_MarkerName"]}\t{row["MRKR_Role"]}");
			}
			sb.AppendLine();

			// missing:
			sql =
				$"""
				select MRKR_ptr_SubmissionUserID, SUB_UserID, MRKR_MarkerEmail from
				TB_Submissions FULL OUTER JOIN TB_Markers
				on MRKR_ptr_SubmissionUserID = SUB_UserID
				where MRKR_ptr_SubmissionUserID is null 
				or SUB_UserID is null 
				""";
			dt = GetDataTable(sql);
			lastReportMail = "";
			sb.AppendLine("# Report missing");
			sb.AppendLine();
			foreach (DataRow row in dt.Rows)
			{
				if (row["MRKR_ptr_SubmissionUserID"] is DBNull)
					sb.AppendLine($"Missing marker assignment for submission of student\t{row["SUB_UserID"]}");
				else
					sb.AppendLine($"Missing submission for assignment code\t{row["MRKR_ptr_SubmissionUserID"]}, {row["MRKR_MarkerEmail"]}");
			}
			sb.AppendLine();
			sb.AppendLine("# Markers emails");
			sb.AppendLine();
			var emails = ass.Select(x => x.MarkerEmail).ToList();
			sb.AppendLine(string.Join("; ", emails));
			return sb.ToString();
		}

		public FileInfo? GetLocalizedPathFrom(string f)
		{
			var fld = GetFolderName();
			if (fld == null)
				return null;
			var t = new FileInfo(Path.Combine(fld, f));
			return t;
		}

		public IEnumerable<MarkingAssignment> GetMarkingAssignments()
		{
			var sql =
				$"""
				select TB_Markers.*, TB_Submissions.* from 
				TB_Markers LEFT JOIN TB_Submissions
				on MRKR_ptr_SubmissionUserID = SUB_UserID
				order by TB_Markers.MRKR_MarkerEmail
				""";
			var dt = GetDataTable(sql);
			var lastReportMail = "";
			var ret = new List<MarkingAssignment>();
			MarkingAssignment? current = null;
			foreach (DataRow row in dt.Rows)
			{
				var markMail = row["MRKR_MarkerEmail"].ToString()!;
				var markName = row["MRKR_MarkerName"].ToString()!;

				if (current == null || markMail != lastReportMail) 
				{
					current = new MarkingAssignment(markMail, markName);
					ret.Add(current);
					lastReportMail = markMail;
				}
				var studentId = row["MRKR_ptr_SubmissionUserID"] is not DBNull ? row["MRKR_ptr_SubmissionUserID"].ToString()! : "<missing id>";
				var studentPaper = row["SUB_PaperID"] is not DBNull ? row["SUB_PaperID"].ToString()! : "<missing submission>";
				var studentPortal = row["SUB_ElpSite"] is not DBNull ? row["SUB_ElpSite"].ToString()! : "<undefined>";
				var studentRole = row["MRKR_MarkerRole"] is not DBNull ? row["MRKR_MarkerRole"].ToString()! : "<undefined role>";
				current.Add(new MarkingAssignmentDetail(
					studentId, studentPaper, studentPortal, studentRole
					));
			}
			return ret;
		}

		public string GetExcelMarkedEntries(out IEnumerable<SingleSubmissionMark> marks)
		{
			var sb = new StringBuilder();
			var folderName = GetFolderName()!;
			var d = new DirectoryInfo(Path.Combine(folderName, "ReceivedMarks"));
			var excelFiles = d.GetFiles("*.xlsx");
			var retmarks = new List<SingleSubmissionMark>();
			foreach (var excelFile in excelFiles)
			{
				if (!ExcelFunctions.TryReadExcel(excelFile.FullName, out var workbook, out var report))
				{
					sb.AppendLine(report);
					continue;
				}
				retmarks.AddRange(SingleSubmissionMark.GetMarks(workbook, out var getMarksReport));
				
			}
			marks = retmarks;
			return sb.ToString();
		}

		public string CreateExcelMarkingFilesFrom(FileInfo fl)
		{
			var sb = new StringBuilder();
			var ass = GetMarkingAssignments();
			foreach (var assItem in ass)
			{
				sb.AppendLine(CreateExcelMarking(fl, assItem));
			}
			return sb.ToString();
		}

		private string CreateExcelMarking(FileInfo fl, MarkingAssignment assItem)
		{
			var dest = GetLocalizedPathFrom($"{assItem.MarkerEmail}.xlsx");
			if (dest is null)
			{
				return $"Invalid name for {assItem.MarkerEmail}";
			}
			var sb = new StringBuilder();
			if (dest.Exists)
				dest.Delete();
			fl.CopyTo(dest.FullName);
			sb.Append(assItem.FixFile(dest));
			return sb.ToString();
		}

		public IEnumerable<(string StudentId , string MarkerEmail, string MarkerRole)> GetMarkingAssignmentsByStudents()
		{
			var ass = GetMarkingAssignments();
			foreach (var assItem in ass)
			{
				foreach (var item in assItem.Details)
				{
					yield return (item.StudentId, assItem.MarkerEmail, item.MarkingRole);
				}
			}
		}

		public string BareName => Path.GetFileNameWithoutExtension(DbName);
	}
}
