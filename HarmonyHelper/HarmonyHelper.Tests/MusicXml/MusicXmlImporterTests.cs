﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class MusicXmlImporterTests
    {
        string TEST_FILES_PATH
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
        public void ImportTest()
        {
            var path = Path.Combine(TEST_FILES_PATH, "Superstition_Stevie_Wonder 121922.XML");

            Debug.WriteLine(path);
            Debug.Assert(File.Exists(path));

            
            var parser = new MusicXmlImporter();

            var sctx = new SectionContext(2, 16, 4);
            var cctx = new MusicXmlModelCreationContext(path, sctx, "P1", "P2");
            var result = parser.Import(cctx);

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


            //var debug = result.Get(new TimeContext(4));

            new object();
        }
    }
}