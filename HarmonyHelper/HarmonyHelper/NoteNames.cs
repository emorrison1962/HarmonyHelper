using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Eric.Morrison.Harmony
{
    [Obsolete]
    public static class NotesEnumCollection
    {
        #region Properties

        static LinkedList<NotesEnum> LinkedList { get; set; } = new LinkedList<NotesEnum>();

        #endregion

        #region Construction
        static NotesEnumCollection()
        {
            LinkedList.AddLast(NotesEnum.C);
            LinkedList.AddLast(NotesEnum.Db);
            LinkedList.AddLast(NotesEnum.D);
            LinkedList.AddLast(NotesEnum.Eb);
            LinkedList.AddLast(NotesEnum.E);
            LinkedList.AddLast(NotesEnum.F);
            LinkedList.AddLast(NotesEnum.Gb);
            LinkedList.AddLast(NotesEnum.G);
            LinkedList.AddLast(NotesEnum.Ab);
            LinkedList.AddLast(NotesEnum.A);
            LinkedList.AddLast(NotesEnum.Bb);
            LinkedList.AddLast(NotesEnum.B);
        }

        #endregion

        public static LinkedListNode<NotesEnum> Get(NotesEnum ne)
        {
            var node = LinkedList.Find(ne);
            return node;
        }
        public static NotesEnum Get(NotesEnum ne, IntervalsEnum interval)
        {
            var node = LinkedList.Find(ne);

            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

        public static NotesEnum Get(NotesEnum ne, IntervalsEnum intervalEnum, DirectionEnum direction)
        {
            var interval = (int)intervalEnum;
            if (direction == DirectionEnum.Descending)
            {
                interval *= -1;
            }
            var node = LinkedList.Find(ne);
            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

    }//class


    public static class NotesCollection
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
        static NotesCollection()
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
            var interval = (int)intervalEnum;
            if (direction == DirectionEnum.Descending)
            {
                interval *= -1;
            }
            var node = LinkedList.Find(ne);
            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

    }//class

    public static class KeySignatureCollection
    {
        #region Properties

        static LinkedList<KeySignature> LinkedList { get; set; } = new LinkedList<KeySignature>();

        #endregion

        #region Construction
        static KeySignatureCollection()
        {
            LinkedList.AddLast(KeySignature.CMajor);
            LinkedList.AddLast(KeySignature.DbMajor);
            LinkedList.AddLast(KeySignature.DMajor);
            LinkedList.AddLast(KeySignature.EbMajor);
            LinkedList.AddLast(KeySignature.EMajor);
            LinkedList.AddLast(KeySignature.FMajor);
            LinkedList.AddLast(KeySignature.GbMajor);
            LinkedList.AddLast(KeySignature.GMajor);
            LinkedList.AddLast(KeySignature.AbMajor);
            LinkedList.AddLast(KeySignature.AMajor);
            LinkedList.AddLast(KeySignature.BbMajor);
            LinkedList.AddLast(KeySignature.BMajor);
        }

        #endregion

        public static LinkedListNode<KeySignature> Get(KeySignature key)
        {
            var node = LinkedList.Find(key);
            if (null == node)
            {
                throw new ArgumentOutOfRangeException(key.NoteName.ToString());
            }

            return node;
        }
        public static KeySignature Get(KeySignature ne, IntervalsEnum interval)
        {
            var node = LinkedList.Find(ne);
            if (null == node)
                throw new NotImplementedException();

            var ndx = interval.ToIndex();
            node = node.Find(ndx);
            if (null == node)
                throw new NotImplementedException();

            var result = node.Value;
            return result;
        }

        public static KeySignature Get(KeySignature ne, IntervalsEnum intervalEnum, DirectionEnum direction)
        {
            var ndx = intervalEnum.ToIndex();
            var interval = (int)intervalEnum;
            if (direction == DirectionEnum.Descending)
            {
                interval *= -1;
            }
            var node = LinkedList.Find(ne);
            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

    }//class

}//ns
