using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class ii_V_RuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "dm7 g7 cm7 f7 bbm7b5 eb7";
            var chords = ChordFormulaParser.Parse(txt); 
            
            var rule = new ii_V_Rule();
            var results = rule.Analyze(chords);
            
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
            new object();
        }
    }
}