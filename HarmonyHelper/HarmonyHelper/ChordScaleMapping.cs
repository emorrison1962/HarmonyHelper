using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class ChordScaleMapping
    {
        public Chord Chord { get; set; }
        public List<ScaleBase> Scales { get; set; }
    }//class

    public class ChordScaleMappingFactory
    {
    }

}//ns
