using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using UnnItBooster.ModelConversions;

namespace UnnItBooster.Models;

[DebuggerDisplay("{FirstName} {LastName} {FullName} - {Email}")]
public class TurnitInSubmission
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
	public string ElpSite = "";
	public int InternalShortId = -1;

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
		item.ElpSite = Some("SUB_ElpSite", row);
		var sid = row["SUB_Id"].ToString();
		if (!string.IsNullOrEmpty(sid) && int.TryParse(sid, out var result))
			item.InternalShortId = result;
		return item;
	}

	private static string Some(string field, DataRow row)
	{
		return row[field].ToString();
	}

	public static IEnumerable<string> Fields => GetSqlCouples().Select(x => x.Field);

	internal static SqlCouple[] GetSqlCouples(TurnitInSubmission? item = null, string? elpSiteCode = null)
	{
		var elpCode = elpSiteCode
			?? item?.ElpSite
			?? "";
		return new[] {
			new SqlCouple("SUB_LastName", !string.IsNullOrEmpty(item?.LastName) ? item.LastName : item?.FullName),
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
			new SqlCouple("SUB_email", item?.Email?? ""),
			new SqlCouple("SUB_ElpSite", elpCode)
			};
	}
}
