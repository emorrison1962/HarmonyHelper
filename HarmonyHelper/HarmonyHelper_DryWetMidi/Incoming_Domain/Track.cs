using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Eric.Morrison.Harmony;
using System.Diagnostics;
using Melanchall.DryWetMidi.Tools;

namespace HarmonyHelper_DryWetMidi.Incoming_Domain
{
    /// <summary>
    /// https://melanchall.github.io/drywetmidi/api/Melanchall.DryWetMidi.Composing.PatternUtilities.html#Melanchall_DryWetMidi_Composing_PatternUtilities_TransformChords_Melanchall_DryWetMidi_Composing_Pattern_Melanchall_DryWetMidi_Composing_ChordSelection_Melanchall_DryWetMidi_Composing_ChordTransformation_System_Boolean_
    /// </summary>
    public class Track
    {
        public class Bar
        {
            ITimeSpan TimeSpan { get; set; }
            BarBeatFractionTimeSpan BarBeatFractionTimeSpan { get; set; }
            List<Chord> Chords { get; set; } = new List<Chord>();
            List<Note> Notes { get; set; } = new List<Note>();
            public Bar(ITimeSpan ts, BarBeatFractionTimeSpan tsBbf, List<Chord> chords, List<Note> notes)
            {
                this.TimeSpan = ts;
                this.BarBeatFractionTimeSpan = tsBbf;
                this.Chords = chords;
                this.Notes = notes;
            }

            public override string ToString()
            {
                return $"{this.GetType().Name}: {this.BarBeatFractionTimeSpan.ToString()}, Chords={this.Chords.Count}, Notes={this.Notes.Count}";
            }
        }

        #region Properties
        //public GeneralMidiPatchesEnum Patch { get; set; }
        public TrackChunk TrackChunk { get; set; }
        public BarBeatFractionTimeSpan FileDuration { get; set; }
        public Tempo Tempo { get; set; }
        public TempoMap TempoMap { get; set; }
        public FourBitNumber Channel { get; set; }
        public List<Note> Notes { get; set; }
        public List<Chord> Chords { get; set; }
        public ProgramChangeEvent Patch { get; set; }
        List<ChannelEvent> Events { get; set; }
        public int BarLength { get; private set; }
        public MidiFile MidiFile { get; set; }

        public List<Bar> Bars { get; set; } = new List<Bar>();

        #endregion

        #region Vonstruction
        public Track(TrackChunk chunk, TempoMap TempoMap,
            Tempo Tempo, BarBeatFractionTimeSpan FileDuration)
        {
            this.TrackChunk = chunk;
            this.TempoMap = TempoMap;
            this.Tempo = Tempo;
            this.FileDuration = FileDuration;

            this.Init();
        }

        public void Init()
        {
            using (var eventsMgr = this.TrackChunk.ManageTimedEvents())
            using (var chordsMgr = this.TrackChunk.ManageChords())
            using (var notesMgr = this.TrackChunk.ManageNotes())
            {
                this.Events = eventsMgr.Objects
                    .Where(x => x.Event is ChannelEvent)
                    .Select(x => x.Event)
                    .Cast<ChannelEvent>()
                    .ToList();


                var barLengthTicks = BarBeatUtilities.GetBarLength(0, this.TempoMap);
                for (int i = 0; i < FileDuration.Bars; ++i)
                {
                    #region Where in time are we?
                    var start = TimeConverter
                        .ConvertTo<MetricTimeSpan>(barLengthTicks * i,
                        this.TempoMap);
                    var end = new BarBeatFractionTimeSpan(1);
                    var tsBar = start.Add(end, TimeSpanMode.TimeLength);

                    #endregion
                    
                    var chords = chordsMgr.Objects
                        .AtTime(tsBar,
                            this.TempoMap,
                            LengthedObjectPart.Entire)
                        .Where(x => x.Notes.Count > 1)
                        .ToList();

                    var notes = notesMgr.Objects
                        .AtTime(tsBar,
                            this.TempoMap,
                            LengthedObjectPart.Entire)
                        .ToList();

                    var tsBbf = TimeConverter.ConvertTo<BarBeatFractionTimeSpan>(
                        tsBar, this.TempoMap);


                    this.Bars.Add(new Bar(tsBar, tsBbf, chords, notes));
                    new object();
                }
                new object();
            }
        }

        #endregion
        [Obsolete("Get rid of this.")]
        TempoMap GetTempoMap()
        { 
            return this.TempoMap;
        }
        public async void SetEvents(List<ChannelEvent> events)
        {
            this.Events = events;
            await this.ParseEventsAsync();
        }

        async Task ParseEventsAsync()
        {
            this.GetPatches();
            this.GetChords();
            this.GetNotes();
            this.GetBarLength();
            await Task.CompletedTask;
        }

        void GetPatches()
        {
            var pcs = this.Events
                .Where(x => x is ProgramChangeEvent)
                .Select(x => x)
                .Cast<ProgramChangeEvent>()
                .ToList();
            foreach (var pc in pcs)
            {
#warning Handle multple pcs.
                this.Patch = pc;
            }
            new object();
        }

        void GetChords()
        {
            var chords = new List<Chord>();
            this.Chords = this.Events.GetChords()
                    .Where(x => x.Notes.Count > 1)
                    .ToList();
        }
        void GetNotes()
        {
            this.Notes = this.Events.GetNotes().ToList();
        }

        void GetBarLength()
        {
            this.BarLength = BarBeatUtilities.GetBarLength(0, this.TempoMap);

            this.GetBar(0);
        }

        void GetBar(int ndx)
        {
            var barBeatTicksDuration = this.MidiFile.GetDuration<BarBeatTicksTimeSpan>();
            var bars = barBeatTicksDuration.Bars;

            var tempoMap = this.MidiFile.GetTempoMap();
            var barLinesMilliseconds = Enumerable
                .Range(0, (int)bars + 1)
                .Select(bar => TimeConverter
                    .ConvertTo<MetricTimeSpan>(new BarBeatTicksTimeSpan(bar), tempoMap)
                    .TotalMicroseconds)
                .ToList();


            var midiSpans = Enumerable
                .Range(0, (int)bars + 1)
                .Select(bar => TimeConverter
                    .ConvertTo<MidiTimeSpan>(new BarBeatTicksTimeSpan(bar), tempoMap))
                .ToList();


            var pairs = midiSpans.GetPairs();
            var tsBars = new List<ITimeSpan>();
            foreach (var pair in pairs)
            {
                var bar = TimeConverter.ConvertTo<BarBeatTicksTimeSpan>((ITimeSpan)pair.First, tempoMap);

                //this.Notes.ForEach(x => Debug.WriteLine($"{x}: {x.Time}-{x.EndTime}"));

                var result = this.Notes
                    .Where(x => x.Time >= pair.First
                            && x.Time <= pair.Second)
                    .ToList();

                Debug.WriteLine($"{this.Channel}:{bar}: result.Count={result.Count}");

                //ITimeSpan tsBar = end.Subtract(start, TimeSpanMode.TimeLength);
                //tsBars.Add(tsBar);
                new object();
            }

            //foreach (var tsBar in tsBars)
            //{
            //    var result = this.Notes
            //        .Where(x => x.Time >= tsBar);
            //        .StartAtTime(tsBar.)
            //        .AtTime(tsBar, this.TempoMap, LengthedObjectPart.Entire)
            //        .ToList();
            //}

            //var barLinesBars = Enumerable
            //    .Range(0, (int)bars + 1)
            //    .Select(bar => TimeConverter
            //        .ConvertTo<BarBeatTicksTimeSpan>(new BarBeatTicksTimeSpan(1), tempoMap))
            //    .ToArray();
            new object();

#if false
            //while (true)
            {
                var tsStart = new BarBeatTicksTimeSpan(10, 1);
                var tsEnd = new BarBeatTicksTimeSpan(11, 1);
                ITimeSpan tsResult = tsEnd.Subtract(tsStart, TimeSpanMode.TimeLength);

                tsResult.Co

                //var ts = new BarBeatFractionTimeSpan(20);
                var result = this.Notes.Where(x =>
                    x.GetTimedNoteOnEvent().Time >= tsStart.Ticks
                    && x.GetTimedNoteOnEvent().Time <= tsEnd.Ticks)
                    .ToList();
                    //.AtTime(tsResult, this.TempoMap, LengthedObjectPart.Entire)
                    //.StartAtTime(tsStart.Ticks)
                    //.EndAtTime(tsEnd.Ticks)
                    //.ToList();
                new object();

                /*
                IEnumerable<Note> notes = midiFile
    .GetNotes().AtTime(new BarBeatTicksTimeSpan(10, 4), tempoMap);
                */
            }
#endif
        }
    }//class
}//ns
