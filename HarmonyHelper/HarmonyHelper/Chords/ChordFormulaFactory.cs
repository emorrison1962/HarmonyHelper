using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Chords
{
	public static class ChordFormulaFactory
	{
		static public ChordFormula Create(NoteName root, ChordType chordType, KeySignature key)
		{
			var result = new ChordFormula(root, chordType, key);
			return result;
		}
	}
}
