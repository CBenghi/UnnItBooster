using System;

namespace StudentsFetcher.TimeTabling
{
    public class CalItem
    {
        public DayOfWeek Day;
        public int from;
        public int to;
        public string Event;
        public string weeks;

        public CalItem()
        {
        }

        public CalItem(string Day1, int from, int to, string Event, string weeks)
        {
            this.Day = GetDay(Day1);
            this.from = from;
            this.to = to;
            this.Event = Event;
            this.weeks = weeks;
        }

        public static DayOfWeek GetDay(string Day1)
        {
            return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Day1);
        }
    }
}
