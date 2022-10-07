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
    public class DiatonicToKeyRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            {
                var txt = "cmaj7 dm7 em7 fmaj7 g7 am7 bm7b5";
                var chords = ChordFormulaParser.Parse(txt);

                var rule = new DiatonicToKeyRule();
                var results = rule.Analyze(chords);

                Assert.IsNotNull(results);
                Assert.AreEqual(1, results.Count());
                Assert.IsTrue(results[0].Success);
                new object();
            }
            {// A harmonic minor. UGH.
                var txt = "amMaj7 bm7b5 cmaj7#5 dm7 e7 fmaj7 gm7";
                var chords = ChordFormulaParser.Parse(txt);

                var rule = new DiatonicToKeyRule();
                var results = rule.Analyze(chords);

                Assert.IsNotNull(results);
                Assert.AreEqual(2, results.Count());
                Assert.Fail();
                new object();
            }
        }
    }
}