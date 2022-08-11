﻿using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony.Chords
{
	public class ChordFunctionalEqualityComparer : IEqualityComparer<Chord>
	{
		public bool Equals(Chord x, Chord y)
		{
			var comparer = new ChordFormulaFunctionalEqualityComparer();
			var result = comparer.Equals(x.Formula, y.Formula);	
			return result;
		}

		public int GetHashCode(Chord obj)
		{
			var comparer = new ChordFormulaFunctionalEqualityComparer();
			var result = comparer.GetHashCode(obj.Formula);	
			return (int)result;
		}
	}
	public class ChordFormulaFunctionalEqualityComparer : IEqualityComparer<ChordFormula>
	{
		public bool Equals(ChordFormula x, ChordFormula y)
		{//Don't compare keys, due to BorrowedChordHarmonicAnalysisRule dependence.
			var result = false;

			if (x.Root == y.Root)
			{
				if (x.IsDiminished && y.IsDiminished)
					result = true;
				else if (!result && x.IsDominant && y.IsDominant)
					result = true;
#warning This is going to match I, IV and V chords in a Major Scale.
				else if (!result && x.IsMajor && y.IsMajor)
				{
					result = true;
				}
				else if (!result && x.IsMinor && y.IsMinor)
					result = true;
			}
			return result;
		}

		public int GetHashCode(ChordFormula obj)
		{
			throw new NotImplementedException();
		}
	}
}
