using System.Collections.Generic;

namespace StudentsFetcher
{
    public class Marking
    {
        public Marking()
        {
            Mark = -1;
        }

        public int Credits { get; set; }
        public int Mark { get; set; }
        public string MarkStatus { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        static internal string getstat(List<Marking> data, int filter)
        {
            if (data == null)
                return ((double)0).ToString("f2");
            int Mark = 0;
            int Credits = 0;
            foreach (Marking m in data)
            {
                if (
                    (filter == -1 || filter == m.Level)
                    &&
                    (m.Mark != -1)
                    )
                {
                    Mark += m.Mark * m.Credits;
                    Credits += m.Credits;
                }
            }
            if (Credits == 0)
                return "0";
            return ((double)Mark / Credits).ToString("f2");
        }
    }

}
