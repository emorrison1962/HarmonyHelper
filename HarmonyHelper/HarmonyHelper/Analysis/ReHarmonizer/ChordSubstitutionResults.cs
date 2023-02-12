using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Eric.Morrison.Harmony.Constants;
using static Eric.Morrison.Harmony.LinqExtensions;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ChordSubstitutionResults
    {
        #region Properties
        Dictionary<ChordMelodyPairing, Queue<ChordSubstitution>> InternalSubstitutions { get; set; } = new Dictionary<ChordMelodyPairing, Queue<ChordSubstitution>>();

        public ReadOnlyDictionary<ChordMelodyPairing, Queue<ChordSubstitution>> Substitutions
        {
            get { return new ReadOnlyDictionary<ChordMelodyPairing, Queue<ChordSubstitution>>(this.InternalSubstitutions); }
        }

        public int Count
        {
            get
            {
                var result = this.Substitutions
                    .OrderByDescending(x => x.Value.Count)
                    .Select(x => x.Value.Count)
                    .FirstOrDefault();
                return result;
            }
        }

        #endregion

        public ChordSubstitutionResults()
        {
            Debug.Assert(false, "FIXME");
        }

        public ChordSubstitution this[ChordMelodyPairing cmp]
        {
            get
            {
                ChordSubstitution result = null;
                var queue = this.Substitutions[cmp];

                Func<ChordSubstitution, ChordMelodyPairing> orderBy = (key) =>
                {
                    return null;
                };

                var ordered = queue.OrderBy(orderBy).ToList();

                if (queue.Count > 0)
                {
                    result = queue.Dequeue();
                    queue.Enqueue(result);
                }
                else
                {
                    result = new ChordSubstitution(cmp.Formula,
                        cmp.Formula, cmp.TimeContext);
                }
                return result;
            }
        }

        public void Add(ChordMelodyPairing cmp, List<ChordSubstitution> list)
        {
            throw new NotImplementedException("The substitutions need to be ordered in a way make Musical sense.");
            list = list.OrderBy(x => x.Substitution.Root)
                .ToList();

            var qq = list.Where(x => x.Substitution.IsMinor || x.Substitution.IsDominant)
                .OrderBy(x => x.Substitution.Root)
                .ThenByDescending(x => x.Substitution.IsMinor)
                .ThenByDescending(x => x.Substitution.IsDominant)
                .ToList();

            var tuples = new List<ValueTuple<ChordSubstitution, ChordSubstitution>>();

            var sortedList = new List<ChordSubstitution>();
            var distinctNNs = list.Select(x => x.Substitution)
                .Select(x => x.Root)
                .Distinct(new NoteNameAlphaEqualityComparer()).ToList();

            //for (int i = 0; i < list.Count; i++)
            //while(list.Count() > 20)
            {
                var cf1 = list.First();
                var PERFECT_4THs = list
                    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Perfect4th).ToList();
                list.ForEach(x => Debug.WriteLine(x.Substitution));
                var dominants = list
                    .Where(x => x.Substitution.IsDominant)
                    .OrderBy(x => x.Substitution.Root).ToList();
                list.RemoveAll(x => x.Substitution.IsDominant);

                foreach (var nn in distinctNNs)
                {
                    PERFECT_4THs = list
                        .Where(x => nn - x.Substitution.Root == Interval.Perfect4th).ToList();
                    foreach (var item in PERFECT_4THs) 
                    {
                        Debug.WriteLine(item.Substitution);
                        list.Remove(item);
                    }
                }
                new object();
                //var UNISONs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Unison).ToList();
                //var MINOR_2NDs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Minor2nd).ToList(); 
                //var MAJOR_2NDs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Major2nd).ToList();
                //var MINOR_3RDs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Minor3rd).ToList();
                //var MAJOR_3RDs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Major3rd).ToList();
                //var AUGMENTED_4THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Augmented4th).ToList();
                //var DIMINISHED_5THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Diminished5th).ToList();
                //var PERFECT_5THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Perfect5th).ToList();
                //var AUGMENTED_5THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Augmented5th).ToList();
                //var MINOR_6THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Minor6th).ToList();
                //var MAJOR_6THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Major6th).ToList();
                //var DIMINISHED_7THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Diminished7th).ToList();
                //var MINOR_7THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Minor7th).ToList();
                //var MAJOR_7THs = list
                //    .Where(x => cf1.Substitution.Root - x.Substitution.Root == Interval.Major7th).ToList();

                var pair = ValueTuple.Create(cf1, PERFECT_4THs.First());
                tuples.Add(pair);
                list.Remove(pair.Item1);
                list.Remove(pair.Item2);

                var chords = new List<ChordFormula>() { cf1.Substitution, 
                    PERFECT_4THs.First().Substitution };
                var sw = Stopwatch.StartNew();
                var result = HarmonicAnalyzer.Analyze(chords);
                sw.Stop();
                Debug.WriteLine($"{sw.ElapsedMilliseconds} ms, {sw.ElapsedTicks} ticks");
                result.ForEach(x => Debug.WriteLine(x.ToString()));
                new object();

                //is ii V
                //is Diatonic
                //

            }



            var q = new Queue<ChordSubstitution>(list);

            this.InternalSubstitutions[cmp] = q;
            //Debug.WriteLine(cmp);
        }
    }//class

}//ns
