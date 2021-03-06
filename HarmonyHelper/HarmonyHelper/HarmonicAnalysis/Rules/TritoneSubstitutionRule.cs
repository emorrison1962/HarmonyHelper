﻿using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class TritoneSubstitutionRule : HarmonicAnalysisRuleBase
	{
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();
			//var nonDiatonic = key.GetNonDiatonic(chords);
			var pairs = chords.GetPairs().Where(x => (x[0].Root - x[1].Root) == Interval.Minor2nd);
			foreach (var pair in pairs)
			{
				if (pair[0].ChordType.IsDominant)
				{
					var tonic = pair[1].Root;
					var subbedRoot = tonic + new IntervalContext(pair[1].Key, ChordToneInterval.Perfect5th);
					var subbedFor = new ChordFormula(subbedRoot, ChordType.Dominant7th, pair[1].Key);
					result.Add(
						new HarmonicAnalysisResult(this, true, $"{pair[0].Name} could be considered a tritone substitution for {subbedFor.Name}."));
				}
			}

			return result;
		}

	}//class
}//ns

