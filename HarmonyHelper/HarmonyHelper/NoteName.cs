using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    [Obsolete("", true)]
    [Flags]
    public enum NotesEnum
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

        Cb = B,
        Fb = E,

        DSharp = Eb,
        GSharp = Ab,
        CSharp = Db,
        FSharp = Gb,
    };

    public class NoteName
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public NoteName(string name, int val)
        {
            this.Name = name;
            this.Value = val;
        }

        static NoteName()
        {
            C = new NoteName("C", 1 << 1);
            Db = new NoteName("D♭", 1 << 2);
            D = new NoteName("D", 1 << 3);
            Eb = new NoteName("E♭", 1 << 4);
            E = new NoteName("E", 1 << 5);
            F = new NoteName("F", 1 << 6);
            Gb = new NoteName("G♭", 1 << 7);
            G = new NoteName("G", 1 << 8);
            Ab = new NoteName("A♭", 1 << 9);
            A = new NoteName("A", 1 << 10);
            Bb = new NoteName("B♭", 1 << 11);
            B = new NoteName("B", 1 << 12);

            Cb = new NoteName("C♭", B.Value);
            Fb = new NoteName("F♭", E.Value);

            DSharp = new NoteName("D♯", Eb.Value);
            GSharp = new NoteName("G♯", Ab.Value);
            CSharp = new NoteName("C♯", Db.Value);
            FSharp = new NoteName("F♯", Gb.Value);
        }

        #region NoteNames
        static public readonly NoteName C;
        static public readonly NoteName Db;
        static public readonly NoteName D;
        static public readonly NoteName Eb;
        static public readonly NoteName E;
        static public readonly NoteName F;
        static public readonly NoteName Gb;
        static public readonly NoteName G;
        static public readonly NoteName Ab;
        static public readonly NoteName A;
        static public readonly NoteName Bb;
        static public readonly NoteName B;

        static public readonly NoteName Cb;
        static public readonly NoteName Fb;

        static public readonly NoteName DSharp;
        static public readonly NoteName GSharp;
        static public readonly NoteName CSharp;
        static public readonly NoteName FSharp;
        #endregion NoteNames

        public override string ToString()
        {
            return base.ToString();
        }
        public string ToString(KeySignature key)
        {
            return this.Name;
        }

        public bool Equals(NoteName other)
        {
            var result = false;
            if (this.Name == other.Name)
                result = true;
            return result;
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
            var result = this.CompareTo(other);
            return result;
        }
        public static int Compare(NoteName a, NoteName b)
        {
            if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
                //if (null == a && null == b)
                return 0;
            else if (object.ReferenceEquals(null, a))
                //else if (null == a)
                return -1;
            else if (object.ReferenceEquals(null, b))
                //else if (null == b)
                return 1;

            return a.Name.CompareTo(b.Name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }//class
}//ns
