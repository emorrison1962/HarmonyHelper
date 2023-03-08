using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using System.Diagnostics;

namespace HarmonyHelperTests.VoiceLeadingAnalyzer
{
	[TestClass()]
	public class VoiceLeadingAnalyzerTests
	{

		[TestMethod()]
		public void UseCaseOne()
		{
			var analyzer = new Eric.Morrison.Harmony.VoiceLeadingAnalyzer();

			var I = ChordFormula.ADominant7;
			var IV = ChordFormula.DDominant7;

			var results = analyzer.Analyze(I, IV);
			foreach (var result in results.Results)
			{
				Debug.WriteLine($"From {result.From} To {result.To} = {result.Interval}");
			}
			new object();
		}


	}//class
}//ns