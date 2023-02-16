using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class VoiceLeadingAnalyzerTests
	{

		[TestMethod()]
		public void UseCaseOne()
		{
			var analyzer = new VoiceLeadingAnalyzer();

			var I = ChordFormula.A7;
			var IV = ChordFormula.D7;

			var results = analyzer.Analyze(I, IV);
			foreach (var result in results.Results)
			{
				Debug.WriteLine($"From {result.From} To {result.To} = {result.Interval}");
			}
			new object();
		}


	}//class
}//ns