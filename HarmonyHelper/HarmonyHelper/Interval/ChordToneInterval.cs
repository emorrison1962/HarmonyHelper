using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
	public class ChordToneInterval : Interval
	{
		static public List<ChordToneInterval> Catalog { get; set; } = new List<ChordToneInterval>();

		static public new ChordToneInterval None = new ChordToneInterval("None", Interval.Unison, ChordToneFunctionEnum.None);
		static public ChordToneInterval Root = new ChordToneInterval("Root", Interval.Unison, ChordToneFunctionEnum.Root);
		static public ChordToneInterval Sus2 = new ChordToneInterval("Sus2", Interval.Major2nd, ChordToneFunctionEnum.Sus2);
		static public new ChordToneInterval Minor3rd = new ChordToneInterval("Minor3rd", Interval.Minor3rd, ChordToneFunctionEnum.Minor3rd);
		static public new ChordToneInterval Major3rd = new ChordToneInterval("Major3rd", Interval.Major3rd, ChordToneFunctionEnum.Major3rd);
		static public ChordToneInterval Sus4 = new ChordToneInterval("Sus4", Interval.Perfect4th, ChordToneFunctionEnum.Sus4);
		static public new ChordToneInterval Diminished5th = new ChordToneInterval("Diminished5th", Interval.Diminished5th, ChordToneFunctionEnum.Diminished5th);
		static public new ChordToneInterval Perfect5th = new ChordToneInterval("Perfect5th", Interval.Perfect5th, ChordToneFunctionEnum.Perfect5th);
		static public new ChordToneInterval Augmented5th = new ChordToneInterval("Augmented5th", Interval.Augmented5th, ChordToneFunctionEnum.Augmented5th);
		static public new ChordToneInterval Major6th = new ChordToneInterval("Major6th", Interval.Major6th, ChordToneFunctionEnum.Major6th);
		static public new ChordToneInterval Diminished7th = new ChordToneInterval("Diminished7th", Interval.Diminished7th, ChordToneFunctionEnum.Diminished7th);
		static public new ChordToneInterval Minor7th = new ChordToneInterval("Minor7th", Interval.Minor7th, ChordToneFunctionEnum.Minor7th);
		static public new ChordToneInterval Major7th = new ChordToneInterval("Major7th", Interval.Major7th, ChordToneFunctionEnum.Major7th);
		static public ChordToneInterval Flat9th = new ChordToneInterval("Flat9th", Interval.Minor2nd, ChordToneFunctionEnum.Flat9th);
		static public ChordToneInterval Ninth = new ChordToneInterval("Ninth", Interval.Major2nd, ChordToneFunctionEnum.Ninth);
		static public ChordToneInterval Sharp9th = new ChordToneInterval("Sharp9th", Interval.Minor3rd, ChordToneFunctionEnum.Sharp9th);
		static public ChordToneInterval Flat11th = new ChordToneInterval("Flat11th", Interval.Diminished4th, ChordToneFunctionEnum.Flat11th);
		static public ChordToneInterval Eleventh = new ChordToneInterval("Eleventh", Interval.Perfect4th, ChordToneFunctionEnum.Eleventh);
		static public ChordToneInterval Augmented11th = new ChordToneInterval("Augmented11th", Interval.Augmented4th, ChordToneFunctionEnum.Augmented11th);
		static public ChordToneInterval Flat13th = new ChordToneInterval("Flat13th", Interval.Minor6th, ChordToneFunctionEnum.Flat13th);
		static public ChordToneInterval Thirteenth = new ChordToneInterval("Thirteenth", Interval.Major6th, ChordToneFunctionEnum.Thirteenth);

		#region COPY_AND_PASTE_NAMES
#if false
ChordToneInterval.None
ChordToneInterval.Root
ChordToneInterval.Sus2
ChordToneInterval.Minor3rd
ChordToneInterval.Major3rd
ChordToneInterval.Sus4
ChordToneInterval.Diminished5th
ChordToneInterval.Perfect5th
ChordToneInterval.Augmented5th
ChordToneInterval.Major6th
ChordToneInterval.Diminished7th
ChordToneInterval.Minor7th
ChordToneInterval.Major7th
ChordToneInterval.Flat9th
ChordToneInterval.Ninth
ChordToneInterval.Sharp9th
ChordToneInterval.Flat11th
ChordToneInterval.Eleventh
ChordToneInterval.Augmented11th
ChordToneInterval.Flat13th
ChordToneInterval.Thirteenth
#endif
		#endregion

		override public string Name { get; protected set; }
		public ChordToneFunctionEnum ChordToneFunction { get; private set; }
		private ChordToneInterval(string name, Interval interval, ChordToneFunctionEnum chordToneFunction) : base(interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			this.Name = name;
			this.ChordToneFunction = chordToneFunction;
			Catalog.Add(this);
		}

		class ChordToneIntervalComparer : IEqualityComparer<ChordToneInterval>
		{
			public bool Equals(ChordToneInterval x, ChordToneInterval y)
			{
				bool result = false;
				result = x.Equals(y);
				return result;
			}
			public int GetHashCode(ChordToneInterval obj)
			{
				return obj.GetHashCode();
			}
		}

		override public int ToIndex()
		{
			var intervals = ChordToneInterval.Catalog
				.Distinct(new ChordToneIntervalComparer())
				.OrderBy(x => x.Value)
				.ToList();
			var found = intervals.First(x => x == this);
			var result = intervals.IndexOf(found);

			return result;
		}

	}//class
}//ns
