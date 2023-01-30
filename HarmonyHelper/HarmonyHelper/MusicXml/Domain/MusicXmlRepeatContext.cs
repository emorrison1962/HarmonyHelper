using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
