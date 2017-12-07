using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class Scale : ScaleBase
    {
        public Scale(KeySignature key, ScaleFormulaBase formula, NoteRange noteRange) : base(key, formula, noteRange)
        {
        }

        void Init()
        {
            foreach (var interval in this.Formula.Intervals)
            {
                var scaleTone = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
                this.NoteNames.Add(scaleTone);
            }
        }

    }//class

}//ns
