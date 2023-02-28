using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
