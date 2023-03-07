using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ScaleTests_UseCases
	{
		[TestMethod()]
		public void GetScalesForChordsTest()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7th, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Minor7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Major7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.B, ChordIntervalsEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.E, ChordIntervalsEnum.Dominant7th, KeySignature.AMinor));

			var mappings = new List<ChordFormula2ScalesMap>();
			foreach (var chord in chords)
			{
				var mapping = ChordFormula2ScalesMap.GetScalesFor(chord);
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

			chords.Add(ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7th, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Minor7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Major7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.B, ChordIntervalsEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.E, ChordIntervalsEnum.Dominant7th, KeySignature.AMinor));

			var mappings = new List<ChordFormula2ScalesMap>();
			foreach (var chord in chords)
			{
				var mapping = ChordFormula2ScalesMap.GetScalesFor(chord);
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

			mappings = ChordFormula2ScalesMap.FilterByMostUsed(mappings);
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
				 ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Minor7th, KeySignature.EbMajor),
				 ChordFormulaFactory.Get(NoteName.Db, ChordIntervalsEnum.Dominant7th, KeySignature.GbMajor),
				 ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Minor7th, KeySignature.CMajor)
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

		[Ignore]
		[TestMethod()]
		public void AlteredDominants()
		{
			Assert.Fail("throw new NotImplementedException();");
			var chords = new List<ChordFormula>() {
				 ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Minor7th, KeySignature.EbMajor),
				 ChordFormulaFactory.Get(NoteName.Db, ChordIntervalsEnum.Dominant7th, KeySignature.GbMajor),
				 ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Minor7th, KeySignature.CMajor)
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

			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));

			var mappings = new List<ChordFormula2ScalesMap>();


			var pairs = chords.GetPairs().ToList();

			foreach (var pair in pairs)
			{
				var scales = ChordFormula2ScalesMap.GetCommonScales(pair[0], pair[1]);
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
					ChordFormulaFactory.Get(NoteName.A,
						ChordIntervalsEnum.Minor7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.D,
						ChordIntervalsEnum.Dominant7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.G,
						ChordIntervalsEnum.Major7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.C,
						ChordIntervalsEnum.Major7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.FSharp,
						ChordIntervalsEnum.HalfDiminished,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.B,
						ChordIntervalsEnum.Dominant7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.E,
						ChordIntervalsEnum.Minor7th,
						key);
				chords.Add(chord);

				chord =
					ChordFormulaFactory.Get(NoteName.E,
						ChordIntervalsEnum.Minor7th,
						key);
				chords.Add(chord);

			}

			var mappings = new List<ChordFormula2ScalesMap>();


			var pairs = chords.GetPairs().ToList();

			foreach (var pair in pairs)
			{
				var scales = ChordFormula2ScalesMap.GetCommonScales(pair[0], pair[1]);
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
			chords.Add(ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7th, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Minor7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Major7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.B, ChordIntervalsEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.E, ChordIntervalsEnum.Dominant7th, KeySignature.AMinor));

			var pairs = chords.GetPairs().ToList();

			Debug.WriteLine("=== Sunny ===");
			foreach (var pair in pairs)
			{
				var scales = ChordFormula2ScalesMap.GetCommonScales(pair[0], pair[1]);
				Debug.WriteLine($"{pair[0].ToString()} and {pair[1].ToString()} share these scales:");
				Debug.Indent();
				foreach (var scale in scales)
					Debug.WriteLine(scale.ToString());
				Debug.Unindent();
			}
			new object();
		}

		[TestMethod()]
		public void GetResolutionsFor_Blues_Test()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));

			var chordPairs = chords.GetPairs().ToList();

			foreach (var chordPair in chordPairs)
			{
				var chord1 = chordPair[0];
				var chord2 = chordPair[1];
				Debug.WriteLine($"For chords: {chord1.Name} & {chord2.Name}");
				Debug.Indent();
				var scales = ChordFormula2ScalesMap.GetCommonScales(chord1, chord2);
				var count = scales.Count;
				new object();
				foreach (var scale in scales)
				{
					Debug.WriteLine($"Using the mutually inclusive scale: {scale}");
					Debug.Indent();

					foreach (var note in scale.NoteNames)
					{
						if (chord1.Name == "C7" && note.Name == "A")
							new object();
						//if (chord1.Contains(note))
						{
							var role = chord1.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord1.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
							//sb1.AppendLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
						}
						//if (chord2.Contains(note))
						{
							var role = chord2.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord2.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
							//sb2.AppendLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
						}
					}
					//Debug.WriteLine(sb1.ToString());
					//Debug.WriteLine(sb2.ToString());
					Debug.Unindent();
				}
				Debug.Unindent();

				new object();
			}
			new object();
		}

		[Ignore]// Temporarily de-featured
		[TestMethod()]
		public void GetResolutionsFor_Blues_WithExtensions_Test()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C,	ChordIntervalsEnum.Dominant7th, KeySignature.CMajor));

			var chordPairs = chords.GetPairs().ToList();

			foreach (var chordPair in chordPairs)
			{
				var chord1 = chordPair[0];
				var chord2 = chordPair[1];
				Debug.WriteLine($"For chords: {chord1.Name} & {chord2.Name}");
				Debug.Indent();
				var scales = ChordFormula2ScalesMap.GetCommonScales(chord1, chord2);
				var count = scales.Count;
				new object();
				foreach (var scale in scales)
				{
					Debug.WriteLine($"Using the mutually inclusive scale: {scale}");
					Debug.Indent();

					foreach (var note in scale.NoteNames)
					{
						if (chord1.Name == "C7" && note.Name == "A")
							new object();
						//if (chord1.Contains(note))
						{
							var role = chord1.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord1.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
							//sb1.AppendLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
						}
						//if (chord2.Contains(note))
						{
							var role = chord2.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord2.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
							//sb2.AppendLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
						}
					}
					//Debug.WriteLine(sb1.ToString());
					//Debug.WriteLine(sb2.ToString());
					Debug.Unindent();
				}
				Debug.Unindent();

				new object();
			}
			new object();
		}



		[TestMethod()]
		public void GetResolutionsFor_TheChicken_Test()
		{
			//var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			var key = KeySignature.BbMajor;
			chords.Add(ChordFormulaFactory.Get(NoteName.Bb, ChordIntervalsEnum.Dominant7th, key));
			chords.Add(ChordFormulaFactory.Get(NoteName.Eb, ChordIntervalsEnum.Dominant7th, key));
			chords.Add(ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Dominant7th, key));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7th, key));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, key));
			chords.Add(ChordFormulaFactory.Get(NoteName.Bb, ChordIntervalsEnum.Dominant7th, key));

			var chordPairs = chords.GetPairs().ToList();

			foreach (var chordPair in chordPairs)
			{
				var chord1 = chordPair[0];
				var chord2 = chordPair[1];
				Debug.WriteLine($"For chords: {chord1.Name} & {chord2.Name}");
				Debug.Indent();
				var scales = ChordFormula2ScalesMap.GetCommonScales(chord1, chord2);
				var count = scales.Count;
				new object();
				if (0 == count)
					Debug.WriteLine($"No mutually inclusive scales exist for these chords.");
				foreach (var scale in scales)
				{
					Debug.WriteLine($"Using the mutually inclusive scale: {scale}");
					Debug.Indent();

					foreach (var note in scale.NoteNames)
					{
						if (chord1.Name == "C7" && note.Name == "A")
							new object();
						//if (chord1.Contains(note))
						{
							var role = chord1.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord1.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
							//sb1.AppendLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
						}
						//if (chord2.Contains(note))
						{
							var role = chord2.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord2.Name} is the {role.ToStringEx()}");
							//Debug.WriteLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
							//sb2.AppendLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
						}
					}
					//Debug.WriteLine(sb1.ToString());
					//Debug.WriteLine(sb2.ToString());
					Debug.Unindent();
				}
				Debug.Unindent();

				new object();
			}
			new object();
		}

		[TestMethod()]
		public void GetResolutionsFor_Sunny_Test()
		{
			var chords = new List<ChordFormula>();
			chords.Add(ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7th, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Minor7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Major7th, KeySignature.FMajor));
			chords.Add(ChordFormulaFactory.Get(NoteName.B, ChordIntervalsEnum.HalfDiminished, KeySignature.AMinor));
			chords.Add(ChordFormulaFactory.Get(NoteName.E, ChordIntervalsEnum.Dominant7th, KeySignature.AMinor));

			var chordPairs = chords.GetPairs().ToList();

			foreach (var chordPair in chordPairs)
			{
				var chord1 = chordPair[0];
				var chord2 = chordPair[1];
				Debug.WriteLine($"For chords: {chord1.Name} & {chord2.Name}");
				Debug.Indent();
				var scales = ChordFormula2ScalesMap.GetCommonScales(chord1, chord2);
				var count = scales.Count;
				new object();
				if (0 == count)
					Debug.WriteLine($"No mutually inclusive scales exist for these chords.");
				foreach (var scale in scales)
				{
					Debug.WriteLine($"Using the mutually inclusive scale: {scale}");
					Debug.Indent();

					foreach (var note in scale.NoteNames)
					{
						if (chord1.Contains(note))
						{
							var role = chord1.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord1.Name} is the {role.ToStringEx()}");
							Debug.WriteLine($"{note} to {chord1.Name} is the {role.ToStringEx()}");
						}
						if (chord2.Contains(note))
						{
							var role = chord2.GetRelationship(note);
							Debug.WriteLine($"Note {note}'s relationship to {chord2.Name} is the {role.ToStringEx()}");
							Debug.WriteLine($"{note} to {chord2.Name} is the {role.ToStringEx()}");
						}
					}
					Debug.Unindent();
				}
				Debug.Unindent();

				new object();
			}
			new object();
		}


	}//class

}//ns

