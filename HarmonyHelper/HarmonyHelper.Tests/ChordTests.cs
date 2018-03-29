using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass()]
	public class ChordTests
	{
		[TestMethod()]
		public void GetThirdTest()
		{
			var cte = ChordTypesEnum.Minor;

			var ict = (int)cte;
			var mask = (int)(ChordTonesBitmaskEnum.Third);

			var which = (ict & mask);
			var result = (IntervalsEnum)which;

			var interval = ChordTypesEnum.Major.GetThirdInterval();
			//IntervalsEnum GetThird(this ChordTypesEnum e)
			interval.ToStringEx();
		}

		[TestMethod()]
		public void SubtractionOperatorTest()
		{
			var intervals = Enum.GetValues(typeof(IntervalsEnum))
				.OfType<IntervalsEnum>()
				.Where(x => x > IntervalsEnum.None)
				.ToList();

			foreach (var interval in intervals)
			{
				var key = KeySignature.BbMajor;
				var subtrahend = NoteName.C + new IntervalContext(key, interval);
				var result = NoteName.C - subtrahend;
				Assert.AreEqual(interval, result);
			}

			new object();
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
			for (int i = 0; i < MAX_ITERATIONS; ++i)
			{
				var next = chord.GetClosestNoteEx(arpeggiator);
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
			for (int i = 0; i < MAX_ITERATIONS; ++i)
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
			var chord = ChordFormulaCatalog.Formulas.First(x => x.Root == NoteName.Gb && x.ChordType == ChordTypesEnum.Dominant7th);
			Debug.WriteLine(string.Format("{0}7 = {1}", chord.Root.ToString(), chord.ToString()));
			var origKey = chord.Key;
			var txedUp = chord + new IntervalContext(origKey, IntervalsEnum.Perfect4th);
			Assert.AreNotEqual(txedUp, chord);
			var txedDown = txedUp - new IntervalContext(origKey, IntervalsEnum.Perfect4th);
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

				var txedUp = origChord + new IntervalContext(origKey, IntervalsEnum.Perfect4th);
				Assert.AreNotEqual(txedUp, origChord);

				var txedDown = txedUp - new IntervalContext(origKey, IntervalsEnum.Perfect4th);

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
				var newChord = chord + new IntervalContext(chord.Key, IntervalsEnum.Perfect5th);
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
		public void TheCycleTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SeventhPosition);
			var chordFormula = ChordFormulaCatalog.C7;
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var chord = new Chord(chordFormula, noteRange);
			var key = chord.Key;
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };

			for (int i = 0; i <= 10; ++i)
			{
				if (chord.Key.NoteName == NoteName.Bb)
					new Object();
				if (chord.Key.NoteName == NoteName.ASharp)
					new Object();

				var perfect4th = IntervalsEnum.Perfect4th;
				var txedKey = chord.Key + perfect4th;
				chordFormula = chordFormula + new IntervalContext(txedKey, IntervalsEnum.Perfect4th);
				// chordFormula = chordFormula + perfect4th;


				if (KeySignature.BMajor == chordFormula.Key)
					new object();

				chord = new Chord(chordFormula, noteRange);

				//if (KeySignature.EbMajor == chordFormula.Key)
				//    new object();
				//if (chordFormula.Key.UsesFlats)
				//{
				//    Assert.IsTrue(chord.Root.NoteName.IsNatural || chord.Root.NoteName.IsFlat);
				//    Assert.IsTrue(chord.NoteNames.All(x => x.IsNatural || x.IsFlat));
				//    Assert.IsTrue(chord.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsFlat));
				//}
				//else if (chordFormula.Key.UsesSharps)
				//{
				//    Assert.IsTrue(chord.Root.NoteName.IsNatural || chord.Root.NoteName.IsSharp);
				//    Assert.IsTrue(chord.NoteNames.All(x => x.IsNatural || x.IsSharp));
				//    Assert.IsTrue(chord.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsSharp));
				//}
				//else { }

				//Assert.IsTrue(chord.IsValid());

				chords.Add(chord);
			}

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void StraightNoChaserExercise()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
			var FOUR = 4;
			var TWO = 2;

			var contexts = new List<ArpeggiationContext>();

			for (int i = 0; i < 4; ++i)
			{
				var chordFormula = new ChordFormula(NoteName.A, ChordTypesEnum.Minor7th, KeySignature.GMajor);
				var chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, TWO));

				chordFormula = new ChordFormula(NoteName.D, ChordTypesEnum.Dominant7th, KeySignature.GMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, TWO));

				chordFormula = new ChordFormula(NoteName.G, ChordTypesEnum.Minor7th, KeySignature.FMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, FOUR));

				chordFormula = new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.FMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, FOUR));

				chordFormula = new ChordFormula(NoteName.F, ChordTypesEnum.Dominant7th, KeySignature.BbMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, FOUR));
			}

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, null);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void KeySignatureTransposeTest()
		{
			var key = KeySignature.CMajor;
			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				var a = key.NoteName.ToString();
				var b = key.GetNormalized(key.NoteName).ToString();
				Assert.AreEqual(a, b);
				//key.Notes.ForEach(x => Debug.Write(x + ","));
				//Debug.WriteLine("");
				key = key + IntervalsEnum.Perfect4th;
			}
		}

		const int CYCLE_MAX = 11;
		[TestMethod()]
		public void ii_V_CycleTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.TwelfthPosition);

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordTypesEnum chordType = ChordTypesEnum.Augmented;

			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordTypesEnum.Minor7th;
				}
				else
				{
					if (chordType == ChordTypesEnum.Dominant7th)
					{
						chordType = ChordTypesEnum.Minor7th;
						key = key - IntervalsEnum.Major2nd;
					}
					else
					{
						chordType = ChordTypesEnum.Dominant7th;
					}
					root = root + new IntervalContext(key, IntervalsEnum.Perfect4th);
				}

				var formula = new ChordFormula(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);

				//Debug.Write("key="+key.ToString()+":");
				//Debug.Write("("+chord.Name+"):");
				//Debug.WriteLine(chord.ToString());

				new object();

			}

			new object();

			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;


			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void ii_V_Cycle_12Frets_Test()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.B, OctaveEnum.Octave0),
				new Note(NoteName.G, OctaveEnum.Octave3));

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordTypesEnum chordType = ChordTypesEnum.Augmented;

			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordTypesEnum.Minor7th;
				}
				else
				{
					if (chordType == ChordTypesEnum.Dominant7th)
					{
						chordType = ChordTypesEnum.Minor7th;
						key = key - IntervalsEnum.Major2nd;
					}
					else
					{
						chordType = ChordTypesEnum.Dominant7th;
					}
					root = root + new IntervalContext(key, IntervalsEnum.Perfect4th);
				}

				var formula = new ChordFormula(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);

				//Debug.Write("key="+key.ToString()+":");
				//Debug.Write("("+chord.Name+"):");
				//Debug.WriteLine(chord.ToString());

				new object();

			}

			new object();

			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;


			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void TheChickenTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
			var Bb7 = new Chord(new ChordFormula(NoteName.Bb, ChordTypesEnum.Dominant7th, KeySignature.EbMajor), noteRange);
			var startingNote = new Note(Bb7.Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { Bb7 };
			//for (int i = 0; i <= 16; ++i)
			{
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				var Eb7 = new Chord(new ChordFormula(NoteName.Eb, ChordTypesEnum.Dominant7th, KeySignature.AbMajor), noteRange);
				chords.Add(Eb7);
				chords.Add(Eb7);
				var D7 = new Chord(new ChordFormula(NoteName.D, ChordTypesEnum.Dominant7th, KeySignature.GMajor), noteRange);
				chords.Add(D7);
				var G7 = new Chord(new ChordFormula(NoteName.G, ChordTypesEnum.Dominant7th, KeySignature.CMajor), noteRange);
				chords.Add(G7);
				var C7 = new Chord(new ChordFormula(NoteName.C, ChordTypesEnum.Dominant7th, KeySignature.FMajor), noteRange);
				chords.Add(C7);
				chords.Add(C7);
				chords.Add(C7);
				chords.Add(C7);
			}


			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}


		[TestMethod()]
		public void AutumnLeavesTest()
		{
			// Assert.Fail("This test proves that a arpeggiation context can be created that never repeats its first context rendering.");
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
			var startingNote = new Note(NoteName.A, OctaveEnum.Octave2);
			var notesToPlay = 8;

			var key = KeySignature.GMajor;
			var chords = new List<Chord>();
			{
				var chord = new Chord(
					new ChordFormula(NoteName.A,
						ChordTypesEnum.Minor7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.D,
						ChordTypesEnum.Dominant7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.G,
						ChordTypesEnum.Major7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.C,
						ChordTypesEnum.Major7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.FSharp,
						ChordTypesEnum.HalfDiminished,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.B,
						ChordTypesEnum.Dominant7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.E,
						ChordTypesEnum.Minor7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					new ChordFormula(NoteName.E,
						ChordTypesEnum.Minor7th,
						key),
					noteRange);
				chords.Add(chord);

			}


			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 8, null, true);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}



		[TestMethod()]
		public void CycleOfMinor3rdsTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
			var chordFormula = ChordFormulaCatalog.Eb7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			for (int i = 0; i <= 10; ++i)
			{
				chordFormula = chordFormula + new IntervalContext(chordFormula.Key, IntervalsEnum.Minor3rd);
				chord = new Chord(chordFormula, noteRange);
				chords.Add(chord);
			}

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void ColtraneChangesTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.NinthPosition);
			var chordFormula = ChordFormulaCatalog.Bb7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			for (int i = 0; i <= 10; ++i)
			{
				var major3rd = IntervalsEnum.Major3rd;
				var txposedKey = chordFormula.Key + major3rd;
				chordFormula = chordFormula + new IntervalContext(txposedKey, major3rd);
				chord = new Chord(chordFormula, noteRange);
				chords.Add(chord);
			}


			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}


		private void Ctx_Ending(object sender, Arpeggiator e)
		{
			Debug.WriteLine("||");
		}

		private void Ctx_Starting(object sender, Arpeggiator e)
		{
			Debug.Write("|");
		}

		DirectionEnum? _lastDirection;
		private void Ctx_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			var directionChanged = true;
			if (_lastDirection.HasValue)
			{
				if (_lastDirection.Value == ctx.Direction)
				{
					directionChanged = false;
				}
			}
			_lastDirection = ctx.Direction;

			var noteStr = ctx.CurrentNote.ToString();
			if (!directionChanged)
			{
				noteStr = string.Format(" {0,-3}", noteStr);
			}
			else
			{
				noteStr = string.Format("{0,-2}", noteStr);
			}
			Debug.Write(noteStr);
		}

		private void Ctx_DirectionChanged(object sender, Arpeggiator ctx)
		{
			const string ASC = "˄";
			const string DESC = "˅";

			var direction = ctx.Direction == DirectionEnum.Ascending ? ASC : DESC;
			Debug.Write(direction);
		}

		int chordCount = 0;
		const int BARS_PER_LINE = 2;
		private void Ctx_ChordChanged(object sender, Arpeggiator ctx)
		{

			if (ctx.CurrentChord.Key.UsesFlats)
			{
				Assert.IsTrue(ctx.CurrentChord.Root.NoteName.IsNatural || ctx.CurrentChord.Root.NoteName.IsFlat);
				Assert.IsTrue(ctx.CurrentChord.NoteNames.All(x => x.IsNatural || x.IsFlat));
				Assert.IsTrue(ctx.CurrentChord.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsFlat));
			}
			else if (ctx.CurrentChord.Key.UsesSharps)
			{
				Assert.IsTrue(ctx.CurrentChord.Root.NoteName.IsNatural || ctx.CurrentChord.Root.NoteName.IsSharp);
				Assert.IsTrue(ctx.CurrentChord.NoteNames.All(x => x.IsNatural || x.IsSharp));
				Assert.IsTrue(ctx.CurrentChord.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsSharp));
			}
			else { }



			if (chordCount > 0 && chordCount % BARS_PER_LINE == 0)
				Debug.WriteLine(" |");
			Debug.Write(string.Format(" | {0,8} ", "(" + ctx.CurrentChord.Name + ")"));
			++chordCount;
		}

		private void Observe_ArpeggiationContextChanged(object sender, Arpeggiator ctx)
		{
		}


		[TestMethod()]
		public void ChordDiff()
		{
			var key = KeySignature.CMajor;
			var Dm = new ChordFormula(NoteName.D,
				ChordTypesEnum.Minor7th,
				key);
			var G7 = new ChordFormula(NoteName.G,
				ChordTypesEnum.Dominant7th,
				key);

			//var result = Dm.CompareTo(G7, true);
			//Debug.WriteLine(result.ToString());


			key = KeySignature.BbMajor;
			var Bb7 = new ChordFormula(NoteName.Bb,
				ChordTypesEnum.Dominant7th,
				key);
			var Eb7 = new ChordFormula(NoteName.Eb,
				ChordTypesEnum.Dominant7th,
				key);

			var result = Bb7.CompareTo(Eb7, true);
			Debug.WriteLine(result.ToString());

		}


	}//class
}//ns

