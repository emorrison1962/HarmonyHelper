using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class NoteRange
    {
        public Note LowerLimit { get; set; }
        public Note UpperLimit { get; set; }

        LinkedList<Note> LinkedList { get; set; } = new LinkedList<Note>();

        protected NoteRange()
        {
        }
        public NoteRange(Note lowerLimit, Note upperLimit)
        {
            this.LowerLimit = lowerLimit;
            this.UpperLimit = upperLimit;
            Init();
        }

        protected void Init()
        {
            if (null == this.LowerLimit)
                throw new InvalidOperationException();
            if (null == this.UpperLimit)
                throw new InvalidOperationException();

            this.LinkedList.AddLast(this.LowerLimit);
            var node = NotesEnumCollection.Get(this.LowerLimit.NoteName);
            var octave = this.LowerLimit.Octave;
            bool wrapped = false;

            while (true)
            {
                node = node.NextOrFirst(ref wrapped);
                var noteName = node.Value;
                if (wrapped)
                {
                    octave = octave.Next();
                    wrapped = false;
                }
                var note = new Note(noteName, octave);
                this.LinkedList.AddLast(note);
                if (this.UpperLimit.Equals(note))
                    break;
            }

            //this.LinkedList.ToList().ForEach(x => Debug.WriteLine(x
        }

        public Note First(NotesEnum ne)
        {
            var result = LinkedList.Where(x => x.NoteName == ne).FirstOrDefault();
            return result;
        }

        public Note Next(Note after, NotesEnum ne)
        {
            var result = LinkedList.Where(x => x.NoteName == ne).FirstOrDefault();
            return result;
        }

    }

    public class FiveStringBassRange : NoteRange
    {
        public FiveStringBassRange(FiveStringBassPositionEnum position)
        {
            this.SetNoteRange(position);
            base.Init();
        }

        void SetNoteRange(FiveStringBassPositionEnum position)
        {
            switch (position)
            {
                case FiveStringBassPositionEnum.FirstPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.B, OctaveEnum.Octave2);
                        this.LowerLimit = new Note(NotesEnum.B, OctaveEnum.Octave0);
                    }
                    break;
                case FiveStringBassPositionEnum.FifthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.E, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.E, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.SixthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.F, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.F, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.SeventhPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.Gb, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.Gb, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.EigthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.G, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.G, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.NinthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.Ab, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.Ab, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.TenthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.A, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.A, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.EleventhPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.Bb, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.Bb, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.TwelfthPosition:
                    {
                        this.UpperLimit = new Note(NotesEnum.B, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NotesEnum.B, OctaveEnum.Octave1);
                    }
                    break;
                default:
                    { throw new ArgumentOutOfRangeException(); }

            }
        }

        /// <summary>
        /// C1 = B string, 1st fret

        /// C2 = B string, 13th fret
        /// C2 = E string, 8th fret
        /// C2 = A string, 3rd fret

        /// C3 = A string, 15th fret
        /// C3 = G string, 5th fret
        /// C3 = D string, 10th fret

        /// C4 (Middle C)= G string, 17th fret on of bass guitar.
        /// 
        /// 1st pos, B0, B2
        /// 5th E1, E3
        /// 9th G1, G3
        /// 12th B1, B3
        /// 
        /// </summary>

    }


}
