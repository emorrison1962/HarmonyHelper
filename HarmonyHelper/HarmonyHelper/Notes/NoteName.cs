﻿using Eric.Morrison.Harmony.Intervals;
using HarmonyHelper.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony
{
    [Serializable]
    public class NoteName : ChordEntityBase, IComparable<NoteName>, INoteName
    {
        #region Constants

        public enum NoteValuesEnum
        {
            C = 1 << 1,
            Db = 1 << 2,
            D = 1 << 3,
            Eb = 1 << 4,
            E = 1 << 5,
            F = 1 << 6,
            Gb = 1 << 7,
            G = 1 << 8,
            Ab = 1 << 9,
            A = 1 << 10,
            Bb = 1 << 11,
            B = 1 << 12,
        };

        [Flags]
        public enum ExplicitNoteValuesEnum
        {
            BSharp = 1 << 1 | Sharp,
            C = 1 << 1 | Natural,
            Dbb = 1 << 1 | DoubleFlat,

            BSharpSharp = 1 << 2 | DoubleSharp,
            CSharp = 1 << 2 | Sharp,
            Db = 1 << 2 | Flat,
            
            CSharpSharp = 1 << 3 | DoubleSharp, 
            D = 1 << 3 | Natural,
            Ebb = 1 << 3 | DoubleFlat,

            DSharp = 1 << 4 | Sharp,
            Eb = 1 << 4 | Flat,
            Fbb = 1 << 4 | DoubleFlat,

            DSharpSharp = 1 << 5 | DoubleSharp,
            E = 1 << 5 | Natural,
            Fb = 1 << 5 | Flat,

            ESharp = 1 << 6 | Sharp,
            F = 1 << 6 | Natural,
            Gbb = 1 << 6 | DoubleFlat,

            ESharpSharp = 1 << 7 | DoubleSharp,
            FSharp = 1 << 7 | Sharp,
            Gb = 1 << 7 | Flat,

            FSharpSharp = 1 << 8 | DoubleSharp,
            G = 1 << 8 | Natural,
            Abb = 1 << 8 | DoubleFlat,

            GSharp = 1 << 9 | Sharp,
            Ab = 1 << 9 | Flat,

            GSharpSharp = 1 << 10 | DoubleSharp,
            A = 1 << 10 | Natural,
            Bbb = 1 << 10 | DoubleFlat,

            ASharp = 1 << 11 | Sharp,
            Bb = 1 << 11 | Flat,
            Cbb = 1 << 11 | DoubleFlat,

            ASharpSharp = 1 << 12 | DoubleSharp,
            B = 1 << 12 | Natural,
            Cb = 1 << 12 | Flat,

            Natural = 1 << 31,
            Sharp = 1 << 30,
            Flat = 1 << 29,
            DoubleSharp = 1 << 28,
            DoubleFlat = 1 << 27,
        };


        const char ASCII_C = 'C';
        const int OFFSET_TO_ASCII_G = 7;

        #endregion Constants

        #region Statics

        static public readonly NullNoteName Empty = NullNoteName.Instance;
        static List<NoteName> _catalog { get; set; } = new List<NoteName>();
        static List<NoteName> _internalCatalog { get; set; } = new List<NoteName>();
        static public IEnumerable<NoteName> Catalog { get { return _catalog; } }
        static IEnumerable<NoteName> InternalCatalog { get { return _internalCatalog; } }


        static public readonly NoteName BSharp = new NoteName($"B{Constants.SHARP}", 
            NoteValuesEnum.C, ExplicitNoteValuesEnum.BSharp);
        static public readonly NoteName C = new NoteName("C", 
            NoteValuesEnum.C, ExplicitNoteValuesEnum.C);
        static readonly NoteName Dbb = new NoteName($"D{Constants.DOUBLE_FLAT}", 
            NoteValuesEnum.C,
            ExplicitNoteValuesEnum.Dbb, 
            false);


        static readonly NoteName BSharpSharp = new NoteName($"B{Constants.DOUBLE_SHARP}", 
            NoteValuesEnum.Db,
            ExplicitNoteValuesEnum.BSharpSharp,
            false);
        static public readonly NoteName CSharp = new NoteName($"C{Constants.SHARP}", 
            NoteValuesEnum.Db,
            ExplicitNoteValuesEnum.CSharp);
        static public readonly NoteName Db = new NoteName($"D{Constants.FLAT}", 
            NoteValuesEnum.Db,
            ExplicitNoteValuesEnum.Db);


        static readonly NoteName CSharpSharp = new NoteName($"C{Constants.DOUBLE_SHARP}", 
            NoteValuesEnum.D,
            ExplicitNoteValuesEnum.CSharpSharp,
            false);
        static public readonly NoteName D = new NoteName("D", 
            NoteValuesEnum.D,
            ExplicitNoteValuesEnum.D);
        static readonly NoteName Ebb = new NoteName($"E{Constants.DOUBLE_FLAT}", 
            NoteValuesEnum.D,
            ExplicitNoteValuesEnum.Eb,
            false);


        static public readonly NoteName DSharp = new NoteName($"D{Constants.SHARP}", 
            NoteValuesEnum.Eb,
            ExplicitNoteValuesEnum.DSharp);
        static public readonly NoteName Eb = new NoteName($"E{Constants.FLAT}", 
            NoteValuesEnum.Eb,
            ExplicitNoteValuesEnum.Eb);
        static readonly NoteName Fbb = new NoteName($"F{Constants.DOUBLE_FLAT}", 
            NoteValuesEnum.Eb,
            ExplicitNoteValuesEnum.Fbb,
            false);


        static readonly NoteName DSharpSharp = new NoteName($"D{Constants.DOUBLE_SHARP}", 
            NoteValuesEnum.E,
            ExplicitNoteValuesEnum.DSharpSharp,
            false);
        static public readonly NoteName E = new NoteName("E", 
            NoteValuesEnum.E,
            ExplicitNoteValuesEnum.E);
        static public readonly NoteName Fb = new NoteName($"F{Constants.FLAT}", 
            NoteValuesEnum.E,
            ExplicitNoteValuesEnum.Fb);


        static public readonly NoteName ESharp = new NoteName($"E{Constants.SHARP}", 
            NoteValuesEnum.F,
            ExplicitNoteValuesEnum.ESharp);
        static public readonly NoteName F = new NoteName("F", 
            NoteValuesEnum.F,
            ExplicitNoteValuesEnum.F);
        static readonly NoteName Gbb = new NoteName($"G{Constants.DOUBLE_FLAT}", 
            NoteValuesEnum.F,
            ExplicitNoteValuesEnum.Gbb,
            false);


        static readonly NoteName ESharpSharp = new NoteName($"E{Constants.DOUBLE_SHARP}", 
            NoteValuesEnum.Gb,
            ExplicitNoteValuesEnum.ESharpSharp,
            false);
        static public readonly NoteName FSharp = new NoteName($"F{Constants.SHARP}",
            NoteValuesEnum.Gb,
            ExplicitNoteValuesEnum.FSharp);
        static public readonly NoteName Gb = new NoteName($"G{Constants.FLAT}",
            NoteValuesEnum.Gb,
            ExplicitNoteValuesEnum.Gb);


        static readonly NoteName FSharpSharp = new NoteName($"F{Constants.DOUBLE_SHARP}",
            NoteValuesEnum.G,
            ExplicitNoteValuesEnum.FSharpSharp,
            false);
        static public readonly NoteName G = new NoteName("G",
            NoteValuesEnum.G,
            ExplicitNoteValuesEnum.G);
        static readonly NoteName Abb = new NoteName($"A{Constants.DOUBLE_FLAT}",
            NoteValuesEnum.G,
            ExplicitNoteValuesEnum.Abb,
            false);


        static public readonly NoteName GSharp = new NoteName($"G{Constants.SHARP}",
            NoteValuesEnum.Ab,
            ExplicitNoteValuesEnum.GSharp);
        static public readonly NoteName Ab = new NoteName($"A{Constants.FLAT}",
            NoteValuesEnum.Ab,
            ExplicitNoteValuesEnum.Ab);


        static readonly NoteName GSharpSharp = new NoteName($"G{Constants.DOUBLE_SHARP}",
            NoteValuesEnum.A,
            ExplicitNoteValuesEnum.GSharpSharp,
            false);
        static public readonly NoteName A = new NoteName("A",
            NoteValuesEnum.A,
            ExplicitNoteValuesEnum.A);
        static readonly NoteName Bbb = new NoteName($"B{Constants.DOUBLE_FLAT}",
            NoteValuesEnum.A,
            ExplicitNoteValuesEnum.Bbb,
            false);


        static public readonly NoteName ASharp = new NoteName($"A{Constants.SHARP}",
            NoteValuesEnum.Bb,
            ExplicitNoteValuesEnum.ASharp);
        static public readonly NoteName Bb = new NoteName($"B{Constants.FLAT}",
            NoteValuesEnum.Bb,
            ExplicitNoteValuesEnum.Bb);
        static readonly NoteName Cbb = new NoteName($"C{Constants.DOUBLE_FLAT}",
            NoteValuesEnum.Bb,
            ExplicitNoteValuesEnum.Cbb,
            false);

        static readonly NoteName ASharpSharp = new NoteName($"A{Constants.DOUBLE_SHARP}",
            NoteValuesEnum.B,
            ExplicitNoteValuesEnum.ASharpSharp,
            false);
        static public readonly NoteName B = new NoteName("B",
            NoteValuesEnum.B,
            ExplicitNoteValuesEnum.B);
        static public readonly NoteName Cb = new NoteName($"C{Constants.FLAT}",
            NoteValuesEnum.B,
            ExplicitNoteValuesEnum.Cb);


        #endregion Statics

        #region Properties
        static List<EnharmonicEquivalent> EnharmonicEquivalents { get; set; } = new List<EnharmonicEquivalent>();
        virtual public string Name { get; protected set; }
        [Obsolete("", false)]
        virtual public int RawValue { get; protected set; }
        public ExplicitNoteValuesEnum ExplicitNoteValue { get; private set; }
        virtual public bool IsSharped { get; protected set; }
        virtual public bool IsFlatted { get; protected set; }
        virtual public bool IsNatural { get; protected set; }
        virtual public int AsciiSortValue { get; protected set; }

        virtual public int AccidentalCount
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
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(BSharp, C, Dbb));
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
        protected NoteName(string name, NoteValuesEnum val, ExplicitNoteValuesEnum eval, bool addToCatalog = true)
        {
            this.Name = name;
            this.RawValue = (int)val;
            this.ExplicitNoteValue = eval;

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

            if (!_internalCatalog.Contains(this))
                _internalCatalog.Add(this);

            if (addToCatalog)
                _catalog.Add(this);
        }

        NoteName(NoteName src) 
            : this(src.Name, 
                  (NoteValuesEnum)src.RawValue, 
                  src.ExplicitNoteValue,  false)
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
            return nn.RawValue;
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
            if (null == a)
                throw new ArgumentNullException(nameof(a));
            if (null == b)
                throw new ArgumentNullException(nameof(b));

            Interval result = null;

            var logA = Math.Log(a.RawValue, 2);
            var logB = Math.Log(b.RawValue, 2);
            var pow = (logA - logB);

            var invert = false;
            if (pow < 0)
            {
                invert = true;
                pow = Math.Abs(pow);
            }

            //throw new NotImplementedException("Well. I broke this.");
            var intervalValue = (int)Math.Pow(2, pow);
            result = (Interval)intervalValue;
            result = NoteName.ResolveInterval(result, a, b, invert);

            if (invert)
            {
                result = result.Invert();
            }

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

            var result = a.RawValue.CompareTo(b.RawValue);
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
            if (this.RawValue == other.RawValue
                && this.Name == other.Name)
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
            var result = this.RawValue.GetHashCode();
            return result;
        }

        #endregion

        static public Interval ResolveInterval(Interval interval, NoteName a, NoteName b, bool invert = false)
        {
            Interval result = null;
            var lettersAway = a.GetDistance<NoteName>(b, !invert);
            var intervals = Interval.Catalog.Where(x => x.Value == interval.Value).ToList();
            if (0 == lettersAway)
            {
                result = intervals
                    .FirstOrDefault(x => x.Name.Contains("Unison")
                    || x.Name.Contains("Octave"));
            }
            else
            {
                result = intervals
                    .FirstOrDefault(x => x.Name.Contains(lettersAway.ToString()));
            }

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
            //if (src == NoteName.BSharp && interval == ChordToneInterval.Sharp9th)
            //    new object();
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
            var result = src.RawValue << interval.SemiTones;
            if ((NoteValuesEnum)result > NoteValuesEnum.B)
            {
                result = result >> 12;
            }
            Debug.Assert((NoteValuesEnum)result <= NoteValuesEnum.B);

            return result;
        }

        public static NoteName ResolveNoteName(NoteName src, Interval interval, int noteVal)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            const char ASCII_G = 'G';
            var intervalRole = interval.IntervalRoleType;

            var notenames = NoteName.InternalCatalog
                .OrderBy(x => x.RawValue)
                .ToList();
            var resultCandidates = notenames.Where(x => x.RawValue == noteVal).ToList();
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
            var comparer = new NoteNameAlphaEqualityComparer();
            if (
                    comparer.Equals(note, NoteName.ASharp) && interval == Interval.Augmented6th

                    || (comparer.Equals(note, NoteName.DSharp) && interval == Interval.Augmented3rd)
                    || (comparer.Equals(note, NoteName.Fb) && interval == Interval.Diminished6th)
                    || (comparer.Equals(note, NoteName.Fb) && interval == Interval.Diminished2nd)
                    || (comparer.Equals(note, NoteName.ESharp) && interval == Interval.Augmented7th)
                    || (comparer.Equals(note, NoteName.ESharp) && interval == Interval.Augmented3rd)
                    || (comparer.Equals(note, NoteName.Gb) && interval == Interval.Diminished6th)
                    || (comparer.Equals(note, NoteName.Gb) && interval == Interval.Diminished2nd)
                    || (comparer.Equals(note, NoteName.GSharp) && interval == Interval.Augmented7th)
                    || (comparer.Equals(note, NoteName.Ab) && interval == Interval.Diminished2nd)
                    || (comparer.Equals(note, NoteName.ASharp) && interval == Interval.Augmented7th)
                    || (comparer.Equals(note, NoteName.ASharp) && interval == Interval.Augmented3rd)
                    || (comparer.Equals(note, NoteName.Cb) && interval == Interval.Diminished6th)
                    || (comparer.Equals(note, NoteName.Cb) && interval == Interval.Diminished2nd)






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
                    || (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented3rd)
                    || (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented5th)
                    || (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented6th)
                    || (comparer.Equals(note, NoteName.BSharp) && interval == Interval.Augmented7th)

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

                    || (comparer.Equals(note, NoteName.Db) && interval == Interval.Diminished2nd)
                    || (comparer.Equals(note, NoteName.Db) && interval == Interval.Diminished6th)
                    || (comparer.Equals(note, NoteName.Db) && interval == Interval.Diminished7th)

                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Minor2nd)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished3rd)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished4th)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished5th)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Minor6th)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.Diminished7th)
                    || (comparer.Equals(note, NoteName.Dbb) && interval == Interval.DiminishedOctave)

                    || (comparer.Equals(note, NoteName.DSharp) && interval == Interval.Augmented7th)

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


    public class NullNoteName : NoteName, INoteName
    {
        static public NullNoteName Instance;
        static NullNoteName()
        {
            Instance = new NullNoteName();
        }
        private NullNoteName() : base() { }
        override public string Name => Constants.EMPTY;

        override public int AccidentalCount => throw new NotImplementedException();

        override public int AsciiSortValue => int.MinValue;

        override public bool IsFlatted => false;

        override public bool IsNatural => false;

        override public bool IsSharped => false;

        override public int RawValue => int.MinValue;
    }

    [Obsolete("", true)]
    public static class NoteNameCatalogExtensions
    {
        [Obsolete("", true)]
        static public NoteName Get(this IEnumerable<NoteName> src,
            NoteName nn, Interval interval, INoteNameNormalizer normalizer)
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
