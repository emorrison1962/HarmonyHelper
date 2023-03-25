using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;

using DurationEnum = Eric.Morrison.Harmony.MusicXml.DurationEnum;

namespace zHarmonyHelperTests_Arpeggiator
{
    public class MusicXmlObservers
    {
        const string FLAT = "♭";
        const string SHARP = "♯";

        public Part Part { get; set; }
        public MusicXmlObservers(Arpeggiator arpeggiator)
        {
            this.Part = new Part(PartTypeEnum.Melody,
                new PartIdentifier("P1", "Bass"), ClefEnum.Bass);

            this.RegisterMusicXmlObservers(arpeggiator);
        }
        void RegisterMusicXmlObservers(Arpeggiator arpeggiator)
        {
            arpeggiator.Starting += this.Arpeggiator_Starting;
            //arpeggiator.MeasureChanging += Arpeggiator_MeasureChanging;
            arpeggiator.MeasureChanged += this.Arpeggiator_MeasureChanged;
            //arpeggiator.ChordChanging += Arpeggiator_ChordChanging;
            arpeggiator.ChordChanged += this.Arpeggiator_ChordChanged;
            //arpeggiator.NoteChanging += this.Arpeggiator_CurrentNoteChanging;
            arpeggiator.NoteChanged += this.Arpeggiator_CurrentNoteChanged;
            arpeggiator.Ending += this.Arpeggiator_Ending;
        }

        RhythmicContext Rhythm = new RhythmicContext(new TimeSignature(4, 4), 480).SetTempo(100);

        private void Arpeggiator_Starting(object? sender, Arpeggiator args)
        {
            Debug.WriteLine("Arpeggiator_Starting");
            new object();
        }
        private void Arpeggiator_MeasureChanging(object? sender, Arpeggiator args)
        {
            //Debug.WriteLine("Arpeggiator_MeasureChanging");
            new object();
            //this.CreateMeasure(ctx);
        }
        private void Arpeggiator_MeasureChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\tArpeggiator_MeasureChanged: {args.CurrentMeasure}");
            this.CreateMeasure(args);
            new object();
        }
        private void CreateMeasure(Arpeggiator args)
        {
            if (args.CurrentMeasure > 0)
            {
                var measureNumber = args.CurrentMeasure;
                var measure = new Measure(this.Part, measureNumber);
                if (args.CurrentMeasure == 1)
                    measure.Add(new BarlineContext(BarlineStyleEnum.Light_Light, BarlineSideEnum.Left));
                this.Part.Add(measure);
            }
            new object();

        }

        private void Arpeggiator_ChordChanging(object? sender, Arpeggiator.ChordChangingEventArgs args)
        {
            //Debug.WriteLine("Arpeggiator_ChordChanging");
            new object();
        }

        private void Arpeggiator_ChordChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\tArpeggiator_ChordChanged: {args.CurrentChord}");
            this.CreateHarmony(args);
            new object();
        }

        private void CreateHarmony(Arpeggiator args)
        {
            var cctx = new TimeContextEx.CreationContext(this.Rhythm);
            cctx.Duration = Eric.Morrison.Harmony.MusicXml.DurationEnum.Duration_Quarter;
            cctx.MeasureNumber = args.CurrentMeasure;
            cctx.RelativeStart = 0;
            cctx.RelativeEnd = 1;
            var tctx = new TimeContextEx(cctx);

            var tecf = new TimedEventChordFormula(args.CurrentChord.Formula, tctx);
            this.Part.CurrentMeasure.Add(tecf);
        }

        private void Arpeggiator_CurrentNoteChanging(object sender, Arpeggiator.NoteChangingEventArgs args)
        {
            Debug.WriteLine("Arpeggiator_CurrentNoteChanging");
            new object();
        }
        private void Arpeggiator_CurrentNoteChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\t\tArpeggiator_CurrentNoteChanged: {args.CurrentNote}");
            this.CreateNote(args);
            new object();
        }

        private void CreateNote(Arpeggiator args)
        {
            var cctx = new TimeContextEx.CreationContext(this.Rhythm);
            cctx.Duration = DurationEnum.Duration_Quarter;
            cctx.MeasureNumber = args.CurrentMeasure;
            cctx.RelativeStart = 0;
            cctx.RelativeEnd = 1;
            var tctx = new TimeContextEx(cctx);
            var tecf = new TimedEventNote(args.CurrentNote, tctx);
            this.Part.CurrentMeasure.Add(tecf);
        }

        private void Arpeggiator_Ending(object? sender, Arpeggiator args)
        {
            //throw new NotImplementedException();
            //XmlCtx.Document.Save(@"c:\temp\_xml.xml");
            new object();
        }



    }//class
}//ns
