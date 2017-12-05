using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
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
}
