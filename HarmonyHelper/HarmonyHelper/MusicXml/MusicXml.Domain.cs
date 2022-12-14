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
        public int PPQN { get; set; }
    }

    public class MusicXmlPart
    {
        public PartIdentifier Identifier { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
        public MusicXmlMeasure CurrentMeasure { get { return Measures.Last(); } }
        public MusicXmlPart(PartIdentifier PartIdentifier)
        {
            this.Identifier = PartIdentifier;   
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
        public int Start { get; set; }
        public int End { get; set; }
        public int Duration { get; set; }
        public T Event { get; set; }
        public TimedEvent(T @event, int start, int end)
        {
            if (end <= start)
                throw new ArgumentOutOfRangeException();
            this.Start = start;
            this.End = end;
            this.Duration = this.End - this.Start;
            Debug.Assert(this.Duration > 10);

            this.Event = @event;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} Start={this.Start} End={this.End} Event={this.Event.ToString()}";
        }
    }//class

    public class ParsingContext
    {
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();
        #region Properties
#if DEBUG
        public PartIdentifier CurrentPartName { get; set; }
#endif

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
                Debug.Assert(_CurrentOffset <= 480);
                Debug.Assert(_CurrentOffset >= 0);
                //Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }

        public ConcurrentDictionary<TiedNoteContext, TiedNoteContext> TiedNotes { get; set; } = new ConcurrentDictionary<TiedNoteContext, TiedNoteContext>();

        public ChordTimeContext ChordTimeContext { get; set; } = new ChordTimeContext();

        #endregion
    }//class

}//ns
