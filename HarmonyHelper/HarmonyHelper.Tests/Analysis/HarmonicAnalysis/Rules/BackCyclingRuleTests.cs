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
    public class BackCyclingRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "dm7 d7 g7 cMaj7 dm7b5 d7 g7 cm7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new BackCyclingRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count());
            new object();
        }
    }
}