using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using UnnItBooster.ModelConversions;

namespace UnnItBooster.Models;

class TurnitInSubmission
{
    public string FirstName = "";
    public string LastName = "";
    public string FullName = "";
    public string UserId = "";
    public string Title = "";
    public string PaperId = "";
    public string DateUploaded = "";
    public string Grade = "";
    public string Overlap = "";
    public string InternetOverlap = "";
    public string PublicationsOverlap = "";
    public string StudentPapersOverlap = "";
    public string NumericUserId = "";
    public string Email = "";

    public static TurnitInSubmission FromRow(DataRow row)
    {
        var item = new TurnitInSubmission();
		item.LastName = Some("SUB_LastName", row);
		item.FirstName = Some("SUB_FirstName", row);
		item.UserId = Some("SUB_UserID", row);
		item.Title = Some("SUB_Title", row);
		item.PaperId = Some("SUB_PaperID", row);
		item.DateUploaded = Some("SUB_DateUploaded", row);
		item.Grade = Some("SUB_Grade", row);
		item.Overlap = Some("SUB_Overlap", row);
		item.InternetOverlap = Some("SUB_InternetOverlap", row);
		item.PublicationsOverlap = Some("SUB_PublicationsOverlap", row);
		item.StudentPapersOverlap = Some("SUB_StudentPapersOverlap", row);
		item.NumericUserId = Some("SUB_NumericUserID", row);
		item.Email = Some("SUB_email", row);
		return item; 
	}

	private static string Some(string field, DataRow row)
	{
		return row[field].ToString();
	}

	internal static IEnumerable<string> Fields => GetSqlCouples().Select(x => x.Field);

	internal static SqlCouple[] GetSqlCouples(TurnitInSubmission? item = null)
	{
		return new[] {
			new SqlCouple("SUB_LastName", item?.LastName ?? ""),
			new SqlCouple("SUB_FirstName", item?.FirstName?? ""),
			new SqlCouple("SUB_UserID",  item?.UserId?? ""),
			new SqlCouple("SUB_Title",  item?.Title?? ""),
			new SqlCouple("SUB_PaperID", item?.PaperId?? ""),
			new SqlCouple("SUB_DateUploaded",  item?.DateUploaded?? ""),
			new SqlCouple("SUB_Grade",  item?.Grade?? ""),
			new SqlCouple("SUB_Overlap",  item?.Overlap?? ""),
			new SqlCouple("SUB_InternetOverlap",  item?.InternetOverlap?? ""),
			new SqlCouple("SUB_PublicationsOverlap",  item?.PublicationsOverlap?? ""),
			new SqlCouple("SUB_StudentPapersOverlap",  item?.StudentPapersOverlap?? ""),
			new SqlCouple("SUB_NumericUserID",  item?.NumericUserId?? ""),
			new SqlCouple("SUB_email", item?.Email?? "")
			};
	}
}
