using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Chords.Negative_Harmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using HarmonyHelper.Chords.NegativeHarmony;
using System.Diagnostics;

namespace HarmonyHelper.Chords.Negative_Harmony.Tests
{
    [TestClass()]
    public class CircleOfFifthsTests
    {
        [TestMethod()]
        public void CircleOfFifthsTest()
        {
            new CircleOfFifths(NoteName.C);
            new object();
        }

        [TestMethod()]
        public void CircleOfChromaticsTest()
        {
            var coc = new CircleOfChromatics(KeySignature.CMajor);
            foreach (var nn in coc.Notes)
            { 
                Debug.WriteLine(nn);
            }

            new object();
        }

    }//class
}