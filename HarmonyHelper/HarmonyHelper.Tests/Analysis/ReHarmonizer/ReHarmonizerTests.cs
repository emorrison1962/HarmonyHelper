using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.Analysis.ReHarmonizer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.MusicXml;
using System.IO;
using System.Reflection;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer.Tests
{
    [TestClass()]
    public class ReHarmonizerTests
    {
        [TestMethod()]
        public void ReHarmonizeTest()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);

            path = Path.Combine(path, "TEST_FILES");
            path = Path.Combine(path, "Superstition_Stevie_Wonder 121922.XML");
            var parser = new MusicXmlImporter();
            var model = parser.Import(path);
            model.CreateSections(new MusicXmlModel.SectionContext(16, 5));

            new ReHarmonizer().ReHarmonize(model);

        }
    }
}