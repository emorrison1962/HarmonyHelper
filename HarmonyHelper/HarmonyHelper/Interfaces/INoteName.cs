namespace Eric.Morrison.Harmony
{
    public interface INoteName
    {
        int AccidentalCount { get; }
        int AsciiSortValue { get; }
        bool IsFlatted { get; }
        bool IsNatural { get; }
        bool IsSharped { get; }
        string Name { get; }
        uint RawValue { get; }
        string ToString();
    }
}