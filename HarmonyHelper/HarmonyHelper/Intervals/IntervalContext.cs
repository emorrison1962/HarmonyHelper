using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Intervals
{
	[Obsolete("", false)]
	public class IntervalContext
	{
		public INoteNameNormalizer NoteNameNormalizer { get; private set; }
		public Interval Interval { get; private set; }

		public IntervalContext(INoteNameNormalizer noteNameNormalizer, Interval interval)
		{
			this.NoteNameNormalizer = noteNameNormalizer;
			this.Interval = interval;
		}
	}
}
