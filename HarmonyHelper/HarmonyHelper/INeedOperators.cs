using System;

namespace Eric.Morrison.Harmony
{
	public interface INeedOperators<T> : IEquatable<T>, IComparable<T>
	{
        #region Operators
        abstract static bool operator <(T a, T b);
        abstract static bool operator >(T a, T b);
        abstract static bool operator <=(T a, T b);
        abstract static bool operator >=(T a, T b);
        abstract static bool operator ==(T a, T b);
        abstract static bool operator !=(T a, T b);
        abstract static int operator |(T a, T b);

        #endregion

    }
}
