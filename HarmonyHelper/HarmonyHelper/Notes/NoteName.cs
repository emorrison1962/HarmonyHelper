using System;
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

		#region Statics

		static List<NoteName> _catalog { get; set; } = new List<NoteName>();
		static public IEnumerable<NoteName> Catalog { get { return _catalog; } }


		static public readonly NoteName BSharp = new NoteName($"B{Constants.SHARP}", VALUE_C);
		static public readonly NoteName C = new NoteName("C", VALUE_C);
		static public readonly NoteName Dbb = new NoteName($"D{Constants.DOUBLE_FLAT}", VALUE_C);


		static public readonly NoteName BSharpSharp = new NoteName($"B{Constants.DOUBLE_SHARP}", VALUE_Db);
		static public readonly NoteName CSharp = new NoteName($"C{Constants.SHARP}", VALUE_Db);
		static public readonly NoteName Db = new NoteName($"D{Constants.FLAT}", VALUE_Db);


		static public readonly NoteName CSharpSharp = new NoteName($"C{Constants.DOUBLE_SHARP}", VALUE_D);
		static public readonly NoteName D = new NoteName("D", VALUE_D);
		static public readonly NoteName Ebb = new NoteName($"E{Constants.DOUBLE_FLAT}", VALUE_D);


		static public readonly NoteName DSharp = new NoteName($"D{Constants.SHARP}", VALUE_Eb);
		static public readonly NoteName Eb = new NoteName($"E{Constants.FLAT}", VALUE_Eb);
		static public readonly NoteName Fbb = new NoteName($"F{Constants.DOUBLE_FLAT}", VALUE_Eb);


		static public readonly NoteName DSharpSharp = new NoteName($"D{Constants.DOUBLE_SHARP}", VALUE_E);
		static public readonly NoteName E = new NoteName("E", VALUE_E);
		static public readonly NoteName Fb = new NoteName($"F{Constants.FLAT}", VALUE_E);


		static public readonly NoteName ESharp = new NoteName($"E{Constants.SHARP}", VALUE_F);
		static public readonly NoteName F = new NoteName("F", VALUE_F);
		static public readonly NoteName Gbb = new NoteName($"G{Constants.DOUBLE_FLAT}", VALUE_F);


		static public readonly NoteName ESharpSharp = new NoteName($"E{Constants.DOUBLE_SHARP}", VALUE_Gb);
		static public readonly NoteName FSharp = new NoteName($"F{Constants.SHARP}", VALUE_Gb);
		static public readonly NoteName Gb = new NoteName($"G{Constants.FLAT}", VALUE_Gb);


		static public readonly NoteName FSharpSharp = new NoteName($"F{Constants.DOUBLE_SHARP}", VALUE_G);
		static public readonly NoteName G = new NoteName("G", VALUE_G);
		static public readonly NoteName Abb = new NoteName($"A{Constants.DOUBLE_FLAT}", VALUE_G);


		static public readonly NoteName GSharp = new NoteName($"G{Constants.SHARP}", VALUE_Ab);
		static public readonly NoteName Ab = new NoteName($"A{Constants.FLAT}", VALUE_Ab);


		static public readonly NoteName GSharpSharp = new NoteName($"G{Constants.DOUBLE_SHARP}", VALUE_A);
		static public readonly NoteName A = new NoteName("A", VALUE_A);
		static public readonly NoteName Bbb = new NoteName($"B{Constants.DOUBLE_FLAT}", VALUE_A);


		static public readonly NoteName ASharp = new NoteName($"A{Constants.SHARP}", VALUE_Bb);
		static public readonly NoteName Bb = new NoteName($"B{Constants.FLAT}", VALUE_Bb);
		static public readonly NoteName Cbb = new NoteName($"C{Constants.DOUBLE_FLAT}", VALUE_Bb);

		static public readonly NoteName ASharpSharp = new NoteName($"A{Constants.DOUBLE_SHARP}", VALUE_B);
		static public readonly NoteName B = new NoteName("B", VALUE_B);
		static public readonly NoteName Cb = new NoteName($"C{Constants.FLAT}", VALUE_B);


		#endregion Statics

		#region Properties
		static List<EnharmonicEquivalent> EnharmonicEquivalents { get; set; } = new List<EnharmonicEquivalent>();
		public string Name { get; private set; }
		public int Value { get; private set; }
		public bool IsSharped { get; private set; }
		public bool IsFlatted { get; private set; }
		public bool IsNatural { get; private set; }
		public int AsciiSortValue { get; private set; }


		#endregion

		#region Construction
		static NoteName()
		{
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(BSharp, C,  Dbb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(BSharpSharp, CSharp, Db));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(CSharpSharp, D, Ebb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(DSharp, Eb, Fbb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(DSharpSharp, E, Fb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ESharp, F, Gbb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ESharpSharp, FSharp, Gb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(FSharpSharp, G, Abb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(GSharp, Ab));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(GSharpSharp, A, Bbb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ASharp, Bb, Cbb));
			EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ASharpSharp, B, Cb));
		}

		NoteName(string name, int val, bool addToCatalog = true)
		{
			this.Name = name;
			this.Value = val;

			if (this.Name.EndsWith(Constants.SHARP))
				this.IsSharped = true;
			else if (this.Name.EndsWith(Constants.FLAT))
				this.IsFlatted = true;
			else
				this.IsNatural = true;

			this.AsciiSortValue = (this.Name[0] - ASCII_C >= 0) ?
				this.Name[0] - ASCII_C : this.Name[0] - ASCII_C + OFFSET_TO_ASCII_G;

			if (addToCatalog)
				_catalog.Add(this);
		}

		NoteName(NoteName src) : this(src.Name, src.Value, false)
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

		#endregion

		#region Operators
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
				//result = a.AsciiSortValue.CompareTo(b.AsciiSortValue);
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
				result = ctx.Key.GetNormalized(result, ctx.Interval);
			}
			return result;
		}

		public static NoteName operator -(NoteName note, IntervalContext ctx)
		{
			var result = note;
			if (null != note && ctx.Interval > Interval.None)
			{
				result = TransposeDown(note, ctx.Interval);
				result = ctx.Key.GetNormalized(result, ctx.Interval);
			}
			return result;
		}

		public static Interval operator -(NoteName a, NoteName b)
		{
			var result = Interval.None;
			bool success = false;
			if ((null != a && null != b) && 
				(a.Value != b.Value))
				success = true;

			if (success)
			{
				var notes = NoteName.Catalog
					.Distinct(new NoteNameValueEqualityComparer())
					.OrderBy(x => x.Value)
					.ToList();

				var ndxA = notes.FindIndex(x => x.Value == a.Value);
				var ndxB = notes.FindIndex(x => x.Value == b.Value);

				var invert = false;
				var diff = ndxA - ndxB;
				if (diff < 0)
				{
					invert = true;
					diff = Math.Abs(diff);
				}

				var pow = 1 << diff;
				var interval = (Interval)pow;
				result = interval;

				if (invert)
					result = interval.GetInversion();
			}
			return result;
		}

		#endregion

		public static NoteName TransposeUp(NoteName src, Interval interval)
		{
			NoteName result = src;
			var success = false;
			if (Interval.None < interval)
				success = true;

			IEnumerable<NoteName> noteNames = null;
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
				Debug.Assert(null != result);
				Debug.Assert(result != src);
				success = true;

				noteNames = NoteName.Catalog.Where(x => x.Value == result?.Value);
				if (null == noteNames)
					success = false;
			}


			if (success)
			{
				success = false;
				var optimalResult = noteNames.Where(x => x.IsFlatted == src.IsFlatted
					&& x.IsNatural == src.IsNatural
					&& x.IsSharped == src.IsSharped).FirstOrDefault();
				if (null != optimalResult)
				{
					result = optimalResult;
					success = true;
				}

				if (!success)
				{
					var nextBestResult = noteNames.Where(x => x.IsNatural).FirstOrDefault();
					if (null != nextBestResult)
					{
						result = nextBestResult;
						success = true;
					}
				}
				if (!success)
				{
#warning FIXME: # if ascending....
					var defaultResult = noteNames.Where(x => x.IsSharped).FirstOrDefault();
					if (null != defaultResult)
					{
						result = defaultResult;
						success = true;
					}
					else
					{
						defaultResult = noteNames.Where(x => x.IsFlatted).FirstOrDefault();
						if (null != defaultResult)
						{
							result = defaultResult;
							success = true;
						}
					}
				}
				if (!success)
				{
					throw new Exception($"{MethodBase.GetCurrentMethod().Name}: Unable to transpose input.");
				}

			}

			return result;
		}

		public static NoteName TransposeDown(NoteName src, Interval interval)
		{

			var inversion = interval.GetInversion();
			var result = TransposeUp(src, inversion);
			return result;
		}

		static public List<NoteName> GetEnharmonicEquivalents(NoteName nn)
		{
			var ee = NoteName.EnharmonicEquivalents.Where(x => x.Key.Name == nn.Name).First();
			var result = ee.Others;
			return result;
		}

		public override string ToString()
		{
			return this.Name;
		}

	}//class

	public static class NoteNameCatalogExtensions
	{
		[Obsolete("", false)]
		static public NoteName Get(this IEnumerable<NoteName> src,
			NoteName nn, Interval interval, INoteNameNormalizer normalizer)
		{
			var result = nn;
			if (Interval.None < interval)
			{
				result = NoteName.TransposeUp(nn, interval);
				result = normalizer.GetNormalized(result, interval);
			}
			return result;
		}

	}

}//ns
