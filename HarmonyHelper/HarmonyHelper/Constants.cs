namespace Eric.Morrison.Harmony
{
	static public class Constants
	{
		public const string SHARP = "♯";
		public const string FLAT = "♭";
		public const char SHARP_CHAR = '♯';
		public const char FLAT_CHAR = '♭';
		public const string DOUBLE_SHARP = "♯♯";
		public const string DOUBLE_FLAT = "♭♭";

		public const string MAJOR = "△";


		public const string NONE = "none";
		public const string MINOR_2ND = "m2";
		public const string MAJOR_2ND = Constants.MAJOR + "2";
		public const string MINOR_3RD = "m3";
		public const string MAJOR_3RD = Constants.MAJOR + "3";
		public const string DIMINISHED_4TH = "dim4";
		public const string PERFECT_4TH = "P4";
		public const string AUGMENTED_4TH = "+4";
		public const string DIMINISHED_5TH = "dim5";
		public const string PERFECT_5TH = "P5";
		public const string AUGMENTED_5TH = "+5";
		public const string MINOR_6TH = "m6";
		public const string MAJOR_6TH = Constants.MAJOR + "6";
		public const string DIMINISHED_7TH = "dim7";
		public const string MINOR_7TH = "m7";
		public const string MAJOR_7TH = Constants.MAJOR + "7";

		public const string ROOT = "R";
		public const string FLAT_9TH = Constants.FLAT + "9th";
		public const string NINTH = "9th";
		public const string SHARP_9TH = Constants.SHARP + "9th";
		public const string FLAT_11TH = Constants.FLAT + "11th";
		public const string ELEVENTH = "11th";
		public const string SHARP_11TH = Constants.SHARP + "11th";
		public const string FLAT_13TH = Constants.FLAT + "13th";
		public const string THIRTEENTH = "13th";
		public const string SHARP_13TH = Constants.SHARP + "13th";

		public const int INTERVAL_VALUE_UNISON = 1;
		public const int INTERVAL_VALUE_MINOR_2ND = 1 << 1;
		public const int INTERVAL_VALUE_MAJOR_2ND = 1 << 2;
		public const int INTERVAL_VALUE_MINOR_3RD = 1 << 3;
		public const int INTERVAL_VALUE_MAJOR_3RD = 1 << 4;
		public const int INTERVAL_VALUE_DIMINISHED_4TH = INTERVAL_VALUE_MAJOR_3RD;
		public const int INTERVAL_VALUE_PERFECT_4TH = 1 << 5;
		public const int INTERVAL_VALUE_AUGMENTED_4TH = 1 << 6;
		public const int INTERVAL_VALUE_DIMINISHED_5TH = INTERVAL_VALUE_AUGMENTED_4TH;
		public const int INTERVAL_VALUE_PERFECT_5TH = 1 << 7;
		public const int INTERVAL_VALUE_AUGMENTED_5TH = 1 << 8;
		public const int INTERVAL_VALUE_MINOR_6TH = INTERVAL_VALUE_AUGMENTED_5TH;
		public const int INTERVAL_VALUE_MAJOR_6TH = 1 << 9;
		public const int INTERVAL_VALUE_MINOR_7TH = 1 << 10;
		public const int INTERVAL_VALUE_MAJOR_7TH = 1 << 11;
		public const int INTERVAL_VALUE_PERFECT_OCTAVE = 1 << 12;

		public const int COUNT_DIATONIC_SCALE_DEGREES = 7;

		public const string EMPTY = "Empty";

	}
}
