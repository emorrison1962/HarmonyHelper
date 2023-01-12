using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class CircularMultiQueue<K, V>
    {
        #region Properties
        Dictionary<K, Queue<V>> _DictionaryOfQueues { get; set; }
            = new Dictionary<K, Queue<V>>();

        public ReadOnlyDictionary<K, Queue<V>> DictionaryOfQueues
        {
            get { return new ReadOnlyDictionary<K, Queue<V>>(this._DictionaryOfQueues); }
        }

        public bool HasCountBeenRead { get; private set; }
        public int GetCount()
        {
            this.HasCountBeenRead = true;
            var result = this._DictionaryOfQueues
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Value.Count)
                .First();
            return result;
        }

        #endregion

        public V GetNext(K key)
        {
            V result = default(V);
            var queue = this.DictionaryOfQueues[key];
            if (queue.Count > 0)
            {
                result = queue.Dequeue();
                queue.Enqueue(result);
            }
            else
            {
                throw new ArgumentException(nameof(key));
            }
            return result;
        }


        public V this[K key]
        {
            get
            {
                V result = default(V);
                var queue = this.DictionaryOfQueues[key];
                if (queue.Count > 0)
                {
                    result = queue.Dequeue();
                    queue.Enqueue(result);
                }
                else
                {
                    throw new ArgumentException(nameof(key));
                }
                return result;
            }
        }

        public void Add(K key, Queue<V> queue)
        {
            this._DictionaryOfQueues[key] = queue;
        }

        public void Add(K key, IEnumerable<V> items)
        {
            var queue = new Queue<V>();
            var list = items.ToList();
            foreach (var item in list ) 
            { 
                queue.Enqueue(item);
            }
            this._DictionaryOfQueues[key] = queue;
        }

    }//class
}
