using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
    /// <summary>
    /// What is a Secondary Dominant ?
    /// A dominant 7th chord that is NOT built on the fifth degree(V) of the current scale.Or: Any dominant 7th chord that resolves somewhere else than on the tonic (I) by means of of a “V – I” cadence.
    /// 
    /// Here’s why:
    /// 
    /// 
    /// We know we can find the dominant chord on the fifth degree of the major scale. For instance, if we are in C major, the dominant (V) is G7.A secondary dominant is built from another note (NOT the V) and progresses(aka “wants to resolve”) towards other chord(s) in the key(and not the tonic.)
    /// </summary>
    public class SecondaryDominantRule : HarmonicAnalysisRuleBase
	{
		public override string Name { get { return "Secondary Dominant"; } }
		public override string Description => @"A secondary dominant is a dominant 7th chord that is NOT built on the fifth degree(V) of the current scale.Or: Any dominant 7th chord that resolves somewhere else than on the tonic (I) by means of of a “V – I” cadence.";


		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
		{
            var result = new List<HarmonicAnalysisResult>();
            var key = KeySignature.DetermineKey(chords);
            var nonDiatonic = key.GetNonDiatonic(chords);
            if (nonDiatonic.Count > 0)
            {
                var pairs = chords.GetPairs();
                foreach (var pair in pairs)
                {
                    if (!pair[0].IsDominantOfKey(key))
                    {
                        if (nonDiatonic.Contains(pair[0]) && pair[0].ChordType.HasFlag(ChordIntervalsEnum.IsDominant))
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
