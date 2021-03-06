﻿using System.Collections.Generic;
using System.Linq;
using static Eric.Morrison.Harmony.Chords.Chord;
//using static Eric.Morrison.Harmony.Chord;

namespace Eric.Morrison.Harmony
{
	static public partial class ListExtensions
	{
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

		public static T NextOrFirst<T>(this List<T> list, ref int currentNdx) where T : class
		{
			T result = null;
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

		public static Note FindClosest(this List<Note> list, Note lastNote, DirectionEnum direction)
		{
			Note result;

			if (DirectionEnum.Ascending == direction)
			{
				result = list.Where(x => x > lastNote).FirstOrDefault();
			}
			else
			{
				result = list.Where(x => x < lastNote).LastOrDefault();
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


	}//class

}//ns
