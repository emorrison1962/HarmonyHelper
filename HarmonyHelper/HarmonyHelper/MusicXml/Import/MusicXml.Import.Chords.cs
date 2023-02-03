using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlImporter : MusicXmlBase
    {
        TimedEventChordFormula ParseHarmony(XElement xharmony, List<TimedEventChordFormula> existingChords)
        {
#if false
<harmony>
    <root>
        <root-step>B</root-step>
    </root>
    <kind>dominant</kind>
    <degree>
        <degree-value>9</degree-value>
        <degree-alter>1</degree-alter>
        <degree-type>add</degree-type>
    </degree>
    <offset>240</offset>
</harmony>
#endif
            var root = xharmony.Elements(XmlConstants.root).First();
            var strRoot = this.ParseRoot(root);

            var kind = xharmony.Elements(XmlConstants.kind).First();
            var formula = this.ParseKind(xharmony, strRoot);


            var start = ParsingContext.CurrentOffset;
            var end = this.ParsingContext.Rhythm.PulsesPerMeasure;

            if (xharmony.Elements(XmlConstants.offset).Any())
            {
                start = ParsingContext.CurrentOffset + int.Parse(
                    xharmony.Element(XmlConstants.offset).Value);
            }
            if (xharmony.ElementsAfterSelf().Elements(XmlConstants.harmony).Any())
            {
                var sibling = xharmony.ElementsAfterSelf().Elements(XmlConstants.harmony).First();
                if (sibling.Elements(XmlConstants.offset).Any())
                {
                    end = int.Parse(
                        sibling.Element(XmlConstants.offset).Value);
                }
            }

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

        ChordFormula ParseKind(XElement xharmony, string root)
        {
#if false
<harmony print-frame="no">
  <root>
    <root-step>C</root-step>
  </root>
  <kind>dominant</kind>
  <degree>
    <degree-value>5</degree-value>
    <degree-alter>-1</degree-alter>
    <degree-type>alter</degree-type>
  </degree>
  <offset>4</offset>
</harmony>
#endif
            var chordType = xharmony.Element(XmlConstants.kind).Value.ToHarmonyHelperString();
            //var chordType = xkind.Attribute(XmlConstants.text)?.Value;

            var xdegrees = new List<XElement>();
            if (xharmony.Elements(XmlConstants.degree).Any())
            {
                xdegrees = xharmony.Elements(XmlConstants.degree).ToList();
                this.ParseAlterations(xharmony, out var adds, out var alters, out var subtracts);
                foreach (var interval in adds)
                {
                    chordType += interval;
                }
                foreach (var interval in alters)
                {
                    chordType += interval.ToString();
                }
                foreach (var interval in subtracts)
                {
                    chordType += interval;
                }
            }

            var chord = root + chordType;
            Debug.WriteLine(chord);

            var result = ChordFormulaParser.Parse(chord).First();

            return result;
        }

        void ParseAlterations(XElement xharmony,
            out List<string> adds,
            out List<string> alters,
            out List<string> subtracts)
        {
#if false
  <degree>
    <degree-value>5</degree-value>
    <degree-alter>-1</degree-alter>
    <degree-type>alter</degree-type>
  </degree>
#endif
            adds = new List<string>();
            alters = new List<string>();
            subtracts = new List<string>();

            var xalterations = xharmony.Elements(XmlConstants.degree).ToList();
            foreach (var xalteration in xalterations)
            {
                var strVal = xalteration.Element(XmlConstants.degree_value).Value;
                var alter = xalteration.Element(XmlConstants.degree_alter).Value;
                var type = xalteration.Element(XmlConstants.degree_type).Value;
                if (type == XmlConstants.degree_type_add)
                {
                    adds.Add(this.GetIntervalAlteration(xalteration));
                }
                else if (type == XmlConstants.degree_type_alter)
                {
                    alters.Add(this.GetIntervalAlteration(xalteration));
                }
                else if (type == XmlConstants.degree_type_subtract)
                {
                    subtracts.Add(this.GetIntervalAlteration(xalteration));
                }
            }
        }



        const string MINUS = "-";

        string GetIntervalAlteration(XElement xalteration)
        {
            var result = string.Empty;
            var strChordTone = xalteration.Element(XmlConstants.degree_value).Value;
            var alter = xalteration.Element(XmlConstants.degree_alter).Value;


            var count = 0;

            if (alter.StartsWith(MINUS))
            {
                var flats = new List<string> { "b", "b" };
                count = int.Parse(alter.Substring(1, alter.Length - 1));
                var seq = flats.Take(count).ToList();
                foreach (var str in seq)
                { result += str; }
                result += strChordTone;
            }
            else 
            {
                var sharps = new List<string> { "#", "#" };
                count = int.Parse(alter);
                var seq = sharps.Take(count).ToList();
                foreach (var str in seq)
                { result += str; }
                result += strChordTone;
            }

            return result;
        }


    }//class
}//ns
