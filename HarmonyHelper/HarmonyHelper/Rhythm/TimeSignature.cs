using System;

namespace Eric.Morrison.Harmony.Rhythm
{
    public class TimeSignature
    {
        public int BeatCount { get; set; }
        //public DurationEnum BeatUnit { get; set; }
        public int BeatUnit { get; set; }

        public TimeSignature(int count, int unit)
        {
            this.BeatCount = count;
            this.BeatUnit = unit;
        }
    }//class
}//ns