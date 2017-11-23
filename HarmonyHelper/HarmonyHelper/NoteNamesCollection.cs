using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public static class NoteNamesCollection
    {
        #region Properties

        static LinkedList<NoteName> LinkedList { get; set; } = new LinkedList<NoteName>();

        #endregion

        #region Construction

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
            int ndx = interval.ToIndex();
            var node = LinkedList.Find(ne);
            node = node.Find(ndx);

            var result = node.Value;
            if (null == result)
                throw new NullReferenceException();

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
