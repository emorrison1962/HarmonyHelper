using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimeContextEx : TimeContext, IHasIsValid
    {
        new public class CreationContext : TimeContext.CreationContext
        {
            public DurationEnum Duration { get; set; }
            public CreationContext() { }
            public CreationContext(RhythmicContext rhythm)
                : base(rhythm)
            {
            }
        }

        #region Properties
        public DurationEnum _DurationEnum { get; protected set; }
        public DurationEnum DurationEnum
        {
            get { return this._DurationEnum; }
            protected set
            {
                this._DurationEnum = value;
                Debug.Assert(value != DurationEnum.Unknown);
            }
        }

        #endregion

        #region Construction

        TimeContextEx(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
        }

        public TimeContextEx(int measureNumber, RhythmicContext rhythm)
            : this(measureNumber)
        {
            if (null == rhythm)
                throw new ArgumentNullException(nameof(rhythm));
            this.Rhythm = rhythm;
        }

        public TimeContextEx(int measureNumber, RhythmicContext rhythm, DurationEnum duration)
            : this(measureNumber, rhythm)
        {
            this.DurationEnum = duration;
            this.RelativeStart = 0;
            this.RelativeEnd = this.Rhythm.PulsesPerMeasure * this.MeasureNumber | (int)duration;
        }

        public TimeContextEx(Measure measure, RhythmicContext rhythm, DurationEnum duration)
            : this(measure.MeasureNumber, rhythm, duration)
        {
        }

        public TimeContextEx(CreationContext ctx)
            : this(ctx.MeasureNumber, ctx.Rhythm)
        {
            this.RelativeStart = ctx.RelativeStart;
            this.RelativeEnd = ctx.RelativeEnd;
            this.DurationEnum = ctx.Duration;
            this.IsDotted = ctx.IsDotted;
        }
        public TimeContextEx(int measure, CreationContext ctx)
            : this(ctx.MeasureNumber, ctx.Rhythm)
        {
        }
        public TimeContextEx(int measureNumber, RhythmicContext rhythm, int start, int duration)
            : this(measureNumber, rhythm)
        {
            this.RelativeStart = start;
            this.RelativeEnd = start + duration;
        }
        public TimeContextEx(TimeContextEx src)
            : this(src.MeasureNumber, src.Rhythm)
        {
            this.RelativeStart = src.RelativeStart;
            this.RelativeEnd = src.RelativeEnd;
            this.DurationEnum = src.DurationEnum;
        }
        public TimeContextEx()
        {
        }

        #endregion

        #region Fluency
        public TimeContextEx SetDuration(DurationEnum duration)
        {
            this.DurationEnum = duration;
            return this;
        }

        #endregion

        #region Equality
        public bool Equals(TimeContextEx other)
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
            if (obj is TimeContextEx)
                result = this.Equals(obj as TimeContextEx);
            return result;
        }
        public int CompareTo(TimeContextEx other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimeContextEx a, TimeContextEx b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.MeasureNumber.CompareTo(b.MeasureNumber);
            if (0 == result)
                result = a.DurationEnum.CompareTo(b.DurationEnum);
            if (0 == result)
                result = a.RelativeStart.CompareTo(b.RelativeStart);

            return result;
        }
        public override int GetHashCode()
        {
            var result = this.MeasureNumber.GetHashCode()
            ^ this.RelativeStart.GetHashCode()
            ^ this.DurationEnum.GetHashCode();

            return result;
        }
        public static bool operator ==(TimeContextEx a, TimeContextEx b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimeContextEx a, TimeContextEx b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        override public bool IsValid()
        {
            var result = base.IsValid();
            if (result && _DurationEnum == DurationEnum.Unknown)
            {
                result = false;
                Debug.Assert(result);
            }

            return result;
        }

        public override string ToString()
        {
            return $"Start={this.MeasureNumber}.{this.RelativeStart} End={this.MeasureNumber}.{this.RelativeEnd}, Duration={this.DurationEnum}";
        }

        public bool Intersects(TimeContextEx other)
        {
            var result = false;
            if (this.AbsoluteStart >= other.AbsoluteStart
                && this.AbsoluteStart <= other.AbsoluteEnd)
            {
                result = true;
            }
            return result;
        }
        static public TimeContextEx CopyWithOffset(TimeContextEx src, int offset)
        {
            var result = new TimeContextEx(src);
            result.MeasureNumber = result.MeasureNumber + offset;
            return result;
        }

        public string GetNoteLengthName()
        {
            var result = string.Empty;

            switch (this._DurationEnum)
            {
                case DurationEnum.Duration_Maxima:
                    result = DurationStrings.NoteType_maxima;
                    break;
                case DurationEnum.Duration_Long:
                    result = DurationStrings.NoteType_long;
                    break;
                case DurationEnum.Duration_Breve:
                    result = DurationStrings.NoteType_breve;
                    break;
                case DurationEnum.Duration_Whole:
                    result = DurationStrings.NoteType_whole;
                    break;
                case DurationEnum.Duration_Half:
                    result = DurationStrings.NoteType_half;
                    break;
                case DurationEnum.Duration_Quarter:
                    result = DurationStrings.NoteType_quarter;
                    break;
                case DurationEnum.Duration_Eighth:
                    result = DurationStrings.NoteType_eighth;
                    break;
                case DurationEnum.Duration_16th:
                    result = DurationStrings.NoteType_16th;
                    break;
                case DurationEnum.Duration_32nd:
                    result = DurationStrings.NoteType_32nd;
                    break;
                case DurationEnum.Duration_64th:
                    result = DurationStrings.NoteType_64th;
                    break;
                case DurationEnum.Duration_128th:
                    result = DurationStrings.NoteType_128th;
                    break;
                case DurationEnum.Duration_256th:
                    result = DurationStrings.NoteType_256th;
                    break;
                case DurationEnum.Duration_512th:
                    result = DurationStrings.NoteType_512th;
                    break;
                case DurationEnum.Duration_1024th:
                    result = DurationStrings.NoteType_1024th;
                    break;
                case DurationEnum.None:
                    result = string.Empty;
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }

            return result;
        }

        public static TimeContextEx operator +(TimeContextEx addend, TimeContextEx augend)
        {
            var Duration = addend.DurationEnum;
            var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
            var RelativeStart = addend.RelativeStart + augend.RelativeStart;
            var RelativeEnd = addend.RelativeEnd + augend.RelativeEnd;

            var result = new TimeContextEx(MeasureNumber);
            result.SetRelativeStart(RelativeStart);
            result.SetRelativeEnd(RelativeEnd);
            result.SetDuration(Duration);

            return result;
        }

        public XElement ToXElement(XElement xvoice)
        {
            var result = new XElement(Constants.XELEMENT_CHILD_CONTAINER, new object());

            result.Add(new XElement(XmlConstants.duration, this.Duration));
            
            if (null != xvoice)
                result.Add(xvoice);

            var noteTypeName = this.GetNoteLengthName();
            Debug.Assert(noteTypeName != null);
            if (!string.IsNullOrEmpty(noteTypeName))
            {
                result.Add(new XElement(XmlConstants.type, noteTypeName));
            }


            if (this.IsDotted)
            {
                result.Add(new XElement(XmlConstants.dot));
            }

            return result;
        }


    }//class

}//ns
