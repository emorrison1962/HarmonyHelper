using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Intervals;

using Newtonsoft.Json;

namespace Eric.Morrison.Harmony.Chords
{
    public static partial class Extensions
    {
        public static IEnumerable<T> UnionEx<T>(this List<T> src,
            params T[] addl)
        {
            var result = src.Union(addl);
            return result;
        }
    }

    static public class ChordType 
    {
        #region Statics
        static public List<ChordIntervalsEnum> Catalog { get; set; } = new List<ChordIntervalsEnum>();


        #endregion

        static ChordType()
        {
            ChordType.Catalog = Enum.GetValues(typeof(ChordIntervalsEnum))
                .Cast<ChordIntervalsEnum>()
                .ToList()
                .Where(x => x != ChordIntervalsEnum.IsChord
                    && x.HasFlag(ChordIntervalsEnum.IsChord))
                .OrderBy(x => x.Name())
                .ToHashSet()
                .ToList();
        }

    }//class
}//ns
