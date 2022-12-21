using System.Collections.Generic;

using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony.Chords
{
    public interface IChordFormula
    {
        NoteName Bass { get; }
        ChordType ChordType { get; }
        bool IsDiminished { get; }
        bool IsDominant { get; }
        bool IsHalfDiminished { get; }
        bool IsMajor { get; }
        bool IsMinor { get; }
        KeySignature Key { get; }
        string Name { get; }
        List<NoteName> NoteNames { get; }
        NoteName Root { get; }

        int CompareTo(ChordFormula other);
        ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare);
        bool Contains(List<NoteName> notes);
        ContainsEnum Contains(List<NoteName> criteria, out List<NoteName> contained, out List<NoteName> notContained);
        bool Contains(NoteName note);
        ChordFormula Copy();
        bool Equals(ChordFormula other);
        bool Equals(object obj);
        int GetHashCode();
        NoteName GetNormalized(NoteName nn, Interval baseInterval);
        ChordToneFunctionEnum GetRelationship(NoteName note);
        void Normalize(ref List<NoteName> noteNames);
        void SetBassNote(NoteName bass);
        string ToString();
    }

    public interface IHasTimeContext
    {
        TimeContext TimeContext { get; }
    }
    public interface IHasTimeContext<T> where T : class, IMusicalEvent<T>
    {
        T Event { get; }
    }

}//ns