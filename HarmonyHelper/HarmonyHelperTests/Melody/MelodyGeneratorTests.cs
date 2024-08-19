using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Melody;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.MusicXml;
using HarmonyHelper_DryWetMidi;
using HarmonyHelper.MusicXml.Domain;
using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelper.Melody.Tests
{
    [TestClass()]
    public class MelodyGeneratorTests
    {
        [TestMethod()]
        public void CreateMelodyTest()
        {
            //var str = "c6 e7 a7 d7 g7 b7 e7 a7 abdim7";
            var str = "|| dm7 | g7 | cmaj7 | a7 ||";
            var model = this.CreateModel(str);
            //new MelodyGenerator().CreateMelody(model);    
            Assert.Fail();
        }

        public void CreateMidiFile(string chords)
        {
            var str = "c6 e7 a7 d7 g7 b7 e7 a7 abdim7";
            var model = this.CreateModel(str);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);
            new object();
            //Assert.Fail();
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
                DurationEnum.Duration_Whole, rhythm);
            return model;
        }


    }//class
}//ns