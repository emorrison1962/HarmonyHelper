using System;

namespace Eric.Morrison.Harmony.Intervals
{
    [Obsolete("", true)]
    public interface IFunctionalInterval
    {
        IntervalRoleTypeEnum IntervalRoleType { get; }
        //IFunctionalInterval GetInversion();
    }
}