using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.MusicXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml.Tests
{
    [TestClass()]
    public class MusicXmlMeasureTests
    {
        [TestMethod()]
        public void AddOffsetTest()
        {
            var rhythm = new RhythmicContext()
                .SetTimeSignature(new TimeSignature(4, 4))
                .SetPulsesPerQuarterNote(120);
            new TimeContext.CreationContext()
            { MeasureNumber = 1, Rhythm = rhythm, RelativeStart = 0, RelativeEnd = 240 };


            var chords = new List<TimedEventChordFormula>() { 
                new TimedEventChordFormula(ChordFormula.CMaj7, new TimeContext(1, rhythm, 120, 240)) };
            var part = new MusicXmlPart(PartTypeEnum.Harmony);
            var measure = new MusicXmlMeasure(part, 1, chords, null, null, null, null);
            measure.SetMeasureNumber(2);

            var chord = measure.Chords.First();
            Assert.IsTrue(measure.Chords.First().TimeContext == new TimeContext(3, rhythm, 120, 240));
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