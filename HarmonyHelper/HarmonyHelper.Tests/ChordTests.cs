using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ChordTests
	{
		[TestMethod()]
		public void GetThirdTest()
		{
			var cte = ChordType.Minor;

			var ict = (int)cte;
			var mask = (int)(ChordTonesBitmaskEnum.Third);

			var which = (ict & mask);
			var result = (Interval)which;

			var interval = ChordType.Major.GetInterval(ChordFunctionEnum.Third);
			//Interval GetThird(this ChordType e)
			//interval.ToStringEx();
		}

		[TestMethod()]
		public void FindClosestNoteTest()
		{
			//var chordFormula = ChordFormula.A7;
			//var startingNote = chordFormula.Root;
			var lowerLimit = new Note(NoteName.C, OctaveEnum.Octave0);
			var upperLimit = new Note(NoteName.B, OctaveEnum.Octave6);
			var noteRange = new NoteRange(lowerLimit, upperLimit);

			//var chord = new Chord(chordFormula, noteRange);
			var root = new Note(NoteName.A, OctaveEnum.Octave0);
			var third = new Note(NoteName.B, OctaveEnum.Octave0);
			var fifth = new Note(NoteName.C, OctaveEnum.Octave0);
			var seventh = new Note(NoteName.D, OctaveEnum.Octave0);
			var chord = new Chord(root, third, fifth, seventh, noteRange);

			const int MAX_NOTES_PER_CHORD = 8;

			var ctx = new ArpeggiationContext(chord, MAX_NOTES_PER_CHORD);
			var arpeggiator = new Arpeggiator(new ArpeggiationContext[] { ctx },
				DirectionEnum.Ascending,
				noteRange, 4,
				root);

			const int MAX_ITERATIONS = 100;
			Debug.WriteLine(root);
			for (int i = 0 ; i < MAX_ITERATIONS ; ++i)
			{
				var closestNoteCtx = new Chord.ClosestNoteContext(arpeggiator);
				chord.GetClosestNote(closestNoteCtx);
				var next = closestNoteCtx.ClosestNote;
				Debug.WriteLine(string.Format("{0}", next.ToString()));
				arpeggiator.CurrentNote = next;
			}
			new object();
		}


		[TestMethod]
		public void EnumNextTest()
		{
			const int MAX_ITERATIONS = 12;
			var e = OctaveEnum.Octave0;
			var sw = Stopwatch.StartNew();
			for (int i = 0 ; i < MAX_ITERATIONS ; ++i)
			{
				e = e.Next();
				Debug.WriteLine(e);
			}
			sw.Stop();
			Debug.WriteLine(sw.Elapsed);
			new object();
		}

		[TestMethod()]
		public void Gb7ModulationTest()
		{
			var chord = ChordFormulaCatalog.Formulas.First(x => x.Root == NoteName.Gb && x.ChordType == ChordType.Dominant7th);
			Debug.WriteLine(string.Format("{0}7 = {1}", chord.Root.ToString(), chord.ToString()));
			var origKey = chord.Key;
			var txedUp = chord + new IntervalContext(origKey, Interval.Perfect4th);
			Assert.AreNotEqual(txedUp, chord);
			var txedDown = txedUp - new IntervalContext(origKey, Interval.Perfect4th);
			var b = txedDown == chord;
			Assert.AreEqual(txedDown, chord);
			new object();
		}


		[TestMethod()]
		public void ChordTest()
		{
			foreach (var origChord in ChordFormulaCatalog.Formulas)
			{
				Debug.WriteLine(string.Format("{0}7 = {1}", origChord.Root.ToString(), origChord.ToString()));

				var origKey = origChord.Key;

				var txedUp = origChord + new IntervalContext(origKey, Interval.Perfect4th);
				Assert.AreNotEqual(txedUp, origChord);

				var txedDown = txedUp - new IntervalContext(origKey, Interval.Perfect4th);

				var b = txedDown == origChord;
				Assert.AreEqual(txedDown, origChord);
			}
			new object();
		}

		[TestMethod()]
		public void IteratorTest()
		{
			foreach (var chord in ChordFormulaCatalog.Formulas)
			{
				var newChord = chord + new IntervalContext(chord.Key, Interval.Perfect5th);
				//Debug.WriteLine(newChord.ToString());
			}
			new object();
		}

		[TestMethod()]
		public void ToStringTest()
		{
			foreach (var chord in ChordFormulaCatalog.Formulas)
			{
				Debug.WriteLine(chord.ToString());
			}
			new object();
		}

		[TestMethod()]
		public void KeySignatureTransposeTest()
		{
			var key = KeySignature.CMajor;
			for (int i = 0 ; i <= TestConstants.CYCLE_MAX ; ++i)
			{
				var a = key.NoteName.ToString();
				var b = key.GetNormalized(key.NoteName).ToString();
				Assert.AreEqual(a, b);
				//key.Notes.ForEach(x => Debug.Write(x + ","));
				//Debug.WriteLine("");
				key = key + Interval.Perfect4th;
			}
		}


		[TestMethod()]
		public void NoteTest_GSharpGreaterThanAFlat_Test()
		{
			var gSharp = new Note(NoteName.GSharp, OctaveEnum.Octave2);
			var aFlat = new Note(NoteName.Ab, OctaveEnum.Octave2);

			Assert.IsFalse(gSharp > aFlat);
			Assert.IsFalse(aFlat > gSharp);
			Assert.AreEqual(aFlat, gSharp);
		}


		[TestMethod()]
		public void ChordDiff()
		{
			var key = KeySignature.CMajor;
			var Dm = ChordFormulaFactory.Create(NoteName.D,
				ChordType.Minor7th,
				key);
			var G7 = ChordFormulaFactory.Create(NoteName.G,
				ChordType.Dominant7th,
				key);

			//var result = Dm.CompareTo(G7, true);
			//Debug.WriteLine(result.ToString());


			key = KeySignature.BbMajor;
			var Bb7 = ChordFormulaFactory.Create(NoteName.Bb,
				ChordType.Dominant7th,
				key);
			var Eb7 = ChordFormulaFactory.Create(NoteName.Eb,
				ChordType.Dominant7th,
				key);

			var result = Bb7.CompareTo(Eb7, true);
			Debug.WriteLine(result.ToString());

		}

		[TestMethod()]
		public void GetChordToneFunctionTest()
		{
			var chordTypes = ChordType.Catalog;
			foreach (var chordType in chordTypes)
			{
				var chord = ChordFormulaFactory.Create(NoteName.C, chordType, KeySignature.CMajor);
				foreach (var note in NoteName.Catalog)
				{
					if (chord.Contains(note))
					{
						var function = chord.GetChordToneFunction(note);
						if (function == ChordToneFunctionEnum.None)
						{
							function = chord.GetChordToneFunction(note);
						}
						Debug.WriteLine($"{note}'s relationship to {chord.Name}, is {function}");
						new object();
					}
					else
					{
						var function = chord.GetChordToneFunction(note);
						var msg = $"{note}'s relationship to {chord.Name}, is {function}";
						Debug.WriteLine($"{note}'s relationship to {chord.Name}, is {function}");
						new object();
						if (function == ChordToneFunctionEnum.None)
						{
							function = chord.GetChordToneFunction(note);
						}
						if (function != ChordToneFunctionEnum.None)
						{
							function = chord.GetChordToneFunction(note);
						}
					}
				}
			}
			new object();

		}
	}//class
}//ns

