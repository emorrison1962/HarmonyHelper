using System;

using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony
{

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
		Major = Constants.INTERVAL_VALUE_MAJOR_3RD | Constants.INTERVAL_VALUE_PERFECT_5TH,
		Minor = Constants.INTERVAL_VALUE_MINOR_3RD | Constants.INTERVAL_VALUE_PERFECT_5TH,
		Augmented = Constants.INTERVAL_VALUE_MAJOR_3RD | Constants.INTERVAL_VALUE_AUGMENTED_5TH,
		Diminished = Constants.INTERVAL_VALUE_MINOR_3RD | Constants.INTERVAL_VALUE_DIMINISHED_5TH,
		Major7th = Major | Constants.INTERVAL_VALUE_MAJOR_7TH,
		Minor7th = Minor | Constants.INTERVAL_VALUE_MINOR_7TH,
		Dominant7th = Major | Constants.INTERVAL_VALUE_MINOR_7TH,
		HalfDiminished = Diminished | Constants.INTERVAL_VALUE_MINOR_7TH,
		Diminished7 = Diminished | Constants.INTERVAL_VALUE_MAJOR_6TH,
		//Suspended,....
	}


	[Flags]
	public enum ChordTonesBitmaskEnum
	{
		Third = Constants.INTERVAL_VALUE_MINOR_3RD | Constants.INTERVAL_VALUE_MAJOR_3RD,
		Fifth = Constants.INTERVAL_VALUE_DIMINISHED_5TH | Constants.INTERVAL_VALUE_PERFECT_5TH | Constants.INTERVAL_VALUE_DIMINISHED_5TH,
		Seventh = Constants.INTERVAL_VALUE_MINOR_7TH | Constants.INTERVAL_VALUE_MAJOR_7TH
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
        Unknown = 0,
        Start = 1 << 1,
        Stop = 1 << 2,
        StartStop = 1 << 3,
    };

	[Flags]
	public enum NoteLengthDivisorEnum
    {
		Whole = 1,
		Half = 2,
		//DottedHalf = 3,
		Quarter = 4,
		DottedQuarter = 6,
		Eighth= 8,
        DottedEighth = 5,
        _16th = 16,
        //DottedSixteenth = 24,
        _32nd = 32,
        _64th = 64,
        _128th = 128,
        _256th = 256,
        _512th = 512,
        _1024th = 1024,
        Breve = int.MinValue,
        Long = int.MinValue,
        Maxima = int.MinValue
    }

	public enum ClefEnum
	{
        Unknown = 0,
        Treble = 1 << 1, //G clef
        Bass = 1 << 2,   //F clef
    };
}//ns