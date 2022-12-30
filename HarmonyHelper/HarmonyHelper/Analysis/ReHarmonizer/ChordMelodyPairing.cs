using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ChordMelodyPairing : IEquatable<ChordMelodyPairing>
    {
        public TimedEvent<ChordFormula> Chord { get; set; }
        public List<TimedEvent<Note>> Notes { get; set; } = new List<TimedEvent<Note>>();
        public ChordFormula Formula { get; set; }
        public List<NoteName> Melody { get; set; } = new List<NoteName>();
        public TimeContext TimeContext { get; set; }

        public ChordMelodyPairing(TimedEvent<ChordFormula> Chord,
            List<TimedEvent<Note>> Notes, TimeContext TimeContext)
        {
            this.Chord = Chord;
            this.Notes = Notes;
            this.TimeContext = TimeContext;

            this.Formula = Chord.Event;
            this.Melody = Notes.Select(x => x.Event.NoteName)
                .Distinct()
                .OrderBy(x => x.AsciiSortValue)
                .ToList();
        }

        public bool Equals(ChordMelodyPairing other)
        {
            var result = false;

            int myMelody = 0;
            int otherMelody = 0;
            this.Melody.ForEach(x => myMelody |= x.Value);
            other.Melody.ForEach(x => otherMelody |= x.Value);

            if (this.Chord.Event == other.Chord.Event
                && myMelody == otherMelody)
                result = true;
            return result;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            var melody = string.Join(",", this.Melody);
            return $"{nameof(ChordMelodyPairing)}: Chord={this.Chord.Event}, Melody={melody}";
        }
    }//class
}//ns
