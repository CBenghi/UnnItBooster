using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unn.Students
{
    public class StudentId
    {
        public static string NumericFromString(string stringId)
        {
            if (stringId.StartsWith("w"))
                stringId = stringId.Substring(1);
            else if (stringId.StartsWith("n"))
                stringId = "01" + stringId.Substring(1);
            else if (stringId.StartsWith("o"))
                stringId = "02" + stringId.Substring(1);
            else if (stringId.StartsWith("p"))
                stringId = "03" + stringId.Substring(1);
            else if (stringId.StartsWith("q"))
                stringId = "04" + stringId.Substring(1);
            else if (stringId.StartsWith("r"))
                stringId = "05" + stringId.Substring(1);
            else if (stringId.StartsWith("s"))
                stringId = "06" + stringId.Substring(1);
            else if (stringId.StartsWith("t"))
                stringId = "07" + stringId.Substring(1);
            else if (stringId.StartsWith("u"))
                stringId = "08" + stringId.Substring(1);
            else if (stringId.StartsWith("v"))
                stringId = "09" + stringId.Substring(1);
            else
                return string.Empty;
            return stringId;
        }
    }
}
