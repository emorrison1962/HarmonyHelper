using Eric.Morrison.Harmony.Rhythm;
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
        public List<MusicXmlStaff> Staves { get; set; } = new List<MusicXmlStaff>(); 
        public MusicXmlPartIdentifier Identifier { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
        public XElement XElement { get; set; }
        public MusicXmlMeasure CurrentMeasure { get { return Measures.Last(); } }
        KeySignature _KeySignature = null;
        public KeySignature KeySignature 
        {
            get { return _KeySignature; }
            set 
            {
                if (null == _KeySignature)
                    _KeySignature = value;  
            } 
        }
        public int Tempo { get; set; }


        #endregion

        #region Construction
        MusicXmlPart(MusicXmlPart part)
        {
            this.Identifier = part.Identifier;
        }
        public MusicXmlPart(MusicXmlPartIdentifier PartIdentifier)
        {
            this.Identifier = PartIdentifier;
        }
        public MusicXmlPart(MusicXmlPartIdentifier PartIdentifier, XElement xelement)
            : this(PartIdentifier)
        {
            this.XElement = xelement;
        }
        [Obsolete("", false)]
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
