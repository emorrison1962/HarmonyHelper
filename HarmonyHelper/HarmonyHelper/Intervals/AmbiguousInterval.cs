using System;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
    public class AmbiguousInterval : Interval, IEquatable<Interval>, IComparable<Interval>
    {
        public override string Name
        {
            get => $"{base.Name} (may be an enharmonic equivalent)";
            protected set => base.Name = value;
        }

        public AmbiguousInterval(Interval src) 
            : base(src)
        {
            ReflectionExtensions.Copy(this, src);
        }

        override public Interval GetInversion()
        {
            var result = Interval.Catalog.First(x => x.Value == this.Value 
                && x.IntervalRoleType == this.IntervalRoleType)
                .GetInversion();
            
            return result;
        }

        new public bool Equals(Interval other)
        {
            var result = 0 == this.CompareTo(other);
            return result;
        }

        public static bool operator <(AmbiguousInterval left, Interval right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(AmbiguousInterval left, Interval right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(AmbiguousInterval left, Interval right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(AmbiguousInterval left, Interval right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator ==(AmbiguousInterval a, Interval b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(AmbiguousInterval a, Interval b)
        {
            var result = Compare(a, b) != 0;
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

        public static int Compare(AmbiguousInterval a, Interval b)
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

        new public int CompareTo(Interval other)
        {
            int result = 0;
            if (other is null)
                result = -1;

            if (result == 0)
            {
                result = this.Value.CompareTo(other.Value);
            }
            return result;
        }

    }//class
}//ns