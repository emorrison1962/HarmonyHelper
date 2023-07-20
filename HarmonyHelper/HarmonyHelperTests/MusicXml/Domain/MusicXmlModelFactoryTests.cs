using Microsoft.VisualStudio.TestTools.UnitTesting;
using HarmonyHelper.MusicXml.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelper.MusicXml.Domain.Tests
{
    [TestClass()]
    public class MusicXmlModelFactoryTests
    {
        [TestMethod()]
        public void MusicXmlModelFactoryTest_01()
        {

            var Verse_1  = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_1 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Verse_2  = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_2 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Break    = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 |";
            var Verse_Reprise = @"| A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_3 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | C | Am | E7 | Am | Dm | Am | E7 | Am |";
            List<string> Sections = new List<string>()
            {
                Verse_1, Chorus_1,
                Verse_2, Chorus_2,
                Break, 
                Verse_Reprise, Chorus_3
            };

            var rhythm = new RhythmicContext(new TimeSignature(6, 8));
            var factory = new MusicXmlModelFactory(rhythm);

            foreach (var section in Sections)
            {
                var formulas = ChordFormulaParser.Parse(section);
                factory.Part.Add(new Section());
                foreach (var formula in formulas)
                {
                    var measure = new Measure();
                    factory.Part.Sections.Last().Add(measure);

                    var timeCtx = new TimeContextEx(measure,
                        factory.Model.Rhythm,
                        DurationEnum.Duration_Whole);
                    var teChordFormula = new TimedEventChordFormula(formula, timeCtx);
                    measure.Add(teChordFormula);
                }
            }

            var model = factory.Model;
            new object();
        }

        [TestMethod()]
        public void MusicXmlModelFactoryTest_02()
        {

            var Verse_1 = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_1 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Verse_2 = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 | A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_2 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | E7 |";
            var Break = @"| Am | Am | E7 | E7 | Am | Am | E7 | E7 |";
            var Verse_Reprise = @"| A | A7 | Dm | Dm | Am | E7 | Am | G7 |";
            var Chorus_3 = @"| C | C | G | G | G7 | G7 | C | C | C | C7 | F | Dm | C | G | C | C | Am | E7 | Am | Dm | Am | E7 | Am |";
            List<string> Sections = new List<string>()
            {
                Verse_1, Chorus_1,
                Verse_2, Chorus_2,
                Break,
                Verse_Reprise, Chorus_3
            };

            var rhythm = new RhythmicContext(new TimeSignature(6, 8));
            var model = MusicXmlModelFactory.Create(Sections, rhythm);

            new object();
        }

    }//class
}//ns