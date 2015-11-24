using System;

namespace StudentsFetcher.TimeTabling
{
    public class TimeSlot
    {
        public DayOfWeek dayOfWeek;
        public int from;
        public int to;

        public TimeSlot(DayOfWeek dayOfWeek, int p1, int p2)
        {
            // TODO: Complete member initialization
            this.dayOfWeek = dayOfWeek;
            this.from = p1;
            this.to = p2;
        }

    }
}
