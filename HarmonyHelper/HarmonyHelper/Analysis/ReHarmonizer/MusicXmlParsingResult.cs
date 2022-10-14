using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony
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
        public string ID { get; set; }
        public string Name { get; set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
    }
    
    public class MusicXmlMeasure
    {
        public int MeasureNumber { get; set; }
        public List<TimedEvent<ChordFormula>> Chords { get; set; } = new List<TimedEvent<ChordFormula>>();
        public List<TimedEvent<NoteName>> Notes { get; set; } = new List<TimedEvent<NoteName>>();
        public MusicXmlMeasure(int measureNumber)
        {
            this.MeasureNumber = measureNumber;  
        }
    }
    
    public class TimedEvent<T>
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
    }
}
