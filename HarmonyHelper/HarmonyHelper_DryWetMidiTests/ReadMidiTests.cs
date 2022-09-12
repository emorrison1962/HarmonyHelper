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
            reader.Open();

            //Assert.Fail();
        }
    }
}