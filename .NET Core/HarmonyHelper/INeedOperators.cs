using System;

namespace Eric.Morrison.Harmony
{

#if false
    public interface INeedOperators<T> where T : IComparable<T>, IEquatable<T>
    {

        new bool Equals(T? other)
        {
            throw new NotImplementedException();
        }
        int GetHashCode()
        {
            throw new NotImplementedException();
        }


        #region Operators
        static bool operator <(T? a, T? b) { return (dynamic)a.CompareTo((dynamic)b) < 0; }
        static bool operator >(T? a, T? b) { return !(a < b); }
        static bool operator <=(INeedOperators<T> a, INeedOperators<T> b) { throw new NotImplementedException(); }
        static bool operator >=(INeedOperators<T> a, INeedOperators<T> b) { throw new NotImplementedException(); }
#if false
        abstract static bool operator ==(INeedOperators<T> a, INeedOperators<T> b);
        abstract static bool operator !=(INeedOperators<T> a, INeedOperators<T> b);
        static int operator |(INeedOperators<T> a, INeedOperators<T> b) { throw new NotImplementedException(); }
#endif
        #endregion

    }

#endif
}
