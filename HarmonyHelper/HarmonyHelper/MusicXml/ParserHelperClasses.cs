using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace Eric.Morrison.Harmony.MusicXml
{
    public class ChordTimeContext
    {
        public int Measure { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public TimedEvent<Note> FirstNote { get; set; }

        public void Clear()
        {
            this.Measure = 0;
            this.Start = 0;
            this.End = 0;
            this.FirstNote = null;
        }
    }//class

}//ns
