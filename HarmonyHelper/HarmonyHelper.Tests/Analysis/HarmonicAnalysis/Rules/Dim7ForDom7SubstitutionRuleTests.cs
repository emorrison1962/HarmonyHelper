using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class Dim7ForDom7SubstitutionRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "dm7 dbdim7 cmaj7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new Dim7ForDom7SubstitutionRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count());
            Assert.IsTrue(results[0].Success);
            new object();
        }
    }
}