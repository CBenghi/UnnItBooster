using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StudentsFetcher.TimeTabling
{
    public class Cal : List<CalItem>
    {
        public bool IsFreeOn(DayOfWeek day, int from, int to)
        {
            foreach (var item in this)
            {
                if (item.Day == day)
                {
                    int iFrom = Math.Max(from, item.from);
                    int iTo = Math.Min(to, item.to);

                    if (iFrom < iTo)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string LinkName;

        internal static Cal getStudent(string StudentId, int from, int to)
        {
            Cal c = new Cal();
            if (StudentId == "")
                StudentId = "10017655";

            c.LinkName = StudentId;

            string url =
                string.Format(
                "http://aldershot:6600/Reporting/TextSpreadSheet?objectClass=Students&idType=id&identifier={0}&weeks={1}-{2}",
                StudentId, from, to
                );
            string s = ReportServer.getSqlReport(url);


            Regex r = new Regex("Weeks</td>.*?</table>", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            foreach (Match item in r.Matches(s))
            {
                string thisMatch = item.Value;
                string ignoredNewline = "[^<]*";

                string sInt = "<tr>" + ignoredNewline +
                    "<td>(?<Day>.*?)</td>" + ignoredNewline +
                    "<td>(?<From>\\d*?):00</td>" + ignoredNewline +
                    "<td>(?<To>\\d*?):00</td>" + ignoredNewline +
                    "<td>(?<ModuleEvent>.*?)</td>" + ignoredNewline +
                    "<td>(?<ModuleTitle>.*?)</td>" + ignoredNewline +
                    "<td>(?<Room>.*?)</td>" + ignoredNewline +
                    "<td>(?<Weeks>.*?)</td>" + ignoredNewline +
                    "</tr>";
                Regex inM = new Regex(sInt, RegexOptions.Singleline);
                foreach (Match eventData in inM.Matches(thisMatch))
                {
                    string Day = eventData.Groups["Day"].Value;
                    int ifrom = Convert.ToInt32(eventData.Groups["From"].Value);
                    int ito = Convert.ToInt32(eventData.Groups["To"].Value);
                    string Event = eventData.Groups["ModuleEvent"].Value;
                    string weeks = eventData.Groups["Weeks"].Value;

                    CalItem cI = new CalItem(Day, ifrom, ito, Event, weeks);
                    c.Add(cI);
                }
            }
            return c;
        }

        internal int ContinuousStretchAfter(TimeSlot t)
        {
            int contStretch = 0;
            int from = t.to;
            while (!IsFreeOn(t.dayOfWeek, from, from + 1))
            {
                contStretch++;
                from++;
            }
            return contStretch;
        }

        internal int ContinuousStretchBefore(TimeSlot t)
        {
            int contStretch = 0;
            int from = t.from - 1;
            while (!IsFreeOn(t.dayOfWeek, from, from + 1))
            {
                contStretch++;
                from--;
            }
            return contStretch;
        }

        internal bool IsFreeOn(TimeSlot t)
        {
            return IsFreeOn(t.dayOfWeek, t.from, t.to);
        }

        internal bool IsDayFree(DayOfWeek day)
        {
            foreach (var item in this)
            {
                if (item.Day == day)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
