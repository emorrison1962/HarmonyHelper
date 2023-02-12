using System;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Intervals
{
    static public class IntervalExtensions
    {

        public static ScaleToneInterval ToScaleToneInterval(this Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            ScaleToneInterval result = null;

            if (interval == Interval.Unison)
                result = ScaleToneInterval.None;
            else if (interval == Interval.Minor2nd)
                result = ScaleToneInterval.Minor2nd;
            else if (interval == Interval.Major2nd)
                result = ScaleToneInterval.Major2nd;
            else if (interval == Interval.Augmented2nd)
                result = ScaleToneInterval.Augmented2nd;
            else if (interval == Interval.Diminished3rd)
                result = ScaleToneInterval.Diminished3rd;
            else if (interval == Interval.Minor3rd)
                result = ScaleToneInterval.Minor3rd;
            else if (interval == Interval.Major3rd)
                result = ScaleToneInterval.Major3rd;
            else if (interval == Interval.Diminished4th)
                result = ScaleToneInterval.Diminished4th;
            else if (interval == Interval.Perfect4th)
                result = ScaleToneInterval.Perfect4th;
            else if (interval == Interval.Augmented4th)
                result = ScaleToneInterval.Augmented4th;
            else if (interval == Interval.Diminished5th)
                result = ScaleToneInterval.Diminished5th;
            else if (interval == Interval.Perfect5th)
                result = ScaleToneInterval.Perfect5th;
            else if (interval == Interval.Augmented5th)
                result = ScaleToneInterval.Augmented5th;
            else if (interval == Interval.Minor6th)
                result = ScaleToneInterval.Minor6th;
            else if (interval == Interval.Major6th)
                result = ScaleToneInterval.Major6th;
            else if (interval == Interval.Augmented6th)
                result = ScaleToneInterval.Augmented6th;
            else if (interval == Interval.Diminished7th)
                result = ScaleToneInterval.Diminished7th;
            else if (interval == Interval.Minor7th)
                result = ScaleToneInterval.Minor7th;
            else if (interval == Interval.Major7th)
                result = ScaleToneInterval.Major7th;
            else
                throw new NotSupportedException();


            Debug.Assert(null != result);
            return result;
        }

        public static ChordToneInterval ToChordToneInterval(this Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            ChordToneInterval result = null;

            if (interval == Interval.Unison)
                result = ChordToneInterval.None;

            else if (interval == Interval.Minor2nd)
                result = ChordToneInterval.Flat9th;

            else if (interval == Interval.Major2nd)
                result = ChordToneInterval.Ninth;

            else if (interval == Interval.Augmented2nd)
                result = ChordToneInterval.Sharp9th;

            else if (interval == Interval.Minor3rd)
                result = ChordToneInterval.Minor3rd;

            else if (interval == Interval.Major3rd)
                result = ChordToneInterval.Major3rd;

            else if (interval == Interval.Diminished4th)
                result = ChordToneInterval.Flat11th;

            else if (interval == Interval.Perfect4th)
                result = ChordToneInterval.Eleventh;

            else if (interval == Interval.Augmented4th)
                result = ChordToneInterval.Augmented11th;

            else if (interval == Interval.Diminished5th)
                result = ChordToneInterval.Diminished5th;

            else if (interval == Interval.Perfect5th)
                result = ChordToneInterval.Perfect5th;

            else if (interval == Interval.Augmented5th)
                result = ChordToneInterval.Augmented5th;

            else if (interval == Interval.Minor6th)
                result = ChordToneInterval.Flat13th;

            else if (interval == Interval.Major6th)
                result = ChordToneInterval.Major6th;

            else if (interval == Interval.Diminished7th)
                result = ChordToneInterval.Diminished7th;

            else if (interval == Interval.Minor7th)
                result = ChordToneInterval.Minor7th;

            else if (interval == Interval.Major7th)
                result = ChordToneInterval.Major7th;
            else
                throw new NotSupportedException();


#warning **** These interval are not handled!!! ****
#if false
ChordToneInterval.Root
ChordToneInterval.Sus2
ChordToneInterval.Sus4
ChordToneInterval.Thirteenth
#endif

            Debug.Assert(null != result);
            return result;
        }

        public static IntervalValuesEnum ToIntervalValuesEnum(this ChordToneFunctionEnum src)
        {
            IntervalValuesEnum result;

            switch (src)
            {
                case ChordToneFunctionEnum.Root:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_UNISON;
                        break;
                    }

                case ChordToneFunctionEnum.Sus2:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_2ND;
                        break;
                    }

                case ChordToneFunctionEnum.Minor3rd:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD;
                        break;
                    }
                case ChordToneFunctionEnum.Major3rd:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_3RD;
                        break;
                    }

                case ChordToneFunctionEnum.Sus4:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_PERFECT_4TH;
                        break;
                    }

                case ChordToneFunctionEnum.Diminished5th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_5TH;
                        break;
                    }
                case ChordToneFunctionEnum.Perfect5th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH;
                        break;
                    }
                case ChordToneFunctionEnum.Augmented5th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_AUGMENTED_5TH;
                        break;
                    }

                case ChordToneFunctionEnum.Major6th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_6TH;
                        break;
                    }

                case ChordToneFunctionEnum.Diminished7th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_7TH;
                        break;
                    }
                case ChordToneFunctionEnum.Minor7th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH;
                        break;
                    }
                case ChordToneFunctionEnum.Major7th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_7TH;
                        break;
                    }

                case ChordToneFunctionEnum.Flat9th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MINOR_2ND;
                        break;
                    }
                case ChordToneFunctionEnum.Ninth:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_2ND;
                        break;
                    }
                case ChordToneFunctionEnum.Sharp9th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD;
                        break;
                    }

                case ChordToneFunctionEnum.Flat11th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_4TH;
                        break;
                    }
                case ChordToneFunctionEnum.Eleventh:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_PERFECT_4TH;
                        break;
                    }
                case ChordToneFunctionEnum.Augmented11th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_AUGMENTED_4TH;
                        break;
                    }

                case ChordToneFunctionEnum.Flat13th:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MINOR_6TH;
                        break;
                    }
                case ChordToneFunctionEnum.Thirteenth:
                    {
                        result = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_6TH;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
            return result;
        }

    }//class
}//ns
