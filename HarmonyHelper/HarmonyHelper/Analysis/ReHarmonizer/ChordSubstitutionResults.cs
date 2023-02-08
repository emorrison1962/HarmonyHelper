using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException("FIXME");
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

        public void Add(ChordMelodyPairing cmp, Queue<ChordSubstitution> queue)
        {
            var list = queue.OrderBy(x => x.Original.GetRelationship(x.Substitution.Root));
            var q = new Queue<ChordSubstitution>(list);

            this.InternalSubstitutions[cmp] = q;
            //Debug.WriteLine(cmp);
        }
    }//class

}//ns
