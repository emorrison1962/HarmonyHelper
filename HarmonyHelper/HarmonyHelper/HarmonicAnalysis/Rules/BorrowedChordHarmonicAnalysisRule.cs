using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
		public override string Name { get { return this.GetType().Name; } }

		public BorrowedChordHarmonicAnalysisRule()
		{
		}

		public override List<HarmonicAnalysisResult> Analyze(List<Chord> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();

			var grids = new List<Grid>();
			grids.Add(this.CreateMajorBorrowedChordGrid(key));
			grids.Add(this.CreateMelodicMinorBorrowedChordGrid(key));
			grids.Add(this.CreateHarmonicMinorBorrowedChordGrid(key));


			var formulas = chords.Select(x => x).Distinct().ToList();
			var nonDiatonic = key.GetNonDiatonic(formulas).Where(x => !x.Formula.IsDominantOfKey(key));
			new object();

			var dict = new Dictionary<Chord, List<string>>();

			foreach (var chord in nonDiatonic)
			{
				foreach (var grid in grids)
				{
					var rows = grid.Rows.Where(x => x.Chords.Contains(chord, new ChordFunctionalEqualityComparer())).ToList(); // get row from grid.
					foreach (var row in rows)
					{
						var message = $"• {chord.Name} could be considered a borrowed chord from the parallel {key.NoteName} {row.ModeName} mode in {row.Key}.";
						if (dict.Keys.Contains(chord))
						{
							dict[chord].Add(message); 
						}
						else
						{
							dict.Add(chord, new List<string> { message });
						}
					}
					new object();
				}
			}

			foreach (var chord in chords)
			{
				if (dict.ContainsKey(chord))
				{
					var item = dict.Where(x => x.Key == chord).First();
					var message = string.Join(Environment.NewLine, item.Value);
					var har = new HarmonicAnalysisResult(this, true, message, item.Key);
					result.Add(har);
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
			public string ModeName { get; private set; }
			public List<Chord> Chords { get; private set; } = new List<Chord>();
			public GridRow(KeySignature key, string modeName)
			{
				this.Key = key;
				this.ModeName = modeName;
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
				var gridRow = new GridRow(key, scale.ModeName);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chordFormula = new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key);
					gridRow.Chords.Add(new Chord(chordFormula));
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
			Debug.WriteLine("");
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
				var scale = new MelodicMinorModalScaleFormula(key, mode);
				var gridRow = new GridRow(key, scale.ModeName);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chord = new Chord(new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key));
					gridRow.Chords.Add(chord);
				}

				result.Rows.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			//Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
			//foreach (var row in result.Rows)
			//{
			//	Debug.Write($"{row.Key,3}");
			//	Debug.Write($"| {row.ModeName.ToString()} ");
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
				var scale = new HarmonicMinorModalScaleFormula(key, mode);
				var gridRow = new GridRow(key, scale.ModeName);

				var scaleDegrees = Enum.GetValues(typeof(ScaleDegree)).Cast<ScaleDegree>().ToList();
				foreach (var scaleDegree in scaleDegrees)
				{
					var chordType = chordTypes.NextOrFirst(ref chordTypeNdx);
					//Debug.WriteLine(scale);
					var chord = new Chord(new ChordFormula(scale.NoteNames[(int)scaleDegree], chordType, key));
					gridRow.Chords.Add(chord);
				}

				result.Rows.Add(gridRow);
				chordTypes.NextOrFirst(ref chordTypeNdx); //create an offset
			}


			#region debug output
			//Debug.WriteLine($"===={MethodInfo.GetCurrentMethod().Name}====");
			//foreach (var row in result.Rows)
			//{
			//	Debug.Write($"{row.Key,3}");
			//	Debug.Write($"| {row.ModeName.ToString()} ");
			//	Debug.WriteLine($"| {string.Join(", ", row.Formulas.Select(x => x.Name))}");
			//}
			//Debug.WriteLine("");
			#endregion

			return result;
		}


	}//class
}//ns