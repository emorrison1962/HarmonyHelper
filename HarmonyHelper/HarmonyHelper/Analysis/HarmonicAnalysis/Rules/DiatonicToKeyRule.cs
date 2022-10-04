using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
	public class DiatonicToKeyRule : HarmonicAnalysisRuleBase
	{
		public override string Name { get { return "Diatonic to Key"; } }
		public override string Description { get { return @"Chords built from only the seven notes in each key are called diatonic chords."; } }
		public override List<HarmonicAnalysisResult> Analyze(List<ChordFormula> chords, KeySignature key)
		{
			var result = new List<HarmonicAnalysisResult>();
			var keys = KeySignature.MajorKeys;
			var commonKeys = new List<KeySignature>();
			var distinctChords = chords.Distinct().ToList();
			var distinctNoteNames = distinctChords.SelectMany(x => x.NoteNames)
				.Distinct()
				.ToList();
			
			if (key.AreDiatonic(distinctNoteNames))
			{
				var chordNames = string.Join(", ", chords.Distinct()
					.Select(x => $"{x.Name} ({GetChordFunction(x, key.NoteNames.IndexOf(x.Root))})"));
				var diatonicMessage = $"{chordNames} are all diatonic to the key of {key}.";

				result.Add(new HarmonicAnalysisResult(this, true, diatonicMessage, chords.Distinct().ToList()));
			}
			else
			{
				var nonDiatonic = key.GetNonDiatonic(distinctChords);
				var diatonic = distinctChords.Except(nonDiatonic);

				var diatonicChordNames = string.Join(", ", diatonic.Select(x => x.Name));
				var diatonicChords = string.Join(", ",
					diatonic.Distinct()
					.Select(x => $"{x.Name} ({GetChordFunction(x, key.NoteNames.IndexOf(x.Root))})"));
				var diatonicMessage = $"{diatonicChords} are diatonic to {key}.";
				result.Add(new HarmonicAnalysisResult(this, true, diatonicMessage, diatonic.Distinct().ToList()));

				var nonDiatonicChordNames = string.Join(", ", nonDiatonic.Select(x => x.Name));
				var nonDiatonicMessage = $"{nonDiatonicChordNames}  are not diatonic to {key}.";
				result.Add(new HarmonicAnalysisResult(this, true, nonDiatonicMessage, nonDiatonic.Distinct().ToList()));
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
