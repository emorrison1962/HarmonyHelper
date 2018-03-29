using System;

namespace Eric.Morrison.Harmony
{

	[Flags]
	public enum OctaveEnum
	{
		Unknown = int.MinValue,
		Octave0 = 0,
		Octave1,
		Octave2,
		Octave3,
		Octave4,
		Octave5,
		Octave6,
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
	public enum ChordTonesBitmaskEnum
	{
		Third = IntervalsEnum.Minor3rd | IntervalsEnum.Major3rd,
		Fifth = IntervalsEnum.Diminished5th | IntervalsEnum.Perfect5th | IntervalsEnum.Diminished5th,
		Seventh = IntervalsEnum.Minor7th | IntervalsEnum.Major7th
	}



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

	public enum ChordToneFunctionEnum
	{
		None = 0,
		Root,
		Third,
		Fifth,
		Seventh,
		Ninth,
		Eleventh,
		Thirteenth,
	}



}//ns
