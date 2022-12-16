using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ChordMelodyPairing
    {
        public ChordFormula Chord { get; set; }
        public List<NoteName> Melody { get; set; } = new List<NoteName>();

        public ChordMelodyPairing(ChordFormula Chord, List<Note> Notes)
        {
            this.Chord = Chord;
            this.Melody = Notes.Select(x => x.NoteName)
                .Distinct()
                .OrderBy(x => x.AsciiSortValue)
                .ToList();
        }
    }
}
