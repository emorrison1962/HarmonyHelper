using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlScoreMetadata
    {
        public string Title { get; set; }
        public KeySignature KeySignature { get; set; }
    }//class

    public class MusicXmlMetadata
    {
        public KeySignature KeySignature { get; set; }
        public TimeSignature TimeSignature { get; set; }
        public int PulsesPerMeasure { get; set; }
    }

}//ns
