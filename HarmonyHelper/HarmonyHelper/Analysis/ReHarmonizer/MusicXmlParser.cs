using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony
{
    public class MusicXmlParser
    {
        public MusicXmlParser()
        {

        }

        MusicXmlParingResult Parse(string filename)
        {
            return null;
        }

    }//class
    public class MusicXmlParingResult
    { 
        public List<Bar> Bars { get; set; }
    }//class

    public class Bar
    { 
        public List<ChordFormula> Chords { get; set; }
        public List<NoteName> Notes { get; set; }
    }
}//ns
