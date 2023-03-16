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
using Eric.Morrison.Harmony;

namespace MusicXml.Tests
{
    [TestClass()]
    public class MusicXmlExporterTests
    {
        public static string TEST_FILES_PATH
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
        public void ExportTest()
        {
            //foreach (var ct in ChordType.Catalog)
            //{ 
            //    Debug.WriteLine(ct.Name);
            //}


            var path = TEST_FILES_PATH;
            path = Path.Combine(path, "Superstition_Stevie_Wonder 020523.xml");
            var model = Parse(path);
            var doc = new MusicXmlExporter().Export(model);

            var filename = $@"{DateTime.Now.ToString("MMddyy-hhmmss")}.xml";
            filename = @"000000-000004.xml";
            var dstPath = Path.Combine(TEST_FILES_PATH, filename);
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
        public void ExportEffendiMusicXmlFilesTest()
        {
            var srcFolder = Path.Combine(TEST_FILES_PATH, "Effendi MusicXml Files");
            var dstFolder = $"{srcFolder}_exported";

            var files = Directory.GetFiles(srcFolder, "*.xml", SearchOption.AllDirectories)
                .ToList();

            files.Clear();
            var targetFile = Path.Combine(new string[] { srcFolder, "I", "630blues.xml" });
            files.Add(targetFile);

            foreach (var file in files)
            {
                Debug.WriteLine(file);
                var parser = new MusicXmlImporter();
                try
                {
                    var model = parser.Import(file);
                    if (null != model)
                    {
                        //Assert.IsNotNull(model.Rhythm);
                        var doc = new MusicXmlExporter().Export(model);


                        var dstPath = file.Replace(srcFolder, dstFolder);
                        if (!Directory.Exists(Path.GetDirectoryName(dstPath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(dstPath));
                        Debug.WriteLine(dstPath);


                        doc.Save(dstPath);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            new object();
        }


        static public void Export(string dstPath, MusicXmlModel model)
        {
            Debug.WriteLine(dstPath);
            try
            {
                if (null != model)
                {
                    var doc = new MusicXmlExporter().Export(model);
                    if (!Directory.Exists(Path.GetDirectoryName(dstPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(dstPath));
                    Debug.WriteLine(dstPath);

                    doc.Save(dstPath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            new object();
        }

        [TestMethod()]
        public void CreateModelAndExportTest()
        {
            var model = new MusicXmlModel();

            var part = new MusicXmlPart(PartTypeEnum.Melody);
            var isValid = part.IsValid();
            Assert.IsTrue(isValid);

            model.Add(part);

            isValid = model.IsValid();
            Assert.IsTrue(isValid);


            const int MEASURES_MAX = 20;
            for (int m = 1; m < MEASURES_MAX; ++m)
            {
                var measure = new MusicXmlMeasure(part, m);
                isValid = measure.IsValid();
                Assert.IsTrue(isValid);

                part.Add(measure);
                isValid = part.IsValid();
                Assert.IsTrue(isValid);

                var tctx = new TimeContextEx(part.CurrentMeasure.MeasureNumber,
                    model.Rhythm,
                    Eric.Morrison.Harmony.MusicXml.DurationEnum.Duration_Quarter);

                isValid = tctx.IsValid();
                Assert.IsTrue(isValid);

                var tecf = new TimedEventChordFormula(ChordFormula.DMinor7, tctx);
                part.CurrentMeasure.Add(tecf);

                var notes = new List<Note>()
                    {
                        new Note(NoteName.C, OctaveEnum.Octave4),
                        new Note(NoteName.D, OctaveEnum.Octave4),
                        new Note(NoteName.E, OctaveEnum.Octave4),
                        new Note(NoteName.F, OctaveEnum.Octave4),
                    };

                foreach (var note in notes)
                {
                    var ten = new TimedEventNote(note, tctx);
                    part.CurrentMeasure.Add(ten);
                }
            }

            //Debug.WriteLine(part.ToXElement());

            isValid = model.IsValid();
            Assert.IsTrue(isValid);

            var dstPath = $@"c:\temp\{MethodBase.GetCurrentMethod().Name}.xml";
            MusicXmlExporterTests.Export(dstPath, model);
            
            new object();
        }


    }//class
}//ns