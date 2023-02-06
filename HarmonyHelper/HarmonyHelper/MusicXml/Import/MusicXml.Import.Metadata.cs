using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (xmeasure.Descendants(XmlConstants.sound).Any())
            {
                if (Int32.TryParse(
                    xmeasure.Descendants(XmlConstants.sound)
                        .First()
                        .Attribute(XmlConstants.tempo)
                        .Value, out tempo))
                {
                    result = true;
                }
            }
            return result;
        }

        Identification ParseIdentification()
        {
#if false
   <identification>
      <creator type="composer">Franz Schubert</creator>
      <creator type="poet">Wilhelm Müller</creator>
   </identification>
#endif
            var root = this.Document.Element(XmlConstants.score_partwise);
            var result = new Identification();
            if (root.Elements(XmlConstants.identification).Any())
            {
                if (root.Elements(XmlConstants.identification)
                    .Elements(XmlConstants.creator).Any())
                {
                    foreach (var xcreator in root.Elements(XmlConstants.identification)
                        .Elements(XmlConstants.creator))
                    {
                        var role = xcreator.Attribute(XmlConstants.type).Value;
                        var name = xcreator.Value;
                        result.Creators.Add(new Creator(role, name));
                    }
                }
            }

            return result;
        }

        Credits ParseCredits()
        {
            var result = new Credits();
#if false
<score-partwise>
   <work>
      <work-number>D. 911</work-number>
      <work-title>Winterreise</work-title>
   </work>
   <movement-number>22</movement-number>
   <movement-title>Mut</movement-title>
</score-partwise>
#endif
            var root = this.Document.Element(XmlConstants.score_partwise);
            if (root.Elements(XmlConstants.work).Elements(XmlConstants.work_title).Any())
            {
                result.WorkTitle = root.Element(XmlConstants.work).Element(XmlConstants.work_title).Value;
            }

            if (root.Elements(XmlConstants.work).Elements(XmlConstants.work_number).Any())
            {
                result.WorkTitle = root.Element(XmlConstants.work).Element(XmlConstants.work_number).Value;
            }

            if (root.Elements(XmlConstants.movement_number).Any())
            {
                result.MovementNumber = root.Element(XmlConstants.movement_number).Value;
            }

            if (root.Elements(XmlConstants.movement_title).Any())
            {
                result.MovementTitle = root.Element(XmlConstants.movement_title).Value;
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
                timeSignature = new TimeSignature(Int32.Parse(beats), Int32.Parse(beat_type));
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
