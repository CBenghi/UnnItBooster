using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;
using StudentsFetcher.StudentMarking;

namespace StudentMarking
{
    public class clsConfig
    {
        public string DbName { get; set; }

        internal string GetFolderName()
        {
            FileInfo f = new FileInfo(DbName);
            return f.DirectoryName;
        }

        internal SQLiteConnection GetConn()
        {
            return new SQLiteConnection("Data source=" + DbName + ";");
        }

        internal DataTable GetDataTable(string sql)
        {

            DataTable dt = new DataTable();
            SQLiteConnection c = GetConn();
            c.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, c);
            da.Fill(dt);
            c.Close();
            return dt;
        }

        internal DataRow GetStudentRow(int id)
        {
            DataTable dt = new DataTable();
            SQLiteConnection c = GetConn();
            string sql = "select * from TB_Submissions where SUB_Id = " + id.ToString();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, c);
            da.Fill(dt);
            // c.Close();
            if (dt.Rows.Count == 1)
                return dt.Rows[0];
            return null;
        }

        internal string GetStudentReport(int Id, bool SendModerationNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================");
            // txtStudentreport.Text = "No student selected.";
            DataRow stud = GetStudentRow(Id);
            if (stud == null)
            {
                return "";
            }
            sb.AppendFormat("{1} {2} {3} email: {4} (#{0})\r\n",
               stud["SUB_Id"].ToString(),
               stud["SUB_FirstName"].ToString(),
               stud["SUB_LastName"].ToString(),
               stud["SUB_UserId"].ToString(),
               stud["SUB_email"].ToString()
               );
            sb.AppendFormat("\r\n");

            DataTable dt;

            StringBuilder sb2 = new StringBuilder();
            Dictionary<int, string> Components = new Dictionary<int, string>();
            String ComponentComments = "";
            Dictionary<string, string> markAbility = new Dictionary<string,string>();
            markAbility.Add("1", "little or no");
            markAbility.Add("2", "little or no");
            markAbility.Add("3", "little or no");
            markAbility.Add("4", "inadequate");
            markAbility.Add("5", "adequate");
            markAbility.Add("6", "good");
            markAbility.Add("7", "excellent");
            markAbility.Add("8", "outstanding");
            markAbility.Add("9", "outstanding");


            dt = GetDataTable("select * from (tb_submissions inner join tb_marks on mark_ptr_submission = sub_id) left join tb_components on mark_ptr_component = cpnt_id where MARK_Ptr_Submission = " + Id.ToString() + " order by cpnt_order");
            foreach (DataRow item in dt.Rows)
            {
                if (item["cpnt_order"] != DBNull.Value )
                {
                    string cpnt_name = item["cpnt_name"].ToString();
                    int order = Convert.ToInt32(item["cpnt_order"]);
                    int mark = Convert.ToInt32(item["mark_value"]);
                    int percent = Convert.ToInt32(item["cpnt_percent"]);

                    if (order == -1)
                        continue;

                    sb.AppendFormat("Component {3} ({0} {1}% of total mark): {2}\r\n", cpnt_name, percent, mark, order);

                    if (mark > 10)
                    {
                        string CommentTemplate = item["cpnt_comment"].ToString();
                        if (CommentTemplate.Contains(@"{0}"))
                        {
                            string bandMark = mark.ToString().Substring(0, 1);
                            ComponentComments += string.Format(CommentTemplate, markAbility[bandMark]) + "\r\n";
                        }
                    }

                }
                else
                {
                    if (item["MARK_ptr_Component"].ToString()== "-1")
                        continue;
                    sb.AppendFormat("Component {0}: {1}\r\n", item["MARK_ptr_Component"].ToString(), item["MARK_Value"].ToString());
                }
            }

            int totmark = this.GetMarkCalculator().GetFinalMark(stud["SUB_NumericUserId"].ToString(), this);
            if (totmark != -1)
                sb.AppendFormat("Final mark: {0}%\r\n\r\n", totmark);
            sb.AppendLine("---------------");
            // sb.AppendFormat("Similarity index: {0}\r\n", stud["SUB_overlap"].ToString());


            string tmp = ComponentComments.Replace("\r\n", "").Trim();

            if (tmp != string.Empty)
            {
                sb.AppendFormat("Comments:\r\n\r\n");
                sb.AppendFormat(ComponentComments);
            }
            // sb.AppendFormat("Feedback:\r\n\r\n");
            dt = GetDataTable("select * from QComments where SCOM_Ptr_Submission = " + Id.ToString() + "  order by cpnt_order, SCOM_ID");
            string PrevSection = "";
            foreach (DataRow item in dt.Rows)
            {
                string thisSection = item["CPNT_Name"].ToString().Trim();
                if (PrevSection != thisSection)
                {
                    sb.AppendFormat("{0}\r\n\r\n", thisSection);
                    PrevSection = thisSection;
                }
                string basecomment = item["COMM_Text"].ToString().Trim();
                if (basecomment.EndsWith("."))
                    basecomment = basecomment.Substring(0, basecomment.Length - 1);
                string addNote = item["SCOM_AddNote"].ToString().Trim();
                if (addNote.EndsWith("."))
                    addNote = addNote.Substring(0, addNote.Length - 1);

                if (basecomment == "")
                {
                    basecomment = addNote;
                    addNote = "";
                }
                string thisComment = "";
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

            if (SendModerationNotice)
            {
                sb.AppendLine("---------------");
                sb.AppendLine();
                sb.AppendLine(
                    "Mark is subject to moderation, external examiner approval and confirmation by examination board");
            }
            string s = sb.ToString();
            return s;
        }

        internal void Execute(string sql, SQLiteConnection c = null)
        {
            bool bClose = false;
            if (c == null)
            {
                c = GetConn();
                c.Open();
                bClose = true;
            }
            
            SQLiteCommand cm = new SQLiteCommand(sql, c);
            cm.ExecuteNonQuery();
            if (bClose)
                c.Close();
        }

        internal int ExecuteScalar(string sql, SQLiteConnection c = null)
        {
            bool bClose = false;
            if (c == null) { 
                c = GetConn();
                c.Open();
                bClose = true;
            }
            SQLiteCommand id = new SQLiteCommand(sql, c);
            
            object o = id.ExecuteScalar();
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
            MarksCalculator ret = new MarksCalculator();
            if (ret.Marks == null)
                ret.Marks = new List<MarkComponent>();
            DataTable dt = this.GetDataTable("Select * from TB_Components");
            foreach (DataRow row in dt.Rows)
            {
                MarkComponent m = new MarkComponent();
                m.id = Convert.ToInt32(row["CPNT_Id"]);
                m.percent = Convert.ToDouble(row["CPNT_Percent"]);
                ret.Marks.Add(m);
            }

            return ret;
        }
    }
}
