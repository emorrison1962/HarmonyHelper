using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

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

			var grids = new List<Grid>();
			grids.Add(this.CreateMajorBorrowedChordGrid(key));
			grids.Add(this.CreateMelodicMinorBorrowedChordGrid(key));
			grids.Add(this.CreateHarmonicMinorBorrowedChordGrid(key));


			var formulas = chords.Select(x => x).Distinct().ToList();
			var nonDiatonic = key.GetNonDiatonic(formulas).Where(x => !x.IsDominantOfKey(key));
			new object();

			foreach (var formula in nonDiatonic)
			{
				foreach (var grid in grids)
				{
					var rows = grid.Rows.Where(x => x.Formulas.Contains(formula)).ToList(); // get row from grid.
					foreach (var row in rows)
					{
						var message = $"{formula.Name} could be considered a borrowed chord from the parallel {key.NoteName} {row.Mode} mode in {row.Key}.";
						var har = new HarmonicAnalysisResult(this, true, message);
						result.Add(har);
					}
					new object();
				}
			}

			return result;
		}

		class Grid
		{
			public List<GridRow> Rows { get; private set; } = new List<GridRow>();
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
		Grid CreateMajorBorrowedChordGrid(KeySignature inputKey)
		{
			//var result = new List<GridRow>();
			var result = new Grid();

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
				var scale = new MajorModalScaleFormula(key, mode);
				var gridRow = new GridRow(key, mode);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chordFormula = new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key);
					gridRow.Formulas.Add(chordFormula);
				}

				result.Rows.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			//Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
			//foreach (var row in result.Rows)
			//{
			//	Debug.Write($"{row.Key,3}");
			//	Debug.Write($"| {row.Mode.ToString()} ");
			//	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
			//}
			//Debug.WriteLine("");
			#endregion

			return result;
		}

		Grid CreateMelodicMinorBorrowedChordGrid(KeySignature inputKey)
		{
			var result = new Grid();

			var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
				inputKey - Interval.Major2nd,
				inputKey - Interval.Minor3rd,
				inputKey - Interval.Perfect4th,
				inputKey - Interval.Diminished5th,
				inputKey - Interval.Minor6th,
				inputKey - Interval.Minor7th,
			};
			var chordTypes = new List<ChordType>() { //harmonized melodic minor scale
				ChordType.MinorMaj7th,
				ChordType.Minor7th,
				ChordType.Major7Aug5,
				ChordType.Dominant7th,
				ChordType.Dominant7th,
				ChordType.HalfDiminished,
				ChordType.HalfDiminished
			};
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();

			var chordTypeNdx = 0;
			var modeNdx = 0;

			//var scale = new ModeFormula(inputKey, ModeEnum.Ionian);
			foreach (var key in keys)
			{
				var mode = modes[modeNdx++];
				var scale = new MelodicMinorScaleFormula(key);
				var gridRow = new GridRow(key, mode);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chordFormula = new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key);
					gridRow.Formulas.Add(chordFormula);
				}

				result.Rows.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			//Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
			//foreach (var row in result.Rows)
			//{
			//	Debug.Write($"{row.Key,3}");
			//	Debug.Write($"| {row.Mode.ToString()} ");
			//	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
			//}
			//Debug.WriteLine("");
			#endregion

			return result;
		}

		Grid CreateHarmonicMinorBorrowedChordGrid(KeySignature inputKey)
		{
			var result = new Grid();

			var keys = new List<KeySignature> { 
				// These keys represent the transposed key for each row.
				// E.G, 2nd row Cm7 is the Dorian chord from Bb, 4th row CMaj7 is the Lydian chord from key of G.
				inputKey,
				inputKey - Interval.Major2nd,
				inputKey - Interval.Minor3rd,
				inputKey - Interval.Perfect4th,
				inputKey - Interval.Diminished5th,
				inputKey - Interval.Minor6th,
				inputKey - Interval.Minor7th,
			};
			var chordTypes = new List<ChordType>() { //harmonized melodic minor scale
				ChordType.MinorMaj7th,
				ChordType.HalfDiminished,
				ChordType.Major7Aug5,
				ChordType.Minor7th,
				ChordType.Dominant7th,
				ChordType.Major7th,
				ChordType.Diminished7
			};
			var modes = Enum.GetValues(typeof(ModeEnum)).Cast<ModeEnum>().ToList();

			var chordTypeNdx = 0;
			var modeNdx = 0;

			//var scale = new ModeFormula(inputKey, ModeEnum.Ionian);
			foreach (var key in keys)
			{
				var mode = modes[modeNdx++];
				var scale = new MelodicMinorScaleFormula(key);
				var gridRow = new GridRow(key, mode);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chordFormula = new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key);
					gridRow.Formulas.Add(chordFormula);
				}

				result.Rows.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			//Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
			//foreach (var row in result.Rows)
			//{
			//	Debug.Write($"{row.Key,3}");
			//	Debug.Write($"| {row.Mode.ToString()} ");
			//	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
			//}
			//Debug.WriteLine("");
			#endregion

			return result;
		}


	}//class
}//ns