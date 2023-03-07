using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class Dim7ForDom7SubstitutionRule : HarmonicAnalysisRuleBase
	{

#if false
 Rule VIII: Dom     Chords (V     ) 

				   7                                     7 
Subs%tute Dim  chord built on bII of the Dom  chord. 

Ex. 56 

										7 
Also the other 3 symmetric dim  chords and their extensions 

Ex. 57 
				G7b9     = Abo7,     Bo7,              Do7,              Fo7 

										  Extensions of Dim7 Chords 
#endif
		public override string Name { get { return "Diminished 7 for Dominant 7 substitution"; } }
		public override string Description => @"A diminished 7 chord can replace an altered dominant 7 chord (commonly b9 or #9) when the root of the diminished 7 is a half-step above the root of the altered dominant 7.";

		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
		{
            var result = new List<HarmonicAnalysisResult>();
            var key = KeySignature.DetermineKey(chords);
            var nonDiatonic = key.GetNonDiatonic(chords);
            var success = false;
            var diminishedChords = chords.Where(x => x.IsDiminished);
            if (diminishedChords.Count() > 0)
                success = true;
            if (success)
            {
                // get pairs where first chord is diminished
                var pairs = chords.GetPairs().Where(x => x[0].IsDiminished);
                foreach (var pair in pairs)
                {
                    var firstChord = pair[0];
                    var secondChord = pair[1];

                    //get the dim inversions
                    var dimInversions = new List<NoteName>() {
                                    firstChord.Root,
                                    firstChord.Root + ChordToneInterval.Minor3rd,
                                    firstChord.Root + ChordToneInterval.Diminished5th,
                                    firstChord.Root + ChordToneInterval.Diminished7th,
                                };

                    var dominants = new List<ChordFormula>();
                    //subtract 1/2 step to create a dom7.
                    foreach (var dim in dimInversions)
                    {
                        var txposedDim = dim - ChordToneInterval.AugmentedUnison;
                        var root = ChordFormula.EnsureValidRoot(txposedDim);
                        var chord = ChordFormula.Catalog
                            .Where(x=> x.Root == root 
                                && x.ChordType == ChordIntervalsEnum.ChordTypeDominant7th)
                            .First();
                        dominants.Add(chord);
                    }


                    //now, does dom7 resolve to next chord? (dom root == next.fifth?)
                    var fifth = secondChord.Root + ChordToneInterval.Perfect5th;
                    var subbedFor = dominants
                        .Where(x => x.Root == fifth)
                        .FirstOrDefault();
                    if (null != subbedFor)
                    {
                        result.Add(
                            new HarmonicAnalysisResult(this, true,
                            $"{firstChord.Name} could be considered a diminished 7th substitution for {subbedFor.Name}.",
                            new List<ChordFormula> { firstChord, subbedFor }));
                    }
                }
            }

            return result;
        }
    }//class
}//ns
