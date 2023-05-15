using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnnItBooster.Helpers;

namespace UnnItBooster.Models
{
	internal class StudentJsonCollection : IStudentCollection
	{
		private const string StandardCollectionName = "students.json";

		private readonly DirectoryInfo directory;

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
			var d = new DirectoryInfo(containerFullName);
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

		private static JsonSerializerOptions SerOptions()
		{
			var options = new JsonSerializerOptions()
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				WriteIndented = true,
			};
			//var facetConverter = new HeterogenousListConverter<IFacet, List<IFacet>>(
			//	(nameof(IfcClassificationFacet), typeof(IfcClassificationFacet)),
			//);
			//options.Converters.Add(facetConverter);
			return options; 
		}

		public void Save()
		{
			Save(Students, directory);
		}
	}
}
