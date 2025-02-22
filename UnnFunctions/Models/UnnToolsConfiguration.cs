using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnnItBooster.Models;

namespace UnnFunctions.Models
{
	public class UnnToolsConfiguration
	{
		private const string applicationConfigFileName = "UnnToolsConfig.json";

		[JsonIgnore]
		public static UnnToolsConfiguration Settings { get; } = Init();


		private StudentsRepository? _repo = null;

		[JsonIgnore]
		public StudentsRepository StudentsRepository
		{
			get
			{
				if (_repo == null)
					_repo = new StudentsRepository(StudentRepositoryFolder);
				return _repo;
			}
		}

		private static UnnToolsConfiguration Init()
		{
			string path = GetConfigFile();
			if (File.Exists(path))
			{
				try
				{
					var content = File.ReadAllText(path);
					var ret = JsonSerializer.Deserialize<UnnToolsConfiguration>(content);
					if (ret != null)
						return ret;
				}
				catch (Exception)
				{

				}
			}
			return new UnnToolsConfiguration();
		}

		private static string GetConfigFile()
		{
			var t = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			var path = Path.Combine(t.FullName, applicationConfigFileName);
			return path;
		}

		public UnnToolsConfiguration()
        {
			StudentRepositoryFolder = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
					"Students"
					);
		}

		private string _studentRepositoryFolder = string.Empty;
		public string StudentRepositoryFolder
		{
			get
			{
				if (!Directory.Exists(_studentRepositoryFolder))
					Directory.CreateDirectory(_studentRepositoryFolder);
				return _studentRepositoryFolder;
			}
			set => _studentRepositoryFolder = value;
		}

		public void Save()
		{
			var file = new FileInfo(GetConfigFile());
			JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
			var ser = JsonSerializer.Serialize(this, options);
			using var destFile = file.CreateText();
			destFile.Write(ser);

			if (_repo is not null)
			{
				_repo.SetConfigurationFolder(StudentRepositoryFolder);
			}
		}
	}
}
