using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public class ChordCompareResult
	{
		ChordFormula FirstChordFormula { get; set; }
		ChordFormula OtherChordFormula { get; set; }
		public List<NoteName> CommonTones { get; set; } = new List<NoteName>();
		public List<ChordTone> DifferingTones { get; set; } = new List<ChordTone>();

		public ChordCompareResult(ChordFormula firstFormula, ChordFormula otherFormula)
		{
			this.FirstChordFormula = firstFormula;
			this.OtherChordFormula = otherFormula;
		}

		public override string ToString()
		{
			this.CommonTones.Sort();
			this.DifferingTones.Sort();
			var common = string.Join(", ", this.CommonTones.Select(x => x.ToString()));
			var diffs = string.Join(", ", this.DifferingTones.Select(x => x.ToString()));
			//const string FORMAT
			var result = $"Comparing: {this.FirstChordFormula.Name} to {this.OtherChordFormula.Name}, Common Tones: {common}, Differing Tones: {diffs}";
			return result;
		}
	}
}
