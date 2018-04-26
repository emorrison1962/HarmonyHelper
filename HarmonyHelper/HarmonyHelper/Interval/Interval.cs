using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public class Interval
	{
		#region Constants
		#endregion

		#region Static
		static public Interval None = new Interval("None", 0);
		static public Interval Minor2nd = new Interval("Minor2nd", Constants.INTERVAL_VALUE_MINOR_2ND);
		static public Interval Major2nd = new Interval("Major2nd", Constants.INTERVAL_VALUE_MAJOR_2ND);
		static public Interval Minor3rd = new Interval("Minor3rd", Constants.INTERVAL_VALUE_MINOR_3RD);
		static public Interval Major3rd = new Interval("Major3rd", Constants.INTERVAL_VALUE_MAJOR_3RD);
		static public Interval Diminished4th = new Interval("Diminished4th", Constants.INTERVAL_VALUE_DIMINISHED_4TH);
		static public Interval Perfect4th = new Interval("Perfect4th", Constants.INTERVAL_VALUE_PERFECT_4TH);
		static public Interval Augmented4th = new Interval("Augmented4th", Constants.INTERVAL_VALUE_AUGMENTED_4TH);
		static public Interval Diminished5th = new Interval("Diminished5th", Constants.INTERVAL_VALUE_DIMINISHED_5TH);
		static public Interval Perfect5th = new Interval("Perfect5th", Constants.INTERVAL_VALUE_PERFECT_5TH);
		static public Interval Augmented5th = new Interval("Augmented5th", Constants.INTERVAL_VALUE_AUGMENTED_5TH);
		static public Interval Minor6th = new Interval("Minor6th", Constants.INTERVAL_VALUE_MINOR_6TH);
		static public Interval Major6th = new Interval("Major6th", Constants.INTERVAL_VALUE_MAJOR_6TH);
		static public Interval Minor7th = new Interval("Minor7th", Constants.INTERVAL_VALUE_MINOR_7TH);
		static public Interval Major7th = new Interval("Major7th", Constants.INTERVAL_VALUE_MAJOR_7TH);

		#endregion

		public string Name { get; private set; }
		public int Value { get; private set; }
		private Interval(string name, int value)
		{
			this.Name = name;
			this.Value = value;
		}

		public Interval Invert()
		{
			var result = Interval.None;


			if (this == Interval.Minor2nd)
				result = Interval.Major7th;

			else if (this == Interval.Major2nd)
				result = Interval.Minor7th;

			else if (this == Interval.Minor3rd)
				result = Interval.Major6th;

			else if (this == Interval.Major3rd)
				result = Interval.Minor6th;

			else if (this == Interval.Perfect4th)
				result = Interval.Perfect5th;

			else if (this == Interval.Augmented4th)
				result = Interval.Diminished5th;

			else if (this == Interval.Perfect5th)
				result = Interval.Perfect4th;

			else if (this == Interval.Diminished5th)
				result = Interval.Augmented4th;

			else if (this == Interval.Minor6th)
				result = Interval.Major3rd;

			else if (this == Interval.Major6th)
				result = Interval.Minor3rd;

			else if (this == Interval.Minor7th)
				result = Interval.Major2nd;

			else if (this == Interval.Major7th)
				result = Interval.Minor2nd;

			else
				throw new ArgumentOutOfRangeException();


			return result;
		}


	}//class
}//ns
