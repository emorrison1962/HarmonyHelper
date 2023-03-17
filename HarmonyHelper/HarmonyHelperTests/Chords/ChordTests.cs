using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.Intervals;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Eric.Morrison.Harmony.Chords.Chord;
using static Eric.Morrison.Harmony.Chords.ClosestNoteContext;

namespace Chord_Tests
{
    [TestClass()]
    public class ChordTests
    {
        [TestMethod()]
        public void GetThirdTest()
        {
            var cte = ChordIntervalsEnum.Minor;

            var ict = (uint)cte;
            var mask = (uint)(ChordTonesBitmaskEnum.Third);

            var which = (ict & mask);
            var result = (Interval)which;

            var interval = ChordIntervalsEnum.Major.GetInterval(ChordFunctionEnum.Third);
            //Interval GetThird(this ChordType e)
            //interval.ToStringEx();
        }


        public void FindClosestNoteTest(DirectionEnum direction)
        {
            var lowerLimit = new Note(NoteName.C, OctaveEnum.Octave4);
            var upperLimit = new Note(NoteName.B, OctaveEnum.Octave6);
            var noteRange = new NoteRange(lowerLimit, upperLimit);

            var dm7Formula = ChordFormula.CDominant7;
            var g7Formula = ChordFormula.FDominant7;

            var dm7 = new Chord(dm7Formula, noteRange);
            var g7 = new Chord(g7Formula, noteRange);

            const int MAX_NOTES_PER_CHORD = 4;

            var dm7Ctx = new ArpeggiationChordContext(dm7, MAX_NOTES_PER_CHORD);
            var g7Ctx = new ArpeggiationChordContext(g7, MAX_NOTES_PER_CHORD);
            //var arpeggiator = new Arpeggiator(new ArpeggiationChordContext[] { dm7Ctx, g7Ctx },
            //    direction,
            //    noteRange, 4,
            //    dm7.Root);

            var reportedDirection = DirectionEnum.None;

            var sb = new StringBuilder();
            EventHandler<DirectionChangedEventArgs> handler =
                (sender, args) => 
                {
                    const string ASC = "˄";
                    const string DESC = "˅";
                    if (args.Current.HasFlag(DirectionEnum.Ascending)) 
                    {
                        sb.Append(ASC);
                    }
                    else 
                    {
                        sb.Append(DESC);
                    }
                    reportedDirection = args.Current;
                };

            const int MAX_ITERATIONS = 100;
            Debug.WriteLine(dm7.Root);

            var note = dm7.Notes.FirstOrDefault(x => x.NoteName == NoteName.Bb);
            var closestNoteCtx = new ClosestNoteContext(note, dm7, direction);
            closestNoteCtx.DirectionChanged += handler;
            var isDm7 = true;

            for (int i = 0; i < MAX_ITERATIONS; ++i)
            {
                if (i % 4 == 0)
                {
                    if (isDm7)
                    {
                        sb.Append($"{dm7.Formula}: ");
                    }
                    else
                    {
                        sb.Append($" {g7.Formula}: ");
                    }
                }

                var prev = closestNoteCtx.LastNote;
                closestNoteCtx.GetClosestNote();
                var next = closestNoteCtx.ClosestNote;
                sb.Append($"{next.NameAscii}, ");
                closestNoteCtx.LastNote = next;

                Assert.IsNotNull(prev);
                Assert.IsNotNull(next);
                throw new NotImplementedException("Fix these asserts. How do I tell the temporary direction?");
                if (closestNoteCtx.Direction.HasFlag(DirectionEnum.Ascending))
                {
                    //Debug.WriteLine(reportedDirection);
                    Assert.IsTrue(next > prev);
                }
                else if (closestNoteCtx.Direction.HasFlag(DirectionEnum.Descending))
                {
                    Assert.IsTrue(next < prev);
                }

                if (i % 4 == 3)
                {
                    Debug.WriteLine(sb.ToString());
                    sb.Clear();
                    if (isDm7)
                    {
                        closestNoteCtx.SetChord(g7);
                        isDm7 = false;
                    }
                    else
                    {
                        closestNoteCtx.SetChord(dm7);
                        isDm7 = true;
                    }
                }
            }

            new object();
        }

        [TestMethod()]
        public void FindClosestNoteAscendingTest()
        {
            Debug.WriteLine($"==== +{MethodBase.GetCurrentMethod().Name} =======================");
            this.FindClosestNoteTest(DirectionEnum.Ascending);
            new object();
            Debug.WriteLine($"==== -{MethodBase.GetCurrentMethod().Name} =======================");
        }

        [TestMethod()]
        public void FindClosestNoteDescendingTest()
        {
            Debug.WriteLine($"==== +{MethodBase.GetCurrentMethod().Name} =======================");
            this.FindClosestNoteTest(DirectionEnum.Descending);
            new object();
            Debug.WriteLine($"==== -{MethodBase.GetCurrentMethod().Name} =======================");
        }

        [TestMethod()]
        public void FindClosestNoteAscendig_AllowTemporayReversalTest()
        {
            Debug.WriteLine($"==== +{MethodBase.GetCurrentMethod().Name} =======================");
            this.FindClosestNoteTest(DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote);
            new object();
            Assert.Fail();
            Debug.WriteLine($"==== -{MethodBase.GetCurrentMethod().Name} =======================");
        }


        [TestMethod()]
        public void Gb7ModulationTest()
        {
            var chord = ChordFormula.Catalog.First(x => x.Root == NoteName.Gb && x.ChordType == ChordIntervalsEnum.Dominant7);
            Debug.WriteLine(string.Format("{0}7 = {1}", chord.Root.ToString(), chord.ToString()));
            var origKey = chord.Keys.First();
            var txedUp = ChordFormula.TransposeUp(chord, Interval.Perfect4th, true);
            Assert.AreNotEqual(txedUp, chord);
            var txedDown = ChordFormula.TransposeUp(txedUp, Interval.Perfect4th.GetInversion(), true);
            var b = txedDown == chord;
            Assert.AreEqual(txedDown, chord);
            new object();
        }


        [TestMethod()]
        public void ChordTest()
        {
            try
            {
                foreach (var origChord in ChordFormula.Catalog)
                {
                    var txedUp = ChordFormula.TransposeUp(origChord, Interval.Perfect4th, true);
                    if (null != txedUp)
                    {
                        Assert.AreNotEqual(txedUp, origChord);

                        var inversion = Interval.Perfect4th.GetInversion();
                        var txedDown = ChordFormula.TransposeUp(txedUp, inversion, true);
                        if (null != txedDown)
                        {
                            Assert.AreEqual(txedDown, origChord);
                        }
                        else
                        {
                            Debug.WriteLine($"2) Transposing {txedUp.ToString()} down a PerfectFourth was unsuccessful.");
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"1) Transposing {origChord.ToString()} up a PerfectFourth was unsuccessful.");
                    }
                }
                new object();

            }
            catch (Exception ex)
            {
                var bex = ex.GetBaseException();
                throw;
            }
        }

        [TestMethod()]
        public void IteratorTest()
        {
            var assert = false;
            foreach (var chord in ChordFormula.Catalog)
            {
                try
                {
                    var newChord = chord + Interval.Perfect5th;

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex);
                    assert = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(chord);
                    //Debug.WriteLine(ex);
                    assert = true;
                }
                Assert.IsFalse(assert);
            }
            new object();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            foreach (var chord in ChordFormula.Catalog)
            {
                Debug.WriteLine(chord.ToString());
            }
            new object();
        }



        [TestMethod()]
        public void ChordDiff()
        {
            var key = KeySignature.CMajor;
            var Dm = ChordFormulaFactory.Get(NoteName.D,
                ChordIntervalsEnum.Minor7);
            var G7 = ChordFormulaFactory.Get(NoteName.G,
                ChordIntervalsEnum.Dominant7);

            //var result = Dm.CompareTo(G7, true);
            //Debug.WriteLine(result.ToString());


            key = KeySignature.BbMajor;
            var Bb7 = ChordFormulaFactory.Get(NoteName.Bb,
                ChordIntervalsEnum.Dominant7);
            var Eb7 = ChordFormulaFactory.Get(NoteName.Eb,
                ChordIntervalsEnum.Dominant7);

            var result = Bb7.CompareTo(Eb7, true);
            Debug.WriteLine(result.ToString());

        }

        //[TestMethod()]
        //public void GetChordToneFunctionTest()
        //{
        //	var chordTypes = ChordType.Catalog;
        //	foreach (var chordType in chordTypes)
        //	{
        //		var chord = ChordFormulaFactory.Create(NoteName.C, chordType, KeySignature.CMajor);
        //		foreach (var note in NoteName.Catalog)
        //		{
        //			if (chord.Contains(note))
        //			{
        //				var function = chord.GetChordToneFunction(note);
        //				if (function == ChordToneFunctionEnum.None)
        //				{
        //					function = chord.GetChordToneFunction(note);
        //				}
        //				Debug.WriteLine($"{note}'s relationship to {chord.Name}, is {function}");
        //				new object();
        //			}
        //			else
        //			{
        //				var function = chord.GetChordToneFunction(note);
        //				var msg = $"{note}'s relationship to {chord.Name}, is {function}";
        //				Debug.WriteLine($"{note}'s relationship to {chord.Name}, is {function}");
        //				new object();
        //				if (function == ChordToneFunctionEnum.None)
        //				{
        //					function = chord.GetChordToneFunction(note);
        //				}
        //				if (function != ChordToneFunctionEnum.None)
        //				{
        //					function = chord.GetChordToneFunction(note);
        //				}
        //			}
        //		}
        //	}
        //	new object();

        //}


    }//class
}//ns

