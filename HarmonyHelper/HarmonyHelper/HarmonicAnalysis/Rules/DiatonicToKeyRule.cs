using Eric.Morrison.Harmony.Chords;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class DiatonicToKeyRule : HarmonicAnalysisRuleBase
	{
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();
			var keys = KeySignature.MajorKeys;
			var commonKeys = new List<KeySignature>();
			var distinctChords = chords.Distinct().ToList();
			var distinctNoteNames = distinctChords.SelectMany(x => x.NoteNames).Distinct().ToList();
			var message = string.Empty;
			if (key.AreDiatonic(distinctNoteNames))
			{
				var chordNames = string.Join(", ", chords.Distinct()
					.Select(x => $"{x.Name} ({GetChordFunction(x, key.NoteNames.IndexOf(x.Root))})"));
				message = $"{chordNames} are all diatonic to the key of {key}.";

				result.Add(new HarmonicAnalysisResult(this, true, message));
			}
			else
			{
				var nonDiatonic = key.GetNonDiatonic(distinctChords);
				var chordNames = string.Join(", ", nonDiatonic.Select(x => x.Name));
				message = $"{chordNames} are not diatonic to the specified key of {key}.";
				result.Add(new HarmonicAnalysisResult(this, false, message));
			}

			return result;
		}

		string GetChordFunction(ChordFormula chord, int index)
		{
			var result = string.Empty;
			if (chord.IsMinor)
			{
				var minor = "i,ii,iii,iv,v,vi,vii".Split(',').ToList();
				result = minor[index];
			}
			else
			{
				var major = "I,II,III,IV,V,VI,VII".Split(',').ToList();
				result = major[index];
			}
			return result;
		}
	}//class
}//ns
