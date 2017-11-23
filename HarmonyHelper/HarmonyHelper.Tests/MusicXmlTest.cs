using Eric.Morrison.Harmony.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony
{
    [TestClass]
    public class MusicXmlTest
    {
        class XmlContext
        {
            public int MeasureNumber = 0;
            public XDocument Document;
        }

        class LogContext
        {
            public readonly int BARS_PER_LINE = 2;
            public int chordCount = 0;
        }

        XmlContext XmlCtx = new XmlContext();
        LogContext LogCtx = new LogContext();

        [TestMethod()]
        public void TheChickenTest()
        {
            var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
            var chordFormula = ChordFormula.Bb7;
            var chord = new Chord(chordFormula, noteRange);
            var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
            var notesToPlay = 4;

            var chords = new List<Chord>() { chord };
            {
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Bb7, noteRange));
                chords.Add(new Chord(ChordFormula.Eb7, noteRange));
                chords.Add(new Chord(ChordFormula.Eb7, noteRange));
                chords.Add(new Chord(ChordFormula.D7, noteRange));
                chords.Add(new Chord(ChordFormula.G7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
                chords.Add(new Chord(ChordFormula.C7, noteRange));
            }


            var ctx = new ArpeggiationContext(chords,
                DirectionEnum.Ascending,
                noteRange, notesToPlay, startingNote);

            ctx.ArpeggiationContextChanged += Ctx_NoOpObserver;
            ctx.ChordChanged += Ctx_ChordChanged;
            ctx.DirectionChanged += Log_DirectionChanged;
            ctx.CurrentNoteChanged += Ctx_CurrentNoteChanged;
            ctx.Starting += Ctx_Starting;
            ctx.Ending += Ctx_Ending;


            ctx.Arpeggiate();

            new object();
        }

        private void Ctx_Starting(object sender, ArpeggiationContext e)
        {
            this.Log_Starting(sender, e);
            this.XML_Starting(sender, e);
        }
        private void Ctx_ChordChanged(object sender, ArpeggiationContext ctx)
        {
            this.Log_ChordChanged(sender, ctx);
            this.XML_ChordChanged(sender, ctx);
        }
        private void Ctx_CurrentNoteChanged(object sender, ArpeggiationContext ctx)
        {
            this.Log_CurrentNoteChanged(sender, ctx);
            this.XML_CurrentNoteChanged(sender, ctx);
        }
        private void Ctx_Ending(object sender, ArpeggiationContext e)
        {
            this.Log_Ending(sender, e);
            this.XML_Ending(sender, e);
        }
        private void Ctx_NoOpObserver(object sender, ArpeggiationContext ctx)
        { }



        private void Log_Ending(object sender, ArpeggiationContext e)
        {
            Debug.WriteLine("||");
        }

        private void Log_Starting(object sender, ArpeggiationContext e)
        {
            Debug.Write("|");
        }

        private void Log_CurrentNoteChanged(object sender, ArpeggiationContext ctx)
        {
            var noteStr = ctx.CurrentNote.ToString(ToStringEnum.Minimal, ctx.Chord.KeySignature);
            noteStr = string.Format("{0}", noteStr);
            noteStr += string.Format("{0,-3}", (int)ctx.CurrentNote.Octave);
            Debug.Write(noteStr);
        }

        private void Log_DirectionChanged(object sender, ArpeggiationContext ctx)
        {
            const string ASC = "˄";
            const string DESC = "˅";

            var direction = ctx.Direction == DirectionEnum.Ascending ? ASC : DESC;
            Debug.Write(direction);
        }

        private void Log_ChordChanged(object sender, ArpeggiationContext ctx)
        {
            if (LogCtx.chordCount > 0 && LogCtx.chordCount % LogCtx.BARS_PER_LINE == 0)
                Debug.WriteLine(" |");
            Debug.Write(string.Format(" | ({0}) ", ctx.Chord.Name));
            ++LogCtx.chordCount;
        }





        private void XML_Starting(object sender, ArpeggiationContext e)
        {
            string fileContent = Resources.MusicXML_TEMPLATE;
            XmlCtx.Document = XDocument.Parse(fileContent);
            new object();
        }
        private void XML_ChordChanged(object sender, ArpeggiationContext ctx)
        {
            ++XmlCtx.MeasureNumber;
            this.CreateMeasure(ctx.Chord.Root.ToString(ctx.Chord.KeySignature));
        }
        private void XML_Ending(object sender, ArpeggiationContext e)
        {
            XmlCtx.Document.Save(@"c:\temp\_xml.xml");
            new object();
        }
        private void XML_CurrentNoteChanged(object sender, ArpeggiationContext ctx)
        {
            #region FORMAT
            const string FORMAT = @"
      <note>
        <pitch>
          <step>{0}</step>
          {1}
          <octave>{2}</octave>
        </pitch>
        <duration>1</duration>
        <voice>1</voice>
        <type>quarter</type>
      </note>";
            #endregion

            var octave = 2 + (int)ctx.CurrentNote.Octave;
            var note = ctx.CurrentNote.NoteName.ToString();

            var alter = string.Empty;
            if (note.EndsWith(FLAT))
            {
                alter = "<alter>-1</alter>";
            }
            note = note.Replace(FLAT, string.Empty);
            note = note.Replace(SHARP, string.Empty);

            var xml = string.Format(FORMAT, note, alter, octave);
            var elem = XElement.Parse(xml);

            var measure = XmlCtx.Document.Root.Descendants("measure").Last();
            measure.Add(elem);
            new object();
        }


        #region MEASURE_XML
        const string MEASURE_XML = @"
    <measure number=""{0}"" width=""300.00"">
{3}
        <harmony print-frame=""no"">
        <root>
          <root-step>{1}</root-step>
          {2}
        </root>
        <kind text = ""7"" >dominant</kind>
      </harmony>
    </measure>";
        #endregion

        const string FLAT = "♭";
        const string SHARP = "♯";


        private void CreateMeasure(string chordRoot)
        {
            var rootAlter = string.Empty;
            if (chordRoot.EndsWith(FLAT))
                rootAlter = "<root-alter>-1</root-alter>";

            chordRoot = chordRoot.Replace(FLAT, string.Empty);
            chordRoot = chordRoot.Replace(SHARP, string.Empty);

            var print = string.Empty;
            if (1 == XmlCtx.MeasureNumber)
            {
                print = @"      <print>
        <system-layout>
          <system-margins>
            <left-margin>-0.00</left-margin>
            <right-margin>0.00</right-margin>
          </system-margins>
          <system-distance>101.74</system-distance>
        </system-layout>
      </print>
";
            }

            var xml = string.Format(MEASURE_XML, XmlCtx.MeasureNumber, chordRoot, rootAlter, print);

            //Debug.WriteLine(xml);
            var measureElem = XElement.Parse(xml);


            var elem = XmlCtx.Document.Root.Descendants("part").Last();
            elem.Add(measureElem);
            new object();
        }


    }//class
}//ns
