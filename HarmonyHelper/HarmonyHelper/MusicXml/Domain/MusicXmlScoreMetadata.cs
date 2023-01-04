using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlScoreMetadata
    {
        public string Title { get; set; }
        public KeySignature KeySignature { get; set; }
        public Eric.Morrison.Harmony.Rhythm.TimeSignature TimeSignatue { get; set; }
    }//class

}//ns
