using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<MusicXmlEnding> _Endings { get; set; } = new List<MusicXmlEnding>();
        public ReadOnlyCollection<MusicXmlEnding> Endings { get { return _Endings.AsReadOnly(); } }
        public MusicXmlRepeatContext RepeatContext { get; set; }

        #endregion

        #region Construction
        public MusicXmlBarlineContext(BarlineStyleEnum style)
        {
            this.BarlineStyle = style;
        }

        public void Add(MusicXmlEnding ending)
        {
            this._Endings.Add(ending);
        }

        internal XElement ToXElement()
        {
            var result = new XElement(XmlConstants.barline);
            result.Add(this.ToXElement(this.BarlineStyle));

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

        XElement ToXElement(BarlineStyleEnum style)
        {
            var result = new XElement(XmlConstants.bar_style);
            if (style == BarlineStyleEnum.Heavy_Heavy)
                result.Value = XmlConstants.bar_style_heavy_heavy;
            else if (style == BarlineStyleEnum.Heavy_Light)
                result.Value = XmlConstants.bar_style_heavy_light;
            else if (style == BarlineStyleEnum.Light_Heavy)
                result.Value = XmlConstants.bar_style_light_heavy;
            else if (style == BarlineStyleEnum.Light_Light)
                result.Value = XmlConstants.bar_style_light_light;
            else
                result = null;
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
                $"{this.EndingNumber.ToString()}"));

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

    public enum RepeatEnum
    {
        None,
        Forward,
        Backward,
        RepeatAfterJump,
        Segno,
        Coda
    };
    public class MusicXmlRepeatContext
    {
        public RepeatEnum RepeatEnum { get; set; }
        public int RepeatCount { get; set; }

        public MusicXmlRepeatContext(RepeatEnum repeatEnum, int repeatCount = 1)
        {
            this.RepeatEnum = repeatEnum;
            this.RepeatCount = repeatCount;
        }

        public XElement ToXElement()
        {
            var result = new XElement(XmlConstants.repeat);

            result.Add(
                new XAttribute(XmlConstants.repeat_direction,
                    this.RepeatEnum.ToString().ToLower()));

            if (this.RepeatCount > 1)
            {
                result.Add(
                    new XAttribute(XmlConstants.repeat_times,
                        this.RepeatCount.ToString()));
            }

            if (this.RepeatEnum == RepeatEnum.RepeatAfterJump)
            {
                throw new NotImplementedException("Does this work?");
            }

            return result;
        }
    }//class

}//ns
