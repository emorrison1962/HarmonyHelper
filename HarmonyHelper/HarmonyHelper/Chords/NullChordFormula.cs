
using System.ComponentModel;

namespace Eric.Morrison.Harmony.Chords
{
    class NullChordFormula : ChordFormula
    {
        static public readonly NullChordFormula Instance = new NullChordFormula();
        public override IEnumerable<KeySignature> Keys => base.Keys;

        public override NoteName Root => base.Root;

        public override NoteName Bass => base.Bass;

        public override ChordIntervalsEnum ChordType => base.ChordType;

        public override List<NoteName> NoteNames => base.NoteNames;

        public override string Name => string.Empty;

        public override bool IsMajor => base.IsMajor;

        public override bool IsMinor => base.IsMinor;

        public override bool IsHalfDiminished => base.IsHalfDiminished;

        public override bool IsDiminished => base.IsDiminished;

        public override bool IsDominant => base.IsDominant;

        public override bool UsesSharps => base.UsesSharps;

        public override bool UsesFlats => base.UsesFlats;

        protected override HashSet<KeySignature> _Keys { get => base._Keys; set => base._Keys = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}//ns
