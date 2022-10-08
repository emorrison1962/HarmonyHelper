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
    public class SecondaryDominantRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            Assert.Fail();
            var txt = "dm7 db7 c6";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new TritoneSubstitutionRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() == 1);
            new object();

        }
    }
}