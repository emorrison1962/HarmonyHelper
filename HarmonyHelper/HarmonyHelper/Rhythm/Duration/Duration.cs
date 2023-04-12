using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony.Rhythm
{

    /// <summary>
    /// http://www.treblis.com/Notation/Tuplet.html
    /// </summary>
    public class Duration
    {

        public DurationEnum Value { get; set; }

        public Duration(DurationEnum duration)
        {
            this.Value = duration;
        }

    }//class
}//ns
