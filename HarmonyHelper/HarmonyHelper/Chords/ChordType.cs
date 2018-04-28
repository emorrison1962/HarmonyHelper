using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{ 
	public class ChordType
	{
		static public List<ChordType> Catalog { get; set; } = new List<ChordType>();
		static public ChordType None = new ChordType("None", Interval.None);
		static public ChordType Major = new ChordType("Major", Interval.Major3rd, Interval.Perfect5th);
		static public ChordType Minor = new ChordType("Minor", Interval.Minor3rd , Interval.Perfect5th);
		static public ChordType Augmented = new ChordType("Augmented", Interval.Major3rd,   Interval.Augmented5th);
		static public ChordType Diminished = new ChordType("Diminished", Interval.Minor3rd, Interval.Diminished5th);
		static public ChordType Major7th = new ChordType("Major7th", Major.Intervals , Interval.Major7th);
		static public ChordType Minor7th = new ChordType("Minor7th", Minor.Intervals, Interval.Minor7th);
		static public ChordType Dominant7th = new ChordType("Dominant7th", Major.Intervals, Interval.Minor7th);
		static public ChordType HalfDiminished = new ChordType("HalfDiminished", Diminished.Intervals, Interval.Minor7th);
		static public ChordType Diminished7 = new ChordType("Diminished7", Diminished.Intervals, Interval.Diminished7th);
		//Suspended,....
		//= new Interval("Minor6th",

		public string Name { get; private set; }
		public int Value { get; private set; }
		public List<Interval> Intervals { get; set; } = new List<Interval>();
		private ChordType(string name, params Interval[] intervals)
		{
			this.Name = name;
			this.Intervals.AddRange(intervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(Interval.None))
				Catalog.Add(this);
		}
		private ChordType(string name, List<Interval> aIntervals, params Interval[] bIntervals)
		{
			this.Name = name;
			this.Intervals.AddRange(aIntervals);
			this.Intervals.AddRange(bIntervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(Interval.None))
				Catalog.Add(this);
		}

		public static int operator |(ChordType a, ChordType b)
		{
			var result = a.Value | b.Value;
			return result;
		}

		public static explicit operator int(ChordType ct)
		{
			return ct.Value;
		}

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
					throw new NotImplementedException("#9 ???");
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
