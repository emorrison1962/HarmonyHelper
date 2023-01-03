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
        public PartIdentifier Identifier { get; set; }
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
        public TimeSignature TimeSignatue { get; set; }
        public int Tempo { get; set; }
        public int PulsesPerQuarterNote { get; set; }
        public int PulsesPerMeasure
        {
            get
            {
                return this.TimeSignatue.BeatCount * this.PulsesPerQuarterNote;
            }
        }


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
        [Obsolete("", true)]
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
