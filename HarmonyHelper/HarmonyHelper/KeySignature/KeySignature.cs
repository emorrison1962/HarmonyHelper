using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// reference: https://dictionary.onmusic.org/appendix/topics/key-signatures

namespace Eric.Morrison.Harmony
{
	public partial class KeySignature : ClassBase, IEquatable<KeySignature>, IComparable<KeySignature>
	{
		public NoteName NoteName { get; private set; }
		public List<NoteName> Notes { get; private set; }
		public bool UsesSharps { get; private set; }
		public bool UsesFlats { get; private set; }
		public bool IsMajor { get; private set; }
		public bool IsMinor { get; private set; }
		public int AccidentalCount { get; private set; }


		private KeySignature(NoteName key, IEnumerable<NoteName> notes, bool? usesSharps, bool isMajor, bool isMinor)
		{
			this.NoteName = key;
			this.Notes = new List<NoteName>(notes);
			this.AccidentalCount = this.Notes.Where(x => x.Name.EndsWith(Constants.SHARP) 
				|| x.Name.EndsWith(Constants.FLAT)).Count();

			if (usesSharps.HasValue)
			{
				this.UsesSharps = usesSharps.Value;
				this.UsesFlats = !usesSharps.Value;
			}
			if (0 == this.Notes.Count)
				this.UsesFlats = false;

			this.IsMajor = isMajor;
			this.IsMinor = isMinor;
			if (this.IsMajor || this.IsMinor)
			{
				Catalog.Add(this);
			}
			if (this.IsMajor)
			{
				MajorKeys.Add(this);
			}
			else if (this.IsMinor)
			{
				MinorKeys.Add(this);
			}

		}
		class HasEnharmonicComparer : IEqualityComparer<NoteName>
		{
			public bool Equals(NoteName x, NoteName y)
			{
				bool result = false;
				if (x.Value == y.Value
					&& x.Name != y.Name)
					result = true;
				return result;

			}

			public int GetHashCode(NoteName obj)
			{
				return obj.GetHashCode();
			}
		}

		class IsInKeyComparer : IEqualityComparer<NoteName>
		{
			public bool Equals(NoteName x, NoteName y)
			{
				bool result = false;
				if (x.Value == y.Value
					&& x.Name == y.Name)
					result = true;
				return result;

			}

			public int GetHashCode(NoteName obj)
			{
				return obj.GetHashCode();
			}
		}


		public bool Affects(NoteName note)
		{
			var result = false;
			if (this.Notes.Contains(note, new HasEnharmonicComparer()))
				result = true;
			return result;
		}
		public bool Contains(NoteName note)
		{
			var result = false;
			if (this.Notes.Contains(note, new IsInKeyComparer()))
				result = true;
			return result;
		}

		public NoteName GetNormalized(NoteName nn)
		{
			var copy = nn.Copy();
			if (!this.Contains(copy))
			{
				if (this.Affects(copy))
				{
					copy = NoteName.GetEnharmonicEquivalent(copy);
				}
				else if (!nn.IsNatural)
				{
					copy = NoteName.GetEnharmonicEquivalent(nn);
				}
			}
			return copy;
		}

		public override string ToString()
		{
			return this.NoteName.ToString();
		}

		public bool Equals(KeySignature other)
		{
			var result = false;
			if (other.NoteName == this.NoteName)
				result = true;
			return result;
		}

		public override int GetHashCode()
		{
			var result = this.NoteName.GetHashCode()
				^ this.Notes.GetHashCode()
				^ this.UsesSharps.GetHashCode()
				^ this.UsesFlats.GetHashCode();
			return result;
		}
		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is KeySignature)
				result = this.Equals(obj as KeySignature);
			return result;
		}

		public static bool operator ==(KeySignature a, KeySignature b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(KeySignature a, KeySignature b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}

		public int CompareTo(KeySignature other)
		{
			var result = Compare(this, other);
			return result;
		}
		public static int Compare(KeySignature a, KeySignature b)
		{
			if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
				return 0;
			else if (object.ReferenceEquals(null, a))
				return -1;
			else if (object.ReferenceEquals(null, b))
				return 1;

			var result = a.NoteName.CompareTo(b.NoteName);
			if (0 == result)
			{
				result = a.Notes.GetHashCode().CompareTo(b.Notes.GetHashCode());
			}
			if (0 == result)
				result = a.UsesSharps.CompareTo(b.UsesSharps);
			if (0 == result)
				result = a.UsesFlats.CompareTo(b.UsesFlats);
			return result;
		}

		public static KeySignature operator +(KeySignature key, IntervalsEnum interval)
		{
			var result = KeySignature.GetTransposed(key, interval);
			return result;
		}

		public static KeySignature operator -(KeySignature key, IntervalsEnum interval)
		{
			var inversion = interval.GetInversion();
			var result = KeySignature.GetTransposed(key, inversion);
			return result;
		}

		public static KeySignature GetTransposed(KeySignature key, IntervalsEnum interval)
		{
			KeySignature result = null;
			var txposedNote = NoteName.TransposeUp(key.NoteName, interval);
			IEnumerable<KeySignature> catalog = null;

			if (key.IsMajor)
			{
				catalog = KeySignature.MajorKeys;
			}
			else if (key.IsMinor)
			{
				catalog = KeySignature.MinorKeys;
			}
			else
			{
				throw new Exception($"{MethodBase.GetCurrentMethod().Name}");
			}

			var seq = KeySignature.MajorKeys.Where(x => x.NoteName.Value == txposedNote.Value);
			if (null == seq)
			{
				throw new Exception($"{MethodBase.GetCurrentMethod().Name}: Major key with NoteName{{{txposedNote.Name}}} does not exist");
			}
			if (1 == seq.Count())
			{
				result = seq.First();
			}
			else
			{
				result = seq.OrderBy(x => x.AccidentalCount).First();
				new object();
			}

			return result;
		}

		public static KeySignature GetTransposed(KeySignature key, IntervalsEnum intervalEnum, DirectionEnum direction)
		{
			var intervalNdx = intervalEnum.ToIndex();
			if (direction == DirectionEnum.Descending)
			{
				intervalNdx *= -1;
			}
			var result = Get(key, (int)intervalNdx);

			return result;
		}

		public static KeySignature Get(KeySignature key, int intervalNdx)
		{
			List<KeySignature> keys = null;
			if (key.IsMajor)
			{
				keys = KeySignature.MajorKeys.OrderBy(x => x.NoteName.Value).ToList();
			}
			if (key.IsMinor)
			{
				keys = KeySignature.MinorKeys.OrderBy(x => x.NoteName.Value).ToList();
			}

			throw new NotImplementedException("15 NoteNames. UGH!");
			var maxNdx = keys.Count - 1;
			var currentNdx = keys.IndexOf(key);
			var targetNdx = currentNdx + intervalNdx;

			if (targetNdx < 0)
			{
				targetNdx = maxNdx + targetNdx;
			}
			else if (targetNdx > maxNdx)
			{
				targetNdx = targetNdx - maxNdx;
			}

			var result = keys[targetNdx];

			return result;
		}



	}//class
}//ns
