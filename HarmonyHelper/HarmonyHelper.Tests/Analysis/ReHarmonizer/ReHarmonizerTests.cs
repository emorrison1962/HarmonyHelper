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
                
                var srcPath = Path.Combine(MusicXmlExporterTests.TEST_FILES_PATH, "Superstition_Stevie_Wonder 121922.XML");
                Debug.WriteLine(srcPath);
                var parser = new MusicXmlImporter();

                var sctx = new SectionContext(0, 16, 4);
                using (var model = parser.Import(srcPath))
                {
                    //model.CreateSections(new SectionContext(0, 16, 4));

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

#if false
        public void foo()
        {
            var ts = DateTime.Now - DateTime.Now;

            var rhytmicCtx = new RhythmicContext();
            rhytmicCtx.TimeSignature = new TimeSignature(4, 4);

            var m = new TestMeasure(1);
            m.RhythmicContext = rhytmicCtx;

            var n1 = new Note(NoteName.C, OctaveEnum.Octave3);
            var n2 = new Note(NoteName.D, OctaveEnum.Octave3);
            var n3 = new Note(NoteName.E, OctaveEnum.Octave3);

            var t1s = new MeasureTime(1, 0);
            var t1e = new MeasureTime(1, 120);

            var t2s = new MeasureTime(1, 120);
            var t2e = new MeasureTime(1, 240);

            var t3s = new MeasureTime(1, 240);
            var t3e = new MeasureTime(1, 360);

            var ts1 = t1e - t1s;
            var ts2 = t2e - t2s;
            var ts3 = t3e - t3s;


            var te1 = new TimedEventNote(n1, t1s, ts1);
            var te2 = new TimedEventNote(n2, t2s, ts2);
            var te3 = new TimedEventNote(n3, t3s, ts3);

        }

        public class TestMeasure : MusicXmlMeasure
        {
            public TestMeasure(int measureNumber) : base(measureNumber)
            {
            }

            public TestMeasure(MusicXmlMeasure src) : base(src)
            {
            }

            public TestMeasure(int measureNumber, List<TimedEventChordFormula> Chords, List<TimedEventNote> Notes, List<TimedEventRest> Rests, List<TimedEventForward> Forwards, List<TimedEventBackup> Backups) : base(measureNumber, Chords, Notes, Rests, Forwards, Backups)
            {
            }
            public RhythmicContext RhythmicContext { get; set; }
            public TestMeasure(RhythmicContext rc)
                : base (0)
            {
                this.RhythmicContext = rc;
            }
        }

        public class RhythmicContext
        { 
            public TimeSignature TimeSignature { get; set; }
            public int PulsesPerMeasure { get; protected set; }
        }

        public class MusicalTime
        {
            public int Value { get; set; }
            public MusicalTime(int value)
            {
                Value = value;
            }
        }

        public class MeasureTime: MusicalTime 
        {
            public int MeasureNumber { get; set; }
            public MeasureTime(int measureNumber, int val)
                : base(val)
            {
                MeasureNumber = measureNumber;  
            }
            public static MeasureTime operator +(MeasureTime addend, MeasureTime augend)
            {
                var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
                var Value = addend.Value + augend.Value;
                return new MeasureTime(MeasureNumber,
                    Value);
            }

            public static MeasureTimeSpan operator -(MeasureTime minuend, MeasureTime subtrahend)
            {
                var MeasureNumber = minuend.MeasureNumber + subtrahend.MeasureNumber;
                var Value = minuend.Value - subtrahend.Value;
                return new MeasureTimeSpan(Value, false);
            }

        }

        public class MusicalTimeSpan<T> where T : MusicalTime
        {
            public T Start { get; set; }
            public T End { get; set; }
            public bool IsTied { get; set; }
            public T Duration { get; set; }


        }

        public class MeasureTimeSpan : MusicalTimeSpan<MeasureTime>
        {
            public virtual LinkedList<MeasureTime> Related { get; set; } = new LinkedList<MeasureTime>();
            public int Value { get; set; }
            public MeasureTimeSpan(int val, bool isTied)
            {
                this.Value = val;
            }

            public static MeasureTime operator -(MeasureTimeSpan minuend, MeasureTime subtrahend)
            {
                throw new NotImplementedException();
                return null;
                //var MeasureNumber = minuend.MeasureNumber + subtrahend.MeasureNumber;
                //var Value = minuend.Value - subtrahend.Value;
                //return new MeasureTimeSpan(Value, false);
            }
            public static MeasureTime operator +(MeasureTimeSpan minuend, MeasureTime subtrahend)
            {
                throw new NotImplementedException();
                return null;
                //var MeasureNumber = minuend.MeasureNumber + subtrahend.MeasureNumber;
                //var Value = minuend.Value - subtrahend.Value;
                //return new MeasureTimeSpan(Value, false);
            }
        }
#endif
    }//class
}//ns