using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace StudentsFetcher.StudentMarking
{
    public class ClsConfig
    {
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

            var dt = new DataTable();
            var c = GetConn();
            c.Open();
            var da = new SQLiteDataAdapter(sql, c);
            da.Fill(dt);
            c.Close();
            return dt;
        }

        internal DataRow GetStudentRow(int id)
        {
            var dt = new DataTable();
            var c = GetConn();
            var sql = "select * from TB_Submissions where SUB_Id = " + id;
            var da = new SQLiteDataAdapter(sql, c);
            da.Fill(dt);
            // c.Close();
            if (dt.Rows.Count == 1)
                return dt.Rows[0];
            return null;
        }

        internal string GetStudentReport(int id, bool sendModerationNotice)
        {
            var sb = new StringBuilder();
            sb.AppendLine("================");
            // txtStudentreport.Text = "No student selected.";
            var stud = GetStudentRow(id);
            if (stud == null)
            {
                return "";
            }
            sb.AppendFormat("{1} {2} {3} email: {4} (#{0})\r\n",
               stud["SUB_Id"],
               stud["SUB_FirstName"],
               stud["SUB_LastName"],
               stud["SUB_UserId"],
               stud["SUB_email"]
               );
            sb.AppendFormat("\r\n");


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
                {"9", "outstanding"}
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

                    sb.AppendFormat("Component {3} ({0} {1}% of total mark): {2}\r\n", cpntName, percent, mark, order);

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

            var totmark = GetMarkCalculator().GetFinalMark(stud["SUB_NumericUserId"].ToString(), this);
            if (totmark != -1)
                sb.AppendFormat("Overall mark: {0}%\r\n\r\n", totmark);
            sb.AppendLine("---------------");
            // sb.AppendFormat("Similarity index: {0}\r\n", stud["SUB_overlap"].ToString());


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
                var basecomment = item["COMM_Text"].ToString().Trim();
                if (basecomment.EndsWith("."))
                    basecomment = basecomment.Substring(0, basecomment.Length - 1);
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
                    thisComment  = string.Format(" - {0} ({1}).",
                        basecomment,
                        addNote
                        );
                }
                else
                {
                    thisComment = string.Format(" - {0}.",
                        basecomment
                        );
                }
                sb.AppendLine(thisComment);
            }

            if (sendModerationNotice)
            {
                sb.AppendLine("---------------");
                sb.AppendLine();
                sb.AppendLine(
                    "Mark is subject to moderation, external examiner approval and confirmation by examination board");
            }
            var s = sb.ToString();
            return s;
        }

        internal void Execute(string sql, SQLiteConnection c = null)
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

        internal int ExecuteScalar(string sql, SQLiteConnection c = null)
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
            if (ret.Marks == null)
                ret.Marks = new List<MarkComponent>();
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
    }
}
