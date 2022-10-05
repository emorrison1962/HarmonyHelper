using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony.HarmonicAnalysis
{
	public class HarmonicAnalyzer
	{
		public HarmonicAnalyzer()
		{

		}

        static public List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords)
        {
            var analyzer = new HarmonicAnalyzer();
            var result = analyzer.Analyze(chords);
            return result;
        }

        public List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, bool unused = false)
        {
            var result = new List<HarmonicAnalysisResult>();
            foreach (var rule in HarmonicAnalysisRuleBase.Catalog)
            {
                var har = rule.Analyze(chords);
                result.AddRange(har);
            }

            return result;
        }
    }//class
}//ns
