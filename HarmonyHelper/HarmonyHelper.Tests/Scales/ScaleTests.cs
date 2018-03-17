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

				var hasChord = scale.Contains(chord);
				if (hasChord)
				{
					new object();
				}

				if (hasChord) //implies implicit IEnumerable<NoteName> conversion operator!!!
				{
					//Debug.Write(scale.Name.ToString());

					var copy = new List<NoteName>(scale.NoteNames);
					copy.Sort(new NoteNameAlphaComparer());

#warning *** Okay, got rid of redundant enharmonic equivalentss. But now I need to select WHICH enharmonic equivalents I want to use. ***

					if (!reported.Contains(copy, new NoteNameListValueEqualityComparer()))
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
				var mapping = this.GetScalesFor(chord);
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

			//var scales = (
			//			from m in mappings
			//			from s in m.ScaleFormulas
			//			select s).ToList();
			//var scaleGroups = scales.GroupBy(s => s).OrderBy(s => s.Count()).ToList();
			//var popularScales = scaleGroups.Distinct().Select(g => g.Key).ToList();
			//var theMostPopularBars = mappings.Select(m => m.ScaleFormulas.Where(b => popularScales.Contains(b)).First()).ToList();


			//var pairings = mappings
			//	.Select(m => new
			//	{
			//		ChordFormula = m.ChordFormula,
			//		ScaleFormula = m.ScaleFormulas
			//		.Where(s => popularScales.Contains(s)).First()
			//	}).ToList();


			//foreach (var anon in pairings)
			//{
			//	Debug.WriteLine(anon.ChordFormula.Name);
			//	Debug.Indent();
			//	Debug.WriteLine(anon.ScaleFormula.ToString());
			//	Debug.Unindent();
			//}

			new object();
		}



		ChordFormulaScalesMapping GetScalesFor(ChordFormula chord)
		{
#warning *** THIS IS THE LOGIC!!! ***

			var mapping = new ChordFormulaScalesMapping(chord);
			var catalog = new ScaleFormulaCatalog();
			var formulas = catalog.Formulas.OrderBy(x => x.Name).ToList();

			var matching = formulas.Where(x => x.Contains(chord));
			mapping.ScaleFormulas.AddRange(matching);
			//foreach (var scale in formulas)
			//{
			//	var hasChord = scale.Contains(chord);
			//	if (hasChord)
			//	{
			//		mapping.ScaleFormulas.Add(scale);
			//	}
			//}

			var enharmonicEquivalents = mapping.ScaleFormulas.GetEnharmonicEquivalents();

			var result = new ChordFormulaScalesMapping(chord);
			foreach (var list in enharmonicEquivalents.Equivalents.Values)
			{
#warning **** 031618: Chord-centric or key-centric? ****
				var scale = list.Where(x => x.Root == chord.Root).FirstOrDefault();
				//var scale = list.Where(x => x.Root == chord.Key.NoteName).FirstOrDefault();
				if (null != scale)
				{
					result.ScaleFormulas.Add(scale);
				}
				else
				{
#warning "Maybe full unit tests are in order. They would probably end up saving you time."

					if (list.Count == 1)
					{
						result.ScaleFormulas.Add(list.First());
					}
					else
					{
						var types = list.Select(x => x.GetType()).Distinct();
						if (types.Count() > 1)
						{
							new Object();
						}

						var comparer = new NoteNameAphaEqualityComparer();
						var intersectCount = 0;
						ScaleFormulaBase selectedScale = null;
						foreach (var s in list)
						{
							var count = s.NoteNames.Intersect(chord.NoteNames, comparer).Count();
							if (count > intersectCount)
							{
								intersectCount = count;
								selectedScale = s;
							}
						}
						Debug.Assert(null != selectedScale);
						result.ScaleFormulas.Add(selectedScale);
					}
				}
			}


			new object();

			return result;
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

	public class EnharmonicEquivalents
	{
		public Dictionary<string, List<ScaleFormulaBase>> Equivalents { get; set; } = new Dictionary<string, List<ScaleFormulaBase>>();
		public void Add(ScaleFormulaBase scale)
		{
			var key = scale.CreateStringKey();
			if (this.Equivalents.Keys.Contains(key))
			{
				var list = this.Equivalents[key];
				list.Add((dynamic)scale);
			}
			else
			{
				var list = new List<ScaleFormulaBase>();
				list.Add(scale);
				this.Equivalents.Add(key, list);
			}
		}
	}
	static class Extensions
	{
		static public EnharmonicEquivalents GetEnharmonicEquivalents(this List<ScaleFormulaBase> src)
		{
			var result = new EnharmonicEquivalents();
			foreach (var scale in src)
			{
				result.Add(scale);
			}
			return result;
		}

		static public string CreateStringKey(this ScaleFormulaBase src)
		{
			var key = src.NoteNames.Sum(x => x.Value);
			var result = key.ToString();

			//var comparer = new NoteNameAlphaComparer();
			//var seq = src.NoteNames.OrderBy(x => x, comparer).Select(x => x.Name);
			//var result = string.Join(",", seq);
			return result;
		}
	}
}//ns