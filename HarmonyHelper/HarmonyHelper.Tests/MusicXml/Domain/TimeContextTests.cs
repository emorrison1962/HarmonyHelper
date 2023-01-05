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
            var ts = new TimeSignature(4, 4);
            var tc = new TimeContext(ts, 1, 480, 0, 120);
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
    }
}