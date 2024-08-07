using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.MusicXml;

#if false
https://www.edmprod.com/advanced-melodies-chord-tones-motifs/
#endif

namespace HarmonyHelper.Melody
{
    public class MelodyGenerator
    {
        List<TimedEventChordFormula> ChordFormulas { get; set; } = new List<TimedEventChordFormula>();
        public MusicXmlModel CreateMelody(MusicXmlModel model)
        {
            var formulas = model.GetChords();
            return this.CreateMelody(formulas);
        }

        public MusicXmlModel CreateMelody(List<TimedEventChordFormula> teFormulas)
        {
            this.ChordFormulas = teFormulas;
            this.Analyze();
            return null;
        }

        void Analyze()
        {
            /*
            • Avoid octaves.
            • Prefer m2 chord resolutions.
            • Enjoy paralell 6ths.
            • 1.5 octave vocal range.
            • https://musictheory.pugetsound.edu/mt21c/NonChordTonesIntroduction.html
            • Use directional patterns.
            • So to conclude, our Stepwise Melody Rule is to have no more than three stepwise notes in your melodies.

             */

            var sb = new StringBuilder();
            var firstTime = true;
            foreach (var pair in ChordFormulas.GetPairs()) 
            {
                var qqq = pair.First.IsStrongBeat;

                sb.AppendLine();
                sb.AppendFormat($"    {{0, -20}}{Environment.NewLine}", pair.First.Event);
                if (firstTime) 
                {
                    firstTime = false;
                    sb.Append($"| X m2 ");
                }
                else 
                {
                    sb.Append($"| Y P4 ");
                }

                var list = new List<IntervalContext>();
                foreach (var nn01 in pair.First.Event.NoteNames) 
                {
                    foreach (var nn02 in pair.Second.Event.NoteNames)
                    {
                        var ctx = new IntervalContext(nn01, nn02);
                        list.Add(ctx);
                    }
                }
                var minCtx = list
                    .Where(x => x.Interval > Interval.Unison)
                    .MinBy(x => x.Interval.Value);
                Debug.Assert(null != minCtx);

                sb.Append(@$" {minCtx.NoteNameFirst} > {minCtx.NoteNameSecond} ({minCtx.Interval.Name})  ");
                list.Clear();
            }
            Debug.WriteLine(sb.ToString());
            new object();
        }

    }//class

    class IntervalContext
    {
        public NoteName NoteNameFirst { get; set; }
        public NoteName NoteNameSecond { get; set; }
        public Interval Interval { get; set; }
        public IntervalContext(NoteName nnFirst, NoteName nnSecond)
        {
            this.NoteNameFirst = nnFirst;
            this.NoteNameSecond = nnSecond;
            var tmpInterval = nnFirst - nnSecond;
            this.Interval = Interval.Min(tmpInterval, tmpInterval.GetInversion());
        }
    }

    abstract class MelodicMotionBase
    { 
    }

    class PassingTone : MelodicMotionBase
    { 
    }


}//ns
