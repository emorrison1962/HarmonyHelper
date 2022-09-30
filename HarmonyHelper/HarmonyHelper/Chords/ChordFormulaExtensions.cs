﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
	public static class ChordFormulaExtensions
	{
		static public bool IsDominantOfKey(this ChordFormula src, KeySignature key)
		{
			var result = false;
			if (src.IsDominant)
			{
				if (Interval.Perfect5th == src.Root - key.NoteName)
				{
					result = true;
				}
			}
			return result;
		}

		static public bool IsTwoFiveOne(this IEnumerable<ChordFormula> triplet, KeySignature key)
		{
			var result = false;
			const int EXPECTED_TRIPLET_ELEMENT_COUNT = 3;
			if (EXPECTED_TRIPLET_ELEMENT_COUNT != triplet.Count())
				throw new ArgumentOutOfRangeException();

			if (key.NoteName == triplet.ElementAt(2).Root)
			{
				var chord0 = triplet.ElementAt(0);
				var chord1 = triplet.ElementAt(1);
				var chord2 = triplet.ElementAt(2);
				if (key.IsMinor)
				{
#if DEBUG
					var interval = chord0.Root - key.NoteName;
#endif
					if ((chord0.IsDiminished && Interval.Major2nd == chord0.Root - key.NoteName)
						&& (chord1.IsDominant && Interval.Perfect5th == chord1.Root - key.NoteName)
						&& (chord2.IsMinor && chord2.Root == key.NoteName))
					{
						result = true;
					}
				}
				else
				{
#if DEBUG
					var interval = chord0.Root - key.NoteName;
#endif
					if ((chord0.IsMinor && Interval.Major2nd == chord0.Root - key.NoteName)
						&& (chord1.IsDominant && Interval.Perfect5th == chord1.Root - key.NoteName)
						&& (chord2.IsMajor && chord2.Root == key.NoteName))
					{
						result = true;
					}
				}
			}

			return result;
		}

		[Obsolete("", true)]
		static public bool IsTwoFive(this IEnumerable<ChordFormula> pair, KeySignature key)
		{
			var result = false;
			const int EXPECTED_ELEMENT_COUNT = 2;
			if (EXPECTED_ELEMENT_COUNT != pair.Count())
				throw new ArgumentOutOfRangeException();

			if (key.NoteName == pair.ElementAt(0).Root - Interval.Major2nd)
			{
				var chord0 = pair.ElementAt(0);
				var chord1 = pair.ElementAt(1);
				if (key.IsMinor)
				{
#if DEBUG
					var interval = chord0.Root - key.NoteName;
#endif
					if ((chord0.IsHalfDiminished && Interval.Major2nd == chord0.Root - key.NoteName)
						&& (chord1.IsDominant && Interval.Perfect5th == chord1.Root - key.NoteName))
					{
						result = true;
					}
				}
				else
				{
#if DEBUG
					var interval = chord0.Root - key.NoteName;
#endif
					if ((chord0.IsMinor && Interval.Major2nd == chord0.Root - key.NoteName)
						&& (chord1.IsDominant && Interval.Perfect5th == chord1.Root - key.NoteName))
					{
						result = true;
					}
				}
			}

			return result;
		}

        static public bool IsTwoFive(this IEnumerable<ChordFormula> pair, out KeySignature key)
        {
            var result = false;
			key = null;

            const int EXPECTED_ELEMENT_COUNT = 2;
            if (EXPECTED_ELEMENT_COUNT != pair.Count())
                throw new ArgumentOutOfRangeException();

            var chord0 = pair.ElementAt(0);
            var chord1 = pair.ElementAt(1);
			if (chord1.IsDominant)
			{
				if (chord0.IsMinor || chord0.IsHalfDiminished)
				{
					if (chord0.Root - chord1.Root == Interval.Perfect5th)
					{
						var isMinor = false;
						if (chord0.IsHalfDiminished)
                        {
                            isMinor = true;
                        }
                        
						var knn = chord0.Root - Interval.Major2nd;
						key = KeySignature.Catalog
							.FirstOrDefault(x => x.NoteName == knn 
								&& x.IsMinor == isMinor);
                        result = true;
					}
				}
			}
            return result;
        }
    }
}
