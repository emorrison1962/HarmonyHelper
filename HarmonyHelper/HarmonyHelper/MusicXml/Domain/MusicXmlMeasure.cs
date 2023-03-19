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
using System.Xml.Linq;


namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlMeasure : ClassBase, IDisposable, IHasIsValid
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
        bool HasMetadata { get; set; }
        List<MusicXmlBarlineContext> _BarlineContexts { get; set; } = new List<MusicXmlBarlineContext>();
        public IEnumerable<MusicXmlBarlineContext> BarlineContexts { get { return _BarlineContexts; } }

        List<TimedEventChordFormula> _Chords { get; set; } = new List<TimedEventChordFormula>();
        List<TimedEventNote> _Notes { get; set; } = new List<TimedEventNote>();
        List<TimedEventRest> _Rests { get; set; } = new List<TimedEventRest>();
        List<TimedEventForward> _Forwards { get; set; } = new List<TimedEventForward>();
        List<TimedEventBackup> _Backups { get; set; } = new List<TimedEventBackup>();

        public ReadOnlyCollection<TimedEventChordFormula> Chords
        { get { return this._Chords.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEventNote> Notes
        { get { return this._Notes.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEventRest> Rests
        { get { return this._Rests.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEventForward> Forwards
        { get { return this._Forwards.AsReadOnly(); } }
        public ReadOnlyCollection<TimedEventBackup> Backups
        { get { return this._Backups.AsReadOnly(); } }

        public bool HasForwards { get { return this.Forwards.Count > 0; } }
        public bool HasBackups { get { return this.Backups.Count > 0; } }

        public bool IsSectionEnd { get; set; }
        public bool IsSectionStart { get; set; }

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
            List<TimedEventChordFormula> Chords,
            List<TimedEventNote> Notes,
            List<TimedEventRest> Rests,
            List<TimedEventForward> Forwards,
            List<TimedEventBackup> Backups)
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
            this._Notes = src.Notes.Select(x => new TimedEventNote(x)).ToList();
            this._Chords = src.Chords.Select(x => new TimedEventChordFormula(x)).ToList();
            this._Rests = src.Rests.Select(x => new TimedEventRest(x)).ToList();
            this._Forwards = src.Forwards.Select(x => new TimedEventForward(x)).ToList();
            this._Backups = src.Backups.Select(x => new TimedEventBackup(x)).ToList();

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

        public void Add(TimedEventChordFormula Chord)
        {
            this._Chords.Add(Chord);
        }
        public void AddRange(List<TimedEventChordFormula> Chords)
        {
            this._Chords.AddRange(Chords);
        }
        public void Add(TimedEventNote Note)
        {
            this._Notes.Add(Note);
        }
        public void AddRange(List<TimedEventNote> Notes)
        {
            this._Notes.AddRange(Notes);
        }
        public void AddRange(List<TimedEventRest> Rests)
        {
            this._Rests.AddRange(Rests);
        }
        public void AddRange(List<TimedEventForward> Forwards)
        {
            this._Forwards.AddRange(Forwards);
        }
        public void AddRange(List<TimedEventBackup> Backups)
        {
            this._Backups.AddRange(Backups);
        }

        public void Add(MusicXmlBarlineContext barline)
        {
            this._BarlineContexts.Add(barline);
            if (barline.IsDoubleBarline)
            {
                if (barline.BarlineSide == BarlineSideEnum.Left)
                {
                    this.IsSectionStart = true;
                }
                if (barline.BarlineSide == BarlineSideEnum.Right)
                {
                    this.IsSectionEnd = true;
                }
            }
        }

        public class Envelope
        {
            public IHasTimeContext Event { get; set; }
            public Envelope(IHasTimeContext Event)
            {
                this.Event = Event;
            }
        }

        public List<TimedEventBase> TimedEvents
        {
            get
            {
                var result = new List<TimedEventBase>();

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
        }

        public List<TimedEventBase> GetMergedEvents()
        {
            var result = new List<TimedEventBase>();

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

        public static List<ChordMelodyPairing> GetChordMelodyPairings(MelodyHarmonyPair<MusicXmlMeasure> mhPair)
        {
            var result = new List<ChordMelodyPairing>();
            foreach (var chord in mhPair.Harmony.Chords)
            {
                var notes = mhPair.Melody.Notes.ToList().GetIntersecting(chord.TimeContext);
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
            //return $"{nameof(MusicXmlMeasure)}: Part={this.Part.Identifier.ID}, MeasureNumber={this.MeasureNumber}, Chords={chords}, Notes={notes}, Rests={Rests.Count}, HasMetadata={this.HasMetadata}";

            var append = string.Empty;
            if (this.IsSectionStart)
                append = $", IsSectionStart ={this.IsSectionStart}";
            if (this.IsSectionEnd)
                append = $", IsSectionEnd ={this.IsSectionEnd}";

            return $"{nameof(MusicXmlMeasure)}: Part={this.Part.Identifier.ID}, MeasureNumber={this.MeasureNumber}{append}";

        }

        public bool IsValid()
        {
            var result = true;

            if (_MeasureNumber == 0)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && !_Chords.All(x => x.IsValid()))
            {
                result = false;
            }

            if (result && !_Notes.All(x => x.IsValid()))
            {
                result = false;
            }

            if (result && !_Rests.All(x => x.IsValid()))
            {
                result = false;
            }

            if (result && !_Forwards.All(x => x.IsValid()))
            {
                result = false;
            }

            if (result && !_Backups.All(x => x.IsValid()))
            {
                result = false;
            }

            return result;
        }

        public XElement ToXElement()
        {
            var result = new XElement(XmlConstants.measure);
            result.Add(new XAttribute(XmlConstants.number, this.MeasureNumber));

            if (this.BarlineContexts.Any(x => x.BarlineSide == BarlineSideEnum.Left))
            {
                var ctxs = this.BarlineContexts.Where(x => x.BarlineSide == BarlineSideEnum.Left);
                foreach (var ctx in ctxs)
                {
                    XElement xbarline = ctx.ToXElement();
                    if (null != ctx.RepeatContext)
                    {
                        xbarline.Add(ctx.RepeatContext.ToXElement());
                        if (ctx.RepeatContext.RepeatCount > 1)
                        {
                            throw new NotImplementedException();
                        }
                    }
                    result.Add(xbarline);
                }
            }

            var events = this.GetMergedEvents();
            foreach (var @event in events)
            {
                //var ob = (dynamic)@event;
                var xevent = @event.ToXElement();
                result.Add(xevent);
            }

            if (this.BarlineContexts.Any(x => x.BarlineSide == BarlineSideEnum.Right))
            {
                var ctxs = this.BarlineContexts.Where(x => x.BarlineSide == BarlineSideEnum.Left);
                foreach (var ctx in ctxs)
                {
                    XElement xbarline = ctx.ToXElement();
                    if (null != ctx.RepeatContext)
                    {
                        xbarline.Add(ctx.RepeatContext.ToXElement());
                        if (ctx.RepeatContext.RepeatCount > 1)
                        {
                            throw new NotImplementedException();
                        }
                    }
                    result.Add(xbarline);
                }
            }

            return result;
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
