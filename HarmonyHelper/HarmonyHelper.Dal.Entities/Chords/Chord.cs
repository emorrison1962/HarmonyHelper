using Eric.Morrison.Harmony.Intervals;
using HarmonyHelper.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Chords
{
    public class Chord : ChordEntityBase
	{
		#region Properties

		public Note Root { get; protected set; }
		public ChordFormula Formula { get; private set; }
		public List<Note> Notes { get; private set; } = new List<Note>();
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public string Name
		{
			get
			{
				var root = this.Root.NoteName.ToString();
				var chordType = this.Formula.ChordType.Name;

				var result = string.Format("{0}{1}",
					root,
					chordType);
				return result;
			}
		}
		public bool IsMajor { get { return this.Formula.ChordType.IsMajor; } }
		public bool IsMinor { get { return this.Formula.ChordType.IsMinor; } }
		public bool IsDiminished { get { return this.Formula.ChordType.IsDiminished; } }

		#endregion

		#region Construction
		[Obsolete("Used by EF.", true)]
		public Chord()
        {
            
        }

        #endregion
    }//class
}//ns
