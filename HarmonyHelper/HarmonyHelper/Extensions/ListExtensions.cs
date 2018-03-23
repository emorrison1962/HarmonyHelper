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


	}//class

}//ns
