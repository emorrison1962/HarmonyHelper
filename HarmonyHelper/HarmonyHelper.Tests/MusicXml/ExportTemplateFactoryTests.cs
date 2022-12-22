using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.MusicXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml.Tests
{
    [TestClass()]
    public class ExportTemplateFactoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var model = MusicXmlExportr_ExportTests.Parse();
            var doc = new ExportTemplateFactory().Create(model);
            new object();
        }
}
}