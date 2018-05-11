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
	public class ModalScaleFormulaBaseTests
	{
		[TestMethod()]
		public void ModalScaleFormulaBaseTest()
		{
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();
			foreach (var mode in modes)
			{
				var formula = new ModalMajorScaleFormula(KeySignature.CMajor, mode);
				Debug.WriteLine(formula.ToString());
			}
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Assert.Fail();
		}
	}
}