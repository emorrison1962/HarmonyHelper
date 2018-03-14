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

		class ChordFormulaScalesMapping
		{
			public ChordFormula ChordFormula { get; set; }
			public List<ScaleFormulaBase> ScaleFormulas { get; set; } = new List<ScaleFormulaBase>();

			public ChordFormulaScalesMapping(ChordFormula formula)
			{
				if (null == formula)
					throw new ArgumentNullException();
				this.ChordFormula = formula;
			}
		}

		[TestMethod()]
		public void GetScalesForChordTest()
		{
#warning *** THIS IS THE LOGIC!!! ***

#warning *** "TODO" ***

			//var chord = ChordFormula.Bb7;
			var chord = new ChordFormula(NoteName.Bb, ChordTypesEnum.Minor7th, KeySignature.EbMajor);
			var mapping = new ChordFormulaScalesMapping(chord);

			Debug.WriteLine("Scales containing the chord tones from: " + chord.Name.ToString());
			Debug.Indent();

			var reported = new List<List<NoteName>>();

			var catalog = new ScaleFormulaCatalog();
			var formulas = catalog.Formulas.OrderBy(x => x.Name).ToList();
			foreach (var scale in formulas)
			{
				if (scale.Name == "B♭ Dorian")
					new object();

				var hasChord = scale.Contains(chord.NoteNames);
				if (hasChord)
				{
					new object();
				}

				if (hasChord) //implies implicit IEnumerable<NoteName> conversion operator!!!
				{
					//Debug.Write(scale.Name.ToString());

					var copy = new List<NoteName>(scale.NoteNames);
					copy.Sort(new NoteNameAlphaComparer());

#warning *** Okay, got rid of redundant enharmonic equivelents. But now I need to select WHICH enharmonic equivelent I want to use. ***

					if (!reported.Contains(copy, new NoteNameListValueComparer()))
					//if (true)
					{
						mapping.ScaleFormulas.Add(scale);

						Debug.Write(string.Format("{0} ", scale.Key.NoteName));
						Debug.Write(scale.ToString());
						//Debug.Write(" contains: ");
						//Debug.Write(Bb7.Name.ToString());
						Debug.WriteLine("");
					}
					else
					{
					}

				}
			}
			Debug.Unindent();

			new object();

#if false
Scales containing the chord tones from: B♭Minor7th
Scales containing the chord tones from: B♭Minor7th
	C Phrygian: C,D♭,E♭,F,G,A♭,B♭
	C Locrian: C,D♭,E♭,F,G♭,A♭,B♭
	G DiminishedHalfWholeFormula: G,A♭,B♭,B,D♭,D,E,F
	B Lydian: B,C♯,D♯,F,F♯,G♯,A♯
	F HarmonicMinorFormula: F,G,A♭,B♭,C,D♭,E
	B♭ PentatonicMinorFormula: B♭,D♭,E♭,F,A♭



#endif

		}


		[TestMethod()]
		public void GetScalesForChordsTest()
		{
			var key = KeySignature.AMinor;
			var chords = new List<ChordFormula>();

			chords.Add(new ChordFormula(NoteName.A, ChordTypesEnum.Minor7th, key));
			chords.Add(new ChordFormula(NoteName.G, ChordTypesEnum.Minor7th, key));
			chords.Add(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, key));
			chords.Add(new ChordFormula(NoteName.F, ChordTypesEnum.Major7th, key));
			chords.Add(new ChordFormula(NoteName.B, ChordTypesEnum.HalfDiminished, key));
			chords.Add(new ChordFormula(NoteName.E, ChordTypesEnum.Dominant7th, key));

			var mappings = new List<ChordFormulaScalesMapping>();
			foreach (var chord in chords)
			{
				var mapping = this.GetScalesFor(chord);
				mappings.Add(mapping);
			}

			var grouped = mappings.GroupBy(x => x.ScaleFormulas.Select(s => s.Name));
			foreach (var group in grouped)
			{
				var s = group.ToString();
				new object();
			}


			var seq = mappings.Select(m => m).Select(m => m.ScaleFormulas.Select(x => x)
									.GroupBy(s => s)
									.OrderByDescending(gp => gp.Count())
									.Take(5)
									.Select(g => new { chord = m.ChordFormula, scales = g.Key })).ToList();
			foreach (var g in seq)
			{
				//var l = g..SelectMany(i => i).ToList();
				new object();

			}

			//var seq = (from m in mappings
			//		   from scale in m.ScaleFormulas
			//		   select new { ChordFormula = m.ChordFormula, ScaleFormula = scale });

			foreach (var mapping in mappings)
			{
				Debug.WriteLine(mapping.ChordFormula.Name);
				Debug.Indent();
				foreach (var sm in mapping.ScaleFormulas)
				{
					Debug.WriteLine(sm.Name);
				}
				Debug.Unindent();
			}
			new object();
		}


		ChordFormulaScalesMapping GetScalesFor(ChordFormula chord)
		{
#warning *** THIS IS THE LOGIC!!! ***

#warning *** "TODO" ***

			var mapping = new ChordFormulaScalesMapping(chord);

			var catalog = new ScaleFormulaCatalog();
			var formulas = catalog.Formulas.OrderBy(x => x.Name).ToList();
			//var reported = new List<List<NoteName>>();
			foreach (var scale in formulas)
			{
				var hasChord = scale.Contains(chord.NoteNames);
				if (hasChord)
				{
					new object();
				}

				if (hasChord) //implies implicit IEnumerable<NoteName> conversion operator!!!
				{
					var scaleNotes = new List<NoteName>(scale.NoteNames);
					scaleNotes.Sort(new NoteNameAlphaComparer());

#warning *** Okay, got rid of redundant enharmonic equivelents. But now I need to select WHICH enharmonic equivelent I want to use. ***

					//if (!reported.Contains(scaleNotes, new NoteNameListValueComparer()))
					{
						//reported.Add(scaleNotes);
						mapping.ScaleFormulas.Add(scale);
					}

				}
			}
			return mapping;
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
			throw new NotImplementedException();
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


	}//class
}//ns