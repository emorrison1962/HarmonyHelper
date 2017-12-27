
#if false
using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class ModeFormula : KeyedScaleFormulaBase
    {
        static public ModeFormula Ionian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Ionian);
            var key = root - keyOffset;
            return new ModeFormula(key, ModeEnum.Ionian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th);
        }
        static public ModeFormula Dorian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Dorian);
            return new ModeFormula(key, ModeEnum.Dorian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th);
        }
        static public ModeFormula Phrygian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Phrygian);
            return new ModeFormula(key, ModeEnum.Phrygian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);
        }
        static public ModeFormula Lydian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Lydian);
            return new ModeFormula(key, ModeEnum.Lydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Augmented4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th);
        }
        static public ModeFormula Mixolydian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Mixolydian);
            return new ModeFormula(key, ModeEnum.Mixolydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th);
        }
        static public ModeFormula Aeolian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Aeolian);
            return new ModeFormula(key, ModeEnum.Aeolian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);
        }
        static public ModeFormula Locrian(NoteName root)
        {
            var keyOffset = GetDistanceFromKeyRoot(ModeEnum.Locrian);
            return new ModeFormula(key, ModeEnum.Locrian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Diminished5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th);
        }

        public ModeEnum Mode { get; private set; }
        IntervalsEnum DistanceFromRoot { get; set; }
        public IntervalsEnum Second { get; private set; }
        public IntervalsEnum Third { get; private set; }
        public IntervalsEnum Fourth { get; private set; }
        public IntervalsEnum Fifth { get; private set; }
        public IntervalsEnum Sixth { get; private set; }
        public IntervalsEnum Seventh { get; private set; }

        public ModeFormula(ModeEnum me, IntervalsEnum second, IntervalsEnum third,
            IntervalsEnum fourth, IntervalsEnum fifth, IntervalsEnum sixth, IntervalsEnum seventh)
        {
            this.Mode = me;
            this.Name = this.Mode.ToString("G");
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
            this.Sixth = sixth;
            this.Seventh = seventh;
            this.GetDistanceFromRoot();
        }

        static IntervalsEnum GetDistanceFromKeyRoot(ModeEnum mode)
        {
            var result = IntervalsEnum.None;
            switch (mode)
            {
                //case ModeEnum.Ionian:
                case ModeEnum.Dorian:
                    result = IntervalsEnum.Major2nd;
                    break;
                case ModeEnum.Phrygian:
                    result = IntervalsEnum.Major3rd;
                    break;
                case ModeEnum.Lydian:
                    result = IntervalsEnum.Perfect4th;
                    break;
                case ModeEnum.Mixolydian:
                    result = IntervalsEnum.Perfect5th;
                    break;
                case ModeEnum.Aeolian:
                    result = IntervalsEnum.Major6th;
                    break;
                case ModeEnum.Locrian:
                    result = IntervalsEnum.Major7th;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return result;
        }

        override protected List<NoteName> PopulateNoteNames()
        {
            var root = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
            var result = new List<NoteName>();
            result.Add(this.Key.NoteName);
            foreach (var interval in this.Formula.Intervals)
            {
                var nn = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
                result.Add(nn);
            }

            return result;
        }


        //public override string ToString()
        //{
        //    const string FORMAT = @"{0}: {1}";
        //    var result = string.Format(FORMAT,
        //        this.Mode.ToString("G"),
        //        this.Name,
        //        string.Join(",", this.NoteNames));

        //    return result;
        //}

        //public override string ToString()
        //{
        //    var result = string.Empty;
        //    const string FORMAT = @"{0} Mode in {1}: {2}";
        //    result = string.Format(FORMAT,
        //        this.Formula.ToString(),
        //        this.Key.NoteName,
        //        string.Join(",", this.NoteNames));
        //    return result;
        //}


        protected override void PopulateIntervals()
        {
            this.Intervals = new List<IntervalsEnum>(new[] { Second, Third, Fourth, Fifth, Sixth, Seventh });
        }

        protected override void Init()
        {
            base.InitImpl();
        }
    }
}
#endif