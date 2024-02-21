using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
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


    public partial class TimeContext : IHasIsValid
    {
        public class CreationContext
        {
            public DurationEnum Duration { get; set; }
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


        #region Properties
        public DurationEnum _Duration { get; protected set; }
        public DurationEnum Duration
        {
            get { return this._Duration; }
            protected set
            {
                this._Duration = value;
            }
        }

        #endregion

        #region Construction

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

        public TimeContext(int measureNumber, RhythmicContext rhythm, DurationEnum duration)
            : this(measureNumber, rhythm)
        {
            this.Duration = duration;
            this.RelativeStart = 0;
            this.RelativeEnd = this.Rhythm.PulsesPerMeasure * this.MeasureNumber | (int)duration;
        }

        public TimeContext(Measure measure, RhythmicContext rhythm, DurationEnum duration)
            : this(measure.MeasureNumber, rhythm, duration)
        {
        }

        public TimeContext(CreationContext ctx)
            : this(ctx.MeasureNumber, ctx.Rhythm)
        {
            this.RelativeStart = ctx.RelativeStart;
            this.RelativeEnd = ctx.RelativeEnd;
            this.Duration = ctx.Duration;
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
            this.Duration = src.Duration;
        }
        public TimeContext()
        {
        }

        #endregion

        #region Fluency
        public TimeContext SetDuration(DurationEnum duration)
        {
            this.Duration = duration;
            return this;
        }

        #endregion


        public bool IsValid()
        {
            var result = true;
            if (result && _Duration == DurationEnum.None)
            {
                result = false;
                Debug.Assert(result);
            }

            return result;
        }

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

        public string GetNoteLengthName()
        {
            var result = string.Empty;

            switch (this._Duration)
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

        public static TimeContext operator +(TimeContext addend, TimeContext augend)
        {
            var Duration = addend.Duration;
            var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
            var RelativeStart = addend.RelativeStart + augend.RelativeStart;
            var RelativeEnd = addend.RelativeEnd + augend.RelativeEnd;

            var result = new TimeContext(MeasureNumber);
            result.SetRelativeStart(RelativeStart);
            result.SetRelativeEnd(RelativeEnd);
            result.SetDuration((DurationEnum)Duration);

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
