using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class BorrowedChordHarmonicAnalysisRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "Bb6 Gm7 Cm7 F7 Bb6 Gm7 Cm7 F7 Bb6 Bb7 Eb6 Ebm7 Bb6 Gm7 Cm7 F7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new BorrowedChordHarmonicAnalysisRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() == 4);
            new object();
        }
    }
}