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

#if false
namespace HarmonyHelper.Melody
{
    public class MelodyGenerator
    {
        List<TimedEventChordFormula> TimedEventChordFormulas { get; set; } = new List<TimedEventChordFormula>();
        public MusicXmlModel CreateMelody(MusicXmlModel model)
        {
            var formulas = model.GetChords();
            return this.CreateMelody(formulas);
        }

        public MusicXmlModel CreateMelody(List<TimedEventChordFormula> teFormulas)
        {
            this.TimedEventChordFormulas = teFormulas;
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

            
            foreach (var tecf in TimedEventChordFormulas)
            {
            }

            var sb = new StringBuilder();
            var firstTime = true;
            foreach (var pair in TimedEventChordFormulas.GetPairs()) 
            {
                var qqq = pair.First.IsStrongBeat;
                var ppm = pair.First.TimeContext.Rhythm.PulsesPerMeasure;
                var formula = pair.First.Event;
                var nns = formula.NoteNames;
                NoteName nnCurrent = nns[0];

                for (int i = 0; i < ppm; i++)
                {
                    var melodicMotion = MelodicMotion.GetRandom();
                    NoteName nnNext = this.GetNextNote(nnCurrent, melodicMotion, pair);
                }


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

        NoteName GetNextNote(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            NoteName result = NoteName.C;
            var first = pair.First.Event.NoteNames;
            var second = pair.Second.Event.NoteNames;

            switch (melodicMotion.MelodicMotionType)
            {
                case MelodicMotionEnum.PassingTone:
                    {
                        result = this.GetNextPassingTone(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.NeighborTone:
                    {
                        result = this.GetNextNeighborTone(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.Appoggiatura:
                    {
                        result = this.GetNextAppoggiatura(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.EscapeTone:
                    {
                        result = this.GetNextEscapeTone(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.DoubleNeighbor:
                    {
                        result = this.GetNextDoubleNeighbor(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.Anticipation:
                    {
                        result = this.GetNextAnticipation(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.PedalPoint:
                    {
                        result = this.GetNextPedalPoint(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.Suspension:
                    {
                        result = this.GetNextSuspension(currentNote, melodicMotion, pair);
                        break;
                    }
                case MelodicMotionEnum.Retardation:
                    {
                        result = this.GetNextRetardation(currentNote, melodicMotion, pair);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return result;
        }

        /// <summary>
        /// PassingTone
        /// Approached by   Left by
        /// step            step in same direction
        /// </summary>
        /// <param name="currentNote"></param>
        /// <param name="melodicMotion"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private NoteName GetNextPassingTone(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextNeighborTone(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextAppoggiatura(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextEscapeTone(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextDoubleNeighbor(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextAnticipation(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextPedalPoint(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }
        
        private NoteName GetNextSuspension(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

        private NoteName GetNextRetardation(NoteName currentNote, MelodicMotion melodicMotion, LinqExtensions.Pair<TimedEventChordFormula> pair)
        {
            throw new NotImplementedException();
        }

    }//class
}//ns

#endif
