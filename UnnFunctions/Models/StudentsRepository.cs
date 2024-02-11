using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace UnnItBooster.Models;

public class StudentsRepository
{
	private List<IStudentCollection> collections = new();

	public StudentsRepository(string dataFolder)
	{
		this.dataFolder = dataFolder ?? string.Empty;
		Reload();
	}

	public void Reload(IEnumerable<string>? nameFilters = null)
	{
		List<string>? filters = null;
		if (nameFilters is not null)
			filters = nameFilters.ToList();

		collections = new List<IStudentCollection>();
		foreach (var possibleContainer in ConfigurationFolder.GetDirectories())
		{
			if (filters is null || filters.Any(x => filters.Contains(possibleContainer.Name)))
			{
				if (StudentJsonCollection.IsValid(possibleContainer))
				{
					collections.Add(new StudentJsonCollection(possibleContainer));
				}
			}
		}
	}

	/// <summary>
	/// Initializes or updates a student collection by name (by merging students based on id)
	/// </summary>
	public string ConsiderNewStudents(IEnumerable<Student> students, string collectionName)
	{
		var sb = new StringBuilder();
		if (string.IsNullOrEmpty(collectionName))
		{
			sb.AppendLine($"No destination code.\r\n");
			return sb.ToString();
		}
		if (!students.Any())
		{
			sb.AppendLine($"No students to process.\r\n");
			return sb.ToString();
		}

		sb.AppendLine($"Processing {students.Count()} records.\r\n");
		var coll = GetPersonCollections().FirstOrDefault(x => x.Name == collectionName);
		if (coll is null)
		{
			if (IsValidNewCollectionName(collectionName, out var containerFullName))
			{
				// if new and valid
				sb.AppendLine($"New container {containerFullName}\r\n");
				_ = StudentJsonCollection.Create(containerFullName, students);
			}
		}
		else
		{
			// if update and exists
			var studs = coll.Students.MergeInformation(students);
			coll.Students = studs.ToList();
			sb.AppendLine($"Merged in existing container, total of {studs.Count()} records.\r\n");
			coll.Save();
		}
		Reload();
		return sb.ToString();
	}

	private string dataFolder { get; set; }

	public IEnumerable<IStudentCollection> GetPersonCollections()
	{
		foreach (var item in collections)
		{
			yield return item;
		}
	}

	public IEnumerable<Student> Students
	{
		get
		{
			return collections.SelectMany(item => item.Students);
		}
	}

	public DirectoryInfo ConfigurationFolder
	{
		get
		{
			DirectoryInfo? di;
			try
			{
				di = new DirectoryInfo(dataFolder);
			}
			catch (Exception)
			{
				di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
			}
			if (!di.Exists)
			{
				di = new DirectoryInfo(".");
			}
			return di;
		}
	}

	private const string PhotoFolder = "Photos";

	public string GetDefaultImageName(string number, string moduleCode)
	{
		var d = new DirectoryInfo(dataFolder);
		var pho = Path.Combine(d.FullName, PhotoFolder);
		d = new DirectoryInfo(pho);
		if (!d.Exists)
			d.Create();
		if (!string.IsNullOrEmpty(moduleCode)) 
		{
			pho = Path.Combine(d.FullName, moduleCode);
			d = new DirectoryInfo(pho);
			if (!d.Exists)
				d.Create();
		}
		return Path.Combine(pho, $"{number}.jpg");
	}

	public bool HasImage(Student student, out string imagePath)
	{
		var num = student.NumericStudentId;
		return HasImage(num, out imagePath);
	}

	public bool HasImage(string numericStudentId, out string imagePath)
	{
		imagePath = "";
		var d = new DirectoryInfo(dataFolder);
		var fl = d.GetFiles($"{numericStudentId}.jpg", SearchOption.AllDirectories).FirstOrDefault();
		if (fl is null)
			return false;
		imagePath = fl.FullName;
		return true;
	}

	public Student? GetStudentById(string numericStudentId, IStudentCollection? studcoll = null)
	{
		if (studcoll is not null)
		{
			foreach (var item in studcoll.Students)
			{
				if (item.NumericStudentId == numericStudentId)
					return item;
			}
		}
		else
		{
			foreach (var item in Students)
			{
				if (item.NumericStudentId == numericStudentId)
					return item;
			}
		}
		return null;
	}

	public bool IsValidNewCollectionName(string shortName, out string containerFullName)
	{
		containerFullName = string.Empty;
		if (string.IsNullOrWhiteSpace(shortName))
			return false;
		var folderName = Path.Combine(
				ConfigurationFolder.FullName,
				shortName);
		var d = new DirectoryInfo(folderName);
		if (!d.Exists)
			containerFullName = d.FullName;
		return !d.Exists;
	}

	/// <returns>the count of affected students</returns>
	public int AddAlternativeEmail(Student stude, string newEmail)
	{
		int tally = 0;
		foreach (var collection in collections)
		{
			var any = false;
			foreach (var stud in collection.Students.Where(x => x.Email == stude.Email))
			{
				if (stud.AddAlternativeEmail(newEmail))
				{
					tally++;
					any = true;
				}
			}
			if (any)
				collection.Save();
		}
		return tally;
	}

	public bool TryGetStudentByEmail(string seekingEmail, [NotNullWhen(true)]out Student? returnStudent)
	{
		returnStudent = Students.FirstOrDefault(x => x.HasEmail(seekingEmail));
		return returnStudent != null;
	}

	public int UpdateStudentInfo(Student student)
	{
		var tally = 0;
		foreach (var coll in collections)
		{
			if (UpdateStudentInfo(student, coll))
				tally++;
		}
		return tally;
	}

	public bool UpdateStudentInfo(Student student, string collection)
	{
		var coll = collections.FirstOrDefault(x => x.Name == collection);
		if (coll is null)
			return false;
		return UpdateStudentInfo(student, coll);
	}

	private static bool UpdateStudentInfo(Student student, IStudentCollection coll)
	{
		if (
			string.IsNullOrEmpty(student.Email)
			&& string.IsNullOrEmpty(student.NumericStudentId)
			)
			return false;
		var toUpdate = coll.Students.FirstOrDefault(x => x.HasEmail(student.Email!));
		if (toUpdate is null && !string.IsNullOrEmpty(student.NumericStudentId))
		{
			toUpdate = coll.Students.FirstOrDefault(x => x.NumericStudentId == student.NumericStudentId);
		}
		if (toUpdate is null)
		{
			return false;
		}
		toUpdate.MergeInformation(student);
		coll.Save();
		return true;
	}

	public bool TryGetExtraImage(string numericUserId, out string image, string CollectionCode = "extra")
	{
		string imageUrl = GetImageUrl(numericUserId);
		var nm = GetDefaultImageName(numericUserId, CollectionCode);
		if (File.Exists(nm))
		{
			image = nm;
			return true;
		}
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			var request = WebRequest.Create(imageUrl);
			using var response = request.GetResponse();
			using var stream = response.GetResponseStream();
			using var fileStream = File.Create(nm);
			stream.CopyTo(fileStream);
			image = nm;
			return true;
		}
		catch (Exception)
		{
			if (File.Exists(nm))
				File.Delete(nm);
			image = string.Empty;
			return false;
		}
	}

	private static Regex reNumericUserId = new Regex("^\\d{8}$");

	public static bool IsNumericUserId(string candidate)
	{
		return reNumericUserId.IsMatch(candidate);
	}

	public static string GetImageUrl(string numericUserId)
	{
		return $"https://nuweb2.northumbria.ac.uk/photoids/{numericUserId}.jpg";
	}

	public IEnumerable<IStudentCollection> GetContainersFor(string senderEmailAddress)
	{
		foreach (var collection in collections)
		{
			if (collection is null)
				continue;
			if (collection.Students.Any(x => x.HasEmail(senderEmailAddress)))
				yield return collection;
		}
	}
}
