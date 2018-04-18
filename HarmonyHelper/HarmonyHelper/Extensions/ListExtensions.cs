using System;
using System.Collections.Generic;
using System.Linq;

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

		public static bool HasBitmask(this DirectionEnum cte, DirectionEnum value)
		{
			var result = false;

			var bitmask = (int)value;
			var icte = (int)cte;
			var masked = (icte & bitmask);
			if (masked == bitmask)
				result = true;

			return result;
		}

		public static DirectionEnum GetMasked(this DirectionEnum src, DirectionEnum requested)
		{
			var result = DirectionEnum.None;

			var bitmask = (int)requested;
			var iSrc = (int)src;
			var which = (iSrc & bitmask);
			result = (DirectionEnum)which;

			return result;
		}


		public static Note FindClosest(this List<Note> list, Note lastNote, ref DirectionEnum direction)
		{
			Note result;

			if (DirectionEnum.Ascending == direction)
			{
				result = list.Where(x => x > lastNote).FirstOrDefault();
			}
			else if (DirectionEnum.Descending == direction)
			{
				result = list.Where(x => x < lastNote).LastOrDefault();
			}
			else // | DirectionEnum.AllowTemporayReversal
			{
				var ascNote = list.Where(x => x > lastNote).FirstOrDefault();
				var descNote = list.Where(x => x < lastNote).LastOrDefault();

				if (null != ascNote && null != descNote)
				{
					var ascInterval = ascNote - lastNote;
					ascInterval = (IntervalsEnum)Math.Min((int)ascInterval, (int)ascInterval.GetInversion());

					var descInterval = descNote - lastNote;
					descInterval = (IntervalsEnum)Math.Min((int)descInterval, (int)descInterval.GetInversion());

					if (descInterval == ascInterval)
					{
						var dir = direction.GetMasked(DirectionEnum.Ascending | DirectionEnum.Descending);
						if (DirectionEnum.Ascending == dir)
						{
							result = ascNote;
							direction = DirectionEnum.AllowTemporayReversal | DirectionEnum.Ascending;
						}
						else if (DirectionEnum.Descending == dir)
						{
							result = descNote;
							direction = DirectionEnum.AllowTemporayReversal | DirectionEnum.Descending;
						}
						else
						{
							result = null;
						}
					}
					else
					{
						if (descInterval < ascInterval)
						{
							result = descNote;
							direction = DirectionEnum.AllowTemporayReversal |  DirectionEnum.Descending;
						}
						else
						{
							result = ascNote;
							direction = DirectionEnum.AllowTemporayReversal | DirectionEnum.Ascending;
						}
					}
				}
				else
				{
					result = ascNote ?? descNote;
				}
			}

			return result;
		}


	}//class

}//ns
