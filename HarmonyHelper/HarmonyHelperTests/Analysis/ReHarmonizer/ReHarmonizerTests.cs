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
using Eric.Morrison.Harmony.Rhythm;
using Eric.Morrison.Harmony.Chords;
using System.Diagnostics;
using Eric.Morrison.Harmony.MusicXml.Tests;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer.Tests
{
    [TestClass()]
    public class ReHarmonizerTests
    {
        [TestMethod()]
        public void ReHarmonizeTest()
        {
            try
            {
                //TestUtilities.DisableAssertionDialogs();
                
                var srcPath = Path.Combine(MusicXmlExporterTests.TEST_FILES_PATH, 
                    "Superstition_Stevie_Wonder 020523.xml");
                Debug.WriteLine(srcPath);

                var parser = new MusicXmlImporter();

                using (var model = parser.Import(srcPath))
                {
                    Assert.IsTrue(model.IsValid());

                    var sw = Stopwatch.StartNew();
                    new ReHarmonizer().ReHarmonize(model, "P1", "P1");
                    //model.MergeSections();
                    sw.Stop();
                    Debug.WriteLine(sw.Elapsed.ToString());

                    foreach (var part in model.Parts)
                    {
                        Debug.WriteLine($"part.Measures.Count= {part.Measures.Count}");
                        new object();
                    }


                    foreach (var part in model.Parts)
                    {
                        var nMeasures = part.Measures.Count;
                        foreach (var measure in part.Measures)
                        {
                            Debug.WriteLine(measure.MeasureNumber);
                        }
                    }

                    model.RenderSections();
                    var doc = new MusicXmlExporter()
                        .Export(model);


                    //MusicXmlBase.ValidateMusicXmlSchema(doc);

                    var filename = $@"{DateTime.Now.ToString("MMddyy-hhmmss")}.xml";
                    filename = "000000-000001.xml";
                    var savePath = Path.Combine(MusicXmlExporterTests.TEST_FILES_PATH, filename);
                    doc.Save(savePath);
                    new object();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }//class
}//ns