using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Chords
{
	public class ChordTone : IComparable<ChordTone>
	{
		ChordFormula ChordFormula { get; set; }
		NoteName NoteName { get; set; }

		public ChordTone(ChordFormula chordFormula, NoteName noteName)
		{
			this.ChordFormula = chordFormula;
			this.NoteName = noteName;
		}
		public override string ToString()
		{
			var result = $"({this.ChordFormula.Name}){this.NoteName.ToString()}";
			return result;
		}

		public int CompareTo(ChordTone other)
		{
			return this.NoteName.CompareTo(other.NoteName);
		}
	}

}
