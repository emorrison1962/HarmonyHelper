using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Chords.Negative_Harmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using HarmonyHelper.Chords.NegativeHarmony;

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
    }
}