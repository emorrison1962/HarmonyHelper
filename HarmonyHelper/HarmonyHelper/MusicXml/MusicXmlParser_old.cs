#if false
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
    public class MusicXmlParser : IMusicXmlParser
    {
#region Constants

#endregion

#region Properties
#if DEBUG
        string CurrentPartName { get; set; }
#endif

        int _CurrentMeasure = 0;
        int CurrentMeasure
        {
            get
            {
                return _CurrentMeasure;
            }
            set
            {
                this.CurrentOffset = 0;
                _CurrentMeasure = value;
            }
        }

        public MusicXmlMeasure CurrentXmlMeasure { get; private set; }

        int _CurrentOffset = 0;
#warning FIXME: Refactor this to a backing store prop after setters are working properly.
        int CurrentOffset
        {
            get
            {
                return _CurrentOffset;
            }
            set
            {
                _CurrentOffset = value;
                //Debug.Assert(_CurrentOffset <= 480);
                //Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }
        MusicXmlModel ParsingResult { get; set; }

        ConcurrentDictionary<TiedNoteContext, TiedNoteContext> TiedNotes { get; set; } = new ConcurrentDictionary<TiedNoteContext, TiedNoteContext>();

        ChordTimeContext ChordTimeContext { get; set; } = new ChordTimeContext();

        XDocument Document { get; set; }
#endregion

        public MusicXmlParser()
        {
            this.ParsingResult = new MusicXmlModel();
        }

        public MusicXmlModel Parse(string filename)
        {
            //var xml = this.LoadEmbeddedResource();

            this.Document = XDocument.Load(filename);
            var result = this.Parse(this.Document);
            return result;
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

        MusicXmlModel Parse(XDocument doc)
        {
            this.Document = this.Transform();

            ParseMeasures
                ParseParts
                Parse

            this.ParseScoreMetadata(doc);
            this.ParseParts(doc);
            return this.ParsingResult;
        }

        void ParseScoreMetadata(XDocument doc)
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
            result.PPQN = this.ParsePpqn(doc);

            this.ParsingResult.Metadata = result;
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
            var result = doc.Descendants(XmlConstants.work_title).First().Value;
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
            var result = KeySignature.CMajor;
            var fifths = Int32.Parse(
                doc.Descendants(XmlConstants.key)
                .Descendants(XmlConstants.fifths)
                .First().Value);
            if (fifths < 0)
            {
                KeySignature.Catalog
                    .Where(x => x.UsesFlats
                        && x.AccidentalCount == Math.Abs(fifths))
                    .First();
            }
            else
            {
                KeySignature.Catalog
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
                result.Add(new PartIdentifier(id, name));
            }
            return result;
        }

        void ParseParts(XDocument doc)
        {
            var parts = doc.Descendants(XmlConstants.part);
            foreach (var part in parts)
            {
                var partName = part.Attribute(XmlConstants.id).Value;
                var xmlPart = new MusicXmlPart(partName);

                var elements = this.GetMusicalElements(part);

                this.ParseMusicalElements(xmlPart, elements);
                new object();
                //this.ParsingResult.Parts.Add(
                //    this.ParsePart(part));
            }
        }

        private void ParseMusicalElements(MusicXmlPart part, List<XElement> elements)
        {
            foreach (var element in elements)
            {
                if (element.Name == XmlConstants.backup)
                {
                    var duration = this.ParseDuration(element);
                    this.CurrentOffset -= duration;
                }
                else if (element.Name == XmlConstants.harmony)
                {
                    var chords = new List<TimedEvent<ChordFormula>>();
                    chords.Add(this.ParseHarmony(element));
                }
                else if (element.Name == XmlConstants.note)
                {
                    var events = new List<TimedEvent<Note>>();
                    events.Add(this.ParseNote(element));
                }
            }
        }

#if false
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
                        this.CurrentOffset -= duration;
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

        [Obsolete("Need to get rid of this so that I can look ahead across bar lines.", true)]
        MusicXmlMeasure ParseMeasure(XElement measure)
        {
            ParsePart
            var currentMeasure = Int32.Parse(measure.Attribute(XmlConstants.number).Value);
            this.CurrentMeasure = currentMeasure;
            var result = this.CurrentXmlMeasure = new MusicXmlMeasure(currentMeasure);

            var elements = measure.Elements();
            foreach (var element in elements)
            {
                if (element.Name == XmlConstants.backup)
                {
                    var duration = this.ParseDuration(element);
                    this.CurrentOffset -= duration;
                }
                else if (element.Name == XmlConstants.harmony)
                {
                    result.Add(this.ParseHarmony(element));
                }
                else if (element.Name == XmlConstants.note)
                {
                    result.Add(this.ParseNote(element));
                }
            }
            return result;
        }

        TimedEvent<ChordFormula> ParseHarmony(XElement harmony)
        {
            return this.ParseChord(harmony);
        }

        List<TimedEvent<object>> Events { get; set; } = new List<TimedEvent<object>>();
        TimedEvent<Note> ParseNote(XElement note)
        {// https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/note/
            //Debug.WriteLine($"{note}");


            var attributes = note.Attributes();
            foreach (var attribute in attributes)
            {
                //Debug.WriteLine($"{attribute}");
            }

            var elements = note.Elements();
            foreach (var element in elements)
            {// <pitch>, <unpitched> or <rest>
                if (note.Elements(XmlConstants.pitch).Any())
                {
                    this.ParsePitched(note);
                }
                else if (note.Elements(XmlConstants.unpitched).Any())
                {
                    this.ParseUnpitched(note);
                }
                else if (note.Elements(XmlConstants.rest).Any())
                {
                    this.ParseRest(note);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return null;
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

        private void ParsePitched(XElement note)
        {
            var lastEvent = this.Events.LastOrDefault();

            Note hhNote = null;
            int duration = 0;
            int start = 0;
            int end = 0;

            if (note.Elements(XmlConstants.tie).Any())
            {
                var tieType = this.ParseTie(note);
                Debug.WriteLine($"**** tie count = {note.Descendants(XmlConstants.tie).Count()}");
                if (tieType == TieTypeEnum.Start || tieType == TieTypeEnum.Stop)
                {// There can be a start AND a stop.
                    var tiedNote = new TiedNoteContext(
                            this, note, tieType,
                            this.CurrentMeasure, this.CurrentOffset);
                    this.TiedNotes.TryAdd(tiedNote, tiedNote);

                    tiedNote.TryResolve();
                }
                //short circuit processing for tied notes.
                return;
                //if (TieTypeEnum.Stop == note.GetTieType())
                //{
                //    new object();
                //}
            }
            if (note.Elements(XmlConstants.pitch).Any())
            {
                hhNote = this.Parse_HarmonyHelper_Note(note);
            }
            if (note.Elements(XmlConstants.duration).Any())
            {
                duration = this.ParseDuration(note);
                start = this.CurrentOffset;
                end = this.CurrentOffset + duration;
                Debug.Assert(start != end);
            }

            var result = new TimedEvent<Note>(hhNote, start, end);
            if (this.IsFirstNoteOfChord(note))
            {
                this.ChordTimeContext.Start = start;
                this.ChordTimeContext.End = end;
                this.ChordTimeContext.FirstNote = result;
            }
            if (this.IsNoteOfChord(note))
            {
                result.Start = this.ChordTimeContext.Start;
                result.End = this.ChordTimeContext.End;
            }
            if (this.IsLastNoteOfChord(note))
            {
                this.ChordTimeContext.Clear();
                new object();
            }


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

        async public Task ResolveTiedNote(TiedNoteContext tieStop)
        {
            var tieStart = this.TiedNotes.Where(x => tieStop.Equals(x.Key)).First().Key;

            if (!this.TiedNotes.TryRemove(tieStart, out var unused01))
            {
                new object();
            }
            if (!this.TiedNotes.TryRemove(tieStop, out var unused02))
            {
                new object();
            }

            Debug.Assert(tieStart.Measure == tieStop.Measure);

            try
            {
                var result = new TimedEvent<Note>(tieStart.Note,
                    tieStart.Offset,
                    tieStop.Offset + tieStop.Duration);
                this.CurrentXmlMeasure.Add(result);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.GetBaseException().Message);
            }

            //this.TiedNotes

            new object();

            await Task.CompletedTask;
        }

        public HashSet<string> UnpitchedDescendants { get; private set; } = new HashSet<string>();

        private void ParseUnpitched(XElement note)
        {
            throw new NotImplementedException("No example data to work from.");
            var descendants = note.Elements();
            foreach (var descendant in descendants)
            {
                this.UnpitchedDescendants.Add(descendant.Name.ToString());
            }
        }

        TimedEvent<Rest> ParseRest(XElement note)
        {
            TimedEvent<Rest> result = null;
            var duration = ParseDuration(note);
            if (note.Descendants(XmlConstants.rest).Any())
            {
                result = new TimedEvent<Rest>(new Rest(), this.CurrentOffset, this.CurrentOffset + duration);
                this.CurrentOffset += duration;
            }

            return result;
        }

        public int ParseDuration(XElement note)
        {//The <duration> element moves the musical position when used in <backup> elements, <forward> elements, and <note> elements that do not contain a <chord> child element.
            var result = 0;
            //if (!note.Elements(XmlConstants.chord).Any())
            {
                var duration = note.Elements(XmlConstants.duration).First();
                var val = duration.Value;
                result = Int32.Parse(val);
            }
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

        TimedEvent<ChordFormula> ParseChord(XElement harmony)
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

            var strOffset = harmony.Descendants(XmlConstants.offset).FirstOrDefault()?.Value;
            var offset = 0;
            if (!string.IsNullOrEmpty(strOffset))
            {
                if (!Int32.TryParse(strOffset, out offset))
                {
                    offset = 0;
                }
            }
            var result = new TimedEvent<ChordFormula>(formula,
                offset,
                this.CurrentMeasure * ParsingResult.Metadata.PPQN
                + offset);

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

        string LoadEmbeddedResource(string partialName)
        {
            var result = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceNames()
                .Where(x => x.Contains(partialName)).FirstOrDefault();
            using (var sr = new StreamReader(assembly
                .GetManifestResourceStream(resource)))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

    }//class
}//ns
#endif