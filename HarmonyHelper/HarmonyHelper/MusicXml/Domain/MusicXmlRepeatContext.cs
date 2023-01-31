using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml.Domain
{
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
    }
}
