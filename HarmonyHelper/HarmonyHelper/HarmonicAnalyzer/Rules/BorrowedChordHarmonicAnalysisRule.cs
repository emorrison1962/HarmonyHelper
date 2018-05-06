using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
	public class BorrowedChordHarmonicAnalysisRule : HarmonicAnalysisRuleBase
	{

		public BorrowedChordHarmonicAnalysisRule()
		{
		}


		public override HarmonicAnalysisResult Analyze(List<Chord> chords)
		{
			this.CreateBorrowedChordGrid(KeySignature.CMajor);

			foreach (var chord in chords)
			{

			}

			return null;
		}

		List<List<ChordFormula>> CreateBorrowedChordGrid(KeySignature inputKey)
		{
			var result = new List<List<ChordFormula>>();
			var scale = new ModeFormula(inputKey, ModeEnum.Ionian);
			var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
				inputKey - Interval.Major2nd,
				inputKey - Interval.Major3rd,
				inputKey - Interval.Perfect4th,
				inputKey - Interval.Perfect5th,
				inputKey - Interval.Major6th,
				inputKey - Interval.Major7th,
			};

			var chordTypes = new List<ChordType>() { //harmonized major scale
				ChordType.Major7th,
				ChordType.Minor7th,
				ChordType.Minor7th,
				ChordType.Major7th,
				ChordType.Dominant7th,
				ChordType.Minor7th,
				ChordType.HalfDiminished
			};

			var chordTypeNdx = 0;
			foreach (var key in keys)
			{
				var modeChords = new List<ChordFormula>();
				for (int scaleDegree = 0 ; scaleDegree < Constants.COUNT_DIATONIC_SCALE_DEGREES ; ++scaleDegree)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					var chordFormula = new ChordFormula(scale.NoteNames[scaleDegree], chordType, key);
					modeChords.Add(chordFormula);
				}
				result.Add(modeChords);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}

			#region debug output
			foreach (var modeChords in result)
			{
				Debug.Write($"{modeChords[0].Key,3}");
				foreach (var cf in modeChords)
				{
					Debug.Write($"| {cf,18} ");
				}
				Debug.WriteLine(" |");
			}
			#endregion

			return result;
		}

	}//class
}//ns