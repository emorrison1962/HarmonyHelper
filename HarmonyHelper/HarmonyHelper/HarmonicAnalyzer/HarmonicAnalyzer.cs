using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public class HarmonicAnalyzer
	{
		public HarmonicAnalyzer()
		{

		}

		public List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key, bool unused = false)
		{
			var result = new List<HarmonicAnalysisResult>();
			foreach (var rule in HarmonicAnalysisRuleBase.Catalog)
			{
				var har = rule.Analyze(chords, key);
				result.AddRange(har);
			}

			return result;
		}

		static public List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var analyzer = new HarmonicAnalyzer();
			var result = analyzer.Analyze(chords, key, false);
			return result;
		}
	}
}
