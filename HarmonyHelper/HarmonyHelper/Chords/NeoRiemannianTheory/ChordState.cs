
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
    public struct ChordState : IEquatable<ChordState>
    {
        #region Properties
        public NoteName Root { get; }
        public ChordIntervalsEnum ChordType { get; }
        public NrtChordFormula NrtFormula { get; set; }
        public ChordFormula Formula { get=> NrtFormula.Formula; }
        public Point GridPosition { get; } 

        #endregion

        #region Construction

        public ChordState(NoteName nn, ChordIntervalsEnum chordType, Point gridPos)
        {
            this.Root = nn;
            this.ChordType = chordType;
            var formula = ChordFormula.Catalog.First(x => (x.Root == nn && x.ChordType == chordType));
            this.NrtFormula = NrtChordFormula.CreateEx(formula);
            this.GridPosition = gridPos;
        }

        static ChordState CreateEx(NoteName nn, ChordIntervalsEnum chordType, Point gridPos)
        {
            var result = new ChordState(nn, chordType, gridPos);
            return result;
        }

        #endregion

        public override bool Equals(object obj) => obj is ChordState other && Equals(other);
        public bool Equals(ChordState other)
        {
            var result = Root.Equals(other.Root) 
                && ChordType == other.ChordType
                && GridPosition.Equals(other.GridPosition);
            return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Root, ChordType, GridPosition);
        }
        //public override string xToString() => $"{this.GetType().Name}: {NrtFormula.Name} at ({GridPosition.X}, {GridPosition.Y})";
        public override string ToString() => $"{this.GetType().Name}: Root={this.Root.NameAscii}, ChordType={this.ChordType}";
    }

}//ns

