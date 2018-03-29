using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public static class IntervalsEnumExtensions
	{
		class IntervalsEnumValueComparer : IEqualityComparer<IntervalsEnum>
		{
			public bool Equals(IntervalsEnum x, IntervalsEnum y)
			{
				bool result = false;
				if ((int)x == (int)y)
					result = true;
				return result;

			}

			public int GetHashCode(IntervalsEnum obj)
			{
				return obj.GetHashCode();
			}
		}

		public static int ToIndex(this IntervalsEnum ie)
		{
			var result = 0;
			var tmp = ie;
			while (tmp >= IntervalsEnum.Minor2nd)
			{
				++result;
				int x = (int)tmp >> 1;
				tmp = (IntervalsEnum)x;
			}
			return result;
		}

		public static IntervalsEnum GetInversion(this IntervalsEnum interval)
		{
			IntervalsEnum result = IntervalsEnum.None;
			if (IntervalsEnum.None != interval)
			{
				var comparer = new IntervalsEnumValueComparer();
				var list = Enum.GetValues(typeof(IntervalsEnum)).Cast<IntervalsEnum>()
					.Where(x => x != IntervalsEnum.None)
					.Distinct(comparer)
					.OrderBy(x => x)
					.ToList();

				//list.ForEach(x => Debug.WriteLine($"{x}: {(int)x}"));

				var ndx = list.IndexOf(interval);
				var inversionNdx = (list.Count - 1) - ndx;
				result = list[inversionNdx];
			}

			return result;
		}


		public static string ToStringEx(this IntervalsEnum e)
		{
			const string NONE = "none";
			const string MINOR_2ND = "m2";
			const string MAJOR_2ND = "M2";
			const string MINOR_3RD = "m3";
			const string MAJOR_3RD = "M3";
			const string DIMINISHED_4TH = "dim4";
			const string PERFECT_4TH = "P4";
			const string AUGMENTED_4TH = "+4";
			const string DIMINISHED_5TH = "dim5";
			const string PERFECT_5TH = "P5";
			const string AUGMENTED_5TH = "+5";
			const string MINOR_6TH = "m6";
			const string MAJOR_6TH = "M6";
			const string MINOR_7TH = "m7";
			const string MAJOR_7TH = "M7";

			var result = string.Empty;

			switch (e)
			{
				case IntervalsEnum.None:
					result = NONE;
					break;
				case IntervalsEnum.Minor2nd:
					result = MINOR_2ND;
					break;
				case IntervalsEnum.Major2nd:
					result = MAJOR_2ND;
					break;
				case IntervalsEnum.Minor3rd:
					result = MINOR_3RD;
					break;
				case IntervalsEnum.Major3rd:
					result = MAJOR_3RD;
					break;
				//case IntervalsEnum.Diminished4th:
				//	result = DIMINISHED_4TH;
				//	break;
				case IntervalsEnum.Perfect4th:
					result = PERFECT_4TH;
					break;
				//case IntervalsEnum.Augmented4th:
				//	result = AUGMENTED_4TH;
				//	break;
				case IntervalsEnum.Diminished5th:
					result = DIMINISHED_5TH;
					break;
				case IntervalsEnum.Perfect5th:
					result = PERFECT_5TH;
					break;
				case IntervalsEnum.Augmented5th:
					result = AUGMENTED_5TH;
					break;
				//case IntervalsEnum.Minor6th:
				//	result = MINOR_6TH;
				//	break;
				case IntervalsEnum.Major6th:
					result = MAJOR_6TH;
					break;
				case IntervalsEnum.Minor7th:
					result = MINOR_7TH;
					break;
				case IntervalsEnum.Major7th:
					result = MAJOR_7TH;
					break;
				default: throw new NotSupportedException();

			}

			return result;
		}

		public static IntervalsEnum Invert(this IntervalsEnum interval)
		{
			var result = IntervalsEnum.None;
			switch (interval)
			{
				case IntervalsEnum.Minor2nd:
					result = IntervalsEnum.Major7th;
					break;
				case IntervalsEnum.Major2nd:
					result = IntervalsEnum.Minor7th;
					break;
				case IntervalsEnum.Minor3rd:
					result = IntervalsEnum.Major6th;
					break;
				case IntervalsEnum.Major3rd:
					result = IntervalsEnum.Minor6th;
					break;
				case IntervalsEnum.Perfect4th:
					result = IntervalsEnum.Perfect5th;
					break;
				case IntervalsEnum.Augmented4th:
					result = IntervalsEnum.Diminished5th;
					break;
				case IntervalsEnum.Perfect5th:
					result = IntervalsEnum.Perfect4th;
					break;
				//case IntervalsEnum.Augmented5th:
				//    result = IntervalsEnum.Diminished4th;
				//break;
				case IntervalsEnum.Minor6th:
					result = IntervalsEnum.Major3rd;
					break;
				case IntervalsEnum.Major6th:
					result = IntervalsEnum.Minor3rd;
					break;
				case IntervalsEnum.Minor7th:
					result = IntervalsEnum.Major2nd;
					break;
				case IntervalsEnum.Major7th:
					result = IntervalsEnum.Minor2nd;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return result;
		}

		public static IntervalsEnum GetInterval(ChordTypesEnum cte, int bitmask)
		{
			var result = IntervalsEnum.None;

			var icte = (int)cte;
			var which = (icte & bitmask);
			result = (IntervalsEnum)which;

			return result;
		}
		public static IntervalsEnum GetThirdInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Major3rd | IntervalsEnum.Minor3rd);
			var result = GetInterval(cte, mask);
			return result;
		}
		public static IntervalsEnum GetFifthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Diminished5th
				| IntervalsEnum.Perfect5th
				| IntervalsEnum.Augmented5th);
			var result = GetInterval(cte, mask);
			return result;
		}
		public static IntervalsEnum GetSeventhInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Minor7th
				| IntervalsEnum.Major7th);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static IntervalsEnum GetNinthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Major2nd
				| IntervalsEnum.Minor2nd
				| IntervalsEnum.Minor3rd);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static IntervalsEnum GetEleventhInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Perfect4th
				| IntervalsEnum.Augmented4th);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static IntervalsEnum GetThirteenthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(IntervalsEnum.Minor6th
				| IntervalsEnum.Major6th);
			var result = GetInterval(cte, mask);
			return result;
		}

	}//class

}//ns
