using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlPart
    {
        #region Properties
        public PartIdentifier Identifier { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
        public XElement XElement { get; set; }
        public MusicXmlMeasure CurrentMeasure { get { return Measures.Last(); } }

        #endregion

        #region Construction
        MusicXmlPart(MusicXmlPart part)
        {
            this.Identifier = part.Identifier;
        }
        public MusicXmlPart(PartIdentifier PartIdentifier)
        {
            this.Identifier = PartIdentifier;
        }
        public MusicXmlPart(PartIdentifier PartIdentifier, XElement xelement)
            : this(PartIdentifier)
        {
            this.XElement = xelement;
        }
        static public MusicXmlPart CloneShallow(MusicXmlPart part)
        {
            return new MusicXmlPart(part);
        }
        #endregion
        public override string ToString()
        {
            return $"{nameof(MusicXmlPart)}: {Identifier}";
        }

    }//class

}//ns
