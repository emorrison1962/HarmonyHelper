using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Intervals
{
	public class ScaleToneInterval : Interval
	{

		static public new ScaleToneInterval None = new ScaleToneInterval("None", Interval.None, ScaleToneFunctionEnum.None);
		static public ScaleToneInterval Root = new ScaleToneInterval("Root", Interval.None, ScaleToneFunctionEnum.Root);
		static public ScaleToneInterval Sus2 = new ScaleToneInterval("Sus2", Interval.Major2nd, ScaleToneFunctionEnum.Sus2);
		static public new ScaleToneInterval Minor3rd = new ScaleToneInterval("Minor3rd", Interval.Minor3rd, ScaleToneFunctionEnum.Minor3rd);
		static public new ScaleToneInterval Major3rd = new ScaleToneInterval("Major3rd", Interval.Major3rd, ScaleToneFunctionEnum.Major3rd);
		static public ScaleToneInterval Sus4 = new ScaleToneInterval("Sus4", Interval.Perfect4th, ScaleToneFunctionEnum.Sus4);
		static public new ScaleToneInterval Diminished5th = new ScaleToneInterval("Diminished5th", Interval.Diminished5th, ScaleToneFunctionEnum.Diminished5th);
		static public new ScaleToneInterval Perfect5th = new ScaleToneInterval("Perfect5th", Interval.Perfect5th, ScaleToneFunctionEnum.Perfect5th);
		static public new ScaleToneInterval Augmented5th = new ScaleToneInterval("Augmented5th", Interval.Augmented5th, ScaleToneFunctionEnum.Augmented5th);
		static public new ScaleToneInterval Major6th = new ScaleToneInterval("Major6th", Interval.Major6th, ScaleToneFunctionEnum.Major6th);
		static public new ScaleToneInterval Diminished7th = new ScaleToneInterval("Diminished7th", Interval.Diminished7th, ScaleToneFunctionEnum.Diminished7th);
		static public new ScaleToneInterval Minor7th = new ScaleToneInterval("Minor7th", Interval.Minor7th, ScaleToneFunctionEnum.Minor7th);
		static public new ScaleToneInterval Major7th = new ScaleToneInterval("Major7th", Interval.Major7th, ScaleToneFunctionEnum.Major7th);
		static public ScaleToneInterval Flat9th = new ScaleToneInterval("Flat9th", Interval.Minor2nd, ScaleToneFunctionEnum.Flat9th);
		static public ScaleToneInterval Ninth = new ScaleToneInterval("Ninth", Interval.Major2nd, ScaleToneFunctionEnum.Ninth);
		static public ScaleToneInterval Sharp9th = new ScaleToneInterval("Sharp9th", Interval.Minor3rd, ScaleToneFunctionEnum.Sharp9th);
		static public ScaleToneInterval Flat11th = new ScaleToneInterval("Flat11th", Interval.Diminished4th, ScaleToneFunctionEnum.Flat11th);
		static public ScaleToneInterval Eleventh = new ScaleToneInterval("Eleventh", Interval.Perfect4th, ScaleToneFunctionEnum.Eleventh);
		static public ScaleToneInterval Augmented11th = new ScaleToneInterval("Augmented11th", Interval.Augmented4th, ScaleToneFunctionEnum.Augmented11th);
		static public ScaleToneInterval Flat13th = new ScaleToneInterval("Flat13th", Interval.Minor6th, ScaleToneFunctionEnum.Flat13th);
		static public ScaleToneInterval Thirteenth = new ScaleToneInterval("Thirteenth", Interval.Major6th, ScaleToneFunctionEnum.Thirteenth);

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
		}
	}//class
}
