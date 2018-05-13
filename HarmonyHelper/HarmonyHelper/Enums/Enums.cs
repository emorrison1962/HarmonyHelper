using System;

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



	[Obsolete("", true)]
	[Flags]
	public enum IntervalsEnum
	{
		None = 0,
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
		// Octave = 1 << 12,
	}
#if false
None
Minor2nd
Major2nd
Minor3rd
Major3rd
Diminished4th
Perfect4th
Augmented4th
Diminished5th
Perfect5th
Augmented5th
Minor6th
Major6th
Minor7th
Major7th
#endif

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

		Minor2nd,
		Major2nd,
		Augmented2nd,

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

		Diminished7th,
		Minor7th,
		Major7th,
	}


}//ns
