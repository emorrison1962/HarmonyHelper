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
    public class CircularQueue<T> : IEnumerable<T>
    {
        #region Properties
        Queue<T> Queue { get; set; }
        public int Count
        {
            get
            {
                var result = this.Queue.Count;
                return result;
            }
        }

        #endregion

        public T GetNext()
        {
            T result = default(T);
            var queue = this.Queue;
            if (queue.Count > 0)
            {
                result = queue.Dequeue();
                queue.Enqueue(result);
            }
            return result;
        }

        public void Add(IEnumerable<T> items)
        {
            var queue = new Queue<T>();
            var list = items.ToList();
            foreach (var item in list)
            {
                queue.Enqueue(item);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var count = this.Queue.Count();
            for (var i = 0; i < count; ++i)
            {
                T result = default(T);
                var reQueues = new List<T>();
                foreach (var item in this.Queue)
                {
                    result = this.Queue.Dequeue();
                    reQueues.Add(result);
                }
                foreach (var item in reQueues)
                {//For circular queue functionality, re-queue the items.
                    this.Queue.Enqueue(item);
                }
                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }//class
}//ns
