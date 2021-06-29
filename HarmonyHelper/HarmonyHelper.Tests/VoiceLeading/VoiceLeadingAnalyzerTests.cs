using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class VoiceLeadingAnalyzerTests
	{
		[TestMethod()]
		public void VoiceLeadingAnalyzerTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UseCaseOne()
		{
			var analyzer = new VoiceLeadingAnalyzer();

			var I = ChordFormulaCatalog.A7;
			var IV = ChordFormulaCatalog.D7;

			//analyzer.Analyze(I, IV);
		}


	}//class
}//ns