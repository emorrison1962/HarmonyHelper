using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Chords.NegativeHarmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;

namespace HarmonyHelper.Chords.NegativeHarmony.Tests
{
    [TestClass()]
    public class ModesMirrorTests
    {
        [TestMethod()]
        public void GetMirrorTest()
        {
            var ks = KeySignature.CMajor;
            var actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.C);
            Assert.AreEqual(NoteName.G, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.D);
            Assert.AreEqual(NoteName.F, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.E);
            Assert.AreEqual(NoteName.DSharp, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.F);
            Assert.AreEqual(NoteName.D, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.G);
            Assert.AreEqual(NoteName.C, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.A);
            Assert.AreEqual(NoteName.ASharp, actual);

            actual = new NegativeHarmonyMirror().GetMirror(ks, NoteName.B);
            Assert.AreEqual(NoteName.GSharp, actual);
            new object();
        }
    }
}