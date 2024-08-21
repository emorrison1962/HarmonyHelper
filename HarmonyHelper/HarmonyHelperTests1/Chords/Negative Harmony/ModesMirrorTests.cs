using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Chords.NegativeHarmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

namespace HarmonyHelper.Chords.NegativeHarmony.Tests
{
    [TestClass()]
    public class ModesMirrorTests
    {
        [TestMethod()]
        public void GetMirrorTest()
        {
            var ks = KeySignature.CMajor;
            var actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.C);
            Assert.AreEqual(NoteName.G, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.D);
            Assert.AreEqual(NoteName.F, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.E);
            Assert.AreEqual(NoteName.DSharp, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.F);
            Assert.AreEqual(NoteName.D, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.G);
            Assert.AreEqual(NoteName.C, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.A);
            Assert.AreEqual(NoteName.ASharp, actual);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, NoteName.B);
            Assert.AreEqual(NoteName.GSharp, actual);
            new object();
        }

        [TestMethod()]
        public void GetMirrorChordTest()
        {
            var ks = KeySignature.CMajor;
            var actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.C, ChordIntervalsEnum.Major7));
            Assert.AreEqual(ChordIntervalsEnum.Minor6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.D, ChordIntervalsEnum.Minor7));
            Assert.AreEqual(ChordIntervalsEnum.Major6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.E, ChordIntervalsEnum.Minor7));
            Assert.AreEqual(ChordIntervalsEnum.Major6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.F, ChordIntervalsEnum.Major7));
            Assert.AreEqual(ChordIntervalsEnum.Minor6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.G, ChordIntervalsEnum.Dominant7));
            Assert.AreEqual(ChordIntervalsEnum.Minor6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.A, ChordIntervalsEnum.Minor7));
            Assert.AreEqual(ChordIntervalsEnum.Major6, actual.ChordType);

            actual = new NegativeHarmonyMirror().GetMirrored(ks, ChordFormulaFactory.Get(NoteName.B, ChordIntervalsEnum.HalfDiminished));
            Assert.AreEqual(ChordIntervalsEnum.Minor6, actual.ChordType);

            new object();
        }

    }//class
}//ns