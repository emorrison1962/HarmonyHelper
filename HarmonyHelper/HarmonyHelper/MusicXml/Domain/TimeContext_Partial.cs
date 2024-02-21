using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class TimeContext : ITimeContext
    {
        public int AbsoluteEnd
        {
            get
            {
                return (this.Rhythm.PulsesPerMeasure * this.MeasureNumber) + this.RelativeEnd;
            }
        }

        public int AbsoluteStart
        {
            get
            {
                return (this.Rhythm.PulsesPerMeasure * this.MeasureNumber) + this.RelativeStart;
            }
        }

        public int Duration
        {
            get
            {
                return RelativeEnd - RelativeStart;
            }
        }

        public bool IsDotted { get; private set; }

        public int MeasureNumber { get; private set; }

        public int RelativeEnd { get; protected set; } = int.MinValue;

        public int RelativeStart { get; protected set; } = int.MinValue;

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

        public TieTypeEnum TieType { get; set; } = TieTypeEnum.None;

        public TimeContext SetIsDotted(bool isDotted)
        {
            throw new NotImplementedException();
        }

        public TimeContext SetMeasureNumber(int measureNumber)
        {
            throw new NotImplementedException();
        }

        public TimeContext SetRelativeEnd(int end)
        {
            throw new NotImplementedException();
        }

        public TimeContext SetRelativeStart(int start)
        {
            throw new NotImplementedException();
        }

        public TimeContext SetRhythmicContext(RhythmicContext ctx)
        {
            throw new NotImplementedException();
        }

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

    }//class
}//ns
