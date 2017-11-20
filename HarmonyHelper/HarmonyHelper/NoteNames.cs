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

        public static LinkedListNode<KeySignature> Get(KeySignature ne)
        {
            var node = LinkedList.Find(ne);
            return node;
        }
        public static KeySignature Get(KeySignature ne, IntervalsEnum interval)
        {
            var node = LinkedList.Find(ne);
            node = node.Find((int)interval);

            var result = node.Value;
            return result;
        }

        public static KeySignature Get(KeySignature ne, IntervalsEnum intervalEnum, DirectionEnum direction)
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
