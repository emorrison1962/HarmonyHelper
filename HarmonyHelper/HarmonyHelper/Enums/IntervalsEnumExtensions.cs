using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{

	[Obsolete("", true)]
	public static class IntervalsEnumExtensions
	{
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

	}//class

}//ns
