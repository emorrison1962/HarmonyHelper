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
                    .First();
                return result;
            }
        }

        #endregion

        public ChordSubstitutionResults() {  }

        public ChordSubstitution this[ChordMelodyPairing cmp] 
        { 
            get 
            { 
                var queue = this.Substitutions[cmp];
                var result = queue.Dequeue();
                queue.Enqueue(result);
                return result;
            } 
        }

        public void Add(ChordMelodyPairing key, Queue<ChordSubstitution> queue)
        {
            this.InternalSubstitutions[key] = queue;
            Debug.WriteLine(key);
        }
    }//class
}//ns
