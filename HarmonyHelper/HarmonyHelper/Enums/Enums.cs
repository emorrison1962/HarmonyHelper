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
}//ns