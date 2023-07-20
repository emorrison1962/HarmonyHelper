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
        public void CreateMidiFileTest_EitherWay()
        {
            var model = this.CreateModel_EitherWay();
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\EitherWay.mid";
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

        public MusicXmlModel CreateModel_EitherWay()
        {

            var Verse_1 = @"| G | GMaj7/F# | G7/F | C/E | Eb | D2 | C, G/B | C, Bb |";
            List<string> Sections = new List<string>()
            {
                Verse_1
            };

            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);
            return model;
        }

    }//class
}//ns