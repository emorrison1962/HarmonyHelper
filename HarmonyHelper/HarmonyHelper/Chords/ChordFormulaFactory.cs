using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Chords
{
    public static class ChordFormulaFactory
    {
        static public ChordFormula Create(NoteName root, ChordType chordType)
        {
            if (null == root)
                throw new ArgumentNullException();
            if (null == chordType)
                throw new ArgumentNullException();

            var result = ChordFormula.Create(root, chordType);
            return result;
        }

        static public ChordFormula Get(NoteName root, ChordType chordType, KeySignature unused)
        {
            var result = ChordFormula.Catalog
                        .First(x => x.Root == NoteName.A
                        && x.ChordType == ChordType.Minor7th);
            return result;
        }

    }//class
}//ns
