using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony;
using System.Reflection;
using HarmonyHelper.Chords;

namespace Eric.Morrison.Harmony.Chords
{
    [Serializable]
    public partial class ChordFormula : ChordEntityBase
    {
        #region Properties

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
        public int SortOrder { get { return 3; } }
        virtual public NoteName Root { get; private set; }
        virtual public NoteName Bass { get; private set; }
        virtual public ChordType ChordType { get; private set; }
        virtual public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
        virtual public string Name { get { return this.Root.ToString() + this.ChordType.Name; } }

        virtual public bool IsMajor { get { return this.ChordType.IsMajor; } }
        virtual public bool IsMinor { get { return this.ChordType.IsMinor; } }
        virtual public bool IsHalfDiminished { get { return this.ChordType.IsHalfDiminished; } }
        virtual public bool IsDiminished { get { return this.ChordType.IsDiminished; } }
        virtual public bool IsDominant { get { return this.ChordType.IsDominant; } }

        virtual public bool UsesSharps { get; private set; }
        virtual public bool UsesFlats { get; private set; }

        #endregion

        #region Construction

        [Obsolete("Used by EF.", true)]
        public ChordFormula()
        {
        }

        public ChordFormula(NoteName root, ChordType chordType, KeySignature key)
            : base(key)
        {
            if (null == root)
                throw new NullReferenceException();

            this.NoteNames.Add(this.Root = root);
            this.ChordType = chordType;

            foreach (var interval in this.ChordType.Intervals)
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

        public ChordFormula(ChordFormula src)
        {
            this.Root = src.Root;
            this.Bass = src.Bass;
            this.Keys = src.Keys;
            this.ChordType = src.ChordType;
            this.NoteNames = src.NoteNames;
        }

        public ChordFormula Copy()
        {
            var result = new ChordFormula(this);
            return result;
        }
        [Obsolete("", true)]
        public static ChordFormula Copy(ChordFormula src)
        {
            var result = new ChordFormula(src);
            return result;
        }

        #endregion


    }//class
}//ns
