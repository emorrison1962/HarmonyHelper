using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class ScaleFormula : HarmonyEntityBase
    {
        public List<IntervalsEnum> Intervals { get; protected set; } = new List<IntervalsEnum>();
        public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();
        public ScaleFormula(KeySignature key, IEnumerable<IntervalsEnum> intervals) : base(key)
        {
            this.Intervals = new List<IntervalsEnum>(intervals);
        }

        void Init()
        {
            foreach (var interval in this.Intervals)
            {
                var scaleTone = NoteNamesCollection.Get(this.Key, this.Key.NoteName, interval);
                this.NoteNames.Add(scaleTone);
            }
        }
    }//class
}//ns
