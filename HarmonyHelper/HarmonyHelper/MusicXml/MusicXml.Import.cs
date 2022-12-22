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

        public MusicXmlParsingResult Parse(string filename)
        {
            //var xml = this.LoadEmbeddedResource();

            this.Document = XDocument.Load(filename);

            MusicXmlBase.ValidateMusicXmlSchema(this.Document);

            var result = this.ParseImpl(this.Document);
            return result;
        }

        MusicXmlParsingResult ParseImpl(XDocument doc)
        {
            //this.ValidateMusicXmlSchema(doc);

            var metadata = this.ParseScoreMetadata(doc);
            this.ParsingContext.Metadata = metadata;
            var score = this.Document.Elements(XmlConstants.score_partwise).First();

#warning FIXME:            
            var parts = this.ParseParts(doc).Skip(1).ToList();
            foreach (var part in parts)
            {
                //this.ParsingContext.CurrentPart = part;
                var xmeasures = part.XElement.Elements(XmlConstants.measure)
                    .ToList();
                foreach (var xmeasure in xmeasures)
                {
                    var measure = this.ParseMeasure(xmeasure);
                    part.Measures.Add(measure);
                }
            }
            var result = this.CreateParsingResult(metadata, parts);
            return result;
        }

        MusicXmlParsingResult CreateParsingResult(MusicXmlScoreMetadata metadata, List<MusicXmlPart> parts)
        {
            var result = new MusicXmlParsingResult();
            result.Metadata = metadata;
            result.Parts = parts;
            return result;
        }

        private void PreParseTiedNotes(XDocument doc)
        {
            var xnotesArr = doc.Descendants().Where(x => x.Name == XmlConstants.note
                && x.Elements(XmlConstants.tie).Any()).ToArray();
            var xnotes = xnotesArr.Reverse().ToList();

            var seq = (from xn in xnotes
                       from xp in xn.Ancestors(XmlConstants.part)
                       from xm in xp.Ancestors(XmlConstants.measure)
                       select new
                       {
                           Measure = xm.Attribute(XmlConstants.number).Value,
                           Part = xp.Attribute(XmlConstants.id).Value,
                           TieType = this.ParseTie(xn),
                           Note = Parse_HarmonyHelper_Note(xn),
                           XNote = xn,
                       })
               .ToList();


            var groupings = seq.GroupBy(x => x.TieType).ToList();
            foreach (var grouping in groupings)
            {
                var list = grouping.ToList();
                new object();
            }

            foreach (var item in seq)
            {
                new object();
            }


            //.Attribute(XmlConstants.id)
            //.Value;



            foreach (var xnote in xnotes)
            {
                var xpart = xnote.Ancestors(XmlConstants.part)
                    .First();
                var xmeasure = xpart.Ancestors(XmlConstants.measure)
                    .First();

            }


                List<XElement> start = new List<XElement>();
            List<XElement> stop = new List<XElement>();
            List<XElement> both = new List<XElement>();
            foreach (var xnote in xnotes)
            { 
                var tieType = this.ParseTie(xnote);
                if (tieType == TieTypeEnum.Start)
                    start.Add(xnote);
                if (tieType == TieTypeEnum.Stop)
                    stop.Add(xnote);
                if (tieType == TieTypeEnum.StartStop)
                    both.Add(xnote);
            }

            new object();
        }

        XDocument Transform()
        {
            var xslt = LoadEmbeddedResource("parttime.xsl");
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

        MusicXmlScoreMetadata ParseScoreMetadata(XDocument doc)
        {
#if false
   <measure number="1">
      <attributes>
        <divisions>120</divisions>
        <key>
           <fifths>-2</fifths>
        </key>
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
        <clef>
           <sign>TAB</sign>
           <line>5</line>
        </clef>
           <staff-details>
           <staff-lines>4</staff-lines>
            <staff-tuning line="1">
             <tuning-step>E</tuning-step>
             <tuning-octave>1</tuning-octave>
             </staff-tuning>
            <staff-tuning line="2">
             <tuning-step>A</tuning-step>
             <tuning-octave>1</tuning-octave>
             </staff-tuning>
            <staff-tuning line="3">
             <tuning-step>D</tuning-step>
             <tuning-octave>2</tuning-octave>
             </staff-tuning>
            <staff-tuning line="4">
             <tuning-step>G</tuning-step>
             <tuning-octave>2</tuning-octave>
             </staff-tuning>
           </staff-details>
      </attributes>
      <sound tempo="160"/>
      <forward>
         <duration>480</duration>
      </forward>
   </measure>
#endif
            var result = new MusicXmlScoreMetadata();
            result.Title = this.ParseTitle(doc);
            result.KeySignature = this.ParseKeySignature(doc);
            result.TimeSignatue = this.ParseTimeSignature(doc);
            result.Tempo = this.ParseTempo(doc);
            result.PulsesPerQuarterNote = this.ParsePpqn(doc);

            TimedEventFactory.Instance.PulsesPerMeasure = result.PulsesPerMeasure;

            return result;
        }

        int ParsePpqn(XDocument doc)
        {//<divisions>120</divisions>
            var result = Int32.Parse(
                doc.Descendants(XmlConstants.divisions)
                .First()
                .Value);
            return result;
        }

        int ParseTempo(XDocument doc)
        {//<sound tempo="160"/>
            var result = Int32.Parse(
                doc.Descendants(XmlConstants.sound)
                .First()
                .Attribute(XmlConstants.tempo)
                .Value);
            return result;
        }

        string ParseTitle(XDocument doc)
        {
            var result = doc.Descendants(XmlConstants.work_title).FirstOrDefault()?.Value;
            return result;
        }

        TimeSignature ParseTimeSignature(XDocument doc)
        {
#if false
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
#endif
            var ts = doc.Descendants(XmlConstants.time).First();
            var beats = ts.Descendants(XmlConstants.beats).First().Value;
            var beat_type = ts.Descendants(XmlConstants.beat_type).First().Value;
            var result = new TimeSignature(beats, beat_type);
            return result;
        }

        KeySignature ParseKeySignature(XDocument doc)
        {
            KeySignature result = null;
            var fifths = Int32.Parse(
                doc.Descendants(XmlConstants.key)
                .Descendants(XmlConstants.fifths)
                .First().Value);
            if (fifths == 0)
            {
                result = KeySignature.CMajor;
            }
            else if (fifths < 0)
            {
                result = KeySignature.Catalog
                    .Where(x => x.UsesFlats
                        && x.AccidentalCount == Math.Abs(fifths))
                    .First();
            }
            else
            {
                result = KeySignature.Catalog
                    .Where(x => x.UsesSharps
                        && x.AccidentalCount == fifths)
                    .First();
            }
            return result;
        }

        List<PartIdentifier> ParsePartList(XDocument doc)
        {
#if false
  <part-list>
   <score-part id="P1">
      <part-name>Bass</part-name>
  </score-part>
#endif
            var result = new List<PartIdentifier>();
            var part_list = doc.Descendants(XmlConstants.part_list).First();
            var score_parts = doc.Descendants(XmlConstants.score_part);
            foreach (var score_part in score_parts)
            {
                var id = score_part.Attribute(XmlConstants.id).Value;
                var name = doc.Descendants(XmlConstants.part_name).First().Value;
                var pid = new PartIdentifier(id, name);
                result.Add(pid);
            }
            return result;
        }

#if true
        List<MusicXmlPart> ParseParts(XDocument doc)
        {
            var result = new List<MusicXmlPart>();

            var pids = new List<PartIdentifier>();
            var score_parts = doc.Descendants(XmlConstants.score_part);
            foreach (var score_part in score_parts)
            {
                var id = score_part.Attribute(XmlConstants.id).Value;
                var name = doc.Descendants(XmlConstants.part_name).First().Value;
                var pid = new PartIdentifier(id, name);
                pids.Add(pid);
            }

            var xparts = doc.Descendants(XmlConstants.part);
            foreach (var xpart in xparts)
            {
                var partName = xpart.Attribute(XmlConstants.id).Value;
                var pid = pids.First(x => x.ID == partName);
                result.Add(new MusicXmlPart(pid, xpart));
            }
            return result;
        }

#endif
        private void PopulateMeasure(List<XElement> elements, MusicXmlMeasure measure)
        {
            this.ParsingContext.CurrentOffset = 0;

            var chords = new List<TimedEvent<ChordFormula>>();
            var notes = new List<TimedEvent<Note>>();
            var rests = new List<TimedEvent<Rest>>();
            foreach (var xelement in elements)
            {
                //Debug.WriteLine(this.ParsingContext.CurrentOffset);
                if (xelement.Name == XmlConstants.backup)
                {
                    var duration = int.Parse(xelement.Element(XmlConstants.duration).Value);
                    Debug.Assert(duration == 480);
                    this.ParsingContext.CurrentOffset = 0;
                    //this.ParsingContext.CurrentOffset -= duration;
                }

                else if (xelement.Name == XmlConstants.harmony)
                {
                    var chord = this.ParseChord(xelement, chords);
                    Debug.Assert(chord != null);
                    chords.Add(chord);
                }
                
                else if (xelement.Elements(XmlConstants.pitch).Any())
                {
                    var note = this.ParsePitched(xelement);
                    if (note != null);
                        notes.Add(note);
                }
                
                else if (xelement.Descendants(XmlConstants.rest).Any())
                {
                    var rest = this.ParseRest(xelement);
                    Debug.Assert(rest != null);
                    rests.Add(rest);
                }
            }

            measure.Chords = chords;
            measure.Notes = notes;
            measure.Rests = rests;
        }

#if false
        MusicXmlPart ParsePart(XElement part)
        {
#if false
    <part id="P1">
      <attributes>
        <divisions>120</divisions>
        <key>
          <fifths>-2</fifths>
        </key>
        <time>
          <beats>4</beats>
          <beat-type>4</beat-type>
        </time>
        <clef>
          <sign>TAB</sign>
          <line>5</line>
        </clef>
        <staff-details>
          <staff-lines>4</staff-lines>
          <staff-tuning line="1">
            <tuning-step>E</tuning-step>
            <tuning-octave>1</tuning-octave>
          </staff-tuning>
          <staff-tuning line="2">
            <tuning-step>A</tuning-step>
            <tuning-octave>1</tuning-octave>
          </staff-tuning>
          <staff-tuning line="3">
            <tuning-step>D</tuning-step>
            <tuning-octave>2</tuning-octave>
          </staff-tuning>
          <staff-tuning line="4">
            <tuning-step>G</tuning-step>
            <tuning-octave>2</tuning-octave>
          </staff-tuning>
        </staff-details>
      </attributes>
      <sound tempo="160" />
      <forward>
        <duration>480</duration>
      </forward>
    </part>

#endif
            var result = MusicXmlPart.Parse(part);

            var measures = part.Descendants(XmlConstants.measure);
            foreach (var measure in measures)
            {
                result.Measures.Add(
                    this.ParseMeasure(measure));
            }
            return result;
        }

        MusicXmlPart ParsePart(XElement part)
        {
            var partName = part.Attribute(XmlConstants.id).Value;
#if DEBUG
            this.CurrentPartName = partName;
#endif
            var result = new MusicXmlPart(partName);
            var measures = part.Descendants(XmlConstants.measure);
            foreach (var measure in measures)
            {
                result.Measures.Add(
                    this.ParseMeasure(measure));
            }
            return result;
        }
#endif

        List<XElement> GetMusicalElements(XElement part)
        {
            var result = new List<XElement>();

            var measures = part.Elements(XmlConstants.measure);
            foreach (var measure in measures)
            {
                var measureNumber = measure.Attribute(XmlConstants.number);
                var measureMarker = new XElement(XmlConstants.measure, measureNumber);
                result.Add(measureMarker);

                var elements = measure.Elements();  
                foreach (var element in elements)
                {
                    if (element.Name == XmlConstants.backup)
                    {
                        var duration = this.ParseDuration(element);
                        this.ParsingContext.CurrentOffset -= duration;
                    }
                    else if (element.Name == XmlConstants.harmony)
                    {
                        result.Add(element);
                        //result.Add(this.ParseHarmony(element));
                    }
                    else if (element.Name == XmlConstants.note)
                    {
                        result.Add(element);
                        //result.Add(this.ParseNote(element));
                    }
                }
            }

            result = this.PrepareChords(result);
            result = this.PrepareTies(result);

            return result;
        }

        private List<XElement> PrepareChords(List<XElement> musicalElements)
        {
            foreach (var musicalElement in musicalElements)
            {
                if (musicalElement.ElementsAfterSelf().Count() > 0
                    && musicalElement.Name == XmlConstants.note
                    && musicalElement.Elements(XmlConstants.chord).Any()
                    && musicalElement.ElementsAfterSelf()
                        .FirstOrDefault()
                        .Elements(XmlConstants.chord)
                        .Any())
                {
                    musicalElement.Add(new XElement(XmlConstants.chord_start));
                }
            }
            return musicalElements;
        }

        private List<XElement> PrepareTies(List<XElement> musicalElements)
        {
            foreach (var musicalElement in musicalElements)
            {
                if (musicalElement.ElementsAfterSelf().Count() > 0
                    && musicalElement.Name == XmlConstants.note //note
                    && musicalElement.Elements()
                    .Where(x => x.Name.ToString() == XmlConstants.tie
                        && x.Value == XmlConstants.start) //child element "tie" with attribute "start"
                    .Any()
                    && musicalElement.ElementsAfterSelf()
                        .FirstOrDefault()
                        .Elements(XmlConstants.chord)
                        .Any())
                {
                    musicalElement.Add(new XElement(XmlConstants.chord_start));
                }
            }
            return musicalElements;
        }

        MusicXmlMeasure ParseMeasure(XElement xmeasure)
        {
            var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
            var result = new MusicXmlMeasure(measureNumber);
            this.ParsingContext.CurrentMeasure = result;

            var elements = xmeasure.Elements().ToList();
            this.PopulateMeasure(elements, result);
            //foreach (var xelement in elements)
            //{
            //    if (xelement.Name == XmlConstants.backup)
            //    {
            //        var duration = int.Parse(xelement.Element(XmlConstants.duration).Value);
            //        Debug.Assert(duration == 480);
            //        this.ParsingContext.CurrentOffset = 0;
            //    }
            //    else if (xelement.Name == XmlConstants.harmony)
            //    {
            //        result.Add(this.ParseHarmony(xelement));
            //    }
            //    else if (xelement.Name == XmlConstants.note)
            //    {
            //        result.Add(this.ParseNote(xelement));
            //    }
            //}
            return result;
        }

        [Obsolete("", true)]
        TimedEvent<Note> ParseNote(XElement xnote)
        {// https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/note/
         //Debug.WriteLine($"{note}");
            TimedEvent<Note> result = null;
                        var xelements = xnote.Elements();
            foreach (var xelement in xelements)
            {// <pitch>, <unpitched> or <rest>
                if (xnote.Elements(XmlConstants.pitch).Any())
                {
                    result = this.ParsePitched(xnote);
                }
                //else if (xnote.Elements(XmlConstants.unpitched).Any())
                //{
                //    this.ParseUnpitched(xnote);
                //}
                //else if (xnote.Elements(XmlConstants.rest).Any())
                //{
                //    this.ParseRest(xnote);
                //}
                //else
                //{
                //    throw new NotImplementedException();
                //}
            }

            return result;
#if false
            TimedEvent<NoteName> result = null;

            if (note.Descendants("pitch").Any())
            {
                var xpitch = note.Descendants("pitch").First();
                var nn = this.ParsePitch(xpitch);

                Debug.Assert(duration != int.MinValue);
                result = new TimedEvent<NoteName>(nn,
                    this.CurrentOffset,
                    this.CurrentOffset + duration);
                this.CurrentOffset += duration;
            }
            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
            return result;
#endif
        }

        private TimedEvent<Note> ParsePitched(XElement xnote)
        {
            TimedEvent<Note> result = null;

            Note hhNote = null;
            int duration = 0;
            int start = 0;
            int end = 0;

#if false //Ignore tied notes, for now.
            if (xnote.Elements(XmlConstants.tie).Any())
            {
                var tieType = this.ParseTie(xnote);
                Debug.WriteLine($"**** tie count = {xnote.Descendants(XmlConstants.tie).Count()}");
                if (tieType == TieTypeEnum.Start || tieType == TieTypeEnum.Stop)
                {// There can be a start AND a stop.
                    var tiedNote = new TiedNoteContext(
                            this, xnote, tieType,
                            this.ParsingContext.CurrentMeasure, this.ParsingContext.CurrentOffset);
                    this.ParsingContext.TiedNotes.TryAdd(tiedNote, tiedNote);

                    tiedNote.TryResolve();
                }
                //short circuit processing for tied notes.
                return result;
                //if (TieTypeEnum.Stop == note.GetTieType())
                //{
                //    new object();
                //}
            }
#endif
            if (xnote.Elements(XmlConstants.pitch).Any())
            {
                hhNote = this.Parse_HarmonyHelper_Note(xnote);
            }
            if (xnote.Elements(XmlConstants.type).Any())
            {
                duration = this.ParseDuration(xnote);
                start = this.ParsingContext.CurrentOffset;
                end = this.ParsingContext.CurrentOffset + duration;

                if (this.IsFirstNoteOfChord(xnote))
                {
                    this.ParsingContext.ChordTimeContext.Start = start;
                    this.ParsingContext.ChordTimeContext.End = end;
                    this.ParsingContext.ChordTimeContext.FirstNote = result;
                }
                else if (this.IsLastNoteOfChord(xnote))
                {
                    start = this.ParsingContext.ChordTimeContext.Start;
                    end = this.ParsingContext.ChordTimeContext.End;
                    this.ParsingContext.ChordTimeContext.Clear();
                    this.ParsingContext.CurrentOffset += duration;
                    new object();
                }
                else if (this.IsNoteOfChord(xnote))
                {
                    start = this.ParsingContext.ChordTimeContext.Start;
                    end = this.ParsingContext.ChordTimeContext.End;
                }
                else //we're not in a chord.
                {
                    this.ParsingContext.CurrentOffset += duration;
                }
                Debug.Assert(start != end);
            }

            //result = new TimedEvent<Note>(hhNote, start, end);
            result = TimedEventFactory.Instance.CreateTimedEvent(hhNote,
                this.ParsingContext.CurrentMeasure.MeasureNumber,
                start,
                end);


            return result;
        }

        TieTypeEnum ParseTie(XElement note)
        {
#if false
<note attack="18">
  <duration>60</duration>
  <tie type="start" />
</note>
#endif
            var result = TieTypeEnum.Unknown;
            var ties = note.Descendants(XmlConstants.tie).ToList();
            if (ties.Count == 1)
            {
                var attrVal = ties[0].Attribute(XmlConstants.type).Value;
                if (XmlConstants.start == attrVal)
                    result = TieTypeEnum.Start;
                else
                    result = TieTypeEnum.Stop;
            }
            else
            {
                result = TieTypeEnum.StartStop;
            }
            return result;
        }

        bool IsFirstNoteOfChord(XElement note)
        {
            var elements = note.ElementsAfterSelf(XmlConstants.note).ToList();
            var result = (note.ElementsAfterSelf()
                .FirstOrDefault()
                ?.Elements(XmlConstants.chord)
                ?.Any()).GetValueOrDefault();
            if (result)
            {
                new object();
            }
            return result;
        }

        bool IsNoteOfChord(XElement note)
        {
            var result = false;
            if (null != note)
            {
                result = note.Elements(XmlConstants.chord).Any();
                if (result)
                {
                    new object();
                }
            }
            return result;
        }
        bool IsLastNoteOfChord(XElement note)
        {
            var beforeElements = note.ElementsBeforeSelf(XmlConstants.note)
                .ToList();
            var afterElements = note.ElementsBeforeSelf(XmlConstants.note)
                .ToList();
            var before = note.ElementsBeforeSelf(XmlConstants.note)
                .FirstOrDefault();
            var after = note.ElementsAfterSelf(XmlConstants.note)
                .FirstOrDefault();

            var result = false;
            if (IsNoteOfChord(note))
            {
                new object();
                if (!IsNoteOfChord(after))
                {
                    result = true;
                }
            }

            if (result)
            {
                new object();
            }

            return result;
        }

        public HashSet<string> UnpitchedDescendants { get; private set; } = new HashSet<string>();

        private void ParseUnpitched(XElement xnote)
        {
            throw new NotImplementedException("No example data to work from.");
            var descendants = xnote.Elements();
            foreach (var descendant in descendants)
            {
                this.UnpitchedDescendants.Add(descendant.Name.ToString());
            }
        }

        TimedEvent<Rest> ParseRest(XElement xnote)
        {
            TimedEvent<Rest> result = null;
            var duration = ParseDuration(xnote);
            if (xnote.Descendants(XmlConstants.rest).Any())
            {
                //result = new TimedEvent<Rest>(new Rest(), 
                //    this.ParsingContext.CurrentOffset, 
                //    this.ParsingContext.CurrentOffset + duration);
                result = TimedEventFactory.Instance.CreateTimedEvent(new Rest(),
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    this.ParsingContext.CurrentOffset + duration);


                this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        public int ParseDuration(XElement xnote)
        {//The <duration> element moves the musical position when used in <backup> elements, <forward> elements, and <note> elements that do not contain a <chord> child element.
            var result = 0;
            //if (!note.Elements(XmlConstants.chord).Any())
            {
                var duration = xnote.Elements(XmlConstants.type).First();
                var val = duration.Value;
                result = this.GetDuration(val);
            }
            if (xnote.Elements(XmlConstants.time_modification).Any())
            {
                var xtime_modification = xnote.Elements(XmlConstants.time_modification)
                    .First();
                var tm = this.ParseTimeModification(xtime_modification);
                result = tm.GetDuration(result);
            }
            return result;
        }

        TimeModification ParseTimeModification(XElement xtime_modification)
        {
            return new TimeModification(xtime_modification);
        }

        private int GetDuration(string val)
        {
            var divisor = 0;
            switch (val)
            {
                case XmlConstants.NoteTypes.NoteType_1024th:
                    {
                        divisor = 1024;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_512th:
                    {
                        divisor = 512;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_256th:
                    {
                        divisor = 256;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_128th:
                    {
                        divisor = 128;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_64th:
                    {
                        divisor = 64;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_32nd:
                    {
                        divisor = 32;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_16th:
                    {
                        divisor = 16;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_eighth:
                    {
                        divisor = 8;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_quarter:
                    {
                        divisor = 4;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_half:
                    {
                        divisor = 2;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_whole:
                    {
                        divisor = 1;
                        break;
                    }
                case XmlConstants.NoteTypes.NoteType_breve:
                case XmlConstants.NoteTypes.NoteType_long:
                case XmlConstants.NoteTypes.NoteType_maxima:
                default:
                    {
                        throw new NotImplementedException();
                        break;
                    }
            }
            var result = this.ParsingContext.Metadata.PulsesPerMeasure / divisor;
            return result;
        }

        public Note Parse_HarmonyHelper_Note(XElement note)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif
            Note result = null;
            var pitch = note.Elements(XmlConstants.pitch).First();

            var strNoteName = pitch.Elements(XmlConstants.step).First().Value;
            var modifier = pitch.Elements(XmlConstants.alter).FirstOrDefault()?.Value;
            if (modifier != null)
            {
                if (modifier == "-1")
                    strNoteName += "b";
                else
                    strNoteName += "#";
            }
            var octave = (OctaveEnum)Int32.Parse(
                pitch.Elements(XmlConstants.octave)
                .First()
                .Value);

            if (NoteNameParser.TryParse(strNoteName, out var notes, out var msg))
            {
                var nn = notes.First();
                result = new Note(nn, octave);
            }
            else
            {
                throw new ArgumentException(msg);
            }
            return result;
        }

        TimedEvent<ChordFormula> ParseChord(XElement harmony, List<TimedEvent<ChordFormula>> existingChords)
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
            var root = harmony.Descendants(XmlConstants.root).First();
            var strRoot = this.ParseRoot(root);

            var kind = harmony.Descendants(XmlConstants.kind).First();
            var formula = this.ParseKind(strRoot, kind);


            var start = ParsingContext.CurrentOffset;
            var end = this.ParsingContext.Metadata.PulsesPerMeasure;

            if (harmony.Elements(XmlConstants.offset).Any())
            {
                start = ParsingContext.CurrentOffset + int.Parse(
                    harmony.Element(XmlConstants.offset).Value);
            }
            if (harmony.ElementsAfterSelf().Elements(XmlConstants.harmony).Any())
            {
                var sibling = harmony.ElementsAfterSelf().Elements(XmlConstants.harmony).First();
                if (sibling.Elements(XmlConstants.offset).Any())
                {
                    end = int.Parse(
                        sibling.Element(XmlConstants.offset).Value);
                }
            }
            Debug.Assert(start >= 0);

            //var result = new TimedEvent<ChordFormula>(formula,
            //    offset,
            //    this.ParsingContext.CurrentMeasure.MeasureNumber 
            //        * this.ParsingContext.Metadata.PulsesPerMeasure
            //        + offset);
            //throw new NotImplementedException("We're getting wacky TimeContexts.");
            var result = TimedEventFactory.Instance.CreateTimedEvent(formula,
                this.ParsingContext.CurrentMeasure.MeasureNumber,
                start,
                end);
            
            if (existingChords.Count != 0)
            {
                var previousChord = existingChords.Last();
                previousChord.TimeContext.RelativeEnd = result.RelativeStart;
            }

            return result;
        }

        ChordFormula ParseKind(string root, XElement kind)
        {
#if false
  <kind text="Maj7">major-seventh</kind>
  OR
  <kind>major</kind>
#endif
            var chordType = kind.Attribute(XmlConstants.text)?.Value;
            var chord = root + chordType;
            var result = ChordFormulaParser.Parse(chord).First();
            return result;
        }

        string ParseRoot(XElement root)
        {
#if false
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
#endif
            var result = root.Descendants(XmlConstants.root_step).First().Value;
            var modifier = root.Descendants(XmlConstants.root_alter).FirstOrDefault()?.Value;
            if (modifier != null)
            {
                if (modifier == "-1")
                    result += "b";
                else
                    result += "#";
            }
            return result;
        }

    }//class
}//ns
