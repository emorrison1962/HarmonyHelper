using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class NoteRange
    {
        public static readonly NoteRange Default = new NoteRange(new Note(NoteName.C, OctaveEnum.Octave3), new Note(NoteName.C, OctaveEnum.Octave4));
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
            var node = NoteNamesCollection.Get(this.LowerLimit.NoteName);
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

        public Note First(NoteName nn, KeySignature key)
        {
            var tmp = LinkedList.Where(x => x.NoteName.Value == nn.Value).FirstOrDefault();
            var result = tmp.Copy();
            var normalized = key.GetNormalized(nn);
            result.SetNoteName(normalized);
            return result;
        }

        public Note Next(Note after, NoteName nn)
        {
            var result = LinkedList.Where(x => x.NoteName == nn).FirstOrDefault();
            return result;
        }

        public List<Note> GetNotes(List<Note> wantedNotes)
        {
            var result = new List<Note>();

            #region Remove out of range octaves

            var octaves = Enum.GetValues(typeof(OctaveEnum)).OfType<OctaveEnum>().ToList();
            octaves.Where(x => x < this.LowerLimit.Octave || x > this.UpperLimit.Octave)
                .ToList().ForEach(x => octaves.Remove(x));

            #endregion

            foreach (var note in wantedNotes)
            {
                var copy = new Note(note);
                foreach (var octave in octaves)
                {
                    copy = new Note(copy);
                    copy.Octave = octave;

                    if (copy <= this.UpperLimit)
                    {
                        result.Add(copy);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            result.Where(x => x < this.LowerLimit || x > this.UpperLimit)
                .ToList().ForEach(x => result.Remove(x));

            result.Sort(new NoteComparer());
            return result;
        }

        public List<Note> GetNotes(List<NoteName> wantedNames)
        {
            var wantedNotes = new List<Note>();
            foreach (var nn in wantedNames)
            {
                var tmp = new Note(nn, OctaveEnum.Unknown);
                wantedNotes.Add(tmp);
            }
            var result = this.GetNotes(wantedNotes);
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
                        this.UpperLimit = new Note(NoteName.B, OctaveEnum.Octave2);
                        this.LowerLimit = new Note(NoteName.B, OctaveEnum.Octave0);
                    }
                    break;
                case FiveStringBassPositionEnum.FifthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.E, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.E, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.SixthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.F, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.F, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.SeventhPosition:
                    {
                        this.UpperLimit = new Note(NoteName.Gb, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.Gb, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.EigthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.G, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.G, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.NinthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.Ab, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.Ab, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.TenthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.A, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.EleventhPosition:
                    {
                        this.UpperLimit = new Note(NoteName.Bb, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.Bb, OctaveEnum.Octave1);
                    }
                    break;
                case FiveStringBassPositionEnum.TwelfthPosition:
                    {
                        this.UpperLimit = new Note(NoteName.B, OctaveEnum.Octave3);
                        this.LowerLimit = new Note(NoteName.B, OctaveEnum.Octave1);
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
