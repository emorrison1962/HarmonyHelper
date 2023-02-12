using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public static class IntervalsEnumExtensions
    {
        public static IntervalRoleTypeEnum ToIntervalRoleType(this ChordToneFunctionEnum src)
        {
            Debug.Assert(ChordToneFunctionEnum.None != src);
            IntervalRoleTypeEnum result = IntervalRoleTypeEnum.Unknown;
            switch (src)
            {
                case ChordToneFunctionEnum.Root:
                    { result = IntervalRoleTypeEnum.Unison; break; }

                case ChordToneFunctionEnum.Flat9th:
                case ChordToneFunctionEnum.Sus2:
                case ChordToneFunctionEnum.Ninth:
                case ChordToneFunctionEnum.Sharp9th:
                    { result = IntervalRoleTypeEnum.Second; break; }

                case ChordToneFunctionEnum.Minor3rd:
                case ChordToneFunctionEnum.Major3rd:
                    { result = IntervalRoleTypeEnum.Third; break; }

                case ChordToneFunctionEnum.Flat11th:
                case ChordToneFunctionEnum.Eleventh:
                case ChordToneFunctionEnum.Augmented11th:
                case ChordToneFunctionEnum.Sus4:
                    { result = IntervalRoleTypeEnum.Fourth; break; }

                case ChordToneFunctionEnum.Diminished5th:
                case ChordToneFunctionEnum.Perfect5th:
                case ChordToneFunctionEnum.Augmented5th:
                    { result = IntervalRoleTypeEnum.Fifth; break; }

                case ChordToneFunctionEnum.Flat13th:
                case ChordToneFunctionEnum.Thirteenth:
                case ChordToneFunctionEnum.Major6th:
                    { result = IntervalRoleTypeEnum.Sixth; break; }

                case ChordToneFunctionEnum.Diminished7th:
                case ChordToneFunctionEnum.Minor7th:
                case ChordToneFunctionEnum.Major7th:
                    { result = IntervalRoleTypeEnum.Seventh; break; }

                default: { throw new NotImplementedException(); }
            }
            return result;
        }

        public static IntervalRoleTypeEnum ToIntervalRoleType(this ScaleToneFunctionEnum src)
        {
            IntervalRoleTypeEnum result = IntervalRoleTypeEnum.Unknown;
            switch (src)
            {
                case ScaleToneFunctionEnum.Root:
                case ScaleToneFunctionEnum.AugmentedUnison:
                    { result = IntervalRoleTypeEnum.Unison; break; }

                case ScaleToneFunctionEnum.DiminishedOctave:
                    { result = IntervalRoleTypeEnum.Octave; break; }

                case ScaleToneFunctionEnum.Minor2nd:
                case ScaleToneFunctionEnum.Major2nd:
                case ScaleToneFunctionEnum.Augmented2nd:
                    { result = IntervalRoleTypeEnum.Second; break; }
                    
                case ScaleToneFunctionEnum.Diminished3rd:
                case ScaleToneFunctionEnum.Minor3rd:
                case ScaleToneFunctionEnum.Major3rd:
                    { result = IntervalRoleTypeEnum.Third; break; }

                case ScaleToneFunctionEnum.Diminished4th:
                case ScaleToneFunctionEnum.Perfect4th:
                case ScaleToneFunctionEnum.Augmented4th:
                    { result = IntervalRoleTypeEnum.Fourth; break; }

                case ScaleToneFunctionEnum.Diminished5th:
                case ScaleToneFunctionEnum.Perfect5th:
                case ScaleToneFunctionEnum.Augmented5th:
                    { result = IntervalRoleTypeEnum.Fifth; break; }

                case ScaleToneFunctionEnum.Minor6th:
                case ScaleToneFunctionEnum.Major6th:
                case ScaleToneFunctionEnum.Augmented6th:
                    { result = IntervalRoleTypeEnum.Sixth; break; }

                case ScaleToneFunctionEnum.Diminished7th:
                case ScaleToneFunctionEnum.Minor7th:
                case ScaleToneFunctionEnum.Major7th:
                    { result = IntervalRoleTypeEnum.Seventh; break; }

                default: { throw new NotImplementedException(); }
            }
            return result;
        }

        [Obsolete("", false)]
        public static string ToStringEx(this ChordToneFunctionEnum e)
        {
            var result = string.Empty;

            switch (e)
            {
                case ChordToneFunctionEnum.None:
                    result = Constants.NONE;
                    break;
                case ChordToneFunctionEnum.Root:
                    result = Constants.ROOT;
                    break;
                case ChordToneFunctionEnum.Flat9th:
                    result = Constants.FLAT_9TH;
                    break;
                case ChordToneFunctionEnum.Ninth:
                    result = Constants.NINTH;
                    break;
                case ChordToneFunctionEnum.Sharp9th:
                    result = Constants.SHARP_9TH;
                    break;
                case ChordToneFunctionEnum.Minor3rd:
                    result = Constants.MINOR_3RD;
                    break;
                case ChordToneFunctionEnum.Major3rd:
                    result = Constants.MAJOR_3RD;
                    break;
                case ChordToneFunctionEnum.Flat11th:
                    result = Constants.FLAT_11TH;
                    break;
                case ChordToneFunctionEnum.Eleventh:
                    result = Constants.ELEVENTH;
                    break;
                case ChordToneFunctionEnum.Augmented11th:
                    result = Constants.SHARP_11TH;
                    break;
                case ChordToneFunctionEnum.Diminished5th:
                    result = Constants.DIMINISHED_5TH;
                    break;
                case ChordToneFunctionEnum.Perfect5th:
                    result = Constants.PERFECT_5TH;
                    break;
                case ChordToneFunctionEnum.Augmented5th:
                    result = Constants.AUGMENTED_5TH;
                    break;
                case ChordToneFunctionEnum.Flat13th:
                    result = Constants.FLAT_13TH;
                    break;
                case ChordToneFunctionEnum.Thirteenth:
                    result = Constants.THIRTEENTH;
                    break;
                case ChordToneFunctionEnum.Diminished7th:
                    result = Constants.DIMINISHED_7TH;
                    break;
                case ChordToneFunctionEnum.Minor7th:
                    result = Constants.MINOR_7TH;
                    break;
                case ChordToneFunctionEnum.Major7th:
                    result = Constants.MAJOR_7TH;
                    break;
                default: throw new NotSupportedException();

            }

            return result;
        }

    }//class

}//ns
