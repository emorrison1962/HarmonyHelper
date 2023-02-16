using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Collections.Generic
{
    public class CircularMultiQueue<K, V> : IEnumerable<V>
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

        IEnumerator<V> IEnumerable<V>.GetEnumerator()
        {
            var count = this._DictionaryOfQueues
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Value.Count)
                .First();

            for (var i = 0; i < count; ++i)
            {
                V result = default(V);
                var reQueues = new Dictionary<Queue<V>, V>();
                foreach (var kvp in this._DictionaryOfQueues)
                {
                    Debug.WriteLine(kvp.Key);
                    var val = kvp.Value.Dequeue();
                    reQueues.Add(kvp.Value, val);
                    result = val;
                    yield return result;
                }
                new object();
                foreach (var item in reQueues)
                {//For circular queue functionality, re-queue the items.
                    item.Key.Enqueue(item.Value);
                }
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
