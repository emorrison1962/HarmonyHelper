using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class EnharmonicEquivalent
	{
		public NoteName Key { get; private set; }
		public List<NoteName> Others { get; private set; }
		EnharmonicEquivalent(NoteName key, IEnumerable<NoteName> others)
		{
			this.Key = key;
			this.Others = others.OrderBy(x => x, new AccidentalCountComparer()).ToList();

			if (!this.Others.All(x => x.Value == this.Key.Value))
				throw new ArgumentException();
		}

		public class AccidentalCountComparer : IComparer<NoteName>
		{
			public int Compare(NoteName x, NoteName y)
			{
				Func<NoteName, int> accidentalCount = (nn) =>  
					nn.Name.Contains(Constants.DOUBLE_FLAT) 
					|| nn.Name.Contains(Constants.DOUBLE_SHARP) ? 2 : 
						nn.Name.Contains(Constants.FLAT)
						|| nn.Name.Contains(Constants.SHARP) ? 1 : 0;

				return accidentalCount(x).CompareTo(accidentalCount(y));

			}
		}


		static public List<EnharmonicEquivalent> Create(params NoteName[] noteNames)
		{
			var result = new List<EnharmonicEquivalent>();
			var comparer = new NoteNameExplicitEqualityComparer();
			foreach (var key in noteNames)
			{
				var others = noteNames.Where(x => !comparer.Equals(key, x));
				result.Add(new EnharmonicEquivalent(key, others));
			}
			return result;
		}

		public override string ToString()
		{
			return $"{this.Key}:{string.Join(", ", this.Others)}";
		}
	}//class
}//ns
