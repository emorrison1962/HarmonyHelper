using System.Collections.Generic;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

namespace Eric.Morrison.Harmony.HarmonicAnalysis
{
	class HarmonicAnalysisResultEmpty : HarmonicAnalysisResult
	{
		public HarmonicAnalysisResultEmpty() : base (null, false, "", (Chord)null)
		{
		}
	}

	public class HarmonicAnalysisResult
	{
		static public readonly HarmonicAnalysisResult Empty = new HarmonicAnalysisResultEmpty();

		public bool Success { get; private set; }
		public HarmonicAnalysisRuleBase Rule { get; private set; }
		public string Message { get; private set; }
		public List<Chord> Chords { get; private set; }

		public HarmonicAnalysisResult(HarmonicAnalysisRuleBase rule, bool success, string message, Chord chord)
			: this(rule, success, message, new List<Chord>() { chord })
		{
		}

		public HarmonicAnalysisResult(HarmonicAnalysisRuleBase rule, bool success, string message, List<Chord> chords)
		{
			this.Rule = rule;
			this.Success = success;
			this.Message = message;
			this.Chords = chords;	
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}