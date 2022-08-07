using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
	public class ScaleToneInterval : Interval
	{
		static new public List<ScaleToneInterval> Catalog { get; set; } = new List<ScaleToneInterval>();

		static public ScaleToneInterval None = new ScaleToneInterval("None", Interval.Unison, ScaleToneFunctionEnum.None);
		static public ScaleToneInterval Root = new ScaleToneInterval("Root", Interval.Unison, ScaleToneFunctionEnum.Root);

		static new public ScaleToneInterval AugmentedUnison = new ScaleToneInterval("AugmentedUnison", Interval.AugmentedUnison, ScaleToneFunctionEnum.AugmentedUnison);

		static new public ScaleToneInterval Minor2nd = new ScaleToneInterval("Minor2nd", Interval.Minor2nd, ScaleToneFunctionEnum.Major2nd);
		static new public ScaleToneInterval Major2nd = new ScaleToneInterval("Major2nd", Interval.Major2nd, ScaleToneFunctionEnum.Major2nd);
		static new public ScaleToneInterval Augmented2nd = new ScaleToneInterval("Augmented2nd", Interval.Augmented2nd, ScaleToneFunctionEnum.Augmented2nd);

		static new public ScaleToneInterval Diminished3rd = new ScaleToneInterval("Diminished3rd", Interval.Diminished3rd, ScaleToneFunctionEnum.Diminished3rd);
		static public new ScaleToneInterval Minor3rd = new ScaleToneInterval("Minor3rd", Interval.Minor3rd, ScaleToneFunctionEnum.Minor3rd);
		static public new ScaleToneInterval Major3rd = new ScaleToneInterval("Major3rd", Interval.Major3rd, ScaleToneFunctionEnum.Major3rd);

		static new public ScaleToneInterval Diminished4th = new ScaleToneInterval("Diminished4th", Interval.Diminished4th, ScaleToneFunctionEnum.Diminished4th);
		static new public ScaleToneInterval Perfect4th = new ScaleToneInterval("Perfect4th", Interval.Perfect4th, ScaleToneFunctionEnum.Perfect4th);
		static new public ScaleToneInterval Augmented4th = new ScaleToneInterval("Augmented4th", Interval.Augmented4th, ScaleToneFunctionEnum.Augmented4th);

		static public new ScaleToneInterval Diminished5th = new ScaleToneInterval("Diminished5th", Interval.Diminished5th, ScaleToneFunctionEnum.Diminished5th);
		static public new ScaleToneInterval Perfect5th = new ScaleToneInterval("Perfect5th", Interval.Perfect5th, ScaleToneFunctionEnum.Perfect5th);
		static public new ScaleToneInterval Augmented5th = new ScaleToneInterval("Augmented5th", Interval.Augmented5th, ScaleToneFunctionEnum.Augmented5th);

		static new public ScaleToneInterval Augmented6th = new ScaleToneInterval("Augmented6th", Interval.Augmented6th, ScaleToneFunctionEnum.Augmented6th);
		static new public ScaleToneInterval Minor6th = new ScaleToneInterval("Minor6th", Interval.Minor6th, ScaleToneFunctionEnum.Minor6th);
		static public new ScaleToneInterval Major6th = new ScaleToneInterval("Major6th", Interval.Major6th, ScaleToneFunctionEnum.Major6th);

		static public new ScaleToneInterval Diminished7th = new ScaleToneInterval("Diminished7th", Interval.Diminished7th, ScaleToneFunctionEnum.Diminished7th);
		static public new ScaleToneInterval Minor7th = new ScaleToneInterval("Minor7th", Interval.Minor7th, ScaleToneFunctionEnum.Minor7th);
		static public new ScaleToneInterval Major7th = new ScaleToneInterval("Major7th", Interval.Major7th, ScaleToneFunctionEnum.Major7th);

		static new public ScaleToneInterval DiminishedOctave = new ScaleToneInterval("DiminishedOctave", Interval.DiminishedOctave, ScaleToneFunctionEnum.DiminishedOctave);

		#region COPY_AND_PASTE_NAMES
#if false
ScaleToneInterval.None
ScaleToneInterval.Root
ScaleToneInterval.Minor2nd
ScaleToneInterval.Major2nd
ScaleToneInterval.Augmented2nd
ScaleToneInterval.Minor3rd
ScaleToneInterval.Major3rd
ScaleToneInterval.Diminished4th
ScaleToneInterval.Perfect4th
ScaleToneInterval.Augmented4th
ScaleToneInterval.Diminished5th
ScaleToneInterval.Perfect5th
ScaleToneInterval.Augmented5th
ScaleToneInterval.Minor6th
ScaleToneInterval.Major6th
ScaleToneInterval.Diminished7th
ScaleToneInterval.Minor7th
ScaleToneInterval.Major7th
#endif
		#endregion

		override public string Name { get; protected set; }
		public ScaleToneFunctionEnum ScaleToneFunction { get; private set; }


		public ScaleToneInterval(string name, Interval interval, ScaleToneFunctionEnum ScaleToneFunction) : base(interval)
		{
			this.Name = name;
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

}//ns
