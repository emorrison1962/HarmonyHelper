using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class HarmonyEntityBase : ClassBase
    {
        public KeySignature Key { get; protected set; }

        public HarmonyEntityBase(KeySignature key)
        {
            this.Key = key;
        }
    }//class

    public abstract class BaseWithOperators<T> : HarmonyEntityBase, IComparable<T>, IEquatable<T> where T: HarmonyEntityBase
	{
        T entity;
        public BaseWithOperators(KeySignature key)
            : base(key)
        {
        }

		#region IComparable

		public int CompareTo(BaseWithOperators<T> other)
		{
			var result = Compare(this, other);
			return result;
		}
		public static int Compare(BaseWithOperators<T> a, BaseWithOperators<T> b) 
		{
			return a.CompareTo(b);
		}

		public bool Equals(T other)
		{
			return this.CompareTo(other) == 0;
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is T)
			{
				result = this.Equals(obj as T);
			}
			else
			{
				base.Equals(obj);
			}
			return result;

		}

		abstract public override int GetHashCode();

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }

        #endregion




        public static bool operator <(BaseWithOperators<T> left, T right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(BaseWithOperators<T> left, T right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(BaseWithOperators<T> left, T right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(BaseWithOperators<T> left, T right)
        {
            return left.CompareTo(right) >= 0;
        }

		#region Operators
		public static bool operator <(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}
		
		public static T operator +(BaseWithOperators<T> note, IntervalContext ctx)
		{
			throw new NotImplementedException();
			//var result = note;
			//if (null != note && ctx.Interval > Interval.Unison)
			//{
			//	result = TransposeUp(note, ctx.Interval);
			//	//result = ctx.TNormalizer.GetNormalized(result, ctx.Interval);
			//}
			//return result;
		}

		public static T operator -(BaseWithOperators<T> note, IntervalContext ctx)
		{
			throw new NotImplementedException();	
			//var result = note;
			//if (null != note && ctx.Interval > Interval.Unison)
			//{
			//	result = TransposeDown(note, ctx.Interval);
			//}
			//return result;
		}

		public static Interval operator -(BaseWithOperators<T> a, BaseWithOperators<T> b)
		{
			throw new NotImplementedException();
			var result = Interval.Unison;
			//bool success = false;
			//if ((null != a && null != b) &&
			//	(a.Value != b.Value))
			//	success = true;

			//if (success)
			//{
			//	var notes = T.Catalog
			//		.Distinct(new NoteNameValueEqualityComparer())
			//		.OrderBy(x => x.Value)
			//		.ToList();

			//	var ndxA = notes.FindIndex(x => x.Value == a.Value);
			//	var ndxB = notes.FindIndex(x => x.Value == b.Value);

			//	var invert = false;
			//	var diff = ndxA - ndxB;
			//	if (diff < 0)
			//	{
			//		invert = true;
			//		diff = Math.Abs(diff);
			//	}

			//	var val = 1 << diff;
			//	result = ResolveInterval(val, a, b);

			//	if (invert)
			//		result = result.GetInversion();
			//}
			//return result;
		}

		#endregion

	}//class

}//ns
