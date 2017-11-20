using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class KeySignature : IEquatable<KeySignature>
    {
        #region KeySignatures
        public static readonly KeySignature NoAccidentals;
        public static readonly KeySignature CMajor;
        public static readonly KeySignature AMinor;

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

        public NotesEnum Key { get; private set; }
        public List<NotesEnum> Notes { get; private set; }
        public bool UsesSharps { get; private set; }


        static KeySignature()
        {
            NoAccidentals = new KeySignature(NotesEnum.C, new List<NotesEnum>(), false);
            CMajor = KeySignature.Clone(NoAccidentals);
            AMinor = KeySignature.Clone(NoAccidentals);

            OneSharps = new KeySignature(NotesEnum.G, new[] { NotesEnum.Gb }, true); // F#
            GMajor = KeySignature.Clone(KeySignature.OneSharps);
            EMinor = KeySignature.Clone(KeySignature.OneSharps);

            TwoSharps = new KeySignature(NotesEnum.D, new[] { NotesEnum.Gb,
                NotesEnum.Db,}, true); // F♯ C♯
            DMajor = KeySignature.Clone(KeySignature.TwoSharps);
            BMinor = KeySignature.Clone(KeySignature.TwoSharps);

            ThreeSharps = new KeySignature(NotesEnum.A,
                new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,}, true);// F♯, C♯, G♯
            AMajor = KeySignature.Clone(KeySignature.ThreeSharps);
            FSharpMinor = KeySignature.Clone(KeySignature.ThreeSharps);

            FourSharps = new KeySignature(NotesEnum.E, new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,}, true);// F♯, C♯, G♯, D♯
            EMajor = KeySignature.Clone(KeySignature.FourSharps);
            CSharpMinor = KeySignature.Clone(KeySignature.FourSharps);

            FiveSharps = new KeySignature(NotesEnum.B, new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,}, true);// F♯, C♯, G♯, D♯, A♯
            BMajor = KeySignature.Clone(KeySignature.FiveSharps);
            GSharpMinor = KeySignature.Clone(KeySignature.FiveSharps);

            SixSharps = new KeySignature(NotesEnum.FSharp, new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,
                NotesEnum.F}, true);// F♯, C♯, G♯, D♯, A♯, E♯
            FSharpMajor = KeySignature.Clone(KeySignature.SixSharps);
            DSharpMinor = KeySignature.Clone(KeySignature.SixSharps);

            SevenSharps = new KeySignature(NotesEnum.CSharp, new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,
                NotesEnum.F,
                NotesEnum.C }, true);// F♯, C♯, G♯, D♯, A♯, E♯, B♯
            CSharpMajor = KeySignature.Clone(KeySignature.SevenSharps);
            ASharpMinor = KeySignature.Clone(KeySignature.SevenSharps);

            OneFlats = new KeySignature(NotesEnum.F, new[] { NotesEnum.Bb,
            }, false);// B♭
            FMajor = KeySignature.Clone(KeySignature.OneFlats);
            DMinor = KeySignature.Clone(KeySignature.OneFlats);

            TwoFlats = new KeySignature(NotesEnum.Bb, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
            }, false);// B♭, E♭
            BbMajor = KeySignature.Clone(KeySignature.TwoFlats);
            GMinor = KeySignature.Clone(KeySignature.TwoFlats);

            ThreeFlats = new KeySignature(NotesEnum.Eb, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
            }, false);// B♭, E♭, A♭
            EbMajor = KeySignature.Clone(KeySignature.ThreeFlats);
            CMinor = KeySignature.Clone(KeySignature.ThreeFlats);

            FourFlats = new KeySignature(NotesEnum.Ab, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
            }, false);// B♭, E♭, A♭, D♭
            AbMajor = KeySignature.Clone(KeySignature.FourFlats);
            FMinor = KeySignature.Clone(KeySignature.FourFlats);

            FiveFlats = new KeySignature(NotesEnum.Db, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
            }, false);// B♭, E♭, A♭, D♭, G♭
            DbMajor = KeySignature.Clone(KeySignature.FiveFlats);
            BbMinor = KeySignature.Clone(KeySignature.FiveFlats);


            SixFlats = new KeySignature(NotesEnum.Gb, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
                NotesEnum.Cb,
            }, false);// B♭, E♭, A♭, D♭, G♭, C♭
            GbMajor = KeySignature.Clone(KeySignature.SixFlats);
            EbMinor = KeySignature.Clone(KeySignature.SixFlats);

            SevenFlats = new KeySignature(NotesEnum.Cb, new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
                NotesEnum.Cb,
                NotesEnum.Fb
            }, false);// B♭, E♭, A♭, D♭, G♭, C♭, F♭
            CbMajor = KeySignature.Clone(KeySignature.SevenFlats);
            AbMinor = KeySignature.Clone(KeySignature.SevenFlats);
        }

        private KeySignature(NotesEnum key, IEnumerable<NotesEnum> notes, bool usesSharps)
        {
            this.Key = key;
            this.Notes = new List<NotesEnum>(notes);
            this.UsesSharps = usesSharps;
        }
        private static KeySignature Clone(KeySignature src)
        {
            var result = new KeySignature(src.Key, src.Notes, src.UsesSharps);
            return result;
        }

        public bool Affects(NotesEnum note)
        {
            var result = false;
            if (this.Notes.Contains(note))
                result = true;
            return result;
        }
        public override string ToString()
        {
            return this.Key.ToString();
        }

        public bool Equals(KeySignature other)
        {
            var result = false;
            if (other.Key == this.Key)
                result = true;
            return result;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

    }//class
}//ns
