using NPOI.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace UnnItBooster;

public class EmailContent
{
	public string EmailSubject { get; set; } = string.Empty;
	public string EmailBody { get; set; } = string.Empty;
	public string EmailCC { get; set; } = string.Empty;
	public string EmailIdentificationField { get; set; } = string.Empty;
	public string EmailIdentificationTransform { get; set; } = string.Empty;

	const string EmailExtension = "emailtemplate";

	public static IEnumerable<FileInfo> GetTemplates(DirectoryInfo? directory)
	{
		if (directory is null || !directory.Exists)
			return Enumerable.Empty<FileInfo>();
		return directory.GetFiles($"*.{EmailExtension}", SearchOption.AllDirectories);
	}

	internal bool Save(DirectoryInfo configurationFolder)
	{
		if (configurationFolder is null || !configurationFolder.Exists)
			return false;
		if (string.IsNullOrWhiteSpace(EmailSubject))
			return false;
		var file = new FileInfo(Path.Combine(configurationFolder.FullName, $"{EmailSubject}.{EmailExtension}"));
		JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
		var ser = JsonSerializer.Serialize(this, options);
		using var destFile = file.CreateText();
		destFile.Write(ser);
		return true;
	}

	public static EmailContent? FromFile(DirectoryInfo d, string name)
	{
		if (!d.Exists)
			return null;
		name = $"{name}.{EmailExtension}";
		var path = Path.Combine(d.FullName, name);
		if (!File.Exists(path))
			return null;
		var content = File.ReadAllText(path);
		var ret = JsonSerializer.Deserialize<EmailContent>(content);
		return ret;
	}

	internal static IEnumerable<string> GetTemplateNames(DirectoryInfo? directory)
	{
		foreach (var item in GetTemplates(directory))
		{
			yield return item.Name.Replace($".{EmailExtension}", "");
		}
	}

	static Regex IsNumericStudentId = new Regex(@"^(\d{8})$");

	internal static string ResolveEmail(string startingContent, string mode)
	{
		switch (mode)
		{
			case "MCRF_ID":
				{
					var tArr = startingContent.Split(['/'], StringSplitOptions.RemoveEmptyEntries);
					var pot = tArr.FirstOrDefault();
					if (pot is not null && IsNumericStudentId.IsMatch(pot))
					{
						return $"w{pot}@northumbria.ac.uk";
					}
					return "";
				}
			default:
				return startingContent;

		}
	}

	enum emailTransformOptions
	{
		none,
		MCRF_ID
	}

	internal static string[] GetOptions()
	{
		var options = new string[] {
			emailTransformOptions.none.ToString(),
			emailTransformOptions.MCRF_ID.ToString()
		};
		return options;
	}
}
