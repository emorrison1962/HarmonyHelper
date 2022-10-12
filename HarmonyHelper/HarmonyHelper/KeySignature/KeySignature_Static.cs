using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public partial class KeySignature
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
        static List<KeySignature> _internalCatalog { get; set; } = new List<KeySignature>();
        static IEnumerable<KeySignature> InternalCatalog { get { return _internalCatalog; } }

        public static List<KeySignature> Catalog { get; private set; } = new List<KeySignature>();
        public static List<KeySignature> MajorKeys { get; private set; } = new List<KeySignature>();
		public static List<KeySignature> MinorKeys { get; private set; } = new List<KeySignature>();
		#endregion KeySignatures


		#region Construction
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
				}, null, false, false);
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

				_internalCatalog.Add(modifiedMinorKey);
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
			var result = new KeySignature(nn, src.NoteNames, src.UsesSharps, isMajor, !isMajor, addToCatalog);
			return result;
		}
		#endregion

		public List<ChordFormula> GetNonDiatonic(List<ChordFormula> chords)
		{
			var result = new List<ChordFormula>();
			foreach (var chord in chords)
			{
				if (!IsDiatonic(chord.NoteNames))
					result.Add(chord);
			}
			return result;
		}

		bool IsDiatonic(List<NoteName> noteNames)
		{
			var result = false;

			if (0 == noteNames.Except(this.NoteNames).Count())
				result = true;

			return result;
		}

	}//class
}//ns
