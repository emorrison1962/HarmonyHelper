using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.MusicXml;

namespace zHarmonyHelperTests_Arpeggiator
{
    public class MusicXmlObservers
    {
        const string FLAT = "♭";
        const string SHARP = "♯";

        public MusicXmlPart Part { get; set; }
        public MusicXmlObservers(Arpeggiator arpeggiator)
        {
            this.Part = new MusicXmlPart(PartTypeEnum.Melody,
                new MusicXmlPartIdentifier("P1", "Bass"));

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

        private void Arpeggiator_Starting(object sender, Arpeggiator args)
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
            new object();
        }
        private void Arpeggiator_ChordChanging(object? sender, Arpeggiator.ChordChangingEventArgs args)
        {
            //Debug.WriteLine("Arpeggiator_ChordChanging");
            new object();
        }

        private void Arpeggiator_ChordChanged(object sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\tArpeggiator_ChordChanged: {args.CurrentChord}");
            new object();
        }
        private void Arpeggiator_CurrentNoteChanging(object sender, Arpeggiator.NoteChangingEventArgs args)
        {
            Debug.WriteLine("Arpeggiator_CurrentNoteChanging");
            new object();
        }
        private void Arpeggiator_CurrentNoteChanged(object sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\t\tArpeggiator_CurrentNoteChanged: {args.CurrentNote}");
            new object();
        }
        private void Arpeggiator_Ending(object sender, Arpeggiator args)
        {
            //throw new NotImplementedException();
            //XmlCtx.Document.Save(@"c:\temp\_xml.xml");
            new object();
        }


        private void CreateMeasure(Arpeggiator args)
        {
			var measureNumber = args.CurrentMeasure + 2;
            var measure = new MusicXmlMeasure(this.Part, args.CurrentMeasure + 2);
            this.Part.Add(measure);
			new object();

        }

    }
}
