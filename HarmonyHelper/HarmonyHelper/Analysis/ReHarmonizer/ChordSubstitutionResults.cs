using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ChordSubstitutionResults : IEnumerable<ChordSubstitution>
    {
        public Dictionary<ChordMelodyPairing, Queue<ChordSubstitution>> Substitutions { get; set; } = new Dictionary<ChordMelodyPairing, Queue<ChordSubstitution>>();
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

        public IEnumerator<ChordSubstitution> GetEnumerator()
        {
            var result = this.Substitutions
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Value)
                .First()
                .GetEnumerator();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

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
    }//class
}//ns
