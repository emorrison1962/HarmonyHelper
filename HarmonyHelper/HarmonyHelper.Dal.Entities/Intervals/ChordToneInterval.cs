using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
    public class ChordToneInterval : Interval
	{
		static new public List<ChordToneInterval> Catalog { get; set; } = new List<ChordToneInterval>();

		static public readonly new ChordToneInterval None = new ChordToneInterval("None", Interval.Unison, ChordToneFunctionEnum.None);
        static public readonly ChordToneInterval Root = new ChordToneInterval("Root", Interval.Unison, ChordToneFunctionEnum.Root);
        static public readonly ChordToneInterval Sus2 = new ChordToneInterval("Sus2", Interval.Major2nd, ChordToneFunctionEnum.Sus2);
        static public readonly new ChordToneInterval Minor3rd = new ChordToneInterval("Minor3rd", Interval.Minor3rd, ChordToneFunctionEnum.Minor3rd);
        static public readonly new ChordToneInterval Major3rd = new ChordToneInterval("Major3rd", Interval.Major3rd, ChordToneFunctionEnum.Major3rd);
        static public readonly ChordToneInterval Sus4 = new ChordToneInterval("Sus4", Interval.Perfect4th, ChordToneFunctionEnum.Sus4);
        static public readonly new ChordToneInterval Diminished5th = new ChordToneInterval("Diminished5th", Interval.Diminished5th, ChordToneFunctionEnum.Diminished5th);
        static public readonly new ChordToneInterval Perfect5th = new ChordToneInterval("Perfect5th", Interval.Perfect5th, ChordToneFunctionEnum.Perfect5th);
        static public readonly new ChordToneInterval Augmented5th = new ChordToneInterval("Augmented5th", Interval.Augmented5th, ChordToneFunctionEnum.Augmented5th);
        static public readonly new ChordToneInterval Major6th = new ChordToneInterval("Major6th", Interval.Major6th, ChordToneFunctionEnum.Major6th);
        static public readonly new ChordToneInterval Diminished7th = new ChordToneInterval("Diminished7th", Interval.Diminished7th, ChordToneFunctionEnum.Diminished7th);
        static public readonly new ChordToneInterval Minor7th = new ChordToneInterval("Minor7th", Interval.Minor7th, ChordToneFunctionEnum.Minor7th);
        static public readonly new ChordToneInterval Major7th = new ChordToneInterval("Major7th", Interval.Major7th, ChordToneFunctionEnum.Major7th);
        static public readonly ChordToneInterval Flat9th = new ChordToneInterval("Flat9th", Interval.Minor2nd, ChordToneFunctionEnum.Flat9th);
        static public readonly ChordToneInterval Ninth = new ChordToneInterval("Ninth", Interval.Major2nd, ChordToneFunctionEnum.Ninth);
        static public readonly ChordToneInterval Sharp9th = new ChordToneInterval("Sharp9th", Interval.Minor3rd, ChordToneFunctionEnum.Sharp9th);
        static public readonly ChordToneInterval Flat11th = new ChordToneInterval("Flat11th", Interval.Diminished4th, ChordToneFunctionEnum.Flat11th);
        static public readonly ChordToneInterval Eleventh = new ChordToneInterval("Eleventh", Interval.Perfect4th, ChordToneFunctionEnum.Eleventh);
        static public readonly ChordToneInterval Augmented11th = new ChordToneInterval("Augmented11th", Interval.Augmented4th, ChordToneFunctionEnum.Augmented11th);
        static public readonly ChordToneInterval Flat13th = new ChordToneInterval("Flat13th", Interval.Minor6th, ChordToneFunctionEnum.Flat13th);
        static public readonly ChordToneInterval Thirteenth = new ChordToneInterval("Thirteenth", Interval.Major6th, ChordToneFunctionEnum.Thirteenth);

		#region Properties
		override public string Name { get; protected set; }
		public ChordToneFunctionEnum ChordToneFunction { get; private set; }
		override public IntervalRoleTypeEnum IntervalRoleType => this.ChordToneFunction.ToIntervalRoleType();

		#endregion
		
		#region Construction
		[Obsolete("For EF.", true)]
		private ChordToneInterval() : base(null) { }
		private ChordToneInterval(string name, Interval interval, ChordToneFunctionEnum chordToneFunction) : base(interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			this.Name = name;
			this.ChordToneFunction = chordToneFunction;
			Catalog.Add(this);
		}

		#endregion
	}//class
}//ns
