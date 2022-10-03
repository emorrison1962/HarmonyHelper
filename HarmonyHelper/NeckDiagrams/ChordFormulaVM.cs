using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace NeckDiagrams
{
    public class ChordFormulaVM
    {
        public ChordFormula ChordFormula { get; set; }
        public Guid Guid { get; set; }
        public bool IsSelected { get; set; } = false;

        public ChordFormulaVM(ChordFormula chordFormula, Guid guid)
        {
            ChordFormula = chordFormula;
            Guid = guid;
        }
    }//class
}//ns
