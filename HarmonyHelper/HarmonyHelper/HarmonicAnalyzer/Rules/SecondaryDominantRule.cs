using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
	public class SecondaryDominantRule : HarmonicAnalysisRuleBase
	{
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
		{
			var success = false;
			var pairs = chords.GetPairs();
			foreach (var pair in pairs)
			{
				if (pair[0].ChordType.IsDominant)
				{
					var interval = pair[0].Root - pair[1].Root;
					if (pair[0].Root - pair[1].Root == Interval.Perfect5th)
					{
						Debug.WriteLine($"{pair[0]}, {pair[1]}");
						success = true;
					}
				}
			}

			var result = new List<HarmonicAnalysisResult>();
			result.Add(new HarmonicAnalysisResult(this, success, "NotImplemented"));
			return result;
		}
	}
}
