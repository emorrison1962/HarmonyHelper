using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class BorrowedChordHarmonicAnalysisRule : HarmonicAnalysisRuleBase
	{
		[Flags]
		enum ScaleDegree
		{
			i = 0, ii, iii, iv, v, vi, vii
		}


		public BorrowedChordHarmonicAnalysisRule()
		{
		}


		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();

			var grid = this.CreateBorrowedChordGrid(key);

			var formulas = chords.Select(x => x).Distinct().ToList();
			var nonDiatonic = key.GetNonDiatonic(formulas);
			new object();

			foreach (var formula in nonDiatonic)
			{
				var rows = grid.Where(x => x.Formulas.Contains(formula)).ToList(); // get row from grid.
				foreach (var row in rows)
				{
					var message = $"{formula} could be considered a borrowed chord from the parallel {key.NoteName} {row.Mode} mode in {row.Key}.";
					var har = new HarmonicAnalysisResult(this, true, message);
					result.Add(har);
				}
				new object();
			}

			return result;
		}

		class GridRow
		{
			public KeySignature Key { get; private set; }
			public ModeEnum Mode { get; private set; }
			public List<ChordFormula> Formulas { get; private set; } = new List<ChordFormula>();
			public GridRow(KeySignature key, ModeEnum mode)
			{
				this.Key = key;
				this.Mode = mode;
			}
		}
		List<GridRow> CreateBorrowedChordGrid(KeySignature inputKey)
		{
			var result = new List<GridRow>();

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
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();

			var chordTypeNdx = 0;
			var modeNdx = 0;

			//var scale = new ModeFormula(inputKey, ModeEnum.Ionian);
			foreach (var key in keys)
			{
				var mode = modes[modeNdx++];
				var scale = new ModeFormula(key, mode);
				var gridRow = new GridRow(key, mode);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chordFormula = new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key);
					gridRow.Formulas.Add(chordFormula);
				}

				result.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			foreach (var row in result)
			{
				Debug.Write($"{row.Key,3}");
				Debug.Write($"| {row.Mode.ToString()} ");
				Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
			}
			#endregion

			return result;
		}

	}//class
}//ns