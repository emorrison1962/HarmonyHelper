using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;

namespace HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class ii_V_I_RuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        { 
            var chords = ChordFormulaParser.Parse("bm7b5 e7 am7 dm7 g7 cmaj7");

            var rule = new ii_V_I_Rule();
            var results = rule.Analyze(chords);
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);  
        }
    }
}