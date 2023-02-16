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
    public class TimedEventBackup : TimedEventBase, IHasTimeContext, IEquatable<TimedEventBackup>, IComparable<TimedEventBackup>, IHasIsValid
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public Backup Event { get; set; }

        #endregion

        #region Construction
        public TimedEventBackup(TimedEventBackup src)
            : base(src)
        {
            this.Event = src.Event.Copy();
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventBackup(Backup backup, TimeContext ctx)
            : base(ctx)
        {
            this.Event = backup;
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

        override public XElement ToXElement()
        {
            var rest = this.Event;
            var time = this.TimeContext;

            var xbackup = new XElement(XmlConstants.backup);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xbackup.Add(xduration);
            return xbackup;
        }

        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEventBackup other)
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
            if (obj is TimedEventBackup)
                result = this.Equals(obj as TimedEventBackup);
            return result;
        }
        public int CompareTo(TimedEventBackup other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEventBackup a, TimedEventBackup b)
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

        new public bool IsValid()
        {
            var result = base.IsValid();
            if (result && Event == null)
            {
                result = false;
                Debug.Assert(result);
            }
            return result;
        }

        public static bool operator ==(TimedEventBackup a, TimedEventBackup b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEventBackup a, TimedEventBackup b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class
}//ns
