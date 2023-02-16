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
            var txt = "dm7 g#dim7 c6 dm7 bdim7 c6 dm7 ddim7 c6 dm7 fdim7 c6";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new Dim7ForDom7SubstitutionRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() == 4);
            new object();
        }
    }
}