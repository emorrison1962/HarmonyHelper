using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ChordMelodyPairing
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
    }//class

    public class ChordSubstitution
    {
        public ChordFormula Original { get; private set; }
        public ChordFormula Substitution { get; private set; }
        public TimeContext TimeContext { get; private set; }

        public ChordSubstitution(ChordFormula Original, ChordFormula Substitution, TimeContext TimeContext)
        {
            this.Original = Original;
            this.Substitution = Substitution;
            this.TimeContext = TimeContext;
        }
        public override string ToString()
        {
            return $"{nameof(ChordSubstitution)}: TimeContext={TimeContext}, Original={Original}, Substitution={Substitution}";
        }
    }//class

}//ns
