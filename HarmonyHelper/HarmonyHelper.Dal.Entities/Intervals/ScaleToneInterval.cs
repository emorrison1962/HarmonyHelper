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


		#region Properties
		override public string Name { get; protected set; }
		public ScaleToneFunctionEnum ScaleToneFunction { get; private set; }

		override public IntervalRoleTypeEnum IntervalRoleType => this.ScaleToneFunction.ToIntervalRoleType();

		#endregion

		#region Construction
		[Obsolete("For EF.", true)]
		public ScaleToneInterval()
        {
            
        }
        public ScaleToneInterval(string name, Interval interval, ScaleToneFunctionEnum ScaleToneFunction) : base(interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			this.Name = name;
			this.ScaleToneFunction = ScaleToneFunction;
			Catalog.Add(this);
		}

		#endregion
	}//class

}//ns
