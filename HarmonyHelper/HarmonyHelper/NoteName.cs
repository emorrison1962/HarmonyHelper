using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class NoteName
    {
        #region Constants
        const int VALUE_C = 1 << 1;
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
        const int VALUE_B = 1 << 12;

        //const int VALUE_Cb = VALUE_B;
        //const int VALUE_Fb = VALUE_E;

        //const int VALUE_DSHARP = VALUE_Eb;
        //const int VALUE_GSHARP = VALUE_Ab;
        //const int VALUE_CSHARP = VALUE_Db;
        //const int VALUE_FSHARP = VALUE_Gb;
        #endregion Constants


        static List<NoteName> NoteNames { get; set; } = new List<NoteName>();
        static List<EnharmonicEquivalent> EnharmonicEquivalents { get; set; } = new List<EnharmonicEquivalent>();
        public string Name { get; private set; }
        public int Value { get; private set; }
        public bool IsSharp { get; private set; }
        public bool IsFlat { get; private set; }
        public bool IsNatural { get; private set; }


        NoteName(string name, int val)
        {
            this.Name = name;
            this.Value = val;

            if (this.Name.EndsWith("♯"))
                this.IsSharp = true;
            else if (this.Name.EndsWith("♭"))
                this.IsFlat = true;
            else
                this.IsNatural = true;
        }

        NoteName(NoteName src) : this(src.Name, src.Value)
        {
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
            NoteNames.Add(BSharp = new NoteName("B♯", VALUE_C));
            NoteNames.Add(C = new NoteName("C", VALUE_C));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(C, BSharp));

            NoteNames.Add(CSharp = new NoteName("C♯", VALUE_Db));
            NoteNames.Add(Db = new NoteName("D♭", VALUE_Db));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(CSharp, Db));

            NoteNames.Add(D = new NoteName("D", VALUE_D));

            NoteNames.Add(DSharp = new NoteName("D♯", VALUE_Eb));
            NoteNames.Add(Eb = new NoteName("E♭", VALUE_Eb));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(DSharp, Eb));

            NoteNames.Add(E = new NoteName("E", VALUE_E));
            NoteNames.Add(Fb = new NoteName("F♭", VALUE_E));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(E, Fb));

            NoteNames.Add(ESharp = new NoteName("E♯", VALUE_F));
            NoteNames.Add(F = new NoteName("F", VALUE_F));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ESharp, F));

            NoteNames.Add(FSharp = new NoteName("F♯", VALUE_Gb));
            NoteNames.Add(Gb = new NoteName("G♭", VALUE_Gb));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(FSharp, Gb));

            NoteNames.Add(G = new NoteName("G", VALUE_G));

            NoteNames.Add(GSharp = new NoteName("G♯", VALUE_Ab));
            NoteNames.Add(Ab = new NoteName("A♭", VALUE_Ab));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(GSharp, Ab));

            NoteNames.Add(A = new NoteName("A", VALUE_A));

            NoteNames.Add(ASharp = new NoteName("A♯", VALUE_Bb));
            NoteNames.Add(Bb = new NoteName("B♭", VALUE_Bb));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(ASharp, Bb));

            NoteNames.Add(B = new NoteName("B", VALUE_B));
            NoteNames.Add(Cb = new NoteName("C♭", VALUE_B));
            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(B, Cb));


            EnharmonicEquivalents.AddRange(EnharmonicEquivalent.Create(C));
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
            var result = pairing.Other;
            return result;
        }

        static public List<NoteName> GetNoteNames()
        {
            return NoteName.NoteNames;
        }

        public override string ToString()
        {
            return this.Name;
        }
        [Obsolete]
        public string ToString(KeySignature key)
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
            if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
                return 0;
            else if (object.ReferenceEquals(null, a))
                return -1;
            else if (object.ReferenceEquals(null, b))
                return 1;

            return a.Value.CompareTo(b.Value);
        }

        public bool Equals(NoteName other)
        {
            var result = false;
            if (this.Value == other.Value)
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

        public static NoteName operator +(NoteName note, IntervalsEnum interval)
        {
            var result = note;
            if (null != note && interval > IntervalsEnum.None)
            {
                result = NoteNamesCollection.Get(note, interval);
            }
            return result;
        }

        public static NoteName operator -(NoteName note, IntervalsEnum interval)
        {
            var result = note;
            if (null != note && interval > IntervalsEnum.None)
            {
                result = NoteNamesCollection.Get(note, interval, DirectionEnum.Descending);
            }
            return result;
        }

        public static IntervalsEnum operator -(NoteName a, NoteName b)
        {
            var result = IntervalsEnum.None;
            if (null != a && null != b)
            {
                var notes = NoteName.GetNoteNames()
                    .Distinct(new NoteNameValueComparer())
                    .OrderBy(x => x.Value)
                    .ToList();

                var ndxA = notes.FindIndex(x => x.Value == a.Value);
                var ndxB = notes.FindIndex(x => x.Value == b.Value);

                var diff = Math.Abs(ndxA - ndxB);
                var pow = 1 << diff;
                result = (IntervalsEnum)pow;
            }
            return result;
        }


    }//class

    class NoteNameValueComparer : IEqualityComparer<NoteName>
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

}//ns
