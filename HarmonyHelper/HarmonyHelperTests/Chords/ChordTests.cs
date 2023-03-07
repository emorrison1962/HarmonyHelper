using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.Intervals;

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
            var chord = new Chord(noteRange, root, third, fifth, seventh);

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
                var closestNoteCtx = new Chord.ClosestNoteContext(arpeggiator);
                chord.GetClosestNote(closestNoteCtx);
                var next = closestNoteCtx.ClosestNote;
                Debug.WriteLine(string.Format("{0}", next.ToString()));
                arpeggiator.CurrentNote = next;
            }
            new object();
        }


        [TestMethod()]
        public void Gb7ModulationTest()
        {
            var chord = ChordFormula.Catalog.First(x => x.Root == NoteName.Gb && x.ChordType == ChordType.Dominant7th);
            Debug.WriteLine(string.Format("{0}7 = {1}", chord.Root.ToString(), chord.ToString()));
            var origKey = chord.Keys.First();
            var txedUp = chord + Interval.Perfect4th;
            Assert.AreNotEqual(txedUp, chord);
            var txedDown = txedUp - Interval.Perfect4th;
            var b = txedDown == chord;
            Assert.AreEqual(txedDown, chord);
            new object();
        }


        [TestMethod()]
        public void ChordTest()
        {
            ChordFormula currentChord = null;
            try
            {
                foreach (var origChord in ChordFormula.Catalog)
                {
                    currentChord = origChord;
                    if (origChord.Keys.Count() > 0)
                    {
                        if (ChordFormula.Catalog.ToList().Any(x => x.Name == origChord.Name))
                        {
                            Debug.WriteLine($"{origChord.ToString()}");

                            var origKey = origChord.Keys.First();

                            var txedUp = origChord + Interval.Perfect4th;
                            Assert.IsNotNull( txedUp );
                            Assert.AreNotEqual(txedUp, origChord);

                            if (txedUp.Keys.Any())
                            {
                                var txedDown = txedUp - Interval.Perfect4th;
                                var b = txedDown == origChord;
                                Assert.AreEqual(txedDown, origChord);
                            }
                        }
                        else
                        {
                            Assert.Fail();
                        }
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
                ChordType.Minor7th,
                key);
            var G7 = ChordFormulaFactory.Get(NoteName.G,
                ChordType.Dominant7th,
                key);

            //var result = Dm.CompareTo(G7, true);
            //Debug.WriteLine(result.ToString());


            key = KeySignature.BbMajor;
            var Bb7 = ChordFormulaFactory.Get(NoteName.Bb,
                ChordType.Dominant7th,
                key);
            var Eb7 = ChordFormulaFactory.Get(NoteName.Eb,
                ChordType.Dominant7th,
                key);

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

