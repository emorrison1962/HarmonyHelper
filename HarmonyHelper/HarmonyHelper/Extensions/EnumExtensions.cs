using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{

	public static class ChordTypesEnumExtensions
	{
		public static string ToStringEx(this ChordTypesEnum cte)
		{
			var result = string.Empty;

			switch (cte)
			{
				case ChordTypesEnum.None:
					result = "no chord";
					break;
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
		public static T Next<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

			T[] Arr = (T[])Enum.GetValues(src.GetType());
			int j = Array.IndexOf<T>(Arr, src) + 1;
			return (Arr.Length == j) ? Arr[0] : Arr[j];
		}
	}

	public static class ModeEnumExtensions
	{
		public static string ToStringEx(this ModeEnum src) 
		{
			var str = src.ToString();
			var result = str;
			return str;
		}
	}

}
