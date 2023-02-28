using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;

using static Eric.Morrison.Harmony.NoteName;

// reference: https://dictionary.onmusic.org/appendix/topics/key-signatures

namespace Eric.Morrison.Harmony
{
    [Serializable]
    public partial class KeySignature : ClassBase
    {
        #region Properties
        virtual public NoteName NoteName { get; private set; }
        virtual public List<NoteName> NoteNames { get; private set; }
        virtual public List<NoteName> Accidentals { get { return this.NoteNames.Where(x => x.IsFlatted || x.IsSharped).ToList(); } }
        virtual public bool UsesSharps { get; private set; }
        virtual public bool UsesFlats { get; private set; }
        virtual public bool IsMajor { get; private set; }
        virtual public bool IsMinor { get; private set; }
        virtual public int AccidentalCount { get; private set; }
        virtual public string Name { get; private set; }
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

        virtual public ChordFormula Ionian { get; private set; }
        virtual public ChordFormula Dorian { get; private set; }
        virtual public ChordFormula Phrygian { get; private set; }
        virtual public ChordFormula Lydian { get; private set; }
        virtual public ChordFormula MixoLydian { get; private set; }
        virtual public ChordFormula Aeolian { get; private set; }
        virtual public ChordFormula Locrian { get; private set; }
        public ExplicitNoteValuesEnum ExplicitValue { get; private set; }

        #endregion

        #region Construction
        private KeySignature(NoteName key, 
            IEnumerable<NoteName> notes, 
            bool? usesSharps, 
            bool isMajor, 
            bool isMinor, 
            bool addToCatalog = true)
        {
            this.NoteName = key;
            this.NoteNames = new List<NoteName>(notes);
            this.AccidentalCount = this.NoteNames.Where(x => x.Name.EndsWith(Constants.SHARP)
                || x.Name.EndsWith(Constants.FLAT)).Count();

            if (usesSharps.HasValue)
            {
                if (0 < this.AccidentalCount)
                {
                    this.UsesSharps = usesSharps.Value;
                    this.UsesFlats = !usesSharps.Value;
                    if (usesSharps.Value)
                        this.ExplicitValue = ExplicitNoteValuesEnum.Sharp;
                    else
                        this.ExplicitValue = ExplicitNoteValuesEnum.Flat;
                }
                else
                {
                    this.ExplicitValue = ExplicitNoteValuesEnum.Natural;
                }

            }
            if (0 == this.NoteNames.Count)
                this.UsesFlats = false;

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

        [Obsolete("For EF.", true)]
        public KeySignature() { }

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

    }//class
}//ns
