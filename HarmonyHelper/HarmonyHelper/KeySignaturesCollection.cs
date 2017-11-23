using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
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
            var interval = intervalEnum.ToIndex();
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
