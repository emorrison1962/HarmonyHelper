using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimeContext : IEquatable<TimeContext>, IComparable<TimeContext>
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

        #region Properties
        public TimeSignature TimeSignature { get; set; }
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

        #region Note Types
        public int Whole
        {
            get
            {
                var result = this.PulsesPerMeasure;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int Half
        {
            get
            {
                var result = this.PulsesPerMeasure / 2;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int DottedHalf
        {
            get
            {
                var result = this.Quarter * 3;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int Quarter
        {
            get
            {
                var result = this.PulsesPerMeasure / 4;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int DottedQuarter
        {
            get
            {
                var result = this.Eighth * 3;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int Eighth
        {
            get
            {
                var result = this.PulsesPerMeasure / 8;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int DottedEighth
        {
            get
            {
                var result = this._16th * 3;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _16th
        {
            get
            {
                var result = this.PulsesPerMeasure / 16;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int DottedSixteenth
        {
            get
            {
                var result = this._32nd * 3;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _32nd
        {
            get
            {
                var result = this.PulsesPerMeasure / 32;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _64th
        {
            get
            {
                var result = this.PulsesPerMeasure / 64;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _128th
        {
            get
            {
                var result = this.PulsesPerMeasure / 128;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _256th
        {
            get
            {
                var result = this.PulsesPerMeasure / 256;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _512th
        {
            get
            {
                var result = this.PulsesPerMeasure / 512;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        public int _1024th
        {
            get
            {
                var result = this.PulsesPerMeasure / 1024;
                if (0 == result)
                    throw new ArgumentOutOfRangeException("result");
                return result;
            }
        }
        int Breve
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        int Long
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        int Maxima
        {
            get { throw new NotSupportedException(); }
        }

        #endregion

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
        public TimeContext(TimeSignature ts, int measure, int ppm, int start, int end)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.TimeSignature = ts;
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
        public NoteLengthDivisorEnum NoteLengthDivisor()
        {
            throw new NotImplementedException("Fix this.");
            var nt = this.PulsesPerMeasure / (float)this.Duration;
            if (Enum.TryParse<NoteLengthDivisorEnum>(nt.ToString(), out var nlde))
                new object();
            else
                new object();
            return nlde;
        }

        static public TimeContext CopyWithOffset(TimeContext src, int offset)
        {
            var result = new TimeContext(src);
            result.MeasureNumber = result.MeasureNumber + offset;
            return result;
        }

        public bool TryGetName(int duration, out string name, out bool isDotted)
        {
            var result = false;
            name = string.Empty;
            isDotted = false;
            if (duration == this.Whole)
            {
                name = NoteType_whole;
            }

            else if (duration == this.DottedHalf)
            {
                name = NoteType_half;
                isDotted = true;
            }
            else if (duration == this.Half)
            {
                name = NoteType_half;
            }
            else if (duration == this.DottedQuarter)
            {
                name = NoteType_quarter;
                isDotted = true;
            }
            else if (duration == this.Quarter)
            {
                name = NoteType_quarter;
            }
            else if (duration == this.DottedEighth)
            {
                name = NoteType_eighth;
                isDotted = true;
            }
            else if (duration == this.Eighth)
            {
                name = NoteType_eighth;
            }
            else if (duration == this._16th)
            {
                name = NoteType_16th;
            }
            else if (duration == this._32nd)
            {
                name = NoteType_32nd;
            }
            else if (duration == this._64th)
            {
                name = NoteType_64th;
            }
            else if (duration == this._128th)
            {
                name = NoteType_128th;
            }
            else if (duration == this._256th)
            {
                name = NoteType_256th;
            }
            else if (duration == this._512th)
            {
                name = NoteType_512th;
            }


            return result;
        }

        public static TimeContext operator +(TimeContext addend, TimeContext augend)
        {
            var PulsesPerMeasure = addend.PulsesPerMeasure;
            var MeasureNumber = addend.MeasureNumber + augend.MeasureNumber;
            var RelativeStart = addend.RelativeStart + augend.RelativeStart;
            var RelativeEnd = addend.RelativeEnd + augend.RelativeEnd;
            return new TimeContext(MeasureNumber, 
                PulsesPerMeasure, 
                RelativeStart, 
                RelativeEnd);
        }
    }//class

}//ns
