using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Notes;
using Eric.Morrison.Harmony.Rhythm;
using Kohoutech.Score.MusicXML;

#region MusicXml reference
#if false

https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/

#endif
#endregion


namespace Eric.Morrison.Harmony
{
    public class MusicXmlParser: IMusicXmlParser
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
                this._CurrentOffset = 0;
                _CurrentMeasure = value;
                Debug.WriteLine($"set_CurrentMeasure: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }

        int _CurrentOffset = 0;
        int CurrentOffset
        {
            get
            {
                return _CurrentOffset;
            }
            set
            {
                _CurrentOffset = value;
                Debug.Assert(_CurrentOffset <= 480);
                Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }
        MusicXmlParsingResult Result { get; set; }

        List<UnresolvedTiedNote> UnresolvedTiedNotes { get; set; } = new List<UnresolvedTiedNote>();

        #endregion

        public MusicXmlParser()
        {
            this.Result = new MusicXmlParsingResult();
        }

        public MusicXmlParsingResult Parse(string filename)
        {
            var xml = this.LoadEmbeddedResource();

            var doc = XDocument.Parse(xml);
            var result = this.Parse(doc);
            return result;
        }

        MusicXmlParsingResult Parse(XDocument doc)
        {
            this.ParseScoreMetadata(doc);
            this.ParseParts(doc);
            return this.Result;
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

            this.Result.Metadata = result;
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
#warning FIXME:
            var parts = doc.Descendants(XmlConstants.part);
            foreach (var part in parts)
            {
                this.Result.Parts.Add(
                    this.ParsePart(part));
            }
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

        MusicXmlMeasure ParseMeasure(XElement measure)
        {
            var currentMeasure = Int32.Parse(measure.Attribute(XmlConstants.number).Value);
            this.CurrentMeasure = currentMeasure;
            var result = new MusicXmlMeasure(currentMeasure);

            var descendants = measure.Elements();
            foreach (var descendant in descendants)
            {
                if (descendant.Name == XmlConstants.backup)
                {
                    var duration = this.ParseDuration(descendant);
                    this.CurrentOffset -= duration;
                }
                else if (descendant.Name ==XmlConstants.harmony)
                {
                    result.Add(this.ParseHarmony(descendant));
                }
                else if (descendant.Name == XmlConstants.note)
                {
                    result.Add(this.ParseNote(descendant));
                }
#if false
                else if (descendant.Name == "note"
                    && descendant.Descendants("rest").Any())
                {
                    result.Add(this.ParseRest(descendant));
                }
#endif
            }
            return result;
        }

        TimedEvent<ChordFormula> ParseHarmony(XElement harmony)
        {
            return this.ParseChord(harmony);
        }

        TimedEvent<NoteName> ParseNote(XElement note)
        {// https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/note/
            Debug.WriteLine("****************************************");
            Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");


            //Debug.WriteLine($"{note}");


            int duration = int.MinValue;

            var attributes = note.Attributes();
            foreach (var attribute in attributes)
            {
                //Debug.WriteLine($"{attribute}");
            }
            var descendants = note.Elements();
            foreach (var descendant in descendants)
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
            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
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
            Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            //Debug.WriteLine($"{note}");
            var attributes = note.Attributes();
            foreach (var attribute in attributes)
            {
                //Debug.WriteLine($"{attribute}");
            }
            var elements = note.Elements();
            foreach (var element in elements)
            {// <pitch>, <unpitched> or <rest>
                switch (element.Name.ToString())
                {
                    case XmlConstants.pitch:
                        {
                            var pitch = this.ParseNoteName(element);
                            break;
                        }
                    case XmlConstants.duration:
                        {
                            var duration = this.ParseDuration(note);
                            break;
                        }
                    case XmlConstants.tie:
                        {
                            if (TieTypeEnum.Start == note.GetTieType())
                            {
                                this.UnresolvedTiedNotes.Add(
                                    new UnresolvedTiedNote(
                                        this, note, this.CurrentOffset));
                            }
                            break;
                        }
                    case XmlConstants.chord:
                    case XmlConstants.voice:
                    case XmlConstants.type:
                    case XmlConstants.beam:
                    case XmlConstants.notations:
                    case XmlConstants.accidental:
                    case XmlConstants.dot:
                    case XmlConstants.staff:
                    case XmlConstants.time_modification:
                    default:
                        {
                            break;
                        }
                }
            }

            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
        }

        async public Task TiedNoteResolvedAsync(UnresolvedTiedNote utn)
        {
            Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
            var item = this.UnresolvedTiedNotes.Where(x => utn.Equals(x)).First();
            //this.UnresolvedTiedNotes.Remove(utn);
            new object();
            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
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
            Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");

            TimedEvent<Rest> result = null;
            var duration = ParseDuration(note);
            if (note.Descendants(XmlConstants.rest).Any())
            {
                result = new TimedEvent<Rest>(new Rest(), this.CurrentOffset, this.CurrentOffset + duration);
                this.CurrentOffset += duration;
            }

            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
            return result;
        }

        int ParseDuration(XElement note)
        {//The <duration> element moves the musical position when used in <backup> elements, <forward> elements, and <note> elements that do not contain a <chord> child element.
            var result = 0;
            if (!note.Elements(XmlConstants.chord).Any())
            {
                var duration = note.Elements(XmlConstants.duration).First();
                var val = duration.Value;
                result = Int32.Parse(val);
            }
            return result;
        }

        public NoteName ParseNoteName(XElement pitch)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif
            var nn = pitch.Elements(XmlConstants.step).First().Value;
            var modifier = pitch.Elements(XmlConstants.alter).FirstOrDefault()?.Value;
            if (modifier != null)
            {
                if (modifier == "-1")
                    nn += "b";
                else
                    nn += "#";
            }
            NoteName result = null;
            if (NoteNameParser.TryParse(nn, out var notes, out var msg))
            {
                result = notes.First();
            }
            else
            {
                throw new ArgumentException(msg);
            }
            return result;
        }

        TimedEvent<ChordFormula> ParseChord(XElement chord)
        {
            Debug.WriteLine($"+{MethodBase.GetCurrentMethod().Name}");
#if false
      <harmony>
         <root>
         <root-step>C</root-step>
         </root>
         <kind text="m7">minor-seventh</kind>
      <offset>240</offset>
      </harmony>
#endif
            var root = chord.Descendants(XmlConstants.root).First();
            var strRoot = this.ParseRoot(root);

            var kind = chord.Descendants(XmlConstants.kind).First();
            var formula = this.ParseKind(strRoot, kind);

            var strOffset = chord.Descendants(XmlConstants.offset).FirstOrDefault()?.Value;
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
                this.CurrentMeasure * Result.Metadata.PPQN
                + offset);

            Debug.WriteLine($"-{MethodBase.GetCurrentMethod().Name}");
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

        string LoadEmbeddedResource()
        {
            var result = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceNames()
                .Where(x => x.Contains("All Of Me")).FirstOrDefault();
            using (var sr = new StreamReader(assembly
                .GetManifestResourceStream(resource)))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

    }//class

    public enum TieTypeEnum
    {
        Unknown,
        Start,
        Stop
    };

    public static partial class XElementExtensions
    {
        static public TieTypeEnum GetTieType(this XElement note)
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
                {
                    result = TieTypeEnum.Start;
                }
                else
                {
                    result = TieTypeEnum.Stop;
                }
            }
            return result;
        }

    }


}//ns
