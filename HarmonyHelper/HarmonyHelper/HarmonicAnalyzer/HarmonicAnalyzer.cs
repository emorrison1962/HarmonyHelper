using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public class HarmonicAnalyzer
	{
		public HarmonicAnalyzer()
		{

		}

		public List<HarmonicAnalysisResult> Analyze(List<Chord> chords, bool unused = false)
		{
			var result = new List<HarmonicAnalysisResult>();
			foreach (var rule in HarmonicAnalysisRuleBase.Catalog)
			{
				if (rule.SupportsLists)
				{
					var har = rule.Analyze(chords);
					result.Add(har);
				}
				else
				{
					var pairs = chords.GetPairs();
					foreach (var pair in pairs)
					{
						rule.Analyze(pair[0], pair[1]);
					}
				}
			}

			return result;
		}

		static public List<HarmonicAnalysisResult> Analyze(List<Chord> chords)
		{
			var analyzer = new HarmonicAnalyzer();
			var result = analyzer.Analyze(chords, false);
			return result;
		}
	}
}
