﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

using static System.Collections.Specialized.BitVector32;

using Section = Eric.Morrison.Harmony.MusicXml.Section;

namespace HarmonyHelper.MusicXml.Domain
{
    public class MusicXmlModelFactory
    {
        public MusicXmlModel Model { get; set; } = new MusicXmlModel();
        public Part Part { get { return this.Model.Parts.First(); } }

        public MusicXmlModelFactory(RhythmicContext rhythm = null)
        {
            if (null != rhythm)
                this.Model.Rhythm = rhythm;
            this.Model.Add(new Part(PartTypeEnum.Harmony));
        }

        static public MusicXmlModel Create(List<string> sections, RhythmicContext rhythm = null)
        {
            var factory = new MusicXmlModelFactory(rhythm);
            foreach (var section in sections)
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

            var result = factory.Model;
            return result;
        }

        static public MusicXmlModel Create(List<string> sections, DurationEnum de, RhythmicContext rhythm = null)
        {
            var factory = new MusicXmlModelFactory(rhythm);
            foreach (var section in sections)
            {
                var formulas = ChordFormulaParser.Parse(section);
                factory.Part.Add(new Section());
                foreach (var formula in formulas)
                {
                    var measure = new Measure();
                    factory.Part.Sections.Last().Add(measure);

                    var timeCtx = new TimeContextEx(measure,
                        factory.Model.Rhythm,
                        de);
                    var teChordFormula = new TimedEventChordFormula(formula, timeCtx);
                    measure.Append(teChordFormula);
                }
            }

            var result = factory.Model;
            return result;
        }

    }//class
}//ns
