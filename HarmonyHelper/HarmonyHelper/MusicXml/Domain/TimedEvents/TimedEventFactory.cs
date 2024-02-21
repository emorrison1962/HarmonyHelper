using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
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
            bool isDotted,
            DurationEnum de,
            TimeModification timeModification,
            XElement xnote)
        {
            Debug.Assert(de != DurationEnum.None);
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = de,
                IsDotted = isDotted,
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
            bool isDotted,
            DurationEnum de,
            TimeModification timeModification,
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
                Duration = de,
                IsDotted = isDotted,
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
            TimeModification timeModification)
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
            TimeModification timeModification)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
            };
            var time = new TimeContext(ctx);
            var result = new TimedEventBackup(backup,
                time);
            result.TimeModification = timeModification;
            return result;
        }

    }//class

}//ns
