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
        public TimeContext TimeContext { get; set; }
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
        protected void ToXElements(TimeContext time, out XElement xnoteTypeName, out XElement xduration, out XElement xdot)
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

    public class TimedEventFactory
    {
        static public TimedEventFactory Instance { get; } = new TimedEventFactory();
        public int PulsesPerMeasure { get; set; } = int.MinValue;

        TimedEventFactory() { }

        public TimedEventChordFormula CreateTimedEvent(ChordFormula formula,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = DurationEnum.None
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventChordFormula(formula, 
                time);
            return result;
        }

        public TimedEventNote CreateTimedEvent(Note note,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            DurationEnum de,
            MusicXmlTimeModification timeModification,
            XElement xnote)
        {
            Debug.Assert(de != DurationEnum.Unknown);
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = de
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventNote(note,
                time);
            result.TimeModification = timeModification;
            return result;
        }
        public TimedEventRest CreateTimedEvent(Rest rest,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            DurationEnum de,
            MusicXmlTimeModification timeModification,
            XElement xnote)
        {
            //Debug.Assert(de != DurationEnum.None);
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = de
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventRest(rest,
                time);
            result.TimeModification = timeModification;
            return result;
        }

        public TimedEventForward CreateTimedEvent(Forward forward,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            MusicXmlTimeModification timeModification)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventForward(forward,
                time);
            result.TimeModification = timeModification;
            return result;
        }

        public TimedEventBackup CreateTimedEvent(Backup backup,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            MusicXmlTimeModification timeModification)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = DurationEnum.None
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventBackup(backup,
                time);
            result.TimeModification = timeModification;
            return result;
        }

    }//class

}//ns
