using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony
{
    public interface IMusicalEvent
    { 
    }
    public interface IMusicalEvent<T> : IMusicalEvent where T : class
    {
    }
}