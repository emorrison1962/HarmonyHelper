using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    static class LinkedListExtensions
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current, ref bool wrapped)
        {
            if (null == current)
                throw new ArgumentNullException();
            var result = current.Next;
            if (null == result)
            {
                result = current.List.First;
                wrapped = true;
            }
            return result;
        }
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            if (null == current)
                throw new ArgumentNullException();
            bool wrapped = false;
            return current.NextOrFirst(ref wrapped);
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current, ref bool wrapped)
        {
            if (null == current)
                throw new ArgumentNullException();
            var result = current.Previous;
            if (null == result)
            {
                result = current.List.Last;
                wrapped = true;
            }
            return result;
        }
        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            if (null == current)
                throw new ArgumentNullException();
            bool wrapped = false;
            return current.PreviousOrLast(ref wrapped);
        }

        public static LinkedListNode<T> Find<T>(this LinkedListNode<T> current, int interval)
        {
            if (null == current)
                throw new ArgumentNullException();
            if (interval > 0)
            {
                for (int i = 0; i < interval; ++i)
                {
                    current = current.NextOrFirst();
                }
            }
            else
            {
                for (int i = interval; i < 0; ++i)
                {
                    current = current.PreviousOrLast();
                }
            }
            return current;
        }

        public static Note FindClosest(this LinkedList<Note> ll, Note lastNote, DirectionEnum direction)
        {
            Note result;

            if (DirectionEnum.Ascending == direction)
            {
                result = ll.Where(x => x > lastNote).FirstOrDefault();
            }
            else
            {
                result = ll.Where(x => x < lastNote).LastOrDefault();
            }
            return result;
        }

        static string ToString(this NoteName note, bool useSharps)
        {
            var result = note.ToString();

            if (useSharps)
            {
                if (result.EndsWith("b"))
                {
                    new object();
                    var n = NoteNamesCollection.Get(note, IntervalsEnum.Minor2nd, DirectionEnum.Descending);
                    result = n.ToString();
                }
            }

            return result;
        }
    }//class
}//ns
