#nullable enable
using System;
using System.Diagnostics;
using System.IO;
using System.Web.UI.WebControls.WebParts;

namespace UnnItBooster.Models
{
	[DebuggerDisplay("{FullName} {NumericStudentId} {Email}")]
	public class Student
	{
        public string? FullName { get; set; }
		
		
		private string? surname;
		public string? Surname
		{
			get => surname; 
			set
			{
				if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(FullName))
				{
					if (FullName!.EndsWith(value, StringComparison.OrdinalIgnoreCase))
					{
						var index = FullName.IndexOf(value, StringComparison.OrdinalIgnoreCase);
						var fn = FullName.Substring(0, index).Trim();
						if (!string.IsNullOrEmpty(fn) && string.IsNullOrEmpty(forename))
							forename = fn;
					}
				}
				else if (!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(FullName))
				{ 
					FullName = value;
				}
				surname = value;
			}
		}
		public string? Forename
		{
			get => forename; 
			set
			{
				forename = value;
			}
		}
		public string? Route { get; set; } 

		private string numericStudentId = string.Empty;
		private string? forename;

		public string NumericStudentId
		{
			get => numericStudentId;
			set
			{
				if (value.StartsWith("w"))
				{
					numericStudentId = value.Substring(1);
					return;
				}

				if (value.Contains("/"))
				{
					numericStudentId = value.Substring(0, value.IndexOf('/'));
					return;
				}
				numericStudentId = value;
			}
		}
		public string? CourseYear { get; set; } = string.Empty;
		public string? Occurrence { get; set; } = string.Empty;
		public string? Module { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public bool DSSR { get; set; } = false;
		public bool Matches(string filter)
		{
			if (FullName == filter)
				return true;
			if (Surname != null && Surname.Contains(filter))
				return true;
			if (Forename != null && Forename.Contains(filter))
				return true;
			if (NumericStudentId != null && NumericStudentId.Contains(filter))
				return true;
			if (Email != null && Email.Contains(filter))
				return true;
			return false;
		}

		public string PictureName(string pictureFolder)
		{
			return Path.Combine(pictureFolder, string.Format("{0}.jpg", NumericStudentId));
		}
	}
}