using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Harmony.MusicXml;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml.Tests
{
    [TestClass()]
    public class MusicXmlExport_ExportTests
    {
        static string TEST_FILES_PATH
        {
            get
            {
                var path = Assembly.GetExecutingAssembly().Location;
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.GetDirectoryName(path);
                path = Path.Combine(path, "TEST_FILES");
                return path;
            }
        }

        [TestMethod()]
        public void ExportTest()
        {
            //foreach (var ct in ChordType.Catalog)
            //{ 
            //    Debug.WriteLine(ct.Name);
            //}


            var path = TEST_FILES_PATH;
            path = Path.Combine(path, "Superstition_Stevie_Wonder 121922.XML");
            var model = Parse(path);
            var doc = new MusicXmlExporter().Export(model);

            var folder = @"c:\temp\MusicXml";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filename = $@"{DateTime.Now.ToString("MMddyy-hhmmss")}.xml";
            filename = "000000-000000.xml";
            var dstPath = Path.Combine(folder, filename);
            doc.Save(dstPath);
            new object();
        }

        static public MusicXmlModel Parse(string path)
        {
            Debug.Assert(File.Exists(path));

            var parser = new MusicXmlImporter();
            var result = parser.Import(path);

            return result;
        }

        [TestMethod()]
        public void foo()
        {
            var path = TEST_FILES_PATH;
            path = Path.Combine(path, "Untitled score-Piano.xml");

            var model = Parse(path);
            var doc = new MusicXmlExporter().Export(model);

            var filename = $@"{DateTime.Now.ToString("MMddyy-hhmmss")}.xml";
            filename = "000000-000002.xml";
            var dstPath = Path.Combine(TEST_FILES_PATH, filename);
            doc.Save(dstPath);
            new object();
        }

    }//class

}//ns