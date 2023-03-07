using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Intervals;

using Newtonsoft.Json;

namespace Eric.Morrison.Harmony.Chords
{
    public static partial class Extensions
    {
        public static IEnumerable<T> UnionEx<T>(this List<T> src,
            params T[] addl)
        {
            var result = src.Union(addl);
            return result;
        }
    }

    [Obsolete("", true)]
    public class ChordType : ClassBase, IEquatable<ChordType>, IChordType
    {
        #region Statics
        static public List<ChordType> Catalog { get; set; } = new List<ChordType>();
        static public ChordType None = new ChordType("None",
            ChordToneInterval.None);
        static public ChordType Augmented = new ChordType("aug",
            ChordToneInterval.Major3rd,
            ChordToneInterval.Augmented5th);
        static public ChordType Diminished = new ChordType("dim",
            ChordToneInterval.Minor3rd,
            ChordToneInterval.Diminished5th);
        static public ChordType HalfDiminished = new ChordType("m7b5",
            Diminished.Intervals.UnionEx(
                new[] { ChordToneInterval.Minor7th }));
        static public ChordType Diminished7 = new ChordType("dim7",
            Diminished.Intervals.UnionEx(
                new[] { ChordToneInterval.Diminished7th }));


        #region Suspended chords
        static public ChordType Sus2 = new ChordType("Sus2",
            ChordToneInterval.Sus2, ChordToneInterval.Perfect5th);
        static public ChordType SevenSus2 = new ChordType("7Sus2",
            Sus2.Intervals.UnionEx(ChordToneInterval.Minor7th));
        static public ChordType Sus4 = new ChordType("Sus4",
            ChordToneInterval.Sus4, ChordToneInterval.Perfect5th);
        static public ChordType SevenSus4 = new ChordType("7Sus4",
            Sus4.Intervals.UnionEx(ChordToneInterval.Minor7th));
        static public ChordType Sus2Sus4 = new ChordType("Sus2Sus4",
            Sus2.Intervals.UnionEx(ChordToneInterval.Sus4));
        #endregion


        #region Diatonic Minor chords

        static public ChordType Minor = new ChordType("m",
            ChordToneInterval.Minor3rd, ChordToneInterval.Perfect5th);
        static public ChordType Minor7th = new ChordType("m7",
            Minor.Intervals.UnionEx(ChordToneInterval.Minor7th));
        static public ChordType MinorMaj7th = new ChordType("mM7",
            Minor.Intervals.UnionEx(ChordToneInterval.Major7th));
        static public ChordType MinorMaj7thAug5 = new ChordType("mMaj7aug5",
            ChordToneInterval.Minor3rd, ChordToneInterval.Augmented5th, ChordToneInterval.Major7th);
        static public ChordType Minor6th = new ChordType("m6",
            Minor.Intervals.UnionEx(ChordToneInterval.Major6th));
        static public ChordType Minor9th = new ChordType("m9",
            Minor7th.Intervals.UnionEx(ChordToneInterval.Ninth));
        static public ChordType Minor11th = new ChordType("m11",
            Minor9th.Intervals.UnionEx(ChordToneInterval.Eleventh));
        static public ChordType Minor13th = new ChordType("m13",
            Minor11th.Intervals.UnionEx(ChordToneInterval.Thirteenth));
        static public ChordType MinorAdd9 = new ChordType("mAdd9",
            Minor.Intervals.UnionEx(ChordToneInterval.Ninth));

        #endregion


        #region Diatonic Major chords
        static public ChordType Major = new ChordType("Maj",
            ChordToneInterval.Major3rd, ChordToneInterval.Perfect5th);
        static public ChordType Major6th = new ChordType("6",
            Major.Intervals.UnionEx(ChordToneInterval.Major6th));
        static public ChordType Major7th = new ChordType("Maj7",
            Major.Intervals.UnionEx(ChordToneInterval.Major7th));
        static public ChordType Major9th = new ChordType("Maj9",
            Major7th.Intervals.UnionEx(ChordToneInterval.Ninth));
        static public ChordType Major11th = new ChordType("Maj11",
            Major9th.Intervals.UnionEx(ChordToneInterval.Eleventh));
        static public ChordType Major13th = new ChordType("Maj13",
            Major11th.Intervals.UnionEx(ChordToneInterval.Thirteenth));
        static public ChordType MajorAdd9 = new ChordType("Add9",
            Major.Intervals.UnionEx(ChordToneInterval.Ninth));
        static public ChordType MajorMu = new ChordType("MajMu",
            Major.Intervals.UnionEx(ChordToneInterval.Ninth));
        static public ChordType Major7b5 = new ChordType("Maj7b5",
            ChordToneInterval.Major3rd, ChordToneInterval.Diminished5th, ChordToneInterval.Major7th);
        static public ChordType Major7Aug5 = new ChordType("Maj7aug5",
            ChordToneInterval.Major3rd, ChordToneInterval.Augmented5th, ChordToneInterval.Major7th);

        #endregion


        #region Diatonic Dominant7 chords
        static public ChordType Dominant7th = new ChordType("7",
            Major.Intervals.UnionEx(ChordToneInterval.Minor7th));
        static public ChordType Dominant9th = new ChordType("9",
            Dominant7th.Intervals.UnionEx(ChordToneInterval.Ninth));
        static public ChordType Dominant11th = new ChordType("11",
            Dominant9th.Intervals.UnionEx(ChordToneInterval.Eleventh));
        static public ChordType Dominant13th = new ChordType("13",
            Dominant11th.Intervals.UnionEx(ChordToneInterval.Thirteenth));
        static public ChordType Major13Aug11th = new ChordType("13",
            Dominant9th.Intervals.UnionEx(
            ChordToneInterval.Augmented11th,
            ChordToneInterval.Thirteenth));
        #endregion


        #region Altered Dominant7 chords
        static public ChordType Dominant7b5 = new ChordType("7b5",
            new[]{ ChordToneInterval.Major3rd,
            ChordToneInterval.Diminished5th,
            ChordToneInterval.Minor7th}, true);
        static public ChordType Dominant7Aug = new ChordType("7+",
            new[]{ ChordToneInterval.Major3rd,
            ChordToneInterval.Augmented5th,
            ChordToneInterval.Minor7th }, true);
        static public ChordType Dominant7b9 = new ChordType("7b9",
            Dominant7th.Intervals.UnionEx(
            ChordToneInterval.Flat9th), true);
        static public ChordType Dominant7Sharp9 = new ChordType("7sharp9",
            Dominant7th.Intervals.UnionEx(ChordToneInterval.Sharp9th), true);
        #endregion


        #endregion

        #region Properties
        virtual public string Name { get; private set; }
        virtual public int Value { get; private set; }
        virtual public List<ChordToneInterval> Intervals { get; private set; } = new List<ChordToneInterval>();

        virtual public bool IsMajor { get; private set; }
        virtual public bool IsMinor { get; private set; }
        virtual public bool IsDiminished { get; private set; }
        virtual public bool IsHalfDiminished { get; private set; }
        virtual public bool IsDominant { get; private set; }
        virtual public bool IsAlteredDominant { get; private set; }

        #endregion

        #region Construction
        [JsonConstructor]
        public ChordType(string Name, int Value, List<ChordToneInterval> Intervals,
            bool IsMajor, bool IsMinor, bool IsDiminished,
            bool IsHalfDiminished, bool IsDominant, bool IsAlteredDominant, int Id)
        {
            this.Name = Name;
            this.Value = Value;
            this.Intervals = Intervals;
            this.IsMajor = IsMajor;
            this.IsMinor = IsMinor;
            this.IsDiminished = IsDiminished;
            this.IsHalfDiminished = IsHalfDiminished;
            this.IsDominant = IsDominant;
            this.IsAlteredDominant = IsAlteredDominant;
            this.Id = Id;
        }
        protected ChordType() { }
        private ChordType(string name, params ChordToneInterval[] intervals)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            this.Name = name;
            this.Intervals.AddRange(intervals);
            this.Intervals.ForEach(x => this.Value |= x.Value);
            if (!this.Intervals.Contains(ChordToneInterval.None))
                Catalog.Add(this);
            this.Init();
        }

        private ChordType(string name,
            IEnumerable<ChordToneInterval> intervals,
            bool isAlteredDominant = false)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            this.Name = name;
            this.Intervals.AddRange(intervals);
            this.Intervals.ForEach(x => this.Value |= x.Value);
            if (isAlteredDominant)
                this.IsAlteredDominant = true;
            if (!this.Intervals.Contains(ChordToneInterval.None))
                Catalog.Add(this);
            this.Init();
        }

        void Init()
        {
            if (!this.Intervals.Contains(ChordToneInterval.None))
            {
                if (this.Intervals.Contains(ChordToneInterval.Major3rd)
                    //&& this.Intervals.Contains(ChordToneInterval.Perfect5th)
                    && !this.Intervals.Contains(ChordToneInterval.Minor7th))
                {
                    this.IsMajor = true;
                }
                if (this.Intervals.Contains(ChordToneInterval.Minor3rd)
                    && this.Intervals.Contains(ChordToneInterval.Perfect5th))
                {
                    this.IsMinor = true;
                }

                if (this.Intervals.Contains(ChordToneInterval.Minor3rd)
                    && (this.Intervals.Contains(ChordToneInterval.Diminished5th)
                        && this.Intervals.Contains(ChordToneInterval.Minor7th)))
                {
                    this.IsHalfDiminished = true;
                }

                if (this.Intervals.Contains(ChordToneInterval.Minor3rd)
                    && (this.Intervals.Contains(ChordToneInterval.Diminished5th)
                        && this.Intervals.Contains(ChordToneInterval.Diminished7th)))
                {
                    this.IsDiminished = true;
                }

                if (this.Intervals.Contains(ChordToneInterval.Major3rd)
                    && this.Intervals.Contains(ChordToneInterval.Minor7th))
                {
                    this.IsDominant = true;
                }
            }
        }

        #endregion

        #region Operators
        public static int operator |(ChordType a, ChordType b)
        {
            var result = a.Value | b.Value;
            return result;
        }

        public static explicit operator int(ChordType ct)
        {
            return ct.Value;
        }

        #endregion

        #region IEquatable, IComparable
        public bool Equals(ChordType other)
        {
            var result = false;
            if (0 == this.Intervals.Except(other.Intervals).Count())
            {
                if (0 == other.Intervals.Except(this.Intervals).Count())
                {
                    result = true;
                }
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ChordType)
                result = this.Equals(obj as ChordType);
            return result;
        }
        public int CompareTo(ChordType other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(ChordType a, ChordType b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.Value.CompareTo(b.Value);

            if (0 == result)
            {
                result = a.Name.CompareTo(b.Name);
            }
            if (0 == result)
            {
                result = a.Value.CompareTo(b.Value);
            }
            if (0 == result)
            {
                result = a.IsMajor.CompareTo(b.IsMajor);
            }
            if (0 == result)
            {
                result = a.IsMinor.CompareTo(b.IsMinor);
            }
            if (0 == result)
            {
                result = a.IsDiminished.CompareTo(b.IsDiminished);
            }
            if (0 == result)
            {
                result = a.IsHalfDiminished.CompareTo(b.IsHalfDiminished);
                                        }
            if (0 == result)
            {
                result = a.IsDominant.CompareTo(b.IsDominant);
            }
            if (0 == result)
            {
                result = a.IsAlteredDominant.CompareTo(b.IsAlteredDominant);
            }

            if (0 == result)
            {
                result = a.Intervals.Count.CompareTo(b.Intervals.Count);
            }
            if (0 == result)
            {
                for (int i = 0; i < a.Intervals.Count; ++i)
                {
                    result = a.Intervals[i].CompareTo(b.Intervals[i]);
                    if (0 != result)
                        break;
                }
            }

            return result;
        }
        public override int GetHashCode()
        {
            var result = this.Value.GetHashCode();
            this.Intervals
                .OrderBy(x => x.FunctionalValue)
                .ToList()
                .ForEach(x => result ^= x.GetHashCode());
            return result;
        }
        public static bool operator ==(ChordType a, ChordType b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(ChordType a, ChordType b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        #region Used to be IntervalsEnumExtensions
        public Interval GetInterval(ChordFunctionEnum cfe)
        {
            if (0 == this.Intervals.Count)
                throw new Exception("this.Intervals not initialized.");
            var result = ChordToneInterval.None;

            Predicate<ChordToneInterval> predicate = null;

            switch (cfe)
            {
                case ChordFunctionEnum.Root:
                case ChordFunctionEnum.None:
                    break;

                case ChordFunctionEnum.Sus2:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd;
                    break;

                case ChordFunctionEnum.Third:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor3rd || x == ChordToneInterval.Major3rd;
                    break;

                case ChordFunctionEnum.Sus4:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th;
                    break;

                case ChordFunctionEnum.Fifth:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect5th || x == ChordToneInterval.Diminished5th || x == ChordToneInterval.Augmented5th;
                    break;

                case ChordFunctionEnum.Seventh:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Minor7th || x == ChordToneInterval.Major7th || x == ChordToneInterval.Diminished7th;
                    break;

                case ChordFunctionEnum.Ninth:
                    //throw new NotImplementedException("#9 ???");
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major2nd || x == ChordToneInterval.Minor2nd;
                    break;

                case ChordFunctionEnum.Eleventh:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Perfect4th || x == ChordToneInterval.Augmented4th;
                    break;

                case ChordFunctionEnum.Thirteenth:
                    predicate = (ChordToneInterval x) => x == ChordToneInterval.Major6th || x == ChordToneInterval.Minor6th;
                    break;
            }

            if (null != predicate)
            {
                var found = this.Intervals.FirstOrDefault(x => predicate(x));
                if (null != found)
                    result = found;
            }

            return result;
        }
        #endregion

        public override string ToString()
        {
            return this.Name;
            return $"{this.GetType().Name}: Name={this.Name}";
        }

    }//class
}//ns
