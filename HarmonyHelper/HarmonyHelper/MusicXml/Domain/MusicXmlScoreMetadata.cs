using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlScoreMetadata
    {
        #region Properties
        public string Now { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }
        public Identification Identification { get; set; }
        public Credits Credits { get; set; }

        #endregion

        #region Construction
        public MusicXmlScoreMetadata()
        {
        }

        #endregion

        public List<XElement> ToXElements ()
        {
            var result = new List<XElement>();
            result.Add(this.Identification.ToXElement());
            result.AddRange(this.Credits.ToXElements());

            return result;
        }
        
        XElement GetPartsList(MusicXmlModel model)
        {
#if false
<part-list>
   <score-part id="P1">
      <part-name>ElecPiano</part-name>
  </score-part>
   <score-part id="P2">
      <part-name>Calliope</part-name>
  </score-part>
  </part-list>
#endif
            var result = new XElement(XmlConstants.part_list);
            foreach (var part in model.Parts)
            {
                var xscore_part = new XElement(XmlConstants.score_part,
                    new XAttribute(XmlConstants.id, part.Identifier.ID));
                var xpart_name = new XElement(XmlConstants.part_name,
                    part.Identifier.Name);
                xscore_part.Add(xpart_name);
                result.Add(xscore_part);
            }
            return result;
        }
    }//class

    public class MusicXmlMetadata
    {
        public KeySignature KeySignature { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public int PulsesPerMeasure { get; set; }

        MusicXmlMetadata()
        {

        }
    }

}//ns
