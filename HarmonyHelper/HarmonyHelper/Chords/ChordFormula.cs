using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class ChordFormula : ClassBase, IEquatable<ChordFormula>, IComparable<ChordFormula>
	{
		#region Properties

		public NoteName Root { get; set; }
		public NoteName Third { get; set; }
		public NoteName Fifth { get; set; }
		public NoteName Seventh { get; set; }
		public KeySignature Key { get; set; }
		public ChordTypesEnum ChordType { get; set; }
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public string Name { get { return this.Root.ToString() + this.ChordType.ToStringEx(); } }


		#endregion

		#region Construction

		public ChordFormula(NoteName root, ChordTypesEnum chordType, KeySignature key)
		{
			if (null == root)
				throw new NullReferenceException();
			if (null == key)
				throw new NullReferenceException();

			this.NoteNames.Add(this.Root = root);
			this.ChordType = chordType;
			this.Key = key;

			var interval = chordType.GetThirdInterval();
			var third = NoteName.Catalog.Get(key, root, interval);
			this.NoteNames.Add(this.Third = third);


			interval = chordType.GetFifthInterval();
			var fifth = NoteName.Catalog.Get(key, root, interval);
			this.NoteNames.Add(this.Fifth = fifth);

			interval = chordType.GetSeventhInterval();
			var seventh = NoteName.Catalog.Get(key, root, interval);
			this.NoteNames.Add(this.Seventh = seventh);

		}


		#endregion

		public bool Contains(NoteName note)
		{
			bool result = false;
			result = this.NoteNames.Contains(note);
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

				if (interval == IntervalsEnum.None)
				{
					result = ChordToneFunctionEnum.Root;
				}
				else if (this.Third.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Third;
				}
				else if (this.Fifth.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Fifth;
				}
				else if (this.Seventh.Value == note.Value)
				{
					result = ChordToneFunctionEnum.Seventh;
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
				if (interval >= IntervalsEnum.Minor2nd && interval <= IntervalsEnum.Major2nd)
				{
					result = ChordToneFunctionEnum.Ninth;
				}
				else if (interval >= IntervalsEnum.Minor3rd && interval <= IntervalsEnum.Major3rd)
				{// 3rd
					if (interval == IntervalsEnum.Minor3rd)
					{
						if (this.Contains(note + new IntervalContext(this.Key, IntervalsEnum.Minor2nd)))
						{// Okay. We have a major 3rd. This must be the #9.
							result = ChordToneFunctionEnum.Ninth;
						}
						else
						{
							result = ChordToneFunctionEnum.Third;
						}
					}
					else
					{
						result = ChordToneFunctionEnum.Third;
					}
				}
				else if (interval >= IntervalsEnum.Diminished4th && interval <= IntervalsEnum.Perfect4th)
				{// 11th
#warning Suspended chords?
					if (this.Contains(note - new IntervalContext(this.Key, IntervalsEnum.Minor2nd)))
					{// Okay. We have a minor 3rd. This must be the b11.
						result = ChordToneFunctionEnum.Eleventh;
					}
				}
				else if (interval >= IntervalsEnum.Diminished5th && interval <= IntervalsEnum.Augmented5th)
				{// 5th
					result = ChordToneFunctionEnum.Fifth;
					if (interval == IntervalsEnum.Diminished5th)
					{
						if (IntervalsEnum.Diminished5th == (IntervalsEnum)((int)this.ChordType & (int)IntervalsEnum.Diminished5th))
						{
							result = ChordToneFunctionEnum.Fifth;
						}
					}
				}
				else if (interval >= IntervalsEnum.Minor6th && interval <= IntervalsEnum.Major6th)
				{// 13th
					if (this.Contains(note - new IntervalContext(this.Key, IntervalsEnum.Minor2nd)))
					{// Okay. We have a perfect 5th. This must be the b13.
						result = ChordToneFunctionEnum.Thirteenth;
					}
				}
				else if (interval >= IntervalsEnum.Major6th && interval <= IntervalsEnum.Major7th)
				{// 7th
					if (interval == IntervalsEnum.Major6th)
					{
						if (this.IsDiminished())
						{
							result = ChordToneFunctionEnum.Seventh;
						}
					}
					else
					{
						result = ChordToneFunctionEnum.Seventh;
					}
				}
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
				if (interval != IntervalsEnum.Minor3rd
					&& interval != IntervalsEnum.Diminished5th
					&& interval != IntervalsEnum.Major6th)
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
			if (IntervalsEnum.None == this.ChordType.GetThirdInterval())
				result = true;
			return result;
		}
		bool HasFifth()
		{
			var result = false;
			if (IntervalsEnum.None == this.ChordType.GetFifthInterval())
				result = true;
			return result;
		}
		bool HasSeventh()
		{
			var result = false;
			if (IntervalsEnum.None == this.ChordType.GetSeventhInterval())
				result = true;
			return result;
		}
		bool HasNinth()
		{
			var result = false;
			if (IntervalsEnum.None == this.ChordType.GetNinthInterval())
				result = true;
			return result;
		}
		bool HasEleventh()
		{
			var result = false;
			if (IntervalsEnum.None == this.ChordType.GetEleventhInterval())
				result = true;
			return result;
		}
		bool HasThirteenth()
		{
			var result = false;
			if (IntervalsEnum.None == this.ChordType.GetThirteenthInterval())
				result = true;
			return result;
		}


		public static ChordFormula operator +(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key + ctx.Interval;
			var txedRoot = chord.Root + ctx; // new IntervalContext(txedKey, ctx.Interval);

			var result = new ChordFormula(txedRoot, chord.ChordType, ctx.Key);// txedKey);
			return result;
		}

		public static ChordFormula operator -(ChordFormula chord, IntervalContext ctx)
		{
			// var txedKey = chord.Key - ctx.Interval;
			var txedRoot = chord.Root - ctx;// new IntervalContext(txedKey, ctx.Interval);

			var result = new ChordFormula(txedRoot, chord.ChordType, ctx.Key);// txedKey);
			return result;

			//var txedKey = chord.Key - interval;
			//var txedRoot = NoteNamesCollection.Get(txedKey, chord.Root, interval, DirectionEnum.Descending);
			//txedRoot = txedKey.GetNormalized(txedRoot);

			//var result = new ChordFormula(txedRoot, chord.ChordType, txedKey);
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
			if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
				return 0;
			else if (object.ReferenceEquals(null, a))
				return -1;
			else if (object.ReferenceEquals(null, b))
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
