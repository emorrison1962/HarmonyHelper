using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.MusicXml;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml.Tests
{
    [TestClass()]
    public class TimeContextTests
    {
        [TestMethod()]
        public void CopyWithOffsetTest()
        {
            var tc = new TimeContext()
                .SetRhythmicContext(new RhythmicContext()
                    .SetPulsesPerMeasure(480))
                .SetMeasureNumber(1)
                .SetRelativeStart(0)
                .SetRelativeEnd(240);

            var result = TimeContext.CopyWithOffset(tc, 3);
            Assert.IsTrue(tc.MeasureNumber == 1);
            Assert.IsTrue(tc.Rhythm.PulsesPerMeasure == 480);
            Assert.IsTrue(tc.RelativeStart == 0);
            Assert.IsTrue(tc.RelativeEnd == 240);

            Assert.IsTrue(!tc.Equals(result));

            Assert.IsTrue(result.MeasureNumber == 4);
            Assert.IsTrue(result.Rhythm.PulsesPerMeasure == 480);
            Assert.IsTrue(result.RelativeStart == 0);
            Assert.IsTrue(result.RelativeEnd == 240);
        }

        [TestMethod()]
        public void TryGetNameTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void AdditionOperatorTest()
        {
        }

    }//class
}//ns