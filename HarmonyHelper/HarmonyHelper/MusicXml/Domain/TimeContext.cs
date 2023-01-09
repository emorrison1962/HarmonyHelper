using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class RhythmicContext
    {
        public TimeSignature TimeSignature { get; set; }
        //public int PulsesPerMeasure { get; protected set; }
        public int PulsesPerQuarterNote { get; set; }
        public int PulsesPerMeasure
        {
            get
            {
                return this.TimeSignature.BeatCount * this.PulsesPerQuarterNote;
            }
        }

        public int ToInt32(DurationEnum duration)
        { 
            throw new NotImplementedException();
        }
    }

    [Flags]
    public enum DurationEnum
    {
        None = 0,
        Duration_Maxima = 1 << 1,
        Duration_Long = 1 << 2,
        Duration_Breve = 1 << 3,
        Duration_Whole = 1 << 4,
        Duration_Half = 1 << 5,
        Duration_Quarter = 1 << 6,
        Duration_Eighth = 1 << 7,
        Duration_16th = 1 << 8,
        Duration_32nd = 1 << 9,
        Duration_64th = 1 << 10,
        Duration_128th = 1 << 11,
        Duration_256th = 1 << 12,
        Duration_512th = 1 << 13,
        Duration_1024th = 1 << 14,
    };

    public abstract class DurationStrings
    {
        #region Constants
        public const string NoteType_1024th = "1024th";
        public const string NoteType_512th = "512th";
        public const string NoteType_256th = "256th";
        public const string NoteType_128th = "128th";
        public const string NoteType_64th = "64th";
        public const string NoteType_32nd = "32nd";
        public const string NoteType_16th = "16th";
        public const string NoteType_eighth = "eighth";
        public const string NoteType_quarter = "quarter";
        public const string NoteType_half = "half";
        public const string NoteType_whole = "whole";
        public const string NoteType_breve = "breve";
        public const string NoteType_long = "long";
        public const string NoteType_maxima = "maxima";

        #endregion

    }

    public class TimeContext : IEquatable<TimeContext>, IComparable<TimeContext>
    {
        #region Properties
        public RhythmicContext Rhythm { get; set; }
        public int MeasureNumber { get; set; }
        public int AbsoluteStart
        {
            get
            {
                return (this.Rhythm.PulsesPerMeasure * this.MeasureNumber) + this.RelativeStart;
            }
        }
        public int AbsoluteEnd
        {
            get
            {
                return (this.Rhythm.PulsesPerMeasure * this.MeasureNumber) + this.RelativeEnd;
            }
        }
        public int RelativeStart { get; set; }
        public int RelativeEnd { get; set; }
        public DurationEnum Duration { get; set; }

        TimeContext TiedPrevious { get; set; }
        TimeContext TiedNext { get; set; }
        public bool IsTieStart 
        { 
            get 
            {
                var result = true;
                if (null == TiedPrevious)
                    result = false;
                return result;
            } 
        }
        public bool IsTieEnd
        {
            get
            {
                var result = true;
                if (null == TiedNext)
                    result = false;
                return result;
            }
        }
        public bool IsTied
        {
            get
            {
                var result = false;
                if (null != TiedPrevious || null != TiedNext)
                    result = true;
                return result;
            }
        }
        public bool IsDotted { get; set; }


        #endregion

        #region Construction
        public class CreationContext
        {
            public int MeasureNumber { get; set; }
            public RhythmicContext Rhythm { get; set; }
            public int RelativeStart { get; set; }
            public int RelativeEnd { get; set; }
            public DurationEnum Duration { get; set; }
            public bool IsDotted { get; set; }
            public TimeContext TiedPrevious { get; set; }
            public TimeContext TiedNext { get; set; }
        }
        public TimeContext(CreationContext ctx)
        {
            this.MeasureNumber = ctx.MeasureNumber;
            this.Rhythm = ctx.Rhythm;
            this.RelativeStart = ctx.RelativeStart;
            //this.RelativeEnd = ctx.Start + ctx.Duration;
            this.Duration = ctx.Duration;
            this.TiedPrevious= ctx.TiedPrevious;
            this.TiedNext = ctx.TiedNext;
            this.IsDotted = ctx.IsDotted;    
        }
        public TimeContext(int measure, CreationContext ctx)
        {
            this.MeasureNumber = measure;
            this.Rhythm = ctx.Rhythm;
        }
        public TimeContext(int measure, RhythmicContext rhythm, int start, int duration)
        {
            this.MeasureNumber = measure;
            this.Rhythm = rhythm;
            this.RelativeStart= start;
            this.RelativeEnd = start + duration;
        }
        public TimeContext(TimeContext src)
        {
            this.MeasureNumber = src.MeasureNumber;
            this.Rhythm = src.Rhythm;
            this.RelativeStart = src.RelativeStart;
            this.RelativeEnd = src.RelativeEnd;
            this.Duration = src.Duration;
        }

        #endregion

        #region Equality
        public bool Equals(TimeContext other)
        {
            var result = false;
            if (this.MeasureNumber == other.MeasureNumber
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
                result = a.Duration.CompareTo(b.Duration);
            if (0 == result)
                result = a.RelativeStart.CompareTo(b.RelativeStart);

            return result;
        }
        public override int GetHashCode()
        {
            var result = this.MeasureNumber.GetHashCode()
            ^ this.RelativeStart.GetHashCode()
            ^ this.Duration.GetHashCode();

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
        static public TimeContext CopyWithOffset(TimeContext src, int offset)
        {
            var result = new TimeContext(src);
            result.MeasureNumber = result.MeasureNumber + offset;
            return result;
        }

        public bool TryGetName(DurationEnum duration, out string name, out bool isDotted)
        {
            var result = false;
            name = string.Empty;
            isDotted = this.IsDotted;

            switch (duration)
            {
                case DurationEnum.Duration_Maxima:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Long:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Breve:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Whole:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Half:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Quarter:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Eighth:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_16th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_32nd:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_64th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_128th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_256th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_512th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_1024th:
                    name = DurationStrings.NoteType_maxima;
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }

            return result;
        }

        public static TimeContext operator +(TimeContext addend, TimeContext augend)
        {
            var Duration = addend.Duration;
            var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
            var RelativeStart = addend.RelativeStart + augend.RelativeStart;
            var RelativeEnd = addend.RelativeEnd + augend.RelativeEnd;

            var ctx = new TimeContext.CreationContext() { 
                MeasureNumber= MeasureNumber,
                RelativeStart = RelativeStart,
                Duration = Duration,
                Rhythm = augend.Rhythm,
            };
            return new TimeContext(ctx);
        }
    }//class

}//ns
