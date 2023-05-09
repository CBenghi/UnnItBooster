using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnnFunctions.Students
{
    public enum StudentRelationType
    {
        Module,
        Tutorship,
    }

    public class StudentRelation
    {
        public StudentRelationType Type { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }

    }
}
