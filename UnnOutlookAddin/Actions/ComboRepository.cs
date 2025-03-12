using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnnOutlookAddin.Actions
{
    public class ComboRepository
    {
		public ComboRepository(string code, string destination)
		{
			RepoCode = code;
			Destination = destination;
		}

		public string RepoCode { get; set; }
        public string Destination { get; set; }

        public override string ToString() => RepoCode;
	}
}
