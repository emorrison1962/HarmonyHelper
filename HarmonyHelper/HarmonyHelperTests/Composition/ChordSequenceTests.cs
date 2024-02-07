using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.Composition;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony;
using zHarmonyHelperTests_Arpeggiator;

namespace HarmonyHelper.Composition.Tests
{
    [TestClass()]
    public class ChordSequenceTests
    {
        [TestMethod()]
        public void ChordSequenceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            var model = ChordSequenceTests.CreateModel();
            var chords = model.Parts.First().Chords;
            var seq = ChordSequence.Create(chords);
            Assert.IsNotNull(seq);
        }

        static MusicXmlModel CreateModel()
        {
            var result = new MusicXmlModel();

            var chordTxt = "dm7 g7 cmaj7 am7";
            var success = false;

            if (ChordFormulaParser.TryParse(chordTxt, out var key, out List<ChordFormula> formulas, out string message))
            {
                //formulas.ForEach(x => Debug.WriteLine(x));
                success = true;
            }
            else
            {
                Assert.Fail("Couldn't parse chords.");
            }

            if (success)
            {
                var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.EigthPosition);

                new object();

                var startingNote = new Note(formulas[0].Root,
                //OctaveEnum.Octave1);
                OctaveEnum.Octave2);
                var notesToPlay = 4;

                var contexts = new List<ArpeggiationChordContext>();
                formulas.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, noteRange, notesToPlay)));

                var arpeggiator = new Arpeggiator(contexts,
                    DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote,
                    noteRange, 4, startingNote, true);

                //this.RegisterTraceObservers(arpeggiator);
                var musicXmlObservers = new MusicXmlObservers(arpeggiator);

                arpeggiator.Arpeggiate();
                var part = musicXmlObservers.Part;
                result = ChordSequenceTests.CreateModel(part);
                new object();
            }
            return result;
        }

        public static MusicXmlModel CreateModel(Part part)
        {
            var isValid = part.IsValid();

            var result = new MusicXmlModel();
            result.Add(part);

            isValid = result.IsValid();

            return result;
        }

        public static ChordSequence CreateChordSequence()
        {
            var model = ChordSequenceTests.CreateModel();
            var chords = model.Parts.First().Chords;
            var result = ChordSequence.Create(chords);
            return result;
        }

    }//class
}//ns