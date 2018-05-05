using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class BorrowedChordHarmonicAnalysisRule : HarmonicAnalysisRuleBase
	{
		public BorrowedChordHarmonicAnalysisRule()
		{
		}


		public override HarmonicAnalysisResult Analyze(List<Chord> chords)
		{
			throw new NotImplementedException();
			//var keys = KeySignature.MajorKeys;
			//if (a.Formula.ChordType.IsMajor)
			//{
			//	foreach (var key in KeySignature.MajorKeys)
			//	{
			//		var diatonic = key.AreDiatonic(a.NoteNames);
			//		if (diatonic)
			//			new object();
			//	}
			//	var akeys = KeySignature.MajorKeys.Where(x => x.AreDiatonic(a.NoteNames));
			//	new object();
			//}
			//if (b.Formula.ChordType.IsMajor)
			//{
			//	foreach (var key in KeySignature.MajorKeys)
			//	{
			//		var diatonic = key.AreDiatonic(b.NoteNames);
			//		if (diatonic)
			//			new object();
			//	}
			//	var bkeys = KeySignature.MajorKeys.Where(x => x.AreDiatonic(b.NoteNames));
			//	new object();
			//}
			//else
			//{
			//}
			//return null;
		}
	}
}