using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

using Newtonsoft.Json;

using static Eric.Morrison.Harmony.NoteName;

// reference: https://dictionary.onmusic.org/appendix/topics/key-signatures

namespace Eric.Morrison.Harmony
{
    [Serializable]
    public partial class KeySignature : ClassBase, IEquatable<KeySignature>, IComparable<KeySignature>
    {

        #region Properties
        virtual public NoteName NoteName { get; set; }
        virtual public List<NoteName> NoteNames { get; set; }
        virtual public List<NoteName> Accidentals { get { return this.NoteNames?.Where(x => x.IsFlatted || x.IsSharped).ToList(); } }
        virtual public bool UsesSharps
        {
            get
            {
                var result = false;
                if (this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Sharp)
                    || this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.DoubleSharp))
                    result = true;
                return result;
            }
        }
        virtual public bool UsesFlats
        {
            get
            {
                var result = false;
                if (this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Flat)
                    || this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.DoubleFlat))
                    result = true;
                return result;
            }
        }
        virtual public bool IsNatural
        {
            get
            {
                var result = false;
                if (this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Natural))
                    result = true;
                return result;
            }
        }


        virtual public bool IsMajor { get; set; }
        virtual public bool IsMinor { get; set; }
        virtual public int AccidentalCount { get; set; }
        virtual public string Name { get; set; }
        [Obsolete("", false)]
        public int RawValue
        {
            get
            {
                var result = 0;
                this.NoteNames.ForEach(note => result |= note.RawValue);
                return result;
            }
        }

        [JsonIgnore]
        virtual public ChordFormula Ionian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula Dorian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula Phrygian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula Lydian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula MixoLydian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula Aeolian { get; private set; }
        [JsonIgnore]
        virtual public ChordFormula Locrian { get; private set; }

        public ExplicitNoteValuesEnum ExplicitValue { get; private set; }

        #endregion

        #region Construction
        private KeySignature(NoteName key, 
            IEnumerable<NoteName> notes, 
            bool isMajor, 
            bool isMinor, 
            bool addToCatalog = true)
        {
            this.NoteName = key;
            this.NoteNames = new List<NoteName>(notes);
            this.AccidentalCount = this.NoteNames.Where(x => x.Name.EndsWith(Constants.SHARP)
                || x.Name.EndsWith(Constants.FLAT)).Count();

            if (this.NoteNames.Any(x => x.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Sharp)))
                this.ExplicitValue = ExplicitNoteValuesEnum.Sharp;
            else if (this.NoteNames.Any(x => x.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Flat)))
                this.ExplicitValue = ExplicitNoteValuesEnum.Flat;
            else
                this.ExplicitValue = ExplicitNoteValuesEnum.Natural;


            this.IsMajor = isMajor;
            this.IsMinor = isMinor;
            if (this.IsMajor || this.IsMinor)
            {
                _InternalCatalog.Add(this);
                if (addToCatalog)
                    _Catalog.Add(this);
            }
            if (this.IsMajor)
            {
                if (addToCatalog)
                    MajorKeys.Add(this);
            }
            else if (this.IsMinor)
            {
                if (addToCatalog)
                    MinorKeys.Add(this);
            }
            var majMin = this.IsMajor ? "Major" : "Minor";
            this.Name = $"{this.NoteName} {majMin}";

            Task.Run(() => this.InitAsync());
        }

        protected KeySignature() { }

        async Task InitAsync()
        {
            try
            {
                await this.SetChordsAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task SetChordsAsync()
        {
            if (this.IsMajor)
            {
                var ii = this.NoteName + Interval.Major2nd;
                var iii = this.NoteName + Interval.Major3rd;
                var IV = this.NoteName + Interval.Perfect4th;
                var V = this.NoteName + Interval.Perfect5th;
                var vi = this.NoteName + Interval.Major6th;
                var vii = this.NoteName + Interval.Major7th;

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Major7th
                        && x.Root == this.NoteName)
                    .First();

                this.Dorian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == ii)
                    .First();

                this.Phrygian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == iii)
                    .First();

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Major7th
                        && x.Root == IV)
                    .First();

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Dominant7th
                        && x.Root == V)
                    .First();

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == vi)
                    .First();

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.HalfDiminished
                        && x.Root == vii)
                    .First();

            }
            else
            {
#warning FIXME: Use harmonic minor. 
                var ii = this.NoteName + Interval.Major2nd;
                var iii = this.NoteName + Interval.Minor3rd;
                var IV = this.NoteName + Interval.Perfect4th;
                var V = this.NoteName + Interval.Perfect5th;
                var vi = this.NoteName + Interval.Minor6th;
                var vii = this.NoteName + Interval.Minor7th;

                this.Ionian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == this.NoteName)
                    .FirstOrDefault();

                this.Dorian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.HalfDiminished
                        && x.Root == ii)
                    .FirstOrDefault();

                this.Phrygian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Major7th
                        && x.Root == iii)
                    .FirstOrDefault();

                this.Lydian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == IV)
                    .FirstOrDefault();

                this.MixoLydian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Minor7th
                        && x.Root == V)
                    .FirstOrDefault();

                this.Aeolian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Major7th
                        && x.Root == vi)
                    .FirstOrDefault();

                this.Locrian = ChordFormula.Catalog
                    .Where(x => x.ChordType == ChordType.Dominant7th
                        && x.Root == vii)
                    .FirstOrDefault();
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Comparers
        class HasEnharmonicComparer : IEqualityComparer<NoteName>
        {
            public bool Equals(NoteName x, NoteName y)
            {
                bool result = false;
                if (x.RawValue == y.RawValue
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
                if (x.RawValue == y.RawValue
                    && x.Name == y.Name)
                    result = true;
                return result;

            }

            public int GetHashCode(NoteName obj)
            {
                return obj.GetHashCode();
            }
        }

        #endregion

        #region Operators
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
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.NoteName.CompareTo(b.NoteName);
            if (0 == result)
                result = a.ExplicitValue.CompareTo(b.ExplicitValue);
            if (0 == result)
            {
                result = a.NoteNames.GetHashCode().CompareTo(b.NoteNames.GetHashCode());
            }
            return result;
        }

        public static KeySignature operator +(KeySignature key, Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            var result = KeySignature.GetTransposed(key, interval);
            return result;
        }

        public static KeySignature operator -(KeySignature key, Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            var inversion = interval.GetInversion();
            var result = KeySignature.GetTransposed(key, inversion);
            return result;
        }

        public override int GetHashCode()
        {
            var result = this.NoteName.GetHashCode()
                ^ this.NoteNames.GetHashCode()
                ^ this.ExplicitValue.GetHashCode();
            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is KeySignature)
                result = this.Equals(obj as KeySignature);
            return result;
        }

        public bool Equals(KeySignature other)
        {
            var result = false;
            if (other.NoteName == this.NoteName)
                result = true;
            return result;
        }

        #endregion

        public static KeySignature GetTransposed(KeySignature key, Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            KeySignature result = null;
            if (!NoteName.TryTransposeUp(key.NoteName, interval, out var txposedNote, out var enharmonicEquivalent))
            {
                txposedNote = enharmonicEquivalent;
            }

            IEnumerable<KeySignature> catalog = null;

            if (key.IsMajor)
            {
                catalog = KeySignature.MajorKeys;
            }
            else if (key.IsMinor)
            {
                catalog = KeySignature.MinorKeys;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{MethodBase.GetCurrentMethod().Name}");
            }

            var seq = catalog.Where(x => x.NoteName.RawValue == txposedNote.RawValue);
            if (null == seq)
            {
                throw new ArgumentOutOfRangeException($"{MethodBase.GetCurrentMethod().Name}: Major key with NoteName{{{txposedNote.Name}}} does not exist");
            }
            if (1 == seq.Count())
            {
                result = seq.First();
            }
            else
            {
                result = seq.OrderBy(x => x.AccidentalCount).First();
                new object();
            }

            return result;
        }

        public bool Contains(NoteName note, out NoteName inKeyEnharmonic)
        {
            inKeyEnharmonic = null;
            var result = false;

            var explicitComparer = new IsInKeyComparer();
            if (this.NoteNames.Contains(note, explicitComparer))
                result = true;
            else
            {
                if (this.NoteNames.Contains(note, new HasEnharmonicComparer()))
                {
                    foreach (var ee in NoteName.GetEnharmonicEquivalents(note))
                    {
                        if (this.NoteNames.Contains(ee, explicitComparer))
                        {
                            inKeyEnharmonic = ee;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public bool Contains(List<NoteName> notes, out List<NoteName> blueNotes)
        {
            bool result = false;

            var nns = (from nn in this.NoteNames
                       where notes.Any(x => x.Equals(nn))
                       select nn).ToList();

            blueNotes = notes.Except(nns).ToList();

            if (nns.Count > blueNotes.Count)
            {
                if (blueNotes.Count > 0)
                {
                    new object();
                    result = true;
                }
            }

            if (nns.Count == notes.Count)
                result = true;

            return result;
        }

        public override string ToString()
        {
            return this.Name;
        }
        public IsDiatonicEnum IsDiatonic(List<NoteName> noteNames)
        {
            var result = IsDiatonicEnum.No;

            var val = 0;
            noteNames.ForEach(nn => val |= nn.RawValue);
            if (val == (this.RawValue & val))
                result = IsDiatonicEnum.Yes;

            return result;
        }

        public IsDiatonicEnum IsDiatonic(ChordFormula formula)
        {
            var result = IsDiatonicEnum.No;
            var tmpFormula = formula;
            bool isAltered = false;
            if (formula.ChordType.IsAlteredDominant)
            {
                tmpFormula = ChordFormula.Catalog.First(x => 
                    x.Root == formula.Root
                    && x.IsDominant == true);
                isAltered = true;
            }
            if (tmpFormula.RawValue == (tmpFormula.RawValue & this.RawValue))
            {
                if (!tmpFormula.NoteNames.Any(x =>
                    x.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.DoubleSharp)
                    || x.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.DoubleFlat)))
                {
                    if (tmpFormula.UsesSharps 
                        && this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Sharp))
                    {
                        result = IsDiatonicEnum.Yes;
                    }
                    else if (tmpFormula.UsesFlats 
                        && this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Flat))
                    {
                        result = IsDiatonicEnum.Yes;
                    }
                    else if (this.ExplicitValue.HasFlag(ExplicitNoteValuesEnum.Natural))
                    {
                        result = IsDiatonicEnum.Yes;
                    }
                }
            }

            return result;
        }


        public IsDiatonicEnum IsDiatonic(List<NoteName> nns, out List<NoteName> blueNotes)
        {
            var result = IsDiatonicEnum.Unknown;
            blueNotes = nns.Except(this.NoteNames,
                new NoteNameExplicitEqualityComparer())
                .ToList();
            if (0 == blueNotes.Count)
                result = IsDiatonicEnum.Yes;
            else if (blueNotes.Count < nns.Count)
                result = IsDiatonicEnum.Partially;
            else
                result = IsDiatonicEnum.No;
            return result;
        }

        static public KeySignature DetermineKey(List<ChordFormula> chords)
        {// This is questionable logic. But limited Real Book examination reveals that this is pretty widely used.
            KeySignature result = null;
            var maj = chords.FirstOrDefault(x => x.IsMajor);
            if (maj != null)
            {
                result = KeySignature.Catalog
                    .FirstOrDefault(x => x.IsMajor
                    && x.NoteName == maj.Root);
            }
            else
            {
                var min = chords.LastOrDefault(x => x.IsMinor);
                if (null != min)
                {
                    result = KeySignature.Catalog
                        .FirstOrDefault(x => x.IsMinor
                        && x.NoteName == min.Root);
                }
                else
                { // Give up
                    result = KeySignature.CMajor;
                }
            }
            return result;
        }


        [Obsolete("Get rid of this!")]
        static public bool TryDetermineKey(List<NoteName> notes,
            out KeySignature matchedKey,
            out KeySignature probableKey)
        {
            matchedKey = null;
            probableKey = null;
            var result = false;
            var keys = new List<Tuple<List<NoteName>, KeySignature>>();
            foreach (var key in KeySignature.Catalog)
            {
                var areDiatonic = key.IsDiatonic(notes, out var blueNotes);
                if (areDiatonic == IsDiatonicEnum.Yes)
                {
                    matchedKey = key;
                    result = true;
                    break;
                }
                else if (areDiatonic == IsDiatonicEnum.Partially)
                {
                    keys.Add(new Tuple<List<NoteName>, KeySignature>(blueNotes, key));
                }
                else
                {
                    keys.Add(new Tuple<List<NoteName>, KeySignature>(blueNotes, key));
                }
            }
            if (!result)
            {
                var probableTuple = keys.OrderBy(x => x.Item1)
                    .ThenBy(x => x.Item2.AccidentalCount)
                    .First();
                probableKey = probableTuple.Item2;
                result = true;
            }

            return result;
        }


        public KeySignature GetRelativeMajor()
        {
            if (this.IsMajor)
                throw new ArgumentOutOfRangeException();
            var success = NoteName.TryTransposeUp(this.NoteName, Interval.Minor3rd, out var txposedNote, out var unused);
            Debug.Assert(success);

            var result = KeySignature.MajorKeys.First(x => x.NoteName == txposedNote);
            return result;
        }
        public KeySignature GetRelativeMinor()
        {
            KeySignature result = null;
            if (this.IsMinor)
                throw new ArgumentOutOfRangeException();
            if (NoteName.TryTransposeUp(this.NoteName, Interval.Minor3rd.GetInversion(), out var txposed, out var unused))
            {
                result = KeySignature.MinorKeys.First(x => x.NoteName == txposed);
            }
            return result;
        }

        public KeySignature GetEnharmonicEquivalent()
        {
            var nns = NoteName.GetEnharmonicEquivalents(this.NoteName);
            var keys = Catalog
                .Where(x => x.NoteName.RawValue == this.NoteName.RawValue
                    && x.IsMajor == this.IsMajor).ToList();
            var result = keys.OrderBy(x => x.AccidentalCount)
                .First();
            return result;
        }

    }//class
}//ns
