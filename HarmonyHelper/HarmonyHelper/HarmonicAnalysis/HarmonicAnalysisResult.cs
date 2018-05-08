using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

namespace Eric.Morrison.Harmony.HarmonicAnalysis
{
	class HarmonicAnalysisResultEmpty : HarmonicAnalysisResult
	{
		public HarmonicAnalysisResultEmpty() : base (null, false, "")
		{
		}
	}
	public class HarmonicAnalysisResult
	{
		static public readonly HarmonicAnalysisResult Empty = new HarmonicAnalysisResultEmpty();

		public bool Success { get; private set; }
		public HarmonicAnalysisRuleBase Rule { get; private set; }
		public string Message { get; private set; }

		public HarmonicAnalysisResult(HarmonicAnalysisRuleBase rule, bool success, string message)
		{
			this.Rule = rule;
			this.Success = success;
			this.Message = message;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}