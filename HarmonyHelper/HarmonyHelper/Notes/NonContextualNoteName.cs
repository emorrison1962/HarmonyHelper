using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	public class NonContextualNoteName : NoteName
	{
		public override string Name
		{
			get => $"{base.Name} (may be an enharmonic equivalent)";
			protected set => base.Name = value;
		}

		public NonContextualNoteName(NoteName nn)
		{
			ReflectionExtensions.Copy(this, nn);
		}

		#region Operators
		public static bool operator <(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(NonContextualNoteName a, NoteName b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}
		public static implicit operator int(NonContextualNoteName nn)
		{
			throw new InvalidOperationException($"{nameof(NonContextualNoteName)} does not support this.");
		}
		public static explicit operator NonContextualNoteName(int i)
		{
			throw new InvalidOperationException($"{nameof(NonContextualNoteName)} does not support this.");
		}
		public static NoteName operator +(NonContextualNoteName note, Interval interval)
		{
			throw new InvalidOperationException($"{nameof(NonContextualNoteName)} does not support this.");
		}

		public static NonContextualNoteName operator -(NonContextualNoteName note, Interval interval)
		{
			throw new InvalidOperationException($"{nameof(NonContextualNoteName)} does not support this.");
		}

		public static Interval operator -(NonContextualNoteName a, NoteName b)
		{
			throw new InvalidOperationException($"{nameof(NonContextualNoteName)} does not support this.");
		}

		#endregion

		#region IComparable

		public int CompareTo(NoteName other)
		{
			var result = Compare(this, other);
			return result;
		}
		public static int Compare(NonContextualNoteName a, NoteName b)
		{
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			var result = a.Value.CompareTo(b.Value);

			return result;
		}

		override public bool Equals(NoteName other)
		{
			var result = false;
			if (this.Name == other.Name
				&& this.Value == other.Value)
				result = true;
			return result;
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is NoteName)
			{
				result = this.Equals(obj as NoteName);
			}
			else
			{
				base.Equals(obj);
			}
			return result;

		}

		public override int GetHashCode()
		{
			var result = this.Value.GetHashCode();
			return result;
		}

		#endregion

	}
}
