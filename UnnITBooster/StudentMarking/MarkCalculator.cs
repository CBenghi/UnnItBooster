using System;
using System.Collections.Generic;
using StudentMarking;

namespace StudentsFetcher.StudentMarking
{
	public class MarksCalculator
	{
		public MarksCalculator()
		{
			Marks = new List<MarkComponent>();
		}

		public List<MarkComponent> Marks { get; private set; }

		public int GetFinalMark(string NumericUserId, MarkingConfig cfg)
		{
			double totPerc = 0;
			double totMark = 0;
			double finalMark = -1;

			string sql = "select MARK_Value from TB_Marks inner join TB_Submissions on mark_ptr_submission = SUB_ID where cast (SUB_NumericUserID as int) = cast(" + NumericUserId + " as int) and MARK_ptr_Component = -1";
			int marktot = cfg.ExecuteScalar(sql);
			if (marktot != -1)
			{
				finalMark = marktot;
			}
			else
			{
				foreach (var mc in Marks)
				{
					sql = "select MARK_Value from TB_Marks inner join TB_Submissions on mark_ptr_submission = SUB_ID where cast (SUB_NumericUserID as int) = cast(" + NumericUserId + " as int) and MARK_ptr_Component = " + mc.id;
					int mark = cfg.ExecuteScalar(sql);
					if (mark != -1)
					{
						totMark += mark * mc.percent;
						totPerc += mc.percent;
					}
				}

				if (totPerc != 0)
					finalMark = totMark / totPerc;
				int iFinalMark = (int)Math.Round(finalMark, MidpointRounding.AwayFromZero);
				finalMark = iFinalMark;
			}
			if (finalMark == 49)
				finalMark += 1;
			if (finalMark == 59)
				finalMark += 1;
			if (finalMark == 69)
				finalMark += 1;
			if (finalMark == 79)
				finalMark += 1;
			return (int)finalMark;
		}
	}
	public class MarkComponent
	{
		public int id;
		public double percent;
	}
}
