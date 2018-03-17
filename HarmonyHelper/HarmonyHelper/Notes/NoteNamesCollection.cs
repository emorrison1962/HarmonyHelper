using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public static class NoteNamesCollection
    {
        #region Properties

        static LinkedList<NoteName> LinkedList { get; set; } = new LinkedList<NoteName>();
        public static IEnumerable<NoteName> Catalog
        {
            get
            {
                var result = LinkedList.Select(x => x).ToList();
                return result;
            }
        }

        #endregion

        #region Construction

        static NoteNamesCollection()
        {
            var notes = NoteName.GetNoteNames().Distinct(new NoteNameValueEqualityComparer()).ToList();
            notes.ForEach(x => LinkedList.AddLast(x));
        }

        #endregion

        public static LinkedListNode<NoteName> Get(NoteName nn)
        {
            var node = LinkedList.Find(nn);
            return node;
        }
        public static NoteName Get(KeySignature key, NoteName nn, IntervalsEnum interval)
        {
            int ndx = interval.ToIndex();
            var node = LinkedList.Find(nn);
            node = node.Find(ndx);

            var result = NoteName.Copy(node.Value);
            if (null == result)
                throw new NullReferenceException();
            result = key.GetNormalized(result);
            return result;
        }

        public static NoteName Get(KeySignature key, NoteName ne, IntervalsEnum intervalEnum, DirectionEnum direction)
        {
            var interval = intervalEnum.ToIndex();
            if (direction == DirectionEnum.Descending)
            {
                interval *= -1;
            }
            var node = LinkedList.Find(ne);
            node = node.Find(interval);

            var result = node.Value;
            key.GetNormalized(result);
            return result;
        }

    }//class

}//ns
