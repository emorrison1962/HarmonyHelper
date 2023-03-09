﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Chords
{
    public static class ChordFormulaFactory
    {
        static public ChordFormula Create(NoteName root, ChordIntervalsEnum chordType)
        {
            if (null == root)
                throw new ArgumentNullException();
            if (null == chordType)
                throw new ArgumentNullException();

            var result = ChordFormula.Create(root, chordType);
            return result;
        }

        static public ChordFormula Get(NoteName root, ChordIntervalsEnum chordType)
        {
            var result = ChordFormula.Catalog
                        .First(x => x.Root == root
                            && x.ChordType == chordType);
            return result;
        }

    }//class
}//ns
