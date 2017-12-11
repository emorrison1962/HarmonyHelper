using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class ChordFormula : IEquatable<ChordFormula>, IComparable<ChordFormula>
    {
        #region Chords
        [Obsolete]
        static public readonly ChordFormula C7;
        [Obsolete]
        static public readonly ChordFormula F7;
        [Obsolete]
        static public readonly ChordFormula Bb7;
        [Obsolete]
        static public readonly ChordFormula Eb7;
        [Obsolete]
        static public readonly ChordFormula Ab7;
        [Obsolete]
        static public readonly ChordFormula Db7;
        [Obsolete]
        static public readonly ChordFormula Gb7;
        [Obsolete]
        static public readonly ChordFormula B7;
        [Obsolete]
        static public readonly ChordFormula E7;
        [Obsolete]
        static public readonly ChordFormula A7;
        [Obsolete]
        static public readonly ChordFormula D7;
        [Obsolete]
        static public readonly ChordFormula G7;
        #endregion

        #region Properties
        [Obsolete]
        static public List<ChordFormula> Formulas { get; private set; } = new List<ChordFormula>();

        public NoteName Root { get; set; }
        public NoteName Third { get; set; }
        public NoteName Fifth { get; set; }
        public NoteName Seventh { get; set; }
        public KeySignature Key { get; set; }
        public ChordTypesEnum ChordType { get; set; }
        public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
        public string Name { get { return this.Root.ToString()+this.ChordType.ToString(); } }


        #endregion

        #region Construction
        static ChordFormula()
        {
            var dominant7th = ChordTypesEnum.Dominant7th;

            Formulas.Add(C7 = new ChordFormula(NoteName.C, dominant7th, KeySignature.FMajor));
            Formulas.Add(F7 = new ChordFormula(NoteName.F, dominant7th, KeySignature.BbMajor));
            Formulas.Add(Bb7 = new ChordFormula(NoteName.Bb, dominant7th, KeySignature.EbMajor));
            Formulas.Add(Eb7 = new ChordFormula(NoteName.Eb, dominant7th, KeySignature.AbMajor));
            Formulas.Add(Ab7 = new ChordFormula(NoteName.Ab, dominant7th, KeySignature.DbMajor));
            Formulas.Add(Db7 = new ChordFormula(NoteName.Db, dominant7th, KeySignature.GbMajor));
            Formulas.Add(Gb7 = new ChordFormula(NoteName.Gb, dominant7th, KeySignature.CbMajor));
            Formulas.Add(B7 = new ChordFormula(NoteName.B, dominant7th, KeySignature.EMajor));
            Formulas.Add(E7 = new ChordFormula(NoteName.E, dominant7th, KeySignature.AMajor));
            Formulas.Add(A7 = new ChordFormula(NoteName.A, dominant7th, KeySignature.DMajor));
            Formulas.Add(D7 = new ChordFormula(NoteName.D, dominant7th, KeySignature.GMajor));
            Formulas.Add(G7 = new ChordFormula(NoteName.G, dominant7th, KeySignature.CMajor));
        }

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
            var third = NoteNamesCollection.Get(key, root, interval);
            this.NoteNames.Add(this.Third = third);


            interval = chordType.GetFifthInterval();
            var fifth = NoteNamesCollection.Get(key, root, interval);
            this.NoteNames.Add(this.Fifth = fifth);

            interval = chordType.GetSeventhInterval();
            var seventh = NoteNamesCollection.Get(key, root, interval);
            this.NoteNames.Add(this.Seventh = seventh);

        }


        #endregion

        public static ChordFormula operator +(ChordFormula chord, IntervalsEnum interval)
        {
            var txedKey = chord.Key + interval;
            var txedRoot = NoteNamesCollection.Get(txedKey, chord.Root, interval);

            var result = new ChordFormula(txedRoot, chord.ChordType, txedKey);
            return result;
        }

        public static ChordFormula operator -(ChordFormula chord, IntervalsEnum interval)
        {
            var txedKey = chord.Key - interval;
            var txedRoot = NoteNamesCollection.Get(txedKey, chord.Root, interval, DirectionEnum.Descending);
            txedRoot = txedKey.Normalize(txedRoot);

            var result = new ChordFormula(txedRoot, chord.ChordType, txedKey);
            return result;
        }

        public override string ToString()
        {
            var r = this.Root.ToString();
            var third = this.Third.ToString();
            var fifth = this.Fifth.ToString();
            var seventh = this.Seventh.ToString();

            var result = string.Format("{0},{1},{2},{3}", r, third, fifth, seventh);
            return result;
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

    }//class
}//ns
