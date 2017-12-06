using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    [Flags]
    public enum ModeEnum
    {
        Ionian = 1,
        Dorian,
        Phrygian,
        Lydian,
        Mixolydian,
        Aeolian,
        Locrian
    }

    public class Mode : ScaleBase
    {
        public NoteName Tonic { get; private set; }
        NoteName Second { get; set; }
        public NoteName Third { get; private set; }
        public NoteName Fourth { get; private set; }
        public NoteName Fifth { get; private set; }
        public NoteName Sixth { get; private set; }
        public NoteName Seventh { get; private set; }
        public ModeFormula Formula { get; private set; }
        public NoteRange NoteRange { get; private set; }

        public Mode(KeySignature key, ModeFormula formula, NoteRange noteRange) : base(key)
        {
            this.Key = key;
            this.Formula = formula;
            this.NoteRange = noteRange;
            this.Create();
        }

        void Create()
        {
            var tonicOffset = this.GetTonicOffset();
            var tonic = this.Key.NoteName;
            if (tonicOffset > IntervalsEnum.None)
                tonic = this.Key.NoteName + tonicOffset;

            this.Tonic = this.Key.Normalize(tonic);
            this.Second = this.Key.Normalize(this.Tonic + this.Formula.Second);
            this.Third = this.Key.Normalize(this.Tonic + this.Formula.Third);
            this.Fourth = this.Key.Normalize(this.Tonic + this.Formula.Fourth);
            this.Fifth = this.Key.Normalize(this.Tonic + this.Formula.Fifth);
            this.Sixth = this.Key.Normalize(this.Tonic + this.Formula.Sixth);
            this.Seventh = this.Key.Normalize(this.Tonic + this.Formula.Seventh);

            var wantedNotes = new List<NoteName>() { this.Tonic, this.Second, this.Third, this.Fourth, this.Fifth, this.Sixth, this.Seventh };
            this.Notes = this.NoteRange.GetNotes(wantedNotes);
            
        }

        IntervalsEnum GetTonicOffset()
        {
            IntervalsEnum result = IntervalsEnum.None;
            switch (Formula.Mode)
            {
                case ModeEnum.Ionian:
                    result = IntervalsEnum.None;
                    break;
                case ModeEnum.Dorian:
                    result = ModeFormula.Ionian.Second;
                    break;
                case ModeEnum.Phrygian:
                    result = ModeFormula.Ionian.Third;
                    break;
                case ModeEnum.Lydian:
                    result = ModeFormula.Ionian.Fourth;
                    break;
                case ModeEnum.Mixolydian:
                    result = ModeFormula.Ionian.Fifth;
                    break;
                case ModeEnum.Aeolian:
                    result = ModeFormula.Ionian.Sixth;
                    break;
                case ModeEnum.Locrian:
                    result = ModeFormula.Ionian.Seventh;
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            var result = string.Empty;
            const string FORMAT = @"{0} Mode in {8}: {1},{2},{3},{4},{5},{6},{7}";
            result = string.Format(FORMAT,
                this.Formula.Mode.ToString(),
                this.Tonic,
                this.Second,
                this.Third,
                this.Fourth,
                this.Fifth,
                this.Sixth,
                this.Seventh,
                this.Key.NoteName);
            return result;
        }
    }//class
}//ns
