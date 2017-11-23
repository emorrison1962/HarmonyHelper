using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class ChordFormula : IEquatable<ChordFormula>, IComparable<ChordFormula>
    {
        #region Chords
        static public readonly ChordFormula C7;
        static public readonly ChordFormula F7;
        static public readonly ChordFormula Bb7;
        static public readonly ChordFormula Eb7;
        static public readonly ChordFormula Ab7;
        static public readonly ChordFormula Db7;
        static public readonly ChordFormula Gb7;
        static public readonly ChordFormula B7;
        static public readonly ChordFormula E7;
        static public readonly ChordFormula A7;
        static public readonly ChordFormula D7;
        static public readonly ChordFormula G7;
        #endregion

        #region Properties
        static public List<ChordFormula> Chords { get; private set; } = new List<ChordFormula>();

        public NoteName Root { get; set; }
        public NoteName Third { get; set; }
        public NoteName Fifth { get; set; }
        public NoteName Seventh { get; set; }
        public KeySignature KeySignature { get; set; }
        public ChordTypesEnum ChordType { get; set; }
        public ChordFunctionEnum ChordFunction { get; set; }

        #endregion

        #region Construction
        static ChordFormula()
        {
            var dominant7th = ChordTypesEnum.Dominant7th;
            var dominant = ChordFunctionEnum.V;

            //var test = new ChordFormula(NoteName.D, dominant7th, dominant, KeySignature.GMajor);
            //Debug.WriteLine(test);


            Chords.Add(C7 = new ChordFormula(NoteName.C, dominant7th, dominant, KeySignature.FMajor));
            Chords.Add(F7 = new ChordFormula(NoteName.F, dominant7th, dominant, KeySignature.BbMajor));

            Chords.Add(Bb7 = new ChordFormula(NoteName.Bb, dominant7th, dominant, KeySignature.EbMajor));
            Chords.Add(Eb7 = new ChordFormula(NoteName.Eb, dominant7th, dominant, KeySignature.AbMajor));
            Chords.Add(Ab7 = new ChordFormula(NoteName.Ab, dominant7th, dominant, KeySignature.DbMajor));
            Chords.Add(Db7 = new ChordFormula(NoteName.Db, dominant7th, dominant, KeySignature.GbMajor));

            Chords.Add(Gb7 = new ChordFormula(NoteName.Gb, dominant7th, dominant, KeySignature.CbMajor));


            Chords.Add(B7 = new ChordFormula(NoteName.B, dominant7th, dominant, KeySignature.EMajor));
            Chords.Add(E7 = new ChordFormula(NoteName.E, dominant7th, dominant, KeySignature.AMajor));

            Chords.Add(A7 = new ChordFormula(NoteName.A, dominant7th, dominant, KeySignature.DMajor));
            Chords.Add(D7 = new ChordFormula(NoteName.D, dominant7th, dominant, KeySignature.GMajor));
            Chords.Add(G7 = new ChordFormula(NoteName.G, dominant7th, dominant, KeySignature.CMajor));
        }

        private ChordFormula(NoteName root, ChordTypesEnum chordType, 
            ChordFunctionEnum chordFunction, KeySignature key)
        {
            this.KeySignature = key;
            this.ChordType = chordType;
            this.ChordFunction = chordFunction;

            this.Root = root;
            if (null == root)
                throw new NullReferenceException();

            var interval = chordType.GetThirdInterval();
            var third = NotesCollection.Get(root, interval);
            if (null == third)
                throw new NullReferenceException();
            this.Third = key.Normalize(third);


            interval = chordType.GetFifthInterval();
            var fifth = NotesCollection.Get(root, interval);
            if (null == fifth)
                throw new NullReferenceException();
            this.Fifth = key.Normalize(fifth);

            interval = chordType.GetSeventhInterval();
            var seventh = NotesCollection.Get(root, interval);
            if (null == seventh)
                throw new NullReferenceException();
            this.Seventh = key.Normalize(seventh);

        }


        #endregion

        public static ChordFormula operator +(ChordFormula chord, IntervalsEnum interval)
        {
            var txedKey = KeySignatureCollection.Get(chord.KeySignature, interval);
            var txedRoot = NotesCollection.Get(chord.Root, interval);
            txedRoot = txedKey.Normalize(txedRoot);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
            return result;
        }

        public static ChordFormula operator -(ChordFormula chord, IntervalsEnum interval)
        {
            var txedKey = KeySignatureCollection.Get(chord.KeySignature, interval, DirectionEnum.Descending);
            var txedRoot = NotesCollection.Get(chord.Root, interval, DirectionEnum.Descending);
            txedRoot = txedKey.Normalize(txedRoot);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
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
                && this.KeySignature == other.KeySignature)
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
                result = a.KeySignature.CompareTo(b.KeySignature);
            return result;
        }
        public override int GetHashCode()
        {
            var result = this.Root.GetHashCode()
                ^ this.Third.GetHashCode()
                ^ this.Fifth.GetHashCode()
                ^ this.Seventh.GetHashCode()
                ^ this.KeySignature.GetHashCode();

            return result;
        }

    }//class
}//ns
