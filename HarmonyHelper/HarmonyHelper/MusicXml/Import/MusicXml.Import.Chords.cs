using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlImporter : MusicXmlBase
    {
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
            var root = harmony.Elements(XmlConstants.root).First();
            var strRoot = this.ParseRoot(root);

            var kind = harmony.Elements(XmlConstants.kind).First();
            var formula = this.ParseKind(strRoot, kind);


            var start = ParsingContext.CurrentOffset;
            var end = this.ParsingContext.Rhythm.PulsesPerMeasure;

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

            var duration = end - start;
            var result = TimedEventFactory.Instance.CreateTimedEvent(formula,
                this.ParsingContext.Rhythm,
                this.ParsingContext.CurrentMeasure.MeasureNumber,
                start,
                duration);

            if (existingChords.Count != 0)
            {
                var previousChord = existingChords.Last();
                previousChord.TimeContext
                    .SetRelativeEnd(result.RelativeStart);
            }

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
            var result = root.Elements(XmlConstants.root_step).First().Value;
            var modifier = root.Elements(XmlConstants.root_alter).FirstOrDefault()?.Value;
            if (modifier != null)
            {
                if (modifier == "-1")
                    result += "b";
                else
                    result += "#";
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

    }
}
