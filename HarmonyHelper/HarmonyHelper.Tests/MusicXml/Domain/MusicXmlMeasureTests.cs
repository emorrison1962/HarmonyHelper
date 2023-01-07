using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.MusicXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.MusicXml.Tests
{
    [TestClass()]
    public class MusicXmlMeasureTests
    {
        [TestMethod()]
        public void AddOffsetTest()
        {
            var chords = new List<TimedEvent<ChordFormula>>() { 
                new TimedEvent<ChordFormula>(ChordFormula.CMaj7, new TimeContext(1, 480, 120, 240)) };
            var measure = new MusicXmlMeasure(1, chords, null, null, null, null);
            measure.AddOffset(new TimeContext(2));

            var chord = measure.Chords.First();
            Assert.IsTrue(measure.Chords.First().TimeContext == new TimeContext(3, 480, 120, 240));
        }

        [Ignore]
        [TestMethod()]
        public void GetMergedEventsTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void CreateChordMelodyPairingsTest()
        {
            Assert.Fail();
        }

    }//class
}//ns