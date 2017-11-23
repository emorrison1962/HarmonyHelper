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

            new object();
            var ict = (int)cte;
            var mask = (int)(IntervalsEnum.Major3rd | IntervalsEnum.Minor3rd);

            var which = (ict & mask);
            var result = (IntervalsEnum)which;

            var interval = ChordTypesEnum.Major.GetThirdInterval();
            //IntervalsEnum GetThird(this ChordTypesEnum e)
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
                var subtrahend = NoteName.C + interval;
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

            var ctx = new ArpeggiationContext(new Chord[] { chord },
                DirectionEnum.Ascending,
                noteRange,
                MAX_NOTES_PER_CHORD, 
                root);

            const int MAX_ITERATIONS = 100;
            Debug.WriteLine(root);
            for (int i = 0; i < MAX_ITERATIONS; ++i)
            {
                var next = chord.GetClosestNoteEx(ctx);
                Debug.WriteLine(string.Format("{0}", next.ToString()));
                ctx.CurrentNote = next;
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
        public void ChordTest()
        {
            foreach (var chord in ChordFormula.Chords)
            {
                Debug.WriteLine(string.Format("{0}7 = {1}", chord.Root.ToString(), chord.ToString()));
                var txedUp = chord + IntervalsEnum.Perfect4th;
                Assert.AreNotEqual(txedUp, chord);
                var txedDown = txedUp - IntervalsEnum.Perfect4th;
                var b = txedDown == chord;
                Assert.AreEqual(txedDown, chord);
            }
            new object();
        }

        [TestMethod()]
        public void IteratorTest()
        {
            foreach (var chord in ChordFormula.Chords)
            {
                var newChord = chord + IntervalsEnum.Perfect5th;
                //Debug.WriteLine(newChord.ToString());
            }
            new object();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            foreach (var chord in ChordFormula.Chords)
            {
                Debug.WriteLine(chord.ToString());
            }
            new object();
        }

        [TestMethod()]
        public void TheCycleTest()
        {
            var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.TwelfthPosition);
            var chordFormula = ChordFormula.C7;
            var chord = new Chord(chordFormula, noteRange);
            var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Perfect4th;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }

            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            ctx.Arpeggiate();

            new object();
        }

        [TestMethod()]
        public void KeySignatureTransposeTest()
        {
            var key = KeySignature.CMajor;
            for (int i = 0; i <= CYCLE_MAX; ++i)
            {
                var a = key.NoteName.ToString();
                var b = key.Normalize(key.NoteName).ToString();
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
                    root = root + IntervalsEnum.Perfect4th;
                    root = key.Normalize(root);
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

            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;


            ctx.Arpeggiate();

            new object();
        }

        [TestMethod()]
        public void TheChickenTest()
        {
            var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
            var chordFormula = ChordFormula.Bb7;
            var chord = new Chord(chordFormula, noteRange);
            var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var chords = new List<Chord>() { chord };
            //for (int i = 0; i <= 16; ++i)
            {
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Eb7, noteRange));
                chords.Add(new Chord(ChordFormula.Eb7, noteRange));
                chords.Add(new Chord(ChordFormula.D7, noteRange));
                chords.Add(new Chord(ChordFormula.G7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
            }



            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            ctx.Arpeggiate();

            new object();
        }

        [TestMethod()]
        public void CycleOfMinor3rdsTest()
        {
            var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
            var chordFormula = ChordFormula.Eb7;
            var chord = new Chord(chordFormula, noteRange);
            var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Minor3rd;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }

            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            ctx.Arpeggiate();

            new object();
        }

        [TestMethod()]
        public void ColtraneChangesTest()
        {
            var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.NinthPosition);
            var chordFormula = ChordFormula.Bb7;
            var chord = new Chord(chordFormula, noteRange);
            var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Major3rd;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }



            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            ctx.Arpeggiate();

            new object();
        }


        private void Ctx_Ending(object sender, ArpeggiationContext e)
        {
            Debug.WriteLine("||");
        }

        private void Ctx_Starting(object sender, ArpeggiationContext e)
        {
            Debug.Write("|");
        }

        private void Ctx_CurrentNoteChanged(object sender, ArpeggiationContext ctx)
        {
            var noteStr = ctx.CurrentNote.ToString(ToStringEnum.Minimal, ctx.Chord.KeySignature);
            noteStr = string.Format("{0,-3}", noteStr);
            Debug.Write(noteStr);
        }

        private void Ctx_DirectionChanged(object sender, ArpeggiationContext ctx)
        {
            const string ASC = "˄";
            const string DESC = "˅";

            var direction = ctx.Direction == DirectionEnum.Ascending ? ASC : DESC;
            Debug.Write(direction);
        }

        int chordCount = 0;
        const int BARS_PER_LINE = 2;
        private void Ctx_ChordChanged(object sender, ArpeggiationContext ctx)
        {
            if (chordCount > 0 && chordCount % BARS_PER_LINE == 0)
                Debug.WriteLine(" |");
            Debug.Write(string.Format(" | ({0}) ", ctx.Chord.Name));
            ++chordCount;
        }

        private void Observe_ArpeggiationContextChanged(object sender, ArpeggiationContext ctx)
        {
        }


    }//class
}//ns

