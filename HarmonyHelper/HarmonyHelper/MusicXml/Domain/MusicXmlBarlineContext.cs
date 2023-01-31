using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml.Domain
{
    public enum BarlineStyleEnum
    {
        None = 0,
        Dashed = 1,
        Dotted,
        Heavy,
        Heavy_Heavy,
        Heavy_Light,
        Light_Heavy,
        Light_Light,
        Regular,
        Short,
        Tick,
    };
    public class MusicXmlBarlineContext
    {
        #region Properties
        public BarlineStyleEnum BarlineStyle { get; set; }
        public bool IsLeft { get; set; }
        public bool IsRight { get; set; }
        public bool IsDoubleBarline
        {
            get
            {
                var result = false;
                if (this.BarlineStyle == BarlineStyleEnum.Heavy_Heavy
                    || this.BarlineStyle == BarlineStyleEnum.Heavy_Light
                    || this.BarlineStyle == BarlineStyleEnum.Light_Heavy
                    || this.BarlineStyle == BarlineStyleEnum.Light_Light)
                {
                    result = true;
                }
                return result;
            }
        }
        public List<MusicXmlEnding> Endings { get; set; } = new List<MusicXmlEnding>();
        public MusicXmlRepeatContext RepeatContext { get; set; }

        #endregion

        #region Construction
        public MusicXmlBarlineContext(BarlineStyleEnum style)
        {
            this.BarlineStyle = style;
        }

        internal XElement ToXElement()
        {
            var result = new XElement(XmlConstants.barline);
            if (null != this.RepeatContext)
            {
                XElement xrepeat = this.RepeatContext.ToXElement();
            }

            foreach (var ending in this.Endings)
            {
                result.Add(ending.ToXElement());
            }

            return result;
        }

        #endregion
    }//class

    public enum EndingTypeEnum
    {
        Unknown,
        Start,
        Stop,
        Discontinue
    };
    public class MusicXmlEnding
    {
        #region Properties
        public EndingTypeEnum EndingType { get; set; } = EndingTypeEnum.Unknown;
        public string EndingNumber { get; set; }

        #endregion
        
        #region Construction
        public MusicXmlEnding(EndingTypeEnum EndingType, string endingNumber)
        {
            this.EndingType = EndingType;
            this.EndingNumber = endingNumber;
        }

        #endregion
        
        public XElement ToXElement()
        {
#if false
<ending number="1,2" type="start">1., 2.</ending>

<ending number="1,2" type="stop"/>

<ending number="3" type="start">3.</ending>
#endif
            
            var result = new XElement(XmlConstants.ending);

            result.Add(
            new XAttribute(XmlConstants.ending_number, 
                $"{this.EndingNumber.ToString()}."));
            
            var strEndingType = string.Empty;
            if (this.EndingType == EndingTypeEnum.Start)
                strEndingType = XmlConstants.ending_type_start;

            else if (this.EndingType == EndingTypeEnum.Stop)
                strEndingType = XmlConstants.ending_type_stop;

            else if (this.EndingType == EndingTypeEnum.Discontinue)
                strEndingType = XmlConstants.ending_type_discontinue;

            result.Add(
                new XAttribute(XmlConstants.ending_type, 
                    strEndingType));

            return result;
        }
    }//class

}//ns
