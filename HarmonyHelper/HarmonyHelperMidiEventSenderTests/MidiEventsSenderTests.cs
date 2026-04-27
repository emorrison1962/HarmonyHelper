using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using HarmonyHelper_DryWetMidi;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonyHelper_DryWetMidi.Tests
{
    [TestClass()]
    public class MidiEventsSenderTests
    {
        [TestMethod()]
        public void MidiEventsSenderTest()
        {
            using var sender = new MidiEventsSender();
        }

        [TestMethod()]
        public void PlayNoteTest()
        {
            using var sender = new MidiEventsSender();
            var note = new Note(NoteName.C, OctaveEnum.Octave4);
            sender.Play(note);
            Task.Delay(1000).Wait();
            sender.Stop(note);
            new object();
        }

        [TestMethod()]
        public void StopTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PlayChordTest()
        {
            using var sender = new MidiEventsSender();
            var formula = ChordFormula.Catalog
                .Where(cf => cf.ChordType == ChordIntervalsEnum.Major 
                    && cf.Root == NoteName.C).First();
            var chord = new Chord(formula, new NoteRange(new Note(NoteName.C, OctaveEnum.Octave4),
                new Note(NoteName.C, OctaveEnum.Octave5)));
            sender.Play(chord);
            Task.Delay(1000).Wait();
            sender.Stop(chord);
            new object();
        }

        [TestMethod()]
        public void StopTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TurnAllNotesOffTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}