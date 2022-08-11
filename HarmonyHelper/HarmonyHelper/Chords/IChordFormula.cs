using Eric.Morrison.Harmony.Intervals;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony.Chords
{
    public interface IChordFormula
    {
        NoteName Bass { get; }
        ChordType ChordType { get; }
        bool IsDiminished { get; }
        bool IsDominant { get; }
        bool IsMajor { get; }
        bool IsMinor { get; }
        KeySignature Key { get; }
        string Name { get; }
        List<NoteName> NoteNames { get; }
        NoteName Root { get; }

        int CompareTo(ChordFormula other);
        ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare);
        bool Contains(NoteName note);
        bool Equals(ChordFormula other);
        bool Equals(object obj);
        int GetHashCode();
        NoteName GetNormalized(NoteName nn, Interval baseInterval);
        ChordToneFunctionEnum GetRelationship(NoteName note);
        void Normalize(ref List<NoteName> noteNames);
        void SetBassNote(NoteName bass);
        string ToString();
    }
}