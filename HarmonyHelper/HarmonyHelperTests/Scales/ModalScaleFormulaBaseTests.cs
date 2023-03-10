using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Eric.Morrison.Harmony.Scales;
using System.Reflection;

namespace ModalScaleFormulaBase_Tests
{
	[TestClass()]
	public class ModalScaleFormulaBaseTests
	{
		[TestMethod()]
		public void MajorModalScaleFormulaTest()
		{
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();
			foreach (var mode in modes)
			{
				var formula = new MajorModalScaleFormula(KeySignature.CMajor, mode);
				Debug.WriteLine(formula.ToString());
			}
		}

		[TestMethod()]
		public void HarmonicMinorModalScaleFormulaTest()
		{
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();
			foreach (var mode in modes)
			{
				var formula = new HarmonicMinorModalScaleFormula(KeySignature.AMinor, mode);
				Debug.WriteLine(formula.ToString());
			}
			Debug.WriteLine("");
		}

		[TestMethod()]
		public void MelodicMinorModalScaleFormulaTest()
		{
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();
			foreach (var mode in modes)
			{
				var formula = new MelodicMinorModalScaleFormula(KeySignature.AMinor, mode);
				Debug.WriteLine(formula.ToString());
			}
			Debug.WriteLine("");

		}

		[TestMethod()]
		public void GetScaleTypesViaReflection()
		{
			var assembly = Assembly.GetAssembly(typeof(NoteName));
			var types = assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ScaleFormulaBase)));
			foreach (var t in types)
				Debug.WriteLine(t.Name);
			new Object();

		}

		[TestMethod()]
		public void Debug_WriteLine_Scales()
		{
			var majorKey = KeySignature.CMajor;
			var minorKey = KeySignature.AMinor;
			ScaleFormulaBase formula = null;

			{// major
				formula = new PentatonicMajorScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new MajorModalScaleFormula(majorKey, ModeEnum.Ionian);
				Debug.WriteLine(formula.ToString());
				formula = new WholeToneScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new DiminishedHalfWholeScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new DiminishedWholeHalfScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new ChromaticScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new NonatonicBluesScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new HexatonicBluesScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
				formula = new HeptatonicBluesScaleFormula(majorKey);
				Debug.WriteLine(formula.ToString());
			}
			{//minor
				formula = new HarmonicMinorScaleFormula(minorKey);
				Debug.WriteLine(formula.ToString());
				formula = new MelodicMinorScaleFormula(minorKey);
				Debug.WriteLine(formula.ToString());
				formula = new PentatonicMinorScaleFormula(minorKey);
				Debug.WriteLine(formula.ToString());
				formula = new HarmonicMinorModalScaleFormula(minorKey, ModeEnum.Ionian);
				Debug.WriteLine(formula.ToString());
			}
			new object();
		}

	}//class
}//ns