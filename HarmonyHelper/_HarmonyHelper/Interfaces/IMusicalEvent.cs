using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Interfaces;

namespace Eric.Morrison.Harmony
{
    public interface IMusicalEvent
    { 
    }
    public interface IMusicalEvent<T> : IImplementCopy<T>, IMusicalEvent where T : class
    {
        int SortOrder { get; }
    }
}