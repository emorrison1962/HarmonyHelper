using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Analysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Notes;
using System.Diagnostics;
using Eric.Morrison.Harmony;

namespace Analysis.Tests
{
    [TestClass()]
    public class MelodyToHarmonyAnalyzerTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var song = new List<List<NoteName>>();

            var s = "d e e d g e";
            NoteNameParser.TryParse(s, out var notes, out var msg);

            song.Add(notes);
            var result = new MelodyToHarmonyAnalyzer().Analyze(song);
            foreach (var bar in result)
            {
                foreach (var chord in bar.OrderBy(x => x.Name))
                {
                    Debug.WriteLine(chord);
                }
            }
            new object();
        }
    }
}