using Eric.Morrison.Harmony.Intervals;
using HarmonyHelper.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Eric.Morrison.Harmony
{
    [Serializable]
    public class NoteName : ChordEntityBase
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


    }//class
}//ns
