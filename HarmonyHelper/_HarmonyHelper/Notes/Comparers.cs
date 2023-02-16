using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public class NoteNameValueEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			var result = false;
			if (x.Value == y.Value)
				result = true;
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Value.GetHashCode();
		}
	}

	public class NoteNameExplicitEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			var result = false;
			if (x.Name == y.Name && x.Value == y.Value)
				result = true;
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Name.GetHashCode() ^ obj.Value.GetHashCode();
		}
	}

	public class NoteNameAlphaEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			return x.Name.Equals(y.Name);
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Name.GetHashCode();
		}
	}

	public class NoteNameAlphaComparer : IComparer<NoteName>
	{
		public int Compare(NoteName x, NoteName y)
		{
			return x.AsciiSortValue.CompareTo(y.AsciiSortValue);
		}
	}

	public class NoteNameListAlphaEqualityComparer : IEqualityComparer<List<NoteName>>
	{
		public bool Equals(List<NoteName> x, List<NoteName> y)
		{
			var result = true;
			var comparer = new NoteNameAlphaEqualityComparer();
			foreach (var nn in x)
			{
				if (!y.Contains(nn, comparer))
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public int GetHashCode(List<NoteName> obj)
		{
			var result = 0;
			foreach (var nn in obj)
			{
				result ^= nn.Value.GetHashCode();
			}
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Value.GetHashCode();
		}
	}


	public class NoteNameListValueEqualityComparer : IEqualityComparer<List<NoteName>>
	{
		public bool Equals(List<NoteName> x, List<NoteName> y)
		{
			var result = true;
			var valueComparer = new NoteNameValueEqualityComparer();
			foreach (var nn in x)
			{
				if (!y.Contains(nn, valueComparer))
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public int GetHashCode(List<NoteName> obj)
		{
			var result = 0;
			foreach (var nn in obj)
			{
				result ^= nn.Value.GetHashCode();
			}
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Value.GetHashCode();
		}
	}

}
