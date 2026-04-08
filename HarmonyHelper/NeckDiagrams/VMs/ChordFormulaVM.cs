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
        public string Name { get { return this.ChordFormula.Name; } }

        public ChordFormulaVM(ChordFormula chordFormula)
        {
            ChordFormula = chordFormula;
            Guid = Guid.NewGuid();
        }

        public ChordFormulaVM(ChordFormula chordFormula, Guid guid) : this(chordFormula)
        {
            Guid = guid;
        }
    }//class
}//ns
