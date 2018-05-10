using System;
using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
	public class ChordType
	{
		#region Statics
		static public List<ChordType> Catalog { get; set; } = new List<ChordType>();
		static public ChordType None = new ChordType("None", ChordToneInterval.None);
		static public ChordType Augmented = new ChordType("aug", ChordToneInterval.Major3rd, ChordToneInterval.Augmented5th);
		static public ChordType Diminished = new ChordType("dim", ChordToneInterval.Minor3rd, ChordToneInterval.Diminished5th);
		static public ChordType HalfDiminished = new ChordType("m7b5", Diminished.Intervals, ChordToneInterval.Minor7th);
		static public ChordType Diminished7 = new ChordType("dim7", Diminished.Intervals, ChordToneInterval.Diminished7th);


		#region Suspended chords
		static public ChordType Sus2 = new ChordType("Sus2", ChordToneInterval.Sus2, ChordToneInterval.Perfect5th);
		static public ChordType SevenSus2 = new ChordType("7Sus2", Sus2.Intervals, ChordToneInterval.Minor7th);
		static public ChordType Sus4 = new ChordType("Sus4", ChordToneInterval.Sus4, ChordToneInterval.Perfect5th);
		static public ChordType SevenSus4 = new ChordType("7Sus4", Sus4.Intervals, ChordToneInterval.Minor7th);
		static public ChordType Sus2Sus4 = new ChordType("Sus2Sus4", Sus2.Intervals, ChordToneInterval.Sus4);
		#endregion


		#region Diatonic Minor chords

		static public ChordType Minor = new ChordType("m", ChordToneInterval.Minor3rd, ChordToneInterval.Perfect5th);
		static public ChordType Minor7th = new ChordType("m7", Minor.Intervals, ChordToneInterval.Minor7th);
		static public ChordType MinorMaj7th = new ChordType("mM7", Minor.Intervals, ChordToneInterval.Major7th);
		static public ChordType Minor6th = new ChordType("m6", Minor.Intervals, ChordToneInterval.Major6th);
		static public ChordType Minor9th = new ChordType("m9", Minor7th.Intervals, ChordToneInterval.Ninth);
		static public ChordType Minor11th = new ChordType("m11", Minor9th.Intervals, ChordToneInterval.Eleventh);
		static public ChordType Minor13th = new ChordType("m13", Minor11th.Intervals, ChordToneInterval.Thirteenth);
		static public ChordType MinorAdd9 = new ChordType("mAdd9", Minor.Intervals, ChordToneInterval.Ninth);

		#endregion


		#region Diatonic Major chords
		static public ChordType Major = new ChordType("", ChordToneInterval.Major3rd, ChordToneInterval.Perfect5th);
		static public ChordType Major6th = new ChordType("6", Major.Intervals, ChordToneInterval.Major6th);
		static public ChordType Major7th = new ChordType("Maj7", Major.Intervals, ChordToneInterval.Major7th);
		static public ChordType Major9th = new ChordType("Maj9", Major7th.Intervals, ChordToneInterval.Ninth);
		static public ChordType Major11th = new ChordType("Maj11", Major9th.Intervals, ChordToneInterval.Eleventh);
		static public ChordType Major13th = new ChordType("Maj13", Major11th.Intervals, ChordToneInterval.Thirteenth);
		static public ChordType MajorAdd9 = new ChordType("Add9", Major.Intervals, ChordToneInterval.Ninth);
		static public ChordType MajorMu = new ChordType("MajMu", Major.Intervals, ChordToneInterval.Ninth);
		static public ChordType Major7b5 = new ChordType("Maj7b5", ChordToneInterval.Major3rd, ChordToneInterval.Diminished5th, ChordToneInterval.Major7th);
		static public ChordType Major7Aug5 = new ChordType("Maj7+5", ChordToneInterval.Major3rd, ChordToneInterval.Augmented5th, ChordToneInterval.Major7th);

		#endregion


		#region Diatonic Dominant7 chords
		static public ChordType Dominant7th = new ChordType("7", Major.Intervals, ChordToneInterval.Minor7th);
		static public ChordType Dominant9th = new ChordType("9", Dominant7th.Intervals, ChordToneInterval.Ninth);
		static public ChordType Dominant11th = new ChordType("11", Dominant9th.Intervals, ChordToneInterval.Eleventh);
		static public ChordType Dominant13th = new ChordType("13", Dominant11th.Intervals, ChordToneInterval.Thirteenth);

		#endregion


		#region Altered Dominant7 chords

		static public ChordType Dominant7b9 = new ChordType("7b9", Dominant7th.Intervals, ChordToneInterval.Flat9th);
		static public ChordType Dominant7Sharp9 = new ChordType("7#9", Dominant7th.Intervals, ChordToneInterval.Sharp9th);
		#endregion


		#endregion

		#region Properties
		public string Name { get; private set; }
		public int Value { get; private set; }
		public List<ChordToneInterval> Intervals { get; set; } = new List<ChordToneInterval>();

		public bool IsMajor { get; set; }
		public bool IsMinor { get; set; }
		public bool IsDiminished { get; set; }
		public bool IsDominant { get; set; }

		#endregion

		#region Construction
		private ChordType(string name, params ChordToneInterval[] intervals)
		{
			this.Name = name;
			this.Intervals.AddRange(intervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(ChordToneInterval.None))
				Catalog.Add(this);
			this.Init();
		}

		private ChordType(string name, List<ChordToneInterval> aIntervals, params ChordToneInterval[] bIntervals)
		{
			this.Name = name;
			this.Intervals.AddRange(aIntervals);
			this.Intervals.AddRange(bIntervals);
			this.Intervals.ForEach(x => this.Value |= x.Value);
			if (!this.Intervals.Contains(ChordToneInterval.None))
				Catalog.Add(this);
			this.Init();
		}

		void Init()
		{
			if (!this.Intervals.Contains(ChordToneInterval.None))
			{
				if (this.Intervals.Contains(ChordToneInterval.Major3rd))
					this.IsMajor = true;
				if (this.Intervals.Contains(ChordToneInterval.Minor3rd))
					this.IsMinor = true;
				if (this.Intervals.Contains(ChordToneInterval.Minor3rd)
					&& this.Intervals.Contains(ChordToneInterval.Diminished5th))
					this.IsDiminished = true;

				if (this.Intervals.Contains(ChordToneInterval.Major3rd)
					&& this.Intervals.Contains(ChordToneInterval.Minor7th))
					this.IsDominant = true;

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
			var result = ChordToneInterval.None;

			Predicate<ChordToneInterval> predicate = null;

			switch (cfe)
			{
				case ChordFunctionEnum.Root:
				case ChordFunctionEnum.None:
					break;

				case ChordFunctionEnum.Sus2:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd;
					break;

				case ChordFunctionEnum.Third:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor3rd || x == ChordToneInterval.Major3rd;
					break;

				case ChordFunctionEnum.Sus4:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th;
					break;

				case ChordFunctionEnum.Fifth:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect5th || x == ChordToneInterval.Diminished5th || x == ChordToneInterval.Augmented5th;
					break;

				case ChordFunctionEnum.Seventh:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor7th || x == ChordToneInterval.Major7th || x == ChordToneInterval.Diminished7th;
					break;

				case ChordFunctionEnum.Ninth:
					//throw new NotImplementedException("#9 ???");
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd || x == ChordToneInterval.Minor2nd;
					break;

				case ChordFunctionEnum.Eleventh:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th || x == ChordToneInterval.Augmented4th;
					break;

				case ChordFunctionEnum.Thirteenth:
					predicate = (ChordToneInterval x) => x == ChordToneInterval.Major6th || x == ChordToneInterval.Minor6th;
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
