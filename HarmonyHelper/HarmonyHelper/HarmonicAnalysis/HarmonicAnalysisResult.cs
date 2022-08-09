using System.Collections.Generic;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

namespace Eric.Morrison.Harmony.HarmonicAnalysis
{
	class HarmonicAnalysisResultEmpty : HarmonicAnalysisResult
	{
		public HarmonicAnalysisResultEmpty() : base (null, false, "", (ChordFormula)null)
		{
		}
	}
	public class HarmonicAnalysisResult
	{
		static public readonly HarmonicAnalysisResult Empty = new HarmonicAnalysisResultEmpty();

		public bool Success { get; private set; }
		public HarmonicAnalysisRuleBase Rule { get; private set; }
		public string Message { get; private set; }
		public List<ChordFormula> ChordFormulas { get; private set; }

		public HarmonicAnalysisResult(HarmonicAnalysisRuleBase rule, bool success, string message, ChordFormula formula)
			: this(rule, success, message, new List<ChordFormula>() { formula })
		{
		}

		public HarmonicAnalysisResult(HarmonicAnalysisRuleBase rule, bool success, string message, List<ChordFormula> formulas)
		{
			this.Rule = rule;
			this.Success = success;
			this.Message = message;
			this.ChordFormulas = formulas;	
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}