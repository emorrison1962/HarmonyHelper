using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony
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
		public void Interval_Distinct_ToIndex()
		{
			var indexes = new List<int>();
			foreach (var interval in Interval.Catalog)
			{
				var ndx = interval.ToIndex();
				indexes.Add(ndx);
			}
			Assert.IsTrue(indexes.Count == indexes.Distinct().Count());
			new object();
		}

		[TestMethod]
		public void Interval_GetInversion()
		{
			var intervals = Interval.Catalog.Where(x => x != Interval.None);
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
					Assert.IsTrue(inversion == Interval.Minor3rd);
				else if (interval == Interval.Minor7th)
					Assert.IsTrue(inversion == Interval.Major2nd);
				else if (interval == Interval.Major7th)
					Assert.IsTrue(inversion == Interval.Minor2nd);

			}
		}

		[TestMethod]
		public void NoteName_Subtration_Operator()
		{
			var nn1 = NoteName.Catalog[0];
			var nns = NoteName.Catalog.Where(x => x != nn1);

			foreach (var nn2 in nns)
			{
				var i1 = nn2 - nn1;
				var i2 = nn1 - nn2;
				Assert.AreEqual(i1, i2);
			}
		}

		[TestMethod]
		public void NoteName_Transpose()
		{
			foreach (var noteName in NoteName.Catalog)
			{
				var intervals = Interval.Catalog.Where(x => x != Interval.None);
				foreach (var interval in intervals)
				{
					var txposedUp = NoteName.TransposeUp(noteName, interval);
					var expectedInterval = noteName - txposedUp;

					Assert.IsTrue(expectedInterval.Value == Math.Min(interval.Value, interval.GetInversion().Value));
					Assert.IsFalse(txposedUp == noteName);

					var txposedDown = NoteName.TransposeDown(txposedUp, interval);
					expectedInterval = txposedDown - noteName;

					Assert.IsTrue(expectedInterval == Interval.None);
					Assert.IsFalse(txposedDown == txposedUp);
					Assert.IsTrue(txposedDown == noteName);
				}
			}
		}

		[TestMethod]
		public void NoteName_BSharp_Transpose()
		{
			var originalNoteName = NoteName.BSharp;
			var interval = Interval.Major2nd;

			var txposedUp = NoteName.TransposeUp(originalNoteName, interval);
			var expectedInterval = originalNoteName - txposedUp;

			Assert.IsTrue(expectedInterval.Value == Math.Min(interval.Value, interval.GetInversion().Value));
			Assert.IsFalse(txposedUp == originalNoteName);

			var txposedDown = NoteName.TransposeDown(txposedUp, interval);
			expectedInterval = txposedDown - originalNoteName;

			Assert.IsTrue(expectedInterval == Interval.None);
			Assert.IsFalse(txposedDown == txposedUp);
			Assert.IsTrue(txposedDown == originalNoteName);
		}


		[TestMethod]
		public void Chords_Dont_have_Sharps_AND_Flats()
		{
			var noteRange = NoteRange.Default;

			foreach (var noteName in NoteName.Catalog)
			{
				foreach (var chordType in ChordType.Catalog.Where(x => x != ChordType.None))
				{
					foreach (var key in KeySignature.Catalog)
					{
						var formula = new ChordFormula(noteName, chordType, key);
						var chord = new Chord(formula, noteRange);

						var flatCount = chord.Notes.Count(x => x.NoteName.IsFlat);
						var sharpCount = chord.Notes.Count(x => x.NoteName.IsSharp);
						var naturalCount = chord.Notes.Count(x => x.NoteName.IsNatural);

						if (flatCount > 0)
							Assert.IsTrue(sharpCount == 0);
						else if (sharpCount > 0)
							Assert.IsTrue(flatCount == 0);
					}
				}
			}

		}

	}//class
}//ns
