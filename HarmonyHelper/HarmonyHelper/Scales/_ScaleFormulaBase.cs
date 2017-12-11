using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleFormulaBase
    {
        public List<IntervalsEnum> Intervals { get; set; } = new List<IntervalsEnum>();
        virtual public string Name { get; protected set; }



        abstract protected void PopulateIntervals();
        abstract protected void Init();
        public ScaleFormulaBase()
        {
            this.Name = this.GetType().Name; 
            Task.Run((Action)this.InitImpl);
        }

        protected void InitImpl()
        {
            this.PopulateIntervals();
        }
    }//class

    public class KeyedScaleFormulaBase : ScaleFormulaBase
    {
        public KeySignature Key { get; private set; }
        public ScaleFormulaBase Formula { get; private set; }
        public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();

        public KeyedScaleFormulaBase(KeySignature key, ScaleFormulaBase formula)
        {
            this.Key = key;
            this.Formula = formula;
            this.Name = formula.Name;
        }

        public bool Contains(IEnumerable<NoteName> chordTones)
        {
            var result = false;
            this.NoteNames = this.PopulateNoteNames();
            Debug.Assert(this.NoteNames.Count > 0);
            foreach (var chordTone in chordTones)
            {
                if (!this.NoteNames.Contains(chordTone))
                {
                    result = false;
                    break;
                }
                else
                {
                    // We've got a match!!
                    result = true;
                    new object();
                }
            }

            return result;
        }

        override protected void Init()
        {
        }

        protected override void PopulateIntervals()
        {
        }

        List<NoteName> PopulateNoteNames()
        {
            var result = new List<NoteName>();
            result.Add(this.Key.NoteName);
            foreach (var interval in this.Formula.Intervals)
            {
                var nn = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
                result.Add(nn);
            }

            return result;
        }

        public override string ToString()
        {
            var result = string.Empty;
            const string FORMAT = @"{0}: {1}";
            result = string.Format(FORMAT,
                //this.Formula.ToString(),
                this.Name,
                string.Join(",", this.NoteNames));
            return result;
        }

    }
}//ns
