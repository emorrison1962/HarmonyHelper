using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class HarmonicAnalyzerTests
	{
		[TestMethod()]
		public void HarmonicAnalyzer_Test()
		{
		}

		[TestMethod()]
		public void Analyze_Test()
		{
			var str = "Dm7 g7 cmaj7";
			if (ChordParser.TryParse(str, out List<Chord> chords, out string message))
			{
				var analysisResults = HarmonicAnalyzer.Analyze(chords);
				foreach (var analysisResult in analysisResults)
				{
					if (analysisResult.Success)
						Debug.WriteLine(analysisResult.Message);
				}
				Assert.IsNotNull(analysisResults);
			}
			else
			{
				Assert.Fail(message);
			}
			Assert.Fail();
		}
		[TestMethod()]
		public void SecondaryDominantRule_Test()
		{
			var str = "Dm7 g7 cmaj7 A7 Dm7 g7 cmaj7 A7";
			if (ChordParser.TryParse(str, out List<Chord> chords, out string message))
			{
				var analysisResults = HarmonicAnalyzer.Analyze(chords);
				foreach (var analysisResult in analysisResults)
				{
					if (null != analysisResult && analysisResult.Success)
						Debug.WriteLine(analysisResult.Message);
				}
				Assert.IsNotNull(analysisResults);
			}
			else
			{
				Assert.Fail(message);
			}
			Assert.Fail();
		}
	}//class
}//ns