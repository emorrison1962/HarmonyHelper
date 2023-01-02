using System;

namespace Eric.Morrison.Harmony.Rhythm
{
    public class TimeSignature
    {
        public int BeatCount { get; set; }
        //public DurationEnum BeatUnit { get; set; }
        public int BeatUnit { get; set; }

        public TimeSignature(string count, string unit)
        {
            if (int.TryParse(count, out var beatCount))
            {
                this.BeatCount = beatCount;
            }
            else
            {
                throw new ArgumentException("count");
            }
            
            if (int.TryParse(count, out var beatUnit))
            {
                this.BeatUnit = beatUnit;
            }
            else
            {
                throw new ArgumentException("unit");
            }

        }
    }
}