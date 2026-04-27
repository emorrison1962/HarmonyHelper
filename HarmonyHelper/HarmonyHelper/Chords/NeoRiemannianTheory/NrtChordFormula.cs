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
    public interface INrtChordFormula
    {
        NrtChordFormula L { get; }
        NrtChordFormula P { get; }
        NrtChordFormula R { get; }
    }

    public class NrtChordFormula : IChordFormula, INrtChordFormula, IEquatable<NrtChordFormula>
    {
        public NoteName Root { get => this.Formula.Root; }
        public ChordFormula Formula { get; private set; }

        NrtChordFormula _P = null;
        NrtChordFormula _L = null;
        NrtChordFormula _R = null;

        #region Properties
        static ConcurrentDictionary<ChordFormula, NrtChordFormula> Cache = new ConcurrentDictionary<ChordFormula, NrtChordFormula>();

        public NrtChordFormula P
        {
            get
            {
                if (_P is null)
                {
                    _P = TransformP();
                }
                return _P;
            }
        }
        public NrtChordFormula L
        {
            get
            {
                if (_L is null)
                    _L = TransformL();
                return _L;
            }
        }
        public NrtChordFormula R
        {
            get
            {
                if (_R is null)
                    _R = TransformR();
                return _R;
            }
        }

        #endregion

        #region Construction

        static public NrtChordFormula CreateEx(ChordFormula formula)
        {
            if (!Cache.TryGetValue(formula, out var result))
            {
                result = new NrtChordFormula(formula);
                Cache[formula] = result;
            }
            else
            {
                new object();
            }
            return result;
        }

        NrtChordFormula(ChordFormula? formula)
        {
            if (formula is null)
                throw new ArgumentNullException(nameof(formula));
            this.Formula = formula;

            Task.Run(() => InitAsync());
        }

        async Task InitAsync()
        {
            await Task.Run(() =>
            {
                // Pre-calculate the P, L, R transformations for efficiency
                var p = this.P;
                var l = this.L;
                var r = this.R;
            });
        }

        #endregion

        ChordFormula SearchChordFormulaCatalog(NoteName root, ChordIntervalsEnum chordType)
        {
            var result = ChordFormula.Catalog
                    .Where(x => x.Root == root && x.ChordType == chordType)
                    .First();
            return result;
        }

        NrtChordFormula TransformP()
        {
            // Toggle between Major and Minor while keeping the same root
            ChordFormula formula = null;
            if (this.Formula.IsMajor)
            {
                formula = this.SearchChordFormulaCatalog(this.Formula.Root, ChordIntervalsEnum.Minor);
            }
            else
            {
                formula = this.SearchChordFormulaCatalog(this.Formula.Root, ChordIntervalsEnum.Major);
            }

            var result = NrtChordFormula.CreateEx(formula);
            this._P = result;
            return result;
        }

        NrtChordFormula TransformL()
        {
            // C Major (0,4,7) -> E Minor (4,7,11). Root 0 moves to 11 (B).
            // C Minor (0,3,7) -> Ab Major (8,0,3). Root 0 moves to 8 (Ab).
            ChordFormula formula = null;
            if (this.Formula.IsMajor)
            {
                var nn = this.Formula.Root + Interval.Major3rd; //E
                formula = this.SearchChordFormulaCatalog(nn, ChordIntervalsEnum.Minor);
            }
            else
            {
                var nn = this.Formula.Root + Interval.Minor6th; //Ab
                formula = this.SearchChordFormulaCatalog(nn, ChordIntervalsEnum.Major);
            }
            var result = NrtChordFormula.CreateEx(formula);
            return result;
        }

        NrtChordFormula TransformR()
        {
            // C Major (0,4,7) -> A Minor (9,0,4). Root 0 moves to 9 (A).
            // C Minor (0,3,7) -> Eb Major (3,7,10). Root 0 moves to 3 (Eb).
            ChordFormula formula = null;
            if (this.Formula.IsMajor)
            {
                var nn = this.Formula.Root + Interval.Major6th; //A
                formula = this.SearchChordFormulaCatalog(nn, ChordIntervalsEnum.Minor);
            }
            else
            {
                var nn = this.Formula.Root + Interval.Minor3rd; //Eb
                formula = this.SearchChordFormulaCatalog(nn, ChordIntervalsEnum.Major);
            }
            var result = NrtChordFormula.CreateEx(formula);
            return result;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Formula}";
        }

        public bool Equals(NrtChordFormula? other)
        {
            var result = this.Formula.Equals(other?.Formula);
            return result;
        }

        public override int GetHashCode()
        {
            var result = this.Formula.GetHashCode();
            return result;
        }



        #region IChordFormula
        public NoteName Bass => ((IChordFormula)this.Formula).Bass;

        public ChordIntervalsEnum ChordType => ((IChordFormula)this.Formula).ChordType;

        public bool IsDiminished => ((IChordFormula)this.Formula).IsDiminished;

        public bool IsDominant => ((IChordFormula)this.Formula).IsDominant;

        public bool IsHalfDiminished => ((IChordFormula)this.Formula).IsHalfDiminished;

        public bool IsMajor => ((IChordFormula)this.Formula).IsMajor;

        public bool IsMinor => ((IChordFormula)this.Formula).IsMinor;

        public string Name => ((IChordFormula)this.Formula).Name;

        public List<NoteName> NoteNames => ((IChordFormula)this.Formula).NoteNames;

        public int CompareTo(ChordFormula other)
        {
            return ((IChordFormula)this.Formula).CompareTo(other);
        }

        public ChordCompareResult CompareTo(ChordFormula other, bool logicalCompare)
        {
            return ((IChordFormula)this.Formula).CompareTo(other, logicalCompare);
        }

        public bool Contains(List<NoteName> notes)
        {
            return ((IChordFormula)this.Formula).Contains(notes);
        }

        public ChordFormulaContainsEnum Contains(List<NoteName> criteria, out List<NoteName> contained, out List<NoteName> notContained)
        {
            return ((IChordFormula)this.Formula).Contains(criteria, out contained, out notContained);
        }

        public bool Contains(NoteName note)
        {
            return ((IChordFormula)this.Formula).Contains(note);
        }

        public ChordFormula CopyEx()
        {
            return ((IChordFormula)this.Formula).CopyEx();
        }

        public bool Equals(ChordFormula other)
        {
            return ((IChordFormula)this.Formula).Equals(other);
        }

        override public bool Equals(object obj)
        {
            if (obj is NrtChordFormula other)
                return this.Formula.Equals(other.Formula);
            return false;
        }

        public ChordToneFunctionEnum GetRelationship(NoteName note)
        {
            return ((IChordFormula)this.Formula).GetRelationship(note);
        }

        public void SetBassNote(NoteName bass)
        {
            ((IChordFormula)this.Formula).SetBassNote(bass);
        }

        #endregion

    }//class
}//ns
