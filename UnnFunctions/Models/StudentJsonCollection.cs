using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnnItBooster.Models
{
	public class StudentJsonCollection : IStudentCollection
	{
		public string? OutlookFolder { get; set; }

		// private const string StandardCollectionName = "students.json";
		private const string CollectionFileName = "StudentCollection.json";

		private readonly DirectoryInfo directory;

		public List<Student> Students { get; set; } = new List<Student>();

		// only for persistence
		public StudentJsonCollection()
		{
			directory = new DirectoryInfo(".");
		}

		public StudentJsonCollection(DirectoryInfo directory)
		{
			if (directory == null)
				throw new ArgumentNullException(nameof(directory));
			if (!directory.Exists)
				throw new ArgumentException($"{nameof(directory)} does not exist");
			this.directory = directory;
			if (File.Exists(persistenceFileName))
				Reload();
		}

		public StudentJsonCollection(DirectoryInfo directory, IEnumerable<Student> students) : this(directory)
		{
			Students.AddRange(students);
			Save();
		}

		private void Reload()
		{
			var cont = File.ReadAllText(persistenceFileName);
			try
			{
				var t = JsonSerializer.Deserialize<StudentJsonCollection>(cont);
				if (t != null)
				{
					Students = t.Students;
					OutlookFolder = t.OutlookFolder;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.InnerException?.Message ?? "");
			}			
		}

		private string persistenceFileName => GetJsonPersistenceFile(directory);

		public string Name => directory.Name;

		static string GetJsonPersistenceFile(DirectoryInfo d)
		{
			return Path.Combine(d.FullName, CollectionFileName);
		}

		public static bool IsValid(DirectoryInfo directory)
		{
			if (directory == null)
				return false;
			return File.Exists(GetJsonPersistenceFile(directory));
		}

		public static StudentJsonCollection Create(string containerFullName, IEnumerable<Student> students)
		{
			var d = new DirectoryInfo(containerFullName);
			d.Create();
			return new StudentJsonCollection(d, students);
		}

		private static void Save(StudentJsonCollection students, DirectoryInfo d)
		{
			var fullName = GetJsonPersistenceFile(d);
			var opts = new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
			var t = JsonSerializer.Serialize(students, opts);
			File.WriteAllText(fullName, t);
		}

		public void FullSave()
		{
			var fullName = Path.Combine(
				directory.FullName,
				"StudentCollection.json"
				);
			var opts = new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
			var t = JsonSerializer.Serialize(this, opts);
			File.WriteAllText(fullName, t);
		}

		public void Save()
		{
			Save(this, directory);
		}
	}
}
