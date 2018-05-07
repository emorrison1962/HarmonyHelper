using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison
{
	public static class LinqExtensions
	{
		public static IEnumerable<T[]> GetPairs<T>(this IEnumerable<T> sequence)
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
					yield return buffer;
					buffer = new T[partitionSize];
				}
			}
		}


	}//class
}//ns
