using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class SecondaryDominantRule : HarmonicAnalysisRuleBase
	{
		public override string Name { get { return this.GetType().Name; } }

		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();
			var nonDiatonic = key.GetNonDiatonic(chords);
			if (nonDiatonic.Count > 0)
			{
				var pairs = chords.GetPairs();
				foreach (var pair in pairs)
				{
					if (!pair[0].IsDominantOfKey(key))
					{
						if (nonDiatonic.Contains(pair[0]) && pair[0].ChordType.IsDominant)
						{
							var interval = pair[0].Root - pair[1].Root;
							if (pair[0].Root - pair[1].Root == Interval.Perfect5th)
							{
								//Debug.WriteLine($"{pair[0]}, {pair[1]}");
								result.Add(
									new HarmonicAnalysisResult(this, true, 
										$"{pair[0].Name} could be considered a secondary dominant to {pair[1].Name}.",
										new List<ChordFormula> { pair[0], pair[1] }));
							}
						}
					}
				}
			}

			return result;
		}
	}
}
