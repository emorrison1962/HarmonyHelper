using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper_DryWetMidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace HarmonyHelper_DryWetMidi.Tests
{
    [TestClass()]
    public class ReadMidiTests
    {
        [TestMethod()]
        public void OpenTest()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);

            path = Path.Combine(path, "TEST_FILES");
            path = Path.Combine(path, "Superstition.mid");

            var reader = new MidiFileConverter(path);

            //Assert.Fail();
        }
    }
}