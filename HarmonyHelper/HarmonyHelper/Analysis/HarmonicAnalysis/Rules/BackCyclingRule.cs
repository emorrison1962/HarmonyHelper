using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	/// <summary>
	/// WHAT IS BACK CYCLING?
	///	Before you dive into applying this concept to your playing, let’s look at the theory behind this common chord substitution and how you can apply it to your playing.
	///
	///
	/// Here is the basic definition of back cycling to check out before we dissect that theory further.
	/// 
	/// 
	/// Back Cycling is when you take one chord progression, such as a ii-V-I, and you substitute a cycle of V7 changes over those chords, such as ii-II-V-I.
	/// 
	/// This may seem simple on paper, but it can pose a challenge to apply on the guitar, mostly because you are seeing one set of chords on the page, hearing that same set of chords in the band, but playing a completely different set of chords in your comping or soloing phrases.
	/// 
	/// The term back cycling is so labeled because you start at the resolution chord (such as the Imaj7 in a ii-V-I phrase) and you work back using the cycle of V7s to create your chord substitutions.
	/// 
	/// For example: playing the progression Dm7-D7 G7-Cmaj7 over Dm7-G7-Cmaj7.
	/// 
	/// The reason this works is that the subs are dominant chords (V7s) of the next chord in the progression. D7 shouldn’t sound good over G7, but in the progression, it resolves to the next chord (G7) as it is the V7 of that chord.
	/// 
	/// This creates that cool, tension-and-release sound that you hear in many classic jazz solos, and one that can add a new level of interest to your comping and soloing performance.
	/// 
	/// To create more tension in your lines, you simply work back the cycle of V7s further, always adding the V7 of the chord you are on before that chord in the changes.
	/// 
	/// If you were to do this to a ii-V-I progression, which you will see in more detail in the next section of this lesson, you would get:
	/// 
	/// 
	/// Dm7-G7-Cmaj7
	/// Dm7-D7 G7-Cmaj7
	/// Dm7 A7-D7 G7-Cmaj7
	/// E7 A7-D7 G7-Cmaj7
	/// As you can see, in each example I’ve added one more V7 chord before the V7 in the progression, which eventually creates a V7 of, V7 of, V7 of, V7 to Imaj7 progression.
	/// 
	/// 
	/// The essence of back cycling is that you are creating tension, but the cycle of V7s is such a recognizable progression that these subs can be followed by the listener until you resolve the subs to an “inside” chord in the phrase.
	/// 
	/// 
	/// It will take some time for your ears to become accustomed to this level of tension and release in your playing, so start today and over time you will begin to hear this kind of chord sub concept as normal in your comping and soloing.
	/// </summary>
	public class BackCyclingRule : HarmonicAnalysisRuleBase
	{
		const string DESCRIPTION =
			@"Back Cycling is when a chord progression, such as a ii-V-I, substitutes a cycle of V7 changes over those chords, such as ii-II7-V-I.";
		public override string Name { get { return "Back Cycling"; } } 
		public override string Description { get { return DESCRIPTION; } }
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> input)
		{
            var result = new List<HarmonicAnalysisResult>();

            var chords = new List<ChordFormula>(input);
            //Debug.WriteLine($"Chrds: {string.Join(", ", chords.Select(x => x.Name))}");

            var pairs = chords.GetPairs().Where(x => (x.First.Root - x.Second.Root) == Interval.Minor2nd).ToList();
            foreach (var pair in pairs)
            {
                if (pair.First.ChordType.IsDominant)
                {
                    var subbedFor = this.GetTritoneSubstitution(pair.First);
                    var seq = chords.FindAll(x => x == pair.First);
                    foreach (var item in seq)
                    {
                        var ndx = chords.IndexOf(item);
                        chords[ndx] = subbedFor;
                    }

                    //Debug.WriteLine($"{pair[0].Name} is a tritone sub for {subbedFor.Name}");
                    new object();
                }
            }

            var theCycle = this.CreateCycle();
            //Debug.WriteLine($"Cycle: {string.Join(", ", theCycle)}");
            var roots = chords.Select(x => x.Root);
            //Debug.WriteLine($"Roots: {string.Join(", ", roots)}");


            int startNdx = 0;
            int lastNdx = 0;
            var success = false;
            while (lastNdx < chords.Count)
            {
                success = theCycle.TryGetSubequence(roots.Select(x => x),
                    new NoteNameValueEqualityComparer(),
                    out List<NoteName> subSequence, ref lastNdx);
                //Debug.WriteLine(lastNdx);
                //Debug.WriteLine($"subSequence: {string.Join(", ", subSequence)}");

                new object();


                if (success)
                {
                    //var seq = chords.GetRange(startNdx, lastNdx - startNdx).ToList();
                    var seq = input.GetRange(startNdx, lastNdx - startNdx).ToList();
                    Debug.Assert(seq.Count() == subSequence.Count);

                    var har = new HarmonicAnalysisResult(this,
                        true,
                        $"The sequence: {string.Join(", ", seq.Select(x => x.Name))} could be considered harmonic back-cycling.",
                        seq.ToList());

                    result.Add(har);
                    //Debug.WriteLine(har.Message);
                    //new object();
                }
                startNdx = lastNdx;

            }


            return result;
        }

        List<NoteName> CreateCycle()
		{
			var result = new List<NoteName>();

			var key = KeySignature.FSharpMajor;
			var perfect4th = Interval.Perfect4th;

			const int CYCLE_MAX = 24;
			for (int i = 0; i < CYCLE_MAX; ++i)
			{
				result.Add(key.NoteName);
				key += perfect4th;
			}

			//result.ForEach(x => Debug.WriteLine(x));
			return result;
		}

		ChordFormula GetTritoneSubstitution(ChordFormula orig)
		{
			ChordFormula result = null;
			if (orig.IsDominant)
			{
				var resultFormula = orig + ChordToneInterval.Augmented4th;
				result = new ChordFormula(resultFormula);
			}
			return result;
		}



	}//class

	public static class ExtensionMethods
	{
		public static bool TryGetSubequence<T>(this IEnumerable<T> sequenceBeingSearched, IEnumerable<T> sequenceToFind, IEqualityComparer<T> comparer, out List<T> subSequence, ref int lastNdx)
		{
			subSequence = new List<T>();

			bool matchFound = false;
			var wantedList = sequenceToFind.ToList().GetRange(lastNdx, sequenceToFind.Count() - lastNdx).ToList();
			//Debug.WriteLine($"wantedList: {string.Join(", ", wantedList)}");
			int ndx = 0;

			using (IEnumerator<T> sequenceBeingSearchedEnum = sequenceBeingSearched.GetEnumerator())
			{
				while (sequenceBeingSearchedEnum.MoveNext())
				{
					if (comparer == null ?
						wantedList[ndx].Equals(sequenceBeingSearchedEnum.Current) :
						comparer.Equals(wantedList[ndx], sequenceBeingSearchedEnum.Current))
					{
						// Match, so move the target enum forward
						if (!subSequence.Contains(sequenceBeingSearchedEnum.Current, comparer))
						{
							subSequence.Add(sequenceBeingSearchedEnum.Current);
							lastNdx++;
						}
						matchFound = true;
						if (ndx == wantedList.Count - 1)
						{
							// We went through the entire target, so we have a match
							break;
						}

						ndx++;
					}
					else if (matchFound)
					{
						matchFound = false;
						ndx = 0;

						if (comparer == null ?
							wantedList[ndx].Equals(sequenceBeingSearchedEnum.Current) :
							comparer.Equals(wantedList[ndx], sequenceBeingSearchedEnum.Current))
						{
							if (!subSequence.Contains(sequenceBeingSearchedEnum.Current, comparer))
							{
								subSequence.Add(sequenceBeingSearchedEnum.Current);
							}
							matchFound = true;
							lastNdx++;
							ndx++;
						}
					}
				}

				var result = false;
				if (subSequence.Count < 4)
				{
					result = false;
					subSequence.Clear(); // if we don't have more tha 4 elements, we don't have backcycling.
				}
				else
					result = true;
				return result;
			}
		}
	}//class
}//ns
