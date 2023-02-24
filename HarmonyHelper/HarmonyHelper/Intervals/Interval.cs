using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eric.Morrison.Harmony.Constants;

namespace Eric.Morrison.Harmony.Intervals
{
	public class Interval : ClassBase, IEquatable<Interval>, IComparable<Interval>
    {
		#region Constants
		#endregion

		#region Static
		static public List<Interval> Catalog { get; set; } = new List<Interval>();
		static public Interval Unison = new Interval("Unison", 
            IntervalValuesEnum.Unison, 0, 
            IntervalRoleTypeEnum.Unison, 
            IntervalFunctionalValuesEnum.Unison);
        static public Interval Diminished2nd = new Interval("Diminished2nd", 
            IntervalValuesEnum.Unison, 0, 
            IntervalRoleTypeEnum.Second, 
            IntervalFunctionalValuesEnum.Second | IntervalFunctionalValuesEnum.Diminished);

        static public Interval AugmentedUnison = new Interval("Augmented Unison", 
            IntervalValuesEnum.Minor2nd, 1, 
            IntervalRoleTypeEnum.Unison, 
            IntervalFunctionalValuesEnum.Unison | IntervalFunctionalValuesEnum.Augmented);
		static public Interval Minor2nd = new Interval("Minor2nd", 
            IntervalValuesEnum.Minor2nd, 1, 
            IntervalRoleTypeEnum.Second, 
            IntervalFunctionalValuesEnum.Second | IntervalFunctionalValuesEnum.Minor);

		static public Interval Major2nd = new Interval("Major2nd", 
            IntervalValuesEnum.Major2nd, 2, 
            IntervalRoleTypeEnum.Second, 
            IntervalFunctionalValuesEnum.Major2nd);
		static public Interval Diminished3rd = new Interval("Diminished3rd", 
            IntervalValuesEnum.Major2nd, 2, IntervalRoleTypeEnum.Third,
            IntervalFunctionalValuesEnum.Major2nd);

		static public Interval Augmented2nd = new Interval("Augmented2nd", 
            IntervalValuesEnum.Minor3rd, 3, IntervalRoleTypeEnum.Second,
            IntervalFunctionalValuesEnum.Minor3rd);
		static public Interval Minor3rd = new Interval("Minor3rd", 
            IntervalValuesEnum.Minor3rd, 3, IntervalRoleTypeEnum.Third, 
            IntervalFunctionalValuesEnum.Minor3rd);

		static public Interval Major3rd = new Interval("Major3rd", 
            IntervalValuesEnum.Major3rd, 4, 
            IntervalRoleTypeEnum.Third,
            IntervalFunctionalValuesEnum.Major3rd);

		static public Interval Diminished4th = new Interval("Diminished4th", 
            IntervalValuesEnum.Diminished4th, 4, 
            IntervalRoleTypeEnum.Fourth,
            IntervalFunctionalValuesEnum.Diminished4th);
		
        static public Interval Perfect4th = new Interval("Perfect4th", 
            IntervalValuesEnum.Perfect4th, 5, 
            IntervalRoleTypeEnum.Fourth,
            IntervalFunctionalValuesEnum.Perfect4th);
        static public Interval Augmented3rd = new Interval("Augmented3rd", 
            IntervalValuesEnum.Perfect4th, 5, 
            IntervalRoleTypeEnum.Third,
            IntervalFunctionalValuesEnum.Third | IntervalFunctionalValuesEnum.Augmented);

        static public Interval Augmented4th = new Interval("Augmented4th", 
            IntervalValuesEnum.Augmented4th, 6, 
            IntervalRoleTypeEnum.Fourth,
            IntervalFunctionalValuesEnum.Augmented4th);

		static public Interval Diminished5th = new Interval("Diminished5th", 
            IntervalValuesEnum.Diminished5th, 6, 
            IntervalRoleTypeEnum.Fifth,
            IntervalFunctionalValuesEnum.Diminished5th);

		static public Interval Perfect5th = new Interval("Perfect5th", 
            IntervalValuesEnum.Perfect5th, 7, 
            IntervalRoleTypeEnum.Fifth,
            IntervalFunctionalValuesEnum.Perfect5th);
        static public Interval Diminished6th = new Interval("Diminished6th", 
            IntervalValuesEnum.Perfect5th, 7, 
            IntervalRoleTypeEnum.Sixth,
            IntervalFunctionalValuesEnum.Sixth | IntervalFunctionalValuesEnum.Diminished);

        static public Interval Augmented5th = new Interval("Augmented5th", 
            IntervalValuesEnum.Augmented5th, 8, 
            IntervalRoleTypeEnum.Fifth,
            IntervalFunctionalValuesEnum.Augmented5th);

		static public Interval Minor6th = new Interval("Minor6th", 
            IntervalValuesEnum.Minor6th, 8, 
            IntervalRoleTypeEnum.Sixth,
            IntervalFunctionalValuesEnum.Minor6th);

		static public Interval Major6th = new Interval("Major6th", 
            IntervalValuesEnum.Major6th, 9, 
            IntervalRoleTypeEnum.Sixth,
            IntervalFunctionalValuesEnum.Major6th);

		static public Interval Augmented6th = new Interval("Augmented6th", 
            IntervalValuesEnum.Minor7th, 10, 
            IntervalRoleTypeEnum.Sixth,
            IntervalFunctionalValuesEnum.Sixth | IntervalFunctionalValuesEnum.Augmented);
		static public Interval Diminished7th = new Interval("Diminished7th", 
            IntervalValuesEnum.Major6th, 9, 
            IntervalRoleTypeEnum.Seventh,
            IntervalFunctionalValuesEnum.Diminished7th);
		static public Interval Minor7th = new Interval("Minor7th", 
            IntervalValuesEnum.Minor7th, 10, 
            IntervalRoleTypeEnum.Seventh,
            IntervalFunctionalValuesEnum.Minor7th);

		static public Interval Major7th = new Interval("Major7th", 
            IntervalValuesEnum.Major7th, 11, 
            IntervalRoleTypeEnum.Seventh,
            IntervalFunctionalValuesEnum.Major7th);
		static public Interval DiminishedOctave = new Interval("Diminished Octave", 
            IntervalValuesEnum.Major7th, 11, 
            IntervalRoleTypeEnum.Octave,
            IntervalFunctionalValuesEnum.DiminishedOctave);
		
        static public Interval PerfectOctave = new Interval("Perfect Octave", 
            IntervalValuesEnum.Unison, 12, 
            IntervalRoleTypeEnum.Octave,
            IntervalFunctionalValuesEnum.PerfectOctave);
        static public Interval Augmented7th = new Interval("Augmented7th", 
            IntervalValuesEnum.Unison, 12, 
            IntervalRoleTypeEnum.Seventh,
            IntervalFunctionalValuesEnum.Seventh | IntervalFunctionalValuesEnum.Augmented);
        #endregion

        virtual public string Name { get; protected set; }
		public int Value { get; private set; }
		public int SemiTones { get; private set; }
		virtual public IntervalRoleTypeEnum IntervalRoleType { get; protected set; }
        public IntervalFunctionalValuesEnum FunctionalValue { get; private set; }

        #region Construction
        static Interval() { }
        private Interval() { }
        private Interval(string name, IntervalValuesEnum value, int semitones, IntervalRoleTypeEnum it, IntervalFunctionalValuesEnum ifve)
        {
            this.Name = name;
            this.Value = (int)value;
            this.SemiTones = semitones;
            this.IntervalRoleType = it;
            this.FunctionalValue = ifve;

            Catalog.Add(this);
        }
        protected Interval(Interval src)
        {
            this.Name = src.Name;
            this.Value = src.Value;
            this.SemiTones = src.SemiTones;
            this.IntervalRoleType = src.IntervalRoleType;
        }


        #endregion
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
