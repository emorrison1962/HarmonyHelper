using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
    public class Chord : HarmonyEntityBase
    {
        #region Properties

        public Note Root { get; set; }
        public Note Third { get; set; }
        public Note Fifth { get; set; }
        public Note Seventh { get; set; }
        ChordFormula ChordFormula { get; set; }

        LinkedList<Note> ChordTones { get; set; } = new LinkedList<Note>();

        #endregion

        #region Construction

        public Chord(ChordFormula formula, NoteRange noteRange) : base(formula.Key)
        {
            if (null == formula)
                throw new ArgumentNullException();
            if (null == formula.Key)
                throw new ArgumentNullException();
            if (null == noteRange)
                throw new ArgumentNullException();

            this.Key = formula.Key;

            this.Root = noteRange.First(formula.Root, this.Key);
            this.Third = noteRange.First(formula.Third, this.Key);
            this.Fifth = noteRange.First(formula.Fifth, this.Key);
            this.Seventh = noteRange.First(formula.Seventh, this.Key);
            this.ChordFormula = formula;

            if (null == this.Root)
                throw new NullReferenceException();
            if (null == this.Third)
                throw new NullReferenceException();
            if (null == this.Fifth)
                throw new NullReferenceException();
            if (null == this.Seventh)
                throw new NullReferenceException();

            this.PopulateChordTones(noteRange);
        }

        public Chord(Note root, Note third, Note fifth, Note seventh, NoteRange noteRange) 
            : base(KeySignature.CMajor)
        {
            if (null == root)
                throw new ArgumentNullException();
            if (null == third)
                throw new ArgumentNullException();
            if (null == fifth)
                throw new ArgumentNullException();
            if (null == seventh)
                throw new ArgumentNullException();
            this.Root = root;
            this.Third = third;
            this.Fifth = fifth;
            this.Seventh = seventh;

            this.PopulateChordTones(noteRange);
        }

        void PopulateChordTones(NoteRange noteRange)
        {
            var notes = new List<Note>()
            {
                this.Root,
                this.Third,
                this.Fifth,
                this.Seventh,
            };

            var result = noteRange.GetNotes(notes);
            result.ForEach(x => this.ChordTones.AddLast(x));
        }

        #endregion

        public Note GetClosestNoteEx(ArpeggiationContext ctx)
        {
            var result = this.ChordTones.FindClosest(ctx.CurrentNote, ctx.Direction);
            if (null == result)
            {
                ctx.Direction = ctx.Direction.Next();
                result = this.ChordTones.FindClosest(ctx.CurrentNote, ctx.Direction);
            }

            //Debug.WriteLine(
            //    string.Format("Last={0}, Next={1}",
            //        ctx.CurrentNote.ToString(ToStringEnum.Minimal),
            //        next.ToString(ToStringEnum.Minimal)));
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}",
                this.Root.ToString(ToStringEnum.Minimal, this.Key),
                this.Third.ToString(ToStringEnum.Minimal, this.Key),
                this.Fifth.ToString(ToStringEnum.Minimal, this.Key),
                this.Seventh.ToString(ToStringEnum.Minimal, this.Key));
        }
        public string Name {
            get
            {
                var result = string.Format("{0}{1}",
                    this.Root.ToString(ToStringEnum.Minimal, this.Key),
                    this.ChordFormula.ChordType.ToStringEx());
                return result;
            }
        }
    }//class
}//ns
