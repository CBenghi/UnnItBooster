using System.Collections.Generic;
using System.Data;
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
	
	public string CitationList = "";
	public string Bibliography = "";
	public int InternalShortId = -1;

	public static TurnitInSubmission FromRow(DataRow row)
	{
		var item = new TurnitInSubmission();
		item.LastName = GetFromField("SUB_LastName", row);
		item.FirstName = GetFromField("SUB_FirstName", row);
		item.UserId = GetFromField("SUB_UserID", row);
		item.Title = GetFromField("SUB_Title", row);
		item.PaperId = GetFromField("SUB_PaperID", row);
		item.DateUploaded = GetFromField("SUB_DateUploaded", row);
		item.Grade = GetFromField("SUB_Grade", row);
		item.Overlap = GetFromField("SUB_Overlap", row);
		item.InternetOverlap = GetFromField("SUB_InternetOverlap", row);
		item.PublicationsOverlap = GetFromField("SUB_PublicationsOverlap", row);
		item.StudentPapersOverlap = GetFromField("SUB_StudentPapersOverlap", row);
		item.NumericUserId = GetFromField("SUB_NumericUserID", row);
		item.Email = GetFromField("SUB_email", row);
		item.ElpSite = GetFromField("SUB_ElpSite", row);
		//
		item.CitationList = GetFromField("SUB_InText", row);
		item.Bibliography = GetFromField("SUB_Biblio", row);
		var sid = row["SUB_Id"].ToString();
		if (!string.IsNullOrEmpty(sid) && int.TryParse(sid, out var result))
			item.InternalShortId = result;
		return item;
	}

	private static string GetFromField(string field, DataRow row)
	{
		return row[field].ToString() ?? "";
	}

	public static IEnumerable<string> Fields => GetSqlCouples().Select(x => x.Field);

	internal static SqlCouple[] GetSqlCouples(TurnitInSubmission? item = null, string? elpSiteCode = null)
	{
		var elpCode = elpSiteCode
			?? item?.ElpSite
			?? "";
		var lastName = item is null
			? ""
			: !string.IsNullOrEmpty(item.LastName) ? item.LastName : item.FullName;
		return [
			new SqlCouple("SUB_LastName", lastName),
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
			// added bibliography and citation list to the sql couples
			new SqlCouple("SUB_InText", item?.CitationList ?? ""),
			new SqlCouple("SUB_Biblio", item?.Bibliography ?? ""),
			new SqlCouple("SUB_ElpSite", elpCode)
			];
	}
}
