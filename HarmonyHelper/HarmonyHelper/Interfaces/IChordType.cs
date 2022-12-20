using System.Collections.Generic;

using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
    public interface IChordType
    {
        List<ChordToneInterval> Intervals { get; }
        bool IsDiminished { get; }
        bool IsDominant { get; }
        bool IsHalfDiminished { get; }
        bool IsMajor { get; }
        bool IsMinor { get; }
        string Name { get; }
        int Value { get; }

        string ToString();
    }
}