using System;
using System.Collections.Generic;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
    public class ChordType : ClassBase
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

        [Obsolete("Used by EF.", true)]
        public ChordType()
        {
            
        }
        private ChordType(string name, params ChordToneInterval[] intervals)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            this.Name = name;
            this.Intervals.AddRange(intervals);
            this.Intervals.ForEach(x => this.Value |= x.Value);
            if (!this.Intervals.Contains(ChordToneInterval.None))
                Catalog.Add(this);
            //this.Init();
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
            //this.Init();
        }


    }//class
}//ns
