using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class TritoneSubstitutionRule : HarmonicAnalysisRuleBase
	{
		public override string Name { get { return "Tritone Substitution"; } }
		public override string Description => @"A tritone substitution is the substitution of one dominant seventh chord (possibly altered or extended) with another that is three whole steps (a tritone) from the original chord. In other words, tritone substitution involves replacing V7 with ♭II7";

		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
		{
            var result = new List<HarmonicAnalysisResult>();
            //var nonDiatonic = key.GetNonDiatonic(chords);
            var pairs = chords.GetPairs().Where(x => (x[0].Root - x[1].Root) == Interval.Minor2nd);
            foreach (var pair in pairs)
            {
                if (pair[0].ChordType.HasFlag(ChordIntervalsEnum.IsDominant))
                {
                    var tonic = pair[1].Root;
                    var subbedRoot = tonic + ChordToneInterval.Perfect5th;
                    var subbedFor = ChordFormula.Catalog
                        .Where(x => x.Root == subbedRoot
                            && x.ChordType == ChordIntervalsEnum.Dominant7th)
                        .First();

                    result.Add(new HarmonicAnalysisResult(this, true,
                        $"{pair[0].Name} could be considered a tritone substitution for {subbedFor.Name}.",
                                                                new List<ChordFormula> { pair[0], subbedFor }));
                }
            }

            return result;
        }
    }//class
}//ns

