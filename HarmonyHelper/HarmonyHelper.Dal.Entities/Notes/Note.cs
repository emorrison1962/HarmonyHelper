using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public static class SuperScript
	{ 
		public const string ZERO = "⁰";
		public const string ONE = "¹";
		public const string TWO = "²";
		public const string THREE = "³";
		public const string FOUR = "⁴";
		public const string FIVE = "⁵";
		public const string SIX = "⁶";
		public const string SEVEN = "⁷";
		public const string EIGHT = "⁸";
		public const string NINE = "⁹";
	}

	public class Note : ClassBase
    {
        #region Properties
        public int SortOrder { get { return 5; } }

        public NoteName NoteName { get; private set; }

		public OctaveEnum Octave { get; set; }

		#endregion

		#region Construction
		[Obsolete("For EF.", true)]
		public Note() {  }
		public Note(Note src)
		{
			if (null == src)
				throw new ArgumentNullException();
			this.NoteName = src.NoteName.Copy();
			this.Octave = src.Octave;
		}
		public Note(NoteName nn, OctaveEnum octave)
		{
			this.NoteName = nn;
			this.Octave = octave;
		}

		public Note Copy()
		{
			var result = new Note(this);
			return result;
		}
		#endregion

	}//class
}//ns
