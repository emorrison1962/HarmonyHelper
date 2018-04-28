using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class ChordFormulaExtensions
	{
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public ChordFormulaExtensions(ChordFormula formula)
		{// Diatonic extensions.
			var mode = new ModeFormula(formula.Key, ModeEnum.Ionian);
			var ninth = formula.Root + new IntervalContext(formula.Key, mode.Second);
			var eleventh = formula.Root + new IntervalContext(formula.Key, mode.Fourth);
			var thirteenth = formula.Root + new IntervalContext(formula.Key, mode.Sixth);
		}
	}

	public class ChordFormula : ClassBase, IEquatable<ChordFormula>, IComparable<ChordFormula>, INoteNameNormalizer
	{
		#region Properties

		public NoteName Root { get; set; }
		public NoteName Third { get; set; }
		public NoteName Fifth { get; set; }
		public NoteName Seventh { get; set; }
		public KeySignature Key { get; set; }
		public ChordType ChordType { get; set; }
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public string Name { get { return this.Root.ToString() + this.ChordType.ToStringEx(); } }


		#endregion

		#region Construction

		public ChordFormula(NoteName root, ChordType chordType, KeySignature key, bool addDiatonicExtension = false)
		{
			if (null == root)
				throw new NullReferenceException();
			if (null == key)
				throw new NullReferenceException();

			this.NoteNames.Add(this.Root = root);
			this.ChordType = chordType;
			this.Key = key;

			var interval = chordType.GetInterval(ChordFunctionEnum.Third);
			if (Interval.None != interval)
			{
				this.NoteNameNormalizationHint = ChordFunctionEnum.Third;
				var third = NoteName.Catalog.Get(root, interval, this);
				this.NoteNames.Add(this.Third = third);
			}

			interval = chordType.GetInterval(ChordFunctionEnum.Fifth);
			if (Interval.None != interval)
			{
				this.NoteNameNormalizationHint = ChordFunctionEnum.Fifth;
				var fifth = NoteName.Catalog.Get(root, interval, this);
				this.NoteNames.Add(this.Fifth = fifth);
			}

			interval = chordType.GetInterval(ChordFunctionEnum.Seventh);
			if (Interval.None != interval)
			{
				this.NoteNameNormalizationHint = ChordFunctionEnum.Seventh;
				var seventh = NoteName.Catalog.Get(root, interval, this);
				this.NoteNames.Add(this.Seventh = seventh);
			}

			if (addDiatonicExtension)
			{
				interval = chordType.GetInterval(ChordFunctionEnum.Ninth);
				if (Interval.None != interval)
				{
					this.NoteNameNormalizationHint = ChordFunctionEnum.Ninth;
					var nn = NoteName.Catalog.Get(root, interval, this);
					this.NoteNames.Add(nn);
				}
				interval = chordType.GetInterval(ChordFunctionEnum.Eleventh);
				if (Interval.None != interval)
				{
					this.NoteNameNormalizationHint = ChordFunctionEnum.Eleventh;
					var nn = NoteName.Catalog.Get(root, interval, this);
					this.NoteNames.Add(nn);
				}

				interval = chordType.GetInterval(ChordFunctionEnum.Thirteenth);
				if (Interval.None != interval)
				{
					this.NoteNameNormalizationHint = ChordFunctionEnum.Thirteenth;
					var nn = NoteName.Catalog.Get(root, interval, this);
					this.NoteNames.Add(nn);
				}
			}
			this.NoteNameNormalizationHint = ChordFunctionEnum.None;
		}

		ChordFunctionEnum NoteNameNormalizationHint { get; set; }
		public NoteName GetNormalized(NoteName nn)
		{
			var result = nn;
			if (this.Root.IsNatural)
			{

				int root = this.Root.Name[0];
				int wanted = 0;
				switch (this.NoteNameNormalizationHint)
				{
					case ChordFunctionEnum.None:
						wanted = nn.Name[0];
						break;
					case ChordFunctionEnum.Third:
						wanted = root + 2;
						break;
					case ChordFunctionEnum.Fifth:
						wanted = root + 4;
						break;
					case ChordFunctionEnum.Seventh:
						wanted = root + 6;
						break;
					case ChordFunctionEnum.Ninth:
						wanted = root + 1;
						break;
					case ChordFunctionEnum.Eleventh:
						wanted = root + 3;
						break;
					case ChordFunctionEnum.Thirteenth:
						wanted = root + 5;
						break;
				}
				if (wanted > 'G')
					wanted -= 7;

				char readable = (char)wanted;
				if (nn.Name[0] != wanted)
					result = NoteName.GetEnharmonicEquivalent(nn);
				if (ChordType.Diminished7 != this.ChordType && ChordType.Augmented != this.ChordType)
					Debug.Assert(result.Name[0] == wanted);

			}
			else if (this.Root.IsFlat && nn.IsSharp)
			{
				result = NoteName.GetEnharmonicEquivalent(nn);
			}
			else if (this.Root.IsSharp && nn.IsFlat)
			{
				result = NoteName.GetEnharmonicEquivalent(nn);
			}
		


			return result;
			//			else if (!nn.IsNatural)
			//			{
			//				if (null != accidentalHint && !accidentalHint.IsNatural)
			//				{
			//					if (nn.IsFlat != accidentalHint.IsFlat)
			//					{
			//						copy = NoteName.GetEnharmonicEquivalent(nn);
			//					}
			//				}
			//				else
			//				{
			//#warning If the key is CMajor and the nn is A# and accidentalHint is D, we're in the dark.
			//					//copy = NoteName.GetEnharmonicEquivalent(nn);
			//				}
			//			}

		}




		#endregion

		public bool Contains(NoteName note)
		{
			bool result = false;
			result = this.NoteNames.Contains(note);
			return result;
		}

		public ChordFunctionEnum GetChordFunction(NoteName note)
		{
			var result = ChordFunctionEnum.None;
			var success = false;
			if (this.Contains(note))
				success = true;
			if (success)
			{
				var interval = this.Root - note;

				if (interval == Interval.None)
				{
					result = ChordFunctionEnum.Root;
				}
				else if (this.Third.Value == note.Value)
				{
					result = ChordFunctionEnum.Third;
				}
				else if (this.Fifth.Value == note.Value)
				{
					result = ChordFunctionEnum.Fifth;
				}
				else if (this.Seventh.Value == note.Value)
				{
					result = ChordFunctionEnum.Seventh;
				}
			}
			return result;
		}

		public ChordToneFunctionEnum GetChordToneFunction(NoteName note)
		{
			var result = ChordToneFunctionEnum.None;
			var success = false;
			if (this.Contains(note))
				success = true;
			if (success)
			{
				var interval = this.Root - note;

				if (interval == Interval.None)
				{
					result = ChordToneFunctionEnum.Root;
				}
				else if (this.Third.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Major3rd;
					interval = this.ChordType.GetInterval(ChordFunctionEnum.Third);
					if (Interval.Minor3rd == interval)
						result = ChordToneFunctionEnum.Minor3rd;
				}
				else if (this.Fifth.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Perfect5th;
				}
				else if (this.Seventh.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Major7th;
					interval = this.ChordType.GetInterval(ChordFunctionEnum.Seventh);
					if (Interval.Minor7th == interval)
						result = ChordToneFunctionEnum.Minor7th;
				}

			}
			return result;
		}

		public ChordToneFunctionEnum GetRelationship(NoteName note)
		{
			var result = this.GetChordToneFunction(note);
			var success = false;
			if (ChordToneFunctionEnum.None != result)
				success = true;
			if (!success)
			{
				var interval = this.Root - note;

				if (interval == Interval.Minor2nd)
					result = ChordToneFunctionEnum.Flat9th;

				else if (interval == Interval.Major2nd)
					result = ChordToneFunctionEnum.Ninth;

				else if (interval == Interval.Minor3rd)
					result = ChordToneFunctionEnum.Sharp9th;

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
					if (this.IsDiminished())
					{
						result = ChordToneFunctionEnum.Diminished7th;
					}
				}

				else if (interval == Interval.Minor7th)
					result = ChordToneFunctionEnum.Minor7th;

				else if (interval == Interval.Major7th)
					result = ChordToneFunctionEnum.Major7th;

				else
					throw new NotSupportedException();
			}

			return result;
		}


		bool IsDiminished()
		{
			var result = true;
			var pairs = this.NoteNames.AsEnumerable().GetPairs();
			foreach (var pair in pairs)
			{
				var interval = pair[0] - pair[1];
				if (interval != Interval.Minor3rd
					&& interval != Interval.Diminished5th
					&& interval != Interval.Major6th)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		bool HasThird()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Third))
				result = true;
			return result;
		}
		bool HasFifth()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Fifth))
				result = true;
			return result;
		}
		bool HasSeventh()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Seventh))
				result = true;
			return result;
		}
		bool HasNinth()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Ninth))
				result = true;
			return result;
		}
		bool HasEleventh()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Eleventh))
				result = true;
			return result;
		}
		bool HasThirteenth()
		{
			var result = false;
			if (Interval.None == this.ChordType.GetInterval(ChordFunctionEnum.Thirteenth))
				result = true;
			return result;
		}


		public static ChordFormula operator +(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key + ctx.Interval;
			var txedRoot = chord.Root + ctx; // new IntervalContext(txedKey, ctx.Interval);

			var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, ctx.Key);// txedKey);
			return result;
		}

		public static ChordFormula operator -(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key - ctx.Interval;
			var txedRoot = chord.Root - ctx;// new IntervalContext(txedKey, ctx.Interval);

			var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, ctx.Key);// txedKey);
			return result;

			//var txedKey = chord.Key - interval;
			//var txedRoot = NoteNamesCollection.Get(txedKey, chord.Root, interval, DirectionEnum.Descending);
			//txedRoot = txedKey.GetNormalized(txedRoot);

			//var result = ChordFormulaFactory.Create(txedRoot, chord.ChordType, txedKey);
			//return result;
		}

		public override string ToString()
		{
			return $"{this.Name}: {this.Root.ToString()},{this.Third.ToString()},{this.Fifth.ToString()},{this.Seventh.ToString()}";
		}

		public bool Equals(ChordFormula other)
		{
			var result = false;
			if (this.Root.Equals(other.Root)
				&& this.Third == other.Third
				&& this.Fifth == other.Fifth
				&& this.Seventh == other.Seventh
				&& this.Key == other.Key)
				result = true;
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
				result = a.Third.CompareTo(b.Third);
			if (0 == result)
				result = a.Fifth.CompareTo(b.Fifth);
			if (0 == result)
				result = a.Seventh.CompareTo(b.Seventh);
			if (0 == result)
				result = a.Key.CompareTo(b.Key);
			return result;
		}
		public override int GetHashCode()
		{
			var result = this.Root.GetHashCode()
				^ this.Third.GetHashCode()
				^ this.Fifth.GetHashCode()
				^ this.Seventh.GetHashCode()
				^ this.Key.GetHashCode();

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



	}//class
}//ns
