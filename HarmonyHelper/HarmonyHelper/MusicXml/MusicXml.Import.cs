﻿using System;
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

        public MusicXmlModel Import(string filename)
        {
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
                    
                    this.ParseMeasure(xmeasure, ref measure);
                    part.Measures.Add(measure);
                }
            }
            var result = this.CreateParsingResult(metadata, parts);
            return result;
        }

        MusicXmlModel CreateParsingResult(MusicXmlScoreMetadata metadata, List<MusicXmlPart> parts)
        {
            var result = new MusicXmlModel();
            result.Metadata = metadata;
            result.Parts = parts;
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

        MusicXmlScoreMetadata ParseScoreMetadata()
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
            result.Title = this.ParseTitle();
            return result;
        }

        MusicXmlMeasure ParsePartMetadata(MusicXmlPart part, XElement xmeasure)
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
            var xpart = this.Document.Descendants(XmlConstants.part)
                .FirstOrDefault(x => x.Attribute(XmlConstants.id).Value == part.Identifier.ID);

            var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
            var measure = new MusicXmlMeasure(measureNumber);
            measure.HasMetadata= true;

            if (TryParseKeySignature(xmeasure, out var keySignature))
                part.KeySignature = keySignature;

            if (this.TryParseTimeSignature(xmeasure, out var timeSignature))
                part.TimeSignatue = timeSignature;

            if (this.TryParseStaves(xmeasure, out var staves))
                part.Staves = staves;

            if (this.TryParseTempo(xmeasure, out var tempo))
                part.Tempo = tempo;
            
            if (this.TryParsePpqn(xmeasure, out var ppqn))
                part.PulsesPerQuarterNote = ppqn;
            
            TimedEventFactory.Instance.PulsesPerMeasure = part.PulsesPerMeasure;

            return measure;
        }

        bool TryParseStaves(XElement xmeasure, out List<MusicXmlStaff> staves)
        {
            var result = false;
            staves = null;
            if (xmeasure.Element(XmlConstants.attributes)
                .Elements(XmlConstants.clef).Any())
            {
                staves = MusicXmlStaff.FromXml(xmeasure);
                result = true;
            }
            return result;
        }

        bool TryParsePpqn(XElement xmeasure, out int ppqn)
        {//<divisions>120</divisions>
            ppqn = int.MinValue;
            var result = false;
            if (xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.divisions).Any())
            {
                ppqn = Int32.Parse(
                    xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.divisions)
                    .First()
                    .Value);
                result = true;
            }
            return result;
        }

        bool TryParseTempo(XElement xmeasure, out int tempo)
        {//<sound tempo="160"/>
            tempo = int.MinValue;
            var result = false;
            if (xmeasure.Elements(XmlConstants.sound).Any())
            {
                if (Int32.TryParse(
                    xmeasure.Elements(XmlConstants.sound)
                        .First()
                        .Attribute(XmlConstants.tempo)
                        .Value, out tempo))
                {
                    result = true;
                }
            }
            return result;
        }

        string ParseTitle()
        {
            var result = this.Document.Descendants(XmlConstants.work_title).FirstOrDefault()?.Value;
            return result;
        }

        bool TryParseTimeSignature(XElement xmeasure, out TimeSignature timeSignature)
        {
#if false
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
#endif
            var result = false;
            timeSignature = null;
            if (xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.time).Any())
            {
                var xtime = xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.time).First();
                var beats = xtime.Elements(XmlConstants.beats).First().Value;
                var beat_type = xtime.Elements(XmlConstants.beat_type).First().Value;
                timeSignature = new TimeSignature(beats, beat_type);
                result = true;
            }
            return result;
        }

        bool TryParseKeySignature(XElement xmeasure, out KeySignature keySignature)
        {
            var result = false;
            keySignature = null;
            if (xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.key).Any())
            {
                var fifths = Int32.Parse(
                    xmeasure.Elements(XmlConstants.attributes).Elements(XmlConstants.key)
                    .Elements(XmlConstants.fifths)
                    .First().Value);
                if (fifths == 0)
                {
                    keySignature = KeySignature.CMajor;
                }
                else if (fifths < 0)
                {
                    keySignature = KeySignature.Catalog
                        .Where(x => x.UsesFlats
                            && x.AccidentalCount == Math.Abs(fifths))
                        .First();
                }
                else
                {
                    keySignature = KeySignature.Catalog
                        .Where(x => x.UsesSharps
                            && x.AccidentalCount == fifths)
                        .First();
                }
                result = true;
            }
            return result;
        }

        List<MusicXmlPart> ParseParts()
        {
            var result = new List<MusicXmlPart>();

            var pids = new List<PartIdentifier>();
            var score_parts = this.Document.Descendants(XmlConstants.score_part);
            foreach (var score_part in score_parts)
            {
                var id = score_part.Attribute(XmlConstants.id).Value;
                var name = score_part.Descendants(XmlConstants.part_name).First().Value;
                var pid = new PartIdentifier(id, name);
                pids.Add(pid);
            }

            var xparts = this.Document.Descendants(XmlConstants.part);
            foreach (var xpart in xparts)
            {
                var partName = xpart.Attribute(XmlConstants.id).Value;
                var pid = pids.First(x => x.ID == partName);
                var part = new MusicXmlPart(pid, xpart);
                result.Add(part);
            }
            return result;
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
                //Debug.WriteLine(this.ParsingContext.CurrentOffset);
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

                else if (xelement.Descendants(XmlConstants.rest).Any())
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

            measure.Chords = chords;
            measure.Notes = notes;
            measure.Rests = rests;
            if (forwards.Count > 0)
                measure.Forwards= forwards;
            if (backups.Count > 0)
                measure.Backups= backups;
        }

        TimedEvent<Forward> ParseForward(XElement xelement)
        {
            TimedEvent<Forward> result = null;
            var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            if (xelement.Name == XmlConstants.forward)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Forward(),
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    this.ParsingContext.CurrentOffset + duration);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        TimedEvent<Backup> ParseBackup(XElement xelement)
        {
            TimedEvent<Backup> result = null;
            var duration = Int32.Parse(xelement.Element(XmlConstants.duration).Value);
            if (xelement.Name == XmlConstants.backup)
            {
                result = TimedEventFactory.Instance.CreateTimedEvent(new Backup(),
                    this.ParsingContext.CurrentMeasure.MeasureNumber,
                    this.ParsingContext.CurrentOffset,
                    this.ParsingContext.CurrentOffset + duration);

                //this.ParsingContext.CurrentOffset += duration;
            }

            return result;
        }

        void ParseMeasure(XElement xmeasure, ref MusicXmlMeasure measure)
        {
            if (measure == null)
            {
                var measureNumber = Int32.Parse(xmeasure.Attribute(XmlConstants.number).Value);
                measure = new MusicXmlMeasure(measureNumber);
            }
            this.ParsingContext.CurrentMeasure = measure;
            this.PopulateMeasure(xmeasure, measure);
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

            bool hasChord = false;
            if (xnote.Elements(XmlConstants.chord).Any())
            {
                hasChord = true;
            }


            //result = new TimedEvent<Note>(hhNote, start, end);
            result = TimedEventFactory.Instance.CreateTimedEvent(hhNote,
            this.ParsingContext.CurrentMeasure.MeasureNumber,
            start,
            end);
            result.Serialization.HasChord = hasChord;

            if (xnote.Attributes(XmlConstants.attack).Any())
                result.Serialization.Attack = xnote.Attribute(XmlConstants.attack).Value;
            if (xnote.Attributes(XmlConstants.release).Any())
                result.Serialization.Release = xnote.Attribute(XmlConstants.release).Value;

            result.Serialization.Voice = xnote.Element(XmlConstants.voice).Value;
            result.Serialization.Staff = xnote.Element(XmlConstants.staff).Value;

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
                result.Serialization.Voice = xnote.Element(XmlConstants.voice).Value;
                result.Serialization.Staff = xnote.Element(XmlConstants.staff).Value;

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
            var result = this.ParsingContext.PulsesPerMeasure / divisor;
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
            var end = this.ParsingContext.PulsesPerMeasure;

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
