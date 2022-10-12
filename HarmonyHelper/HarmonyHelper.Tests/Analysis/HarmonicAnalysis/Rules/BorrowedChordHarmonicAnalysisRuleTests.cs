using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Analysis.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Chords;
using System.Diagnostics;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class BorrowedChordHarmonicAnalysisRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "Bb6 Gm7 Cm7 F7 Bb6 Gm7 Cm7 F7 Bb6 Bb7 Eb6 Ebm7 Bb6 Gm7 Cm7 F7";
            var chords = ChordFormulaParser.Parse(txt);

            var rule = new BorrowedChordHarmonicAnalysisRule();
            var results = rule.Analyze(chords);

            Assert.IsNotNull(results);
#if false
• B♭7 could be considered a borrowed chord from the parallel B♭ Mixolydian mode in E♭ Major.
• B♭7 could be considered a borrowed chord from the parallel B♭ Melodic Minor Overtone Scale mode in F Major.
• E♭m7 could be considered a borrowed chord from the parallel B♭ Aeolian mode in D♭ Major.
• E♭m7 could be considered a borrowed chord from the parallel B♭ Hermonic Minor Harmonic Minor mode in B♭ Major.
#endif
            Assert.IsTrue(results.Count() == 2);
            new object();
        }
    }
}