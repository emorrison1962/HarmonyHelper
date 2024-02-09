using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace HarmonyHelper.Composition
{
    [Flags]
    public enum MotifDirectionEnum
    { 
        Unknown = 0,
        None = 1,
        Ascending = 1 << 1,
        Descending = 1 << 2,    
    };

    public static class MelodyFactory
    {
        static public Melody Create(ChordSequence chords)
        { 
            var result = new Melody();
            return result;
        }

    }//class

    public class ChordSequence : IEnumerable<TimedEventChordFormula>
    {
        #region Properties
        Dictionary<int, TimedEventChordFormula> Formulas { get; set; } = new Dictionary<int, TimedEventChordFormula>();

        public int Count { get { return this.Formulas.Count; } }
        #endregion

        #region Construction
        public ChordSequence() { }

        public static ChordSequence Create(IList<TimedEventChordFormula> formulas)
        {
            var result = new ChordSequence();
            foreach (var formula in formulas)
            {
                result.Add(formula);
            }
            return result;
        }

        #endregion
        
        private void Add(TimedEventChordFormula formula)
        {
            if (this.Formulas.ContainsKey(formula.AbsoluteStart))
                new object();
            this.Formulas.Add(formula.AbsoluteStart, formula);
        }

        public IEnumerator<TimedEventChordFormula> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Formulas.GetEnumerator();
        }
    }//class

    public class Melody
    {
    }//class


    /*
     MelodyFactory (ChordSequence, Length)

    Melody
    Key
    CurrentChord
    NextChord
    //Direction: Ascending, Descending, Flat
    Beat

    Motion: Scalar, Chordal
    ScaleTone
    ChordTone
    IsScaleTone
    IsChordTone

    Rhythm
    Motif: DDA, DAD, ADD, DDD, AAA, DAA, ADA, AAD,...

    PreviousNote
    NextNote

    NextInterval
    PreviousInterval

    NextHarmonicNavigation

    Use Case: CreateMelody

    appoggiatura vs acciaccatura

     * */

}//ns
