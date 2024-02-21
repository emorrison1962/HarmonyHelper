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
    public class TimedEventRest : TimedEventBase, IHasTimeContext, IEquatable<TimedEventRest>, IComparable<TimedEventRest>, IHasIsValid
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public Rest Event { get; set; }

        protected TimeContext _TimeContext { get; set; }
        new public TimeContext TimeContext
        {
            get { return this._TimeContext; }
            set
            {
                if (value is TimeContext)
                    this._TimeContext = (TimeContext)value;
                else
                    Debug.Assert(false);
            }
        }
        #endregion

        #region Construction
        public TimedEventRest(TimedEventRest src)
            : base(src)
        {
            this.Event = src.Event.CopyEx();
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventRest(Rest rest, TimeContext ctx)
            : base(ctx)
        {
            this.Event = rest;
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

        override public XElement ToXElement()
        {
#if false
      <note>
        <rest/>
         <duration>120</duration>
         <voice>1</voice>
         <type>quarter</type>
         <staff>1</staff>
      </note>

#endif
            var rest = this.Event;

            var xnote = new XElement(XmlConstants.note);
            var xrest = new XElement(XmlConstants.rest);
            xnote.Add(xrest);

            var xvoice = new XElement(XmlConstants.voice, this.Serialization.Voice);

            var xparent = this.TimeContext.ToXElement(xvoice);
            foreach (var xchild in xparent.Elements())
                xnote.Add(xchild);

            if (!string.IsNullOrEmpty(this.Serialization.Staff))
                xnote.Add(new XElement(XmlConstants.staff, this.Serialization.Staff));

            return xnote;
        }


        #endregion

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

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEventRest other)
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
            if (obj is TimedEventRest)
                result = this.Equals(obj as TimedEventRest);
            return result;
        }
        public int CompareTo(TimedEventRest other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEventRest a, TimedEventRest b)
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

        public static bool operator ==(TimedEventRest a, TimedEventRest b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEventRest a, TimedEventRest b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class
}//ns
