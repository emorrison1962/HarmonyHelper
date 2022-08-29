using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarmonyHelperTests.Chords
{
	[TestClass()]
	public class ChordFormulaTests
	{
		[TestMethod()]
		public void ColtraneChangesTest()
		{
			var chordFormula = ChordFormulaCatalog.Bb7;

			for (int i = 0; i <= 10; ++i)
			{
				chordFormula -= Interval.Major3rd;
				Debug.WriteLine(chordFormula.Name);
				//var major3rd = Interval.Major3rd;
				//var txposedKey = chordFormula.Key - major3rd;
				//chordFormula = chordFormula - new IntervalContext(txposedKey, major3rd);
			}

			new object();
		}

	}//class
}//ns
