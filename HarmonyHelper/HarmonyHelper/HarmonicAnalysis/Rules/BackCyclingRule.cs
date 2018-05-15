using System;
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
			var sequenceStart = theCycle.IndexOfSequence(roots, new NoteNameValueEqualityComparer());
			new object();

			//var dominants = chords.Where(x => x.IsDominant).ToList();
			//var indeces = dominants.Select(x => dominants.IndexOf(x));


			//var nonDiatonic = key.GetNonDiatonic(chords);
			//if (nonDiatonic.Count > 0)
			//{
			//	var pairs = chords.GetPairs();
			//	foreach (var pair in pairs)
			//	{
			//		if (nonDiatonic.Contains(pair[0]) && pair[0].ChordType.IsDominant)
			//		{
			//			var interval = pair[0].Root - pair[1].Root;
			//			if (pair[0].Root - pair[1].Root == Interval.Perfect5th)
			//			{
			//				//Debug.WriteLine($"{pair[0]}, {pair[1]}");
			//				result.Add(
			//					new HarmonicAnalysisResult(this, true, $"{pair[0].Name} could be considered a secondary dominant to {pair[1].Name}."));
			//			}
			//		}
			//	}
			//}

			return result;
		}

		List<NoteName> CreateCycle()
		{
			var result = new List<NoteName>();

			var key = KeySignature.CMajor;
			var perfect4th = Interval.Perfect4th;

			const int CYCLE_MAX = 24;
			for (int i = 0 ; i < CYCLE_MAX ; ++i)
			{
				result.Add(key.NoteName);
				key = key + perfect4th;
			}

			result.ForEach(x => Debug.WriteLine(x));
			return result;
		}

	}//class

	public static class ExtensionMethods
	{
		public static int IndexOfSequence<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
		{
			return source.IndexOfSequence(sequence, EqualityComparer<T>.Default);
		}

		public static int IndexOfSequence<T>(this IEnumerable<T> source, IEnumerable<T> sequence, IEqualityComparer<T> comparer)
		{
			var result = new List<T>();

			var seq = sequence.ToArray();

			int p = 0; // current position in source sequence
			int i = 0; // current position in searched sequence
			var prospects = new List<int>(); // list of prospective matches
			foreach (var item in source)
			{
				// Remove bad prospective matches
				prospects.RemoveAll(k => !comparer.Equals(item, seq[p - k]));

				// Is it the start of a prospective match ?
				if (comparer.Equals(item, seq[0]))
				{
					prospects.Add(p);
					result.Add(item);
				}

				// Does current character continues partial match ?
				if (comparer.Equals(item, seq[i]))
				{
					prospects.Add(p);
					i++;
					// Do we have a complete match ?
					if (i == seq.Length)
					{
						// Bingo !
						return p - seq.Length + 1;
					}
				}
				else // Mismatch
				{
					// Do we have prospective matches to fall back to ?
					if (prospects.Count > 0)
					{
						// Yes, use the first one
						int k = prospects[0];
						i = p - k + 1;
					}
					else
					{
						// No, start from beginning of searched sequence
						i = 0;
					}
				}
				p++;
			}
			// No match
			return -1;
		}
	}
}//ns
