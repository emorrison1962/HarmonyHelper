using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public abstract class HarmonicAnalysisRuleBase
	{
		static public List<HarmonicAnalysisRuleBase> Catalog { get; set; } = new List<HarmonicAnalysisRuleBase>();

		abstract public string Name { get; }

		static HarmonicAnalysisRuleBase()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var rules = assembly.GetTypes().Where(x => x.BaseType == typeof(HarmonicAnalysisRuleBase));
			foreach (var rule in rules)
			{
				var created = Activator.CreateInstance(rule);
				Catalog.Add(created as HarmonicAnalysisRuleBase);
			}
		}

		public HarmonicAnalysisRuleBase()
		{
		}

		public abstract List<HarmonicAnalysisResult> Analyze(List<Chord> chords, KeySignature key);

	}//class
}//ns