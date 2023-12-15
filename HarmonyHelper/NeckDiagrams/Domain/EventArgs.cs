using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.HarmonicAnalysis;

namespace NeckDiagrams.Domain
{
    public class ChordFormulaVMEventArgs : EventArgs
    {
        public List<ChordFormulaVM> Items { get; private set; } = new List<ChordFormulaVM>();
        public ChordFormulaVMEventArgs(List<ChordFormulaVM> Items)
        {
            this.Items = Items;
        }
    }//class

    public class AnalysisResultEventArgs : EventArgs
    {
        public HarmonicAnalysisResult Result { get; protected set; }
        public AnalysisResultEventArgs(HarmonicAnalysisResult Result)
        {
            this.Result = Result;
        }
    }

}//ns
