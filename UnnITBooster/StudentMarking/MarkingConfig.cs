using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using UnnItBooster.ModelConversions;
using UnnItBooster.Models;

namespace StudentsFetcher.StudentMarking
{
	public class MarkingConfig
    {
        public MarkingConfig(string dbName)
        {
            DbName = dbName;
        }

        public string DbName { get; set; }

        internal string GetFolderName()
        {
            var f = new FileInfo(DbName);
            return f.DirectoryName;
        }

        internal SQLiteConnection GetConn()
        {
            return new SQLiteConnection("Data source=" + DbName + ";");
        }

        internal DataTable GetDataTable(string sql)
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

        internal DataRow? GetStudentRow(int id)
        {
            var dt = new DataTable();
            var c = GetConn();
            var sql = "select * from TB_Submissions where SUB_Id = " + id;
            var da = new SQLiteDataAdapter(sql, c);
            da.Fill(dt);
            // c.Close();
            return dt.Rows.Count == 1 
                ? dt.Rows[0] 
                : null;
        }

        internal string GetStudentReport(int id, bool sendModerationNotice)
        {
            var sb = new StringBuilder();
            sb.AppendLine("================");
            var stud = GetStudentRow(id);
            if (stud == null)
            {
                return "";
            }
            sb.AppendLine($"{stud["SUB_FirstName"]} {stud["SUB_LastName"]} {stud["SUB_UserId"]}");
            sb.AppendLine($"email: {stud["SUB_email"]} (#{stud["SUB_Id"]})");
            sb.AppendLine($"Submission ID: {stud["SUB_PaperID"]}");
            sb.AppendLine($"Submission Title: {stud["SUB_Title"]}");
            sb.AppendLine();

            var componentComments = "";
            var markAbility = new Dictionary<string, string>
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


            var dt = GetDataTable("select * from (tb_submissions inner join tb_marks on mark_ptr_submission = sub_id) left join tb_components on mark_ptr_component = cpnt_id where MARK_Ptr_Submission = " + id + " order by cpnt_order");
            foreach (DataRow item in dt.Rows)
            {
                if (item["cpnt_order"] != DBNull.Value )
                {
                    var cpntName = item["cpnt_name"].ToString();
                    var order = Convert.ToInt32(item["cpnt_order"]);
                    var mark = Convert.ToInt32(item["mark_value"]);
                    var percent = Convert.ToInt32(item["cpnt_percent"]);

                    if (order == -1)
                        continue;

                    sb.AppendFormat("Component {3} ({1}% of total mark for {0}): {2}\r\n", cpntName, percent, mark, order);

                    if (mark > 10)
                    {
                        var commentTemplate = item["cpnt_comment"].ToString();
                        if (commentTemplate.Contains(@"{0}"))
                        {
                            var bandMark = mark.ToString().Substring(0, 1);
                            componentComments += string.Format(commentTemplate, markAbility[bandMark]) + "\r\n";
                        }
                    }
                }
                else
                {
                    if (item["MARK_ptr_Component"].ToString()== "-1")
                        continue;
                    sb.AppendFormat("Component {0}: {1}\r\n", item["MARK_ptr_Component"], item["MARK_Value"]);
                }
            }
            var studId = stud["SUB_NumericUserId"].ToString();
            if (studId == @"")
            {
                throw  new Exception(@"Missing student Id");
            }
            var totmark = GetMarkCalculator().GetFinalMark(studId, this);
            if (totmark != -1)
                sb.AppendFormat("Overall mark: {0}%\r\n\r\n", totmark);
            sb.AppendLine("---------------");
            if (sendModerationNotice)
            {
                sb.AppendFormat("Similarity index: {0}\r\n", stud["SUB_overlap"].ToString());
            }

            var tmp = componentComments.Replace("\r\n", "").Trim();

            if (tmp != string.Empty)
            {
                sb.AppendFormat("Comments:\r\n\r\n");
                sb.AppendFormat(componentComments);
            }
            // sb.AppendFormat("Feedback:\r\n\r\n");
            dt = GetDataTable("select * from QComments where SCOM_Ptr_Submission = " + id + "  order by cpnt_order, SCOM_ID");
            var prevSection = "";
            foreach (DataRow item in dt.Rows)
            {
                var thisSection = item["CPNT_Name"].ToString().Trim();
                if (prevSection != thisSection)
                {
                    sb.AppendFormat("{0}\r\n\r\n", thisSection);
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
                    thisComment  = $" - {basecomment} ({addNote}){lastchar}";
                }
                else
                {
                    thisComment = $" - {basecomment}{lastchar}";
                }
                sb.AppendLine(thisComment);
            }

            if (sendModerationNotice)
            {
                sb.AppendLine("---------------");
                sb.AppendLine();
                sb.AppendLine("Mark is subject to moderation, external examiner approval and confirmation by examination board");
            }
            var s = sb.ToString();
            return s;
        }

        internal void Execute(string sql, SQLiteConnection? c = null)
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

        internal int ExecuteScalar(string sql, SQLiteConnection? c = null)
        {
            var bClose = false;
            if (c == null) { 
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

        internal MarksCalculator GetMarkCalculator()
        {      
            var ret = new MarksCalculator();
            var dt = GetDataTable("Select * from TB_Components");
            foreach (DataRow row in dt.Rows)
            {
                var m = new MarkComponent
                {
                    id = Convert.ToInt32(row["CPNT_Id"]),
                    percent = Convert.ToDouble(row["CPNT_Percent"])
                };
                ret.Marks.Add(m);
            }

            return ret;
        }

		internal string UpdateDatabase(List<SubmittedFile> files)
		{
			var c = GetConn();
			c.Open();
			var ids = "select SUB_PaperId from TB_Submissions";
			var existingIds = GetVector(ids);

			int prevCount = existingIds.Count;
			int tallyUpdate = 0;
			int tallyNotFound = 0;

			StringBuilder sb = new StringBuilder();
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

		internal void SetComponentComment(int order, string comment)
		{
            comment = comment.Replace("'", "''");
            var sql = $"update TB_Components set CPNT_Comment = '{comment}' where CPNT_Order = {order}";
			Execute(sql);
		}

		public string BareName
        {
            get
            {
                return  Path.GetFileNameWithoutExtension(DbName);
            }
        }
    }
}
