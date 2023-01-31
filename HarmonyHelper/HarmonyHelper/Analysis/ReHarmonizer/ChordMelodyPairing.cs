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
        public TimedEventChordFormula Chord { get; set; }
        public List<TimedEventNote> Notes { get; set; } = new List<TimedEventNote>();
        public ChordFormula Formula { get; set; }
        public List<NoteName> Melody { get; set; } = new List<NoteName>();
        public int MelodyBitMask { get; set; } 
        public TimeContext TimeContext { get; set; }

        public ChordMelodyPairing(TimedEventChordFormula Chord,
            List<TimedEventNote> Notes, TimeContext TimeContext)
        {
            this.Chord = Chord;
            this.Notes = Notes;
            this.TimeContext = TimeContext;

            this.Formula = Chord.Event;
            Notes.ForEach(x => this.MelodyBitMask |= x.Event.NoteName.Value);
            this.Melody = Notes.Select(x => x.Event.NoteName)
               .Distinct(new NoteNameValueEqualityComparer())
               .OrderBy(x => x.AsciiSortValue)
               .ToList();
        }

        public bool Equals(ChordMelodyPairing other)
        {
            var result = false;

            if (this.Chord.Event == other.Chord.Event
                && this.MelodyBitMask == other.MelodyBitMask)
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
