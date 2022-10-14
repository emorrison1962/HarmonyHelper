using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Tests
{
    [TestClass()]
    public class MusicXmlParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            var result = new MusicXmlParser().Parse(null);

            Assert.IsNotNull(result);
            foreach (var part in result.Parts)
            {
                Assert.IsNotNull(part);
                foreach (var measure in part.Measures)
                {
                    Assert.IsNotNull(measure);
                    foreach (var note in measure.Notes)
                    {
                        Assert.IsNotNull(note);
                    }
                    foreach (var chord in measure.Chords)
                    {
                        Assert.IsNotNull(chord);
                    }
                }
            }


            var debug = result.Get(4, 0, 0);

            new object();
        }
    }
}