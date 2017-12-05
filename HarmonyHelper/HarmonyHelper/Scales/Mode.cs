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

    public class ModeFormula
    {
        static public ModeFormula Ionian;
        static public ModeFormula Dorian;
        static public ModeFormula Phrygian;
        static public ModeFormula Lydian;
        static public ModeFormula Mixolydian;
        static public ModeFormula Aeolian;
        static public ModeFormula Locrian;
        static public List<ModeFormula> Catalog { get; private set; } = new List<ModeFormula>();

        public ModeEnum Mode { get; private set; }
        public IntervalsEnum Second { get; private set; }
        public IntervalsEnum Third { get; private set; }
        public IntervalsEnum Fourth { get; private set; }
        public IntervalsEnum Fifth { get; private set; }
        public IntervalsEnum Sixth { get; private set; }
        public IntervalsEnum Seventh { get; private set; }

        static ModeFormula()
        {
            Ionian = new ModeFormula(ModeEnum.Ionian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th);
            Dorian = new ModeFormula(ModeEnum.Dorian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th);
            Phrygian = new ModeFormula(ModeEnum.Phrygian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);
            Lydian = new ModeFormula(ModeEnum.Lydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Augmented4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th);
            Mixolydian = new ModeFormula(ModeEnum.Mixolydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th);
            Aeolian = new ModeFormula(ModeEnum.Aeolian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);
            Locrian = new ModeFormula(ModeEnum.Locrian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Diminished5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);

            Catalog.AddRange(new ModeFormula[] {
                Ionian,
                Dorian,
                Phrygian,
                Lydian,
                Mixolydian,
                Aeolian,
                Locrian });
        }

        public ModeFormula(ModeEnum me, IntervalsEnum second, IntervalsEnum third, IntervalsEnum fourth, IntervalsEnum fifth, IntervalsEnum sixth, IntervalsEnum seventh)
        {
            this.Mode = me;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
            this.Sixth = sixth;
            this.Seventh = seventh;
        }

        public override string ToString()
        {
            return this.Mode.ToString();
        }
    }
    public class Mode : ScaleBase
    {
        public NoteName Tonic { get; private set; }
        public NoteName Second { get; private set; }
        public NoteName Third { get; private set; }
        public NoteName Fourth { get; private set; }
        public NoteName Fifth { get; private set; }
        public NoteName Sixth { get; private set; }
        public NoteName Seventh { get; private set; }
        public ModeFormula Formula { get; private set; }
        public Mode(ModeFormula formula, KeySignature key) : base(key)
        {
            this.Key = key;
            this.Formula = formula;
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
            this.Notes = new List<NoteName>() { this.Tonic, this.Second, this.Third, this.Fourth, this.Fifth, this.Sixth, this.Seventh };
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
