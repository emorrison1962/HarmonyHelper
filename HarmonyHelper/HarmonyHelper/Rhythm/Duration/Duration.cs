using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Rhythm
{
    public enum DurationEnum
    {
        Whole = Quarter * 4,
        Half = Quarter * 2,
        Quarter = 240,
        Eighth = Quarter / 2,
        Sixteenth = Eighth / 2,
        SixtyFourth = Sixteenth / 2,

        EighthTriplet = Quarter / 3,
        SixteenthTriplet = Eighth / 3,

        EightQuintuplet = Half / 5,
        SixteenthQuintuplet = Quarter / 5,
    }

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
