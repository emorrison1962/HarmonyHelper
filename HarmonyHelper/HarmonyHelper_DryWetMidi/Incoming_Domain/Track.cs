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
        public bool IsDrumTrack 
        {
            get 
            {
                var result = false;
                if (this.Channel == 9)
                    result = true;
                return result;
            }
        }
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
                    #region Determine which bar we're processing.
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

                    var tsBbf = TimeConverter
                        .ConvertTo<BarBeatFractionTimeSpan>(
                            tsBar, this.TempoMap);


                    this.Bars.Add(new Bar(tsBar, tsBbf, chords, notes));
                    new object();
                }
                new object();
            }
        }

        #endregion
    }//class
}//ns
