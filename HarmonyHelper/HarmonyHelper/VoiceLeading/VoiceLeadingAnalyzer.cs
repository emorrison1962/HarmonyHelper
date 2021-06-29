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


//		public void Analyze(Chords.ChordFormula formula01, Chords.ChordFormula formula02)
//		{
//			var nn01 = formula01.NoteNames;
//			foreach (var nn in nn01)
//				Debug.WriteLine(nn);
//			var nn02 = formula02.NoteNames;
//			foreach (var nn in nn02)
//				Debug.WriteLine(nn);
//			var common = this.GetCommonNotes(formula01, formula02);

//			var f01Filtered = formula01.NoteNames.Except(common).ToList();
//			var f02Filtered = formula02.NoteNames.Except(common).ToList();


//#if false
//var results = Csts.Where(d => 
//						 d.EffDt == Csts.Where(x => 
//											   x.ItmCd == d.ItmCd && 
//											   x.EffDt <= DateTime.Now)
//										.Max(x => x.EffDt))
//				  .OrderBy(d => d.ItmCd)
//				  .Select(d => new { d.ItmCd, d.BuyQty, d.Content });
//#endif
//			var seq =
//				(from n01 in formula01.NoteNames
//				 from n02 in formula02.NoteNames
//					 //where n01 - n02 == Interval.Minor2nd
//				 select new
//				 {
//					 n01 = n01,
//					 n02 = n02,
//					 Interval = (n01 - n02).Abs()
//				 })
//				 .OrderBy(x => x.Interval)
//				 .ToList();

//#if false
//public static TSource Aggregate<TSource>(
//	this IEnumerable<TSource> source, 
//	Func<TSource, TSource, TSource> func);
//#endif
//			TSource Aggregate<TSource>(
//				this IEnumerable<TSource> source,
//				Func<(NoteName, NoteName, Interval),
//				(NoteName, NoteName, Interval),
//				(NoteName, NoteName, Interval)> func)

//			Func<(NoteName, NoteName, Interval),
//				(NoteName, NoteName, Interval),
//				(NoteName, NoteName, Interval)> aggregator = (a, b, c) => { };

//			seq.Aggregate(

//			var w = seq.Where(x =>
//				formula01.NoteNames.Contains(x.n01)
//				&& formula02.NoteNames.Contains(x.n02)).Aggregate(x => ;


//			var q = seq

//				.Where(x => formula01.NoteNames.Contains(x.n01)
//					&& formula02.NoteNames.Contains(x.n02))
//				.ToList();

//			new object();

//		}

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
