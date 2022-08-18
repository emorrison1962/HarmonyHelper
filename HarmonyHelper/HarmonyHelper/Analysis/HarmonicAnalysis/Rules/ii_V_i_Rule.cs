﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class ii_V_I_Rule : HarmonicAnalysisRuleBase
	{
		public override string Name { get { return this.GetType().Name; } }
		public override string Description => @"The ii–V–I progression (""two–five–one progression"") (occasionally referred to as ii–V–I turnaround, and ii–V–I) is a common cadential chord progression used in a wide variety of music genres, including jazz harmony.";

        public override List<HarmonicAnalysisResult> Analyze(List<Chord> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();

			var triplets = chords.GetTriplets();
			//.Where(x => x[1].IsDominant 
			//&& x[0].Root - x[1].Root == Interval.Perfect5th
			//&& x[1].Root - x[2].Root == Interval.Perfect5th);

			foreach (var triplet in triplets)
			{//Minor: bm7b5, e7, am7 Major: bm7 e7 amaj7
				if (key.NoteName == triplet[2].Root.NoteName)
				{
					if (triplet.Select(x => x.Formula).IsTwoFiveOne(key))
					{
						if (key.IsMinor)
						{//ii V i minor.
							result.Add(
								new HarmonicAnalysisResult(this, true,
								$"{string.Join(", ", triplet.Select(x => x.Name))} is a ii, V, i in {key.Name}.", 
								triplet.ToList()));
						}
						else
						{
							result.Add(
								new HarmonicAnalysisResult(this, true,
								$"{string.Join(", ", triplet.Select(x => x.Name))} is a ii, V, I in {key.Name}.",
								triplet.ToList()));
						}
					}
				}
			}

			return result;
		}

	}//class
}//ns