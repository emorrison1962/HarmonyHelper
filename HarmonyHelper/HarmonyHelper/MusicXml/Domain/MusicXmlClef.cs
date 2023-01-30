using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlStaff
    {
        public MusicXmlClef Clef { get; set; }
        public MusicXmlStaff(MusicXmlClef Clef)
        {
            if (null == Clef)
                throw new ArgumentNullException(nameof(Clef));
            this.Clef = Clef;
        }

        static public List<MusicXmlStaff> FromXml(XElement xmeasure)
        {
#if false
   <measure number="1">
      <attributes>
        ...
        <staves>2</staves>
        <clef number="1">
           <sign>G</sign>
           <line>2</line>
        </clef>
        <clef number="2">
           <sign>F</sign>
           <line>4</line>
        </clef>
        ...
   </measure>
#endif
            var result = new List<MusicXmlStaff>();

            foreach (var xclef in xmeasure.Element(XmlConstants.attributes)
                .Elements(XmlConstants.clef))
            {
                var staff = new MusicXmlStaff(MusicXmlClef.FromXml(xclef));
                result.Add(staff);
            }
            return result;
        }
    }
    public class MusicXmlClef
    {
        const string TREBLE_SIGN = "G";
        const string TREBLE_LINE = "2";
        const string BASS_SIGN = "F";
        const string BASS_LINE = "4";
        const string PERCUSSION_SIGN = "percussion";
        const string PERCUSSION_LINE = "2";

        /// <summary>
        ///     <clef number="1">
        ///        <sign>G</sign>
        ///        <line>2</line>
        ///     </clef>
        ///     <clef number="2">
        ///        <sign>F</sign>
        ///        <line>4</line>
        ///     </clef>
        /// </summary>
        public ClefEnum ClefType { get; set; }
        public int ClefNumber { get; set; }

        public MusicXmlClef(ClefEnum clefType, int clefNumber)
        {
            ClefType = clefType;
            ClefNumber = clefNumber;
        }

        public XElement ToXml()
        {
            var result = new XElement(XmlConstants.clef, new XAttribute(XmlConstants.number, this.ClefNumber));
            var sign = string.Empty;
            var line = string.Empty;

            if (this.ClefType == ClefEnum.Treble)
            {
                sign = TREBLE_SIGN;
                line = TREBLE_LINE;
            }
            else if (this.ClefType == ClefEnum.Bass)
            {
                sign = BASS_SIGN;
                line = BASS_LINE;
            }
            else if (this.ClefType == ClefEnum.Percussion)
            {
                sign = PERCUSSION_SIGN;
                line = PERCUSSION_LINE;
            }
            else
            {
                throw new NotImplementedException();
            }
            result.Add(new XElement(XmlConstants.sign, sign));
            result.Add(new XElement(XmlConstants.line, line));
            return result;
        }
        static public MusicXmlClef FromXml(XElement xclef)
        {
            MusicXmlClef result = null;
            int clefNumber = 1;
            if (xclef.Attributes(XmlConstants.number).Any())
            {
                Int32.TryParse(xclef.Attribute(XmlConstants.number).Value, out clefNumber);
            }
            
            var sign = xclef.Element(XmlConstants.sign).Value;
            string line = null;
            if (xclef.Elements(XmlConstants.line).Any())
            {
                line = xclef.Element(XmlConstants.line).Value;
            }
            
            if (TREBLE_SIGN == sign)
            {
                if (TREBLE_LINE == line)
                {
                    result = new MusicXmlClef(ClefEnum.Treble, clefNumber);
                }
            }
            else if (BASS_SIGN == sign)
            {
                if (BASS_LINE == line)
                {
                    result = new MusicXmlClef(ClefEnum.Bass, clefNumber);
                }
            }
            else if (PERCUSSION_SIGN == sign)
            {
                if (line == null || PERCUSSION_LINE == line)
                {
                    result = new MusicXmlClef(ClefEnum.Percussion, clefNumber);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }//class
}//ns
