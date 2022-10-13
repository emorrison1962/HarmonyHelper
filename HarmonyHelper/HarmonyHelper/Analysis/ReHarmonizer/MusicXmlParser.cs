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

namespace Eric.Morrison.Harmony
{
    public class MusicXmlParser
    {
        public MusicXmlParser()
        {

        }

        public MusicXmlParingResult Parse(string filename)
        {
            var xml = this.LoadEmbeddedResource();
            var doc = XDocument.Parse(xml);
            var result = this.Parse(doc);
            return result;
        }

        MusicXmlParingResult Parse(XDocument doc)
        {
            var result = new MusicXmlParingResult();
            var parts = doc.Descendants("part");
            foreach (var part in parts)
            {
                result.Parts.Add(
                    this.ParsePart(part));
            }
            return result;
        }

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
    public class MusicXmlParingResult
    {
        public KeySignature KeySignature { get; set; }
        public int Tempo { get; set; } 
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();
    }//class

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
