using System;
using System.Diagnostics;

using Eric.Morrison.Harmony.MusicXml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Enums
{
    [TestClass]
    public class EnumsTests
    {
        [TestMethod]
        public void EnumTests()
        {
            ChordIntervalsEnum chordTypeEnum = ChordIntervalsEnum.Dominant11b9;

            var isDominant = false;
            var isAltered = false;

            if (chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalMajor3rd)
                && chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalMinor7th))
            {
                isDominant = true;
            }
            Assert.IsTrue(isDominant);

            if (isDominant)
            {
                if (chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalDiminished5th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalAugmented5th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat9th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalSharp9th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat11th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalAugmented11th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat13th)
                    )
                {
                    isAltered = true;
                }
            }
            Assert.IsTrue(isAltered);

            new object();
        }
    }//class
}//ns
