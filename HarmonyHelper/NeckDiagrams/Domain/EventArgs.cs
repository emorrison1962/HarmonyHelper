using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;

namespace NeckDiagrams.Domain
{
    [Obsolete("", true)]
    public class ChordFormulaEventArgs : EventArgs
    {
        public List<ChordFormula> Items { get; private set; } = new List<ChordFormula>();
        public ChordFormulaEventArgs(List<ChordFormula> Items)
        {
            this.Items = Items;
        }
    }//class

    [Obsolete("", true)]
    public class AnalysisResultEventArgs : EventArgs
    {
        public HarmonicAnalysisResult Result { get; protected set; }
        public AnalysisResultEventArgs(HarmonicAnalysisResult Result)
        {
            this.Result = Result;
        }
    }

}//ns
