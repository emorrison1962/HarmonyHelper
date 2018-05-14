﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
	public class ScaleToneInterval : Interval
	{
		static public List<ScaleToneInterval> Catalog { get; set; } = new List<ScaleToneInterval>();

		static public new ScaleToneInterval None = new ScaleToneInterval("None", Interval.None, ScaleToneFunctionEnum.None);
		static public ScaleToneInterval Root = new ScaleToneInterval("Root", Interval.None, ScaleToneFunctionEnum.Root);

		static public ScaleToneInterval Minor2nd = new ScaleToneInterval("Minor2nd", Interval.Minor2nd, ScaleToneFunctionEnum.Major2nd);
		static public ScaleToneInterval Major2nd = new ScaleToneInterval("Major2nd", Interval.Major2nd, ScaleToneFunctionEnum.Major2nd);
		static public ScaleToneInterval Augmented2nd = new ScaleToneInterval("Augmented2nd", Interval.Augmented2nd, ScaleToneFunctionEnum.Augmented2nd);

		static public new ScaleToneInterval Minor3rd = new ScaleToneInterval("Minor3rd", Interval.Minor3rd, ScaleToneFunctionEnum.Minor3rd);
		static public new ScaleToneInterval Major3rd = new ScaleToneInterval("Major3rd", Interval.Major3rd, ScaleToneFunctionEnum.Major3rd);

		static public ScaleToneInterval Diminished4th = new ScaleToneInterval("Diminished4th", Interval.Diminished4th, ScaleToneFunctionEnum.Diminished4th);
		static public ScaleToneInterval Perfect4th = new ScaleToneInterval("Perfect4th", Interval.Perfect4th, ScaleToneFunctionEnum.Perfect4th);
		static public ScaleToneInterval Augmented4th = new ScaleToneInterval("Augmented4th", Interval.Augmented4th, ScaleToneFunctionEnum.Augmented4th);

		static public new ScaleToneInterval Diminished5th = new ScaleToneInterval("Diminished5th", Interval.Diminished5th, ScaleToneFunctionEnum.Diminished5th);
		static public new ScaleToneInterval Perfect5th = new ScaleToneInterval("Perfect5th", Interval.Perfect5th, ScaleToneFunctionEnum.Perfect5th);
		static public new ScaleToneInterval Augmented5th = new ScaleToneInterval("Augmented5th", Interval.Augmented5th, ScaleToneFunctionEnum.Augmented5th);

		static public ScaleToneInterval Minor6th = new ScaleToneInterval("Minor6th", Interval.Minor6th, ScaleToneFunctionEnum.Minor6th);
		static public new ScaleToneInterval Major6th = new ScaleToneInterval("Major6th", Interval.Major6th, ScaleToneFunctionEnum.Major6th);

		static public new ScaleToneInterval Diminished7th = new ScaleToneInterval("Diminished7th", Interval.Diminished7th, ScaleToneFunctionEnum.Diminished7th);
		static public new ScaleToneInterval Minor7th = new ScaleToneInterval("Minor7th", Interval.Minor7th, ScaleToneFunctionEnum.Minor7th);
		static public new ScaleToneInterval Major7th = new ScaleToneInterval("Major7th", Interval.Major7th, ScaleToneFunctionEnum.Major7th);


		#region names
#if false
None
Root
Sus2
Minor3rd
Major3rd
Sus4
Diminished5th
Perfect5th
Augmented5th
Diminished7th
Minor7th
Major7th
Flat9th
Ninth
Sharp9th
Flat11th
Eleventh
Augmented11th
Flat13th
Thirteenth
#endif
		#endregion

		override public string Name { get; protected set; }
		public ScaleToneFunctionEnum ScaleToneFunction { get; private set; }


		public ScaleToneInterval(string name, Interval interval, ScaleToneFunctionEnum ScaleToneFunction) : base(interval)
		{
			this.ScaleToneFunction = ScaleToneFunction;
			Catalog.Add(this);
		}


		public class ScaleToneIntervalValueEqualityComparer : IEqualityComparer<ScaleToneInterval>
		{
			public bool Equals(ScaleToneInterval x, ScaleToneInterval y)
			{
				var result = false;
				if (x.Value == y.Value)
					result = true;
				return result;
			}

			public int GetHashCode(ScaleToneInterval obj)
			{
				return obj.Value.GetHashCode();
			}
		}

		public static ScaleToneInterval operator -(ScaleToneInterval a, ScaleToneInterval b)
		{
			var result = ScaleToneInterval.None;
			bool success = false;
			if ((null != a && null != b) &&
				(a.Value != b.Value))
				success = true;

			if (success)
			{
				var notes = ScaleToneInterval.Catalog
					.Distinct(new ScaleToneIntervalValueEqualityComparer())
					.OrderBy(x => x.Value)
					.ToList();

				var ndxA = notes.FindIndex(x => x.Value == a.Value);
				var ndxB = notes.FindIndex(x => x.Value == b.Value);

				var invert = false;
				var diff = ndxA - ndxB;
				if (diff < 0)
				{
					invert = true;
					diff = Math.Abs(diff);
				}

				var pow = 1 << diff;
				var interval = (ScaleToneInterval)pow;
				var baseInterval = interval;

				if (invert)
					baseInterval = interval.GetInversion().ToScaleToneInterval();

				result = ScaleToneInterval.Catalog.Where(x => x.Value == baseInterval.Value).First();
			}
			return result;
		}


		public static ScaleToneInterval ToScaleToneInterval(Interval interval)
		{
			ScaleToneInterval result = null;

			var matchCount = ScaleToneInterval.Catalog.Where(x => x.Value == interval.Value).Count();
			Debug.Assert(1 == matchCount);
			result = ScaleToneInterval.Catalog.Where(x => x.Value == interval.Value).First();

			return result;
		}
	}//class

	public static class IntervalExtensions
	{
		public static ScaleToneInterval ToScaleToneInterval(this Interval interval)
		{
			var result = ScaleToneInterval.ToScaleToneInterval(interval);
			Debug.Assert(null != result);
			return result;
		}
	}
}//ns
