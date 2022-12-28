using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class Rest : IMusicalEvent<Rest>, IComparable<Rest>, IEquatable<Rest>
    {
        public int CompareTo(Rest other)
        {
            return 0;
        }

        public bool Equals(Rest other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString() 
        { 
            return nameof(Rest);
        }
    }//class
}//ns
