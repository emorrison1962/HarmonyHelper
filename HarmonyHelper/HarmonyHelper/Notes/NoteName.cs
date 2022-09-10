using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony
{
	[Serializable]
	public class NoteName : HarmonyEntityBase, IComparable<NoteName>
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

		//static public readonly NullNoteName Empty = NullNoteName.Instance;
		static List<NoteName> _catalog { get; set; } = new List<NoteName>();
		static List<NoteName> _internalCatalog { get; set; } = new List<NoteName>();
		static public IEnumerable<NoteName> Catalog { get { return _catalog; } }
		static IEnumerable<NoteName> InternalCatalog { get { return _internalCatalog; } }


		static public readonly NoteName BSharp = new NoteName($"B{Constants.SHARP}", VALUE_C);
		static public readonly NoteName C = new NoteName("C", VALUE_C);
		static readonly NoteName Dbb = new NoteName($"D{Constants.DOUBLE_FLAT}", VALUE_C, false);


		static readonly NoteName BSharpSharp = new NoteName($"B{Constants.DOUBLE_SHARP}", VALUE_Db, false);
		static public readonly NoteName CSharp = new NoteName($"C{Constants.SHARP}", VALUE_Db);
		static public readonly NoteName Db = new NoteName($"D{Constants.FLAT}", VALUE_Db);


		static readonly NoteName CSharpSharp = new NoteName($"C{Constants.DOUBLE_SHARP}", VALUE_D, false);
		static public readonly NoteName D = new NoteName("D", VALUE_D);
		static readonly NoteName Ebb = new NoteName($"E{Constants.DOUBLE_FLAT}", VALUE_D, false);


		static public readonly NoteName DSharp = new NoteName($"D{Constants.SHARP}", VALUE_Eb);
		static public readonly NoteName Eb = new NoteName($"E{Constants.FLAT}", VALUE_Eb);
		static readonly NoteName Fbb = new NoteName($"F{Constants.DOUBLE_FLAT}", VALUE_Eb, false);


		static readonly NoteName DSharpSharp = new NoteName($"D{Constants.DOUBLE_SHARP}", VALUE_E, false);
		static public readonly NoteName E = new NoteName("E", VALUE_E);
		static public readonly NoteName Fb = new NoteName($"F{Constants.FLAT}", VALUE_E);


		static public readonly NoteName ESharp = new NoteName($"E{Constants.SHARP}", VALUE_F);
		static public readonly NoteName F = new NoteName("F", VALUE_F);
		static readonly NoteName Gbb = new NoteName($"G{Constants.DOUBLE_FLAT}", VALUE_F, false);


		static readonly NoteName ESharpSharp = new NoteName($"E{Constants.DOUBLE_SHARP}", VALUE_Gb, false);
		static public readonly NoteName FSharp = new NoteName($"F{Constants.SHARP}", VALUE_Gb);
		static public readonly NoteName Gb = new NoteName($"G{Constants.FLAT}", VALUE_Gb);


		static readonly NoteName FSharpSharp = new NoteName($"F{Constants.DOUBLE_SHARP}", VALUE_G, false);
		static public readonly NoteName G = new NoteName("G", VALUE_G);
		static readonly NoteName Abb = new NoteName($"A{Constants.DOUBLE_FLAT}", VALUE_G, false);


		static public readonly NoteName GSharp = new NoteName($"G{Constants.SHARP}", VALUE_Ab);
		static public readonly NoteName Ab = new NoteName($"A{Constants.FLAT}", VALUE_Ab);


		static readonly NoteName GSharpSharp = new NoteName($"G{Constants.DOUBLE_SHARP}", VALUE_A, false);
		static public readonly NoteName A = new NoteName("A", VALUE_A);
		static readonly NoteName Bbb = new NoteName($"B{Constants.DOUBLE_FLAT}", VALUE_A, false);


		static public readonly NoteName ASharp = new NoteName($"A{Constants.SHARP}", VALUE_Bb);
		static public readonly NoteName Bb = new NoteName($"B{Constants.FLAT}", VALUE_Bb);
		static readonly NoteName Cbb = new NoteName($"C{Constants.DOUBLE_FLAT}", VALUE_Bb, false);

		static readonly NoteName ASharpSharp = new NoteName($"A{Constants.DOUBLE_SHARP}", VALUE_B, false);
		static public readonly NoteName B = new NoteName("B", VALUE_B);
		static public readonly NoteName Cb = new NoteName($"C{Constants.FLAT}", VALUE_B);


		#endregion Statics

		#region Properties
		static List<EnharmonicEquivalent> EnharmonicEquivalents { get; set; } = new List<EnharmonicEquivalent>();
		virtual public string Name { get; protected set; }
		public int Value { get; protected set; }
		public bool IsSharped { get; protected set; }
		public bool IsFlatted { get; protected set; }
		public bool IsNatural { get; protected set; }
		public int AsciiSortValue { get; protected set; }

		public int AccidentalCount 
		{ 
			get 
			{
				var result = this.Name.Count(x => x == Constants.SHARP_CHAR 
					|| x == Constants.FLAT_CHAR);
				return result;
			} 
		}

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

		protected NoteName() { }
		protected NoteName(string name, int val, bool addToCatalog = true)
		{
			this.Name = name;
			this.Value = val;

			if (this.Name.EndsWith(Constants.SHARP))
				this.IsSharped = true;
			else if (this.Name.EndsWith(Constants.FLAT))
				this.IsFlatted = true;
			else
				this.IsNatural = true;

			if (this.Name[0] - ASCII_C >= 0)
			{
				this.AsciiSortValue = this.Name[0] - ASCII_C;
			}
			else
			{
				this.AsciiSortValue = this.Name[0] - ASCII_C + OFFSET_TO_ASCII_G;
			}

			_internalCatalog.Add(this);
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
		public static implicit operator int(NoteName nn)
		{
			return nn.Value;
		}
		public static explicit operator NoteName(int i)
		{
			return new NoteName("dynamic", i, false);
		}

		public static NoteName operator +(NoteName note, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var result = note;
			if (null != note)
			{
				//result = TransposeUp(note, interval);
				if (TryTransposeUp(note, interval, out var txposed, out var enharmonic))
				{
					result = txposed;
				}
				else 
				{
					result = enharmonic;
				}
            }
            return result;
		}

		public static NoteName operator -(NoteName note, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			NoteName result = null;
			if (null != note)
			{
				var success = NoteName.TryTransposeUp(note, interval.GetInversion(), out var txposed, out var enharmonicEquivelent);
				if (success)
				{
					result = txposed;
				}
				else
				{
					result = enharmonicEquivelent;
				}
			}
			return result;
		}

		public static Interval operator -(NoteName a, NoteName b)
		{
			Interval result = null;
			
			var logA = Math.Log(a.Value, 2);
            var logB = Math.Log(b.Value, 2);
            var pow = (logA - logB);

            var invert = false;
            if (pow < 0)
            {
                invert = true;
                pow = Math.Abs(pow);
            }
            else if (0 == pow)
            {
                result = Interval.Unison;
            }

            var intervalValue = (int)Math.Pow(2, pow);
            result = (Interval)intervalValue;
            if (invert)
            {
                result = result.Invert();
            }
            result = NoteName.ResolveInterval(result, a, b, invert);

            Debug.WriteLine($"{a} - {b} = {result}");
			
			return result;
		}
#if false
        public static AmbiguousInterval operator -(NoteName a, NoteName b)
        {
            var result = Interval.Unison;
            bool success = false;
            if ((null != a && null != b) &&
                (a.Value != b.Value))
                success = true;

            var invert = false;
            if (a < b)
            {
                var tmp = a;
                a = b;
                b = tmp;
                invert = true;
            }
            else
            {
                new object();
            }



            if (success)
            {
                var notes = NoteName.InternalCatalog
                    .OrderBy(x => x.Value)
                    .ToList();

                //var ndxA = notes.FindIndex(x => x.Value == a.Value);
                //var ndxB = notes.FindIndex(x => x.Value == b.Value);

                var shifted = int.MinValue;
                for (int shift = 0; shift < MAX_UPPER_SHIFT; ++shift)
                {
                    throw new NotImplementedException("this doesn't work if b < a");
                    if (b.Value == a.Value << shift)
                    {
                        shifted = shift;
                        break;
                    }
                }
                var intervalValue = (int)Math.Pow(2, shifted);

                result = ResolveInterval((Interval)intervalValue, a, b);

                new object();
#if false
				var invert = false;
				var diff = ndxA - ndxB;
				if (diff < 0)
				{
					invert = true;
					diff = Math.Abs(diff);
				}

				var val = 1 << diff;
				result = ResolveInterval(val, a, b);
#endif

                if (invert)
                    result = result.GetInversion();
            }
            return new AmbiguousInterval(result);
        }

#endif
#if false
		public static Interval operator -(NoteName a, NoteName b)
		{
			var result = Interval.Unison;
			bool success = false;
			if ((null != a && null != b) &&
				(a.Value != b.Value))
				success = true;

			if (success)
			{
				var notes = NoteName.InternalCatalog
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

				var val = 1 << diff;
				result = ResolveInterval(val, a, b);

				if (invert)
					result = result.GetInversion();
			}
			return result;
		}
#endif
        #endregion

        #region IComparable

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
				result = a.Name[0].CompareTo(b.Name[0]);
#if false
				Less than zero: This instance is less than value.
				Zero: This instance is equal to value.
				Greater than zero: This instance is greater than value.
#endif
			}

			return result;
		}

		virtual public bool Equals(NoteName other)
		{
			var result = false;
			if (this.Name == other.Name 
				&& this.Value == other.Value)
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

		#endregion

		static public Interval ResolveInterval(Interval interval, NoteName a, NoteName b, bool invert = false)
		{
			var steps = a.GetDistance<NoteName>(b, !invert);
			var intervals = Interval.Catalog.Where(x => x.Value == interval.Value).ToList();
			var result = intervals.FirstOrDefault(x => x.Name.Contains(steps.ToString()));

			if (result == null)
			{
				result = (Interval)interval;
			}

			Debug.Assert(result != null);

			return result;
		}


		public static bool TryTransposeUp(NoteName src, Interval interval, out NoteName txposed, out NoteName enharmonicEquivelent)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var result = false;
			txposed = null;
			enharmonicEquivelent = null;	

			var success = IsValidTransposition(src, interval);
			if (success)
			{
				txposed = TransposeUp(src, interval);
				result = true;
			}
			else
			{
				var enharmonicEquivalents = NoteName.GetEnharmonicEquivalents(src);
				var enharmonicEquivalent = enharmonicEquivalents.OrderBy(e => e.AccidentalCount).First();
				success = TryTransposeUp(enharmonicEquivalent, interval, out txposed, out var unused);
				Debug.Assert(success);
				if (success)
				{
					enharmonicEquivelent = txposed;
					txposed = null;
				}
			}
			return result;
		}

		protected static NoteName TransposeUp(NoteName src, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			NoteName result = null;
			var success = false;
			if (Interval.Unison == interval || Interval.PerfectOctave == interval)
			{
				result = src;
			}
			else
			{
				success = true;
			}

			IEnumerable<NoteName> noteNames = null;
			if (success)
			{
				var val = TransposeValue(src, interval);
				result = ResolveNoteName(src, interval, val);
				Debug.Assert(null != result);
			}
			Debug.Assert(null != result);
			return result;
		}

		private static int TransposeValue(NoteName src, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var result = src.Value << interval.SemiTones;
			if (result > VALUE_B)
			{
				result = result >> 12;
			}
			Debug.Assert(result <= VALUE_B);

			return result;
		}

		public static NoteName ResolveNoteName(NoteName src, Interval interval, int noteVal)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			const char ASCII_G = 'G';
			var intervalRole = interval.IntervalRoleType;

			var notenames = NoteName.InternalCatalog
				.OrderBy(x => x.Value)
				.ToList();
			var resultCandidates = notenames.Where(x => x.Value == noteVal).ToList();
			Debug.Assert(resultCandidates.Count > 0);

			var srcAscii = (int)src.Name[0];
			var readableSrcAscii = (char)srcAscii;
			var lettersAway = (int)intervalRole;
			srcAscii += lettersAway;
			if (srcAscii > ASCII_G)
			{
				srcAscii -= OFFSET_TO_ASCII_G;
			}

			var criteria = new String((char)srcAscii, 1);
			var result = resultCandidates.FirstOrDefault(x => x.Name.StartsWith(criteria));
			if (null == result) //This can happen when transposing B# up an augmented fifth, expecting F###
			{
				throw new ArgumentOutOfRangeException(nameof(result), $"HarmonyHelper does not support triple flatted or triple sharped NoteNames.");
			}
			return result;
		}

		public static bool IsValidTransposition(NoteName note, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var result = true;
			var comparer = new NoteNameAphaEqualityComparer();
			if (
					comparer.Equals(note, NoteName.ASharp) && interval == Interval.Augmented6th

					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Major3rd)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Major6th)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.ASharpSharp) && interval == Interval.Major7th)

					|| (comparer.Equals(note, NoteName.Bbb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Bbb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Bbb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Bbb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented6th)

					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Major2nd)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Major3rd)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Perfect5th)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Major6th)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.BSharpSharp) && interval == Interval.Major7th)

					|| (comparer.Equals(note, NoteName.Cb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Cb) && interval == Interval.Diminished7th)

					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Minor2nd)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Minor3rd)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Minor6th)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.Minor7th)
					|| (comparer.Equals(note, NoteName.Cbb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.CSharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.CSharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.CSharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.CSharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.CSharpSharp) && interval == Interval.Augmented6th)

					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Minor2nd)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Minor6th)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Dbb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Major3rd)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.DSharpSharp) && interval == Interval.Major7th)

					|| (comparer.Equals(note, NoteName.ESharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.ESharp) && interval == Interval.Augmented2nd)

					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Major2nd)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Major3rd)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Major6th)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.ESharpSharp) && interval == Interval.Major7th)

					|| (comparer.Equals(note, NoteName.Ebb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Ebb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Ebb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Ebb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Ebb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Minor2nd)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Minor3rd)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Perfect4th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Minor6th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.Minor7th)
					|| (comparer.Equals(note, NoteName.Fbb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.Fb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Fb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Fb) && interval == Interval.Diminished7th)

					|| (comparer.Equals(note, NoteName.FSharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.FSharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.FSharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.FSharpSharp) && interval == Interval.Augmented6th)

					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.AugmentedUnison)
					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.Augmented4th)
					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.Augmented5th)
					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.Augmented6th)
					|| (comparer.Equals(note, NoteName.GSharpSharp) && interval == Interval.Major7th)

					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Minor2nd)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Augmented2nd)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Minor3rd)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Minor6th)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Gbb) && interval == Interval.DiminishedOctave)

					|| (comparer.Equals(note, NoteName.Gb) && interval == Interval.Diminished3rd)

					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.Minor2nd)
					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.Diminished3rd)
					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.Diminished4th)
					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.Diminished5th)
					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.Diminished7th)
					|| (comparer.Equals(note, NoteName.Abb) && interval == Interval.DiminishedOctave)

				 )
			{
				result = false;
			}
			return result;
		}

		[Obsolete("", true)]
		public static NoteName TransposeDown(NoteName src, Interval interval)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var inversion = interval.GetInversion();
			var result = TransposeUp(src, (dynamic)inversion);
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


	[Obsolete("", true)]
	public class NullNoteName : NoteName
	{
		static public NullNoteName Instance = new NullNoteName();
		static NullNoteName()
		{
			Instance = new NullNoteName();
		}
		private NullNoteName() : base() { }
		new public string Name => Constants.EMPTY;
	}

	[Obsolete("", true)]
	public static class NoteNameCatalogExtensions
	{
		[Obsolete("", true)]
		static public NoteName Get(this IEnumerable<NoteName> src,
			NoteName nn, Interval interval,INoteNameNormalizer normalizer)
		{
			if (null == interval)
				throw new ArgumentNullException(nameof(interval));
			var result = nn;
			if (Interval.Unison < interval)
			{
				var success = NoteName.TryTransposeUp(nn, interval, out result, out var unused);
				Debug.Assert(success);
			}
			Debug.Assert(result != null);
			return result;
		}
	}//class

}//ns
