using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public abstract class ScaleFormulaBase : IComparable<ScaleFormulaBase>, IEquatable<ScaleFormulaBase>
	{
		public KeySignature Key { get; protected set; }
		public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();
		public NoteName Root { get; protected set; }

		public List<IntervalsEnum> Intervals { get; set; } = new List<IntervalsEnum>();
		virtual public string Name { get; protected set; }



		abstract protected void PopulateIntervals();
		abstract protected void Init();
		public ScaleFormulaBase(KeySignature key)
		{
			this.Key = key;

			var name = this.GetType().Name;
			name = name.Replace("Formula", string.Empty);
			name = string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

			this.Name = string.Format("{0} {1}",
				this.Key.NoteName,
				name);
		}

		protected void InitImpl()
		{
			this.PopulateIntervals();
			this.PopulateNoteNames();

			this.Root = this.NoteNames[0];
		}

		public bool Contains(ChordFormula formula)
		{
			var result = this.Contains(formula.NoteNames);
			return result;
		}

		bool Contains(IEnumerable<NoteName> chordTones)
		{
			var result = false;
			Debug.Assert(this.NoteNames.Count > 0);
			var comparer = new NoteNameValueEqualityComparer();

			foreach (var chordTone in chordTones)
			{
				if (this.NoteNames.Contains(chordTone, comparer))
				{
					result = true;
				}
				else
				{
					result = false;
					break;
				}
			}

			return result;
		}

		virtual protected void PopulateNoteNames()
		{
			var result = new List<NoteName>();
			result.Add(this.Key.NoteName);
			foreach (var interval in this.Intervals)
			{
				var nn = NoteNames.Get(this.Key, this.Key.NoteName, interval);
				result.Add(nn);
			}

			this.NoteNames = result;
		}

		public override string ToString()
		{
			var result = string.Empty;
			const string FORMAT = @"{0}: {1}";
			result = string.Format(FORMAT,
				//this.Key.NoteName.ToString(),
				this.Name,
				string.Join(",", this.NoteNames));
			return result;
		}

		public int CompareTo(ScaleFormulaBase other)
		{
			var result = this.Name.CompareTo(other.Name);
			if (0 == result)
			{
				result = -(this.NoteNames.Sum(x => x.Value).CompareTo(other.NoteNames.Sum(x => x.Value)));
			}
			return result;
		}

		public bool Equals(ScaleFormulaBase other)
		{
			var result = this.Name == other.Name;
			if (result)
				new object();
			if (!result)
			{
				result = this.NoteNames.Sum(x => x.Value) == other.NoteNames.Sum(x => x.Value);
				if (result)
					new object();
			}
			if (!result)
			{
				result = this.Key.ToString() == other.Key.ToString();
				if (result)
					new object();
			}
			return result;
		}

		public override int GetHashCode()
		{
			var result = 0;
			this.NoteNames.ForEach(x => result ^= x.GetHashCode());
			//Debug.WriteLine($"{this.ToString()}: HashCode={result}");
			return result;
		}

	}//class

	public class ScaleFormulaBaseEqualityComparer : IEqualityComparer<ScaleFormulaBase>
	{
		public bool Equals(ScaleFormulaBase x, ScaleFormulaBase y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(ScaleFormulaBase obj)
		{
			return obj.GetHashCode();
		}
	}

	public class ScaleFormulaBasePrecedenceComparer : IComparer<ScaleFormulaBase>
	{
		public int Compare(ScaleFormulaBase a, ScaleFormulaBase b)
		{
			var result = 0;
			result = -(a.NoteNames.Sum(x => x.Value)
				.CompareTo(b.NoteNames.Sum(x => x.Value)));
			return result;
		}
	}
}//ns
