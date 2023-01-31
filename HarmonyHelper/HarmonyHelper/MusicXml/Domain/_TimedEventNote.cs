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
    abstract public class TimedEventNote : TimedEventBase, IHasTimeContext, IEquatable<TimedEventNote>, IComparable<TimedEventNote>
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public Note Event { get; set; }

        #endregion

        #region Construction
        public TimedEventNote(TimedEventNote src)
            : base(src)
        {
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventNote(TimeContext ctx)
            : base(ctx)
        {
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
        public XElement ToXElement()
        {
            var nn = te.Event.NoteName;
            var note = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            {
                if (null != te.Serialization.Attack)
                    xnote.Add(new XAttribute(XmlConstants.attack, te.Serialization.Attack));
                if (null != te.Serialization.Release)
                    xnote.Add(new XAttribute(XmlConstants.release, te.Serialization.Release));

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
                if (te.Serialization.HasChord)
                {
                    xnote.Add(new XElement(XmlConstants.chord));
                }
                xnote.Add(xpitch);
                {
                    this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
                    xnote.Add(xduration);
                    xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
                    xnote.Add(xnoteTypeName);
                    xnote.Add(xdot);

                    if (!string.IsNullOrEmpty(te.Serialization.Staff))
                        xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));
                }

                if (te.TimeContext.TieType != TieTypeEnum.None)
                {
#if false
        <notations>
          <tied type="start"/>
        </notations>
#endif
                    var xnotations = new XElement(XmlConstants.notations);
                    xnote.Add(xnotations);
                    if (te.TimeContext.TieType == TieTypeEnum.Start)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.Stop)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.StartStop)
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
        public XElement ToXElement<TE>(TimedEvent<Rest> te)
            where TE: TimedEvent<Rest> 
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
            var rest = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            var xrest = new XElement(XmlConstants.rest);
            xnote.Add(xrest);

            this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
            xnote.Add(xduration);
            xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
            xnote.Add(xnoteTypeName);
            xnote.Add(xdot);

            if (!string.IsNullOrEmpty(te.Serialization.Staff))
                xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));

            return xnote;
        }

        public XElement ToXElement<TE>(TimedEvent<Forward> te)
            where TE: TimedEvent<Forward>
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xforward = new XElement(XmlConstants.forward);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xforward.Add(xduration);
            return xforward;
        }

        public XElement ToXElement<TE>(TimedEvent<Backup> te)
            where TE: TimedEvent<Backup>
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xbackup = new XElement(XmlConstants.backup);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xbackup.Add(xduration);
            return xbackup;
        }

        void ToXElements(TimeContext time, out XElement xnoteTypeName, out XElement xduration, out XElement xdot)
        {
            time.TryGetName(time.DurationEnum, out var name, out var isDotted);
            xnoteTypeName = null; xduration = null; xdot = null;
#if true
            xnoteTypeName = new XElement(XmlConstants.type, name);

            xduration = new XElement(XmlConstants.duration, time.Duration);
            xdot = null;
            if (isDotted)
            {
                xdot = new XElement(XmlConstants.dot);
            }
#endif
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
