using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Analysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.Tests
{
    [TestClass()]
    public class MelodyToHarmonyAnalyzerTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var s = "d e e d g e";
            var song = new List<List<NoteName>>();
            var notes = new List<NoteName> { NoteName.E, NoteName.G, NoteName.A, NoteName.B, NoteName.D };
            song.Add(notes);
            var result = new MelodyToHarmonyAnalyzer().Analyze(song);
            new object();
        }
    }
}