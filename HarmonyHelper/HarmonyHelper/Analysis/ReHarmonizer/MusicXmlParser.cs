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
            var chords = measure.Descendants("harmony");
            foreach (var chord in chords)
            {
                result.Chords.Add(this.ParseChord(chord));
            }
            
            var notes = measure.Descendants("note");
            var nns = new List<NoteName>();
            foreach (var note in notes)
            {
                nns.Add(this.ParseNote(note));
            }
            result.Notes.AddRange(nns.Where(x => x!= null).Distinct());
            return result;
        }

        private NoteName ParseNote(XElement note)
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
#endif
            NoteName result = null;
            var pitches = note.Descendants("pitch");
            if (pitches.Count() > 0)
            {
                Debug.Assert(pitches.Count() == 1);
                foreach (var pitch in pitches)
                {
                    result = this.ParsePitch(pitch);
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

        private ChordFormula ParseChord(XElement chord)
        {
#if false
<harmony>
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
  <kind text="Maj7">major-seventh</kind>
</harmony>
#endif
            var root = chord.Descendants("root").First();
            var strRoot = this.ParseRoot(root);

            var kind = chord.Descendants("kind").First();
            var result = this.ParseKind(strRoot, kind);

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
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();
    }//class

    public class MusicXmlPart 
    {
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
    }
    public class MusicXmlMeasure
    { 
        public List<ChordFormula> Chords { get; set; } = new List<ChordFormula>();  
        public List<NoteName> Notes { get; set; } = new List<NoteName>();
    }
}//ns
