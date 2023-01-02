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
        [TestMethod()]
        public void ExportTest()
        {
            var folder = @"c:\temp\MusicXml";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            var model = Parse();
            var doc = new MusicXmlExporter()
                .Export(model);

            //MusicXmlBase.ValidateMusicXmlSchema(doc);

            var filename = $@"{DateTime.Now.ToString("MMddyy-hhmmss")}.xml";
            filename = "000000-000000.xml";
            var path = Path.Combine(folder, filename);
            doc.Save(path);
            new object();
        }

        static public MusicXmlModel Parse()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "TEST_FILES");
            path = Path.Combine(path, "Superstition_Stevie_Wonder 121922.XML");
            Debug.WriteLine(path);
            Debug.Assert(File.Exists(path));

            var parser = new MusicXmlImporter();
            var result = parser.Import(path);

            return result;
        }

        [TestMethod()]
        public void foo()
        {
            var model = Parse();
            foreach (var part in model.Parts)
            {
                foreach (var measure in part.Measures)
                {
                    var events = measure.GetMergedEvents();
                    //measure.Chords
                    //    measure.Notes
                    //    measure.Rests
                    foreach (var @event in events)
                    {
                        //if (evt is IHasTimeContext<ChordFormula>)
                        //var cft = ((dynamic)evt).ToXElement();
                        Debug.WriteLine(@event);
                        foo((dynamic)@event);
                    }
                        Debug.WriteLine("========================");
                    new object();
                }
            }
        }

        void foo(TimedEvent<ChordFormula> te)
        { 
        }
        void foo(TimedEvent<Note> te)
        {
        }
        void foo(TimedEvent<Rest> te)
        {
        }
    }//class

}//ns