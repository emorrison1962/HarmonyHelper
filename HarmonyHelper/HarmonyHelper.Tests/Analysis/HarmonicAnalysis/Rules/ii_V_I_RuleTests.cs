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
    public class ii_V_I_RuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            ChordFormulaParser.TryParse("cmaj7 bm7b5 e7 am7 d7 gm7 c7 f7 fm7 bb7 ebm7 ab7 dm7 g7 cmaj7 a7 dm7 g7", out var key, out var formulas, out var msg);
#if false
cmaj7 
* bm7b5 e7 am7 
d7 gm7 c7 f7 fm7 bb7 ebm7 ab7 
* dm7 g7 cmaj7 
a7 dm7 g7"
#endif

            var rule = new ii_V_I_Rule();
            var results1 = rule.Analyze(formulas, key);
            var results = rule.Analyze(formulas);
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);  

            Assert.Fail();
        }
    }
}