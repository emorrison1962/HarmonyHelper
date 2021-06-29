using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Tests;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	[TestClass()]
	public partial class ArpeggiatorTests
	{
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

				var perfect4th = Interval.Perfect4th;
				var txedKey = chord.Key + perfect4th;
				chordFormula = chordFormula + new IntervalContext(txedKey, Interval.Perfect4th);
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
				var chordFormula = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor7th, KeySignature.GMajor);
				var chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, TWO));

				chordFormula = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7th, KeySignature.GMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, TWO));

				chordFormula = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor7th, KeySignature.FMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, FOUR));

				chordFormula = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7th, KeySignature.FMajor);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationContext(chord, FOUR));

				chordFormula = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant7th, KeySignature.BbMajor);
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
		public void ii_V_CycleTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.TwelfthPosition);

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordType chordType = ChordType.Augmented;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordType.Minor7th;
				}
				else
				{
					if (chordType == ChordType.Dominant7th)
					{
						chordType = ChordType.Minor7th;
						key = key - Interval.Major2nd;
					}
					else
					{
						chordType = ChordType.Dominant7th;
					}
					root = root + new IntervalContext(key, Interval.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
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
			ChordType chordType = ChordType.Augmented;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordType.Minor7th;
				}
				else
				{
					if (chordType == ChordType.Dominant7th)
					{
						chordType = ChordType.Minor7th;
						key = key - Interval.Major2nd;
					}
					else
					{
						chordType = ChordType.Dominant7th;
					}
					root = root + new IntervalContext(key, Interval.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
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
		public void TheCycle_12Frets_Test()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.B, OctaveEnum.Octave0),
				new Note(NoteName.G, OctaveEnum.Octave3));

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordType chordType = ChordType.None;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.G;
					key = KeySignature.CMajor;
					chordType = ChordType.Dominant7th;
				}
				else
				{
					chordType = ChordType.Dominant7th;
					key = key + Interval.Perfect4th;
					root = root + new IntervalContext(key, Interval.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
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

			var noteUsage = this.noteRangeUsageStatistics.NoteUsages.ToList();
			//noteUsage.ForEach(kvp => Debug.WriteLine($"{kvp.Key.ToString()} was used {kvp.Value} times."));

			new object();
		}

		[TestMethod()]
		public void TheCycle_12Frets_Test_Guitar()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.E, OctaveEnum.Octave1),
				new Note(NoteName.E, OctaveEnum.Octave4));

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordType chordType = ChordType.None;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.C;
					key = KeySignature.GbMajor;
					chordType = ChordType.Dominant7th;
				}
				else
				{
					chordType = ChordType.Dominant7th;
					key = key + Interval.Perfect4th;
					root = root + new IntervalContext(key, Interval.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
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

			var noteUsage = this.noteRangeUsageStatistics.NoteUsages.ToList();
			//noteUsage.ForEach(kvp => Debug.WriteLine($"{kvp.Key.ToString()} was used {kvp.Value} times."));

			new object();
		}

		[TestMethod()]
		public void Blues_12Frets_Test_Guitar()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.E, OctaveEnum.Octave1),
				new Note(NoteName.E, OctaveEnum.Octave4));

			var chords = new List<Chord>();
			KeySignature key = KeySignature.AMajor;
			ChordType chordType = ChordType.Dominant7th;

			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.D, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.D, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.E, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.D, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.A, chordType, key), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Create(NoteName.E, chordType, key), noteRange));


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave1);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
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

			var noteUsage = this.noteRangeUsageStatistics.NoteUsages.ToList();
			//noteUsage.ForEach(kvp => Debug.WriteLine($"{kvp.Key.ToString()} was used {kvp.Value} times."));

			new object();
		}


		NoteRangeUsageStatistics noteRangeUsageStatistics { get; set; }
		class NoteRangeUsageStatistics
		{
			public Dictionary<Note, int> NoteUsages { get; private set; } = new Dictionary<Note, int>();
			public NoteRangeUsageStatistics(NoteRange nr)
			{
				nr.Notes.ForEach(x => this.NoteUsages.Add(x, 0));
			}

			public void AddReference(Note note)
			{
				if (!this.NoteUsages.ContainsKey(note))
					this.NoteUsages.Add(note, 0);
				var currentCount = this.NoteUsages[note];
				this.NoteUsages[note] = ++currentCount;
			}
		}

		[TestMethod()]
		public void TheChickenTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
			var Bb7 = new Chord(ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant7th, KeySignature.EbMajor), noteRange);
			var startingNote = new Note(Bb7.Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { Bb7 };
			//for (int i = 0; i <= 16; ++i)
			{
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				var Eb7 = new Chord(ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant7th, KeySignature.AbMajor), noteRange);
				chords.Add(Eb7);
				chords.Add(Eb7);
				var D7 = new Chord(ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7th, KeySignature.GMajor), noteRange);
				chords.Add(D7);
				var G7 = new Chord(ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant7th, KeySignature.CMajor), noteRange);
				chords.Add(G7);
				var C7 = new Chord(ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7th, KeySignature.FMajor), noteRange);
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
					ChordFormulaFactory.Create(NoteName.A,
						ChordType.Minor7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.D,
						ChordType.Dominant7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.G,
						ChordType.Major7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.C,
						ChordType.Major7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.FSharp,
						ChordType.HalfDiminished,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.B,
						ChordType.Dominant7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.E,
						ChordType.Minor7th,
						key),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
					ChordFormulaFactory.Create(NoteName.E,
						ChordType.Minor7th,
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
				chordFormula = chordFormula + new IntervalContext(chordFormula.Key, Interval.Minor3rd);
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
				var major3rd = Interval.Major3rd;
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

		[TestMethod()]
		public void ArpeggioExerciseTest()
		{
			var noteRange = new NoteRange(new Note(NoteName.A, OctaveEnum.Octave2), new Note(NoteName.A, OctaveEnum.Octave3));
			
			var startingNote = new Note(NoteName.A, OctaveEnum.Octave2);
			var beatsPerBar = 6;

			var chords = new List<Chord>();
			chords.Add(new Chord(ChordFormulaCatalog.A7, noteRange));
			chords.Add(new Chord(ChordFormulaCatalog.D7, noteRange));

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, beatsPerBar)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, beatsPerBar, startingNote, true);

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
			if (null != this.noteRangeUsageStatistics)
				this.noteRangeUsageStatistics.AddReference(ctx.CurrentNote);
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
				noteStr = string.Format(" {0,-2}", noteStr);
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
			if (chordCount > 0 && chordCount % BARS_PER_LINE == 0)
				Debug.WriteLine(" |");
			Debug.Write(string.Format(" | {0,5} ", "(" + ctx.CurrentChord.Name + ")"));
			++chordCount;
		}

		private void Observe_ArpeggiationContextChanged(object sender, Arpeggiator ctx)
		{
		}




	}
}
