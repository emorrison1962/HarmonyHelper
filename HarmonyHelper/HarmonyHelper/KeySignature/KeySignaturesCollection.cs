using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	[Obsolete("***", true)]
	public static class KeySignatureCollection
	{
		#region Properties

		//static LinkedList<KeySignature> LinkedList { get; set; } = new LinkedList<KeySignature>();
		static List<KeySignature> KeySignatures { get; set; } = new List<KeySignature>();

		#endregion

		#region Construction
		static KeySignatureCollection()
		{
			KeySignatures.Add(KeySignature.CMajor);
			KeySignatures.Add(KeySignature.DbMajor);
			KeySignatures.Add(KeySignature.DMajor);
			KeySignatures.Add(KeySignature.EbMajor);
			KeySignatures.Add(KeySignature.EMajor);
			KeySignatures.Add(KeySignature.FMajor);
			KeySignatures.Add(KeySignature.GbMajor);
			KeySignatures.Add(KeySignature.GMajor);
			KeySignatures.Add(KeySignature.AbMajor);
			KeySignatures.Add(KeySignature.AMajor);
			KeySignatures.Add(KeySignature.BbMajor);
			KeySignatures.Add(KeySignature.BMajor);
		}

		#endregion

		//public static KeySignature Get(KeySignature key, IntervalsEnum interval)
		//{
		//	var node = LinkedList.Find(key);
		//	if (null == node)
		//		throw new NotImplementedException();

		//	var ndx = interval.ToIndex();
		//	node = node.Find(ndx);
		//	if (null == node)
		//		throw new NotImplementedException();

		//	var result = node.Value;
		//	return result;
		//}


		public static KeySignature Get(KeySignature key, Interval interval)
		{
			var maxNdx = KeySignatures.Count - 1;
			var currentNdx = KeySignatures.IndexOf(key);
			var intervalNdx = interval.ToIndex();

			var targetNdx = (currentNdx + intervalNdx) % maxNdx;

			var result = KeySignatures[targetNdx];

			return result;
		}

		public static KeySignature Get(KeySignature key, int intervalNdx)
		{
			var maxNdx = KeySignatures.Count - 1;
			var currentNdx = KeySignatures.IndexOf(key);
			var targetNdx = currentNdx + intervalNdx;
			if (targetNdx < 0)
				targetNdx = maxNdx + targetNdx;

			var result = KeySignatures[targetNdx];

			return result;
		}

		public static KeySignature Get(KeySignature key, Interval intervalEnum, DirectionEnum direction)
		{
			var intervalNdx = intervalEnum.ToIndex();
			if (direction == DirectionEnum.Descending)
			{
				intervalNdx *= -1;
			}
			var result = Get(key, (int)intervalNdx);

			return result;
		}


#if false
		public Note Next(DirectionEnum direction = DirectionEnum.Ascending)
		{
			Note result = null;
			var currentNdx = this.Notes.IndexOf(this.CurrentNote);

			if (DirectionEnum.Ascending == direction)
			{
				var nextNdx = 0;
				if (currentNdx < this.MaxIndex)
				{
					nextNdx = currentNdx + 1;
				}
				result = this.Notes[nextNdx];
			}
			else
			{
				var nextNdx = this.MaxIndex;
				if (currentNdx > 0)
				{
					nextNdx = currentNdx - 1;
				}
				result = this.Notes[nextNdx];
			}

			return result;
		}

#endif

		//public static KeySignature Get(KeySignature ne, IntervalsEnum intervalEnum, DirectionEnum direction)
		//{
		//	var interval = intervalEnum.ToIndex();





		//	if (direction == DirectionEnum.Descending)
		//	{
		//		interval *= -1;
		//	}
		//	var node = LinkedList.Find(ne);
		//	node = node.Find((int)interval);

		//	var result = node.Value;
		//	return result;
		//}

	}//class

}//ns
