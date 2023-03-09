using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;
using System.Reflection;
using HarmonyHelper.Chords;
using Newtonsoft.Json;
using HarmonyHelper.Interfaces;

namespace Eric.Morrison.Harmony.Chords
{
    [Serializable]
    public partial class ChordFormula : ChordEntityBase, IEquatable<ChordFormula>, IComparable<ChordFormula>, INoteNameContainer, IHasRootNoteName, IMusicalEvent<ChordFormula>, IChordFormula, IHasName
    {
        #region Properties

        [Obsolete("", false)]
        [JsonIgnore]
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
        public int SortOrder { get { return 3; } }
        virtual public NoteName Root { get; private set; }
        virtual public NoteName Bass { get; private set; }
        virtual public ChordIntervalsEnum ChordType { get; private set; }
        virtual public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
        [JsonIgnore]
        virtual public string Name { get { return this.Root.ToString() + this.ChordType.Name(); } }
        public string NameAscii { get { return this.Name.Replace("♭", "b").Replace("♯", "#"); } }


        [JsonIgnore]
        virtual public bool IsMajor 
        { 
            get 
            { 
                return this.ChordType.HasFlag(ChordIntervalsEnum.IntervalMajor3rd) 
                    && !this.ChordType.HasFlag(ChordIntervalsEnum.IntervalMinor7th); 
            } 
        }
        [JsonIgnore]
        virtual public bool IsMinor { get { return this.ChordType.HasFlag(ChordIntervalsEnum.IsMinor); } }
        [JsonIgnore]
        virtual public bool IsHalfDiminished { get { return this.ChordType.HasFlag(ChordIntervalsEnum.IsHalfDiminished); } }
        [JsonIgnore]
        virtual public bool IsDiminished { get { return this.ChordType.HasFlag(ChordIntervalsEnum.IsDiminished); } }
        [JsonIgnore]
        virtual public bool IsDominant { get { return this.ChordType.HasFlag(ChordIntervalsEnum.IsDominant); } }

        virtual public bool UsesSharps { get; private set; }
        virtual public bool UsesFlats { get; private set; }

        #endregion

        #region Construction
        [JsonConstructor]
        public ChordFormula(NoteName Root, NoteName Bass,
            ChordIntervalsEnum ChordType)
        {
            this.Root = Root;
            this.Bass = Bass;
            this.ChordType = ChordType;
        }
        ChordFormula()
        {
        }

        ChordFormula(NoteName root, ChordIntervalsEnum chordType)
        {
            if (null == root)
                throw new NullReferenceException();

            this.Root = root;
            //this.NoteNames.Add(this.Root = root);
            this.ChordType = chordType;

            foreach (var interval in this.ChordType.Intervals())
            {
                var nn = root + interval;
                Debug.Assert(nn != null);
                this.NoteNames.Add(nn);
                if (nn.IsFlatted)
                {
                    this.UsesFlats = true;
                }
                else if (nn.IsSharped)
                {
                    this.UsesSharps = true;
                }
            }
        }

        ChordFormula(ChordFormula src)
        {
            this.Root = src.Root.Copy();
            this.Bass = src.Bass?.Copy();
            foreach (var key in src._Keys)
                this._Keys.Add(key);
            this.ChordType = src.ChordType;
            foreach (var nn in src.NoteNames)
                this.NoteNames.Add(nn);
        }

        static public ChordFormula Create(NoteName root, ChordIntervalsEnum chordType)
        {
            if (null == root)
                throw new ArgumentNullException();
            if (null == chordType)
                throw new ArgumentNullException();

            var result = new ChordFormula(root, chordType);
            return result;
        }

        public ChordFormula Copy()
        {
            var result = new ChordFormula(this);
            return result;
        }

        internal static NoteName EnsureValidRoot(NoteName nn)
        {
            var result = nn;
            if (nn.AccidentalCount > 1)
            {
                result = NoteName.GetEnharmonicEquivalents(nn)
                    .OrderBy(ee => ee.AccidentalCount)
                    .First();
            }
            return result;
        }

        #endregion

        public bool Contains(NoteName note)
        {
            bool result = false;
            result = this.NoteNames.Contains(note);
            return result;
        }

        public void Add(KeySignature key)
        {
            if (null != key)
            {
                this._Keys.Add(key);
            }
        }
        public bool Contains(List<NoteName> notes)
        {
            bool result = false;

            var nns = (from nn in this.NoteNames
                       where notes.Any(x => x.Equals(nn))
                       select nn);
            if (nns.Count() == notes.Count)
                result = true;

            return result;
        }

        public bool IsSubsumedBy(ChordFormula other)
        {
            var result = false;

            if (other.Root == this.Root)
            {
                if (this.NoteNames.Count >= 4)
                {
                    if (other.Contains(this.NoteNames))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public ChordFormulaContainsEnum Contains(List<NoteName> criteria, out List<NoteName> contained, out List<NoteName> notContained)
        {
            ChordFormulaContainsEnum result = ChordFormulaContainsEnum.Unknown;

            contained = (from nn in this.NoteNames
                         where criteria.Any(x => x.Equals(nn))
                         select nn).ToList();
            notContained = criteria.Except(contained).ToList();

            if (0 == notContained.Count)
                result = ChordFormulaContainsEnum.Yes;
            else if (notContained.Count <= contained.Count)
                result = ChordFormulaContainsEnum.Partially;
            else
                result = ChordFormulaContainsEnum.No;

            return result;
        }

        public void SetBassNote(NoteName bass)
        {
            this.Bass = bass;
        }


        public ChordToneFunctionEnum GetRelationship(NoteName note)
        {
            var result = ChordToneFunctionEnum.None;
            var interval = (this.Root - note).Invert();

            if (interval == Interval.Unison)
                result = ChordToneFunctionEnum.Root;

            else if (interval == Interval.Minor2nd)
                result = ChordToneFunctionEnum.Flat9th;

            else if (interval == Interval.Major2nd)
                result = ChordToneFunctionEnum.Ninth;

            else if (interval == Interval.Augmented2nd)
                result = ChordToneFunctionEnum.Sharp9th;

            else if (interval == Interval.Minor3rd)
                result = ChordToneFunctionEnum.Minor3rd;

            else if (interval == Interval.Major3rd)
                result = ChordToneFunctionEnum.Major3rd;

            else if (interval == Interval.Diminished4th)
                result = ChordToneFunctionEnum.Flat11th;

            else if (interval == Interval.Perfect4th)
                result = ChordToneFunctionEnum.Eleventh;

            else if (interval == Interval.Augmented4th)
                result = ChordToneFunctionEnum.Augmented11th;

            else if (interval == Interval.Diminished5th)
                result = ChordToneFunctionEnum.Augmented11th;

            else if (interval == Interval.Perfect5th)
                result = ChordToneFunctionEnum.Perfect5th;

            else if (interval == Interval.Augmented5th)
                result = ChordToneFunctionEnum.Augmented5th;

            else if (interval == Interval.Minor6th)
                result = ChordToneFunctionEnum.Flat13th;

            else if (interval == Interval.Major6th)
            {
                result = ChordToneFunctionEnum.Thirteenth;
                if (this.IsDiminished)
                {
                    result = ChordToneFunctionEnum.Diminished7th;
                }
            }

            else if (interval == Interval.Diminished7th)
                result = ChordToneFunctionEnum.Diminished7th;

            else if (interval == Interval.Minor7th)
                result = ChordToneFunctionEnum.Minor7th;

            else if (interval == Interval.Major7th)
                result = ChordToneFunctionEnum.Major7th;

            else
                throw new ArgumentOutOfRangeException(nameof(interval));

            return result;
        }

        bool HasThird()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Third))
                result = true;
            return result;
        }
        bool HasFifth()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Fifth))
                result = true;
            return result;
        }
        bool HasSeventh()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Seventh))
                result = true;
            return result;
        }
        bool HasNinth()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Ninth))
                result = true;
            return result;
        }
        bool HasEleventh()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Eleventh))
                result = true;
            return result;
        }
        bool HasThirteenth()
        {
            var result = false;
            if (Interval.Unison == this.ChordType.GetInterval(ChordFunctionEnum.Thirteenth))
                result = true;
            return result;
        }


        public static ChordFormula operator +(ChordFormula chord, Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            ChordFormula result = null;

            //if (chord.Root.AccidentalCount == 2)
            //{
            //    var nn = NoteName.GetEnharmonicEquivalents(chord.Root).First();
            //    chord = new ChordFormula(nn, chord.ChordType, null);
            //}

            //var key = chord._Keys.First();

            if (NoteName.TryTransposeUp(chord.Root, interval, out var txposed, out var enharmonicEquivelent))
            {
                result = ChordFormula.Catalog
                    .FirstOrDefault(x => x.Root == txposed
                        && x.ChordType == chord.ChordType);
                if (null == result)
                {
                    var ee = NoteName
                            .GetEnharmonicEquivalents(txposed)
                            .Where(x => x.AccidentalCount == 
                                NoteName.GetEnharmonicEquivalents(txposed)
                                    .Min(x => x.AccidentalCount))
                            .First();

                    result = ChordFormula.Catalog
                        .FirstOrDefault(x => x.Root == ee
                            && x.ChordType == chord.ChordType);
                }
            }
            else
            {
                result = ChordFormula.Catalog
                    .FirstOrDefault(x => x.Root == enharmonicEquivelent
                        && x.ChordType == chord.ChordType);
            }
            return result;
        }

        public static ChordFormula operator -(ChordFormula chord, Interval interval)
        {
            if (null == interval)
                throw new ArgumentNullException(nameof(interval));
            var inversion = interval.GetInversion();
            var result = chord += inversion;
            return result;
        }

        public static ChordFormula TransposeUp(ChordFormula src, Interval interval, bool respectKey = false)
        {
            KeySignature txedKey = null;
#if false
			if (!respectKey)
			{
				//var key = src.Key.GetEnharmonicEquivalent();
				//var result = ChordFormulaFactory.Create(txedRoot, src.ChordType, key);

				var txposedList = new List<NoteName>();	
				foreach (var nn in src.NoteNames)
				{
					var success = NoteName.TryTransposeUp(nn, interval, out var txposed, out var ee);
					Debug.Assert(success);
					txposedList.Add(txposed);
				}
			}
			else
			{
				src += interval;
				txedKey = src.Key + interval;
			}
#endif
            var txedRoot = src.Root + interval;
            var result = ChordFormulaFactory.Create(txedRoot, src.ChordType);

            return result;

        }

        public override string ToString()
        {
            var bass = string.Empty;
            if (null != this.Bass)
                bass = $"/{this.Bass}";
            return $"{this.Name}{bass}: {string.Join(",", this.NoteNames)}";
        }

        public bool Equals(ChordFormula other)
        {
            var result = false;
            if (0 == this.NoteNames.Except(other.NoteNames).Count())
            {
                if (0 == other.NoteNames.Except(this.NoteNames).Count())
                {
                    //if (this.Key == other.Key)
                    result = true;
                }
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ChordFormula)
                result = this.Equals(obj as ChordFormula);
            return result;
        }
        public int CompareTo(ChordFormula other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(ChordFormula a, ChordFormula b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.Root.CompareTo(b.Root);

            if (0 == result)
            {
                result = a.NoteNames.Count.CompareTo(b.NoteNames.Count);
            }
            if (0 == result)
            {
                for (int i = 0; i < a.NoteNames.Count; ++i)
                {
                    result = a.NoteNames[i].CompareTo(b.NoteNames[i]);
                    if (0 != result)
                        break;
                }
            }

            //if (0 == result)
            //    result = a.Key.CompareTo(b.Key);
            return result;
        }
        public override int GetHashCode()
        {
            var result = this.Root.GetHashCode();
            this.NoteNames
                .OrderBy(x => x.AsciiSortValue)
                .ToList()
                .ForEach(x => result ^= x.GetHashCode());
            //result ^= this.Key.GetHashCode();
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

        public ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare)
        {
            var result = new ChordCompareResult(this, other);

            var tones = this.NoteNames.Select(x => new ChordTone(this, x));
            var otherTones = other.NoteNames.Select(x => new ChordTone(other, x));

            var common = other.NoteNames.Intersect(this.NoteNames).ToList();


            result.CommonTones = common;
            var otherExcept = other.NoteNames.Except(this.NoteNames).Select(x => new ChordTone(other, x)).ToList();
            var thisExcept = this.NoteNames.Except(other.NoteNames).Select(x => new ChordTone(this, x)).ToList();

            var diff = new List<ChordTone>(otherExcept);
            diff.AddRange(thisExcept);

            result.DifferingTones = diff;

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

        KeySignature DetermineKey()
        {
            KeySignature result = null;
            if (this.IsDominant)
            {
                result = KeySignature.InternalCatalog
                    .FirstOrDefault(x => x.NoteName ==
                        this.Root + Interval.Perfect4th);
            }
            else if (this.IsHalfDiminished)
            {
                result = KeySignature.InternalCatalog.Where(x => x.IsMinor)
                    .FirstOrDefault(x => x.NoteName ==
                        this.Root + Interval.Major2nd);
            }
            else
            {
                //Debug.WriteLine($"Unable to determine key for: {this.ToString()}");
            }
            return result;
        }

    }//class
}//ns
