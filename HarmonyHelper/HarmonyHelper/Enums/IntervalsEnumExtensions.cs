using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{

	public static class IntervalsEnumExtensions
	{
		class IntervalValueComparer : IEqualityComparer<Interval>
		{
			public bool Equals(Interval x, Interval y)
			{
				bool result = false;
				if ((int)x == (int)y)
					result = true;
				return result;

			}

			public int GetHashCode(Interval obj)
			{
				return obj.GetHashCode();
			}
		}

		public static int ToIndex(this Interval ie)
		{
			var result = 0;
			var tmp = ie;
			while (tmp >= Interval.Minor2nd)
			{
				++result;
				int x = (int)tmp >> 1;
				tmp = (Interval)x;
			}
			return result;
		}

		public static Interval GetInversion(this Interval interval)
		{
			Interval result = Interval.None;
			if (Interval.None != interval)
			{
				var comparer = new IntervalValueComparer();
				var list = Enum.GetValues(typeof(Interval)).Cast<Interval>()
					.Where(x => x != Interval.None)
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

		public static string ToStringEx(this ChordToneFunctionEnum e)
		{
			var result = string.Empty;

			switch (e)
			{
				case ChordToneFunctionEnum.None:
					result = Constants.NONE;
					break;
				case ChordToneFunctionEnum.Root:
					result = Constants.ROOT;
					break;
				case ChordToneFunctionEnum.Flat9th:
					result = Constants.FLAT_9TH;
					break;
				case ChordToneFunctionEnum.Ninth:
					result = Constants.NINTH;
					break;
				case ChordToneFunctionEnum.Sharp9th:
					result = Constants.SHARP_9TH;
					break;
				case ChordToneFunctionEnum.Minor3rd:
					result = Constants.MINOR_3RD;
					break;
				case ChordToneFunctionEnum.Major3rd:
					result = Constants.MAJOR_3RD;
					break;
				case ChordToneFunctionEnum.Flat11th:
					result = Constants.FLAT_11TH;
					break;
				case ChordToneFunctionEnum.Eleventh:
					result = Constants.ELEVENTH;
					break;
				case ChordToneFunctionEnum.Augmented11th:
					result = Constants.SHARP_11TH;
					break;
				case ChordToneFunctionEnum.Diminished5th:
					result = Constants.DIMINISHED_5TH;
					break;
				case ChordToneFunctionEnum.Perfect5th:
					result = Constants.PERFECT_5TH;
					break;
				case ChordToneFunctionEnum.Augmented5th:
					result = Constants.AUGMENTED_5TH;
					break;
				case ChordToneFunctionEnum.Flat13th:
					result = Constants.FLAT_13TH;
					break;
				case ChordToneFunctionEnum.Thirteenth:
					result = Constants.THIRTEENTH;
					break;
				case ChordToneFunctionEnum.Minor7th:
					result = Constants.MINOR_7TH;
					break;
				case ChordToneFunctionEnum.Major7th:
					result = Constants.MAJOR_7TH;
					break;
				default: throw new NotSupportedException();

			}

			return result;
		}


		public static Interval GetInterval(ChordTypesEnum cte, int bitmask)
		{
			var result = Interval.None;

			var icte = (int)cte;
			var which = (icte & bitmask);
			result = (Interval)which;

			return result;
		}
		public static Interval GetThirdInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Major3rd | Interval.Minor3rd);
			var result = GetInterval(cte, mask);
			return result;
		}
		public static Interval GetFifthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Diminished5th
				| Interval.Perfect5th
				| Interval.Augmented5th);
			var result = GetInterval(cte, mask);
			return result;
		}
		public static Interval GetSeventhInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Minor7th
				| Interval.Major7th);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static Interval GetNinthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Major2nd
				| Interval.Minor2nd
				| Interval.Minor3rd);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static Interval GetEleventhInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Perfect4th
				| Interval.Augmented4th);
			var result = GetInterval(cte, mask);
			return result;
		}

		public static Interval GetThirteenthInterval(this ChordTypesEnum cte)
		{
			var mask = (int)(Interval.Minor6th
				| Interval.Major6th);
			var result = GetInterval(cte, mask);
			return result;
		}

	}//class

}//ns
