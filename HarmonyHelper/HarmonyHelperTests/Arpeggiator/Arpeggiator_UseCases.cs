using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using System.IO;

namespace Tests
{
	public partial class Arpeggiator_UseCases
	{
		[TestMethod()]
		public void TheCycleTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SeventhPosition);
			var contexts = new List<ArpeggiationChordContext>();

			var notesPerMeasure = 4;
			var chordFormula = ChordFormula.CDominant7;
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);

			for (int i = 0; i <= 11; ++i)
			{
				var chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, notesPerMeasure));

				
				chordFormula = chordFormula + Interval.Perfect4th;
			}

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void TheCycleTest_Fluent()
		{
			var chordFormula = ChordFormula.CDominant7;

			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SeventhPosition);
			var notesPerMeasure = 4;
			var arpeggiator = new Arpeggiator(DirectionEnum.Ascending,
				noteRange, notesPerMeasure)
					.Add(new ArpeggiationChordContext(new Chord(chordFormula, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure))
					.Add(new ArpeggiationChordContext(new Chord(chordFormula += Interval.Perfect4th, noteRange), notesPerMeasure));

			this.RegisterEventHandlersForPrinting(arpeggiator);
			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void StraightNoChaserExercise()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
			var FOUR = 4;
			var TWO = 2;

			var contexts = new List<ArpeggiationChordContext>();

			for (int i = 0; i < 4; ++i)
			{
				var chordFormula = ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7);
				var chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, TWO));

				chordFormula = ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Dominant7);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, TWO));

				chordFormula = ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Minor7);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, FOUR));

				chordFormula = ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, FOUR));

				chordFormula = ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Dominant7);
				chord = new Chord(chordFormula, noteRange);
				contexts.Add(new ArpeggiationChordContext(chord, FOUR));
			}

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, null);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void ii_V_CycleTest_Bass()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.EigthPosition);

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
            ChordIntervalsEnum chordType = ChordIntervalsEnum.None;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordIntervalsEnum.Minor7;
				}
				else
				{
					if (chordType == ChordIntervalsEnum.Dominant7)
					{
						chordType = ChordIntervalsEnum.Minor7;
						key = key - Interval.Major2nd;
					}
					else
					{
						chordType = ChordIntervalsEnum.Dominant7;
					}
                    root += ChordToneInterval.Perfect4th;
					if (root.AccidentalCount > 0)
					{
						var ee = NoteName.GetEnharmonicEquivalents(root)
							.OrderBy(x => x.AccidentalCount)
							.FirstOrDefault(x => 
								x.AccidentalCount < root.AccidentalCount);
						root = ee ?? root;
					}
				}

				var formula = ChordFormulaFactory.Get(root, chordType);
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

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			var handlers = new CsvEventHandlers(arpeggiator).Register();

            //this.RegisterEventHandlersForPrinting(arpeggiator);

            arpeggiator.Arpeggiate();
			handlers.Register(false);

			File.WriteAllText(@"c:\temp\csvExport.csv", handlers.Result, Encoding.Unicode);
			
            



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
            ChordIntervalsEnum chordType = ChordIntervalsEnum.Augmented;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordIntervalsEnum.Minor7;
				}
				else
				{
					if (chordType == ChordIntervalsEnum.Dominant7)
					{
						chordType = ChordIntervalsEnum.Minor7;
						key = key - Interval.Major2nd;
					}
					else
					{
						chordType = ChordIntervalsEnum.Dominant7;
					}
					root = root + ChordToneInterval.Eleventh;
				}

				var formula = ChordFormulaFactory.Get(root, chordType);
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

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

            RegisterEventHandlersForPrinting(arpeggiator);


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
            ChordIntervalsEnum chordType = ChordIntervalsEnum.None;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.G;
					key = KeySignature.CMajor;
					chordType = ChordIntervalsEnum.Dominant7;
				}
				else
				{
					chordType = ChordIntervalsEnum.Dominant7;
					key += Interval.Perfect4th;
					root += ChordToneInterval.Eleventh;
				}

				var formula = ChordFormulaFactory.Get(root, chordType);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

			RegisterEventHandlersForPrinting(arpeggiator);
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
            ChordIntervalsEnum chordType = ChordIntervalsEnum.None;

			for (int i = 0; i <= TestConstants.CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.C;
					key = KeySignature.GbMajor;
					chordType = ChordIntervalsEnum.Dominant7;
				}
				else
				{
					chordType = ChordIntervalsEnum.Dominant7;
					key += Interval.Perfect4th;
					root += ChordToneInterval.Eleventh;
				}

				var formula = ChordFormulaFactory.Get(root, chordType);
                var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

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
            ChordIntervalsEnum chordType = ChordIntervalsEnum.Dominant7;

			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.D, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.D, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.E, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.D, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.A, chordType), noteRange));
			chords.Add(new Chord(ChordFormulaFactory.Get(NoteName.E, chordType), noteRange));


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave1);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			this.noteRangeUsageStatistics = new NoteRangeUsageStatistics(noteRange);
			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

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
			var Bb7 = new Chord(ChordFormulaFactory.Get(NoteName.Bb, ChordIntervalsEnum.Dominant7), noteRange);
			var startingNote = new Note(Bb7.Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { Bb7 };
			//for (int i = 0; i <= 16; ++i)
			{
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				chords.Add(Bb7);
				var Eb7 = new Chord(ChordFormulaFactory.Get(NoteName.Eb, ChordIntervalsEnum.Dominant7), noteRange);
				chords.Add(Eb7);
				chords.Add(Eb7);
				var D7 = new Chord(ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Dominant7), noteRange);
				chords.Add(D7);
				var G7 = new Chord(ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7), noteRange);
				chords.Add(G7);
				var C7 = new Chord(ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Dominant7), noteRange);
				chords.Add(C7);
				chords.Add(C7);
				chords.Add(C7);
				chords.Add(C7);
			}


			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

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
                    ChordFormulaFactory.Get(NoteName.A,
                        ChordIntervalsEnum.Minor7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.D,
                        ChordIntervalsEnum.Dominant7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.G,
                        ChordIntervalsEnum.Major7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.C,
                        ChordIntervalsEnum.Major7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.FSharp,
                        ChordIntervalsEnum.HalfDiminished),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.B,
                        ChordIntervalsEnum.Dominant7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.E,
                        ChordIntervalsEnum.Minor7),
					noteRange);
				chords.Add(chord);

				chord = new Chord(
                    ChordFormulaFactory.Get(NoteName.E,
                        ChordIntervalsEnum.Minor7),
					noteRange);
				chords.Add(chord);

			}


			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 8, null, true);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void CycleOfMinor3rdsTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
			var chordFormula = ChordFormula.EbDominant7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			for (int i = 0; i <= 10; ++i)
			{
				chordFormula += Interval.Minor3rd;
				chord = new Chord(chordFormula, noteRange);
				chords.Add(chord);
			}

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void ColtraneChangesTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.NinthPosition);
			var chordFormula = ChordFormula.BbDominant7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			for (int i = 0; i <= 10; ++i)
			{
                if (chordFormula.Root.AccidentalCount == 2)
                {
                    var nn = NoteName.GetEnharmonicEquivalents(chordFormula.Root).First();


                    var key = KeySignature.InternalCatalog
                        .First(x => x.NoteName == nn + ChordToneInterval.Eleventh && x.IsMajor);


                    chordFormula = ChordFormulaFactory
						.Get(nn, chordFormula.ChordType);
                }

                chordFormula -= Interval.Major3rd;
				Debug.WriteLine(chordFormula.Name);
				chord = new Chord(chordFormula, noteRange);
				chords.Add(chord);
			}


			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

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
			chords.Add(new Chord(ChordFormula.ADominant7, noteRange));
			chords.Add(new Chord(ChordFormula.DDominant7, noteRange));

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, beatsPerBar)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, beatsPerBar, startingNote, true);

			arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
			arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
			arpeggiator.NoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Starting += Arpeggiator_Starting;
			arpeggiator.Ending += Arpeggiator_Ending;

			arpeggiator.Arpeggiate();

			new object();
		}

	}
}
