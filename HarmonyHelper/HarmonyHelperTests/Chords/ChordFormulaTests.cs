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
            //ChordFormula.Catalog["Cdim"].Add(KeySignature.Catalog["C♯ Major"]);
            var dict = new Dictionary<ChordFormula, HashSet<KeySignature>> ();
            foreach (var formula in ChordFormula.Catalog) 
            {
                foreach (var key in KeySignature.InternalCatalog)
                {
                    if (formula.NameAscii == "Cdim" && key.NameAscii == "C# Major")
                        new object();
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula))
                    {
                        if (!dict.ContainsKey(formula))
                        {
                            dict[formula] = new HashSet<KeySignature>();
                        }
                        dict[formula].Add(key);
                    }
                }
            }

            var unpaired = new HashSet<ChordFormula> ();
            var formulas = ChordFormula.Catalog.ToList();
            foreach (var formula in formulas)
            {
                if (!dict.Keys.Contains(formula))
                { 
                    unpaired.Add(formula);
                }
            }

            //foreach (var formula in unpaired)
            //{ 
            //    Debug.WriteLine(formula.Name);
            //}

            var pairedFormuas = new List<ChordFormula>();
            foreach (var formula in dict.Keys)
            {
                //Debug.WriteLine($"{formula.Name}");

                var keys = dict[formula];
                foreach (var key in keys)
                {
                    if (formula.NameAscii == "Cdim" && key.NameAscii == "C# Major")
                        new object();
                    if (null != key)
                    {
                        formula.Add(key);
                        //Debug.WriteLine($"\t{key.Name}");
                    }
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
                    //var settings = new JsonSerializerSettings();
                    //settings.Formatting = Formatting.Indented;
                    //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //var json = JsonConvert.SerializeObject(formula, settings);
                    //var serialized = JsonConvert.DeserializeObject<ChordFormula>(json, settings);
                    //Assert.AreEqual(formula, serialized);
                    //new object();



                    foreach (var key in formula.Keys)
                    {
                        var code = $"ChordFormula.Catalog[\"{formula.Name}\"].Add(KeySignature.Catalog[\"{key.Name}\"]);";
                        sb.WriteLine(code);
                    }
                    new object();
                }

                sb.Indent = 2;
                sb.WriteLine("}");

                Debug.WriteLine(sb.InnerWriter.ToString());
            }

            new object();
        }

    }//class
}//ns
