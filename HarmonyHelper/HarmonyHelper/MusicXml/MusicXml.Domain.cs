using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class PartIdentifier
    {
        public string ID;
        public string Name;
        public PartIdentifier(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"{nameof(PartIdentifier)}: ID={ID}, Name={Name}";
        }
    }

    public class MusicXmlParsingResult
    {
        public MusicXmlScoreMetadata Metadata { get; set; }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();

        public List<TimedEvent<ChordFormula>> Get(int bar, int start, int end)
        {
            var result = this.Parts
                .SelectMany(p => p.Measures.Where(x => x.MeasureNumber == bar)
                .SelectMany(m => m.Chords))
                .ToList();
            return result;
        }
    }//class

    public class MusicXmlScoreMetadata
    {
        public string Title { get; set; }
        public KeySignature KeySignature { get; set; }
        public Eric.Morrison.Harmony.Rhythm.TimeSignature TimeSignatue { get; set; }
        public int Tempo { get; set; }
        public int PulsesPerQuarterNote { get; set; }
        public int PulsesPerMeasure 
        { 
            get 
            { 
                return this.TimeSignatue.BeatCount * this.PulsesPerQuarterNote; 
            } 
        }
    }

    public class MusicXmlPart
    {
        public PartIdentifier Identifier { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
        public XElement XElement { get; set; }
        public MusicXmlMeasure CurrentMeasure { get { return Measures.Last(); } }
        public MusicXmlPart(PartIdentifier PartIdentifier)
        {
            this.Identifier = PartIdentifier;   
        }
        public MusicXmlPart(PartIdentifier PartIdentifier, XElement xelement)
            : this(PartIdentifier)
        {
            this.XElement= xelement; 
        }
        public override string ToString()
        {
            return $"{nameof(MusicXmlPart)}: {Identifier}";
        }
    }//class

    public class MusicXmlMeasure
    {
        #region Properties
        public int MeasureNumber { get; set; }
        public List<TimedEvent<ChordFormula>> Chords { get; set; } = new List<TimedEvent<ChordFormula>>();
        public List<TimedEvent<Note>> Notes { get; set; } = new List<TimedEvent<Note>>();
        public List<TimedEvent<Rest>> Rests { get; set; } = new List<TimedEvent<Rest>>();

        #endregion

        #region Construction
        public MusicXmlMeasure(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
        }

        static public MusicXmlMeasure CreateMerged(List<MusicXmlMeasure> items)
        {
            if (null == items || items.Count == 0)
                throw new ArgumentNullException("items");

            var result = new MusicXmlMeasure(items.First().MeasureNumber);

            var chords = items.SelectMany(x => x.Chords
                .Select(y => y))
                .ToList();
            var notes = items.SelectMany(x => x.Notes
                .Select(y => y))
                .ToList();
            var rests = items.SelectMany(x => x.Rests
                .Select(y => y))
                .ToList();

            result.AddRange(chords.Distinct().ToList());
            result.AddRange(notes.Distinct().ToList());
            result.AddRange(rests.Distinct().ToList());

            result.Chords = result.Chords.OrderBy(x => x.AbsoluteStart).ToList();
            result.Notes = result.Notes.OrderBy(x => x.AbsoluteStart).ToList();
            result.Rests = result.Rests.OrderBy(x => x.AbsoluteStart).ToList();

            return result;
        }

        #endregion

        public void Add(TimedEvent<ChordFormula> e) 
        { 
            this.Chords.Add(e);
        }
        public void Add(TimedEvent<Note> e)
        {
            this.Notes.Add(e);
        }
        public void Add(TimedEvent<Rest> e) 
        {
            this.Rests.Add(e);
        }

        public void AddRange(List<TimedEvent<ChordFormula>> e)
        {
            this.Chords.AddRange(e);
        }
        public void AddRange(List<TimedEvent<Note>> e)
        {
            this.Notes.AddRange(e);
        }
        public void AddRange(List<TimedEvent<Rest>> e)
        {
            this.Rests.AddRange(e);
        }

        public class Envelope 
        {
            public IHasTimeContext Event { get; set; }
            public Envelope(IHasTimeContext Event)
            {
                this.Event = Event;
            }
        }
        public List<IHasTimeContext> GetMergedEvents()
        {
            var result = new List<IHasTimeContext>();
            
            result.AddRange(this.Chords.Select(x => x));
            result.AddRange(this.Notes.Select(x => x));
            result.AddRange(this.Rests.Select(x => x));

            result = result.OrderBy(x => x.TimeContext).ToList();

            return result;
        }


        public override string ToString()
        {
            return $"{nameof(MusicXmlMeasure)}: MeasureNumber={this.MeasureNumber}, Chords={Chords.Count}, Notes={Notes.Count}, Rests={Rests.Count}";
        }
    }

    public class TimedEvent<T> : IHasTimeContext, IEquatable<TimedEvent<T>>, IComparable<TimedEvent<T>> 
        where T : class, IMusicalEvent<T>, IComparable<T>
    {
        public int AbsoluteStart { get { return this.TimeContext.AbsoluteStart; } }
        public int AbsoluteEnd { get { return this.TimeContext.AbsoluteEnd; } }
        public int RelativeStart { get { return this.TimeContext.RelativeStart; } }
        public int RelativeEnd { get { return this.TimeContext.RelativeEnd; } }
        public int Duration { get { return this.TimeContext.Duration; } }

        public T Event { get; set; }
        public TimeContext TimeContext { get; set; }
        
        public TimedEvent(T @event, TimeContext ctx)
        {
            this.Event = @event;
            this.TimeContext = ctx;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        public bool Equals(TimedEvent<T> other)
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
            if (obj is TimedEvent<T>)
                result = this.Equals(obj as TimedEvent<T>);
            return result;
        }
        public int CompareTo(TimedEvent<T> other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEvent<T> a, TimedEvent<T> b)
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
            //Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}: {this.ToString()}={result}");

            return result;
        }
        public static bool operator ==(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

    }//class

    public class TimeContext : IEquatable<TimeContext>, IComparable<TimeContext>
    {
        #region Properties
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

        #endregion

        public TimeContext(int measure, int ppm, int start, int end)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.MeasureNumber= measure;
            this.PulsesPerMeasure= ppm;
            this.RelativeStart = start;
            this.RelativeEnd = end;
            this.Duration = this.RelativeEnd - this.RelativeStart;
        }

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
        public string GetNoteType()
        {
            var nt = this.PulsesPerMeasure / this.Duration;
            var nlde = (NoteLengthDivisorEnum)nt;
            return nlde.ToString();
        }
    }//class

    public class TimedEventFactory
    {
        static public TimedEventFactory Instance { get; } = new TimedEventFactory();
        public int PulsesPerMeasure { get; set; } = int.MinValue;

        TimedEventFactory() { }

        public TimedEvent<ChordFormula> CreateTimedEvent(ChordFormula formula,
            int measureNumber,
            int start, 
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var result = new TimedEvent<ChordFormula>(formula,
                new TimeContext(
                    measureNumber,
                    PulsesPerMeasure,
                    start,
                    end));
            return result;
        }

        public TimedEvent<Note> CreateTimedEvent(Note note,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var result = new TimedEvent<Note>(note,
                new TimeContext(
                    measureNumber,
                    PulsesPerMeasure,
                    start,
                    end));
            return result;
        }
        public TimedEvent<Rest> CreateTimedEvent(Rest rest,
            int measureNumber,
            int start,
            int end)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var result = new TimedEvent<Rest>(rest,
                new TimeContext(
                    measureNumber,
                    PulsesPerMeasure,
                    start,
                    end));
            return result;
        }

    }//class

    public class ParsingContext
    {
        #region Properties
#if DEBUG
        MusicXmlPart CurrentPart { get; set; }
#endif
        public MusicXmlScoreMetadata Metadata { get; set; }
        public MusicXmlMeasure CurrentMeasure { get; set; }


        int _CurrentOffset = 0;
#warning FIXME: Refactor this to a backing store prop after setters are working properly.
        public int CurrentOffset
        {
            get
            {
                return _CurrentOffset;
            }
            set
            {
                _CurrentOffset = value;
                Debug.Assert(_CurrentOffset <= 481);
                Debug.Assert(_CurrentOffset >= 0);
                //Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();

        //public ConcurrentDictionary<TiedNoteContext, TiedNoteContext> TiedNotes { get; set; } = new ConcurrentDictionary<TiedNoteContext, TiedNoteContext>();

        public ChordTimeContext ChordTimeContext { get; set; } = new ChordTimeContext();

        #endregion
    }//class

    public class TimeModification
    {
        public int Normal { get; set; }
        public int Actual { get; set; }

        public TimeModification(XElement xtime_modification)
        {
#if false
        <time-modification>
            <actual-notes>3</actual-notes>
            <normal-notes>2</normal-notes>
            <normal-type>eighth</normal-type>
        </time-modification>
#endif
            this.Actual = int.Parse(xtime_modification.Element(XmlConstants.actual_notes).Value);
            this.Normal = int.Parse(xtime_modification.Element(XmlConstants.normal_notes).Value);
        }

        public int GetDuration(int duration)
        { 
            var result = (duration * this.Normal) / this.Actual;
            return result;
        }
    }

}//ns
