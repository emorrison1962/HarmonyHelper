using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public static class ChordFormulaCatalog
	{
		#region Chords
		static public readonly ChordFormula C7;

		static public readonly ChordFormula F7;

		static public readonly ChordFormula Bb7;

		static public readonly ChordFormula Eb7;

		static public readonly ChordFormula Ab7;

		static public readonly ChordFormula Db7;

		static public readonly ChordFormula Gb7;

		static public readonly ChordFormula B7;

		static public readonly ChordFormula E7;

		static public readonly ChordFormula A7;

		static public readonly ChordFormula D7;

		static public readonly ChordFormula G7;
		#endregion

		static public List<ChordFormula> Formulas { get; private set; } = new List<ChordFormula>();

		static ChordFormulaCatalog()
		{
			var dominant7th = ChordTypesEnum.Dominant7th;

			Formulas.Add(C7 = ChordFormulaFactory.Create(NoteName.C, dominant7th, KeySignature.FMajor));
			Formulas.Add(F7 = ChordFormulaFactory.Create(NoteName.F, dominant7th, KeySignature.BbMajor));
			Formulas.Add(Bb7 = ChordFormulaFactory.Create(NoteName.Bb, dominant7th, KeySignature.EbMajor));
			Formulas.Add(Eb7 = ChordFormulaFactory.Create(NoteName.Eb, dominant7th, KeySignature.AbMajor));
			Formulas.Add(Ab7 = ChordFormulaFactory.Create(NoteName.Ab, dominant7th, KeySignature.DbMajor));
			Formulas.Add(Db7 = ChordFormulaFactory.Create(NoteName.Db, dominant7th, KeySignature.GbMajor));
			Formulas.Add(Gb7 = ChordFormulaFactory.Create(NoteName.Gb, dominant7th, KeySignature.CbMajor));
			Formulas.Add(B7 = ChordFormulaFactory.Create(NoteName.B, dominant7th, KeySignature.EMajor));
			Formulas.Add(E7 = ChordFormulaFactory.Create(NoteName.E, dominant7th, KeySignature.AMajor));
			Formulas.Add(A7 = ChordFormulaFactory.Create(NoteName.A, dominant7th, KeySignature.DMajor));
			Formulas.Add(D7 = ChordFormulaFactory.Create(NoteName.D, dominant7th, KeySignature.GMajor));
			Formulas.Add(G7 = ChordFormulaFactory.Create(NoteName.G, dominant7th, KeySignature.CMajor));
		}

	}//class
}//ns
