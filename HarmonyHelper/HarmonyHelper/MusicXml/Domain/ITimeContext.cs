namespace Eric.Morrison.Harmony.MusicXml
{
    public interface ITimeContext
    {
        int AbsoluteEnd { get; }
        int AbsoluteStart { get; }
        int DurationInteger { get; }
        DurationEnum Duration { get; }
        bool IsDotted { get; }
        int MeasureNumber { get; }
        int RelativeEnd { get; }
        int RelativeStart { get; }
        RhythmicContext Rhythm { get; set; }
        TieTypeEnum TieType { get; set; }

        int CompareTo(TimeContext other);
        bool Equals(object obj);
        bool Equals(TimeContext other);
        int GetHashCode();
        bool Intersects(TimeContext other);
        bool IsValid();
        TimeContext SetIsDotted(bool isDotted);
        TimeContext SetMeasureNumber(int measureNumber);
        TimeContext SetRelativeEnd(int end);
        TimeContext SetRelativeStart(int start);
        TimeContext SetRhythmicContext(RhythmicContext ctx);
        string ToString();
    }
}