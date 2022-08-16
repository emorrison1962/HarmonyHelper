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
			if (null == root)
				throw new ArgumentNullException();
			if (null == chordType)
				throw new ArgumentNullException();
			if (null == key)
				throw new ArgumentNullException();

			var result = new ChordFormula(root, chordType, key);
			return result;
		}
	}
}
