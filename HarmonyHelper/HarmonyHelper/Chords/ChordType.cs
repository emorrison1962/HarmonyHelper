using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class ChordType
	{
		#region Statics
		static public List<ChordType> Catalog { get; set; } = new List<ChordType>();
		static public ChordType None = new ChordType("None", Interval.None);
		static public ChordType Major = new ChordType("", Interval.Major3rd, Interval.Perfect5th);
		static public ChordType Minor = new ChordType("m", Interval.Minor3rd, Interval.Perfect5th);
		static public ChordType Augmented = new ChordType("+", Interval.Major3rd, Interval.Augmented5th);
		static public ChordType Diminished = new ChordType("o", Interval.Minor3rd, Interval.Diminished5th);
		static public ChordType Major7th = new ChordType("Maj7", Major.Intervals, Interval.Major7th);
		static public ChordType Minor7th = new ChordType("m7", Minor.Intervals, Interval.Minor7th);
		static public ChordType Dominant7th = new ChordType("7", Major.Intervals, Interval.Minor7th);
		static public ChordType HalfDiminished = new ChordType("m7b5", Diminished.Intervals, Interval.Minor7th);
		static public ChordType Diminished7 = new ChordType("o7", Diminished.Intervals, Interval.Diminished7th);
		//Suspended,....
		//= new Interval("Minor6th",

		#endregion

		#region Properties
		public string Name { get; private set; }
		public int Value { get; private set; }
		public List<Interval> Intervals { get; set; } = new List<Interval>();

		public bool IsMajor { get; set; }
		public bool IsMinor { get; set; }
		public bool IsDiminished { get; set; }
		#endregion

		#region Construction
		private ChordType(string name, params Interval[] intervals)
		{
			this.Name = name;
			this.Intervals.AddRange(intervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(Interval.None))
				Catalog.Add(this);
			this.Init();
		}

		private ChordType(string name, List<Interval> aIntervals, params Interval[] bIntervals)
		{
			this.Name = name;
			this.Intervals.AddRange(aIntervals);
			this.Intervals.AddRange(bIntervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(Interval.None))
				Catalog.Add(this);
			this.Init();
		}

		void Init()
		{
			if (!this.Intervals.Contains(Interval.None))
			{
				if (this.Intervals.Contains(Interval.Major3rd))
					this.IsMajor = true;
				if (this.Intervals.Contains(Interval.Minor3rd))
					this.IsMinor = true;
				if (this.Intervals.Contains(Interval.Diminished5th))
					this.IsDiminished = true;

				Debug.Assert(this.IsMajor != this.IsMinor);
				if (this.IsDiminished)
					Debug.Assert(this.IsDiminished == this.IsMinor);
			}
		}

		#endregion

		#region Operators
		public static int operator |(ChordType a, ChordType b)
		{
			var result = a.Value | b.Value;
			return result;
		}

		public static explicit operator int(ChordType ct)
		{
			return ct.Value;
		}

		#endregion

		#region Used to be IntervalsEnumExtensions
		public Interval GetInterval(ChordFunctionEnum cfe)
		{
			if (0 == this.Intervals.Count)
				throw new Exception("this.Intervals not initialized.");
			var result = Interval.None;

			Predicate<Interval> predicate = null;

			switch (cfe)
			{
				case ChordFunctionEnum.Root:
				case ChordFunctionEnum.None:
					break;

				case ChordFunctionEnum.Third:
					predicate = (Interval x) => x == Interval.Minor3rd || x == Interval.Major3rd;
					break;

				case ChordFunctionEnum.Fifth:
					predicate = (Interval x) => x == Interval.Perfect5th || x == Interval.Diminished5th || x == Interval.Augmented5th;
					break;

				case ChordFunctionEnum.Seventh:
					predicate = (Interval x) => x == Interval.Minor7th || x == Interval.Major7th || x == Interval.Diminished7th;
					break;

				case ChordFunctionEnum.Ninth:
					//throw new NotImplementedException("#9 ???");
					predicate = (Interval x) => x == Interval.Major2nd || x == Interval.Minor2nd;
					break;

				case ChordFunctionEnum.Eleventh:
					predicate = (Interval x) => x == Interval.Perfect4th || x == Interval.Augmented4th;
					break;

				case ChordFunctionEnum.Thirteenth:
					predicate = (Interval x) => x == Interval.Major6th || x == Interval.Minor6th;
					break;
			}

			if (null != predicate)
			{
				var found = this.Intervals.FirstOrDefault(x => predicate(x));
				if (null != found)
					result = found;
			}

			return result;
		}
		#endregion

		public override string ToString()
		{
			return $"{this.GetType().Name}: Name={this.Name}";
		}

	}//class
}//ns
