using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class BackCyclingRule : HarmonicAnalysisRuleBase
	{
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();

			var theCycle = this.CreateCycle();
			var roots = chords.Select(x => x.Root);
			//Debug.WriteLine($"Chrds: {string.Join(", ", chords.Select(x => x.Name))}");
			//Debug.WriteLine($"Roots: {string.Join(", ", roots)}");
			//Debug.WriteLine($"Cycle: {string.Join(", ", theCycle)}");


			int startNdx = 0;
			int lastNdx = 0;
			var success = false;
			while (lastNdx < chords.Count)
			{
				success = theCycle.TryGetSubequence(roots,
					new NoteNameValueEqualityComparer(),
					out List<NoteName> subSequence, ref lastNdx);
				//Debug.WriteLine(lastNdx);
				//Debug.WriteLine($"subSequence: {string.Join(", ", subSequence)}");

				new object();


				if (success)
				{
					var seq = chords.GetRange(startNdx, lastNdx - startNdx).ToList();
					Debug.Assert(seq.Count() == subSequence.Count);
					var har = new HarmonicAnalysisResult(this, true, 
						$"The sequence: {string.Join(", ", seq.Select(x => x.Name))} could be considered harmonic back-cycling.");
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
				key = key + perfect4th;
			}

			//result.ForEach(x => Debug.WriteLine(x));
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
	}


}//ns
