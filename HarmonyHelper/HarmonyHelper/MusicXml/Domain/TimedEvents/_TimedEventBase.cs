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
    abstract public class TimedEventBase : IHasTimeContext
    {
        #region Properties
        public int RelativeStart { get { return this.TimeContext.RelativeStart; } }
        public int RelativeEnd { get { return this.TimeContext.RelativeEnd; } }
        abstract public int SortOrder { get; }
        virtual public TimeContext TimeContext { get; set; }
        public XmlSerializationProperties Serialization { get; set; } = new XmlSerializationProperties();
        public MusicXmlTimeModification TimeModification { get; set; }
        public bool HasTimeModification { get { return null == this.TimeModification; } }

        #endregion

        #region Construction
        public TimedEventBase(TimedEventBase src)
        {
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventBase(TimeContext ctx)
        {
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

        abstract public XElement ToXElement();

        [Obsolete("", false)]
        protected void ToXElements(TimeContextEx time, out XElement xnoteTypeName, out XElement xduration, out XElement xdot)
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
            return $"{this.GetType().Name} TimeContext={this.TimeContext}";
        }

    }//class

    public static class TimedEventExtensions
    {
        public static List<TimedEventNote> GetIntersecting(this List<TimedEventNote> src, TimeContext window)
        {
            var result = new List<TimedEventNote>();
            foreach (var item in src)
            {
                if (item.TimeContext.Intersects(window))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }//class


    public class XmlSerializationProperties
    {
        public string Voice { get; set; }
        public string Staff { get; set; }
        public bool HasChord { get; set; }
        int Forward { get; set; }
        int Backup { get; set; }
        bool HasForward { get { return  this.Forward != 0; } }
        bool HasBackup { get { return  this.Backup != 0; } }   
        public string Attack { get; set; }
        public string Release { get; set; }

        public XmlSerializationProperties() { }
        public XmlSerializationProperties(XmlSerializationProperties src) 
        { 
            this.Staff = src.Staff;
            this.Forward = src.Forward; 
            this.Backup = src.Backup;
            this.Attack = src.Attack;
            this.Release = src.Release;
            this.Voice = src.Voice; 
        }
    }

}//ns
