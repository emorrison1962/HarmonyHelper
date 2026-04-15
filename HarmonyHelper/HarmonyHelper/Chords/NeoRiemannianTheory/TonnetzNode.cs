using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace HarmonyHelper.Chords.NeoRiemannianTheory
{
    public class TonnetzNode : IChordFormula, INrtChordFormula
    {
        public NrtChordFormula NrtFormula { get; set; }
        public NoteName NoteName { get; set; }
        public List<NoteName> Neighbors { get; set; } = new List<NoteName>();

        public TonnetzNode(NrtChordFormula formula, List<TonnetzNode> neighbors)
        {
            this.NrtFormula = formula;
            this.NoteName = this.NrtFormula.Root;
            PopulateNeighbors(this.NoteName);
        }

        public void PopulateNeighbors(NoteName root)
        {
            Neighbors.Clear();

            // We create a temp Major and Minor formula to find the 6 surrounding points
            var majorFormula = ChordFormula.Catalog
                .First(x => x.Root == root
                    && x.ChordType == ChordIntervalsEnum.Major);
            var major = NrtChordFormula.CreateEx(majorFormula);
            var minorFormula = ChordFormula.Catalog
                .First(x => x.Root == root
                    && x.ChordType == ChordIntervalsEnum.Minor);
            var minor = NrtChordFormula.CreateEx(minorFormula);

            // The horizontal axis (Perfect Fifths)
            Neighbors.Add(root + Interval.Perfect5th);
            Neighbors.Add(root + Interval.Perfect4th); // Down a 5th

            // The other vertices of the triangles touching this note
            Neighbors.Add(major.L.Root);
            Neighbors.Add(major.R.Root);
            Neighbors.Add(minor.L.Root);
            Neighbors.Add(minor.R.Root);
        }

        public int CompareTo(ChordFormula other)
        {
            return ((IChordFormula)this.NrtFormula).CompareTo(other);
        }

        public ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare)
        {
            return ((IChordFormula)this.NrtFormula).CompareTo(other, logicalCompare);
        }

        public bool Contains(List<NoteName> notes)
        {
            return ((IChordFormula)this.NrtFormula).Contains(notes);
        }

        override public string ToString()
        {
            return $"{this.GetType().Name}: {this.NrtFormula.Name} at {this.NoteName}";
        }

        #region IChordFormula
        public NoteName Bass => ((IChordFormula)this.NrtFormula).Bass;

        public ChordIntervalsEnum ChordType => ((IChordFormula)this.NrtFormula).ChordType;

        public bool IsDiminished => ((IChordFormula)this.NrtFormula).IsDiminished;

        public bool IsDominant => ((IChordFormula)this.NrtFormula).IsDominant;

        public bool IsHalfDiminished => ((IChordFormula)this.NrtFormula).IsHalfDiminished;

        public bool IsMajor => ((IChordFormula)this.NrtFormula).IsMajor;

        public bool IsMinor => ((IChordFormula)this.NrtFormula).IsMinor;

        public string Name => ((IChordFormula)this.NrtFormula).Name;

        public List<NoteName> NoteNames => ((IChordFormula)this.NrtFormula).NoteNames;

        public NoteName Root => ((IChordFormula)this.NrtFormula).Root;

        public NrtChordFormula L => ((INrtChordFormula)this.NrtFormula).L;

        public NrtChordFormula P => ((INrtChordFormula)this.NrtFormula).P;

        public NrtChordFormula R => ((INrtChordFormula)this.NrtFormula).R;

        NrtChordFormula INrtChordFormula.L => ((INrtChordFormula)this.NrtFormula).L;

        NrtChordFormula INrtChordFormula.P => ((INrtChordFormula)this.NrtFormula).P;

        NrtChordFormula INrtChordFormula.R => ((INrtChordFormula)this.NrtFormula).R;

        public ChordFormulaContainsEnum Contains(List<NoteName> criteria, out List<NoteName> contained, out List<NoteName> notContained)
        {
            return ((IChordFormula)this.NrtFormula).Contains(criteria, out contained, out notContained);
        }

        public bool Contains(NoteName note)
        {
            return ((IChordFormula)this.NrtFormula).Contains(note);
        }

        public ChordFormula CopyEx()
        {
            return ((IChordFormula)this.NrtFormula).CopyEx();
        }

        public bool Equals(ChordFormula other)
        {
            return ((IChordFormula)this.NrtFormula).Equals(other);
        }

        public ChordToneFunctionEnum GetRelationship(NoteName note)
        {
            return ((IChordFormula)this.NrtFormula).GetRelationship(note);
        }

        public void SetBassNote(NoteName bass)
        {
            ((IChordFormula)this.NrtFormula).SetBassNote(bass);
        }

        #endregion
    }
}//ns
