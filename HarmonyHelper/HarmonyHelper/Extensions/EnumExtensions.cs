using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{

	public static class ChordTypesEnumExtensions
	{
		public static string ToStringEx(this ChordType cte)
		{
			var result = string.Empty;
			result = cte.Name;
			//switch (cte)
			//{
			//	case ChordType.None:
			//		result = "no chord";
			//		break;
			//	case ChordType.Major:
			//		break;
			//	case ChordType.Minor:
			//		result = "m";
			//		break;
			//	case ChordType.Augmented:
			//		result = "+";
			//		break;
			//	case ChordType.Diminished:
			//		result = "dim";
			//		break;

			//	case ChordType.Major7th:
			//		result = "Maj7";
			//		break;
			//	case ChordType.Minor7th:
			//		result = "m7";
			//		break;
			//	case ChordType.Dominant7th:
			//		result = "7";
			//		break;
			//	case ChordType.HalfDiminished:
			//		result = "m7b5";
			//		break;
			//	case ChordType.Diminished7:
			//		result = "dim7";
			//		break;
			//	default: throw new NotSupportedException();

			//}

			return result;
		}

	}

	public static class EnumExtensions
	{
		[Obsolete("This is SLOW.")]
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
