using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

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

            var interval = ChordTypesEnum.Major.Get3rd();
            //IntervalsEnum GetThird(this ChordTypesEnum e)
        }


        [TestMethod()]
        public void FindClosestNoteTest()
        {
            //var chordFormula = ChordFormula.A7;
            //var startingNote = chordFormula.Root;
            var lowerLimit = new Note(NotesEnum.C, OctaveEnum.Octave0);
            var upperLimit = new Note(NotesEnum.B, OctaveEnum.Octave6);
            var noteRange = new NoteRange(lowerLimit, upperLimit);

            //var chord = new Chord(chordFormula, noteRange);
            var root = new Note(NotesEnum.A, OctaveEnum.Octave0);
            var third = new Note(NotesEnum.B, OctaveEnum.Octave0);
            var fifth = new Note(NotesEnum.C, OctaveEnum.Octave0);
            var seventh = new Note(NotesEnum.D, OctaveEnum.Octave0);
            var chord = new Chord(root, third, fifth, seventh, noteRange);

            const int MAX_NOTES_PER_CHORD = 8;

            var ctx = new ArpeggiationContext(chord,
                DirectionEnum.Ascending,
                root,
                noteRange,
                MAX_NOTES_PER_CHORD);

            const int MAX_ITERATIONS = 100;
            Debug.WriteLine(root);
            for (int i = 0; i < MAX_ITERATIONS; ++i)
            {
                var next = chord.GetClosestNoteEx(ctx);
                Debug.WriteLine(next.ToString(ToStringEnum.Minimal));
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
                var newChord = chord + IntervalsEnum.Perfect4th;
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

            var ctx = new ArpeggiationContext(chord,
                DirectionEnum.Ascending,
                startingNote,
                noteRange, notesToPlay);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Perfect4th;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }

            ctx.Arpeggiate(chords);

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

            var ctx = new ArpeggiationContext(chord,
                DirectionEnum.Ascending,
                startingNote,
                noteRange, notesToPlay);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

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

            ctx.Arpeggiate(chords);

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

            var ctx = new ArpeggiationContext(chord,
                DirectionEnum.Ascending,
                startingNote,
                noteRange, notesToPlay);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Minor3rd;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }

            ctx.Arpeggiate(chords);

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

            var ctx = new ArpeggiationContext(chord,
                DirectionEnum.Ascending,
                startingNote,
                noteRange, notesToPlay);

            ctx.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Ctx_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;

            var chords = new List<Chord>() { chord };
            for (int i = 0; i <= 10; ++i)
            {
                chordFormula = chordFormula + IntervalsEnum.Major3rd;
                chord = new Chord(chordFormula, noteRange);
                chords.Add(chord);
            }

            ctx.Arpeggiate(chords);

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
            Debug.Write(string.Format(" | ({0}7) ", ctx.Chord.Root.ToString(ToStringEnum.Minimal)));
            ++chordCount;
        }

        private void Observe_ArpeggiationContextChanged(object sender, ArpeggiationContext ctx)
        {
        }


    }//class
}//ns

