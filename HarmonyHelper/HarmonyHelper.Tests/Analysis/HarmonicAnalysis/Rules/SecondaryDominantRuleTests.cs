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
            var txt = "g7 c7 f7 bb7 eb7 abmaj7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new SecondaryDominantRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() == 4);
            new object();

        }
    }
}