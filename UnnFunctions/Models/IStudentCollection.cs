using System.Collections.Generic;
using UnnFunctions.Students;

namespace UnnItBooster.Models
{
	public interface IStudentCollection
	{
		List<Student> Students { get; set; }

		string Name { get; }

		void Save();
	}
}