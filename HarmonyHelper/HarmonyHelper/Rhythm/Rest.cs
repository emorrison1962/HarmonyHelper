using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class Rest : IMusicalEvent<Rest>, IComparable<Rest>, IEquatable<Rest>
    {
        public int SortOrder { get { return 5; } }

        public Rest CopyEx()
        {
            return new Rest();
        }

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

    public class Forward : IMusicalEvent<Forward>, IComparable<Forward>, IEquatable<Forward>
    {
        public Forward()
        {

        }
        public int SortOrder { get { return 1; } }
        public Forward CopyEx()
        {
            return new Forward();
        }

        public int CompareTo(Forward other)
        {
            return 0;
        }

        public bool Equals(Forward other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString()
        {
            return nameof(Forward);
        }
    }//class

    public class Backup : IMusicalEvent<Backup>, IComparable<Backup>, IEquatable<Backup>
    {
        public int SortOrder { get { return 4; } }

        public Backup CopyEx()
        {
            return new Backup();
        }

        public int CompareTo(Backup other)
        {
            return 0;
        }

        public bool Equals(Backup other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString()
        {
            return nameof(Backup);
        }
    }//class

}//ns
