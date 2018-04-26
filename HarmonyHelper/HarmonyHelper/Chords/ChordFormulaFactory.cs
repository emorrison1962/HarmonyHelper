using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public static class ChordFormulaFactory
	{
		static public ChordFormula Create(NoteName root, ChordType chordType, KeySignature key, bool addDiatonicExtensions = false)
		{
			var result = new ChordFormula(root, chordType, key, addDiatonicExtensions);
			return result;
		}
	}
}
