using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace HarmonyHelperTests.Chords
{
    [TestClass()]
    public class ChordFormulaTests
    {
        [TestMethod()]
        public void ColtraneChangesTest()
        {
            var chordFormula = ChordFormula.BbDominant7;

            for (int i = 0; i <= 10; ++i)
            {
                Debug.WriteLine(chordFormula);
                var txposed = chordFormula - Interval.Major3rd;
                chordFormula = txposed;
                Debug.WriteLine(chordFormula.Name);
            }

            new object();
        }

        [TestMethod()]
        public void GetRelatedKeySignaturesTest()
        {
            var dict = new Dictionary<ChordFormula, HashSet<KeySignature>>();
            foreach (var formula in ChordFormula.Catalog)
            {
                foreach (var key in KeySignature.InternalCatalog)
                {
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula))
                    {
                        if (!dict.ContainsKey(formula))
                            dict[formula] = new HashSet<KeySignature>();
                        dict[formula].Add(key);
                    }
                }
            }

            {
                var keys = new HashSet<ChordFormula>();
                foreach (var key in dict.Keys)
                {
                    keys.Add(key);
                }
            }

            var pairedFormuas = new List<ChordFormula>();
            foreach (var formula in dict.Keys)
            {
                formula.ClearKeys();
                var keySignatures = dict[formula];
                foreach (var keySignature in keySignatures)
                {
                    formula.Add(keySignature);
                }
                pairedFormuas.Add(formula);
            }


            using (var sb = new IndentedTextWriter(new StringWriter()))
            {
                sb.Indent = 2;
                sb.WriteLine(@"static void AddKeys()");
                sb.WriteLine("{");
                sb.Indent = 3;

                foreach (var formula in pairedFormuas)
                {
                    foreach (var key in formula.Keys)
                    {
                        var code = $"ChordFormula.Catalog[\"{formula.Name}\"].Add(KeySignature.Catalog[\"{key.Name}\"]);";
                        sb.WriteLine(code);
                    }
                }

                sb.Indent = 2;
                sb.WriteLine("}");

                Debug.WriteLine(sb.InnerWriter.ToString());
            }

            new object();
        }

        [TestMethod()]
        public void TheCycleTest()
        {
            var formulas = new List<ChordFormula>();
            NoteName root = null;
            ChordIntervalsEnum chordType = ChordIntervalsEnum.None;
            const int CYCLE_MAX = 12 - 1;
            for (int i = 0; i <= CYCLE_MAX; ++i)
            {
                if (null == root)
                {
                    root = NoteName.G;
                    chordType = ChordIntervalsEnum.Dominant7;
                }
                else
                {
                    chordType = ChordIntervalsEnum.Dominant7;
                    var copy = root.Copy();

                    //before: G♭
                    // after: C♭

                    Debug.WriteLine($"before: {root}");
                    if (root.Name == "G♭")
                        new object();
                    root += Interval.Perfect4th;
                    Debug.WriteLine($" after: {root}");
                    if (root.ExplicitValue.HasFlag(NoteName.ExplicitNoteValuesEnum.DoubleFlat)
                        || root.ExplicitValue.HasFlag(NoteName.ExplicitNoteValuesEnum.DoubleSharp))
                    {
                        new object();
                        var xx = copy + Interval.Perfect4th;
                    }
                }

                var formula = ChordFormulaFactory.Get(root, chordType);
                formulas.Add(formula);
            }

            Debug.WriteLine(string.Join(" | ", formulas));
            new object();
        }

    }//class
}//ns
