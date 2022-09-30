using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper_DryWetMidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper_DryWetMidi.Tests
{
    [TestClass()]
    public class ReadMidiTests
    {
        [TestMethod()]
        public void OpenTest()
        {
            var reader = new MidiFileConverter();
            //const string MIDI_FILE = @"C:\Users\Eric\Documents\MuseScore3\Scores\Superstition.mid";
            const string MIDI_FILE = @"C:\Users\emorrison\Downloads\Superstitions.mid";
            reader.Open(MIDI_FILE);

            //Assert.Fail();
        }
    }
}