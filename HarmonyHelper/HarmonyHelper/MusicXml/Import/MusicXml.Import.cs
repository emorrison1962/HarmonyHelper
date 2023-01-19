using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
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
    public partial class MusicXmlImporter : MusicXmlBase
    {
        #region Constants

        #endregion

        #region Properties
        XDocument Document { get; set; }
        ParsingContext ParsingContext { get; set; } = new ParsingContext();
        #endregion

        public MusicXmlImporter()
        {
        }

        public MusicXmlModel Import(MusicXmlModelCreationContext cctx)
        {
            this.Document = XDocument.Load(cctx.Path);

            //if (!MusicXmlBase.ValidateMusicXmlSchema(this.Document))
            //    throw new NotImplementedException();

            var result = this.ParseImpl();

            //cctx.PartIdMelody, 
            //cctx.PartIdHarmony


            result.InitSections(cctx.SectionContext);
            return result;
        }

        MusicXmlModel ParseImpl()
        {
            var metadata = this.ParseScoreMetadata();
            this.ParsingContext.Metadata = metadata;

            var score = this.Document.Elements(XmlConstants.score_partwise).First();

            var parts = this.ParseParts().ToList();
            Debug.Assert(parts.Count > 0);
            this.ParsingContext.Parts = parts;
            foreach (var part in parts)
            {
                //this.ParsingContext.CurrentPart = part;
                var xmeasures = part.XElement.Elements(XmlConstants.measure)
                    .ToList();
                foreach (var xmeasure in xmeasures)
                {
                    MusicXmlMeasure measure = null;
                    if (xmeasure.Elements(XmlConstants.attributes).Any())
                    {
                        measure = this.ParsePartMetadata(part, xmeasure);
                    }

                    this.ParseMeasure(part, xmeasure, ref measure);
                    part.Add(measure);
                }
            }
            var result = this.CreateMusicXmlModel(metadata, parts);
            return result;
        }

        MusicXmlScoreMetadata ParseScoreMetadata()
        {
            var result = new MusicXmlScoreMetadata();
            result.Title = this.ParseTitle();
            return result;
        }

        List<MusicXmlPart> ParseParts()
        {
            var result = new List<MusicXmlPart>();
            var xscore_parts = this.Document.Elements(XmlConstants.score_partwise)
                .Elements(XmlConstants.part_list)
                .Elements(XmlConstants.score_part)
                .ToList();
            Debug.Assert(xscore_parts.Count > 0);
            var pids = new List<MusicXmlPartIdentifier>();
            foreach (var xscore_part in xscore_parts)
            {
                var id = xscore_part.Attribute(XmlConstants.id).Value;
                var name = xscore_part.Elements(XmlConstants.part_name).First().Value;
                var pid = new MusicXmlPartIdentifier(id, name);
                pids.Add(pid);
            }

            var xparts = this.Document.Elements(XmlConstants.score_partwise)
                .Elements(XmlConstants.part)
                .ToList();
            Debug.Assert(xparts.Count > 0);
            foreach (var xpart in xparts)
            {
                var partName = xpart.Attribute(XmlConstants.id).Value;
                var pid = pids.First(x => x.ID == partName);
                
                var pte = PartTypeEnum.Unknown;
                var part = new MusicXmlPart(pte, pid, xpart);

                result.Add(part);
            }
            return result;
        }

        MusicXmlMeasure ParsePartMetadata(MusicXmlPart part, XElement xmeasure)
        {
            var xpart = this.Document.Elements(XmlConstants.part)
                .FirstOrDefault(x => x.Attribute(XmlConstants.id).Value == part.Identifier.ID);

            var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
            var measure = new MusicXmlMeasure(part, measureNumber);
            measure.HasMetadata = true;

            if (TryParseKeySignature(xmeasure, out var keySignature))
                part.KeySignature = keySignature;

            if (this.TryParsePpqn(xmeasure, out var ppqn))
            {
                if (this.TryParseTimeSignature(xmeasure, out var timeSignature))
                    this.ParsingContext.Rhythm
                        .SetTimeSignature(timeSignature)
                        .SetPulsesPerMeasure(ppqn);
            }

            if (this.TryParseStaves(xmeasure, out var staves))
                part.Staves = staves;

            if (this.TryParseTempo(xmeasure, out var tempo))
                part.Tempo = tempo;


            TimedEventFactory.Instance.PulsesPerMeasure = 
                this.ParsingContext.Rhythm.PulsesPerMeasure;

            return measure;
        }

        void ParseMeasure(MusicXmlPart part, XElement xmeasure, ref MusicXmlMeasure measure)
        {
            if (measure == null)
            {
                var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
                measure = new MusicXmlMeasure(part, measureNumber);
            }
            this.ParsingContext.CurrentMeasure = measure;
            this.PopulateMeasure(xmeasure, measure);
        }

        private void PopulateMeasure(XElement xmeasure, MusicXmlMeasure measure)
        {
            var xelements = xmeasure.Elements().ToList();
            this.ParsingContext.CurrentOffset = 0;

            var chords = new List<TimedEvent<ChordFormula>>();
            var notes = new List<TimedEvent<Note>>();
            var rests = new List<TimedEvent<Rest>>();
            var forwards = new List<TimedEvent<Forward>>();
            var backups = new List<TimedEvent<Backup>>();
            foreach (var xelement in xelements)
            {
                if (xelement.Name == XmlConstants.harmony)
                {
                    var chord = this.ParseChord(xelement, chords);
                    Debug.Assert(chord != null);
                    chords.Add(chord);
                }

                else if (xelement.Elements(XmlConstants.pitch).Any())
                {
                    var note = this.ParsePitched(xelement);
                    if (note != null) ;
                    notes.Add(note);
                }

                else if (xelement.Elements(XmlConstants.rest).Any())
                {
                    var rest = this.ParseRest(xelement);
                    Debug.Assert(rest != null);
                    rests.Add(rest);
                }
                else if (xelement.Name == XmlConstants.forward)
                {
                    TimedEvent<Forward> forward = this.ParseForward(xelement);
                    Debug.Assert(forward != null);
                    forwards.Add(forward);
                }
                else if (xelement.Name == XmlConstants.backup)
                {
                    TimedEvent<Backup> backup = this.ParseBackup(xelement);
                    Debug.Assert(backup != null);
                    backups.Add(backup);
                }
            }

            measure.AddRange(chords);
            measure.AddRange(notes);
            measure.AddRange(rests);
            measure.AddRange(forwards);
            measure.AddRange(backups);
        }

        TimedEvent<Rest> ParseRest(XElement xnote)
        {
            TimedEvent<Rest> result = null;
            var duration = ParseDuration(xnote, out var durationEnum);
            if (xnote.Elements(XmlConstants.rest).Any())
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Rest(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration,
                    durationEnum);
                result.Serialization.Voice = xnote.Element(XmlConstants.voice).Value;
                if (xnote.Elements(XmlConstants.staff).Any())
                    result.Serialization.Staff = xnote.Element(XmlConstants.staff).Value;

                this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        TimedEvent<Forward> ParseForward(XElement xelement)
        {
            TimedEvent<Forward> result = null;
            //var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            var duration = ParseDuration(xelement, out var durationEnum);

            if (xelement.Name == XmlConstants.forward)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Forward(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        TimedEvent<Backup> ParseBackup(XElement xelement)
        {
            TimedEvent<Backup> result = null;
            //var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            var duration = ParseDuration(xelement, out var durationEnum);

            if (xelement.Name == XmlConstants.backup)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Backup(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }



        int ParseDuration(XElement xnote, out DurationEnum durationEnum)
        {//The <duration> element moves the musical position when used in <backup> elements, <forward> elements, and <note> elements that do not contain a <chord> child element.
            var result = 0;
            durationEnum = DurationEnum.None;
            if (xnote.Elements(XmlConstants.duration).Any())
            {
                result = Int32.Parse(xnote.Element(XmlConstants.duration).Value);
            }
            if (xnote.Elements(XmlConstants.type).Any())
            {
                var xtype = xnote.Elements(XmlConstants.type).First();
                durationEnum = xtype.Value.ToDurationEnum();

                if (xnote.Elements(XmlConstants.time_modification).Any())
                {
                    var xtime_modification = xnote.Elements(XmlConstants.time_modification)
                        .First();
                    var tm = this.ParseTimeModification(xtime_modification);
                    result = tm.GetDuration(result);
                }
            }
            return result;
        }

        MusicXmlTimeModification ParseTimeModification(XElement xtime_modification)
        {
            return new MusicXmlTimeModification(xtime_modification);
        }



        MusicXmlModel CreateMusicXmlModel(MusicXmlScoreMetadata metadata, List<MusicXmlPart> parts)
        {
            var result = new MusicXmlModel();
            result.Metadata = metadata;
            foreach (var part in parts)
            {
                result.Add(part);
            }
            return result;
        }

        XDocument Transform()
        {
            var xslt = Helpers.LoadEmbeddedResource("parttime.xsl");
            var result = new XDocument();

            using (var stringReader = new StringReader(xslt))
            {
                using (XmlReader xsltReader = XmlReader.Create(stringReader))
                {
                    var transformer = new XslCompiledTransform();
                    transformer.Load(xsltReader);
                    using (XmlReader oldDocumentReader = this.Document.CreateReader())
                    {
                        using (XmlWriter newDocumentWriter = result.CreateWriter())
                        {
                            transformer.Transform(oldDocumentReader, newDocumentWriter);
                        }
                    }
                }
            }
            return result;
        }


    }//class
}//ns
