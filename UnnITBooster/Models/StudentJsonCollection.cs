using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnnItBooster.Models
{
	internal class StudentJsonCollection : IStudentCollection
	{
		private const string StandardCollectionName = "students.json";

		private DirectoryInfo directory;

		public List<Student> Students { get; set; } = new List<Student>();

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

		private void Reload()
		{
			var cont = File.ReadAllText(persistenceFileName);
			var t = JsonSerializer.Deserialize<List<Student>>(cont);
			if (t != null)
				Students = t;
		}

		private string persistenceFileName => GetJsonPersistenceFile(directory);

		public string Name => directory.Name;

		static string GetJsonPersistenceFile(DirectoryInfo d)
		{
			return Path.Combine(d.FullName, StandardCollectionName);
		}

		public static bool IsValid(DirectoryInfo directory)
		{
			if (directory == null)
				return false;
			return File.Exists(GetJsonPersistenceFile(directory));
		}

		internal static StudentJsonCollection Create(string containerFullName, IEnumerable<Student> students)
		{
			DirectoryInfo d = new DirectoryInfo(containerFullName);
			d.Create();
			Save(students, d);

			return new StudentJsonCollection(d);
		}

		private static void Save(IEnumerable<Student> students, DirectoryInfo d)
		{
			var fullName = GetJsonPersistenceFile(d);
			var opts = new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
			var t = JsonSerializer.Serialize(students, opts);
			File.WriteAllText(fullName, t);
		}

		public void Save()
		{
			Save(Students, directory);
		}
	}
}
