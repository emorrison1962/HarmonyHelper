using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper
{
    public interface IHasOperators<T>: IEquatable<T>, IComparable<T>
    {
        bool Equals(object obj);
        int GetHashCode();

        abstract static bool operator ==(IHasOperators<T> a, IHasOperators<T> b);// { return a.Equals(b); }
        abstract static bool operator !=(IHasOperators<T> a, IHasOperators<T> b);
        abstract static bool operator <(IHasOperators<T> a, IHasOperators<T> b);
        abstract static bool operator >(IHasOperators<T> a, IHasOperators<T> b);
        abstract static bool operator <=(IHasOperators<T> a, IHasOperators<T> b);
        abstract static bool operator >=(IHasOperators<T> a, IHasOperators<T> b);
    }

    public class Junk : IComparable<Junk>, IEquatable<Junk>
    {
        int Ndx { get; set; }
        public Junk() { }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException("Implement Equals!");
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Junk? other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Junk? other)
        {
            return this.CompareTo(other) == 0;
        }

        public static bool operator ==(Junk left, Junk right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Junk left, Junk right)
        {
            return !(left == right);
        }

        public static bool operator <(Junk left, Junk right)
        {
            return ReferenceEquals(left, null) 
                ? !ReferenceEquals(right, null) 
                : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Junk left, Junk right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Junk left, Junk right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Junk left, Junk right)
        {
            return ReferenceEquals(left, null) 
                ? ReferenceEquals(right, null) 
                : left.CompareTo(right) >= 0;
        }
    }
}
