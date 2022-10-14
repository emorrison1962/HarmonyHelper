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

namespace Eric.Morrison.Harmony
{
    public class MusicXmlParser
    {
        public MusicXmlParser()
        {

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
            var result = new MusicXmlParsingResult();
            var meta = ParseScoreMetadata(doc);
            result.Metadata = meta;

            var parts = doc.Descendants("part");
            foreach (var part in parts)
            {
                result.Parts.Add(
                    this.ParsePart(part));
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
            result.PPQN = this.ParsePpqn(doc);
            return result;
        }

        private int ParsePpqn(XDocument doc)
        {//<divisions>120</divisions>
            var result = Int32.Parse(
                doc.Descendants("divisions")
                .First()
                .Value);
            return result;
        }

        private int ParseTempo(XDocument doc)
        {//<sound tempo="160"/>
            var result = Int32.Parse(
                doc.Descendants("sound")
                .First()
                .Attribute("tempo")
                .Value);
            return result;
        }

        private string ParseTitle(XDocument doc)
        {
            var result = doc.Descendants("work-title").First().Value;
            return result;
        }

        private TimeSignature ParseTimeSignature(XDocument doc)
        {
#if false
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
#endif
            var ts = doc.Descendants("time").First();
            var beats = ts.Descendants("beats").First().Value;
            var beat_type = ts.Descendants("beat-type").First().Value;
            var result = new TimeSignature(beats, beat_type);
            return result;
        }

        KeySignature ParseKeySignature(XDocument doc)
        {
            var result = KeySignature.CMajor;
            var fifths = Int32.Parse(
                doc.Descendants("key")
                .Descendants("fifths")
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
            var part_list = doc.Descendants("part-list").First();
            var score_parts = doc.Descendants("score-part");
            foreach (var score_part in score_parts)
            {
                var id = score_part.Attribute("id").Value;
                var name = doc.Descendants("part-name").First().Value;
                result.Add(new PartIdentifier(id, name));
            }
            return result;
        }
        private MusicXmlPart ParsePart(XElement part)
        {
            var result = new MusicXmlPart();
            var measures = part.Descendants("measure");
            foreach (var measure in measures)
            {
                result.Measures.Add(
                    this.ParseMeasure(measure));
            }
            return result;
        }

        private MusicXmlMeasure ParseMeasure(XElement measure)
        {
            var result = new MusicXmlMeasure();
            this.ParseHarmony(measure, ref result);
            this.ParseNotes(measure, ref result);

            return result;
        }

        private void ParseNotes(XElement measure, ref MusicXmlMeasure result)
        {

            var notes = measure.Descendants("note");
            var nns = new List<TimedEvent<NoteName>>();
            foreach (var note in notes)
            {
                nns.Add(this.ParseNote(note));
            }
            result.Notes.AddRange(nns.Where(x => x != null).Distinct());
        }

        void ParseHarmony(XElement measure, ref MusicXmlMeasure result)
        {
            var chords = measure.Descendants("harmony");
            foreach (var chord in chords)
            {
                result.Chords.Add(this.ParseChord(chord));
            }
        }

        private TimedEvent<NoteName> ParseNote(XElement note)
        {
#if false
<note release="55">
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
  <duration>60</duration>
  <voice>2</voice>
  <type>eighth</type>
  <beam number="1">begin</beam>
  <notations>
    <technical>
      <string>4</string>
      <fret>6</fret>
    </technical>
  </notations>
</note>
    OR
<note>
  <rest />
  <duration>120</duration>
  <voice>1</voice>
  <type>quarter</type>
  <staff>1</staff>
</note>
#endif
            TimedEvent<NoteName> result = null;
            if (null == note.Descendants("rest").FirstOrDefault())
            {
                var pitches = note.Descendants("pitch");
                Debug.Assert(pitches.Count() == 1);

                var pitch = pitches.First();
                var nn = this.ParsePitch(pitch);

                var durations = note.Descendants("duration");
                Debug.Assert(durations.Count() == 1);

                if (Int32.TryParse(durations.First().Value, out var dur))
                {
                    result = new TimedEvent<NoteName>(nn, dur);
                }
                else
                {
                    throw new ArgumentException(durations.First().Value);
                }
            }
            return result;
        }

        private NoteName ParsePitch(XElement pitch)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif

            var nn = pitch.Descendants("step").First().Value;
            var modifier = pitch.Descendants("alter").FirstOrDefault()?.Value;
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

        private TimedEvent<ChordFormula> ParseChord(XElement chord)
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
            var root = chord.Descendants("root").First();
            var strRoot = this.ParseRoot(root);

            var kind = chord.Descendants("kind").First();
            var formula = this.ParseKind(strRoot, kind);

            var strOffset = chord.Descendants("offset").FirstOrDefault()?.Value;
            var intOffset = 0;
            if (!string.IsNullOrEmpty(strOffset))
            {
                if (!Int32.TryParse(strOffset, out intOffset))
                {
                    intOffset = 0;
                }
            }

            var result = new TimedEvent<ChordFormula>(formula, intOffset);
            return result;
        }

        private ChordFormula ParseKind(string root, XElement kind)
        {
#if false
  <kind text="Maj7">major-seventh</kind>
  OR
  <kind>major</kind>
#endif
            var chordType = kind.Attribute("text")?.Value;
            var chord = root + chordType;
            var result = ChordFormulaParser.Parse(chord).First();
            return result;
        }

        private string ParseRoot(XElement root)
        {
#if false
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
#endif
            var result = root.Descendants("root-step").First().Value;
            var modifier = root.Descendants("root-alter").FirstOrDefault()?.Value;
            if (modifier != null)
            { 
                if (modifier ==  "-1")
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

    public class PartIdentifier
    {
        public string ID;
        public string Name;
        public PartIdentifier(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
    public class MusicXmlParsingResult
    {
        public MusicXmlScoreMetadata Metadata { get; set; }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();
    }//class

    public class MusicXmlScoreMetadata
    {
        public string Title { get; set; }
        public KeySignature KeySignature { get; set; }
        public TimeSignature TimeSignatue { get; set; }
        public int Tempo { get; set; }
        public int PPQN { get; set; }
    }
    public class MusicXmlPart 
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
    }
    public class MusicXmlMeasure
    { 
        public List<TimedEvent<ChordFormula>> Chords { get; set; } = new List<TimedEvent<ChordFormula>>();  
        public List<TimedEvent<NoteName>> Notes { get; set; } = new List<TimedEvent<NoteName>>();
    }
    public class TimedEvent<T>
    { 
        public int Start { get; set; }
        public int End { get; set; }
        public int Duration { get; set; }
        public T Event { get; set; }
        public TimedEvent(T @event, int duration)
        {
            Duration = duration;
            this.Event = @event;
        }
    }
}//ns
