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
using Eric.Morrison.Harmony.MusicXml.Domain;
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

        public MusicXmlModel Import(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename);
            this.Document = XDocument.Load(filename);

            //if (!MusicXmlBase.ValidateMusicXmlSchema(this.Document))
            //    throw new NotImplementedException();

            var result = this.ParseImpl();

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
                    if (xmeasure.Elements(XmlConstants.attributes).Any())
                    {
                        this.ParsePartMetadata(part, xmeasure);
                    }

                    this.ParseMeasure(part, xmeasure);
                }
            }
            var result = this.CreateMusicXmlModel(metadata, parts);
            Debug.Assert(result.IsValid());
            return result;
        }

        MusicXmlModel CreateMusicXmlModel(MusicXmlScoreMetadata metadata, List<MusicXmlPart> parts)
        {
            var result = new MusicXmlModel();
            result.Metadata = metadata;
            result.Rhythm = this.ParsingContext.Rhythm;
            foreach (var part in parts)
            {
                result.Add(part);
            }

            this.CreateSections(result);
            
            return result;
        }

        void CreateSections(MusicXmlModel model)
        {
            foreach (var part in model.Parts)
            {
                var measures = (from m in part.Sections.First().Measures
                                where m.IsSectionStart || m.IsSectionEnd
                                select m)
                           .OrderBy(m => m.MeasureNumber)
                           .ToList();

                var pairs = measures.GetPairs().ToList();
                var ndxStart = int.MinValue;
                
                for (int i = 0; i < pairs.Count(); i += 2)
                {
                    var pair = pairs[i];
                    if (ndxStart == int.MinValue)
                        ndxStart = pair.First.MeasureNumber - 1;
                    var ndxEnd = pair.Second.MeasureNumber - ndxStart;

                    var selected = part.Sections.First().Measures
                        .Skip(ndxStart)
                        .Take(ndxEnd)
                        .ToList();
                    ndxStart = ndxEnd;

                    var section = new MusicXmlSection(part, selected);
                    part.Sections.Add(section);
                }
                part.Sections.Remove(part.Sections.First());
            }
        }

        MusicXmlScoreMetadata ParseScoreMetadata()
        {
            var result = new MusicXmlScoreMetadata();
            result.Credits = this.ParseCredits();
            result.Identification = this.ParseIdentification();

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

        void ParsePartMetadata(MusicXmlPart part, XElement xmeasure)
        {
            var xpart = this.Document.Elements(XmlConstants.part)
                .FirstOrDefault(x => x.Attribute(XmlConstants.id).Value == part.Identifier.ID);

            if (TryParseKeySignature(xmeasure, out var keySignature))
                part.KeySignature = keySignature;

            if (this.TryParsePpqn(xmeasure, out var ppqn))
            {
                if (this.TryParseTimeSignature(xmeasure, out var timeSignature))
                    this.ParsingContext.Rhythm
                        .SetTimeSignature(timeSignature)
                        .SetPulsesPerMeasure(timeSignature.BeatCount * ppqn);
            }

            if (this.TryParseStaves(xmeasure, out var staves))
                part.Staves = staves;

            if (this.TryParseTempo(xmeasure, out var tempo))
                this.ParsingContext.Rhythm.SetTempo(tempo);


            TimedEventFactory.Instance.PulsesPerMeasure =
                this.ParsingContext.Rhythm.PulsesPerMeasure;
        }

        void ParseMeasure(MusicXmlPart part, XElement xmeasure)
        {
            var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
            var result = new MusicXmlMeasure(part, measureNumber);

            this.ParsingContext.CurrentMeasure = result;
            this.PopulateMeasure(xmeasure, result);

            if (xmeasure.Elements(XmlConstants.barline).Any())
            {
                var barlineCtxs = this.ParseBarlineContexts(xmeasure);
                foreach (var barlineCtx in barlineCtxs)
                {
                    result.Add(barlineCtx);
                }
            }
            part.Sections.Last().Add(result);
        }

        private void PopulateMeasure(XElement xmeasure, MusicXmlMeasure measure)
        {
            var xelements = xmeasure.Elements().ToList();
            this.ParsingContext.CurrentOffset = 0;

            var chords = new List<TimedEventChordFormula>();
            var notes = new List<TimedEventNote>();
            var rests = new List<TimedEventRest>();
            var forwards = new List<TimedEventForward>();
            var backups = new List<TimedEventBackup>();
            foreach (var xelement in xelements)
            {
                if (xelement.Name == XmlConstants.harmony)
                {
                    var chord = this.ParseHarmony(xelement, chords);
                    Debug.Assert(chord != null);
                    chords.Add(chord);
                }

                else if (xelement.Elements(XmlConstants.pitch).Any())
                {
                    var note = this.ParsePitched(xelement);
                    if (note != null)
                    {
                        notes.Add(note);
                    }
                }

                else if (xelement.Elements(XmlConstants.rest).Any())
                {
                    var rest = this.ParseRest(xelement);
                    Debug.Assert(rest != null);
                    rests.Add(rest);
                }
                else if (xelement.Name == XmlConstants.forward)
                {
                    TimedEventForward forward = this.ParseForward(xelement);
                    Debug.Assert(forward != null);
                    forwards.Add(forward);
                }
                else if (xelement.Name == XmlConstants.backup)
                {
                    TimedEventBackup backup = this.ParseBackup(xelement);
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

        private MusicXmlRepeatContext ParseRepeats(XElement xmeasure)
        {
            MusicXmlRepeatContext result = null;

            RepeatEnum repeat = RepeatEnum.None;
            int nTimes = 1;
            if (xmeasure.Elements(XmlConstants.barline).Elements(XmlConstants.repeat).Any())
            {
                var xbarline = xmeasure.Elements(XmlConstants.barline)
                    .Where(x => null != x.Element(XmlConstants.repeat))
                    .First();
                var xrepeat = xbarline.Element(XmlConstants.repeat);
                var strDirection = xrepeat
                    .Attribute(XmlConstants.repeat_direction).Value;
                if (strDirection == XmlConstants.repeat_forward)
                {
                    repeat = RepeatEnum.Forward;
                }
                else if (strDirection == XmlConstants.repeat_backward)
                {
                    repeat = RepeatEnum.Backward;
                    if (xrepeat.Attributes(XmlConstants.repeat_after_jump).Any())
                    {
                        repeat = RepeatEnum.RepeatAfterJump;
                    }
                }

                if (xrepeat.Attributes(XmlConstants.repeat_times).Any())
                {
                    var strTimes = xrepeat.Attribute(XmlConstants.repeat_times).Value;
                    nTimes = int.Parse(strTimes);
                }
            }

            else if (xmeasure.Elements(XmlConstants.coda).Any())
            {
                repeat = RepeatEnum.Coda;
            }
            else if (xmeasure.Elements(XmlConstants.segno).Any())
            {
                repeat = RepeatEnum.Segno;
            }

            if (repeat != RepeatEnum.None)
            {
                result = new MusicXmlRepeatContext(repeat, nTimes);
            }
            return result;
        }

        private List<MusicXmlBarlineContext> ParseBarlineContexts(XElement xmeasure)
        {
            var result = new List<MusicXmlBarlineContext>();

            if (xmeasure.Elements(XmlConstants.barline).Any())
            {
                foreach (var xbarline in xmeasure.Elements(XmlConstants.barline))
                {
                    var eBarlineStyle = BarlineStyleEnum.None;
                    if (xbarline.Elements(XmlConstants.bar_style).Any())
                    {
                        var xbarlineStyle = xbarline.Element(XmlConstants.bar_style);
                        var strBarlineStyle = xbarlineStyle.Value;

                        if (strBarlineStyle == XmlConstants.bar_style_heavy_heavy)
                            eBarlineStyle = BarlineStyleEnum.Heavy_Heavy;
                        else if (strBarlineStyle == XmlConstants.bar_style_heavy_light)
                            eBarlineStyle = BarlineStyleEnum.Heavy_Light;
                        else if (strBarlineStyle == XmlConstants.bar_style_light_heavy)
                            eBarlineStyle = BarlineStyleEnum.Light_Heavy;
                        else if (strBarlineStyle == XmlConstants.bar_style_light_light)
                            eBarlineStyle = BarlineStyleEnum.Light_Light;
                    }

                    var ctx = new MusicXmlBarlineContext(eBarlineStyle);
                    if (xbarline.Attributes(XmlConstants.barline_location).Any())
                    {
                        if (xbarline.Attribute(XmlConstants.barline_location)
                            .Value == XmlConstants.barline_location_left)
                            ctx.IsLeft = true;
                        else
                            ctx.IsRight = true;
                    }

                    if (xbarline.Elements(XmlConstants.ending).Any())
                    {
                        var xending = xbarline.Elements(XmlConstants.ending).First();
                        var ending = this.ParseEnding(xending);
                        ctx.Add(ending);
                    }

                    if (xbarline.Elements(XmlConstants.repeat).Any())
                    {
                        var repeatCtx = this.ParseRepeats(xmeasure);
                        ctx.RepeatContext = repeatCtx;
                    }

                    result.Add(ctx);

                }
            }
            return result;
        }

        private MusicXmlEnding ParseEnding(XElement xending)
        {
#if false
<ending number="1,2" type="start" default-y="30" end-length="15">1., 2.</ending>

<ending number="1,2" type="stop"/>

<ending number="3" type="start" default-y="30" end-length="15">3.</ending>
#endif
            MusicXmlEnding result = null;
            var endingNumbers = new List<string>();
            if (xending.Attributes(XmlConstants.ending_number).Any())
            {//Split the ending numbers. (<ending number="1,2")
                var item = xending.Attribute(XmlConstants.ending_number).Value;
                {
                    endingNumbers = item.Split(new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                foreach (var endingNumber in endingNumbers)
                {
                    var eEndingType = EndingTypeEnum.Unknown;
                    if (xending.Attributes(XmlConstants.ending_type).Any())
                    {
                        var strEndingType = xending.Attribute(XmlConstants.ending_type).Value;
                        if (strEndingType == XmlConstants.ending_type_start)
                            eEndingType = EndingTypeEnum.Start;
                        else if (strEndingType == XmlConstants.ending_type_stop)
                            eEndingType = EndingTypeEnum.Stop;
                        else if (strEndingType == XmlConstants.ending_type_discontinue)
                            eEndingType = EndingTypeEnum.Discontinue;
                    }
                    result = new MusicXmlEnding(eEndingType, endingNumber);
                }
            }


            //throw new NotImplementedException();
            new object();
            return result;
        }

        TimedEventRest ParseRest(XElement xnote)
        {
            TimedEventRest result = null;
            var duration = ParseDuration(xnote, out var durationEnum,
                out var timeModification, out var isDotted);
            if (xnote.Elements(XmlConstants.rest).Any())
            {
                if (xnote.Element(XmlConstants.rest).Attributes(XmlConstants.measure).Any())
                {
                    durationEnum = DurationEnum.Duration_Whole;
                }

                result = TimedEventFactory.Instance.CreateTimedEvent(new Rest(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration,
                    isDotted,
                    durationEnum,
                    timeModification,
                    xnote);

                result.Serialization.Voice = xnote.Element(XmlConstants.voice).Value;
                if (xnote.Elements(XmlConstants.staff).Any())
                    result.Serialization.Staff = xnote.Element(XmlConstants.staff).Value;

                this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        TimedEventForward ParseForward(XElement xelement)
        {
            TimedEventForward result = null;
            //var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            var duration = ParseDuration(xelement, out var durationEnum,
                out var timeModification, out var isDotted);

            if (xelement.Name == XmlConstants.forward)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Forward(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration, timeModification);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        TimedEventBackup ParseBackup(XElement xelement)
        {
            TimedEventBackup result = null;
            //var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            var duration = ParseDuration(xelement, out var durationEnum,
                out var timeModification, out var isDotted);

            if (xelement.Name == XmlConstants.backup)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Backup(),
                    this.ParsingContext.Rhythm,
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    duration,
                    timeModification);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }



        int ParseDuration(XElement xnote, out DurationEnum durationEnum,
            out MusicXmlTimeModification timeModification, out bool isDotted)
        {//The <duration> element moves the musical position when used in <backup> elements, <forward> elements, and <note> elements that do not contain a <chord> child element.
            isDotted = false;
            if (xnote.Elements(XmlConstants.dot).Any())
                isDotted = true;

            var result = 0;
            durationEnum = DurationEnum.None;
            timeModification = null;
            if (xnote.Elements(XmlConstants.duration).Any())
            {
                result = Int32.Parse(xnote.Element(XmlConstants.duration).Value);
            }
            if (xnote.Elements(XmlConstants.type).Any())
            {
                var xtype = xnote.Elements(XmlConstants.type).First();
                durationEnum = xtype.Value.ToDurationEnum();
            }
            if (xnote.Descendants(XmlConstants.normal_type).Any())
            {
                var xtype = xnote.Descendants(XmlConstants.normal_type).First();
                durationEnum = xtype.Value.ToDurationEnum();
            }
            if (xnote.Elements(XmlConstants.time_modification).Any())
            {
                var xtime_modification = xnote.Elements(XmlConstants.time_modification)
                    .First();
                timeModification = this.ParseTimeModification(xtime_modification);
                result = timeModification.GetDuration(result);
            }

            return result;
        }

        MusicXmlTimeModification ParseTimeModification(XElement xtime_modification)
        {
            return new MusicXmlTimeModification(xtime_modification);
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
