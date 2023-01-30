using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml.Domain;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlMeasure : ClassBase, IDisposable
    {
        private bool disposedValue;
        #region Properties
        public MusicXmlPart Part { get; private set; }
        public int _MeasureNumber { get; set; }
        public int MeasureNumber
        {
            get { return _MeasureNumber; }
            set
            {
                Debug.Assert(value < 18 * 1000);
                Debug.Assert(value >= 0);
                _MeasureNumber = value;
            }
        }
        public XmlSerializationProperties Serialization { get; set; } = new XmlSerializationProperties();

        public bool HasMetadata { get; set; }
        public List<MusicXmlBarlineContext> BarlineContexts { get; set; } = new List<MusicXmlBarlineContext>();

        List<TimedEvent<ChordFormula>> _Chords { get; set; } = new List<TimedEvent<ChordFormula>>();
        List<TimedEvent<Note>> _Notes { get; set; } = new List<TimedEvent<Note>>();
        List<TimedEvent<Rest>> _Rests { get; set; } = new List<TimedEvent<Rest>>();
        List<TimedEvent<Forward>> _Forwards { get; set; } = new List<TimedEvent<Forward>>();
        List<TimedEvent<Backup>> _Backups { get; set; } = new List<TimedEvent<Backup>>();

        public ReadOnlyCollection<TimedEvent<ChordFormula>> Chords
        { get { return this._Chords.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEvent<Note>> Notes
        { get { return this._Notes.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEvent<Rest>> Rests
        { get { return this._Rests.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEvent<Forward>> Forwards
        { get { return this._Forwards.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEvent<Backup>> Backups
        { get { return this._Backups.AsReadOnly(); } }

        public bool HasForwards { get { return this.Forwards.Count > 0; } }
        public bool HasBackups { get { return this.Backups.Count > 0; } }

        #endregion

        #region Construction

        public MusicXmlMeasure(MusicXmlPart part, int measureNumber)
        {
            if (part == null)
                throw new ArgumentNullException(nameof(part));
            this.Part = part;
            this.MeasureNumber = measureNumber;
        }
        public MusicXmlMeasure(
            MusicXmlPart part,
            int measureNumber,
            List<TimedEvent<ChordFormula>> Chords,
            List<TimedEvent<Note>> Notes,
            List<TimedEvent<Rest>> Rests,
            List<TimedEvent<Forward>> Forwards,
            List<TimedEvent<Backup>> Backups)
            : this(part, measureNumber)
        {
            if (null != Chords)
                this.AddRange(Chords);
            if (null != Notes)
                this.AddRange(Notes);
            if (null != Rests)
                this.AddRange(Rests);
            if (null != Forwards)
                this.AddRange(Forwards);
            if (null != Backups)
                this.AddRange(Backups);
        }
        public MusicXmlMeasure(MusicXmlMeasure src)
            : this(src.Part, src.MeasureNumber)
        {
            this.MeasureNumber = src.MeasureNumber;
            this._Notes = src.Notes.Select(x => new TimedEvent<Note>(x)).ToList();
            this._Chords = src.Chords.Select(x => new TimedEvent<ChordFormula>(x)).ToList();
            this._Rests = src.Rests.Select(x => new TimedEvent<Rest>(x)).ToList();
            this._Forwards = src.Forwards.Select(x => new TimedEvent<Forward>(x)).ToList();
            this._Backups = src.Backups.Select(x => new TimedEvent<Backup>(x)).ToList();

            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public void SetMeasureNumber(int measureNumber)
        {
            //Debug.WriteLine($"{this.MeasureNumber}: {this.MeasureNumber += measureNumber}");
            this.MeasureNumber = measureNumber;
            this._Notes.ForEach(x => x.TimeContext
                .SetMeasureNumber(measureNumber));
            this._Chords.ForEach(x => x.TimeContext
                .SetMeasureNumber(measureNumber));
            this._Rests.ForEach(x => x.TimeContext
                .SetMeasureNumber(measureNumber));
            this._Forwards.ForEach(x => x.TimeContext
                .SetMeasureNumber(measureNumber));
            this._Backups.ForEach(x => x.TimeContext
                .SetMeasureNumber(measureNumber));
        }

        #endregion

        public void AddRange(List<TimedEvent<ChordFormula>> Chords)
        {
            this._Chords.AddRange(Chords);
        }
        public void AddRange(List<TimedEvent<Note>> Notes)
        {
            this._Notes.AddRange(Notes);
        }
        public void AddRange(List<TimedEvent<Rest>> Rests)
        {
            this._Rests.AddRange(Rests);
        }
        public void AddRange(List<TimedEvent<Forward>> Forwards)
        {
            this._Forwards.AddRange(Forwards);
        }
        public void AddRange(List<TimedEvent<Backup>> Backups)
        {
            this._Backups.AddRange(Backups);
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

            result.AddRange(this.Chords);
            result.AddRange(this.Notes);
            result.AddRange(this.Rests);
            result.AddRange(this.Forwards);
            result.AddRange(this.Backups);

            result = result.OrderBy(x => x.TimeContext.RelativeStart)
                .ThenBy(x => x.SortOrder)
                .ToList();

            return result;
        }

        public static List<ChordMelodyPairing> GetChordMelodyPairings(MusicXmlMeasure melody, MusicXmlMeasure harmony)
        {
            var result = new List<ChordMelodyPairing>();
            foreach (var chord in harmony.Chords)
            {
                var notes = melody.Notes.ToList().GetIntersecting(chord.TimeContext);
                var pairing = new ChordMelodyPairing(chord,
                    notes.ToList(),
                    chord.TimeContext);
                result.Add(pairing);
            }
            return result;
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
            return $"{nameof(MusicXmlMeasure)}: Part={this.Part.Identifier.ID}, MeasureNumber={this.MeasureNumber}, Chords={chords}, Notes={notes}, Rests={Rests.Count}, HasMetadata={this.HasMetadata}";
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Part = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }//class
}//ns
