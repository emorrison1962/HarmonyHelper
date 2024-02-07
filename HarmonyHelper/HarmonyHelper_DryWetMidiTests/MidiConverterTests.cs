using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper_DryWetMidi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;
using HarmonyHelper.MusicXml.Domain;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;
using zHarmonyHelperTests_Arpeggiator;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;
using Section = Eric.Morrison.Harmony.MusicXml.Section;

namespace HarmonyHelper_DryWetMidi.Tests
{
    [TestClass()]
    public class MidiConverterTests
    {
        [TestMethod()]
        public void OpenTest()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);

            path = Path.Combine(path, "TEST_FILES");
            path = Path.Combine(path, "Superstition.mid");
            if (!File.Exists(path))
                throw new FileNotFoundException(path);


            var reader = new MidiFileConverter(path);

            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateMidiFileTest_Delilah()
        {
            var model = this.CreateModel_Delilah();
            var midi = new MidiFileConverter();
            var filename = @"c:\temp\Delilah.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateMidiFileTest_EitherWay_V()
        {
            var model = this.CreateModel_EitherWay_V();
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\EitherWay_V.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateMidiFileTest_EitherWay_C()
        {
            var model = this.CreateModel_EitherWay_C();
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\EitherWay_C.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateMidiFileTest_Generic()
        {
            var str = "c6 e7 a7 d7 g7 b7 e7 a7 abdim7";
            var model = this.CreateModel(str);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateMidiFileTest_110123()
        {
            var str = "cmaj7 e7 f d eb g7 ab f gb bb7 b c#7";
            var model = this.CreateModel(str);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_110123.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }


        [TestMethod()]
        public void Foo()
        {
            const int PPEN = MidiFileConverter.PPQN / 2;

            Assert.AreEqual(PPEN * 6, this.GetPulsesPerMeasure(new TimeSignatureStub(6, 8)));
            Assert.AreEqual(PPEN * 7, this.GetPulsesPerMeasure(new TimeSignatureStub(7, 8)));
            Assert.AreEqual(PPEN * 8, this.GetPulsesPerMeasure(new TimeSignatureStub(4, 4)));
        }

        int GetPulsesPerMeasure(TimeSignatureStub ts)
        {
            var result = int.MinValue;

            var arr = new[] { ts.Numerator, ts.Denominator };
            this.Simplify(arr);
            var numerator = arr[0];
            var denominator = arr[1];

            switch (denominator)
            {
                case 1:
                    {
                        var ppwn = MidiFileConverter.PPQN * 4;
                        result = numerator * ppwn;
                        break;
                    }
                case 2:
                    {
                        var pphn = MidiFileConverter.PPQN * 2;
                        result = numerator * pphn;
                        break;
                    }
                case 4:
                    {
                        var ppqn = MidiFileConverter.PPQN;
                        result = numerator * ppqn;
                        break;
                    }
                case 8:
                    {
                        var ppen = MidiFileConverter.PPQN / 2;
                        result = numerator * ppen;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                        break;
                    }
            }

            return result;
        }

        public class TimeSignatureStub
        {
            public int Numerator { get; }
            public int Denominator { get; }
            public TimeSignatureStub(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
        }

        void Simplify(int[] numbers)
        {
            int gcd = GCD(numbers);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] /= gcd;
        }
        int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
        int GCD(int[] args)
        {
            // using LINQ:
            return args.Aggregate((gcd, arg) => GCD(gcd, arg));
        }

        public MusicXmlModel CreateModel_Delilah()
        {

            var Verse_1 = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_1 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Verse_2 = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_2 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Break = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 |";
            var Verse_Reprise = @"| A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_3 = @"| C | C 
| G | G | G7 | G7 
| C | C | C | C7 
| F | Dm | C | G 
| C | C | Am | E7 
| Am | Dm | Am | E7 
| Am |";
            List<string> Sections = new List<string>()
            {
                Verse_1, Chorus_1,
                Verse_2, Chorus_2,
                Break,
                Verse_Reprise, Chorus_3
            };

            var rhythm = new RhythmicContext(new TimeSignature(6, 8));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);
            return model;
        }

        [TestMethod()]
        public void Test_112223()
        {
            var model = this.CreateModel_112223();
            var midi = new MidiFileConverter();
            var filename = @"c:\temp\_112223.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
        }
        public MusicXmlModel CreateModel_112223()
        {

            var Verse_1 = @"| Cm7| F7| E7| Am6| G#7| C#m7| E7| G#7|
| C#m7| D7| F#m7| A7| Am7| F#7| Bm7b5| E7b9 |
";
            List<string> Sections = new List<string>()
            {
                Verse_1
            };

            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);
            return model;
        }

        [TestMethod()]
        public void Test_112723()
        {
            var chords = @"| F| C| Am| E7| F| C| G| C| ";
            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }


        public MusicXmlModel CreateModel(string chords)
        {

            List<string> sections = new List<string>()
            {
                chords
            };

            return this.CreateModel(sections);
        }

        public MusicXmlModel CreateModel(List<string> sections)
        {
            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(sections,
                DurationEnum.Duration_Quarter, rhythm);
            return model;
        }

        public MusicXmlModel CreateBasslineModel(Part src)
        {
            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(src.Sections,
                rhythm);
            return model;
        }

        public MusicXmlModel CreateModel()
        {
            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create((List<Section>)null,
                rhythm);
            return model;
        }

        public MusicXmlModel CreateModel_EitherWay_V()
        {

            var Verse_1 = @"| G | GMaj7/F# | G7/F | C/E | Cm/Eb | D | C, G/B | C, Bb |";
            List<string> Sections = new List<string>()
            {
                Verse_1
            };

            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);
            return model;
        }

        public MusicXmlModel CreateModel_EitherWay_C()
        {

            var Verse_1 = @"| G | Em | C | Cm | G | Em | C | Cm |";
            List<string> Sections = new List<string>()
            {
                Verse_1
            };

            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);
            return model;
        }

        [TestMethod()]
        public void Test_121223()
        {
            var chords = @"| C | G7 | Cmaj7 | F#7 | 
                            B7 | E7 | Em | A7 | 
                            Dm7 | G7 |";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_121523()
        {
            var chords = @"| C6 | FMaj7 | Fm7 | Bb7 |";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_122123()
        {
            var chords = @"| fmaj7 | g7 | em7 | am7 
| abmaj7| bb7 | gm7 | cm7 
|bmaj7 | db7 | bbm7 | gb7 |";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_010124()
        {
            var chords = @"| em7 | dm11 | em7 | dm11 
| c69 | bbsus2 | c7 | bbsus2
| a69 | b7 |";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_011124()
        {
            var chords = @"c f bb11 c";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_012524()
        {
            var chords = @"| FMaj7| CMaj7| F69| C69| Fsus| Bbsus| Csus| Dm |";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }

        [TestMethod()]
        public void Test_Walrus()
        {
            var INTRO = ("INTRO", "| b|a|g f|e|e7|d|d7|");
            var A = ("A", "| a a/g|c  d e|a a/g|c|d|a|");
            var B = ("B", "|a a/g|d/f# fmaj7 g|a a/g|f|b|b7|");
            var C = ("C", "|c|d|e|");
            var D = ("D", "|dsus|%|a|e|d d7|");
            var INTERLUDE = ("INTERLUDE", "|e|b a|g f|e|");
            var F = ("F", "|b a|g f|e f|b7|%|");
            var G = ("G", "|c|d|e|d|");
            var H = ("H", "|c|d|e|d|c|bsus|");
            var I = ("I", "|a|g|f|e7|d|c|b|");

            var FORM = new List<(string, string)>()
            {
                INTRO ,
                A , B , C , A ,
                D ,
                B , C , INTERLUDE , F , G , A , B , H , I
            };
            foreach (var item in FORM)
            {
                var model = this.CreateModel(item.Item2);
                var midi = new MidiFileConverter();

                var filename = $@"c:\temp\_{item.Item1}.mid";
                midi.Create(model, filename);
            }
            new object();
        }

        [TestMethod()]
        public void Test_Walrus_Bassline()
        {
            var noteRange = new NoteRange(new Note(NoteName.B, OctaveEnum.Octave1), 1);

            var INTRO = ("INTRO", "| b|a|g f|e|e7|d|d7|");
            var A = ("A", "|a a/g|c  d e|a a/g|c|d|a|");
            var B = ("B", "|a a/g|d/f# fmaj7 g|a a/g|f|b|b7|");
            var C = ("C", "|c|d|e|");
            var D = ("D", "|dsus|%|a|e|d d7|");
            var INTERLUDE = ("INTERLUDE", "|e|b a|g f|e|");
            var F = ("F", "|b a|g f|e f|b7|%|");
            var G = ("G", "|c|d|e|d|");
            var H = ("H", "|c|d|e|d|c|bsus|");
            var I = ("I", "|a|g|f|e7|d|c|b|");

            var FORM = new List<(string, string)>()
            {
                INTRO ,
                A , B , C , A ,
                D ,
                B , C , INTERLUDE , F , G , A , B , H , I
            };
            foreach (var item in FORM)
            {
                var model = this.CreateModel();

                bool success = ChordFormulaParser.TryParse(item.Item2, out var key, out var formulas, out var msg);
                //Assert.IsTrue(success);

                foreach (var formula in formulas)
                {
                    var count = 4;
                    Debug.Write($" | ");
                    var notes = new List<Note>();
                    //for (int i = 0; i < count; ++i)
                    {

                        Debug.Write($" {formula.Root}");

                        var measureNumber = model.Parts[0].Sections.First().Measures.Count;
                        var note = new Note(formula.Root, OctaveEnum.Octave2);

                        var tens = new List<TimedEventNote>();
                        var ten = new TimedEventNote(note, 
                            new TimeContextEx(measureNumber, model.Rhythm));
                        tens.Add(ten);
                        tens.Add(ten);
                        tens.Add(ten);
                        tens.Add(ten);

                        var m = new Measure(model.Parts[0],
                            measureNumber,
                            null,
                            tens,
                            null, null, null);
                        model.Parts[0].Sections[0].Measures.Add(m);

                    }
                }
                Debug.Write($" | ");
                //var basslineModel = this.CreateBasslineModel(musicXmlObservers.Part);
                var filename = $@"c:\temp\_{item.Item1}_bass.mid";
                new MidiFileConverter().Create(model, filename);
                new object();
            }

            new object();
        }


        [TestMethod()]
        public void Test_010124_Bassline()
        {
            var noteRange = new NoteRange(new Note(NoteName.B, OctaveEnum.Octave1), 1);

            var chordTxt = @"| em7 | dm7 | em7 | dm7 | c6 | bbsus2 | c7 | bbsus2 | a6 | b7 | a6 | b7 |";

            var model = this.CreateModel(chordTxt);

            var startingNote = new Note(NoteName.E, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var formulas = model.Parts.First().Sections[1].Measures.Formulas;

            var contexts = new List<ArpeggiationChordContext>();
            formulas.ForEach(f => contexts.
                Add(new ArpeggiationChordContext(
                    new Chord(f, noteRange), notesToPlay)));

            var arpeggiator = new Arpeggiator(contexts,
                DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote,
                noteRange, 4, startingNote, false);

            var musicXmlObservers = new MusicXmlObservers(arpeggiator);

            arpeggiator.Arpeggiate();


            var basslineModel = this.CreateBasslineModel(musicXmlObservers.Part);

            var filename = @"c:\temp\_temp.mid";
            new MidiFileConverter().Create(basslineModel, filename);

            new object();
        }

        [TestMethod()]
        public void Test_013124()
        {
            var chords = @"
|: Dm/A| Dm/A| Am| Am| Dm/A| Dm/A| Am| Am|
| Gm C7/E| F6 Bb| Gm Am| Bb C |";
            chords = @"
| F | Gm | Am | Bb |
";

            var model = this.CreateModel(chords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
        }


    }//class
}//ns