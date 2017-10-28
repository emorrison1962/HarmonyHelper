using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
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

    public static class KeySignatureEnumCollection
    {
        #region Properties

        static LinkedList<KeySignatureEnum> LinkedList { get; set; } = new LinkedList<KeySignatureEnum>();

        #endregion

        #region Construction
        static KeySignatureEnumCollection()
        {
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.C);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.Db);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.D);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.Eb);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.E);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.F);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.Gb);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.G);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.Ab);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.A);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.Bb);
            LinkedList.AddLast((KeySignatureEnum)NotesEnum.B);
        }

        #endregion

        public static LinkedListNode<KeySignatureEnum> Get(KeySignatureEnum ne)
        {
            var node = LinkedList.Find(ne);
            return node;
        }
        public static KeySignatureEnum Get(KeySignatureEnum ne, IntervalsEnum interval)
        {
            var node = LinkedList.Find(ne);
            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

        public static KeySignatureEnum Get(KeySignatureEnum ne, IntervalsEnum intervalEnum, DirectionEnum direction)
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

}//ns
