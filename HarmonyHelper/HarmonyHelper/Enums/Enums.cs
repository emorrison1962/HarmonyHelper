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


    public enum IntervalValuesEnum
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
    public enum OctaveEnum
    {
        Unknown = int.MinValue,
        Octave0 = 0,
        Octave1 = 1,
        Octave2 = 2,
        Octave3 = 3,
        Octave4 = 4,
        Octave5 = 5,
        Octave6 = 6,
    }

    [Obsolete("", true)]
    [Flags]
    public enum ChordTypesEnum
    {
        None = 0,
        Major = IntervalValuesEnum.Major3rd | IntervalValuesEnum.Perfect5th,
        Minor = IntervalValuesEnum.Minor3rd | IntervalValuesEnum.Perfect5th,
        Augmented = IntervalValuesEnum.Major3rd | IntervalValuesEnum.Augmented5th,
        Diminished = IntervalValuesEnum.Minor3rd | IntervalValuesEnum.Diminished5th,
        Major7th = Major | IntervalValuesEnum.Major7th,
        Minor7th = Minor | IntervalValuesEnum.Minor7th,
        Dominant7th = Major | IntervalValuesEnum.Minor7th,
        HalfDiminished = Diminished | IntervalValuesEnum.Minor7th,
        Diminished7 = Diminished | IntervalValuesEnum.Major6th,
        //Suspended,....
    }


    [Flags]
    public enum ChordTonesBitmaskEnum
    {
        Third = IntervalValuesEnum.Minor3rd | IntervalValuesEnum.Major3rd,
        Fifth = IntervalValuesEnum.Diminished5th | IntervalValuesEnum.Perfect5th | IntervalValuesEnum.Diminished5th,
        Seventh = IntervalValuesEnum.Minor7th | IntervalValuesEnum.Major7th
    }

    [Flags]
    public enum DirectionEnum
    {
        None = 0,
        Ascending = 1 << 1,
        Descending = 1 << 2,
        AllowTemporayReversal = 1 << 3,
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

    [Flags]
    public enum ChordIntervalsEnum : uint
    {
        None = 0,
        Root = 1,

        Sus2 = 1 << 1,

        Minor3rd = 1 << 2,
        Major3rd = 1 << 3,

        Sus4 = 1 << 4,

        Diminished5th = 1 << 5,
        Perfect5th = 1 << 6,
        Augmented5th = 1 << 7,

        Major6th = 1 << 8,

        Diminished7th = 1 << 9,
        Minor7th = 1 << 10,
        Major7th = 1 << 11,

        Flat9th = 1 << 12,
        Ninth = 1 << 13,
        Sharp9th = 1 << 14,

        Flat11th = 1 << 15,
        Eleventh = 1 << 16,
        Augmented11th = 1 << 17,

        Flat13th = 1 << 18,
        Thirteenth = 1 << 19,

    };

    [Flags]
    public enum ChordTypeEnum : uint
    {
        Major = ChordIntervalsEnum.Root | ChordIntervalsEnum.Major3rd | ChordIntervalsEnum.Perfect5th,
        Major6 = Major | ChordIntervalsEnum.Major6th,
        Major7 = Major | ChordIntervalsEnum.Major7th,
        Major9 = Major7 | ChordIntervalsEnum.Ninth,
        Major11 = Major9 | ChordIntervalsEnum.Eleventh,
        Major13 = Major11 | ChordIntervalsEnum.Thirteenth,
        MajorMu = ChordIntervalsEnum.Root | ChordIntervalsEnum.Major3rd | ChordIntervalsEnum.Perfect5th | ChordIntervalsEnum.Ninth,


        Dominant7 = Major | ChordIntervalsEnum.Minor7th,
        Dominant7Flat9 = Dominant7 | ChordIntervalsEnum.Flat9th,
        Dominant7Sharp9 = Dominant7 | ChordIntervalsEnum.Sharp9th,

        Dominant7Flat5 = Diminished | ChordIntervalsEnum.Minor7th,
        Dominant7Flat5Flat9 = Dominant7Flat5 | ChordIntervalsEnum.Flat9th,
        Dominant7Flat5Sharp9 = Dominant7Flat5 | ChordIntervalsEnum.Sharp9th,

        Dominant7Sharp5 = Augmented | ChordIntervalsEnum.Minor7th,
        Dominant7Sharp5Flat9 = Dominant7Sharp5 | ChordIntervalsEnum.Flat9th,
        Dominant7Sharp5Nine = Dominant7Sharp5 | ChordIntervalsEnum.Ninth,


        Dominant9 = Dominant7 | ChordIntervalsEnum.Ninth,
        Dominant11 = Dominant9 | ChordIntervalsEnum.Eleventh,
        Dominant11Flat9 = Dominant11 | ChordIntervalsEnum.Flat9th,
        Dominant13 = Dominant11 | ChordIntervalsEnum.Thirteenth,
        Dominant13Augmented11 = Dominant13 | ChordIntervalsEnum.Augmented11th,
        Dominant13Flat9 = Dominant13 | ChordIntervalsEnum.Flat9th,

        Sus4 = ChordIntervalsEnum.Root | ChordIntervalsEnum.Sus4 | ChordIntervalsEnum.Perfect5th,
        Sus2 = ChordIntervalsEnum.Root | ChordIntervalsEnum.Sus2 | ChordIntervalsEnum.Perfect5th,
        Sus2Sus4 = Sus2 | Sus4,
        Dominant7Sus4 = Sus4 | ChordIntervalsEnum.Minor7th,

        Augmented = ChordIntervalsEnum.Root | ChordIntervalsEnum.Major3rd | ChordIntervalsEnum.Augmented5th,
        Diminished = ChordIntervalsEnum.Root | ChordIntervalsEnum.Major3rd | ChordIntervalsEnum.Diminished5th,

        HalfDiminished = Diminished | ChordIntervalsEnum.Minor7th,
        Diminished7 = ChordIntervalsEnum.Root | ChordIntervalsEnum.Minor3rd | ChordIntervalsEnum.Diminished5th | ChordIntervalsEnum.Diminished7th,

        Minor = ChordIntervalsEnum.Root | ChordIntervalsEnum.Minor3rd | ChordIntervalsEnum.Perfect5th,
        Minor7 = Minor | ChordIntervalsEnum.Minor7th,
        Minor9 = Minor7 | ChordIntervalsEnum.Ninth,
        Minor11 = Minor9 | ChordIntervalsEnum.Eleventh,
        Minor13 = Minor11 | ChordIntervalsEnum.Thirteenth,

        Minor6 = Minor | ChordIntervalsEnum.Major6th,
        Minor6Add9 = Minor6 | ChordIntervalsEnum.Ninth,
        Minor7Sharp5 = ChordIntervalsEnum.Root | ChordIntervalsEnum.Minor3rd | ChordIntervalsEnum.Augmented5th | ChordIntervalsEnum.Minor7th,
        MinorAdd9 = Minor | ChordIntervalsEnum.Ninth,
        MinorMajor7 = Minor | ChordIntervalsEnum.Major7th,
        MinorMajor9 = MinorMajor7 | ChordIntervalsEnum.Ninth,

        Major13Sharp11 = Major7 | ChordIntervalsEnum.Augmented11th | ChordIntervalsEnum.Thirteenth,
        Major7Sharp5 = Augmented | ChordIntervalsEnum.Major7th,
        Major7b5 = Diminished | ChordIntervalsEnum.Major7th,
        Major9Sharp11 = Major7 | ChordIntervalsEnum.Ninth | ChordIntervalsEnum.Augmented11th
    };

}//ns