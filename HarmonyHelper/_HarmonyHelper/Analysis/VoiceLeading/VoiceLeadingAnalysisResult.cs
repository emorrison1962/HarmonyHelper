using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	public class VoiceLeadingAnalysisResult
	{
		public List<VoiceLeadingResult> Results { get; private set; } = new List<VoiceLeadingResult>();
		public void Add(VoiceLeadingResult vlr)
		{
			this.Results.Add(vlr);
		}
	}

	public class VoiceLeadingResult
	{
		public NoteName From { get; private set; }
		public NoteName To { get; private set; }
		public Interval Interval { get; private set; }

		public VoiceLeadingResult(NoteName from, NoteName to, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			From = from;
			To = to;
			Interval = interval;
		}
	}

}
