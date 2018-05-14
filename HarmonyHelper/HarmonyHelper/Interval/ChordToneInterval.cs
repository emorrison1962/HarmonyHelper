using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
	public class ChordToneInterval : Interval
	{
		static public List<ChordToneInterval> Catalog { get; set; } = new List<ChordToneInterval>();

		static public new ChordToneInterval None = new ChordToneInterval("None", Interval.None, ChordToneFunctionEnum.None);
		static public ChordToneInterval Root = new ChordToneInterval("Root", Interval.None, ChordToneFunctionEnum.Root);
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
		public ChordToneFunctionEnum ChordToneFunction { get; private set; }
		public ChordToneInterval(string name, Interval interval, ChordToneFunctionEnum chordToneFunction) : base(interval)
		{
			this.ChordToneFunction = chordToneFunction;
		}

		public static ChordToneInterval ToChordToneInterval(Interval interval)
		{
			ChordToneInterval result = null;

			var matchCount = ChordToneInterval.Catalog.Where(x => x.Value == interval.Value).Count();
			Debug.Assert(1 == matchCount);
			result = ChordToneInterval.Catalog.Where(x => x.Value == interval.Value).First();

			switch (interval)
			{
				case Interval.Augmented2nd.Value:
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
