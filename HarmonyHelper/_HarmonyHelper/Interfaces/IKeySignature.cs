using System.Collections.Generic;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
    public interface IKeySignature
    {
        int AccidentalCount { get; }
        List<NoteName> Accidentals { get; }
        ChordFormula Aeolian { get; }
        ChordFormula Dorian { get; }
        ChordFormula Ionian { get; }
        bool IsMajor { get; }
        bool IsMinor { get; }
        ChordFormula Locrian { get; }
        ChordFormula Lydian { get; }
        ChordFormula MixoLydian { get; }
        string Name { get; }
        NoteName NoteName { get; }
        List<NoteName> NoteNames { get; }
        ChordFormula Phrygian { get; }
        bool UsesFlats { get; }
        bool UsesSharps { get; }

    }
}