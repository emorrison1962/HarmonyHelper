using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
    public class Chord
    {
        #region Properties

        NoteRange MinRange { get; set; }
        NoteRange MaxRange { get; set; }
        public KeySignature KeySignature { get; set; }
        public Note Root { get; set; }
        public Note Third { get; set; }
        public Note Fifth { get; set; }
        public Note Seventh { get; set; }
        ChordFormula ChordFormula { get; set; }

        LinkedList<Note> ChordTones { get; set; } = new LinkedList<Note>();

        #endregion

        #region Construction

        public Chord(ChordFormula formula, NoteRange noteRange)
        {
            if (null == formula)
                throw new ArgumentNullException();
            if (null == formula.KeySignature)
                throw new ArgumentNullException();
            if (null == noteRange)
                throw new ArgumentNullException();

            this.KeySignature = formula.KeySignature;

            this.Root = noteRange.First(formula.Root, this.KeySignature);
            this.Third = noteRange.First(formula.Third, this.KeySignature);
            this.Fifth = noteRange.First(formula.Fifth, this.KeySignature);
            this.Seventh = noteRange.First(formula.Seventh, this.KeySignature);
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

        List<Note> PopulateChordTones(NoteRange noteRange)
        {
            var result = new List<Note>();
            #region Our Chord Notes
            var notes = new List<Note>()
            {
                this.Root,
                this.Third,
                this.Fifth,
                this.Seventh,
            };

            #endregion

            #region Remove out of range octaves
            var octaves = Enum.GetValues(typeof(OctaveEnum)).OfType<OctaveEnum>().ToList();
            octaves.Where(x => x < noteRange.LowerLimit.Octave || x > noteRange.UpperLimit.Octave)
                .ToList().ForEach(x => octaves.Remove(x));
            #endregion

            foreach (var note in notes)
            {
                var copy = new Note(note);
                foreach (var octave in octaves)
                {
                    copy = new Note(copy);
                    copy.Octave = octave;

                    if (copy <= noteRange.UpperLimit)
                    {
                        result.Add(copy);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            result.Where(x => x < noteRange.LowerLimit || x > noteRange.UpperLimit)
                .ToList().ForEach(x => result.Remove(x));

            result.Sort(new NoteComparer());
            result.ForEach(x => this.ChordTones.AddLast(x));
            //result.ForEach(x => Debug.WriteLine(x.ToString(ToStringEnum.Minimal)));
            return result;
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
                this.Root.ToString(ToStringEnum.Minimal, this.KeySignature),
                this.Third.ToString(ToStringEnum.Minimal, this.KeySignature),
                this.Fifth.ToString(ToStringEnum.Minimal, this.KeySignature),
                this.Seventh.ToString(ToStringEnum.Minimal, this.KeySignature));
        }
        public string Name {
            get
            {
                var result = string.Format("{0}{1}",
                    this.Root.ToString(ToStringEnum.Minimal, this.KeySignature),
                    this.ChordFormula.ChordType.ToStringEx());
                return result;
            }
        }
    }//class
}//ns
