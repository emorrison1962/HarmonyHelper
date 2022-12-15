using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public TimeSignature TimeSignatue { get; set; }
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
        public int MeasureNumber { get; set; }
        public List<TimedEvent<ChordFormula>> Chords { get; set; } = new List<TimedEvent<ChordFormula>>();
        public List<TimedEvent<Note>> Notes { get; set; } = new List<TimedEvent<Note>>();
        public List<TimedEvent<Rest>> Rests { get; set; } = new List<TimedEvent<Rest>>();


        public MusicXmlMeasure(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
        }

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

        public override string ToString()
        {
            return $"{nameof(MusicXmlMeasure)}: MeasureNumber={this.MeasureNumber}, Chords={Chords.Count}, Notes={Notes.Count}, Rests={Rests.Count}";
        }
    }

    public class TimedEvent<T> where T : class
    {
        public int StartFromSong { get; set; }
        public int EndFromSong { get; set; }

        public int StartFromMeasure { get; set; }
        public int EndFromMeasure { get; set; }

        public int Duration { get; set; }
        public T Event { get; set; }
        public TimedEvent(T @event, int start, int end)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.StartFromMeasure = start;
            this.EndFromMeasure = end;
            Debug.WriteLine($"{this.StartFromMeasure}:{this.EndFromMeasure}, {this.StartFromSong}:{this.EndFromMeasure}, {@event.GetType().Name}");
            this.Duration = this.EndFromMeasure - this.StartFromMeasure;

            this.Event = @event;
        }
        public TimedEvent(T @event, int start, int end, int measure, int ppm)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.StartFromMeasure = start;
            this.EndFromMeasure = end;
            this.StartFromSong = measure * ppm + start;
            this.EndFromSong = measure * ppm + end;
            Debug.WriteLine($"*** {this.StartFromMeasure}: {this.EndFromMeasure}, {@event.GetType().Name} ");
            this.Duration = this.EndFromMeasure - this.StartFromMeasure;

            this.Event = @event;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} Start={this.StartFromMeasure} End={this.EndFromMeasure} Event={this.Event.ToString()}";
        }
    }//class

    public class TimedEventFactory
    {
        static public TimedEventFactory Instance { get; } = new TimedEventFactory();
        public int PulsesPerMeasure { get; set; } = int.MinValue;

        TimedEventFactory() { }

        public TimedEvent<ChordFormula> CreateTimedEvent(ChordFormula formula, 
            int start, 
            int end,
            int measureNumber)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var result = new TimedEvent<ChordFormula>(formula,
                start,
                end,
                measureNumber * PulsesPerMeasure + start,
                measureNumber * PulsesPerMeasure + end );
            return result;
        }
    }

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
