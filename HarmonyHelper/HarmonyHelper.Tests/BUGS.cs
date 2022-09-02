using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
	[TestClass]
	public class BUGS
	{
		[TestMethod]
		public void NoteComparer()
		{
			var ll = new Note(NoteName.C, OctaveEnum.Octave0);
			var ul = new Note(NoteName.B, OctaveEnum.Octave3);
			var noteRange = new NoteRange(ll, ul);
			var result = noteRange.GetNotes(NoteName.Catalog);
			result.Sort(new NoteComparer());
			var s = string.Join(", ", result);
			Debug.WriteLine(s);
			new Object();
		}


		[TestMethod]
		public void Interval_GetInversion()
		{
			var intervals = Interval.Catalog.Where(x => x != Interval.Unison);
			foreach (var interval in intervals)
			{
				var inversion = interval.GetInversion();

				if (interval == Interval.Minor2nd)
					Assert.IsTrue(inversion == Interval.Major7th);
				else if (interval == Interval.Major2nd)
					Assert.IsTrue(inversion == Interval.Minor7th);
				else if (interval == Interval.Minor3rd)
					Assert.IsTrue(inversion == Interval.Major6th);
				else if (interval == Interval.Major3rd)
					Assert.IsTrue(inversion == Interval.Minor6th);
				else if (interval == Interval.Diminished4th)
					Assert.IsTrue(inversion == Interval.Augmented5th);
				else if (interval == Interval.Perfect4th)
					Assert.IsTrue(inversion == Interval.Perfect5th);
				else if (interval == Interval.Augmented4th)
					Assert.IsTrue(inversion == Interval.Diminished5th);
				else if (interval == Interval.Diminished5th)
					Assert.IsTrue(inversion == Interval.Augmented4th);
				else if (interval == Interval.Perfect5th)
					Assert.IsTrue(inversion == Interval.Perfect4th);
				else if (interval == Interval.Augmented5th)
					Assert.IsTrue(inversion == Interval.Diminished4th);
				else if (interval == Interval.Minor6th)
					Assert.IsTrue(inversion == Interval.Major3rd);
				else if (interval == Interval.Major6th)
					Assert.IsTrue(inversion == Interval.Minor3rd);
				else if (interval == Interval.Diminished7th)
					Assert.IsTrue(inversion == Interval.Augmented2nd);
				else if (interval == Interval.Minor7th)
					Assert.IsTrue(inversion == Interval.Major2nd);
				else if (interval == Interval.Major7th)
					Assert.IsTrue(inversion == Interval.Minor2nd);

			}
		}

		[TestMethod]
		public void NoteName_Subtration_Operator()
		{
			var nn1 = NoteName.Catalog.First();
			var nns = NoteName.Catalog.Where(x => x != nn1);

			foreach (var nn2 in nns)
			{
				var i1 = nn2 - nn1;
				var i2 = nn1 - nn2;

				Assert.AreEqual(i2.GetInversion().Value, i1.Value);
			}
		}

		[TestMethod]
		public void NoteName_Transpose()
		{
			var i = NoteName.CSharp - NoteName.BSharp;
			Assert.AreEqual(Interval.DiminishedOctave.Value, i.Value);

			foreach (var noteName in NoteName.Catalog)
			{
				var intervals = Interval.Catalog.Where(x => x != Interval.Unison && x != Interval.PerfectOctave);
				foreach (var interval in intervals)
				{
					if (NoteName.IsValidTransposition(noteName, interval))
					{
						var success = NoteName.TryTransposeUp(noteName, interval, out var txposedUp, out var unused);
						Assert.IsTrue(success);
						var expectedInterval = txposedUp - noteName;
						Assert.AreEqual(expectedInterval, interval);

						Assert.IsTrue(expectedInterval.Value == interval.Value);
						Assert.IsFalse(txposedUp == noteName);

						NoteName.TryTransposeUp(txposedUp, interval.GetInversion(), out var txposedDown, out var enharmonicEquivalent);

						expectedInterval = (txposedDown ?? enharmonicEquivalent) - noteName;

						//Assert.IsTrue(expectedInterval == Interval.Unison);
						Assert.IsFalse(txposedDown == txposedUp);
						Assert.IsTrue(txposedDown == noteName);
					}
				}
			}
		}

		[TestMethod]
		public void NoteName_BSharp_Transpose()
		{
			var originalNoteName = NoteName.BSharp;
			var interval = Interval.Major2nd;

			var success = NoteName.TryTransposeUp(originalNoteName, interval, out var txposedUp, out var unused);
			Assert.IsTrue(success);

			var expectedInterval = originalNoteName - txposedUp;

			Assert.IsTrue(expectedInterval.Value == interval.Value);
			Assert.IsFalse(txposedUp == originalNoteName);

			if (NoteName.TryTransposeUp(txposedUp, interval.GetInversion(), out var txposedDown, out var unused2))
			{
				expectedInterval = txposedDown - originalNoteName;
			}

			Assert.IsTrue(expectedInterval.Value == Interval.Unison.Value);
			Assert.IsFalse(txposedDown == txposedUp);
			Assert.IsTrue(txposedDown == originalNoteName);
		}



		[Ignore]
		[TestMethod]
		public void Chord_Populate_Notes()
		{
			var queue = new Queue<Chord>();
			foreach (var key in KeySignature.Catalog)
			{
				foreach (var chordType in ChordType.Catalog
					.Where(x => x.Intervals.Count > 2)
					.Except(new[] { ChordType.None }))
				{
					foreach (var nn in NoteName.Catalog)
					{
						var ascOctaves = Enum.GetValues(typeof(OctaveEnum))
						.Cast<OctaveEnum>()
						.Where(x => x > OctaveEnum.Unknown && x < OctaveEnum.Octave6)
						.ToList();
						foreach (var ascOctave in ascOctaves)
						{
							var descOctaves = Enum.GetValues(typeof(OctaveEnum))
								.Cast<OctaveEnum>()
								.Where(x => x > OctaveEnum.Unknown && x > ascOctave)
								.ToList();
							foreach (var descOctave in descOctaves)
							{
								try
								{
									var chordFormula = new ChordFormula(nn, chordType, key);
									var ul = new Note(nn, ascOctave);
									var ll = new Note(nn, descOctave);

									var noteRange = new NoteRange(ul, ll);
									var chord = new Chord(chordFormula, noteRange);
									// Debug.WriteLine($"chord.Notes.Count:{chord.Notes.Count}, nn:{nn}, chordType:{chordType}");
									Assert.IsTrue(4 <= chord.Notes.Count);
									chord.Set(noteRange);
									Assert.IsTrue(4 <= chord.Notes.Count);


#if false
									if (4 == queue.Count)
									{
										queue.Dequeue();
										queue.Enqueue(chord);
										this.Arpeggiate(queue.ToList(), noteRange);
									}
#endif

								}
								catch (ArgumentOutOfRangeException)
								{ }

							}
						}
					}
				}
			}
		}

		[TestMethod]
		public void Chord_GetClosestNote()
		{
			var chordTxt = "eb7 abm7 db7";

			if (ChordFormulaParser.TryParse(chordTxt,
				out var key,
				out List<ChordFormula> chords,
				out string message))
			{
				foreach (var chord in chords)
				{
					//new Chord.ClosestNoteContext(
					//GetClosestNote(ClosestNoteContext ctx)
				}
			}

		}


		[Ignore] //SUPER slow.
		[TestMethod]
		public void Arpeggiator_NoteRange_StartingNote_BUG()
		{
			//var chordTxt = "dm7 g7 cm7 f7 bbm7 eb7 abm7 db7";
			var chordTxt = "eb7 abm7 db7";
			var success = false;

			if (ChordFormulaParser.TryParse(chordTxt,
				out var key,
				out List<ChordFormula> chords,
				out string message))
			{
				//chords.ForEach(x => Debug.WriteLine(x));
				success = true;
			}

			if (success)
			{
				//foreach (var key in KeySignature.Catalog)
				{
					foreach (var nn in NoteName.Catalog)
					{
						var chordType = ChordType.Minor7th;
						/*foreach (var chordType in ChordType.Catalog
							.Where(x => x.Intervals.Count > 2)
							.Except(new[] { ChordType.None }))*/
						{

							var ascOctaves = Enum.GetValues(typeof(OctaveEnum))
								.Cast<OctaveEnum>()
								.Where(x => x > OctaveEnum.Unknown && x < OctaveEnum.Octave6)
								.ToList();
							foreach (var ascOctave in ascOctaves)
							{
								var descOctaves = Enum.GetValues(typeof(OctaveEnum))
									.Cast<OctaveEnum>()
									.Where(x => x > OctaveEnum.Unknown && x > ascOctave)
									.ToList();
								foreach (var descOctave in descOctaves)
								{
									try
									{
										{//Arpeggiate
											var noteRange = new NoteRange(
												//new Note(NoteName.B, OctaveEnum.Octave1),
												//new Note(NoteName.B, OctaveEnum.Octave4));
												new Note(NoteName.B, ascOctave),
												new Note(NoteName.B, descOctave));
											chords.ForEach(x => Assert.IsTrue(4 <= x.NoteNames.Count));

											new object();

											var startingNote = new Note(chords[0].Root,
											//OctaveEnum.Octave1);
											OctaveEnum.Octave2);

											var notesToPlay = 4;
											var contexts = new List<ArpeggiationContext>();
											chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, noteRange, notesToPlay)));

											const int BEATS_PER_BAR = 4;
											var arpeggiator = new Arpeggiator(contexts,
												DirectionEnum.Ascending,
												//DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversal,
												noteRange, BEATS_PER_BAR, startingNote, true);
#warning FIXME:
											arpeggiator.Arpeggiate();
										}
									}
									catch { }

								}
							}
							new object();
						}
					}
				}
			}
			new object();

		}

		void Arpeggiate(List<Chord> chords, NoteRange noteRange)
		{//Arpeggiate
			chords.ForEach(x => x.Set(noteRange));

			new object();

			var startingNote = new Note(chords[0].Root.NoteName,
			//OctaveEnum.Octave1);
			OctaveEnum.Octave2);

			var notesToPlay = 4;
			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			const int BEATS_PER_BAR = 4;
			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				//DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversal,
				noteRange, BEATS_PER_BAR, startingNote, true);

			arpeggiator.Arpeggiate();
		}


		[TestMethod]
		public void LinkedLinkTest()
		{
			var list = new List<string>()
			{
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
			};

			var ndx = list.IndexOf("C");
			var result = list.Advance(ndx, 5);
		}

	}//class
}//ns
