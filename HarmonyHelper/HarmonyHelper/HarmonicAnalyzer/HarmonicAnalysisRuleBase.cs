﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony
{
	public abstract class HarmonicAnalysisRuleBase
	{
		static public List<HarmonicAnalysisRuleBase> Catalog { get; set; } = new List<HarmonicAnalysisRuleBase>();

		abstract public bool SupportsLists { get; }

		static HarmonicAnalysisRuleBase()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var rules = assembly.DefinedTypes.Where(x => x.BaseType == typeof(HarmonicAnalysisRuleBase));
			foreach (var rule in rules)
			{
				Activator.CreateInstance(rule);
			}
		}

		public HarmonicAnalysisRuleBase()
		{
			Catalog.Add(this);
		}

		public abstract HarmonicAnalysisResult Analyze(Chord a, Chord b);
		public abstract HarmonicAnalysisResult Analyze(List<Chord> chords);

	}//class
}//ns