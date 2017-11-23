using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Eric.Morrison.Harmony
{
    public static class NoteNamesCollection
    {
        #region Properties

        static LinkedList<NoteName> LinkedList { get; set; } = new LinkedList<NoteName>();

        #endregion

        #region Construction

        class NoteNameValueComparer : IEqualityComparer<NoteName>
        {
            public bool Equals(NoteName x, NoteName y)
            {
                var result = false;
                if (x.Value == y.Value)
                    result = true;
                return result;
            }

            public int GetHashCode(NoteName obj)
            {
                return obj.Value.GetHashCode();
            }
        }
        static NoteNamesCollection()
        {
            var notes = NoteName.GetNoteNames().Distinct(new NoteNameValueComparer()).ToList();
            notes.ForEach(x => LinkedList.AddLast(x));
        }

        #endregion

        public static LinkedListNode<NoteName> Get(NoteName ne)
        {
            var node = LinkedList.Find(ne);
            return node;
        }
        public static NoteName Get(NoteName ne, IntervalsEnum interval)
        {
            var values = Enum.GetValues(typeof(IntervalsEnum));
            var list = new List<IntervalsEnum>();

            for (int i = 0; i < values.Length; ++i)
            {
                var v = values.GetValue(i);
                if (!list.Contains((IntervalsEnum)v))
                    list.Add((IntervalsEnum)v);
            }
            
            int ndx = list.IndexOf(interval);

            var node = LinkedList.Find(ne);
            node = node.Find(ndx);

            var result = node.Value;
            return result;
        }

        public static NoteName Get(NoteName ne, IntervalsEnum intervalEnum, DirectionEnum direction)
        {
            var interval = intervalEnum.ToIndex();
            if (direction == DirectionEnum.Descending)
            {
                interval *= -1;
            }
            var node = LinkedList.Find(ne);
            node = node.Find(interval);

            var result = node.Value;
            return result;
        }

    }//class

}//ns
