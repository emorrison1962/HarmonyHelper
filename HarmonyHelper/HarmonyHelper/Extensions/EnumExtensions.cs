using System;

namespace Eric.Morrison.Harmony
{

	public static class IntervalsEnumExtensions
	{

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

		public static IntervalsEnum GetThirdInterval(this ChordTypesEnum cte)
		{
			var result = IntervalsEnum.None;

			var icte = (int)cte;
			var mask = (int)(IntervalsEnum.Major3rd | IntervalsEnum.Minor3rd);

			var which = (icte & mask);
			result = (IntervalsEnum)which;

			return result;
		}
		public static IntervalsEnum GetFifthInterval(this ChordTypesEnum cte)
		{
			var result = IntervalsEnum.None;
			var icte = (int)cte;
			var mask = (int)(IntervalsEnum.Diminished5th
				| IntervalsEnum.Perfect5th
				| IntervalsEnum.Augmented5th);

			var which = (icte & mask);
			result = (IntervalsEnum)which;
			return result;
		}
		public static IntervalsEnum GetSeventhInterval(this ChordTypesEnum cte)
		{
			var result = IntervalsEnum.None;
			var icte = (int)cte;
			var mask = (int)(IntervalsEnum.Minor7th
				| IntervalsEnum.Major7th);
			var which = (icte & mask);
			result = (IntervalsEnum)which;
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
	}

	public static class ChordTypesEnumExtensions
	{
		public static string ToStringEx(this ChordTypesEnum cte)
		{
			var result = string.Empty;

			switch (cte)
			{
				case ChordTypesEnum.Major:
					break;
				case ChordTypesEnum.Minor:
					result = "m";
					break;
				case ChordTypesEnum.Augmented:
					result = "+";
					break;
				case ChordTypesEnum.Diminished:
					result = "dim";
					break;

				case ChordTypesEnum.Major7th:
					result = "Maj7";
					break;
				case ChordTypesEnum.Minor7th:
					result = "m7";
					break;
				case ChordTypesEnum.Dominant7th:
					result = "7";
					break;
				case ChordTypesEnum.HalfDiminished:
					result = "m7b5";
					break;
				case ChordTypesEnum.Diminished7:
					result = "dim7";
					break;
				default: throw new NotSupportedException();

			}

			return result;
		}

	}

	public static class EnumExtensions
	{
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

		public static T Next<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

			T[] Arr = (T[])Enum.GetValues(src.GetType());
			int j = Array.IndexOf<T>(Arr, src) + 1;
			return (Arr.Length == j) ? Arr[0] : Arr[j];
		}
	}
}
