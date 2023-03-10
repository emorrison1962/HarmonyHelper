using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;

namespace Analysis.HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class BackDoor_ii_V_RuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "dm7 g7 aMaj7 dm7b5 g7 am7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new BackDoor_ii_V_Rule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count());
            new object();
        }
    }
}