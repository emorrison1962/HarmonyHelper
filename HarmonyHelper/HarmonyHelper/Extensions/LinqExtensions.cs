using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public static class LinqExtensions
	{
		public class Pair<T> where T : class
		{
			public T First { get; private set; }
			public T Second { get; private set; }
			public Pair(T[] pair)
			{
				this.First = pair[0];
				this.Second = pair[1];
			}


			public T this[int ndx]
			{
				get
				{
					T result = null;
					if (ndx == 0)
						result = this.First;
					else if (ndx == 1)
						result = this.Second;
					else
						throw new IndexOutOfRangeException();
					return result;
				}
			}
		}

		public static IEnumerable<Pair<T>> GetPairs<T>(this IEnumerable<T> sequence) where T: class
		{
			if (sequence == null)
				throw new ArgumentNullException();

			int partitionSize = 2;
			var buffer = new T[partitionSize];
			var count = sequence.Count();
			for (int i = 0; i < count - 1; ++i)
			{
				var item1 = sequence.ElementAt(i);
				var item2 = sequence.ElementAt(i + 1);
				var ndx = 0;
				buffer[ndx++] = item1;
				buffer[ndx++] = item2;

				if (ndx == partitionSize)
				{
					yield return new Pair<T>(buffer);
					buffer = new T[partitionSize];
				}
			}
		}

		public static IEnumerable<T[]> GetTriplets<T>(this IEnumerable<T> sequence) where T : class
		{
			if (sequence == null)
				throw new ArgumentNullException();

			int partitionSize = 3;
			var buffer = new T[partitionSize];
			var count = sequence.Count();
			for (int i = 0; i < count - 2; ++i)
			{
				var item1 = sequence.ElementAt(i);
				var item2 = sequence.ElementAt(i + 1);
				var item3 = sequence.ElementAt(i + 2);
				var ndx = 0;
				buffer[ndx++] = item1;
				buffer[ndx++] = item2;
				buffer[ndx++] = item3;

				if (ndx == partitionSize)
				{
					yield return buffer;
					buffer = new T[partitionSize];
				}
			}
		}


	}//class
}//ns
