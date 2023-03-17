using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{

	public static class DirectionEnumExtensions
	{
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
