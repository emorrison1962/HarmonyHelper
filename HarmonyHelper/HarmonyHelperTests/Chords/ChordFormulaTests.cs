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
			var chordFormula = ChordFormula.Bb7;

			for (int i = 0; i <= 10; ++i)
			{
				chordFormula -= Interval.Major3rd;
				Debug.WriteLine(chordFormula.Name);
			}

			new object();
		}

	}//class
}//ns
