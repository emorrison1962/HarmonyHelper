using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimedEvent<T> : IHasTimeContext, IEquatable<TimedEvent<T>>, IComparable<TimedEvent<T>>
        where T : class, IMusicalEvent<T>, IComparable<T>, new()
    {
        #region Properties
        public int AbsoluteStart { get { return this.TimeContext.AbsoluteStart; } }
        public int AbsoluteEnd { get { return this.TimeContext.AbsoluteEnd; } }
        public int RelativeStart { get { return this.TimeContext.RelativeStart; } }
        public int RelativeEnd { get { return this.TimeContext.RelativeEnd; } }
        public int Duration { get { return this.TimeContext.Duration; } }
        public int SortOrder { get { return this.Event.SortOrder; } }
        public T Event { get; set; }
        public TimeContext TimeContext { get; set; }
        public XmlSerializationProperties Serialization { get; set; } = new XmlSerializationProperties();

        #endregion

        #region Construction
        public TimedEvent(TimedEvent<T> src)
        {
            var dst = src.Event.Copy();
            this.Event = dst;
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEvent(T @event, TimeContext ctx)
        {
            this.Event = @event;
            this.TimeContext = ctx;
        }

        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEvent<T> other)
        {
            var result = false;
            if (this.Event.Equals(other.Event)
                && this.TimeContext.Equals(other.TimeContext))
                result = true;
            return result;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TimedEvent<T>)
                result = this.Equals(obj as TimedEvent<T>);
            return result;
        }
        public int CompareTo(TimedEvent<T> other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEvent<T> a, TimedEvent<T> b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.Event.CompareTo(b.Event);

            if (0 == result)
            {
                result = a.TimeContext.CompareTo(b.TimeContext);
            }
            return result;
        }
        public override int GetHashCode()
        {
            var result = this.Event.GetHashCode()
                ^ this.TimeContext.ToString().GetHashCode();
            //Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}: {this.ToString()}={result}");

            return result;
        }
        public static bool operator ==(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class

    public class XmlSerializationProperties
    {
        public string Voice { get; set; }
        public string Staff { get; set; }
        public bool HasChord { get; set; }
        int Forward { get; set; }
        int Backup { get; set; }
        bool HasForward { get { return  this.Forward != 0; } }
        bool HasBackup { get { return  this.Backup != 0; } }   
        public string Attack { get; set; }
        public string Release { get; set; }

        public XmlSerializationProperties() { }
        public XmlSerializationProperties(XmlSerializationProperties src) 
        { 
            this.Staff = src.Staff;
            this.Forward = src.Forward; 
            this.Backup = src.Backup;
            this.Attack = src.Attack;
            this.Release = src.Release;
            this.Voice = src.Voice; 
        }
    }

    public class TimeContext : IEquatable<TimeContext>, IComparable<TimeContext>
    {
        #region Properties
        public int PulsesPerMeasure { get; set; } = int.MinValue;
        public int MeasureNumber { get; set; }
        public int AbsoluteStart
        {
            get
            {
                return (this.PulsesPerMeasure * this.MeasureNumber) + this.RelativeStart;
            }
        }
        public int AbsoluteEnd
        {
            get
            {
                return (this.PulsesPerMeasure * this.MeasureNumber) + this.RelativeEnd;
            }
        }
        public int RelativeStart { get; set; }
        public int RelativeEnd { get; set; }
        public int Duration { get; set; }

        #endregion

        #region Construction
        public TimeContext(int measure, int ppm, int start, int end)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.MeasureNumber = measure;
            this.PulsesPerMeasure = ppm;
            this.RelativeStart = start;
            this.RelativeEnd = end;
            this.Duration = this.RelativeEnd - this.RelativeStart;
        }

        public TimeContext(TimeContext src)
        {
            this.MeasureNumber = src.MeasureNumber;
            this.PulsesPerMeasure = src.PulsesPerMeasure;
            this.RelativeStart = src.RelativeStart;
            this.RelativeEnd = this.RelativeEnd;
            this.Duration = src.Duration;
        }
        public TimeContext(int measure)
        {
            this.MeasureNumber = measure;
        }

        #endregion

        #region Equality
        public bool Equals(TimeContext other)
        {
            var result = false;
            if (this.MeasureNumber == other.MeasureNumber
                && this.PulsesPerMeasure == other.PulsesPerMeasure
                && this.RelativeStart == other.RelativeStart
                && this.RelativeEnd == other.RelativeEnd)
                result = true;
            return result;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TimeContext)
                result = this.Equals(obj as TimeContext);
            return result;
        }
        public int CompareTo(TimeContext other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimeContext a, TimeContext b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.MeasureNumber.CompareTo(b.MeasureNumber);
            if (0 == result)
                result = a.PulsesPerMeasure.CompareTo(b.PulsesPerMeasure);
            if (0 == result)
                result = a.RelativeStart.CompareTo(b.RelativeStart);
            if (0 == result)
                result = a.RelativeEnd.CompareTo(b.RelativeEnd);

            return result;
        }
        public override int GetHashCode()
        {
            var result = this.MeasureNumber.GetHashCode()
            ^ this.PulsesPerMeasure.GetHashCode()
            ^ this.RelativeStart.GetHashCode()
            ^ this.RelativeEnd.GetHashCode();

            return result;
        }
        public static bool operator ==(TimeContext a, TimeContext b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimeContext a, TimeContext b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        public override string ToString()
        {
            return $"Start={this.MeasureNumber}.{this.RelativeStart} End={this.MeasureNumber}.{this.RelativeEnd}, Duration={this.Duration}";
        }

        public bool Intersects(TimeContext other)
        {
            var result = false;
            if (this.AbsoluteStart >= other.AbsoluteStart
                && this.AbsoluteStart <= other.AbsoluteEnd)
            {
                result = true;
            }
            return result;
        }
        public string GetNoteType()
        {
            var nt = this.PulsesPerMeasure / this.Duration;
            var nlde = (NoteLengthDivisorEnum)nt;
            return nlde.GetMusicXmlName();
        }

        static public TimeContext CopyWithOffset(TimeContext src, int offset)
        {
            var result = new TimeContext(src);
            result.MeasureNumber = result.MeasureNumber + offset;
            return result;
        }
    }//class

    public class TimedEventFactory
    {
        static public TimedEventFactory Instance { get; } = new TimedEventFactory();
        public int PulsesPerMeasure { get; set; } = int.MinValue;

        TimedEventFactory() { }

        public TimedEvent<ChordFormula> CreateTimedEvent(ChordFormula formula,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var time = new TimeContext(
                measureNumber,
                PulsesPerMeasure,
                start,
                end);
            var result = new TimedEvent<ChordFormula>(formula, 
                time);
            return result;
        }

        public TimedEvent<Note> CreateTimedEvent(Note note,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var time = new TimeContext(
                measureNumber,
                PulsesPerMeasure,
                start,
                end);
            var result = new TimedEvent<Note>(note,
                time);
            return result;
        }
        public TimedEvent<Rest> CreateTimedEvent(Rest rest,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var time = new TimeContext(
                measureNumber,
                PulsesPerMeasure,
                start,
                end);
            var result = new TimedEvent<Rest>(rest,
                time);
            return result;
        }

        public TimedEvent<Forward> CreateTimedEvent(Forward rest,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var time = new TimeContext(
                measureNumber,
                PulsesPerMeasure,
                start,
                end);
            var result = new TimedEvent<Forward>(rest,
                time);
            return result;
        }

        public TimedEvent<Backup> CreateTimedEvent(Backup rest,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var time = new TimeContext(
                measureNumber,
                PulsesPerMeasure,
                start,
                end);
            var result = new TimedEvent<Backup>(rest,
                time);
            return result;
        }

    }//class

}//ns
