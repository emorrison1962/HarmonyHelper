
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
            this.Document = new XDocument();

            this.ParsingContext.Rhythm = model.Rhythm;

            this.Document.Add(new XElement(XmlConstants.score_partwise));
            this.Document.Element(XmlConstants.score_partwise)
                .Add(model.Metadata.ToXElements());
            this.Document.Element(XmlConstants.score_partwise)
                .Add(this.ToXElement(model.Parts));

            foreach (var part in model.Parts)
            {
                var xpart = new XElement(XmlConstants.part);
                xpart.Add(new XAttribute(XmlConstants.id, part.Identifier.ID));

                foreach (var section in part.Sections)
                {
                    foreach (var measure in section.Measures)
                    {
                        measure.ToXElement();
                        var xmeasure = new XElement(XmlConstants.measure);
                        if (measure == part.Sections.First().Measures.First())
                        {
                            this.GetPartMetadata(part, xmeasure);
                        }

                        xmeasure.Add(new XAttribute(XmlConstants.number, measure.MeasureNumber));

                        var events = measure.GetMergedEvents();
                        foreach (var @event in events)
                        {
                            var ob = (dynamic)@event;
                            var xevent = this.ToXElement(ob);
                            xmeasure.Add(xevent);
                        }
                        if (null != section.RepeatContext)
                        {
                            var repeatCtx = section.RepeatContext;
                            if (repeatCtx.RepeatEnum == Domain.RepeatEnum.Forward)
                            { //2nd endings, section.Endings, measure.Barline, measure.HasRepeat
                                throw new NotImplementedException();
                            }
                        }
                        xpart.Add(xmeasure);
                    }
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

            if (null != this.ParsingContext.Rhythm)
            {
                var xdivisions = new XElement(XmlConstants.divisions,
                    this.ParsingContext.Rhythm.PulsesPerMeasure /
                    this.ParsingContext.Rhythm.TimeSignature.BeatCount);
                xattributes.Add(xdivisions);
                var xtime = new XElement(XmlConstants.time);

                var xbeats = new XElement(XmlConstants.beats,
                    this.ParsingContext.Rhythm.TimeSignature.BeatCount);
                xtime.Add(xbeats);
                var xbeat_type = new XElement(XmlConstants.beat_type,
                    this.ParsingContext.Rhythm.TimeSignature.BeatUnit);
                xtime.Add(xbeat_type);
                xattributes.Add(xtime);

            }

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


            var xstaves = new XElement(XmlConstants.staves, part.Staves.Count);
            xattributes.Add(xstaves);

            foreach (var staff in part.Staves)
            {
                xattributes.Add(staff.Clef.ToXml());
            }

            var xsound = new XElement(XmlConstants.sound);
            var xtempo = new XAttribute(XmlConstants.tempo, 
                this.ParsingContext.Rhythm.Tempo);
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

        public XElement ToXElement(List<MusicXmlPart> parts)
        {
            var result = new XElement(XmlConstants.part_list);
            foreach (var part in parts)
            {
#if false
   <score-part id="P1">
      <part-name>ElecPiano</part-name>
  </score-part>
#endif
                var xscore_part = new XElement(XmlConstants.score_part, new XAttribute(XmlConstants.id, part.Identifier.ID));
                xscore_part.Add(new XElement(XmlConstants.part_name, part.Identifier.Name));
                result.Add(xscore_part);
            }
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
            var root = this.ToRoot(te);
            harmony.Add(root);

            var elems = te.Event.ChordType.ToXElements();
            harmony.Add(elems);

            //var kind = new XElement(XmlConstants.kind, te.Event.ChordType.GetMusicXmlName());
            //kind.Add(new XAttribute(XmlConstants.text,
            //    $"{te.Event.Root.Name[0]}{te.Event.ChordType.Name}"));
            //harmony.Add(kind);

#warning throw new NotImplementedException("How do I get the offset?");
            //var offset = new XElement(XmlConstants.offset);
            //harmony.Add(offset);

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
                if (null != te.Serialization.Attack)
                    xnote.Add(new XAttribute(XmlConstants.attack, te.Serialization.Attack));
                if (null != te.Serialization.Release)
                    xnote.Add(new XAttribute(XmlConstants.release, te.Serialization.Release));

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
                if (te.Serialization.HasChord)
                {
                    xnote.Add(new XElement(XmlConstants.chord));
                }
                xnote.Add(xpitch);
                {
                    this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
                    xnote.Add(xduration);
                    xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
                    xnote.Add(xnoteTypeName);
                    xnote.Add(xdot);

                    if (!string.IsNullOrEmpty(te.Serialization.Staff))
                        xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));
                }

                if (te.TimeContext.TieType != TieTypeEnum.None)
                {
#if false
        <notations>
          <tied type="start"/>
        </notations>
#endif
                    var xnotations = new XElement(XmlConstants.notations);
                    xnote.Add(xnotations);
                    if (te.TimeContext.TieType == TieTypeEnum.Start)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.Stop)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.StartStop)
                    {
                        var xtypeStart = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtiedStart = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStart);
                        var xtypeStop = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtiedStop = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStop);
                    }
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

            this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
            xnote.Add(xduration);
            xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
            xnote.Add(xnoteTypeName);
            xnote.Add(xdot);

            if (!string.IsNullOrEmpty(te.Serialization.Staff))
                xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));

            return xnote;
        }

        public XElement ToXElement(TimedEvent<Forward> te)
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xforward = new XElement(XmlConstants.forward);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xforward.Add(xduration);
            return xforward;
        }

        public XElement ToXElement(TimedEvent<Backup> te)
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xbackup = new XElement(XmlConstants.backup);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xbackup.Add(xduration);
            return xbackup;
        }


        void ToXElements(TimeContext time, out XElement xnoteTypeName, out XElement xduration, out XElement xdot)
        {
            time.TryGetName(time.DurationEnum, out var name, out var isDotted);
            xnoteTypeName = null; xduration = null; xdot = null;
#if true
            xnoteTypeName = new XElement(XmlConstants.type, name);

            xduration = new XElement(XmlConstants.duration, time.Duration);
            xdot = null;
            if (isDotted)
            {
                xdot = new XElement(XmlConstants.dot);
            }
#endif
        }


    }//class
}//ns
