using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MeasureList : IList<Measure>, ICollection<Measure>, IEnumerable<Measure>, IEnumerable, IList, ICollection, IReadOnlyList<Measure>, IReadOnlyCollection<Measure>
    {
        #region Properties
        List<Measure> InternalList = new List<Measure>();
        public int Count => ((ICollection<Measure>)InternalList).Count;

        public bool IsReadOnly => ((ICollection<Measure>)InternalList).IsReadOnly;

        public bool IsFixedSize => ((IList)InternalList).IsFixedSize;

        public object SyncRoot => ((ICollection)InternalList).SyncRoot;

        public bool IsSynchronized => ((ICollection)InternalList).IsSynchronized;

        public List<ChordFormula> Formulas 
        { 
            get 
            { 
                var result = this.InternalList
                    .SelectMany(x => x.Chords.Select(m=> m.Event))
                    .ToList();
                return result;
            } 
        }
        #endregion

        public MeasureList()
        {

        }

        public MeasureList(IEnumerable<Measure> measures)
        {
            this.InternalList = new List<Measure>();
            this.AddRange(measures);
        }

        #region Interfaces implemented through InternalList. Overriden for business logic.
        public void Add(Measure item)
        {
            item.MeasureNumber = this.InternalList.Count + 1;
            ((ICollection<Measure>)InternalList).Add(item);
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
            return ((IList)InternalList).Add(value);
        }

        public void AddRange(IEnumerable<Measure> collection)
        {
            foreach (var item in collection)
                this.Add(item);
        }


        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
            ((IList)InternalList).Insert(index, value);
        }

        public bool Remove(Measure item)
        {
            throw new NotImplementedException();
            return ((ICollection<Measure>)InternalList).Remove(item);
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
            ((IList)InternalList).Remove(value);
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
            ((IList<Measure>)InternalList).RemoveAt(index);
        }

        public void Clear()
        {
            throw new NotImplementedException();
            ((ICollection<Measure>)InternalList).Clear();
        }

        #endregion

        #region Interfaces implemented through InternalList
        public Measure this[int index] { get => ((IList<Measure>)InternalList)[index]; set => ((IList<Measure>)InternalList)[index] = value; }
        object IList.this[int index] { get => ((IList)InternalList)[index]; set => ((IList)InternalList)[index] = value; }


        public bool Contains(Measure item)
        {
            return ((ICollection<Measure>)InternalList).Contains(item);
        }

        public bool Contains(object value)
        {
            return ((IList)InternalList).Contains(value);
        }

        public void CopyTo(Measure[] array, int arrayIndex)
        {
            ((ICollection<Measure>)InternalList).CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)InternalList).CopyTo(array, index);
        }

        public IEnumerator<Measure> GetEnumerator()
        {
            return ((IEnumerable<Measure>)InternalList).GetEnumerator();
        }

        public int IndexOf(Measure item)
        {
            return ((IList<Measure>)InternalList).IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return ((IList)InternalList).IndexOf(value);
        }

        public void Insert(int index, Measure item)
        {
            ((IList<Measure>)InternalList).Insert(index, item);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)InternalList).GetEnumerator();
        }

        #endregion    

    }//class

}//ns
