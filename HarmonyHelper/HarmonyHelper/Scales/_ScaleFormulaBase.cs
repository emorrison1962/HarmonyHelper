using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	public abstract class ScaleFormulaBase : INoteNameNormalizer, IComparable<ScaleFormulaBase>, IEquatable<ScaleFormulaBase>, INoteNameContainer
	{
		static public NullScaleFormula Empty = NullScaleFormula.Create();
		public KeySignature Key { get; protected set; }
		public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();
		public NoteName Root { get; protected set; }

		public List<ScaleToneInterval> Intervals { get; set; } = new List<ScaleToneInterval>();
		virtual public string Name { get; protected set; }



		abstract protected void PopulateIntervals();
		abstract protected void Init();
		public ScaleFormulaBase(KeySignature key)
		{
			this.Key = key;
			//this.Root = key.NoteName;
			this.Root = this.Key.NoteName;
			//this.Root = NoteNames.Get(this.Key.NoteName, Interval.None, key);

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

			//this.Root = this.NoteNames[0];
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
			this.Root = this.Key.NoteName;

			result.Add(this.Key.NoteName);
			foreach (var interval in this.Intervals)
			{
				var nn = NoteName.TransposeUp(this.Root, interval);
				nn = this.GetNormalized(nn, interval);
				//var nn = NoteNames.Get(this.Key.NoteName, interval, this);
				Debug.Assert(nn != this.Key.NoteName);
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

		public NoteName GetNormalized(NoteName nn, Interval baseInterval)
		{
			if (!(baseInterval is ScaleToneInterval))
				throw new ArgumentException($"Invalid Argument ({baseInterval})");

			var result = nn;
			if (baseInterval is ScaleToneInterval)
			{
				var interval = baseInterval as ScaleToneInterval;
				int rootAscii = this.Root.Name[0];
#if DEBUG
				var readableRoot = (char)this.Root.Name[0];
#endif
				int wantedAscii = 0;

				switch (interval.ScaleToneFunction)
				{
					case ScaleToneFunctionEnum.None:
					case ScaleToneFunctionEnum.Root:
					case ScaleToneFunctionEnum.AugmentedUnison:
					case ScaleToneFunctionEnum.DiminishedOctave:
						wantedAscii = rootAscii;
						break;
					case ScaleToneFunctionEnum.Minor2nd:
					case ScaleToneFunctionEnum.Major2nd:
					case ScaleToneFunctionEnum.Augmented2nd:
						wantedAscii = rootAscii + 1;
						break;
					case ScaleToneFunctionEnum.Minor3rd:
					case ScaleToneFunctionEnum.Major3rd:
						wantedAscii = rootAscii + 2;
						break;
					case ScaleToneFunctionEnum.Diminished4th:
					case ScaleToneFunctionEnum.Perfect4th:
					case ScaleToneFunctionEnum.Augmented4th:
						wantedAscii = rootAscii + 3;
						break;
					case ScaleToneFunctionEnum.Diminished5th:
					case ScaleToneFunctionEnum.Perfect5th:
					case ScaleToneFunctionEnum.Augmented5th:
						wantedAscii = rootAscii + 4;
						break;
					case ScaleToneFunctionEnum.Major6th:
					case ScaleToneFunctionEnum.Minor6th:
						wantedAscii = rootAscii + 5;
						break;
					case ScaleToneFunctionEnum.Diminished7th:
					case ScaleToneFunctionEnum.Minor7th:
					case ScaleToneFunctionEnum.Major7th:
						wantedAscii = rootAscii + 6;
						break;
				}

				if (wantedAscii > 'G')
					wantedAscii -= 7;
#if DEBUG
				char readableWanted = (char)wantedAscii;
#endif
				if (nn.Name[0] != wantedAscii)
				{
					foreach (var ee in NoteName.GetEnharmonicEquivalents(nn))
					{
						if (ee.Name[0] == wantedAscii)
						{
							result = ee;
							break;
						}
					}
				}
			}

			return result;
		}
		public void Normalize(ref List<NoteName> noteNames)
		{
			var result = new List<NoteName>();
			foreach (var nn in noteNames)
			{
				result.Add(this.GetNormalized(nn, Interval.Unison));
			}
			noteNames = result;
		}


	}//class
	public class NullScaleFormula : ScaleFormulaBase
	{
		public NullScaleFormula(KeySignature key) : base(KeySignature.CMajor)
		{
		}

		static public NullScaleFormula Create()
		{
			return new NullScaleFormula(null);
		}

		new public KeySignature Key { get; protected set; }
		new public List<NoteName> NoteNames { get; protected set; } = new List<NoteName>();
		new public NoteName Root { get; protected set; }

		new public List<ScaleToneInterval> Intervals { get; set; } = new List<ScaleToneInterval>();
		override public string Name { get; protected set; }

		protected override void Init()
		{
		}

		protected override void PopulateIntervals()
		{
		}
	}

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
