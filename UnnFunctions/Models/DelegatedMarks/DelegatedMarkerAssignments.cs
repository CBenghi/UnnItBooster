using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnnFunctions.Models.DelegatedMarks;

/// <summary>
/// Defines the assignment of submission to a single marker identified by name and email
/// </summary>
public class DelegatedMarkerAssignments
{
    public DelegatedMarkerAssignments(string markMail, string markName)
    {
        MarkerEmail = markMail;
        MarkerName = markName;
    }

    public string MarkerEmail { get; set; }
    public string MarkerName { get; set; }
    public List<MarkingAssignmentSubmissionInformation> Details { get; set; } = new();

    internal void Add(MarkingAssignmentSubmissionInformation markingAssignmentDetail)
    {
        Details.Add(markingAssignmentDetail);
    }

    internal string FixFile(FileInfo dest)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Preparing {dest.Name}.");
        using var readFile = new FileStream(dest.FullName, FileMode.Open, FileAccess.Read);
        var workbook = new XSSFWorkbook(readFile);
        readFile.Close();
        ISheet sheet = workbook.GetSheetAt(0);
        IRow row = sheet.GetRow(0);
        ICell cell = row.GetCell(2);
        cell.SetCellValue(MarkerEmail);

        ICellStyle unlockedCellStyle = workbook.CreateCellStyle();
        unlockedCellStyle.IsLocked = false;

        int iRow = 7; // starting at row 8
        foreach (var det in Details)
        {
            row = sheet.GetRow(iRow++);
            row.GetCell(1).SetCellValue(det.ElpId);
            row.GetCell(2).SetCellValue($"w{det.StudentId}");
            row.GetCell(3).SetCellValue(det.SubmissionId);

            // the marking cells need to be unlocked
            //
            for (int i = 4; i < 10; i++)
            {
                var thiscell = row.GetCell(i);
                if (thiscell != null)
                    thiscell.CellStyle = unlockedCellStyle;
                else
                    sb.AppendLine($"problem with null cell at row: {iRow - 1} col: {i}");
            }

            // get the cell style of the comment and make it unlocked
            //

            var commentCell = row.GetCell(10);
            var newCellStyle = workbook.CreateCellStyle();
            newCellStyle.CloneStyleFrom(commentCell.CellStyle);
            newCellStyle.IsLocked = false;
            commentCell.CellStyle = newCellStyle;
        }
        // sheet.ShiftRows(39, 39, iRow - 39, true, false);
        while (iRow < 39)
        {
            row = sheet.GetRow(iRow++);
            // 11 includes the comment
            for (int i = 11; i < 18; i++)
            {
                var thiscell = row.GetCell(i);
                thiscell.SetBlank();
            }
        }
        sheet.ProtectSheet(""); // locks all cells except the unlocked
        dest.Delete();
        using var file = new FileStream(dest.FullName, FileMode.Create, FileAccess.Write);
        workbook.Write(file, false);

        return sb.ToString();
    }
}

