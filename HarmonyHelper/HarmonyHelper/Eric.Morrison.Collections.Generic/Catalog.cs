using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyHelper.Interfaces;

namespace HarmonyHelper.Eric.Morrison.Collections.Generic
{
    public class CatalogBase<T> : IEnumerable<T>, IList<T> where T : IHasName
    {
        HashSet<T> _Catalog = new HashSet<T>();

        public T this[string name]
        {
            get { return this._Catalog.FirstOrDefault(x => x.Name == name); }
            set { }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this._Catalog).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._Catalog).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)this._Catalog).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)this._Catalog).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)this._Catalog).RemoveAt(index);
        }

        public T this[int index] { get => ((IList<T>)this._Catalog)[index]; set => ((IList<T>)this._Catalog)[index] = value; }

        public void Add(T item)
        {
            ((ICollection<T>)this._Catalog).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)this._Catalog).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)this._Catalog).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)this._Catalog).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)this._Catalog).Remove(item);
        }

        public int Count => ((ICollection<T>)this._Catalog).Count;

        public bool IsReadOnly => ((ICollection<T>)this._Catalog).IsReadOnly;
    }

}
