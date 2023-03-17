using System;
using System.Collections.Generic;
using System.Linq;
using static Eric.Morrison.Harmony.Chords.Chord;
//using static Eric.Morrison.Harmony.Chord;

namespace Eric.Morrison.Harmony
{
	static public partial class ListExtensions
	{
		public static T Advance<T>(this List<T> list, int startingNdx, int count) where T : class
		{
			T result = null;
			var maxNdx = list.Count - 1;
			var currentNdx = startingNdx;
			for (int i = 0; i < count; ++i) 
			{ 
				if (currentNdx < maxNdx)
				{
					++currentNdx;
					result = list[currentNdx];
				}
				else if (currentNdx == maxNdx)
				{
					currentNdx = 0;
					result = list[currentNdx];
				}
			}

			return result;
		}

		public static T NextOrFirst<T>(this List<T> list, T current, ref bool wrapped) where T : class
		{
			T result = null;
			var maxNdx = list.Count - 1;
			var currentNdx = list.IndexOf(current);
			if (currentNdx < maxNdx)
			{
				++currentNdx;
				result = list[currentNdx];
			}
			else if (currentNdx == maxNdx)
			{
				currentNdx = 0;
				result = list[currentNdx];
				wrapped = true;
			}

			return result;
		}

		public static T NextOrFirst<T>(this List<T> list, ref int currentNdx) where T : struct
		{
			T result = default;
			var maxNdx = list.Count - 1;
			if (currentNdx < maxNdx)
			{
				result = list[currentNdx];
				++currentNdx;
			}
			else if (currentNdx == maxNdx)
			{
				result = list[maxNdx];
				currentNdx = 0;
			}

			return result;
		}



        public static int GetDistance<T>(this List<T> list, T startingAt, T criteria) where T: IEquatable<T>, IComparable<T>
		{
			if (startingAt.Equals(criteria))
			{
				return 0;
			}
			var maxNdx = list.Count - 1;
			var currentNdx = list.IndexOf(startingAt);

			int distance = 1;
			for (; distance <= list.Count; ++distance)
			{
				if (currentNdx < maxNdx)
				{
					var result = list[currentNdx];
					if (result.Equals(criteria))
					{
						break;
					}
					++currentNdx;
				}
				else if (currentNdx == maxNdx)
				{
					var result = list[maxNdx];
					if (result.Equals(criteria))
					{
						break;
					}
					currentNdx = 0;
				}
			}
			return distance;
		}


		public static T NextOrFirst<T>(this List<T> list, int currentNdx) where T : class
		{
			var maxNdx = list.Count - 1;
			if (currentNdx > maxNdx)
			{
				currentNdx -= list.Count;
			}

			T result = list[currentNdx];
			return result;
		}

		public static int GetDistance<T>(this NoteName src, NoteName dst, bool invert = false)
		{
			int result = int.MinValue;
			var chars = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', };
			if (!invert)
			{
				result = chars.GetDistance(src.Name[0], dst.Name[0]);
			}
			else
			{
				result = chars.GetDistance(dst.Name[0], src.Name[0]);
			}

			return result;
		}


	}//class

}//ns
