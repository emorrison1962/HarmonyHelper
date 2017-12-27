using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleFormulaBase
    {
        public KeySignature Key { get; protected set; }
        public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();

        public List<IntervalsEnum> Intervals { get; set; } = new List<IntervalsEnum>();
        virtual public string Name { get; protected set; }



        abstract protected void PopulateIntervals();
        abstract protected void Init();
        public ScaleFormulaBase(KeySignature key)
        {
            this.Key = key;
            this.Name = string.Format("{0} {1}",
                this.Key.NoteName,
                this.GetType().Name.Replace("Formula", string.Empty));
        }

        protected void InitImpl()
        {
            this.PopulateIntervals();
            this.PopulateNoteNames();
        }

        public bool Contains(ChordFormula formula)
        {
            var result = this.Contains(formula.NoteNames);
            return result;
        }

        public bool Contains(IEnumerable<NoteName> chordTones)
        {
            var result = false;
            Debug.Assert(this.NoteNames.Count > 0);
            foreach (var chordTone in chordTones)
            {
                if (!this.NoteNames.Contains(chordTone, new NoteNameValueComparer()))
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

        virtual protected void PopulateNoteNames()
        {
            var result = new List<NoteName>();
            result.Add(this.Key.NoteName);
            foreach (var interval in this.Intervals)
            {
                var nn = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
                result.Add(nn);
            }

            this.NoteNames = result;
        }

        public override string ToString()
        {
            var result = string.Empty;
            const string FORMAT = @"{0}: {1}";
            result = string.Format(FORMAT,
                //this.Key.NoteName.ToString(),
                this.Name,
                string.Join(",", this.NoteNames));
            return result;
        }

    }//class

}//ns
