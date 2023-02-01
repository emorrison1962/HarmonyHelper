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
    public class TimedEventNote : TimedEventBase, IHasTimeContext, IEquatable<TimedEventNote>, IComparable<TimedEventNote>
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public Note Event { get; set; }
        protected TimeContextEx _TimeContext { get; set; }
        new public TimeContextEx TimeContext
        {
            get { return this._TimeContext; }
            set 
            { 
                if (value is TimeContextEx)
                    this._TimeContext = (TimeContextEx)value;
                else
                    Debug.Assert(false);
            }
        }

        #endregion

        #region Construction
        public TimedEventNote(TimedEventNote src)
            : base(src)
        {
            this.TimeContext = new TimeContextEx(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventNote(Note note, TimeContextEx ctx)
            : base(ctx)
        {
            this.Event = note;
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

        /// <summary>
        /// </summary>
        /// <param name="te"></param>
        /// <returns>
        ///      <note release="55">
        ///        <pitch>
        ///          <step>B</step>
        ///          <alter>-1</alter>
        ///          <octave>1</octave>
        ///        </pitch>
        ///         <duration>60</duration>
        ///         <voice>2</voice>
        ///         <type>eighth</type>
        ///         <beam number="1">begin</beam>
        ///      </note>
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        override public XElement ToXElement()
        {
            var nn = this.Event.NoteName;
            var note = this.Event;
            var time = this.TimeContext as TimeContextEx;

            var xnote = new XElement(XmlConstants.note);
            {
                if (null != this.Serialization.Attack)
                    xnote.Add(new XAttribute(XmlConstants.attack, this.Serialization.Attack));
                if (null != this.Serialization.Release)
                    xnote.Add(new XAttribute(XmlConstants.release, this.Serialization.Release));

                var xpitch = new XElement(XmlConstants.pitch);
                {
                    var xstep = new XElement(XmlConstants.step, nn.Name[0]);
                    xpitch.Add(xstep);

                    if (!nn.IsNatural)
                    {
                        XElement xalter = null;
                        if (nn.IsSharped)
                            xalter = new XElement(XmlConstants.alter, 1);
                        else if (nn.IsFlatted)
                            xalter = new XElement(XmlConstants.alter, -1);
                        xpitch.Add(xalter);
                    }

                    var xoctave = new XElement(XmlConstants.octave, (int)note.Octave);
                    xpitch.Add(xoctave);
                }
                if (this.Serialization.HasChord)
                {
                    xnote.Add(new XElement(XmlConstants.chord));
                }
                xnote.Add(xpitch);
                {
                    this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
                    xnote.Add(xduration);
                    xnote.Add(new XElement(XmlConstants.voice, this.Serialization.Voice));
                    xnote.Add(xnoteTypeName);
                    xnote.Add(xdot);

                    if (!string.IsNullOrEmpty(this.Serialization.Staff))
                        xnote.Add(new XElement(XmlConstants.staff, this.Serialization.Staff));
                }

                if (this.TimeContext.TieType != TieTypeEnum.None)
                {
#if false
        <notations>
          <tied type="start"/>
        </notations>
#endif
                    var xnotations = new XElement(XmlConstants.notations);
                    xnote.Add(xnotations);
                    if (this.TimeContext.TieType == TieTypeEnum.Start)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (this.TimeContext.TieType == TieTypeEnum.Stop)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (this.TimeContext.TieType == TieTypeEnum.StartStop)
                    {
                        var xtypeStart = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtiedStart = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStart);
                        var xtypeStop = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtiedStop = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStop);
                    }
                }
            }
            new object();
            return xnote;
        }

        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEventNote other)
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
            if (obj is TimedEventNote)
                result = this.Equals(obj as TimedEventNote);
            return result;
        }
        public int CompareTo(TimedEventNote other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEventNote a, TimedEventNote b)
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
        public static bool operator ==(TimedEventNote a, TimedEventNote b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEventNote a, TimedEventNote b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class
}//ns
