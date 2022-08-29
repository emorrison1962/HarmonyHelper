using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

// reference: https://dictionary.onmusic.org/appendix/topics/key-signatures

namespace Eric.Morrison.Harmony
{
	[Serializable]
	public partial class KeySignature : ClassBase, IEquatable<KeySignature>, IComparable<KeySignature>, INoteNameNormalizer
	{

		#region Properties
		public NoteName NoteName { get; private set; }
		public List<NoteName> NoteNames { get; private set; }
		public List<NoteName> Accidentals { get { return this.NoteNames.Where(x => x.IsFlatted || x.IsSharped).ToList(); } }
		public bool UsesSharps { get; private set; }
		public bool UsesFlats { get; private set; }
		public bool IsMajor { get; private set; }
		public bool IsMinor { get; private set; }
		public int AccidentalCount { get; private set; }

		public string Name { get; private set; }

		#endregion

		#region Construction
		private KeySignature(NoteName key, IEnumerable<NoteName> notes, bool? usesSharps, bool isMajor, bool isMinor)
		{
			this.NoteName = key;
			this.NoteNames = new List<NoteName>(notes);
			this.AccidentalCount = this.NoteNames.Where(x => x.Name.EndsWith(Constants.SHARP)
				|| x.Name.EndsWith(Constants.FLAT)).Count();

			if (usesSharps.HasValue)
			{
				this.UsesSharps = usesSharps.Value;
				this.UsesFlats = !usesSharps.Value;
			}
			if (0 == this.NoteNames.Count)
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

			var majMin = this.IsMajor ? "Major" : "Minor";
			this.Name = $"{this.NoteName} {majMin}";
		}

		#endregion

		#region Comparers
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

		#endregion

		#region Operators
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
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			var result = a.NoteName.CompareTo(b.NoteName);
			if (0 == result)
			{
				result = a.NoteNames.GetHashCode().CompareTo(b.NoteNames.GetHashCode());
			}
			if (0 == result)
				result = a.UsesSharps.CompareTo(b.UsesSharps);
			if (0 == result)
				result = a.UsesFlats.CompareTo(b.UsesFlats);
			return result;
		}

		public static KeySignature operator +(KeySignature key, Interval interval)
		{
			var result = KeySignature.GetTransposed(key, interval);
			return result;
		}

		public static KeySignature operator -(KeySignature key, Interval interval)
		{
			var inversion = interval.GetInversion();
			var result = KeySignature.GetTransposed(key, inversion);
			return result;
		}

		public override int GetHashCode()
		{
			var result = this.NoteName.GetHashCode()
				^ this.NoteNames.GetHashCode()
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

		public bool Equals(KeySignature other)
		{
			var result = false;
			if (other.NoteName == this.NoteName)
				result = true;
			return result;
		}

		#endregion

		public static KeySignature GetTransposed(KeySignature key, Interval interval)
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
				throw new ArgumentOutOfRangeException($"{MethodBase.GetCurrentMethod().Name}");
			}

			var seq = catalog.Where(x => x.NoteName.Value == txposedNote.Value);
			if (null == seq)
			{
				throw new ArgumentOutOfRangeException($"{MethodBase.GetCurrentMethod().Name}: Major key with NoteName{{{txposedNote.Name}}} does not exist");
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

		public NoteName GetNormalized(NoteName nn, Interval interval)
		{
			var result = nn.Copy();
			if (!this.Contains(result, out NoteName suggested))
			{
				if (null != suggested)
				{
					result = suggested;
				}
				else
				{
#warning  **** What's the fix? I don't know which Ascii name is optimal. ****
					result = NoteName.GetEnharmonicEquivalents(result)[0];
				}
			}
			return result;
		}
		
		public bool Contains(NoteName note, out NoteName inKeyEnharmonic)
		{
			inKeyEnharmonic = null;
			var result = false;

			var explicitComparer = new IsInKeyComparer();
			if (this.NoteNames.Contains(note, explicitComparer))
				result = true;
			else
			{
				if (this.NoteNames.Contains(note, new HasEnharmonicComparer()))
				{
					foreach (var ee in NoteName.GetEnharmonicEquivalents(note))
					{
						if (this.NoteNames.Contains(ee, explicitComparer))
						{
							inKeyEnharmonic = ee;
							break;
						}
					}
				}
			}
			return result;
		}
		public override string ToString()
		{
			return this.Name;
		}
		public bool AreDiatonic(List<NoteName> noteNames)
		{
			bool result = false;
			var count = noteNames.Except(this.NoteNames).Count();
			if (0 == count)
				result = true;
			return result;
		}

		public bool AreDiatonic(List<NoteName> noteNames, out int nonDiatonicCount)
		{
			bool result = false;
			nonDiatonicCount = noteNames.Except(this.NoteNames, 
				new NoteNameExplicitEqualityComparer()).Count();
			if (0 == nonDiatonicCount)
				result = true;
			return result;
		}

		static public bool TryDetermineKey(List<ChordFormula> chords,
			out KeySignature matchedKey,
			out KeySignature probableKey)
		{
			matchedKey = null;
			probableKey = null;
			var result = false;
			var nns = chords.SelectMany(x => x.NoteNames)
				.ToList();
			var keys = new List<Tuple<int, KeySignature>>();
			foreach (var key in KeySignature.Catalog)
			{
				if (key.AreDiatonic(nns, out var notDiatonicCount))
				{
					matchedKey = key;
					result = true;
					break;
				}
				else
				{
					keys.Add(new Tuple<int, KeySignature>(notDiatonicCount, key));
				}
			}
			if (!result)
			{
				var probableTuple = keys.OrderBy(x => x.Item1)
					.ThenBy(x => x.Item2.AccidentalCount)
					.First();
				probableKey = probableTuple.Item2;
				result = true;
			}

			return result;
		}


		public KeySignature GetRelativeMajor()
		{
			if (this.IsMajor)
				throw new ArgumentOutOfRangeException();
			var txed = NoteName.TransposeUp(this.NoteName, Interval.Minor3rd);
			var result = KeySignature.MajorKeys.First(x => x.NoteName == txed);
			return result;
		}
		public KeySignature GetRelativeMinor()
		{
			if (this.IsMinor)
				throw new ArgumentOutOfRangeException();
			var txed = NoteName.TransposeDown(this.NoteName, Interval.Minor3rd);
			var result = KeySignature.MinorKeys.First(x => x.NoteName == txed);
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

        public KeySignature GetEnharmonicEquivalent()
        {
			var nns = NoteName.GetEnharmonicEquivalents(this.NoteName);
			var keys = Catalog
				.Where(x => x.NoteName.Value == this.NoteName.Value 
					&& x.IsMajor == this.IsMajor).ToList();
			var result = keys.OrderBy(x => x.AccidentalCount)
				.First();
			return result;
		}
	}//class
}//ns
