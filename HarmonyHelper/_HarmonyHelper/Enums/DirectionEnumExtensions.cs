using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{

	public static class DirectionEnumExtensions
	{
		static public DirectionEnum Reverse(this DirectionEnum direction)
		{
			var result = DirectionEnum.None;
			var allowReversal = false;
			if (DirectionEnum.AllowTemporayReversal == (direction & DirectionEnum.AllowTemporayReversal))
			{
				allowReversal = true;
			}
			if (DirectionEnum.Descending == (direction & DirectionEnum.Descending))
			{
				result = DirectionEnum.Ascending;
			}
			if (DirectionEnum.Ascending == (direction & DirectionEnum.Ascending))
			{
				result = DirectionEnum.Descending;
			}
			if (allowReversal)
			{
				result |= DirectionEnum.AllowTemporayReversal;
			}
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


	}//class
}//ns
