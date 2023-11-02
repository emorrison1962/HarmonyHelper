using System;

using Eric.Morrison.Harmony.MusicXml;

using static Eric.Morrison.Harmony.Constants;

namespace Eric.Morrison.Harmony
{
    [Flags]
    public enum ModeEnum
    {
        Ionian = 1,
        Dorian,
        Phrygian,
        Lydian,
        Mixolydian,
        Aeolian,
        Locrian
    }


    public enum IntervalValuesEnum : uint
    {
        Unison = 1,
        Minor2nd = 1 << 1,
        Major2nd = 1 << 2,
        Minor3rd = 1 << 3,
        Major3rd = 1 << 4,
        Diminished4th = Major3rd,
        Perfect4th = 1 << 5,
        Augmented4th = 1 << 6,
        Diminished5th = Augmented4th,
        Perfect5th = 1 << 7,
        Augmented5th = 1 << 8,
        Minor6th = Augmented5th,
        Major6th = 1 << 9,
        Diminished7th = Major6th,
        Minor7th = 1 << 10,
        Major7th = 1 << 11,
        PerfectOctave = 1 << 12,
    };

    public enum IntervalFunctionalValuesEnum
    {
        Unison = 1,
        AugmentedUnison = Unison | Augmented,

        Second = 1 << 1,
        Minor2nd = Second | Minor,
        Major2nd = Second | Major,

        Third = 1 << 2,
        Minor3rd = Third | Minor,
        Major3rd = Third | Major,

        Fourth = 1 << 3,
        Diminished4th = Fourth | Diminished,
        Perfect4th = Fourth | Perfect,
        Augmented4th = Fourth | Augmented,

        Fifth = 1 << 4,
        Diminished5th = Fifth | Diminished,
        Perfect5th = Fifth | Perfect,
        Augmented5th = Fifth | Augmented,

        Sixth = 1 << 5,
        Minor6th = Sixth | Minor,
        Major6th = Sixth | Major,

        Seventh = 1 << 6,
        Diminished7th = Seventh | Diminished,
        Minor7th = Seventh | Minor,
        Major7th = Seventh | Major,

        Octave = 1 << 7,
        PerfectOctave = Octave | Perfect,
        DiminishedOctave = Octave | Diminished,

        Major = 1 << 31,
        Minor = 1 << 30,
        Perfect = 1 << 29,
        Augmented = 1 << 28,
        Diminished = 1 << 27,

    };


    [Flags]
    public enum OctaveEnum : uint
    {
        Unknown = uint.MaxValue,
        Octave0 = 1,
        Octave1 = 2,
        Octave2 = 3,
        Octave3 = 4,
        Octave4 = 5,
        Octave5 = 6,
        Octave6 = 7,
    }

    [Flags]
    public enum DirectionEnum
    {
        None = 0,
        Ascending = 1 << 1,
        Descending = 1 << 2,
        AllowTemporayReversalForCloserNote = 1 << 3,
    }

    public enum FiveStringBassPositionEnum
    {
        FirstPosition = 1,
        FifthPosition = 5,
        SixthPosition = 6,
        SeventhPosition = 7,
        EigthPosition = 8,
        NinthPosition = 9,
        TenthPosition = 10,
        EleventhPosition = 11,
        TwelfthPosition = 12,
    }

    public enum GuitarPositionEnum
    {
        OpenPosition = 0,
        FirstPosition = 1,
        SecondPosition = 2,
        ThirdPosition = 3,
        FourthPosition = 4,
        FifthPosition = 5,
        SixthPosition = 6,
        SeventhPosition = 7,
        EigthPosition = 8,
        NinthPosition = 9,
        TenthPosition = 10,
        EleventhPosition = 11,
        TwelfthPosition = 12,
    }

    public enum ToStringEnum
    {
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }


    public enum ChordFunctionEnum
    {
        None = 0,
        Root,
        Sus2,
        Third,
        Sus4,
        Fifth,
        Seventh,
        Ninth,
        Eleventh,
        Thirteenth,
    }

    public enum ChordToneFunctionEnum
    {
        None = 0,
        Root,

        Sus2,

        Minor3rd,
        Major3rd,

        Sus4,

        Diminished5th,
        Perfect5th,
        Augmented5th,

        Major6th,

        Diminished7th,
        Minor7th,
        Major7th,

        Flat9th,
        Ninth,
        Sharp9th,

        Flat11th,
        Eleventh,
        Augmented11th,

        Flat13th,
        Thirteenth,
    }

    public enum ScaleToneFunctionEnum
    {
        None = 0,
        Root,
        AugmentedUnison,

        Minor2nd,
        Major2nd,
        Augmented2nd,

        Diminished3rd,
        Minor3rd,
        Major3rd,

        Diminished4th,
        Perfect4th,
        Augmented4th,

        Diminished5th,
        Perfect5th,
        Augmented5th,

        Minor6th,
        Major6th,
        Augmented6th,

        Diminished7th,
        Minor7th,
        Major7th,

        DiminishedOctave
    }

    public enum IntervalRoleTypeEnum
    {
        Unknown = int.MinValue,
        Unison = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4,
        Sixth = 5,
        Seventh = 6,
        Octave = 7,
        Ninth,
        Eleventh,
        Thirteenth,
    };

    public enum IsDiatonicEnum
    {
        Unknown,
        No,
        Partially,
        Yes,
    };

    public enum ChordFormulaContainsEnum
    {
        Unknown,
        No,
        Partially,
        Yes
    };

    [Flags]
    public enum ChordTonesBitmaskEnum : uint
    {
        Third = ChordIntervalsEnum.IntervalMinor3rd | ChordIntervalsEnum.IntervalMajor3rd,
        Fifth = ChordIntervalsEnum.IntervalDiminished5th | ChordIntervalsEnum.IntervalPerfect5th | ChordIntervalsEnum.IntervalAugmented5th,
        Seventh = ChordIntervalsEnum.IntervalMinor7th | ChordIntervalsEnum.IntervalMajor7th
    }


    [Flags]
    public enum ChordIntervalsEnum : uint
    {
        None = 0,
        IntervalRoot = 1,

        IntervalSus2 = 1 << 1,

        IntervalMinor3rd = 1 << 2,
        IntervalMajor3rd = 1 << 3,

        IntervalSus4 = 1 << 4,

        IntervalDiminished5th = 1 << 5,
        IntervalPerfect5th = 1 << 6,
        IntervalAugmented5th = 1 << 7,

        IntervalMajor6th = 1 << 8,

        IntervalDiminished7th = 1 << 9,
        IntervalMinor7th = 1 << 10,
        IntervalMajor7th = 1 << 11,

        IntervalFlat9th = 1 << 12,
        IntervalNinth = 1 << 13,
        IntervalSharp9th = 1 << 14,

        IntervalFlat11th = 1 << 15,
        IntervalEleventh = 1 << 16,
        IntervalAugmented11th = 1 << 17,

        IntervalFlat13th = 1 << 18,
        IntervalThirteenth = 1 << 19,

        IsChord = 1 << 30,

        Major = IsChord | IntervalRoot | IntervalMajor3rd | IntervalPerfect5th,
        Major6 = Major | IntervalMajor6th,
        Major7 = Major | IntervalMajor7th,
        Major9 = Major7 | IntervalNinth,
        Major11 = Major9 | IntervalEleventh,
        Major13 = Major11 | IntervalThirteenth,
        MajorMu = IsChord | IntervalRoot | IntervalMajor3rd | IntervalPerfect5th | IntervalNinth,


        Dominant7 = Major | IntervalMinor7th,
        Dominant7b9 = Dominant7 | IntervalFlat9th,
        Dominant7Sharp9 = Dominant7 | IntervalSharp9th,

        Dominant7b5 = IsChord | IntervalRoot | IntervalMajor3rd | IntervalDiminished5th | IntervalMinor7th,
        Dominant7b5b9 = Dominant7b5 | IntervalFlat9th,
        Dominant7b5Sharp9 = Dominant7b5 | IntervalSharp9th,

        Dominant7Sharp5 = Augmented | IntervalMinor7th,
        Dominant7Sharp5b9 = Dominant7Sharp5 | IntervalFlat9th,
        Dominant7Sharp5Nine = Dominant7Sharp5 | IntervalNinth,


        Dominant9 = Dominant7 | IntervalNinth,
        Dominant11 = Dominant9 | IntervalEleventh,
        DominantAug11 = Dominant9 | IntervalAugmented11th,
        Dominant11b9 = Dominant11 | IntervalFlat9th,
        Dominant13 = Dominant11 | IntervalThirteenth,
        Dominant13Aug11 = Dominant13 | IntervalAugmented11th,
        Dominant13b9 = Dominant13 | IntervalFlat9th,

        Sus4 = IsChord | IntervalRoot | IntervalSus4 | IntervalPerfect5th,
        Sus2 = IsChord | IntervalRoot | IntervalSus2 | IntervalPerfect5th,
        Sus2Sus4 = Sus2 | Sus4,
        Dominant7Sus2 = Sus2 | IntervalMinor7th,
        Dominant7Sus4 = Sus4 | IntervalMinor7th,

        Augmented = IsChord | IntervalRoot | IntervalMajor3rd | IntervalAugmented5th,
        Diminished = IsChord | IntervalRoot | IntervalMinor3rd | IntervalDiminished5th,

        HalfDiminished = Diminished | IntervalMinor7th,
        Diminished7 = IsChord | IntervalRoot | IntervalMinor3rd | IntervalDiminished5th | IntervalDiminished7th,

        Minor = IsChord | IntervalRoot | IntervalMinor3rd | IntervalPerfect5th,
        Minor7 = Minor | IntervalMinor7th,
        Minor9 = Minor7 | IntervalNinth,
        Minor11 = Minor9 | IntervalEleventh,
        Minor13 = Minor11 | IntervalThirteenth,

        Minor6 = Minor | IntervalMajor6th,
        Minor6Add9 = Minor6 | IntervalNinth,
        Minor7Sharp5 = IsChord | IntervalRoot | IntervalMinor3rd | IntervalAugmented5th | IntervalMinor7th,
        MinorAdd9 = Minor | IntervalNinth,
        MinorMajor7 = Minor | IntervalMajor7th,
        MinorAugmented = IsChord | IntervalRoot | IntervalMinor3rd | IntervalAugmented5th,
        MinorMajor7Aug = MinorAugmented | IntervalMajor7th,
        MinorMajor9 = MinorMajor7 | IntervalNinth,

        Major13Aug11 = Major7 | IntervalAugmented11th | IntervalThirteenth,
        Major7Aug = Augmented | IntervalMajor7th,
        Major7b5 = IsChord | IntervalRoot | IntervalMajor3rd | IntervalDiminished5th | IntervalMajor7th,
        Major9thSharp11 = Major7 | IntervalNinth | IntervalAugmented11th,

        IsDominant = IntervalMajor3rd | IntervalMinor7th,
        IsMajor = IntervalMajor3rd ^ IntervalMinor7th,
        IsMinor = IntervalMinor3rd,
        IsDiminished = IntervalDiminished5th,
        IsHalfDiminished = IntervalDiminished5th  | IntervalMinor7th,

    };
}//ns

namespace Eric.Morrison.Harmony.MusicXml
{
    [Flags]
    public enum TieTypeEnum
    {
        None = 0,
        Start = 1 << 1,
        Stop = 1 << 2,
        StartStop = 1 << 3,
    };

    public enum ClefEnum
    {
        Unknown = 0,
        Treble = 1 << 1, //G clef
        Bass = 1 << 2,   //F clef
        Percussion = 1 << 3,
    };

}//ns