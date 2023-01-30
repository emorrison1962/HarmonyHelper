using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml.Domain
{
    public enum BarlineStyleEnum
    {
        Unknown = 0,
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

        public MusicXmlBarlineContext(BarlineStyleEnum style)
        {
            if (BarlineStyleEnum.Unknown == style)
                throw new ArgumentOutOfRangeException(nameof(style));
            this.BarlineStyle = style;
        }

    }//class

    public enum EndingType
    {
        Start,
        Stop
    }
    public class MusicXmlEnding
    {
        public string EndingNumber { get; set; }
        public EndingType EndingType { get; set; }

    }
}//ns
