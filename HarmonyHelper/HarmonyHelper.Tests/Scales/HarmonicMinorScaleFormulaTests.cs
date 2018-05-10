using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class HarmonicMinorScaleFormulaTests
	{
		[TestMethod()]
		public void HarmonicMinorScaleFormulaTest()
		{
			var keys = KeySignature.MinorKeys;
			foreach (var key in keys)
			{
				var scale = new HarmonicMinorScaleFormula(key);
				Debug.WriteLine(scale.ToString());
				new object();
			}
			//Debug.WriteLine(scale.ToString());
			new object();
		}
	}
}