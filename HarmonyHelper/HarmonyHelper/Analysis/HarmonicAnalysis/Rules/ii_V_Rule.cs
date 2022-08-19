using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules
{
    public class ii_V_Rule : HarmonicAnalysisRuleBase
    {
		public override string Name { get { return this.GetType().Name; } }
		public override string Description => @"The ii–V–I progression (""two–five–one progression"") (occasionally referred to as ii–V–I turnaround, and ii–V–I) is a common cadential chord progression used in a wide variety of music genres, including jazz harmony.";

		public override List<HarmonicAnalysisResult> Analyze(List<Chord> chords, KeySignature unused)
		{
			var result = new List<HarmonicAnalysisResult>();

			var pairs = chords.GetItems(2);
			foreach (var pair in pairs)
			{//Minor: bm7b5, e7, am7 Major: bm7 e7 amaj7
				foreach (var key in KeySignature.Catalog)
				{
					if (pair.Select(x => x.Formula).IsTwoFive(key))
					{
						if (key.IsMinor)
						{//ii V i minor.
							result.Add(
								new HarmonicAnalysisResult(this, true,
								$"{string.Join(", ", pair.Select(x => x.Name))} is a ii, V, i in {key.Name}.",
								pair.ToList()));
						}
						else
						{
							result.Add(
								new HarmonicAnalysisResult(this, true,
								$"{string.Join(", ", pair.Select(x => x.Name))} is a ii, V in {key.Name}.",
								pair.ToList()));
						}
					}
				}
			}

			return result;
		}


	}
}
