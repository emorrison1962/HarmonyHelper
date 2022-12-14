namespace Eric.Morrison.Harmony
{
    public interface IMusicalEvent
    { }
    public interface IMusicalEvent<T> : IMusicalEvent where T : class
    {
        //T Event { get; set; }
    }
}