using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
    public static class ChordIntervalsEnumExtensions
    {
        static public string Name(this ChordIntervalsEnum src)
        {
            var result = Enum.GetName(typeof(ChordIntervalsEnum), src);
            Debug.Assert(null != result);
            return result;
        }

        static public Interval GetInterval(this ChordIntervalsEnum src, ChordFunctionEnum cfe)
        {
            if (src == ChordIntervalsEnum.None)
                throw new Exception($"{nameof(ChordIntervalsEnum)} not initialized.");
            var result = ChordToneInterval.None;

            Predicate<ChordToneInterval> predicate = null;

            switch (cfe)
            {
                case ChordFunctionEnum.Root:
                case ChordFunctionEnum.None:
                    break;

                case ChordFunctionEnum.Sus2:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd;
                    break;

                case ChordFunctionEnum.Third:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor3rd || x == ChordToneInterval.Major3rd;
                    break;

                case ChordFunctionEnum.Sus4:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th;
                    break;

                case ChordFunctionEnum.Fifth:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect5th || x == ChordToneInterval.Diminished5th || x == ChordToneInterval.Augmented5th;
                    break;

                case ChordFunctionEnum.Seventh:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor7th || x == ChordToneInterval.Major7th || x == ChordToneInterval.Diminished7th;
                    break;

                case ChordFunctionEnum.Ninth:
                    //throw new NotImplementedException("#9 ???");
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd || x == ChordToneInterval.Minor2nd;
                    break;

                case ChordFunctionEnum.Eleventh:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th || x == ChordToneInterval.Augmented4th;
                    break;

                case ChordFunctionEnum.Thirteenth:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major6th || x == ChordToneInterval.Minor6th;
                    break;
            }

            if (null != predicate)
            {
                var found = src.Intervals().FirstOrDefault(x => predicate(x));
                if (null != found)
                    result = found;
            }

            return result;
        }

        static public List<ChordToneInterval> Intervals(this ChordIntervalsEnum src)
        {
            var result = new List<ChordToneInterval>();

            if (src.HasFlag(ChordIntervalsEnum.IntervalRoot))
                result.Add(ChordToneInterval.Root);

            if (src.HasFlag(ChordIntervalsEnum.IntervalSus2))
                result.Add(ChordToneInterval.Sus2);

            if (src.HasFlag(ChordIntervalsEnum.IntervalMinor3rd))
                result.Add(ChordToneInterval.Minor3rd);
            if (src.HasFlag(ChordIntervalsEnum.IntervalMajor3rd))
                result.Add(ChordToneInterval.Major3rd);

            if (src.HasFlag(ChordIntervalsEnum.IntervalSus4))
                result.Add(ChordToneInterval.Sus4);

            if (src.HasFlag(ChordIntervalsEnum.IntervalDiminished5th))
                result.Add(ChordToneInterval.Diminished5th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalPerfect5th))
                result.Add(ChordToneInterval.Perfect5th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalAugmented5th))
                result.Add(ChordToneInterval.Augmented5th);

            if (src.HasFlag(ChordIntervalsEnum.IntervalMajor6th))
                result.Add(ChordToneInterval.Major6th);

            if (src.HasFlag(ChordIntervalsEnum.IntervalDiminished7th))
                result.Add(ChordToneInterval.Diminished7th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalMinor7th))
                result.Add(ChordToneInterval.Minor7th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalMajor7th))
                result.Add(ChordToneInterval.Major7th);

            if (src.HasFlag(ChordIntervalsEnum.IntervalFlat9th))
                result.Add(ChordToneInterval.Flat9th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalNinth))
                result.Add(ChordToneInterval.Ninth);
            if (src.HasFlag(ChordIntervalsEnum.IntervalSharp9th))
                result.Add(ChordToneInterval.Sharp9th);

            if (src.HasFlag(ChordIntervalsEnum.IntervalFlat11th))
                result.Add(ChordToneInterval.Flat11th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalEleventh))
                result.Add(ChordToneInterval.Eleventh);
            if (src.HasFlag(ChordIntervalsEnum.IntervalAugmented11th))
                result.Add(ChordToneInterval.Augmented11th);

            if (src.HasFlag(ChordIntervalsEnum.IntervalFlat13th))
                result.Add(ChordToneInterval.Flat13th);
            if (src.HasFlag(ChordIntervalsEnum.IntervalThirteenth))
                result.Add(ChordToneInterval.Thirteenth);
            
            return result;
        }

        static public bool IsAlteredDominant(this ChordIntervalsEnum src)
        {
            var result = false;
            var isDominant = false;
            var isAltered = false;

            if (src.HasFlag(ChordIntervalsEnum.IntervalMajor3rd)
                && src.HasFlag(ChordIntervalsEnum.IntervalMinor7th))
            {
                isDominant = true;
            }

            if (isDominant)
            {
                if (src.HasFlag(ChordIntervalsEnum.IntervalDiminished5th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalAugmented5th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalFlat9th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalSharp9th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalFlat11th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalAugmented11th)
                    || src.HasFlag(ChordIntervalsEnum.IntervalFlat13th)
                    )
                {
                    result = true;
                }
            }
            return result;
        }

        static public List<ChordIntervalsEnum> Catalog(this ChordIntervalsEnum src)
        { 
            var result = new List<ChordIntervalsEnum>();
            return result;
        }
    }//class
}//ns
