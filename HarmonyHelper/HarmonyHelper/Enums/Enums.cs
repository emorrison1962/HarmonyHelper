using System;

namespace Eric.Morrison.Harmony
{
    [Flags]
    public enum NotesEnum
    {
        C = 1 << 1,
        Db = 1 << 2,
        D = 1 << 3,
        Eb = 1 << 4,
        E = 1 << 5,
        F = 1 << 6,
        Gb = 1 << 7,
        G = 1 << 8,
        Ab = 1 << 9,
        A = 1 << 10,
        Bb = 1 << 11,
        B = 1 << 12,

        Cb = B,
        Fb = E,

        DSharp = Eb,
        GSharp = Ab,
        CSharp = Db,
        FSharp = Gb,
    };

    [Flags]
    public enum OctaveEnum
    {
        Unknown = int.MinValue,
        Octave0 = 1 << 13,
        Octave1 = 1 << 14,
        Octave2 = 1 << 15,
        Octave3 = 1 << 16,
        Octave4 = 1 << 17,
        Octave5 = 1 << 18,
        Octave6 = 1 << 19,
    }


    [Flags]
    public enum ChordTypesEnum
    {
        Major = IntervalsEnum.Major3rd | IntervalsEnum.Perfect5th,
        Minor = IntervalsEnum.Minor3rd | IntervalsEnum.Perfect5th,
        Augmented = IntervalsEnum.Major3rd | IntervalsEnum.Augmented5th,
        Diminished = IntervalsEnum.Minor3rd | IntervalsEnum.Diminished5th,

        Major7th = Major | IntervalsEnum.Major7th,
        Minor7th = Minor | IntervalsEnum.Minor7th,
        Dominant7th = Major | IntervalsEnum.Minor7th,
        HalfDiminished = Diminished | IntervalsEnum.Minor7th,
        Diminished7 = Diminished | IntervalsEnum.Major6th,
        //Suspended,....
    }

    [Flags]
    public enum IntervalsEnum
    {
        Unknown = 0,
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
        Minor7th = 1 << 10,
        Major7th = 1 << 11,
    }

    public enum DirectionEnum
    {
        Ascending = 1,
        Descending
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

    public enum ToStringEnum
    {
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }

    [Obsolete("", true)]
    public enum KeySignatureEnum
    {
        Default = -1,

        NoAccidentals = NotesEnum.C,
        CMajor = NotesEnum.C,
        AMinor = NotesEnum.C,

        OneSharps = NotesEnum.G, // F#
        GMajor = NotesEnum.G,
        EMinor = NotesEnum.G,

        TwoSharps = NotesEnum.D, // F♯, C♯
        DMajor = NotesEnum.D,
        BMinor = NotesEnum.D,

        ThreeSharps = NotesEnum.A,// F♯, C♯, G♯
        AMajor = NotesEnum.A,
        FSharpMinor = NotesEnum.A,

        FourSharps = NotesEnum.E,// F♯, C♯, G♯, D♯
        EMajor = NotesEnum.E,
        CSharpMinor = NotesEnum.E,

        FiveSharps = NotesEnum.B,// F♯, C♯, G♯, D♯, A♯
        BMajor = NotesEnum.B,
        GSharpMinor = NotesEnum.B,

        SixSharps = NotesEnum.FSharp,// F♯, C♯, G♯, D♯, A♯, E♯
        FSharpMajor = NotesEnum.FSharp,
        DSharpMinor = NotesEnum.FSharp,

        SevenSharps = NotesEnum.CSharp,// F♯, C♯, G♯, D♯, A♯, E♯, B♯
        CSharpMajor = NotesEnum.CSharp,
        ASharpMinor = NotesEnum.CSharp,

        OneFlats = NotesEnum.F,// B♭
        FMajor = NotesEnum.F,
        DMinor = NotesEnum.F,

        TwoFlats = NotesEnum.Bb,// B♭, E♭
        BbMajor = NotesEnum.Bb,
        GMinor = NotesEnum.Bb,

        ThreeFlats = NotesEnum.Eb,// B♭, E♭, A♭
        EbMajor = NotesEnum.Eb,
        CMinor = NotesEnum.Eb,

        FourFlats = NotesEnum.Ab,// B♭, E♭, A♭, D♭
        AbMajor = NotesEnum.Ab,
        FMinor = NotesEnum.Ab,

        FiveFlats = NotesEnum.Db,// B♭, E♭, A♭, D♭, G♭
        DbMajor = NotesEnum.Db,
        BbMinor = NotesEnum.Db,


        SixFlats = NotesEnum.Gb,// B♭, E♭, A♭, D♭, G♭, C♭
        GbMajor = NotesEnum.Gb,
        EbMinor = NotesEnum.Gb,

        SevenFlats = NotesEnum.Cb,// B♭, E♭, A♭, D♭, G♭, C♭, F♭
        CbMajor = NotesEnum.Cb,
        AbMinor = NotesEnum.Cb,
    }

    public enum ChordFunctionEnum
    {
        I,
        ii,
        iii,
        IV,
        V,
        vi,
        vii,
    }

}//ns
