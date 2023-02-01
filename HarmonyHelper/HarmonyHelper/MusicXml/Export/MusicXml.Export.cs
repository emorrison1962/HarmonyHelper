
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
                        var xmeasure = measure.ToXElement();
                        if (measure == part.Sections.First().Measures.First())
                        {
                            this.GetPartMetadata(part, xmeasure);
                        }

                        xpart.Add(xmeasure);
                    }
                }

                this.Document.Element(XmlConstants.score_partwise)
                    .Add(xpart);
            }
        }

        void GetPartMetadata(MusicXmlPart part, XElement xmeasure)
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
            //var result = xmeasure;
            var xattributes = new XElement(XmlConstants.attributes);
            //result.Add(xattributes);

            if (null != this.ParsingContext.Rhythm)
            {
                #region divisions
                var xdivisions = new XElement(XmlConstants.divisions,
            this.ParsingContext.Rhythm.PulsesPerMeasure /
            this.ParsingContext.Rhythm.TimeSignature.BeatCount);
                xattributes.Add(xdivisions);

                #endregion
                
                #region key
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

                #endregion

                #region time

                var xtime = new XElement(XmlConstants.time);

                var xbeats = new XElement(XmlConstants.beats,
                    this.ParsingContext.Rhythm.TimeSignature.BeatCount);
                xtime.Add(xbeats);
                var xbeat_type = new XElement(XmlConstants.beat_type,
                    this.ParsingContext.Rhythm.TimeSignature.BeatUnit);
                xtime.Add(xbeat_type);
                xattributes.Add(xtime);

                #endregion
            }

            #region staves
            var xstaves = new XElement(XmlConstants.staves, part.Staves.Count);
            xattributes.Add(xstaves);

            #endregion

            #region clefs
            foreach (var staff in part.Staves)
            {
                xattributes.Add(staff.Clef.ToXml());
            }

            #endregion

            xmeasure.AddFirst(this.GetTempo());
            xmeasure.AddFirst(xattributes);

        }

        XElement GetTempo()
        {
            #region tempo
            var result = new XElement(XmlConstants.sound);
            var xtempo = new XAttribute(XmlConstants.tempo,
                this.ParsingContext.Rhythm.Tempo);
            result.Add(xtempo);

            return result;

            #endregion
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

        public XElement ToRoot(TimedEventChordFormula te)
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
        
    }//class
}//ns
