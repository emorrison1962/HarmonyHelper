using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Intervals
{
	public class Interval : IEquatable<Interval>, IComparable<Interval>
	{
		#region Constants
		#endregion

		#region Static
		static public List<Interval> Catalog { get; set; } = new List<Interval>();
		static public Interval Unison = new Interval("Unison", 0);
		static public Interval AugmentedUnison = new Interval("Augmented Unison", Constants.INTERVAL_VALUE_MINOR_2ND);

		static public Interval Minor2nd = new Interval("Minor2nd", Constants.INTERVAL_VALUE_MINOR_2ND);
		static public Interval Major2nd = new Interval("Major2nd", Constants.INTERVAL_VALUE_MAJOR_2ND);
		static public Interval Augmented2nd = new Interval("Augmented2nd", Constants.INTERVAL_VALUE_MINOR_3RD);
		static public Interval Diminished3rd = new Interval("Diminished3rd", Constants.INTERVAL_VALUE_MAJOR_2ND);
		static public Interval Minor3rd = new Interval("Minor3rd", Constants.INTERVAL_VALUE_MINOR_3RD);
		static public Interval Major3rd = new Interval("Major3rd", Constants.INTERVAL_VALUE_MAJOR_3RD);
		static public Interval Diminished4th = new Interval("Diminished4th", Constants.INTERVAL_VALUE_DIMINISHED_4TH);
		static public Interval Perfect4th = new Interval("Perfect4th", Constants.INTERVAL_VALUE_PERFECT_4TH);
		static public Interval Augmented4th = new Interval("Augmented4th", Constants.INTERVAL_VALUE_AUGMENTED_4TH);
		static public Interval Diminished5th = new Interval("Diminished5th", Constants.INTERVAL_VALUE_DIMINISHED_5TH);
		static public Interval Perfect5th = new Interval("Perfect5th", Constants.INTERVAL_VALUE_PERFECT_5TH);
		static public Interval Augmented5th = new Interval("Augmented5th", Constants.INTERVAL_VALUE_AUGMENTED_5TH);
		static public Interval Minor6th = new Interval("Minor6th", Constants.INTERVAL_VALUE_MINOR_6TH);
		static public Interval Major6th = new Interval("Major6th", Constants.INTERVAL_VALUE_MAJOR_6TH);
		static public Interval Diminished7th = new Interval("Diminished7th", Constants.INTERVAL_VALUE_MAJOR_6TH);
		static public Interval Augmented6th = new Interval("Augmented6th", Constants.INTERVAL_VALUE_MINOR_7TH);
		static public Interval Minor7th = new Interval("Minor7th", Constants.INTERVAL_VALUE_MINOR_7TH);
		static public Interval Major7th = new Interval("Major7th", Constants.INTERVAL_VALUE_MAJOR_7TH);

		static public Interval DiminishedOctave = new Interval("Diminished Octave", Constants.INTERVAL_VALUE_MAJOR_7TH);
		#endregion

		#region COPY_AND_PASTE_NAMES
#if false
Interval.Unison
Interval.Minor2nd
Interval.Major2nd
Interval.Augmented2nd
Interval.Minor3rd
Interval.Major3rd
Interval.Diminished4th
Interval.Perfect4th
Interval.Augmented4th
Interval.Diminished5th
Interval.Perfect5th
Interval.Augmented5th
Interval.Minor6th
Interval.Major6th
Interval.Diminished7th
Interval.Augmented6th
Interval.Minor7th
Interval.Major7th
#endif
		#endregion

		virtual public string Name { get; protected set; }
		public int Value { get; private set; }
		private Interval(string name, int value)
		{
			this.Name = name;
			this.Value = value;
			Catalog.Add(this);
		}
		protected Interval(Interval src)
		{
			this.Name = src.Name;
			this.Value = src.Value;
		}

		static Interval() {
		}
		public Interval Invert()
		{
			var result = Interval.Unison;

			if (this == Interval.Unison)
				result = Interval.Unison;

			else if (this == Interval.AugmentedUnison)
				result = Interval.DiminishedOctave;

			else if (this == Interval.Minor2nd)
				result = Interval.Major7th;

			else if (this == Interval.Major2nd)
				result = Interval.Minor7th;

			else if (this == Interval.Augmented2nd)
				result = Interval.Diminished7th;

			else if (this == Interval.Diminished3rd)
				result = Interval.Augmented6th;

			else if (this == Interval.Minor3rd)
				result = Interval.Major6th;

			else if (this == Interval.Major3rd)
				result = Interval.Minor6th;

			else if (this == Interval.Diminished4th)
				result = Interval.Augmented5th;

			else if (this == Interval.Perfect4th)
				result = Interval.Perfect5th;

			else if (this == Interval.Augmented4th)
				result = Interval.Diminished5th;

			else if (this == Interval.Diminished5th)
				result = Interval.Augmented4th;

			else if (this == Interval.Perfect5th)
				result = Interval.Perfect4th;

			else if (this == Interval.Minor6th)
				result = Interval.Major3rd;

			else if (this == Interval.Major6th)
				result = Interval.Minor3rd;

			else if (this == Interval.Augmented6th)
				result = Interval.Diminished3rd;

			else if (this == Interval.Minor7th)
				result = Interval.Major2nd;

			else if (this == Interval.Major7th)
				result = Interval.Minor2nd;

			else if (this == Interval.DiminishedOctave)
				result = Interval.AugmentedUnison;

			else
				throw new ArgumentOutOfRangeException();


			return result;
		}

		public bool Equals(Interval other)
		{
			var result = 0 == this.CompareTo(other);
			return result;
		}

		public Interval Abs()
		{
			var result = this;
			if (this.Invert() < this)
				result = this.Invert();
			return result;
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is Interval)
				result = this.Equals(obj as Interval);
			return result;
		}


		public int CompareTo(Interval other)
		{
			int result = 0;
			if (other is null)
				result= -1;

			if (result == 0)
			{
				result = this.Value.CompareTo(other.Value);
			}
			if (result == 0)
			{
				result = this.Name.CompareTo(other.Name);
			}
			return result;
		}

		public static bool operator <(Interval a, Interval b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(Interval a, Interval b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(Interval a, Interval b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(Interval a, Interval b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(Interval a, Interval b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(Interval a, Interval b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}
		public static int operator |(Interval a, Interval b)
		{
			var result = a.Value | b.Value;
			return result;
		}
		public static explicit operator int(Interval ct)
		{
			return ct.Value;
		}
		public static explicit operator Interval(int i)
		{
			return Interval.Catalog.First(x => x.Value == i);
		}


		public static int Compare(Interval a, Interval b)
		{
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			var result = a.CompareTo(b);
			return result;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name}: Name={this.Name} Value=0x{this.Value.ToString(("x8"))}";
		}

#region Used to be IntervalsEnumExtensions
		class IntervalValueComparer : IEqualityComparer<Interval>
		{
			public bool Equals(Interval x, Interval y)
			{
				bool result = false;
				if (x.Value == y.Value)
					result = true;
				return result;

			}

			public int GetHashCode(Interval obj)
			{
				return obj.GetHashCode();
			}
		}

		public int ToIndex()
		{
			var intervals = Interval.Catalog
				.Distinct(new IntervalValueComparer())
				.OrderBy(x => x.Value)
				.ToList();
			var found = intervals.First(x => x.Value == this.Value);
			var result = intervals.IndexOf(found);

			return result;
		}

		public Interval GetInversion()
		{
			Interval result = Interval.Unison;
			if (Interval.Unison != this)
			{
				if (this == Interval.Minor2nd)
					result = Interval.Major7th;
				else if (this == Interval.Major2nd)
					result = Interval.Minor7th;
				else if (this == Interval.Diminished3rd)
					result = Interval.Augmented6th;
				else if (this == Interval.Augmented2nd)
					result = Interval.Diminished7th;
				else if (this == Interval.Minor3rd)
					result = Interval.Major6th;
				else if (this == Interval.Major3rd)
					result = Interval.Minor6th;
				else if (this == Interval.Diminished4th)
					result = Interval.Augmented5th;
				else if (this == Interval.Perfect4th)
					result = Interval.Perfect5th;
				else if (this == Interval.Augmented4th)
					result = Interval.Diminished5th;
				else if (this == Interval.Diminished5th)
					result = Interval.Augmented4th;
				else if (this == Interval.Perfect5th)
					result = Interval.Perfect4th;
				else if (this == Interval.Augmented5th)
					result = Interval.Diminished4th;
				else if (this == Interval.Minor6th)
					result = Interval.Major3rd;
				else if (this == Interval.Major6th)
					result = Interval.Minor3rd;
				else if (this == Interval.Augmented6th)
					result = Interval.Diminished3rd;
				else if (this == Interval.Diminished7th)
					result = Interval.Augmented2nd;
				else if (this == Interval.Minor7th)
					result = Interval.Major2nd;
				else if (this == Interval.Major7th)
					result = Interval.Minor2nd;
				else
					throw new ArgumentOutOfRangeException();
			}

			return result;
		}

		public override int GetHashCode()
		{
			var hashCode = -244751520;
			// hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Name);
			hashCode = hashCode * -1521134295 + this.Value.GetHashCode();
			return hashCode;
		}



#endregion


	}//class
}//ns
