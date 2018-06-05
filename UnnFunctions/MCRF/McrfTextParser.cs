using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnnFunctions.MCRF
{
    public class McrfTextParser
    {
        public string ParseComponents(string mcrfText, int numComponents)
        {
            var textOut = new StringBuilder();
            var regexBuilder = new StringBuilder();
            regexBuilder.Append(@"(?<uid>\d+)/\d "); // id (consumes space at the end)
            regexBuilder.Append(@"(?<extra>.+) "); // name and other stuff (consumes space at the end)
            for (int i = 0; i < numComponents + 1; i++)
            {
                regexBuilder.Append($@"(?<comp{i}>\d+) (?<code{i}>\w+) ?"); // name and other stuff (consumes space at the end optionally)
            }
            var re = new Regex(regexBuilder.ToString());

            foreach (Match match in re.Matches(mcrfText))
            {
                textOut.Append(match.Groups["uid"].Value);
                for (int i = 0; i < numComponents + 1; i++)
                {
                    textOut.AppendFormat("\t{0}", match.Groups[$"comp{i}"].Value);
                }
                textOut.AppendLine();
            }
            return textOut.ToString();
        }
    }
}
