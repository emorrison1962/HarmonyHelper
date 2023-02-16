using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eric.Morrison.Harmony.Constants;

namespace Eric.Morrison.Harmony.Intervals
{
	public class Interval : IEquatable<Interval>, IComparable<Interval>
    {
		#region Constants
		#endregion

		#region Static
		static public List<Interval> Catalog { get; set; } = new List<Interval>();
		static public Interval Unison = new Interval("Unison", IntervalValuesEnum.INTERVAL_VALUE_UNISON, 0, IntervalRoleTypeEnum.Unison);
        static public Interval Diminished2nd = new Interval("Diminished2nd", IntervalValuesEnum.INTERVAL_VALUE_UNISON, 0, IntervalRoleTypeEnum.Second);

        static public Interval AugmentedUnison = new Interval("Augmented Unison", IntervalValuesEnum.INTERVAL_VALUE_MINOR_2ND, 1, IntervalRoleTypeEnum.Unison);
		static public Interval Minor2nd = new Interval("Minor2nd", IntervalValuesEnum.INTERVAL_VALUE_MINOR_2ND, 1, IntervalRoleTypeEnum.Second);

		static public Interval Major2nd = new Interval("Major2nd", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_2ND, 2, IntervalRoleTypeEnum.Second);
		static public Interval Diminished3rd = new Interval("Diminished3rd", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_2ND, 2, IntervalRoleTypeEnum.Third);

		static public Interval Augmented2nd = new Interval("Augmented2nd", IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD, 3, IntervalRoleTypeEnum.Second);
		static public Interval Minor3rd = new Interval("Minor3rd", IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD, 3, IntervalRoleTypeEnum.Third);

		static public Interval Major3rd = new Interval("Major3rd", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_3RD, 4, IntervalRoleTypeEnum.Third);

		static public Interval Diminished4th = new Interval("Diminished4th", IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_4TH, 4, IntervalRoleTypeEnum.Fourth);
		
        static public Interval Perfect4th = new Interval("Perfect4th", IntervalValuesEnum.INTERVAL_VALUE_PERFECT_4TH, 5, IntervalRoleTypeEnum.Fourth);
        static public Interval Augmented3rd = new Interval("Augmented3rd", IntervalValuesEnum.INTERVAL_VALUE_PERFECT_4TH, 5, IntervalRoleTypeEnum.Third);

        static public Interval Augmented4th = new Interval("Augmented4th", IntervalValuesEnum.INTERVAL_VALUE_AUGMENTED_4TH, 6, IntervalRoleTypeEnum.Fourth);

		static public Interval Diminished5th = new Interval("Diminished5th", IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_5TH, 6, IntervalRoleTypeEnum.Fifth);

		static public Interval Perfect5th = new Interval("Perfect5th", IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH, 7, IntervalRoleTypeEnum.Fifth);
        static public Interval Diminished6th = new Interval("Diminished6th", IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH, 7, IntervalRoleTypeEnum.Sixth);

        static public Interval Augmented5th = new Interval("Augmented5th", IntervalValuesEnum.INTERVAL_VALUE_AUGMENTED_5TH, 8, IntervalRoleTypeEnum.Fifth);

		static public Interval Minor6th = new Interval("Minor6th", IntervalValuesEnum.INTERVAL_VALUE_MINOR_6TH, 8, IntervalRoleTypeEnum.Sixth);

		static public Interval Major6th = new Interval("Major6th", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_6TH, 9, IntervalRoleTypeEnum.Sixth);

		static public Interval Augmented6th = new Interval("Augmented6th", IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH, 10, IntervalRoleTypeEnum.Sixth);
		static public Interval Diminished7th = new Interval("Diminished7th", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_6TH, 9, IntervalRoleTypeEnum.Seventh);
		static public Interval Minor7th = new Interval("Minor7th", IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH, 10, IntervalRoleTypeEnum.Seventh);

		static public Interval Major7th = new Interval("Major7th", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_7TH, 11, IntervalRoleTypeEnum.Seventh);
		static public Interval DiminishedOctave = new Interval("Diminished Octave", IntervalValuesEnum.INTERVAL_VALUE_MAJOR_7TH, 11, IntervalRoleTypeEnum.Octave);
		
        static public Interval PerfectOctave = new Interval("Perfect Octave", IntervalValuesEnum.INTERVAL_VALUE_UNISON, 12, IntervalRoleTypeEnum.Octave);
        static public Interval Augmented7th = new Interval("Augmented7th", IntervalValuesEnum.INTERVAL_VALUE_UNISON, 12, IntervalRoleTypeEnum.Seventh);
        #endregion

        virtual public string Name { get; protected set; }
		public int Value { get; private set; }
		public int SemiTones { get; private set; }
		virtual public IntervalRoleTypeEnum IntervalRoleType { get; protected set; }
		private Interval(string name, IntervalValuesEnum value, int semitones, IntervalRoleTypeEnum it)
		{
			this.Name = name;
			this.Value = (int)value;
			this.SemiTones = semitones;	
			this.IntervalRoleType = it;	
			Catalog.Add(this);
		}
		protected Interval(Interval src)
		{
			this.Name = src.Name;
			this.Value = src.Value;
			this.SemiTones= src.SemiTones;
			this.IntervalRoleType = src.IntervalRoleType;
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

            else if (this == Interval.Diminished2nd)
                result = Interval.Augmented7th;

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

            else if (this == Interval.Augmented3rd)
                result = Interval.Diminished6th;

            else if (this == Interval.Diminished4th)
				result = Interval.Augmented5th;

			else if (this == Interval.Perfect4th)
				result = Interval.Perfect5th;

			else if (this == Interval.Augmented4th)
				result = Interval.Diminished5th;

			else if (this == Interval.Diminished5th)
				result = Interval.Augmented4th;

            else if (this == Interval.Augmented5th)
                result = Interval.Diminished4th;

            else if (this == Interval.Diminished6th)
                result = Interval.Augmented3rd;

            else if (this == Interval.Perfect5th)
				result = Interval.Perfect4th;

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

            else if (this == Interval.Augmented7th)
                result = Interval.Diminished2nd;

            else if (this == Interval.DiminishedOctave)
				result = Interval.AugmentedUnison;

			else
				throw new ArgumentOutOfRangeException();


			return result;
		}

        #region IComparible
        public bool Equals(Interval other)
        {
            var result = 0 == this.CompareTo(other);
            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Interval)
                result = this.Equals(obj as Interval);
            return result;
        }

        public override int GetHashCode()
        {
            var result = this.Value.GetHashCode();
            return result;
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

        public int CompareTo(Interval other)
        {
            int result = 0;
            if (other is null)
                result = -1;

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

        #endregion

        #region Operators
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
        [Obsolete("", false)]
		public static explicit operator int(Interval ct)
        {
            return ct.Value;
        }
		[Obsolete("", false)]
		public static explicit operator Interval(int i)
        {
            return Interval.Catalog.First(x => x.Value == i);
        }

        #endregion


        public override string ToString()
		{
			return $"{this.GetType().Name}: Name={this.Name} Value=0x{this.Value.ToString(("x8"))}";
		}

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
				return obj.Value.GetHashCode();
			}
		}

		[Obsolete("", true)]
		virtual public int ToIndex()
		{
			var intervals = Interval.Catalog
				.Distinct(new IntervalValueComparer())
				.OrderBy(x => x.Value)
				.ToList();
			var found = intervals.First(x => x.Value == this.Value);
			var result = intervals.IndexOf(found);

			return result;
		}

		public Interval Abs()
		{
			var result = this;
			if (this.Invert() < this)
				result = this.Invert();
			return result;
		}
		virtual public Interval GetInversion()
        {
            Interval result = Interval.Unison;
            if (this == Interval.Unison)
                result = Interval.Unison;
            else if (this == Interval.Diminished2nd)
                result = Interval.Augmented7th;
            

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

            else if (this == Interval.Diminished6th)
                result = Interval.Augmented3rd;
            else if (this == Interval.Augmented3rd)
                result = Interval.Diminished6th;

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
            else if (this == Interval.DiminishedOctave)
                result = Interval.AugmentedUnison;
            else if (this == Interval.PerfectOctave)
                result = Interval.PerfectOctave;
            else if (this == Interval.Augmented7th)
                result = Interval.Diminished2nd;

            else
                throw new ArgumentOutOfRangeException();

            return result;
        }


    }//class
}//ns
