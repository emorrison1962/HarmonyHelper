using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ScaleTests
	{
		[TestMethod()]
		public void GetScalesForChordsTest()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.A, ChordTypesEnum.Minor7th, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Minor7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Major7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.B, ChordTypesEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.E, ChordTypesEnum.Dominant7th, KeySignature.AMinor));

			var mappings = new List<ChordFormulaScalesMapping>();
			foreach (var chord in chords)
			{
				var mapping = ChordFormulaScalesMapping.GetScalesFor(chord);
				mappings.Add(mapping);
			}


			Debug.WriteLine("SUNNY: For these chords, these scales contain these chords, verbatim.");
			foreach (var mapping in mappings)
			{
				Debug.WriteLine(mapping.ChordFormula.Name);
				Debug.Indent();
				foreach (var scale in mapping.ScaleFormulas)
				{
					Debug.WriteLine(scale.ToString());
				}
				Debug.Unindent();
			}

			new object();
		}

		[TestMethod()]
		public void GetMinimalScalesForChords_Test()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.A, ChordTypesEnum.Minor7th, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Minor7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Major7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.B, ChordTypesEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.E, ChordTypesEnum.Dominant7th, KeySignature.AMinor));

			var mappings = new List<ChordFormulaScalesMapping>();
			foreach (var chord in chords)
			{
				var mapping = ChordFormulaScalesMapping.GetScalesFor(chord);
				mappings.Add(mapping);
			}


			//Debug.WriteLine("SUNNY: For these chords, these scales contain these chords, verbatim.");
			//foreach (var mapping in mappings)
			//{
			//	Debug.WriteLine(mapping.ChordFormula.Name);
			//	Debug.Indent();
			//	foreach (var scale in mapping.ScaleFormulas)
			//	{
			//		Debug.WriteLine(scale.ToString());
			//	}
			//	Debug.Unindent();
			//}

			mappings = ChordFormulaScalesMapping.FilterByMostUsed(mappings);
			Debug.WriteLine("");
			Debug.WriteLine("SUNNY: For these chords, these scales the most common amongst the chords.");
			foreach (var mapping in mappings)
			{
				Debug.WriteLine(mapping.ChordFormula.Name);
				Debug.Indent();
				foreach (var scale in mapping.ScaleFormulas)
				{
					Debug.WriteLine(scale.ToString());
				}
				Debug.Unindent();
			}

			new object();
		}


		[TestMethod()]
		public void CantaloupeIslandTest()
		{
			var chords = new List<ChordFormula>() {
				 new ChordFormula(NoteName.F, ChordTypesEnum.Minor7th, KeySignature.EbMajor),
				 new ChordFormula(NoteName.Db, ChordTypesEnum.Dominant7th, KeySignature.GbMajor),
				 new ChordFormula(NoteName.D, ChordTypesEnum.Minor7th, KeySignature.CMajor)
			};

			var catalog = new ScaleFormulaCatalog();
			foreach (var chord in chords)
			{
				Debug.WriteLine("Scales containing the chord tones from: " + chord.Name.ToString());
				Debug.Indent();

				var scales = catalog.GetScalesContaining(chord);
				foreach (var scale in scales)
				{
					//Debug.Write(scale.Name.ToString());

					var copy = new List<NoteName>(scale.NoteNames);
					copy.Sort(new NoteNameAlphaComparer());

					Debug.Write(scale.ToString());
					Debug.WriteLine("");
				}
				Debug.Unindent();
			}
			new object();
		}

		[TestMethod()]
		public void AlteredDominants()
		{
			Assert.Fail("throw new NotImplementedException();");
			var chords = new List<ChordFormula>() {
				 new ChordFormula(NoteName.F, ChordTypesEnum.Minor7th, KeySignature.EbMajor),
				 new ChordFormula(NoteName.Db, ChordTypesEnum.Dominant7th, KeySignature.GbMajor),
				 new ChordFormula(NoteName.D, ChordTypesEnum.Minor7th, KeySignature.CMajor)
			};

			var catalog = new ScaleFormulaCatalog();
			foreach (var chord in chords)
			{
				Debug.WriteLine("Scales containing the chord tones from: " + chord.Name.ToString());
				Debug.Indent();

				var scales = catalog.GetScalesContaining(chord);
				foreach (var scale in scales)
				{
					//Debug.Write(scale.Name.ToString());

					var copy = new List<NoteName>(scale.NoteNames);
					copy.Sort(new NoteNameAlphaComparer());

					Debug.Write(scale.ToString());
					Debug.WriteLine("");
				}
				Debug.Unindent();
			}
			new object();
		}


		[TestMethod()]
		public void GetCommonScalesFor_BluesTest()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Dominant7th, KeySignature.CMajor));

			var mappings = new List<ChordFormulaScalesMapping>();


			var pairs = chords.GetPairs().ToList();

			foreach (var pair in pairs)
			{
				var scales = ChordFormulaScalesMapping.GetCommonScales(pair[0], pair[1]);
				new object();
			}
			new object();
		}


		[TestMethod()]
		public void GetCommonScalesFor_AutumnLeaves_Test()
		{
			//var key = KeySignature.AMinor;
			var key = KeySignature.GMajor;
			var chords = new List<ChordFormula>();
			{
				var chord =
					new ChordFormula(NoteName.A,
						ChordTypesEnum.Minor7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.D,
						ChordTypesEnum.Dominant7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.G,
						ChordTypesEnum.Major7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.C,
						ChordTypesEnum.Major7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.FSharp,
						ChordTypesEnum.HalfDiminished,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.B,
						ChordTypesEnum.Dominant7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.E,
						ChordTypesEnum.Minor7th,
						key);
				chords.Add(chord);

				chord =
					new ChordFormula(NoteName.E,
						ChordTypesEnum.Minor7th,
						key);
				chords.Add(chord);

			}

			var mappings = new List<ChordFormulaScalesMapping>();


			var pairs = chords.GetPairs().ToList();

			foreach (var pair in pairs)
			{
				var scales = ChordFormulaScalesMapping.GetCommonScales(pair[0], pair[1]);
				Debug.WriteLine($"{pair[0].ToString()} and {pair[1].ToString()} share these scales:");
				Debug.Indent();
				foreach (var scale in scales)
					Debug.WriteLine(scale.ToString());
				Debug.Unindent();
			}
			new object();
		}

		[TestMethod()]
		public void GetCommonScalesFor_Sunny_Test()
		{
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.A, ChordTypesEnum.Minor7th, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Minor7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Major7th, KeySignature.FMajor));
			chords.Add(new ChordFormula(NoteName.B, ChordTypesEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(new ChordFormula(NoteName.E, ChordTypesEnum.Dominant7th, KeySignature.AMinor));

			var pairs = chords.GetPairs().ToList();

			Debug.WriteLine("=== Sunny ===");
			foreach (var pair in pairs)
			{
				var scales = ChordFormulaScalesMapping.GetCommonScales(pair[0], pair[1]);
				Debug.WriteLine($"{pair[0].ToString()} and {pair[1].ToString()} share these scales:");
				Debug.Indent();
				foreach (var scale in scales)
					Debug.WriteLine(scale.ToString());
				Debug.Unindent();
			}
			new object();
		}

		[TestMethod()]
		public void GetResolutionsFor_BluesTest()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.CMajor));

			var chordPairs = chords.GetPairs().ToList();
#warning ******************************************
#warning ****** resume work ***********************
#warning ******************************************

			foreach (var chordPair in chordPairs)
			{
				var chord1 = chordPair[0];
				var chord2 = chordPair[1];
				Debug.WriteLine($"For chords: {chord1.Name} & {chord2.Name}");
				Debug.Indent();
				var scales = ChordFormulaScalesMapping.GetCommonScales(chord1, chord2);
				foreach (var scale in scales)
				{
					foreach (var note in scale.NoteNames)
					{
						if (chord1.Contains(note))
						{
							var role = chord1.GetRelationship(note);
							Debug.WriteLine($"{chord1.Name}: note {note}'s relationship is the {role}");
						}
						if (chord1.Contains(note))
						{
							var role = chord2.GetRelationship(note);
							Debug.WriteLine($"{chord2.Name}: note {note}'s relationship is the {role}");
						}
					}
				}
				Debug.Unindent();

				new object();
			}
			new object();
		}

	}//class

}//ns

