#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnnItBooster.Models;

public class StudentsRepository
{
	private List<IStudentCollection> collections = new List<IStudentCollection>();

	public static StudentsRepository GetRespository()
	{
		return new StudentsRepository(StudentsFetcher.Properties.Settings.Default.StudentsFolder);
	}

	public StudentsRepository(string dataFolder)
	{
		this.dataFolder = dataFolder ?? string.Empty;
		Reload();
	}

	internal void Reload()
	{
		collections = new List<IStudentCollection>();
		foreach (var item in ConfigurationFolder.GetDirectories())
		{
			if (StudentJsonCollection.IsValid(item))
				collections.Add(new StudentJsonCollection(item));
		}
	}

	private string dataFolder;

	public IEnumerable<IStudentCollection> GetCollections()
	{
		foreach (var item in collections)
		{
			yield return item;
		}
	}

	internal IEnumerable<Student> Students
	{
		get
		{
			return collections.SelectMany(item => item.Students);
		}
	}

	internal DirectoryInfo ConfigurationFolder
	{
		get
		{
			var di = new DirectoryInfo(dataFolder);
			if (!di.Exists)
			{
				di = new DirectoryInfo(".");
			}
			return di;
		}
	}

	internal bool HasImage(Student student, out string imagePath)
	{
		imagePath = "";
		DirectoryInfo d = new DirectoryInfo(dataFolder);
		var fl = d.GetFiles($"{student.NumericStudentId}.jpg", SearchOption.AllDirectories).FirstOrDefault();
		if (fl is null)
			return false;
		imagePath = fl.FullName;
		return true;
	}

	internal Student? GetStudentById(string numericStudentId)
	{
		foreach (var item in Students)
		{
			if (item.NumericStudentId == numericStudentId)
				return item;
		}
		return null;
	}

	internal bool IsValidNewCollectionName(string shortName, out string containerFullName)
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

}
