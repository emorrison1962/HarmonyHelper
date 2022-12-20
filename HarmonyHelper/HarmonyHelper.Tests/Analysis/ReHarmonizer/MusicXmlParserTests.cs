using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony.Tests
{
    [TestClass()]
    public class MusicXmlParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            //path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "TEST_FILES");
            path = Path.Combine(path, "Superstition_Stevie_Wonder 121922.XML");
            Debug.WriteLine(path);
            Debug.Assert(File.Exists(path));

            var parser = new MusicXmlParser();
            var result = parser.Parse(path);

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