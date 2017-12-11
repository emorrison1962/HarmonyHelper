using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class ModeFormula : ScaleFormulaBase
    {
        static public class Catalog
        {
            static public readonly ModeFormula Ionian;
            static public readonly ModeFormula Dorian;
            static public readonly ModeFormula Phrygian;
            static public readonly ModeFormula Lydian;
            static public readonly ModeFormula Mixolydian;
            static public readonly ModeFormula Aeolian;
            static public readonly ModeFormula Locrian;
            static public readonly List<ModeFormula> All = new List<ModeFormula>();

            static Catalog()
            {
                All.Add(Ionian = new ModeFormula(ModeEnum.Ionian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th));
                All.Add(Dorian = new ModeFormula(ModeEnum.Dorian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th));
                All.Add(Phrygian = new ModeFormula(ModeEnum.Phrygian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th));
                All.Add(Lydian = new ModeFormula(ModeEnum.Lydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Augmented4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th));
                All.Add(Mixolydian = new ModeFormula(ModeEnum.Mixolydian, IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th));
                All.Add(Aeolian = new ModeFormula(ModeEnum.Aeolian, IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th));
                All.Add(Locrian = new ModeFormula(ModeEnum.Locrian, IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Diminished5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th));
            }
        }
        public ModeEnum Mode { get; private set; }
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
