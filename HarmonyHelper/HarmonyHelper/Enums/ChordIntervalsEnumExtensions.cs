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
            var result = string.Empty;
            switch (src)
            {
                case ChordIntervalsEnum.Augmented:
                    {
                        result = "+";
                        break;
                    }
                case ChordIntervalsEnum.Diminished:
                    {
                        result = "dim";
                        break;
                    }
                case ChordIntervalsEnum.Diminished7:
                    {
                        result = "dim7";
                        break;
                    }
                case ChordIntervalsEnum.Dominant11:
                    {
                        result = "11";
                        break;
                    }
                case ChordIntervalsEnum.Dominant11b9:
                    {
                        result = "11b9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant13:
                    {
                        result = "13";
                        break;
                    }
                case ChordIntervalsEnum.Dominant13Aug11:
                    {
                        result = "13#11";
                        break;
                    }
                case ChordIntervalsEnum.Dominant13b9:
                    {
                        result = "13b9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7:
                    {
                        result = "7";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7b5:
                    {
                        result = "7b5";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7b5b9:
                    {
                        result = "7b5b9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7b5Sharp9:
                    {
                        result = "7b5#9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7b9:
                    {
                        result = "7b9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sharp5:
                    {
                        result = "7+";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sharp5b9:
                    {
                        result = "7+5b9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sharp5Nine:
                    {
                        result = "7+9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sharp9:
                    {
                        result = "7#9";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sus2:
                    {
                        result = "7sus2";
                        break;
                    }
                case ChordIntervalsEnum.Dominant7Sus4:
                    {
                        result = "7sus4";
                        break;
                    }
                case ChordIntervalsEnum.Dominant9:
                    {
                        result = "9";
                        break;
                    }
                case ChordIntervalsEnum.Major:
                    {
                        result = "Maj";
                        break;
                    }
                case ChordIntervalsEnum.Major11:
                    {
                        result = "Maj11";
                        break;
                    }
                case ChordIntervalsEnum.Major13:
                    {
                        result = "Maj13";
                        break;
                    }
                case ChordIntervalsEnum.Major13Aug11:
                    {
                        result = "Maj13#11";
                        break;
                    }
                case ChordIntervalsEnum.Major6:
                    {
                        result = "6";
                        break;
                    }
                case ChordIntervalsEnum.Major7:
                    {
                        result = "Maj7";
                        break;
                    }
                case ChordIntervalsEnum.Major7Aug:
                    {
                        result = "Maj7+";
                        break;
                    }
                case ChordIntervalsEnum.Major7b5:
                    {
                        result = "Maj7b5";
                        break;
                    }
                case ChordIntervalsEnum.Major9:
                    {
                        result = "Maj9";
                        break;
                    }
                case ChordIntervalsEnum.Major9thSharp11:
                    {
                        result = "Maj9#11";
                        break;
                    }
                case ChordIntervalsEnum.MajorMu:
                    {
                        result = "MajAdd9";
                        break;
                    }
                case ChordIntervalsEnum.Minor:
                    {
                        result = "m";
                        break;
                    }
                case ChordIntervalsEnum.Minor11:
                    {
                        result = "m11";
                        break;
                    }
                case ChordIntervalsEnum.Minor13:
                    {
                        result = "m13";
                        break;
                    }
                case ChordIntervalsEnum.Minor6:
                    {
                        result = "m6";
                        break;
                    }
                case ChordIntervalsEnum.Minor6Add9:
                    {
                        result = "m6Add9";
                        break;
                    }
                case ChordIntervalsEnum.Minor7:
                    {
                        result = "m7";
                        break;
                    }
                case ChordIntervalsEnum.Minor7Sharp5:
                    {
                        result = "m7+";
                        break;
                    }
                case ChordIntervalsEnum.Minor9:
                    {
                        result = "m9";
                        break;
                    }
                case ChordIntervalsEnum.MinorAdd9:
                    {
                        result = "mAdd9";
                        break;
                    }
                case ChordIntervalsEnum.MinorAugmented:
                    {
                        result = "m+";
                        break;
                    }
                case ChordIntervalsEnum.MinorMajor7:
                    {
                        result = "mMaj7";
                        break;
                    }
                case ChordIntervalsEnum.MinorMajor7Aug:
                    {
                        result = "mMaj7+";
                        break;
                    }
                case ChordIntervalsEnum.MinorMajor9:
                    {
                        result = "mMaj9";
                        break;
                    }
                case ChordIntervalsEnum.Sus2:
                    {
                        result = "sus2";
                        break;
                    }
                case ChordIntervalsEnum.Sus2Sus4:
                    {
                        result = "sus";
                        break;
                    }
                case ChordIntervalsEnum.Sus4:
                    {
                        result = "sus4";
                        break;
                    }

                default:
                    throw new NotSupportedException(nameof(src));
            }

            Debug.Assert(null != result);
            return result;
        }

        [Obsolete("")]
        static public string xName(this ChordIntervalsEnum src)
        {
            return Enum.GetName(typeof(ChordIntervalsEnum), src);
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
