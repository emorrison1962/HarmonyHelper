using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Intervals
{
	public class IntervalContext
	{
		public KeySignature Key { get; private set; }
		public Interval Interval { get; private set; }

		public IntervalContext(KeySignature key, Interval interval)
		{
			this.Key = key;
			this.Interval = interval;
		}
	}
}
