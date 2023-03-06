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

namespace HarmonyHelperTests.Chords
{
    [TestClass()]
    public class ChordFormulaTests
    {
        [TestMethod()]
        public void ColtraneChangesTest()
        {
            var chordFormula = ChordFormula.Bb7;

            for (int i = 0; i <= 10; ++i)
            {
                chordFormula -= Interval.Major3rd;
                Debug.WriteLine(chordFormula.Name);
            }

            new object();
        }

        [TestMethod()]
        public void GetRelatedKeySignaturesTest()
        {
            var dict = new Dictionary<ChordFormula, HashSet<KeySignature>> ();
            foreach (var formula in ChordFormula.Catalog) 
            {
                //if (formula.Keys.Count == 0)
                //{ 
                //    new object();
                //}
                foreach (var key in KeySignature.InternalCatalog)
                {
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
                    if (null != key)
                    {
                        formula.Keys.Add(key);
                        //Debug.WriteLine($"\t{key.Name}");
                    }
                }
                pairedFormuas.Add(formula);

            }

            foreach (var formula in pairedFormuas)
            {
                var settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                var json = JsonConvert.SerializeObject(formula, settings);
                var serialized = JsonConvert.DeserializeObject<ChordFormula>(json, settings);

                foreach (var key in formula.Keys)
                {
                    var code = $"ChordFormula.Catalog[\"{formula.Name}\"].Keys.Add(KeySignature.Catalog[\"{key.Name}\"]);";
                    Debug.WriteLine (code);
                }

                Assert.AreEqual(formula, serialized);
                new object();


                new object();
            }

            new object();
        }

    }//class
}//ns
