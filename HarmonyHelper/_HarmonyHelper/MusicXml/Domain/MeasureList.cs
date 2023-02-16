using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MeasureList : IList<MusicXmlMeasure>, ICollection<MusicXmlMeasure>, IEnumerable<MusicXmlMeasure>, IEnumerable, IList, ICollection, IReadOnlyList<MusicXmlMeasure>, IReadOnlyCollection<MusicXmlMeasure>
    {
        #region Properties
        List<MusicXmlMeasure> InternalList = new List<MusicXmlMeasure>();
        public int Count => ((ICollection<MusicXmlMeasure>)InternalList).Count;

        public bool IsReadOnly => ((ICollection<MusicXmlMeasure>)InternalList).IsReadOnly;

        public bool IsFixedSize => ((IList)InternalList).IsFixedSize;

        public object SyncRoot => ((ICollection)InternalList).SyncRoot;

        public bool IsSynchronized => ((ICollection)InternalList).IsSynchronized;

        #endregion

        public MeasureList()
        {

        }

        public MeasureList(IEnumerable<MusicXmlMeasure> measures)
        {
            this.InternalList = new List<MusicXmlMeasure>();
            this.AddRange(measures);
        }

        #region Interfaces implemented through InternalList. Overriden for business logic.
        public void Add(MusicXmlMeasure item)
        {
            item.MeasureNumber = this.InternalList.Count + 1;
            ((ICollection<MusicXmlMeasure>)InternalList).Add(item);
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
            return ((IList)InternalList).Add(value);
        }

        public void AddRange(IEnumerable<MusicXmlMeasure> collection)
        {
            foreach (var item in collection)
                this.Add(item);
        }


        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
            ((IList)InternalList).Insert(index, value);
        }

        public bool Remove(MusicXmlMeasure item)
        {
            throw new NotImplementedException();
            return ((ICollection<MusicXmlMeasure>)InternalList).Remove(item);
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
            ((IList)InternalList).Remove(value);
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
            ((IList<MusicXmlMeasure>)InternalList).RemoveAt(index);
        }

        public void Clear()
        {
            throw new NotImplementedException();
            ((ICollection<MusicXmlMeasure>)InternalList).Clear();
        }

        #endregion

        #region Interfaces implemented through InternalList
        public MusicXmlMeasure this[int index] { get => ((IList<MusicXmlMeasure>)InternalList)[index]; set => ((IList<MusicXmlMeasure>)InternalList)[index] = value; }
        object IList.this[int index] { get => ((IList)InternalList)[index]; set => ((IList)InternalList)[index] = value; }


        public bool Contains(MusicXmlMeasure item)
        {
            return ((ICollection<MusicXmlMeasure>)InternalList).Contains(item);
        }

        public bool Contains(object value)
        {
            return ((IList)InternalList).Contains(value);
        }

        public void CopyTo(MusicXmlMeasure[] array, int arrayIndex)
        {
            ((ICollection<MusicXmlMeasure>)InternalList).CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)InternalList).CopyTo(array, index);
        }

        public IEnumerator<MusicXmlMeasure> GetEnumerator()
        {
            return ((IEnumerable<MusicXmlMeasure>)InternalList).GetEnumerator();
        }

        public int IndexOf(MusicXmlMeasure item)
        {
            return ((IList<MusicXmlMeasure>)InternalList).IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return ((IList)InternalList).IndexOf(value);
        }

        public void Insert(int index, MusicXmlMeasure item)
        {
            ((IList<MusicXmlMeasure>)InternalList).Insert(index, item);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)InternalList).GetEnumerator();
        }

        #endregion    

    }//class

}//ns
