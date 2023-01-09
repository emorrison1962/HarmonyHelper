using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlImporter : MusicXmlBase
    {
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
            var result = string.Empty;
            if (this.Document.Elements(XmlConstants.work).Elements(XmlConstants.work_title).Any())
            {
                result = this.Document.Element(XmlConstants.work).Element(XmlConstants.work_title).Value;
            }
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
                this.ParsingContext.Rhythm.TimeSignature = new TimeSignature(Int32.Parse(beats), Int32.Parse(beat_type));
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


    }//class
}//ns
