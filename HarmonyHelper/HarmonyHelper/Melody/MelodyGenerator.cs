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

namespace HarmonyHelper.Melody
{
    public class MelodyGenerator
    {
        List<ChordFormula> ChordFormulas { get; set; } = new List<ChordFormula>();
        public MusicXmlModel CreateMelody(string chords)
        {
            var formulas = ChordFormulaParser.Parse(chords);
            return this.CreateMelody(formulas);
        }

        public MusicXmlModel CreateMelody(List<ChordFormula> formulas)
        { 
            this.ChordFormulas= formulas;
            this.Analyze();
            return null;
        }

        void Analyze()
        { 
            var sb = new StringBuilder();
            var firstTime = true;
            foreach (var pair in ChordFormulas.GetPairs()) 
            {
                sb.AppendLine();
                sb.AppendFormat($"    {{0, -20}}{Environment.NewLine}", pair.First.Name);
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
                foreach (var nn01 in pair.First.NoteNames) 
                {
                    foreach (var nn02 in pair.Second.NoteNames)
                    {
                        var ctx = new IntervalContext(nn01, nn02);
                        list.Add(ctx);
                    }
                }
                var minCtx = list
                    .Where(x => x.Interval > Interval.Unison)
                    .MinBy(x => x.Interval.Value);

                sb.Append(@$" {minCtx.NoteNameFirst} | {minCtx.NoteNameSecond} {minCtx.Interval.Name}  ");
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

}//ns
