using System;
using System.Linq;

namespace Eric.Morrison.Harmony.Intervals
{
    public class AmbiguousInterval : Interval, IEquatable<AmbiguousInterval>
    {
        public override string Name
        {
            get => $"{base.Name} (may be an enharmonic equivalent)";
            protected set => base.Name = value;
        }

        public AmbiguousInterval(Interval src) 
            : base(src)
        {
            ReflectionExtensions.Copy(this, src);
        }

        override public Interval GetInversion()
        {
            var result = Interval.Catalog.First(x => x.Value == this.Value 
                && x.IntervalRoleType == this.IntervalRoleType)
                .GetInversion();
            
            return result;
        }

        public bool Equals(AmbiguousInterval other)
        {
            throw new NotImplementedException();
        }
    }//class
}//ns