using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	public class VoiceLeadingAnalyzer
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Construction
		public VoiceLeadingAnalyzer()
		{

		}

		public VoiceLeadingAnalysisResult Analyze(Chords.ChordFormula formula01, Chords.ChordFormula formula02)
		{
			var f1 = formula01.Copy(); // Don't modify the input.
			var f2 = formula02.Copy(); // Don't modify the input.
			var vlrs = new List<VoiceLeadingResult>();


			var f1NoteNames = f1.NoteNames;
			var f2NoteNames = f2.NoteNames;
			//f1NoteNames.ForEach(x => Debug.WriteLine(x));
			//f2NoteNames.ForEach(x => Debug.WriteLine(x));

			#region Common tones.
			var commonNoteNames = this.GetCommonNotes(f1, f2);

			commonNoteNames.ForEach(x =>
				vlrs.Add(new VoiceLeadingResult(x, x, Interval.Unison)));

			commonNoteNames.ForEach(x => f1.NoteNames.Remove(x));
			commonNoteNames.ForEach(x => f2.NoteNames.Remove(x));

			#endregion

			#region Minimum amount of movement.
			var resolutions =
		(from nnFrom in f1.NoteNames
		 from nnTo in f2.NoteNames
		 select new
		 {
			 From = nnFrom,
			 To = nnTo,
			 Interval = (nnFrom - nnTo).Abs()
		 }).OrderBy(x => x.Interval).ToList();

			foreach (var nnFrom in f1.NoteNames)
			{
				var resolution = resolutions.First(x => x.From == nnFrom);
				vlrs.Add(new VoiceLeadingResult(resolution.From,
					resolution.To,
					resolution.Interval));
			}

			#endregion

			var result = new VoiceLeadingAnalysisResult();
			vlrs.ForEach(x => result.Add(x));

			return result;
		}

		List<NoteName> GetCommonNotes(Chords.ChordFormula formula01, Chords.ChordFormula formula02)
		{
			var result = formula01.NoteNames
				.Where(x => formula02.NoteNames.Contains(x))
				.ToList();
			return result;
		}
		#endregion

		#region Methods
		#endregion

	}//class
}//ns
