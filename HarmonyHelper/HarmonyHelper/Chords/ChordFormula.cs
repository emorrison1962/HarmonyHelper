using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
	public class ChordFormula : ClassBase, IEquatable<ChordFormula>, IComparable<ChordFormula>, INoteNameNormalizer, INoteNameContainer, IHasRootNoteName
	{
		static public NullChordFormula Empty = NullChordFormula.Create();
		
		#region Properties

		public NoteName Root { get; private set; }
		public NoteName Bass { get; private set; }
		public KeySignature Key { get; private set; }
		public ChordType ChordType { get; private set; }
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public string Name { get { return this.Root.ToString() + this.ChordType.ToStringEx(); } }

		public bool IsMajor { get { return this.ChordType.IsMajor; } }
		public bool IsMinor { get { return this.ChordType.IsMinor; } }
		public bool IsHalfDiminished { get { return this.ChordType.IsHalfDiminished; } }
		public bool IsDiminished { get { return this.ChordType.IsDiminished; } }
		public bool IsDominant { get { return this.ChordType.IsDominant; } }


		#endregion

		#region Construction

		protected ChordFormula()
		{ 
		}
		public ChordFormula(NoteName root, ChordType chordType, KeySignature key)
		{
			if (null == root)
				throw new NullReferenceException();
			if (null == key)
				throw new NullReferenceException();

			this.NoteNames.Add(this.Root = root);
			this.ChordType = chordType;
			this.Key = key;

			foreach (var interval in this.ChordType.Intervals)
			{
				var nn = NoteName.Catalog.Get(root, interval, this);
				Debug.Assert(nn != null);
				this.NoteNames.Add(nn);
			}
		}

		public ChordFormula(ChordFormula src)
		{
			this.Root = src.Root;
			this.Bass = src.Bass;
			this.Key = src.Key;
			this.ChordType = src.ChordType;
			this.NoteNames = src.NoteNames;
		}

		public ChordFormula Copy()
		{
			var result = new ChordFormula(this);
			return result;
		}
		public static ChordFormula Copy(ChordFormula src)
		{
			var result = new ChordFormula(src);
			return result;
		}

		#endregion

		public bool Contains(NoteName note)
		{
			bool result = false;
			result = this.NoteNames.Contains(note);
			return result;
		}

		public void SetBassNote(NoteName bass)
		{
			this.Bass = bass;
		}


		public ChordToneFunctionEnum GetRelationship(NoteName note)
		{
			var result = ChordToneFunctionEnum.None;
			var interval = this.Root - note;

			if (interval == Interval.Unison)
				result = ChordToneFunctionEnum.Root;

			else if (interval == Interval.Minor2nd)
				result = ChordToneFunctionEnum.Flat9th;

			else if (interval == Interval.Major2nd)
				result = ChordToneFunctionEnum.Ninth;

			else if (interval == Interval.Augmented2nd)
				result = ChordToneFunctionEnum.Sharp9th;

			else if (interval == Interval.Minor3rd)
				result = ChordToneFunctionEnum.Minor3rd;

			else if (interval == Interval.Major3rd)
				result = ChordToneFunctionEnum.Major3rd;

			else if (interval == Interval.Diminished4th)
				result = ChordToneFunctionEnum.Flat11th;

			else if (interval == Interval.Perfect4th)
				result = ChordToneFunctionEnum.Eleventh;

			else if (interval == Interval.Augmented4th)
				result = ChordToneFunctionEnum.Augmented11th;

			else if (interval == Interval.Diminished5th)
				result = ChordToneFunctionEnum.Augmented11th;

			else if (interval == Interval.Perfect5th)
				result = ChordToneFunctionEnum.Perfect5th;

			else if (interval == Interval.Augmented5th)
				result = ChordToneFunctionEnum.Augmented5th;

			else if (interval == Interval.Minor6th)
				result = ChordToneFunctionEnum.Flat13th;

			else if (interval == Interval.Major6th)
			{
				result = ChordToneFunctionEnum.Thirteenth;
				if (this.IsDiminished)
				{
					result = ChordToneFunctionEnum.Diminished7th;
				}
			}

			else if (interval == Interval.Diminished7th)
				result = ChordToneFunctionEnum.Diminished7th;

			else if (interval == Interval.Minor7th)
				result = ChordToneFunctionEnum.Minor7th;

			else if (interval == Interval.Major7th)
				result = ChordToneFunctionEnum.Major7th;

			return result;
		}

		bool HasThird()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Third))
				result = true;
			return result;
		}
		bool HasFifth()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Fifth))
				result = true;
			return result;
		}
		bool HasSeventh()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Seventh))
				result = true;
			return result;
		}
		bool HasNinth()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Ninth))
				result = true;
			return result;
		}
		bool HasEleventh()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Eleventh))
				result = true;
			return result;
		}
		bool HasThirteenth()
		{
			var result = false;
			if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Thirteenth))
				result = true;
			return result;
		}


		public static ChordFormula operator +(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key + ctx.Interval;
			var txedRoot = chord.Root + ctx; // new IntervalContext(txedKey, ctx.Interval);

			var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, chord.Key);// txedKey);
			return result;
		}

		public static ChordFormula operator -(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key - ctx.Interval;
			var txedRoot = chord.Root - ctx;// new IntervalContext(txedKey, ctx.Interval);

			var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, chord.Key);// txedKey);
			return result;

			//var txedKey = chord.Key - interval;
			//var txedRoot = NoteNamesCollection.Get(txedKey, chord.Root, interval, DirectionEnum.Descending);
			//txedRoot = txedKey.GetNormalized(txedRoot);

			//var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, txedKey);
			//return result;
		}

		public static ChordFormula operator +(ChordFormula chord, Interval interval)
		{
			var txedKey = chord.Key + interval;
			var txedRoot = chord.Root + new IntervalContext(txedKey, interval);

			var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, chord.Key);// txedKey);
			return result;
		}

		public static ChordFormula operator -(ChordFormula chord, Interval interval)
		{
			var result = TransposeDown(chord, interval);

			//var txedKey = chord.Key - interval;
			//var txedRoot = chord.Root - new IntervalContext(txedKey, interval);
			//var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, chord.Key);

			return result;
		}

#if true
		public static ChordFormula TransposeUp(ChordFormula src, Interval interval, bool respectKey = false)
		{
			KeySignature txedKey = null;
			if (!respectKey)
			{
				//var key = src.Key.GetEnharmonicEquivalent();
				//var result = ChordFormulaFactory.Create(txedRoot, src.ChordType, key);

				foreach (var nn in src.NoteNames)
				{
					var success = NoteName.TryTransposeUp(nn, interval, out var txposed, out var ee);
					Debug.Assert(success);
				}
			}
			else
			{
				src += interval;
				txedKey = src.Key + interval;
			}

			var txedRoot = src.Root + new IntervalContext(txedKey, interval);
			var result = ChordFormulaFactory.Create(txedRoot, src.ChordType, src.Key);

			return result;

		}

		public static ChordFormula TransposeDown(ChordFormula src, Interval interval, bool respectKey = false)
		{

			var inversion = interval.GetInversion();
			var result = TransposeUp(src, inversion, respectKey);
			return result;
		}
#endif

		public override string ToString()
		{
			var bass = string.Empty;
			if (null != this.Bass)
				bass = $"/{this.Bass}";
			return $"{this.Name}{bass}: {string.Join(",", this.NoteNames)}";
		}

		public bool Equals(ChordFormula other)
		{
			var result = false;
			if (0 == this.NoteNames.Except(other.NoteNames).Count())
			{
				if (0 == other.NoteNames.Except(this.NoteNames).Count())
				{
					//if (this.Key == other.Key)
					result = true;
				}
			}
			return result;
		}
		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is ChordFormula)
				result = this.Equals(obj as ChordFormula);
			return result;
		}

		public static bool operator <(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(ChordFormula a, ChordFormula b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}

		public int CompareTo(ChordFormula other)
		{
			var result = Compare(this, other);
			return result;
		}
		public static int Compare(ChordFormula a, ChordFormula b)
		{
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			var result = a.Root.CompareTo(b.Root);

			if (0 == result)
			{
				result = a.NoteNames.Count.CompareTo(b.NoteNames.Count);
			}
			if (0 == result)
			{
				for (int i = 0 ; i < a.NoteNames.Count ; ++i)
				{
					result = a.NoteNames[i].CompareTo(b.NoteNames[i]);
					if (0 != result)
						break;
				}
			}

			if (0 == result)
				result = a.Key.CompareTo(b.Key);
			return result;
		}
		public override int GetHashCode()
		{
			var result = this.Root.GetHashCode();
			this.NoteNames.ForEach(x => result ^= x.GetHashCode());
			result ^= this.Key.GetHashCode();

			return result;
		}

		public ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare)
		{
			var result = new ChordCompareResult(this, other);

			var tones = this.NoteNames.Select(x => new ChordTone(this, x));
			var otherTones = other.NoteNames.Select(x => new ChordTone(other, x));

			var common = other.NoteNames.Intersect(this.NoteNames).ToList();


			result.CommonTones = common;
			var otherExcept = other.NoteNames.Except(this.NoteNames).Select(x => new ChordTone(other, x)).ToList();
			var thisExcept = this.NoteNames.Except(other.NoteNames).Select(x => new ChordTone(this, x)).ToList();

			var diff = new List<ChordTone>(otherExcept);
			diff.AddRange(thisExcept);

			result.DifferingTones = diff;

			return result;
		}

		public NoteName GetNormalized(NoteName nn, Interval baseInterval)
		{
			var result = nn;

			ChordToneInterval interval = null;
			if (baseInterval is ChordToneInterval)
				interval = baseInterval as ChordToneInterval;
			else
				interval = baseInterval.ToChordToneInterval();

			int rootAscii = this.Root.Name[0];
			int wantedAscii = 0;

			switch (interval.ChordToneFunction)
			{
				case ChordToneFunctionEnum.None:
				case ChordToneFunctionEnum.Root:
					wantedAscii = nn.Name[0];
					break;
				case ChordToneFunctionEnum.Sus2:
				case ChordToneFunctionEnum.Flat9th:
				case ChordToneFunctionEnum.Ninth:
				case ChordToneFunctionEnum.Sharp9th:
					wantedAscii = rootAscii + 1;
					break;
				case ChordToneFunctionEnum.Minor3rd:
				case ChordToneFunctionEnum.Major3rd:
					wantedAscii = rootAscii + 2;
					break;
				case ChordToneFunctionEnum.Sus4:
				case ChordToneFunctionEnum.Flat11th:
				case ChordToneFunctionEnum.Eleventh:
				case ChordToneFunctionEnum.Augmented11th:
					wantedAscii = rootAscii + 3;
					break;
				case ChordToneFunctionEnum.Diminished5th:
				case ChordToneFunctionEnum.Perfect5th:
				case ChordToneFunctionEnum.Augmented5th:
					wantedAscii = rootAscii + 4;
					break;
				case ChordToneFunctionEnum.Major6th:
				case ChordToneFunctionEnum.Flat13th:
				case ChordToneFunctionEnum.Thirteenth:
					wantedAscii = rootAscii + 5;
					break;
				case ChordToneFunctionEnum.Diminished7th:
				case ChordToneFunctionEnum.Minor7th:
				case ChordToneFunctionEnum.Major7th:
					wantedAscii = rootAscii + 6;
					break;
			}

			if (wantedAscii > 'G')
				wantedAscii -= 7;
#if DEBUG
			char readableWanted = (char)wantedAscii;
			char readableRoot = (char)rootAscii;
#endif
			if (nn.Name[0] != wantedAscii)
			{
				result = NoteName.GetEnharmonicEquivalents(nn)
					.Where(x => x.Name[0] == wantedAscii)
					.FirstOrDefault();
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

	public class NullChordFormula : ChordFormula
	{
		private NullChordFormula(NoteName root, ChordType chordType, KeySignature key) : base(root, chordType, key)
		{
		}

		private NullChordFormula() : base()
		{ 
		}

		static public NullChordFormula Create() 
		{
			return new NullChordFormula();
		}
	}
}//ns
