using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public class SecondaryDominantRule : HarmonicAnalysisRuleBase
	{
		public override HarmonicAnalysisResult Analyze(List<Chord> chords)
		{
			var success = false;
			var pairs = chords.GetPairs();
			foreach (var pair in pairs)
			{
				if (pair[0].Formula.ChordType.IsDominant)
				{
					if (pair[0].Root - pair[1].Root == Interval.Perfect4th)
					{
						success = true;
					}
				}
			}
			return new HarmonicAnalysisResult(this, success, "NotImplemented");
		}
	}
}
