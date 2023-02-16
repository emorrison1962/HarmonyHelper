using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Scales
{
	[TestClass]
	public class ScaleFormulaTests
	{
		[TestMethod]
		public void ChromaticScaleFormulaTests()
		{
			var scale = new ChromaticScaleFormula(KeySignature.CMajor);
			foreach (var nn in scale.NoteNames)
			{
				Debug.WriteLine(nn);
			}
			new object();
		}
	}
}
