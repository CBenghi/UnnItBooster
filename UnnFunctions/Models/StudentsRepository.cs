﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;

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
		foreach (var item in ConfigurationFolder.GetDirectories())
		{
			if (filters is null || filters.Any(x => filters.Contains(item.Name)))
			{
				if (StudentJsonCollection.IsValid(item))
				{
					collections.Add(new StudentJsonCollection(item));
				}
			}
		}
	}

	/// <summary>
	/// Initializes or updates a student collection by name
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

	private readonly string dataFolder;

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
			var di = new DirectoryInfo(dataFolder);
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
		imagePath = "";
		var d = new DirectoryInfo(dataFolder);
		var fl = d.GetFiles($"{student.NumericStudentId}.jpg", SearchOption.AllDirectories).FirstOrDefault();
		if (fl is null)
			return false;
		imagePath = fl.FullName;
		return true;
	}

	public Student? GetStudentById(string numericStudentId)
	{
		foreach (var item in Students)
		{
			if (item.NumericStudentId == numericStudentId)
				return item;
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

	public bool SetStudentInfo(Student student, string collection)
	{
		var coll = collections.FirstOrDefault(x=>x.Name == collection);
		if (coll is null)
			return false;
		if (
			string.IsNullOrEmpty(student.Email)
			&& string.IsNullOrEmpty(student.NumericStudentId)
			)
			return false;
		var toUpdate = coll.Students.FirstOrDefault(x => x.HasEmail(student.Email!));
		if (toUpdate is null && !string.IsNullOrEmpty( student.NumericStudentId))
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
}