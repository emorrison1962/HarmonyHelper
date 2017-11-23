using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class KeySignature : IEquatable<KeySignature>, IComparable<KeySignature>
    {
        #region KeySignatures
        public static readonly KeySignature NoAccidentals;
        public static readonly KeySignature CMajor;
        public static readonly KeySignature AMinor;
        List<NoteName> CMajorNotes = new List<NoteName>()
        {
            NoteName.C,
            NoteName.D,
            NoteName.E,
            NoteName.F,
            NoteName.G,
            NoteName.A,
            NoteName.B
        };

        public static readonly KeySignature OneSharps;
        public static readonly KeySignature GMajor;
        public static readonly KeySignature EMinor;

        public static readonly KeySignature TwoSharps;
        public static readonly KeySignature DMajor;
        public static readonly KeySignature BMinor;

        public static readonly KeySignature ThreeSharps;
        public static readonly KeySignature AMajor;
        public static readonly KeySignature FSharpMinor;

        public static readonly KeySignature FourSharps;
        public static readonly KeySignature EMajor;
        public static readonly KeySignature CSharpMinor;

        public static readonly KeySignature FiveSharps;
        public static readonly KeySignature BMajor;
        public static readonly KeySignature GSharpMinor;

        public static readonly KeySignature SixSharps;
        public static readonly KeySignature FSharpMajor;
        public static readonly KeySignature DSharpMinor;

        public static readonly KeySignature SevenSharps;
        public static readonly KeySignature CSharpMajor;
        public static readonly KeySignature ASharpMinor;

        public static readonly KeySignature OneFlats;
        public static readonly KeySignature FMajor;
        public static readonly KeySignature DMinor;

        public static readonly KeySignature TwoFlats;
        public static readonly KeySignature BbMajor;
        public static readonly KeySignature GMinor;

        public static readonly KeySignature ThreeFlats;
        public static readonly KeySignature EbMajor;
        public static readonly KeySignature CMinor;

        public static readonly KeySignature FourFlats;
        public static readonly KeySignature AbMajor;
        public static readonly KeySignature FMinor;

        public static readonly KeySignature FiveFlats;
        public static readonly KeySignature DbMajor;
        public static readonly KeySignature BbMinor;


        public static readonly KeySignature SixFlats;
        public static readonly KeySignature GbMajor;
        public static readonly KeySignature EbMinor;

        public static readonly KeySignature SevenFlats;
        public static readonly KeySignature CbMajor;
        public static readonly KeySignature AbMinor;
        #endregion KeySignatures

        public NoteName NoteName { get; private set; }
        public List<NoteName> Notes { get; private set; }
        public bool UsesSharps { get; private set; }
        public bool UsesFlats { get; private set; }


        static KeySignature()
        {
            NoAccidentals = new KeySignature(NoteName.C, new[] {
                NoteName.C,
                NoteName.D,
                NoteName.E,
                NoteName.F,
                NoteName.G,
                NoteName.A,
                NoteName.B
                }, false);
            CMajor = KeySignature.Clone(NoAccidentals);
            AMinor = KeySignature.Clone(NoAccidentals);

            OneSharps = new KeySignature(NoteName.G, new[] {
                NoteName.G,
                NoteName.A,
                NoteName.B,
                NoteName.C,
                NoteName.D,
                NoteName.E,
                NoteName.FSharp
            }, true); // F#
            GMajor = KeySignature.Clone(KeySignature.OneSharps);
            EMinor = KeySignature.Clone(KeySignature.OneSharps);

            TwoSharps = new KeySignature(NoteName.D,
                new[] {
                NoteName.D,
                NoteName.E,
                NoteName.FSharp,
                NoteName.G,
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,}, true); // F♯ C♯
            DMajor = KeySignature.Clone(KeySignature.TwoSharps);
            BMinor = KeySignature.Clone(KeySignature.TwoSharps);

            ThreeSharps = new KeySignature(NoteName.A,
                new[] {
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,
                NoteName.D,
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,}, true);// F♯, C♯, G♯
            AMajor = KeySignature.Clone(KeySignature.ThreeSharps);
            FSharpMinor = KeySignature.Clone(KeySignature.ThreeSharps);

            FourSharps = new KeySignature(NoteName.E,
                new[] {
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,}, true);// F♯, C♯, G♯, D♯
            EMajor = KeySignature.Clone(KeySignature.FourSharps);
            CSharpMinor = KeySignature.Clone(KeySignature.FourSharps);

            FiveSharps = new KeySignature(NoteName.B,
                new[] {
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,}, true);// F♯, C♯, G♯, D♯, A♯
            BMajor = KeySignature.Clone(KeySignature.FiveSharps);
            GSharpMinor = KeySignature.Clone(KeySignature.FiveSharps);

            SixSharps = new KeySignature(NoteName.FSharp, new[] {
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.ESharp}, true);// F♯, C♯, G♯, D♯, A♯, E♯
            FSharpMajor = KeySignature.Clone(KeySignature.SixSharps);
            DSharpMinor = KeySignature.Clone(KeySignature.SixSharps);

            SevenSharps = new KeySignature(NoteName.CSharp, new[] {
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.ESharp,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,
                NoteName.BSharp }, true);// F♯, C♯, G♯, D♯, A♯, E♯, B♯
            CSharpMajor = KeySignature.Clone(KeySignature.SevenSharps);
            ASharpMinor = KeySignature.Clone(KeySignature.SevenSharps);

            OneFlats = new KeySignature(NoteName.F,
                new[] {
                NoteName.F,
                NoteName.G,
                NoteName.A,
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
                NoteName.E,
            }, false);// B♭
            FMajor = KeySignature.Clone(KeySignature.OneFlats);
            DMinor = KeySignature.Clone(KeySignature.OneFlats);

            TwoFlats = new KeySignature(NoteName.Bb,
                new[] {
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
                NoteName.A,
            }, false);// B♭, E♭
            BbMajor = KeySignature.Clone(KeySignature.TwoFlats);
            GMinor = KeySignature.Clone(KeySignature.TwoFlats);

            ThreeFlats = new KeySignature(NoteName.Eb,
                new[] {
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
            }, false);// B♭, E♭, A♭
            EbMajor = KeySignature.Clone(KeySignature.ThreeFlats);
            CMinor = KeySignature.Clone(KeySignature.ThreeFlats);

            FourFlats = new KeySignature(NoteName.Ab,
                new[] {
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
            }, false);// B♭, E♭, A♭, D♭
            AbMajor = KeySignature.Clone(KeySignature.FourFlats);
            FMinor = KeySignature.Clone(KeySignature.FourFlats);

            FiveFlats = new KeySignature(NoteName.Db,
                new[] {
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
            }, false);// B♭, E♭, A♭, D♭, G♭
            DbMajor = KeySignature.Clone(KeySignature.FiveFlats);
            BbMinor = KeySignature.Clone(KeySignature.FiveFlats);


            SixFlats = new KeySignature(NoteName.Gb,
                new[] {
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.Cb,
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
            }, false);// B♭, E♭, A♭, D♭, G♭, C♭
            GbMajor = KeySignature.Clone(KeySignature.SixFlats);
            EbMinor = KeySignature.Clone(KeySignature.SixFlats);

            SevenFlats = new KeySignature(NoteName.Cb,
                new[] {
                NoteName.Cb,
                NoteName.Db,
                NoteName.Eb,
                NoteName.Fb,
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
            }, false);// B♭, E♭, A♭, D♭, G♭, C♭, F♭
            CbMajor = KeySignature.Clone(KeySignature.SevenFlats);
            AbMinor = KeySignature.Clone(KeySignature.SevenFlats);
        }

        private KeySignature(NoteName key, IEnumerable<NoteName> notes, bool usesSharps)
        {
            this.NoteName = key;
            this.Notes = new List<NoteName>(notes);
            this.UsesSharps = usesSharps;
            this.UsesFlats = !usesSharps;
            if (0 == this.Notes.Count)
                this.UsesFlats = false;
        }
        private static KeySignature Clone(KeySignature src)
        {
            var result = new KeySignature(src.NoteName, src.Notes, src.UsesSharps);
            return result;
        }

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


        public bool Affects(NoteName note)
        {
            var result = false;
            if (this.Notes.Contains(note, new HasEnharmonicComparer()))
                result = true;
            return result;
        }
        public bool Contains(NoteName note)
        {
            var result = false;
            if (this.Notes.Contains(note, new IsInKeyComparer()))
                result = true;
            return result;
        }

        public NoteName Normalize(NoteName nn)
        {
            if (!this.Contains(nn))
            {
                if (this.Affects(nn))
                {
                    nn = NoteName.GetEnharmonicEquivalent(nn);
                }
                else if (!nn.IsNatural)
                {
                    nn = NoteName.GetEnharmonicEquivalent(nn);
                }
            }
            return nn;
        }

        public override string ToString()
        {
            return this.NoteName.ToString();
        }

        public bool Equals(KeySignature other)
        {
            var result = false;
            if (other.NoteName == this.NoteName)
                result = true;
            return result;
        }

        public override int GetHashCode()
        {
            var result = this.NoteName.GetHashCode()
                ^ this.Notes.GetHashCode()
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
            if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
                return 0;
            else if (object.ReferenceEquals(null, a))
                return -1;
            else if (object.ReferenceEquals(null, b))
                return 1;

            var result = a.NoteName.CompareTo(b.NoteName);
            if (0 == result)
            {
                result = a.Notes.GetHashCode().CompareTo(b.Notes.GetHashCode());
            }
            if (0 == result)
                result = a.UsesSharps.CompareTo(b.UsesSharps);
            if (0 == result)
                result = a.UsesFlats.CompareTo(b.UsesFlats);
            return result;
        }

        public static KeySignature operator +(KeySignature key, IntervalsEnum interval)
        {
            var result = KeySignatureCollection.Get(key, interval);
            return result;
        }

        public static KeySignature operator -(KeySignature key, IntervalsEnum interval)
        {
            var result = KeySignatureCollection.Get(key, interval, DirectionEnum.Descending);
            return result;
        }


    }//class
}//ns
