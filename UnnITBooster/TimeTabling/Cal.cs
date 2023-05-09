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
