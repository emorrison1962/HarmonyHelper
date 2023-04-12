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

namespace MusicXmlImporter_Tests
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
                path = Path.GetDirectoryName(path);
                path = Path.Combine(path, "TEST_FILES");
                return path;
            }
        }

        [TestMethod()]
        public void ImportTest()
        {
            var path = Path.Combine(TEST_FILES_PATH, "Superstition_Stevie_Wonder 020523.xml");
            //var path = Path.Combine(TEST_FILES_PATH, "Superstition_Stevie_Wonder 121922.musicxml");

            Debug.WriteLine(path);
            Debug.Assert(File.Exists(path));

            
            var parser = new MusicXmlImporter();

            var result = parser.Import(path);

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

        [TestMethod()]
        public void ImportEffendiMusicXmlFilesTest()
        {
            var folder = Path.Combine(TEST_FILES_PATH, "Effendi MusicXml Files");
            var files = Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories)
                .ToList();

            //files.Clear();
            //files.Add(@"C:\Dev\HarmonyHelper\HarmonyHelper\HarmonyHelper.Tests\TEST_FILES\Effendi MusicXml Files\I\dorado 3.xml");

            foreach (var file in files)
            {
                Debug.WriteLine(file);
                var parser = new MusicXmlImporter();
                try
                {
                    var model = parser.Import(file);
                    Assert.IsNotNull(model.Parts);
                    foreach (var part in model.Parts)
                    {
                        Assert.IsNotNull(part.Measures);
                        Assert.IsTrue(part.Measures.Any());
                    }

                    Assert.IsNotNull(model.Rhythm);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            new object();
        }

    }//class
}//ns