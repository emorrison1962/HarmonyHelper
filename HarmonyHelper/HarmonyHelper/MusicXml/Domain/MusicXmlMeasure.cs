using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Eric.Morrison.Harmony.Chords;
using Kohoutech.Score;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlMeasure
    {
        #region Properties
        public int MeasureNumber { get; set; }
        public XmlSerializationProperties Serialization { get; set; } = new XmlSerializationProperties();

        public bool HasMetadata { get; set; }   
        public List<TimedEvent<ChordFormula>> Chords { get; set; } = new List<TimedEvent<ChordFormula>>();
        public List<TimedEvent<Note>> Notes { get; set; } = new List<TimedEvent<Note>>();
        public List<TimedEvent<Rest>> Rests { get; set; } = new List<TimedEvent<Rest>>();
        public List<TimedEvent<Forward>> Forwards { get; set; } = new List<TimedEvent<Forward>>();
        public List<TimedEvent<Backup>> Backups { get; set; } = new List<TimedEvent<Backup>>();
        public bool HasForwards { get { return this.Forwards.Count > 0; } }
        public bool HasBackups { get { return this.Backups.Count > 0; } }

        List<ChordMelodyPairing> _ChordMelodyPairings;
        public List<ChordMelodyPairing> ChordMelodyPairings 
        {
            get 
            {
                if (null == this._ChordMelodyPairings)
                    this.CreateChordMelodyPairings();
                return this._ChordMelodyPairings;
            } 
        } 
        #endregion

        #region Construction

        public MusicXmlMeasure(int measureNumber)
        {
            this.MeasureNumber = measureNumber;
        }
        public MusicXmlMeasure(int measureNumber,
            List<TimedEvent<ChordFormula>> Chords,
            List<TimedEvent<Note>> Notes,
            List<TimedEvent<Rest>> Rests,
            List<TimedEvent<Forward>> Forwards,
            List<TimedEvent<Backup>> Backups)
        {
            this.MeasureNumber = measureNumber;
            if (null != Chords)
                this.Chords = Chords;
            if (null != Notes)
                this.Notes = Notes;
            if (null != Rests)
                this.Rests = Rests;
            if (null != Forwards)
                this.Forwards = Forwards;
            if (null != Backups)
                this.Backups = Backups; 
        }
        public MusicXmlMeasure(MusicXmlMeasure src)
        {
            this.MeasureNumber = src.MeasureNumber;
            this.Notes = src.Notes.Select(x => new TimedEvent<Note>(x)).ToList();
            this.Chords = src.Chords.Select(x => new TimedEvent<ChordFormula>(x)).ToList();
            this.Rests = src.Rests.Select(x => new TimedEvent<Rest>(x)).ToList();
            this.Forwards = src.Forwards.Select(x => new TimedEvent<Forward>(x)).ToList();
            this.Backups = src.Backups.Select(x => new TimedEvent<Backup>(x)).ToList();
            
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        [Obsolete("", true)]
        static public MusicXmlMeasure CopyWithOffset(MusicXmlMeasure src, int offset)
        {
            var result = new MusicXmlMeasure(src);
            result.Notes.ForEach(x => x.TimeContext = TimeContext
                .CopyWithOffset(x.TimeContext, offset));
            result.Chords.ForEach(x => x.TimeContext = TimeContext
                .CopyWithOffset(x.TimeContext, offset));
            result.Rests.ForEach(x => x.TimeContext = TimeContext
                .CopyWithOffset(x.TimeContext, offset));
            result.Forwards.ForEach(x => x.TimeContext = TimeContext
                .CopyWithOffset(x.TimeContext, offset));
            result.Backups.ForEach(x => x.TimeContext = TimeContext
                .CopyWithOffset(x.TimeContext, offset));
            return result;
        }

        public void AddOffset(TimeContext tc)
        {
            this.MeasureNumber += tc.MeasureNumber;
            this.Notes.ForEach(x => x.TimeContext += tc);
            this.Chords.ForEach(x => x.TimeContext += tc);
            this.Rests.ForEach(x => x.TimeContext += tc);
            this.Forwards.ForEach(x => x.TimeContext += tc);
            this.Backups.ForEach(x => x.TimeContext += tc);
        }

        [Obsolete("", true)]
        static public MusicXmlMeasure CreateMergedMeasure(List<MusicXmlMeasure> items)
        {
            if (null == items || items.Count == 0)
                throw new ArgumentNullException("items");

            var chords = items.SelectMany(x => x.Chords
                .Select(y => y))
                .ToList();
            var notes = items.SelectMany(x => x.Notes
                .Select(y => y))
                .ToList();
            var rests = items.SelectMany(x => x.Rests
                .Select(y => y))
                .ToList();
            var forwards = items.SelectMany(x => x.Forwards
                .Select(y => y))
                .ToList();
            var backups = items.SelectMany(x => x.Backups
                .Select(y => y))
                .ToList();

            if (forwards.Count > 0 || backups.Count > 0)
                new object();

            var result = new MusicXmlMeasure(
                items.First().MeasureNumber,
                chords.Distinct().ToList(),
                notes.Distinct().ToList(),
                rests.Distinct().ToList(),
                forwards.Distinct().ToList(),
                backups.Distinct().ToList());

            if (items.Any(x => x.HasMetadata))
                new object();
            result.Chords = result.Chords.OrderBy(x => x.TimeContext.AbsoluteStart).ToList();
            result.Notes = result.Notes.OrderBy(x => x.TimeContext.AbsoluteStart).ToList();
            result.Rests = result.Rests.OrderBy(x => x.TimeContext.AbsoluteStart).ToList();
            result.Forwards = result.Forwards.OrderBy(x => x.TimeContext.AbsoluteStart).ToList();
            result.Backups = result.Backups.OrderBy(x => x.TimeContext.AbsoluteStart).ToList();

            return result;
        }

        #endregion

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
            result.AddRange(this.Forwards.Select(x => x));
            result.AddRange(this.Backups.Select(x => x));

            result = result.OrderBy(x => x.TimeContext.RelativeStart)
                .ThenBy(x => x.SortOrder)
                .ToList();

            return result;
        }

        public void CreateChordMelodyPairings()
        {
            var result = new List<ChordMelodyPairing>();
            foreach (var chord in this.Chords)
            {
                var notes = this.Notes.GetIntersecting(chord.TimeContext);
                var pairing = new ChordMelodyPairing(chord,
                    notes.ToList(),
                    chord.TimeContext);
                result.Add(pairing);
            }
            this._ChordMelodyPairings = result;
        }

        public override string ToString()
        {
            var chords = string.Join(",", this.Chords.Select(x => x.Event));
            var nns = this.Notes
                .Select(x => x.Event.NoteName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var notes = string.Join(",", nns);
            return $"{nameof(MusicXmlMeasure)}: MeasureNumber={this.MeasureNumber}, Chords={chords}, Notes={notes}, Rests={Rests.Count}, HasMetadata={this.HasMetadata}";
        }
    }//class
}//ns
