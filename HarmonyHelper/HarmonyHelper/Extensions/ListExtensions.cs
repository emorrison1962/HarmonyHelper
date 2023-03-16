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

		public static Note FindClosest(this List<Note> list, Note lastNote, DirectionEnum direction)
		{
			Note result = null;
			list = list.OrderBy(x => x.RawValue).ToList();
			if (DirectionEnum.Ascending == direction)
			{
				result = list.Where(x => x.RawValue > lastNote.RawValue).FirstOrDefault();
			}
			else
			{
				result = list.Where(x => x.RawValue < lastNote.RawValue).LastOrDefault();
			}
			return result;
		}

		public static Note FindClosest(this ClosestNoteContext ctx)
		{
			Note result;

			if (DirectionEnum.Ascending == (DirectionEnum.Ascending & ctx.Direction))
			{
				result = FindClosest(ctx.Notes, ctx.LastNote, DirectionEnum.Ascending);
			}
			else // (DirectionEnum.Descending == (DirectionEnum.Descending & direction))
			{
				result = FindClosest(ctx.Notes, ctx.LastNote, DirectionEnum.Descending);
			}
			if (null == result)
			{
				ctx.ExceededRangeLimit = true;
			}

			if (DirectionEnum.AllowTemporayReversal == (DirectionEnum.AllowTemporayReversal & ctx.Direction))
			{
				Note option = null;
				if (DirectionEnum.Ascending == (DirectionEnum.Ascending & ctx.Direction))
				{
					option = FindClosest(ctx.Notes, ctx.LastNote, DirectionEnum.Descending);
				}
				else //(DirectionEnum.Descending == (DirectionEnum.Descending & direction))
				{
					option = FindClosest(ctx.Notes, ctx.LastNote, DirectionEnum.Ascending);
				}

				if (null != result && null != option)
				{
					var optionalInterval = option - ctx.LastNote;
					//optionalInterval = (Interval)Math.Min((int)optionalInterval, (int)optionalInterval.GetInversion());

					var currentInterval = result - ctx.LastNote;
					//currentInterval = (Interval)Math.Min((int)currentInterval, (int)currentInterval.GetInversion());

					if (optionalInterval < currentInterval)
					{
						result = option;
						ctx.TemporaryDirectionReversal = true;
						ctx.Direction = ctx.Direction.Reverse();
					}
				}
				//Debug.Assert(null != result);
			}

			// Debug.Assert(null != result);
			return result;
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
