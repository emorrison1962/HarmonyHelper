using System;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Intervals
{
	static public class IntervalExtensions
	{

		public static ScaleToneInterval ToScaleToneInterval(this Interval interval)
		{
			ScaleToneInterval result = null;

			if (interval == Interval.None)
				result = ScaleToneInterval.None;
			else if (interval == Interval.Minor2nd)
				result = ScaleToneInterval.Minor2nd;
			else if (interval == Interval.Major2nd)
				result = ScaleToneInterval.Major2nd;
			else if (interval == Interval.Augmented2nd)
				result = ScaleToneInterval.Augmented2nd;
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
			ChordToneInterval result = null;

			if (interval == Interval.None)
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

	}//class
}//ns
