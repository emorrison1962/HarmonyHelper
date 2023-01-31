using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimedEventForward : TimedEventBase, IHasTimeContext, IEquatable<TimedEventForward>, IComparable<TimedEventForward>
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public Forward Event { get; set; }

        #endregion

        #region Construction
        public TimedEventForward(TimedEventForward src)
            : base(src)
        {
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventForward(Forward f, TimeContext ctx)
            : base(ctx)
        {
            this.Event = f;
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

        override public XElement ToXElement()
        {
            var rest = this.Event;
            var time = this.TimeContext;

            var xforward = new XElement(XmlConstants.forward);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xforward.Add(xduration);
            return xforward;
        }


        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEventForward other)
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
            if (obj is TimedEventForward)
                result = this.Equals(obj as TimedEventForward);
            return result;
        }
        public int CompareTo(TimedEventForward other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEventForward a, TimedEventForward b)
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
            return result;
        }
        public static bool operator ==(TimedEventForward a, TimedEventForward b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEventForward a, TimedEventForward b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class
}//ns
