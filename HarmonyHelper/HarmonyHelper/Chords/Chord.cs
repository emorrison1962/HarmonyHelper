using Eric.Morrison.Harmony.Intervals;

using HarmonyHelper.Chords;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Chords
{
    public partial class Chord : ChordEntityBase, IEquatable<Chord>, IComparable<Chord>
    {
        #region Properties

        public Note Root { get; protected set; }
        public Note? Second
        { 
            get 
            {
                Note? result = null;
                if (this.Formula.Second is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Second);
                return result;
            } 
        }
        public Note? Third
        {
            get
            {
                Note? result = null;
                if (this.Formula.Third is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Third);
                return result;
            }
        }

        public Note? Fourth
        {
            get
            {
                Note? result = null;
                if (this.Formula.Fourth is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Fourth);
                return result;
            }
        }

        public Note? Fifth
        {
            get
            {
                Note? result = null;
                if (this.Formula.Fifth is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Fifth);
                return result;
            }
        }

        public Note? Sixth
        {
            get
            {
                Note? result = null;
                if (this.Formula.Sixth is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Sixth);
                return result;
            }
        }

        public Note? Seventh
        {
            get
            {
                Note? result = null;
                if (this.Formula.Seventh is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Seventh);
                return result;
            }
        }

        public Note? Ninth
        {
            get
            {
                Note? result = null;
                if (this.Formula.Ninth is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Ninth);
                return result;
            }
        }

        public Note? Eleventh
        {
            get
            {
                Note? result = null;
                if (this.Formula.Eleventh is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Eleventh);
                return result;
            }
        }

        public Note? Thirteenth
        {
            get
            {
                Note? result = null;
                if (this.Formula.Thirteenth is not null)
                    result = this.Notes.First(x => x.NoteName == this.Formula.Thirteenth);
                return result;
            }
        }



        public ChordFormula Formula { get; private set; }
        public List<Note> Notes { get; private set; } = new List<Note>();
        public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
        public string Name
        {
            get
            {
                var root = this.Root.NoteName.ToString();
                var chordType = this.Formula.ChordType.Name();

                var result = string.Format("{0}{1}",
                    root,
                    chordType);
                return result;
            }
        }

        #endregion

        #region Construction

        public Chord SetNoteRange(NoteRange noteRange)
        {
            if (null == noteRange)
                throw new ArgumentNullException();
            this.Root = noteRange.First(this.Formula.Root);
            this.PopulateNotes(noteRange);
            return this;
        }

        public Chord(ChordFormula formula, NoteRange noteRange) : base(formula.Keys)
        {
            if (null == formula)
                throw new ArgumentNullException();
            if (null == noteRange)
                throw new ArgumentNullException();

            this.Formula = formula;
            this.NoteNames = formula.NoteNames;

            this.SetNoteRange(noteRange);
        }

        public Chord(NoteRange noteRange, Note root, params Note[] notes)
            : base(KeySignature.CMajor)
        {
            if (null == root)
                throw new ArgumentNullException();
            this.Root = root;
            this.NoteNames.Add(root.NoteName);
            this.NoteNames.AddRange(notes.Select(x => x.NoteName).ToList());

            this.PopulateNotes(noteRange);
        }

        void PopulateNotes(NoteRange noteRange)
        {
            var pendingNotes = noteRange.GetNotes(this.NoteNames);
            pendingNotes.ForEach(x => this.Notes.Add(x));
            this.Notes.Sort(new NoteComparer());
        }

        #endregion

        public void Set(NoteRange noteRange)
        {
            this.PopulateNotes(noteRange);
        }
        public bool IsValid()
        {
            var result = false;
            foreach (var key in this._Keys)
            {
                if (key.UsesFlats)
                {
                    if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsFlatted)
                        if (this.NoteNames.All(x => x.IsNatural || x.IsFlatted))
                            if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsFlatted))
                                result = true;
                }
                else if (key.UsesSharps)
                {
                    if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsSharped)
                        if (this.NoteNames.All(x => x.IsNatural || x.IsSharped))
                            if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsSharped))
                                result = true;
                }
            }
            Debug.Assert(result);
            return result;
        }

        public override string ToString()
        {
            return $"{this.Formula}";
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Chord)
                result = this.Equals(obj as Note);
            return result;
        }

        public bool Equals(Chord other)
        {
            var result = false;
            if (0 == this.CompareTo(other))
            {
                result = true;
            }
            return result;
        }

        public int CompareTo(Chord other)
        {
            var result = 0;
            var nonintersect = this.Notes.Except(other.Notes).Union(other.Notes.Except(this.Notes));
            var count = nonintersect.Count();
            if (count > 0)
            {
                result = -1;
            }
            return result;
        }

        public static bool operator ==(Chord a, Chord b)
        {
            if (a is null || b is null || a is null && b is null)
                return false;
            var result = a.CompareTo(b) == 0;
            return result;
        }
        public static bool operator !=(Chord a, Chord b)
        {
            var result = !(a == b);
            return result;
        }

        public override int GetHashCode()
        {
            var result = 0;
            this.Notes.ForEach(x => result ^= x.GetHashCode());
            return result;
        }


    }//class
}//ns
