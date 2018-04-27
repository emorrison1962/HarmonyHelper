﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony
{
	[Serializable]
	public class NoteName : ClassBase, IComparable<NoteName>
	{
		#region Constants
		public const int MIN_LOWER_SHIFT = 1;
		const int VALUE_C = 1 << MIN_LOWER_SHIFT;
		const int VALUE_Db = 1 << 2;
		const int VALUE_D = 1 << 3;
		const int VALUE_Eb = 1 << 4;
		const int VALUE_E = 1 << 5;
		const int VALUE_F = 1 << 6;
		const int VALUE_Gb = 1 << 7;
		const int VALUE_G = 1 << 8;
		const int VALUE_Ab = 1 << 9;
		const int VALUE_A = 1 << 10;
		const int VALUE_Bb = 1 << 11;
		public const int MAX_UPPER_SHIFT = 12;
		const int VALUE_B = 1 << MAX_UPPER_SHIFT;
		const char ASCII_C = 'C';
		const int OFFSET_TO_ASCII_G = 7;

		static public int MinValue { get { return VALUE_C; } }
		static public int MaxValue { get { return VALUE_B; } }

		//const int VALUE_Cb = VALUE_B;
		//const int VALUE_Fb = VALUE_E;

		//const int VALUE_DSHARP = VALUE_Eb;
		//const int VALUE_GSHARP = VALUE_Ab;
		//const int VALUE_CSHARP = VALUE_Db;
		//const int VALUE_FSHARP = VALUE_Gb;
		#endregion Constants


		static public List<NoteName> Catalog { get; set; } = new List<NoteName>();
		static List<EnharmonicEquivalent> EnharmonicEquivalents { get; set; } = new List<EnharmonicEquivalent>();
		public string Name { get; private set; }
		public int Value { get; private set; }
		public bool IsSharp { get; private set; }
		public bool IsFlat { get; private set; }
		public bool IsNatural { get; private set; }
		public int AsciiSortValue { get; private set; }



		NoteName(string name, int val)
		{
			this.Name = name;
			this.Value = val;

			if (this.Name.EndsWith(Constants.SHARP))
				this.IsSharp = true;
			else if (this.Name.EndsWith(Constants.FLAT))
				this.IsFlat = true;
			else
				this.IsNatural = true;

			this.AsciiSortValue = (this.Name[0] - ASCII_C >= 0) ? 
				this.Name[0] - ASCII_C : this.Name[0] - ASCII_C + OFFSET_TO_ASCII_G;

		}

		NoteName(NoteName src) : this(src.Name, src.Value)
		{
		}

		public NoteName Copy()
		{
			var result = new NoteName(this);
			return result;
		}
		public static NoteName Copy(NoteName src)
		{
			var result = new NoteName(src);
			return result;
		}

		public class EnharmonicEquivalent
		{
			public NoteName Key { get; private set; }
			public NoteName Other { get; private set; }
			EnharmonicEquivalent(NoteName key, NoteName other)
			{
				if (key.Value != other.Value)
					throw new ArgumentException();

				this.Key = key;
				this.Other = other;

			}
			EnharmonicEquivalent(NoteName key)
			{
				this.Key = key;
				this.Other = key;
			}

			static public EnharmonicEquivalent[] Create(NoteName x, NoteName y)
			{
				return new EnharmonicEquivalent[] {
					new EnharmonicEquivalent(x,y),
					new EnharmonicEquivalent(y,x) };
			}
			static public EnharmonicEquivalent[] Create(NoteName x)
			{
				return new EnharmonicEquivalent[] {
					new EnharmonicEquivalent(x,x) };
			}

			public override string ToString()
			{
				return string.Format("{0}:{1}", this.Key.ToString(), this.Other.ToString());
			}
		}

		static NoteName()
		{
			Catalog.Add(BSharp = new NoteName("B♯", VALUE_C));
			Catalog.Add(C = new NoteName("C", VALUE_C));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(C, BSharp));

			Catalog.Add(CSharp = new NoteName("C♯", VALUE_Db));
			Catalog.Add(Db = new NoteName("D♭", VALUE_Db));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(CSharp, Db));

			Catalog.Add(D = new NoteName("D", VALUE_D));

			Catalog.Add(DSharp = new NoteName("D♯", VALUE_Eb));
			Catalog.Add(Eb = new NoteName("E♭", VALUE_Eb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(DSharp, Eb));

			Catalog.Add(E = new NoteName("E", VALUE_E));
			Catalog.Add(Fb = new NoteName("F♭", VALUE_E));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(E, Fb));

			Catalog.Add(ESharp = new NoteName("E♯", VALUE_F));
			Catalog.Add(F = new NoteName("F", VALUE_F));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ESharp, F));

			Catalog.Add(FSharp = new NoteName("F♯", VALUE_Gb));
			Catalog.Add(Gb = new NoteName("G♭", VALUE_Gb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(FSharp, Gb));

			Catalog.Add(G = new NoteName("G", VALUE_G));

			Catalog.Add(GSharp = new NoteName("G♯", VALUE_Ab));
			Catalog.Add(Ab = new NoteName("A♭", VALUE_Ab));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(GSharp, Ab));

			Catalog.Add(A = new NoteName("A", VALUE_A));

			Catalog.Add(ASharp = new NoteName("A♯", VALUE_Bb));
			Catalog.Add(Bb = new NoteName("B♭", VALUE_Bb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ASharp, Bb));

			Catalog.Add(B = new NoteName("B", VALUE_B));
			Catalog.Add(Cb = new NoteName("C♭", VALUE_B));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(B, Cb));


			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(D));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(G));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(A));

		}

		#region NoteNames
		static public readonly NoteName BSharp;
		static public readonly NoteName C;

		static public readonly NoteName CSharp;
		static public readonly NoteName Db;

		static public readonly NoteName D;

		static public readonly NoteName DSharp;
		static public readonly NoteName Eb;

		static public readonly NoteName E;
		static public readonly NoteName Fb;

		static public readonly NoteName ESharp;
		static public readonly NoteName F;

		static public readonly NoteName FSharp;
		static public readonly NoteName Gb;

		static public readonly NoteName G;

		static public readonly NoteName GSharp;
		static public readonly NoteName Ab;

		static public readonly NoteName A;

		static public readonly NoteName ASharp;
		static public readonly NoteName Bb;

		static public readonly NoteName B;
		static public readonly NoteName Cb;


		#endregion NoteNames

		static public NoteName GetEnharmonicEquivalent(NoteName nn)
		{
			var seq = NoteName.EnharmonicEquivalents.Where(x => x.Key.Name == nn.Name).ToList();
			Debug.Assert(seq.Count == 1);
			var pairing = NoteName.EnharmonicEquivalents.Where(x => x.Key.Name == nn.Name).First();
			var result = pairing.Other.Copy();
			return result;
		}

		public override string ToString()
		{
			return this.Name;
		}

		public static bool operator <(NoteName a, NoteName b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(NoteName a, NoteName b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(NoteName a, NoteName b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(NoteName a, NoteName b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(NoteName a, NoteName b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(NoteName a, NoteName b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}
		public int CompareTo(NoteName other)
		{
			var result = Compare(this, other);
			return result;
		}
		public static int Compare(NoteName a, NoteName b)
		{
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			var result = a.Value.CompareTo(b.Value);
			if (0 == result)
			{
				result = a.AsciiSortValue.CompareTo(b.AsciiSortValue);
#if false
				Less than zero: This instance is less than value.
				Zero: This instance is equal to value.
				Greater than zero: This instance is greater than value.
#endif
			}

			return result;
		}

		public bool Equals(NoteName other)
		{
			var result = false;
			if (/*this.Name == other.Name && */this.Value == other.Value)
				result = true;
			return result;
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is NoteName)
			{
				result = this.Equals(obj as NoteName);
			}
			else
			{
				base.Equals(obj);
			}
			return result;

		}

		public override int GetHashCode()
		{
			var result = this.Value.GetHashCode();
			return result;
		}

		public static NoteName operator +(NoteName note, IntervalContext ctx)
		{
			var result = note;
			if (null != note && ctx.Interval > Interval.None)
			{
				result = TransposeUp(note, ctx.Interval);
				result = ctx.Key.GetNormalized(result);
			}
			return result;
		}

		public static NoteName operator -(NoteName note, IntervalContext ctx)
		{
			var result = note;
			if (null != note && ctx.Interval > Interval.None)
			{
				result = TransposeDown(note, ctx.Interval);
				result = ctx.Key.GetNormalized(result);
			}
			return result;
		}

		public static Interval operator -(NoteName a, NoteName b)
		{
			var result = Interval.None;
			if (null != a && null != b)
			{
				var notes = NoteName.Catalog
					.Distinct(new NoteNameValueEqualityComparer())
					.OrderBy(x => x.Value)
					.ToList();

				var ndxA = notes.FindIndex(x => x.Value == a.Value);
				var ndxB = notes.FindIndex(x => x.Value == b.Value);

				var diff = Math.Abs(ndxA - ndxB);
				if (diff > 0)
				{
					var pow = 1 << diff;
					var intervalA = (Interval)pow;
					var intervalB = intervalA.GetInversion();
					var which = Math.Min(intervalA.Value, intervalB.Value);
					if (intervalA.Value == which)
						result = intervalA;
					else
						result = intervalB;

				}
			}
			return result;
		}

		public static NoteName TransposeUp(NoteName src, Interval interval)
		{
			NoteName result = null;
			var success = false;
			if (interval != Interval.None)
				success = true;
			if (success)
			{
				var notes = NoteName.Catalog
					.Distinct(new NoteNameValueEqualityComparer())
					.OrderBy(x => x.Value)
					.ToList();

				var maxNdx = notes.Count;
				//var maxNdx = notes.Count - 1;
				var currentNdx = notes.IndexOf(src);
				var intervalNdx = interval.ToIndex();

				var targetNdx = (currentNdx + intervalNdx) % maxNdx;

				result = notes[targetNdx];
				Debug.Assert(result != src);

				success = true;
			}
			Debug.Assert(null != result);
			var seq = NoteName.Catalog.Where(x => x.Value == result.Value);
			Debug.Assert(null != seq);
			if (success)
			{
				success = false;
				var optimalResult = seq.Where(x => x.IsFlat == src.IsFlat
					&& x.IsNatural == src.IsNatural
					&& x.IsSharp == src.IsSharp).FirstOrDefault();
				if (null != optimalResult)
				{
					result = optimalResult;
					success = true;
				}
			}
			if (!success)
			{
				var nextBestResult = seq.Where(x => x.IsNatural).FirstOrDefault();
				if (null != nextBestResult)
				{
					result = nextBestResult;
					success = true;
				}
			}
			if (!success)
			{
#warning FIXME: # if ascending....
				var defaultResult = seq.Where(x => x.IsSharp).FirstOrDefault();
				if (null != defaultResult)
				{
					result = defaultResult;
					success = true;
				}
			}
			if (!success)
			{
				throw new Exception($"{MethodBase.GetCurrentMethod().Name}: Unable to transpose input.");
			}

			return result;
		}

		public static NoteName TransposeDown(NoteName src, Interval interval)
		{

			var inversion = interval.GetInversion();
			var result = TransposeUp(src, inversion);
			return result;
		}


	}//class

	public class IntervalContext
	{
		public KeySignature Key { get; private set; }
		public Interval Interval { get; private set; }

		public IntervalContext(KeySignature key, Interval interval)
		{
			this.Key = key;
			this.Interval = interval;
		}
	}

	public class NoteNameValueEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			var result = false;
			if (x.Value == y.Value)
				result = true;
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Value.GetHashCode();
		}
	}

	public class NoteNameExplicitEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			var result = false;
			if (x.Name == y.Name && x.Value == y.Value)
				result = true;
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Name.GetHashCode() ^ obj.Value.GetHashCode();
		}
	}

	public class NoteNameAphaEqualityComparer : IEqualityComparer<NoteName>
	{
		public bool Equals(NoteName x, NoteName y)
		{
			var result = false;
			if (x.Name == y.Name)
				result = true;
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Name.GetHashCode();
		}
	}

	public class NoteNameAlphaComparer : IComparer<NoteName>
	{
		public int Compare(NoteName x, NoteName y)
		{
			return x.AsciiSortValue.CompareTo(y.AsciiSortValue);
		}
	}

	public class NoteNameListValueEqualityComparer : IEqualityComparer<List<NoteName>>
	{
		public bool Equals(List<NoteName> x, List<NoteName> y)
		{
			var result = true;
			var valueComparer = new NoteNameValueEqualityComparer();
			foreach (var nn in x)
			{
				if (!y.Contains(nn, valueComparer))
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public int GetHashCode(List<NoteName> obj)
		{
			var result = 0;
			foreach (var nn in obj)
			{
				result ^= nn.Value.GetHashCode();
			}
			return result;
		}

		public int GetHashCode(NoteName obj)
		{
			return obj.Value.GetHashCode();
		}
	}

	public static class NoteNameCatalogExtensions
	{
		[Obsolete("", false)]
		static public NoteName Get(this List<NoteName> src, 
			NoteName nn, Interval interval, INoteNameNormalizer normalizer)
		{
			var result = NoteName.TransposeUp(nn, interval);
			result = normalizer.GetNormalized(result);
			return result;
		}

	}

}//ns
