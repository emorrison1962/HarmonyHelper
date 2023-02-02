using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Collections.Generic
{
    public class CircularMultiQueue<K, V> : IEnumerable<List<V>>
    {
        #region Properties
        Dictionary<K, Queue<V>> _DictionaryOfQueues { get; set; }
            = new Dictionary<K, Queue<V>>();

        public ReadOnlyDictionary<K, Queue<V>> DictionaryOfQueues
        {
            get { return new ReadOnlyDictionary<K, Queue<V>>(this._DictionaryOfQueues); }
        }


        public int Count
        {
            get
            {
                var result = this._DictionaryOfQueues
                    .OrderByDescending(x => x.Value.Count)
                    .Select(x => x.Value.Count)
                    .First();
                return result;
            }
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
            foreach (var item in list)
            {
                queue.Enqueue(item);
            }
            this._DictionaryOfQueues[key] = queue;
        }

        IEnumerator<List<V>> IEnumerable<List<V>>.GetEnumerator()
        {
            var count = this._DictionaryOfQueues
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Value.Count)
                .First();

            var result = new List<V>();
            for (var i = 0; i < count; ++i)
            {
                result.Clear();
                var reQueues = new Dictionary<Queue<V>, V>();
                foreach (var q in this._DictionaryOfQueues.Values)
                {
                    var val = q.Dequeue();
                    reQueues.Add(q, val);
                    result.Add(val);
                }
                foreach (var item in reQueues)
                {//For circular queue functionality, re-queue the items.
                    item.Key.Enqueue(item.Value);
                }
                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //}
    }//class
}
