using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

using HarmonyHelper.Eric.Morrison.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public partial class KeySignature
    {
        #region Statics
        public static KeySignature NoAccidentals { get; protected set; }
        public static KeySignature CMajor { get; protected set; }
        public static KeySignature AMinor { get; protected set; }
        public static KeySignature OneSharps { get; protected set; }
        public static KeySignature GMajor { get; protected set; }
        public static KeySignature EMinor { get; protected set; }
        public static KeySignature TwoSharps { get; protected set; }
        public static KeySignature DMajor { get; protected set; }
        public static KeySignature BMinor { get; protected set; }
        public static KeySignature ThreeSharps { get; protected set; }
        public static KeySignature AMajor { get; protected set; }
        public static KeySignature FSharpMinor { get; protected set; }
        public static KeySignature FourSharps { get; protected set; }
        public static KeySignature EMajor { get; protected set; }
        public static KeySignature CSharpMinor { get; protected set; }
        public static KeySignature FiveSharps { get; protected set; }
        public static KeySignature BMajor { get; protected set; }
        public static KeySignature GSharpMinor { get; protected set; }
        public static KeySignature SixSharps { get; protected set; }
        public static KeySignature FSharpMajor { get; protected set; }
        public static KeySignature DSharpMinor { get; protected set; }
        public static KeySignature SevenSharps { get; protected set; }
        public static KeySignature CSharpMajor { get; protected set; }
        public static KeySignature ASharpMinor { get; protected set; }
        public static KeySignature OneFlats { get; protected set; }
        public static KeySignature FMajor { get; protected set; }
        public static KeySignature DMinor { get; protected set; }
        public static KeySignature TwoFlats { get; protected set; }
        public static KeySignature BbMajor { get; protected set; }
        public static KeySignature GMinor { get; protected set; }
        public static KeySignature ThreeFlats { get; protected set; }
        public static KeySignature EbMajor { get; protected set; }
        public static KeySignature CMinor { get; protected set; }
        public static KeySignature FourFlats { get; protected set; }
        public static KeySignature AbMajor { get; protected set; }
        public static KeySignature FMinor { get; protected set; }
        public static KeySignature FiveFlats { get; protected set; }
        public static KeySignature DbMajor { get; protected set; }
        public static KeySignature BbMinor { get; protected set; }
        public static KeySignature SixFlats { get; protected set; }
        public static KeySignature GbMajor { get; protected set; }
        public static KeySignature EbMinor { get; protected set; }
        public static KeySignature SevenFlats { get; protected set; }
        public static KeySignature CbMajor { get; protected set; }
        public static KeySignature AbMinor { get; protected set; }

        #endregion        
        public static List<KeySignature> MinorKeys { get; protected set; } = new List<KeySignature>();
        public static List<KeySignature> MajorKeys { get; protected set; } = new List<KeySignature>();

        static CatalogBase<KeySignature> _Catalog { get; set; } = new CatalogBase<KeySignature>();
        static CatalogBase<KeySignature> _InternalCatalog { get; set; } = new CatalogBase<KeySignature>();
        public static CatalogBase<KeySignature> Catalog { get { return _Catalog; } }
        static public IEnumerable<KeySignature> InternalCatalog { get { return _InternalCatalog; } }



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
                }, false, false);
            CMajor = KeySignature.Clone(NoAccidentals, true);
            AMinor = KeySignature.Clone(NoAccidentals, false, NoteName.A);

            OneSharps = new KeySignature(NoteName.G, new[] {
                NoteName.G,
                NoteName.A,
                NoteName.B,
                NoteName.C,
                NoteName.D,
                NoteName.E,
                NoteName.FSharp
            }, true, false, false); // F#
            GMajor = KeySignature.Clone(KeySignature.OneSharps, true);
            EMinor = KeySignature.Clone(KeySignature.OneSharps, false, NoteName.E);

            TwoSharps = new KeySignature(NoteName.D,
                new[] {
                NoteName.D,
                NoteName.E,
                NoteName.FSharp,
                NoteName.G,
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,}, true, false, false); // F♯ C♯
            DMajor = KeySignature.Clone(KeySignature.TwoSharps, true);
            BMinor = KeySignature.Clone(KeySignature.TwoSharps, false, NoteName.B);

            ThreeSharps = new KeySignature(NoteName.A,
                new[] {
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,
                NoteName.D,
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,}, true, false, false);// F♯, C♯, G♯
            AMajor = KeySignature.Clone(KeySignature.ThreeSharps, true);
            FSharpMinor = KeySignature.Clone(KeySignature.ThreeSharps, false, NoteName.FSharp);

            FourSharps = new KeySignature(NoteName.E,
                new[] {
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.A,
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,}, true, false, false);// F♯, C♯, G♯, D♯
            EMajor = KeySignature.Clone(KeySignature.FourSharps, true);
            CSharpMinor = KeySignature.Clone(KeySignature.FourSharps, false, NoteName.CSharp);

            FiveSharps = new KeySignature(NoteName.B,
                new[] {
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.E,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,}, true, false, false);// F♯, C♯, G♯, D♯, A♯
            BMajor = KeySignature.Clone(KeySignature.FiveSharps, true);
            GSharpMinor = KeySignature.Clone(KeySignature.FiveSharps, false, NoteName.GSharp);

            SixSharps = new KeySignature(NoteName.FSharp, new[] {
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,
                NoteName.B,
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.ESharp}, true, false, false);// F♯, C♯, G♯, D♯, A♯, E♯
            FSharpMajor = KeySignature.Clone(KeySignature.SixSharps, true);
            DSharpMinor = KeySignature.Clone(KeySignature.SixSharps, false, NoteName.DSharp);

            SevenSharps = new KeySignature(NoteName.CSharp, new[] {
                NoteName.CSharp,
                NoteName.DSharp,
                NoteName.ESharp,
                NoteName.FSharp,
                NoteName.GSharp,
                NoteName.ASharp,
                NoteName.BSharp }, true, false, false);// F♯, C♯, G♯, D♯, A♯, E♯, B♯
            CSharpMajor = KeySignature.Clone(KeySignature.SevenSharps, true);
            ASharpMinor = KeySignature.Clone(KeySignature.SevenSharps, false, NoteName.ASharp);

            OneFlats = new KeySignature(NoteName.F,
                new[] {
                NoteName.F,
                NoteName.G,
                NoteName.A,
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
                NoteName.E,
            }, false, false, false);// B♭
            FMajor = KeySignature.Clone(KeySignature.OneFlats, true);
            DMinor = KeySignature.Clone(KeySignature.OneFlats, false, NoteName.D);

            TwoFlats = new KeySignature(NoteName.Bb,
                new[] {
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
                NoteName.A,
            }, false, false, false);// B♭, E♭
            BbMajor = KeySignature.Clone(KeySignature.TwoFlats, true);
            GMinor = KeySignature.Clone(KeySignature.TwoFlats, false, NoteName.G);

            ThreeFlats = new KeySignature(NoteName.Eb,
                new[] {
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
                NoteName.D,
            }, false, false, false);// B♭, E♭, A♭
            EbMajor = KeySignature.Clone(KeySignature.ThreeFlats, true);
            CMinor = KeySignature.Clone(KeySignature.ThreeFlats, false, NoteName.C);

            FourFlats = new KeySignature(NoteName.Ab,
                new[] {
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
                NoteName.G,
            }, false, false, false);// B♭, E♭, A♭, D♭
            AbMajor = KeySignature.Clone(KeySignature.FourFlats, true);
            FMinor = KeySignature.Clone(KeySignature.FourFlats, false, NoteName.F);

            FiveFlats = new KeySignature(NoteName.Db,
                new[] {
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.C,
            }, false, false, false);// B♭, E♭, A♭, D♭, G♭
            DbMajor = KeySignature.Clone(KeySignature.FiveFlats, true);
            BbMinor = KeySignature.Clone(KeySignature.FiveFlats, false, NoteName.Bb);


            SixFlats = new KeySignature(NoteName.Gb,
                new[] {
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
                NoteName.Cb,
                NoteName.Db,
                NoteName.Eb,
                NoteName.F,
            }, false, false, false);// B♭, E♭, A♭, D♭, G♭, C♭
            GbMajor = KeySignature.Clone(KeySignature.SixFlats, true);
            EbMinor = KeySignature.Clone(KeySignature.SixFlats, false, NoteName.Eb);

            SevenFlats = new KeySignature(NoteName.Cb,
                new[] {
                NoteName.Cb,
                NoteName.Db,
                NoteName.Eb,
                NoteName.Fb,
                NoteName.Gb,
                NoteName.Ab,
                NoteName.Bb,
            }, false, false, false);// B♭, E♭, A♭, D♭, G♭, C♭, F♭
            CbMajor = KeySignature.Clone(KeySignature.SevenFlats, true);
            AbMinor = KeySignature.Clone(KeySignature.SevenFlats, false, NoteName.Ab);

            foreach (var key in MinorKeys)
            {// To easier deal with the fact that minor keys could be built on Aeolean or Harmonic minor, add both the minor 7th and Major 7th.
                var maj7th = key.NoteName - Interval.Minor2nd;
                var modifiedMinorKey = KeySignature.Clone(key, false, key.NoteName, false);
                modifiedMinorKey.NoteNames.Add(maj7th);
                modifiedMinorKey.Name = $"{modifiedMinorKey.Name} with Major and minor 7ths";

                _InternalCatalog.Add(modifiedMinorKey);
            }

        }

        private static KeySignature Clone(KeySignature src, bool isMajor, NoteName noteName = null, bool addToCatalog = true)
        {
            var nn = src.NoteName;
            if (!isMajor)
            {
                if (null == noteName)
                    throw new ArgumentNullException();
                nn = noteName;
            }
            var result = new KeySignature(nn, src.NoteNames, isMajor, !isMajor, addToCatalog);
            return result;
        }

        public List<ChordFormula> GetNonDiatonic(List<ChordFormula> chords)
        {
            var result = new List<ChordFormula>();
            foreach (var chord in chords)
            {
                if (chord.RawValue != (this.RawValue & chord.RawValue))
                    result.Add(chord);
            }
            return result;
        }

    }//class

}//ns
