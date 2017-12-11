using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleBase : HarmonyEntityBase
    {
        public List<Note> Notes { get; protected set; } = new List<Note>();
        public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();
        public Note CurrentNote { get; set; }
        public NoteRange NoteRange { get; protected set; }
        protected ScaleFormulaBase Formula { get; set; }
        virtual public string Name { get;  protected set; }
        int MaxIndex
        {
            get
            {
                return this.Notes.Count - 1;
            }
        }

        public Note Next(DirectionEnum direction = DirectionEnum.Ascending)
        {
            Note result = null;
            var currentNdx = this.Notes.IndexOf(this.CurrentNote);

            if (DirectionEnum.Ascending == direction)
            {
                var nextNdx = 0;
                if (currentNdx < this.MaxIndex)
                {
                    nextNdx = currentNdx + 1;
                }
                result = this.Notes[nextNdx];
            }
            else
            {
                var nextNdx = this.MaxIndex;
                if (currentNdx > 0)
                {
                    nextNdx = currentNdx - 1;
                }
                result = this.Notes[nextNdx];
            }

            return result;
        }

        protected ScaleBase(KeySignature key, ScaleFormulaBase formula, NoteRange noteRange) : base(key)
        {
            if (null == key)
                throw new ArgumentNullException();
            if (null == formula)
                throw new ArgumentNullException();
            if (null == noteRange)
                throw new ArgumentNullException();
            this.Formula = formula;
            this.NoteRange = noteRange;

            this.Init(noteRange);
        }

        void Init(NoteRange noteRange)
        {
            this.NoteNames.Add(this.Key.NoteName);
            foreach (var interval in this.Formula.Intervals)
            {
                var nn = this.Key.NoteName + new IntervalContext(this.Key, interval);
                this.NoteNames.Add(nn);
            }

            var requestedNotes = this.NoteNames.Select(x => new Note(x, OctaveEnum.Octave0)).ToList();
            var result = noteRange.GetNotes(requestedNotes);
            result.ForEach(x => this.Notes.Add(x));
        }


    }//class
}//ns
