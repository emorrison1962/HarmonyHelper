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
        public void fooTest()
        {
            var tc = new TimeContext(1, 480, 0, 120);
            var whole = tc.Whole;
            var dotHalf = tc.DottedHalf;
            var half = tc.Half;
            var dotQuarter = tc.DottedQuarter;
            var quarter = tc.Quarter;

            Assert.IsTrue(tc.Whole > tc.DottedHalf);
            Assert.IsTrue(tc.DottedHalf > tc.Half);
            Assert.IsTrue(tc.Half > tc.DottedQuarter);
            Assert.IsTrue(tc.DottedQuarter > tc.Quarter);
            Assert.IsTrue(tc.Quarter > tc.DottedEighth);
            Assert.IsTrue(tc.DottedEighth > tc.Eighth);
            Assert.IsTrue(tc.Eighth > tc._16th);
            Assert.IsTrue(tc._16th > tc._32nd);
            Assert.IsTrue(tc._32nd > tc._64th);
            Assert.IsTrue(tc._64th > tc._128th);
            Assert.IsTrue(tc._128th > tc._256th);
            //Assert.IsTrue(tc._256th > tc._512th);
            //Assert.IsTrue(tc._512th > tc._1024th);

            tc.TryGetName(tc.DottedEighth, out var name, out var isDotted);

            new object();
        }

        [TestMethod()]
        public void CopyWithOffsetTest()
        {
            var tc = new TimeContext(1, 480, 0, 240);
            var result = TimeContext.CopyWithOffset(tc, 3);
            Assert.IsTrue(tc.MeasureNumber == 1);
            Assert.IsTrue(tc.PulsesPerMeasure == 480);
            Assert.IsTrue(tc.RelativeStart == 0);
            Assert.IsTrue(tc.RelativeEnd == 240);

            Assert.IsTrue(!tc.Equals(result));

            Assert.IsTrue(result.MeasureNumber == 4);
            Assert.IsTrue(result.PulsesPerMeasure == 480);
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
            var measures = new List<int>() { 1, 3, 5, 7, 13 };
            var starts = new List<int>() { 0, 120, 240, 300, 420 };
            var durations = new List<int>() { 60, 120, 240, 300, 360 };
            var tc = new TimeContext(1, 480);



            for (int i = 0; i < measures.Count; ++i) 
            {
                var add = new TimeContext(measures[i], 480, starts[i], durations[1]);
                var result = tc + add;
                new object();
            }
        }

    }//class
}//ns