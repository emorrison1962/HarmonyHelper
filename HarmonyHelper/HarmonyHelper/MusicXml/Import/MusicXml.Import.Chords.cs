using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var xkind = xharmony.Element(XmlConstants.kind);
            var chordType = xkind.Attribute(XmlConstants.text)?.Value;

            if (xharmony.Elements(XmlConstants.degree).Any())
                this.ParseAlteration(xharmony);


            var chord = root + chordType;
            var result = ChordFormulaParser.Parse(chord).First();
            return result;
        }

        void ParseAlteration(XElement xharmony)
        {
#if false
  <degree>
    <degree-value>5</degree-value>
    <degree-alter>-1</degree-alter>
    <degree-type>alter</degree-type>
  </degree>
#endif
            var xalteration = xharmony.Element(XmlConstants.degree);

            var strVal = xalteration.Element(XmlConstants.degree_value).Value;
            var alter = xalteration.Element(XmlConstants.degree_alter).Value;
            var type = xalteration.Element(XmlConstants.degree_type).Value;

            var irt = this.GetInterval(strVal);
            
            const string MINUS = "-";
            if (alter.StartsWith(MINUS))
            {
                var intervals = Interval.Catalog.Where(x => x.Value < irt.Value)
                    .OrderByDescending(x => x.Value)
                    .Where(x => x.Name.Contains(strVal))
                    .ToList();
                alter = alter.Remove(0, 1);
                var count = int.Parse(alter);
                for (int i = 0; i < count;  ++i)
                    irt -= Interval.Minor2nd;
            }
            else 
            { 
            }

            //var i = Interval.Catalog.Where(x => x.IntervalRoleType == irt);
            new object();
        }

        Interval GetInterval(string strVal)
        {
            Interval result= null;
            switch (int.Parse(strVal))
            {
                case 1: result = ChordToneInterval.Unison; break;
                case 2: result = ChordToneInterval.Major2nd; break;
                case 3: result = ChordToneInterval.Major3rd; break;
                case 4: result = ChordToneInterval.Perfect4th; break;
                case 5: result = ChordToneInterval.Perfect5th; break;
                case 6: result = ChordToneInterval.Major6th; break;
                case 7: result = ChordToneInterval.Major7th; break;
                case 9: result = ChordToneInterval.Ninth; break;
                case 11: result = ChordToneInterval.Eleventh; break;
                case 13: result = ChordToneInterval.Thirteenth; break;
                default: { throw new NotImplementedException(); }
            }
            return result;
        }

    }//class
}//ns
