using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class ScaleEnharmonicEquivalents
	{
		public Dictionary<int, List<ScaleFormulaBase>> Equivalents { get; set; } = new Dictionary<int, List<ScaleFormulaBase>>();
		public void Add(ScaleFormulaBase scale)
		{
			var key = scale.CreateKey();
			if (this.Equivalents.Keys.Contains(key))
			{
				var list = this.Equivalents[key];
				list.Add((dynamic)scale);
			}
			else
			{
				var list = new List<ScaleFormulaBase>();
				list.Add(scale);
				this.Equivalents.Add(key, list);
			}
		}
	}
	public static partial class Extensions
	{
		static public ScaleEnharmonicEquivalents GetEnharmonicEquivalents(this List<ScaleFormulaBase> src)
		{
			var result = new ScaleEnharmonicEquivalents();
			foreach (var scale in src)
			{
				result.Add(scale);
			}
			return result;
		}

		static public int CreateKey(this ScaleFormulaBase src)
		{
			var result = src.NoteNames.Sum(x => x.Value);
			return result;
		}
	}
}
