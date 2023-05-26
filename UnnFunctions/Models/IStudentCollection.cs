using System.Collections.Generic;

namespace UnnItBooster.Models
{
	public interface IStudentCollection
	{
		List<Student> Students { get; set; }

		string Name { get; }

		string? OutlookFolder { get; set; }

		void Save();
	}
}