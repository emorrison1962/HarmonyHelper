using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace HarmonyHelper.Composition
{
    public enum MotifDirectionEnum
    { 
        Unknown = 0,
        Repeat = 1,
        Ascending = 2,
        Descending = 3,    
    };

    public static class MelodyFactory
    {
        static public Melody Create(ChordSequence chords)
        {
            var result = Melody.Create(chords);
            return result;
        }

    }//class

    public class ChordSequence : IEnumerable<TimedEventChordFormula>
    {
        #region Properties
        List<TimedEventChordFormula> Formulas { get; set; } = new List<TimedEventChordFormula>();

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
            this.Formulas.Add(formula);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.Formulas.GetEnumerator();
        }

        public IEnumerator<TimedEventChordFormula> GetEnumerator()
        {
            return this.Formulas.GetEnumerator();
        }
    }//class

    public class Melody
    {
        internal static Melody Create(ChordSequence chords)
        {
            foreach (var trio in chords.GetTriplets())
            {
                var chord = trio.First();
                var next = trio[1];
                var last = trio[2];

                var nns = chord.Event.NoteNames;

                var formula = chord.Event;
                var x = chord.AbsoluteStart;
                var ppm = chord.TimeContext.Rhythm.PulsesPerMeasure;
                for (int i = 0; i < ppm; ++i) 
                {
                    new object();
                }
            }
            throw new NotImplementedException();
            return null;
        }
        int CurrentStartTime { get; set; } = 0;

        int GetNextStartTime(TimedEventChordFormula[] trio)
        {
            DurationEnum.Duration_Quarter
            return -1;
        }

        int GetNextStartTime()
        {
            DurationEnum.Duration_Quarter;
        }

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
