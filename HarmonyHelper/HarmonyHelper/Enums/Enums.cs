﻿using System;

using Eric.Morrison.Harmony.MusicXml;
using static Eric.Morrison.Harmony.Constants;

namespace Eric.Morrison.Harmony
{

    public enum IntervalValuesEnum
    {
        INTERVAL_VALUE_UNISON = 1,
        INTERVAL_VALUE_MINOR_2ND = 1 << 1,
        INTERVAL_VALUE_MAJOR_2ND = 1 << 2,
        INTERVAL_VALUE_MINOR_3RD = 1 << 3,
        INTERVAL_VALUE_MAJOR_3RD = 1 << 4,
        INTERVAL_VALUE_DIMINISHED_4TH = INTERVAL_VALUE_MAJOR_3RD,
        INTERVAL_VALUE_PERFECT_4TH = 1 << 5,
        INTERVAL_VALUE_AUGMENTED_4TH = 1 << 6,
        INTERVAL_VALUE_DIMINISHED_5TH = INTERVAL_VALUE_AUGMENTED_4TH,
        INTERVAL_VALUE_PERFECT_5TH = 1 << 7,
        INTERVAL_VALUE_AUGMENTED_5TH = 1 << 8,
        INTERVAL_VALUE_MINOR_6TH = INTERVAL_VALUE_AUGMENTED_5TH,
        INTERVAL_VALUE_MAJOR_6TH = 1 << 9,
        INTERVAL_VALUE_DIMINISHED_7TH = INTERVAL_VALUE_MAJOR_6TH,
        INTERVAL_VALUE_MINOR_7TH = 1 << 10,
        INTERVAL_VALUE_MAJOR_7TH = 1 << 11,
        INTERVAL_VALUE_PERFECT_OCTAVE = 1 << 12,
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
		Major = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_3RD | IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH,
		Minor = IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD | IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH,
		Augmented = IntervalValuesEnum.INTERVAL_VALUE_MAJOR_3RD | IntervalValuesEnum.INTERVAL_VALUE_AUGMENTED_5TH,
		Diminished = IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD | IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_5TH,
		Major7th = Major | IntervalValuesEnum.INTERVAL_VALUE_MAJOR_7TH,
		Minor7th = Minor | IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH,
		Dominant7th = Major | IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH,
		HalfDiminished = Diminished | IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH,
		Diminished7 = Diminished | IntervalValuesEnum.INTERVAL_VALUE_MAJOR_6TH,
		//Suspended,....
	}


	[Flags]
	public enum ChordTonesBitmaskEnum
	{
		Third = IntervalValuesEnum.INTERVAL_VALUE_MINOR_3RD | IntervalValuesEnum.INTERVAL_VALUE_MAJOR_3RD,
		Fifth = IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_5TH | IntervalValuesEnum.INTERVAL_VALUE_PERFECT_5TH | IntervalValuesEnum.INTERVAL_VALUE_DIMINISHED_5TH,
		Seventh = IntervalValuesEnum.INTERVAL_VALUE_MINOR_7TH | IntervalValuesEnum.INTERVAL_VALUE_MAJOR_7TH
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