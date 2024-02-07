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
using Newtonsoft.Json;
using static Eric.Morrison.Harmony.HarmonicAnalysis.Rules.BorrowedChordHarmonicAnalysisRule;
using System.Reflection;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using HarmonyHelper.Utilities;
using Eric.Morrison.Harmony;

namespace HarmonicAnalysis.Rules.Tests
{
    [TestClass()]
    public class BorrowedChordHarmonicAnalysisRuleTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var txt = "Bb6 Gm7 Cm7 F7 Bb6 Gm7 Cm7 F7 Bb6 Bb7 Eb6 Ebm7 Bb6 Gm7 Cm7 F7";
            var chords = ChordFormulaParser.Parse(txt);

            List<HarmonicAnalysisResult> results = null;
            using (new TimedLogger(MethodBase.GetCurrentMethod().Name))
            {
                var rule = new BorrowedChordHarmonicAnalysisRule();
                results = rule.Analyze(chords);
            }

            Assert.IsNotNull(results);
#if false
• B♭7 could be considered a borrowed chord from the parallel B♭ Mixolydian mode in E♭ Major.
• B♭7 could be considered a borrowed chord from the parallel B♭ Melodic Minor Overtone Scale mode in F Major.
• E♭m7 could be considered a borrowed chord from the parallel B♭ Aeolian mode in D♭ Major.
• E♭m7 could be considered a borrowed chord from the parallel B♭ Harmonic Minor Harmonic Minor mode in B♭ Major.
#endif
            Assert.IsTrue(results.Count() == 2);
            new object();
        }

        [TestMethod()]
        public void GridsTest()
        {
            var rule = new BorrowedChordHarmonicAnalysisRule();
            var grids = rule.CreateGrids(KeySignature.CMajor);
            foreach (var grid in grids)
            {
                var rowCount = grid.Rows.Count;
                for (int ndxRow = 0; ndxRow < rowCount; ++ndxRow)
                {
                    var row = grid.Rows[ndxRow];
                    var chordCount = row.Chords.Count;
                    for (int ndxChord = 0; ndxChord < chordCount; ++ndxChord)
                    {
                        var chord = row.Chords[ndxChord];
                        Debug.Write(chord);

                        //parent.Controls.Add(new Label() { Text = chord.Name }, ndxChord, ndxRow);
                    }


                    var chords = row.Chords.Select(x => x.Name).ToList();
                    var s = $"{row.ModeName} | {chords[0]} | {chords[1]} | {chords[2]} | {chords[3]} | {chords[4]} | {chords[5]} | {chords[6]} | ";


                    Debug.WriteLine(s);
                    new object();
                }
                new object();
                //parent.Refresh();
                //parent.PerformLayout();
            }

            new object();
        }

    }//class
}//ns