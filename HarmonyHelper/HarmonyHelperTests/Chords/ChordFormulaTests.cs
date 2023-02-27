﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            new object();
        }

    }//class
}//ns
