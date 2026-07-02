using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper_DryWetMidi;

using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonyHelper_DryWetMidi.Tests
{
    [TestClass()]
    public class MidiSmootherTests
    {
        [TestMethod()]
        public void SmoothMidiFileTest()
        {
            const string SRC_PATH = @"C:\Downloads\B.mid";
            const string DST_PATH = @"C:\Downloads\B_smoothed.mid";

            MidiSmoother.SmoothMidiChords(SRC_PATH, DST_PATH);
        }
    }
}