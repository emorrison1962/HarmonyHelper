using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    [Flags]
    public enum DurationEnum
    {
        Unknown = 0,
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
        None = 1 << 32,
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

    public class TimeContext : IEquatable<TimeContext>, IComparable<TimeContext>, IHasIsValid
    {
        #region Properties
        RhythmicContext _Rhythm { get; set; }
        public RhythmicContext Rhythm
        {
            get { return this._Rhythm; }
            set
            {
                this._Rhythm = value;
                Debug.Assert(null != value);
            }
        }
        int _MeasureNumber;
        public int MeasureNumber
        {
            get { return _MeasureNumber; }
            protected set
            {
                //Debug.Assert(value < 6 * 1000);
                _MeasureNumber = value;
            }
        }

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
        public int RelativeStart { get; protected set; } = int.MinValue;
        public int RelativeEnd { get; protected set; } = int.MinValue;
        public int Duration
        {
            get
            {
                return RelativeEnd - RelativeStart;
            }
        }

        public TieTypeEnum TieType { get; set; } = TieTypeEnum.None;
        public bool IsDotted { get; protected set; }


        #endregion

        #region Construction

        public class CreationContext
        {
            public int MeasureNumber { get; set; }
            RhythmicContext _Rhythm { get; set; }
            public RhythmicContext Rhythm
            {
                get { return this._Rhythm; }
                set
                {
                    this._Rhythm = value;
                    Debug.Assert(null != value);
                }
            }
            public int RelativeStart { get; set; }
            public int RelativeEnd { get; set; }
            public bool IsDotted { get; set; }
            public CreationContext() { }
            public CreationContext(RhythmicContext rhythm)
            {
                this.Rhythm = rhythm;
            }
        }

        TimeContext(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
        }

        public TimeContext(int measureNumber, RhythmicContext rhythm)
            : this(measureNumber)
        {
            if (null == rhythm)
                throw new ArgumentNullException(nameof(rhythm));
            this.Rhythm = rhythm;
        }

        public TimeContext(CreationContext ctx)
            : this(ctx.MeasureNumber, ctx.Rhythm)
        {
            this.RelativeStart = ctx.RelativeStart;
            this.RelativeEnd = ctx.RelativeEnd;
            this.IsDotted = ctx.IsDotted;
        }
        public TimeContext(int measure, CreationContext ctx)
            : this(ctx.MeasureNumber, ctx.Rhythm)
        {
        }
        public TimeContext(int measureNumber, RhythmicContext rhythm, int start, int duration)
            : this(measureNumber, rhythm)
        {
            this.RelativeStart = start;
            this.RelativeEnd = start + duration;
        }
        public TimeContext(TimeContext src)
            : this(src.MeasureNumber, src.Rhythm)
        {
            this.RelativeStart = src.RelativeStart;
            this.RelativeEnd = src.RelativeEnd;
        }
        public TimeContext()
        {
        }

        #endregion

        #region Fluent
        public TimeContext SetMeasureNumber(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
            return this;
        }
        public TimeContext SetRhythmicContext(RhythmicContext ctx)
        {
            this.Rhythm = ctx;
            return this;
        }

        public TimeContext SetRelativeStart(int start)
        {
            this.RelativeStart = start;
            return this;
        }
        public TimeContext SetRelativeEnd(int end)
        {
            this.RelativeEnd = end;
            return this;
        }

        public TimeContext SetIsDotted(bool isDotted)
        {
            this.IsDotted = isDotted;
            return this;
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
                result = a.RelativeStart.CompareTo(b.RelativeStart);

            return result;
        }
        public override int GetHashCode()
        {
            var result = this.MeasureNumber.GetHashCode()
            ^ this.RelativeStart.GetHashCode();

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

        virtual public bool IsValid()
        {
            var result = true;

            if (null == _Rhythm)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && _MeasureNumber < 0)
            {
                result = false;
                Debug.Assert(result);
            }

            if (result && _MeasureNumber > 0 && AbsoluteStart == 0)
            {
                result = false;
                Debug.Assert(result);
            }

            if (result && _MeasureNumber > 0 && AbsoluteEnd <= AbsoluteStart)
            {
                result = false;
                Debug.Assert(result, "_MeasureNumber > 0 && AbsoluteEnd <= AbsoluteStart");
            }

            if (result && _MeasureNumber > 0 && RelativeStart < 0)
            {
                result = false;
                Debug.Assert(result);
            }

            if (result && _MeasureNumber > 0 && RelativeEnd <= RelativeStart)
            {
                result = false;
                Debug.Assert(result);
            }

            if (result && Duration <= 0)
            {
                result = false;
                Debug.Assert(result);
            }

            return result;
        }

        public override string ToString()
        {
            return $"Start={this.MeasureNumber}.{this.RelativeStart} End={this.MeasureNumber}.{this.RelativeEnd}";
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

        public static TimeContext operator +(TimeContext addend, TimeContext augend)
        {
            var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
            var RelativeStart = addend.RelativeStart + augend.RelativeStart;
            var RelativeEnd = addend.RelativeEnd + augend.RelativeEnd;

            var result = new TimeContext(MeasureNumber)
                .SetRelativeStart(RelativeStart)
                .SetRelativeEnd(RelativeEnd);

            return result;
        }
    }//class

}//ns
