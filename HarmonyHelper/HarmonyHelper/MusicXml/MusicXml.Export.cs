
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Notes;
using Eric.Morrison.Harmony.Rhythm;

#region MusicXml reference
#if false

https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/

#endif
#endregion


namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlExporter : MusicXmlBase
    {
        #region Constants

        #endregion

        #region Properties
        XDocument Document { get; set; }
        ParsingContext ParsingContext { get; set; } = new ParsingContext();

        #endregion

        #region Construction
        public MusicXmlExporter()
        {
        }

        #endregion

        public XDocument Export(MusicXmlModel model)
        {
            this.ExportImpl(model);
            return this.Document;
        }

        void ExportImpl(MusicXmlModel model)
        {
            this.Document = new ExportTemplateFactory().Create(model);

            foreach (var part in model.Parts)
            {
                var xpart = new XElement(XmlConstants.part);
                xpart.Add(new XAttribute(XmlConstants.id, part.Identifier.ID));

                foreach (var measure in part.Measures)
                {
                    var xmeasure = new XElement(XmlConstants.measure);
                    xmeasure.Add(new XAttribute(XmlConstants.number, measure.MeasureNumber));

                    if (measure.HasMetadata)
                    {
                        xmeasure = this.GetPartMetadata(part, xmeasure);
                    }
                    if (measure.Serialization.HasBackup)
                    {
                        var backup = new XElement(XmlConstants.backup, 
                            new XElement (XmlConstants.duration, 
                                measure.Serialization.Backup));
                        xmeasure.Add(backup);
                    }
                    if (measure.Serialization.HasForward)
                    {
                        var forward = new XElement(XmlConstants.forward,
                            new XElement(XmlConstants.duration,
                                measure.Serialization.Forward));
                        xmeasure.Add(forward);
                    }

                    var events = measure.GetMergedEvents();
                    foreach (var @event in events)
                    {
                        var ob = (dynamic)@event;
                        var xevent = this.ToXElement(ob);
                        xmeasure.Add(xevent);
                    }
                    xpart.Add(xmeasure);
                }
                this.Document.Element(XmlConstants.score_partwise)
                    .Add(xpart);
            }
        }

        XElement GetPartMetadata(MusicXmlPart part, XElement xmeasure)
        {
#if false
   <measure number="1">
      <attributes>
        <divisions>120</divisions>
        <key>
           <fifths>2</fifths>
        </key>
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
        <staves>2</staves>
        <clef number="1">
           <sign>G</sign>
           <line>2</line>
        </clef>
        <clef number="2">
           <sign>F</sign>
           <line>4</line>
        </clef>
      </attributes>
      <sound tempo="120"/>
      <forward>
         <duration>480</duration>
      </forward>
   </measure>
#endif
            var result = xmeasure;
            var xattributes = new XElement(XmlConstants.attributes);
            result.Add(xattributes);

            var xdivisions = new XElement(XmlConstants.divisions, 
                part.PulsesPerMeasure / part.TimeSignatue.BeatCount);
            xattributes.Add(xdivisions);

            var xkey = new XElement(XmlConstants.key);
            var fifths = 0;
            if (part.KeySignature.UsesFlats)
            {
                fifths = -part.KeySignature.AccidentalCount;
            }
            else
            {
                fifths = part.KeySignature.AccidentalCount;
            }
            xkey.Add(new XElement(XmlConstants.fifths, fifths));
            xattributes.Add(xkey);


            var xtime = new XElement(XmlConstants.time);
            var xbeats = new XElement(XmlConstants.beats, part.TimeSignatue.BeatCount);
            xtime.Add(xbeats);
            var xbeat_type = new XElement(XmlConstants.beat_type, part.TimeSignatue.BeatUnit);
            xtime.Add(xbeat_type);
            xattributes.Add(xtime);

            var xstaves = new XElement(XmlConstants.staves, part.Staves.Count);
            xattributes.Add(xstaves);

            foreach (var staff in part.Staves)
            {
                xattributes.Add(staff.Clef.ToXml());
            }

            var xsound = new XElement(XmlConstants.sound);
            var xtempo = new XAttribute(XmlConstants.tempo, part.Tempo);
            xsound.Add(xtempo);
            
            result.Add(xsound);

            return result;
        }

        public XElement ToPitch(Note note)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            XElement result = new XElement(XmlConstants.pitch);
            XElement step = new XElement(XmlConstants.step, note.NoteName.Name[0]);
            result.Add(step);

            XElement alter = null;
            if (note.NoteName.IsSharped)
                alter = new XElement(XmlConstants.alter, 1);
            else if (note.NoteName.IsFlatted)
                alter = new XElement(XmlConstants.alter, -1);
            result.Add(alter);

            var octave = new XElement(XmlConstants.octave, (int)note.Octave);
            result.Add(octave);

            return result;
        }

        public XElement ToXElement(TimedEvent<ChordFormula> te)
        {
#if false
      <harmony>
         <root>
         <root-step>C</root-step>
         </root>
         <kind text="m7">minor-seventh</kind>
      <offset>240</offset>
      </harmony>
#endif
            var harmony = new XElement(XmlConstants.harmony);
            var root = ToRoot(te);
            harmony.Add(root);

            var kind = new XElement(XmlConstants.kind, te.Event.ChordType.Name);
            kind.Add(new XAttribute(XmlConstants.text,
                $"{te.Event.Root.Name[0]}{te.Event.ChordType.Name}"));
            harmony.Add(kind);

            //throw new NotImplementedException("How do I get the offset?");
            var offset = new XElement(XmlConstants.offset);
            harmony.Add(offset);

            return harmony;
        }

        public XElement ToRoot(TimedEvent<ChordFormula> te)
        {
#if false
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
#endif

            var root = new XElement(XmlConstants.root);

            var root_step = new XElement(XmlConstants.root_step, te.Event.Root.Name[0]);
            root.Add(root_step);

            if (!te.Event.Root.IsNatural)
            {
                if (te.Event.Root.IsSharped)
                {
                    var root_alter = new XElement(XmlConstants.root_alter, 1);
                    root.Add(root_alter);
                }
                else
                {
                    var root_alter = new XElement(XmlConstants.root_alter, -1);
                    root.Add(root_alter);
                }
            }
            return root;
        }

        public XElement ToXElement<T>(T te)
            where T : TimedEvent<ChordFormula>
        {
#if false
      <harmony>
         <root>
         <root-step>C</root-step>
         </root>
         <kind text="m7">minor-seventh</kind>
      <offset>240</offset>
      </harmony>
#endif
            var harmony = new XElement(XmlConstants.harmony);
            var root = this.ToRoot((dynamic)te);
            harmony.Add(root);

            var kind = new XElement(XmlConstants.kind, te.Event.ChordType.Name);
            harmony.Add(kind);

            //throw new NotImplementedException("How do I get the offset?");
            var offset = new XElement(XmlConstants.offset);
            harmony.Add(offset);

            return harmony;
        }


        /// <summary>
        /// </summary>
        /// <param name="te"></param>
        /// <returns>
        ///      <note release="55">
        ///        <pitch>
        ///          <step>B</step>
        ///          <alter>-1</alter>
        ///          <octave>1</octave>
        ///        </pitch>
        ///         <duration>60</duration>
        ///         <voice>2</voice>
        ///         <type>eighth</type>
        ///         <beam number="1">begin</beam>
        ///      </note>
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public XElement ToXElement(TimedEvent<Note> te)
        {
            var nn = te.Event.NoteName;
            var note = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            {
                var xpitch = new XElement(XmlConstants.pitch);
                {
                    var xstep = new XElement(XmlConstants.step, nn.Name[0]);
                    xpitch.Add(xstep);

                    if (!nn.IsNatural)
                    {
                        XElement xalter = null;
                        if (nn.IsSharped)
                            xalter = new XElement(XmlConstants.alter, 1);
                        else if (nn.IsFlatted)
                            xalter = new XElement(XmlConstants.alter, -1);
                        xpitch.Add(xalter);
                    }

                    var xoctave = new XElement(XmlConstants.octave, (int)note.Octave);
                    xpitch.Add(xoctave);
                }
                if (te.Serialization.IsLastNoteOfChord)
                {
                    xnote.Add(new XElement(XmlConstants.chord));
                }
                xnote.Add(xpitch);
                {
                    this.GetDuration(time, out var xduration, out var xtype);
                    xnote.Add(xduration);
                    xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
                    xnote.Add(xtype);
                    xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));
                }
            }
            new object();
            return xnote;
        }
        public XElement ToXElement(TimedEvent<Rest> te)
        {
#if false
      <note>
        <rest/>
         <duration>120</duration>
         <voice>1</voice>
         <type>quarter</type>
         <staff>1</staff>
      </note>

#endif
            var rest = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            var xrest = new XElement(XmlConstants.rest);
            xnote.Add(xrest);

            this.GetDuration(time, out var duration, out var noteType);
            xnote.Add(duration);
            xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
            xnote.Add(noteType);
            xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));

            return xnote;
        }

        void GetDuration(TimeContext time, out XElement duration, out XElement noteType)
        {
            duration = new XElement(XmlConstants.duration, time.Duration);
            noteType = new XElement(XmlConstants.type,
                time.GetNoteType().ToLower());
        }

    }//class
}//ns
