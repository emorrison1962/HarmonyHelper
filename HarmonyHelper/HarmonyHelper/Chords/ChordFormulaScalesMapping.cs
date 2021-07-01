using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Eric.Morrison.Harmony.Scales;

namespace Eric.Morrison.Harmony.Chords
{
	public class ChordFormulaScalesMapping
	{
		public ChordFormula ChordFormula { get; set; }
		public List<ScaleFormulaBase> ScaleFormulas { get; set; } = new List<ScaleFormulaBase>();

		public ChordFormulaScalesMapping(ChordFormula formula)
		{
			if (null == formula)
				throw new ArgumentNullException();
			this.ChordFormula = formula;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(this.ChordFormula.Name);
			foreach (var scale in this.ScaleFormulas)
			{
				sb.AppendFormat("\t{0}", scale.ToString());
				sb.AppendLine();
			}

			return sb.ToString();
		}

		static public ChordFormulaScalesMapping GetScalesFor(ChordFormula chord)
		{
			var mapping = new ChordFormulaScalesMapping(chord);
			var catalog = new ScaleFormulaCatalog();
			var formulas = catalog.Formulas.OrderBy(x => x.Name).ToList();

			var matching = formulas.Where(x => x.Contains(chord));
			mapping.ScaleFormulas.AddRange(matching);

			var enharmonicEquivalents = mapping.ScaleFormulas.GetEnharmonicEquivalents();

			var result = new ChordFormulaScalesMapping(chord);
			foreach (var list in enharmonicEquivalents.Equivalents.Values)
			{
#warning **** 031618: Chord-centric or key-centric? ****
				//var scale = list.Where(x => x.Root == chord.Root).FirstOrDefault();
				var scale = list.Where(x => x.Root == chord.Key.NoteName).FirstOrDefault();
				//var scale = list.Where(x => x.Root == chord.Key.NoteName || x.Root == chord.Root).FirstOrDefault();
				if (null != scale)
				{
					result.ScaleFormulas.Add(scale);
				}
				else
				{
#warning "Maybe full unit tests are in order. They would probably end up saving you time."

					if (list.Count == 1)
					{
						result.ScaleFormulas.Add(list.First());
					}
					else
					{
						var types = list.Select(x => x.GetType()).Distinct();
						if (types.Count() > 1)
						{
							new Object();
						}

						var comparer = new NoteNameAphaEqualityComparer();
						var intersectCount = 0;
						ScaleFormulaBase selectedScale = null;
						foreach (var s in list)
						{
							var count = s.NoteNames.Intersect(chord.NoteNames, comparer).Count();
							if (count > intersectCount)
							{
								intersectCount = count;
								selectedScale = s;
							}
						}
						Debug.Assert(null != selectedScale);
						result.ScaleFormulas.Add(selectedScale);
					}
				}

#warning Here's whee the scale precednce is implemented. Order this.ScaleFormulas according to the scale precednce we want to set.
			}


			new object();

			return result;
		}

		static public List<ScaleFormulaBase> GetCommonScales(ChordFormula a, ChordFormula b)
		{
			var result = new List<ScaleFormulaBase>();

			var aMapping = GetScalesFor(a);
			var bMapping = GetScalesFor(b);

			result = aMapping.ScaleFormulas.Intersect(bMapping.ScaleFormulas).ToList();
			return result;
		}

		static public List<ChordFormulaScalesMapping> FilterByMostUsed(List<ChordFormulaScalesMapping> mappings)
		{
			mappings.ForEach(x => Debug.WriteLine(x.ToString()));

			var scaleFormulas = (
				from m in mappings
				from s in m.ScaleFormulas
				select s).ToList();


#warning Actually, we really want to order by scale precedence here.
#if false
			Precedence factors:
			Popularity, NotesPerScale(Complexity?), IsMode, KeyCentric, ChordCentric, "In", "Out", ScaleType
#endif

			var comparer = new ScaleFormulaBaseEqualityComparer();
			var scaleGroups = scaleFormulas
					.GroupBy(x => x, comparer)
					.OrderBy(x => x.Count())
					.ToList();
			var popularScales = scaleGroups.Distinct().Select(g => g.Key).ToList();
			var mostPopularScales = mappings.Select(m => m.ScaleFormulas.Where(s => popularScales.Contains(s)).First()).ToList();


			var pairings = mappings
				.Select(m => new
				{
					ChordFormula = m.ChordFormula,
					ScaleFormula = m.ScaleFormulas
					.Where(b => popularScales.Contains(b)).First()
				}).ToList();


			var result = new List<ChordFormulaScalesMapping>();
			foreach (var anon in pairings)
			{
				var mapping = new ChordFormulaScalesMapping(anon.ChordFormula);
				mapping.ScaleFormulas.Add(anon.ScaleFormula);
				result.Add(mapping);
			}

			return result;
		}

	}//class
}//ns
