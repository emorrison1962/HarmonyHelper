using HarmonyHelper_DryWetMidi.Incoming_Domain;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Core = Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
//using Melanchall.DryWetMidi.Multimedia;
//using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace HarmonyHelper_DryWetMidi
{
    [Obsolete("", true)]
    class MidiFileConverterContext
    {
        public string Filename { get; set; }
        public List<TrackChunk> TrackChunks { get; set; } = new List<TrackChunk>();
        public List<Track> Tracks { get; set; } = new List<Track>();

        public MidiFileConverterContext()
        {
            this.Init();
        }

        void Init()
        {
            //for (int i = 0; i < Constants.MIDI_CHANNEL_MAX; i++)
            //{ 
            //    this.Tracks.Add(
            //        new Track((FourBitNumber)i));
            //}
        }
    }
    public class MidiFileConverter
    {
        //MidiFileConverterContext Context { get; set; } = new MidiFileConverterContext();
        public string Filename { get; private set; }
        public MidiFile MidiFile { get; private set; }
        public TrackChunk TrackChunk { get; private set; }
        public BarBeatFractionTimeSpan FileDuration { get; private set; }
        public TempoMap TempoMap { get; private set; }
        public Tempo Tempo { get; private set; }

        public void Open(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename);

            this.Filename = filename;
            this.MidiFile = MidiFile.Read(this.Filename);

            this.Init();

            new object();
        }

#if false
        void InitializeTracks()
        {
            var fileDuration = MidiFile.GetDuration(TimeSpanType.BarBeatFraction);
            this.GetTempo(out var tempoMap, out var tempo);

            Debug.Assert(1 == MidiFile.GetTrackChunks().Count());
            foreach (var trackChunk in MidiFile.GetTrackChunks())
            {
#warning FIXME: handle multiple trackChunks!!
                using (var eventManager = trackChunk.ManageTimedEvents())
                {
                    var events = eventManager.Objects
                        .Where(x => x.Event is ChannelEvent)
                        .Select(x => x.Event)
                        .Cast<ChannelEvent>()
                        .ToList();

                    for (int i = 0; i < Constants.MIDI_CHANNEL_MAX; ++i)
                    {
                        if (0 < events.Where(x => x.Channel == i).Count())
                        {
                            var track = new Track((FourBitNumber)i);
                            track.MidiFile = MidiFile;
                            track.FileDuration = fileDuration;
                            track.TempoMap = tempoMap;
                            track.Tempo = tempo;
                            track.SetEvents(
                                events.Where(x => x.Channel == i)
                                    .ToList());
                            this.Context.Tracks.Add(track);
                        }
                    }
                    new object();
                }
            }
        }
#endif
        void Init()
        {
            this.MergeTrackChunks()
                .GetDurationAndTempo()
                .CreateTracks();

        }

        MidiFileConverter MergeTrackChunks()
        {
            Debug.Assert(1 == this.MidiFile.GetTrackChunks().Count());
            var chunks = this.MidiFile.GetTrackChunks();
            var result = Core.TrackChunkUtilities.Merge(chunks);

            this.TrackChunk = result;
            return this;
        }

        MidiFileConverter GetDurationAndTempo()
        {
            this.FileDuration = MidiFile.GetDuration(TimeSpanType.BarBeatFraction) as BarBeatFractionTimeSpan;
            this.GetTempo(out var tempoMap, out var tempo);
            this.TempoMap = tempoMap;
            this.Tempo = tempo;
            return this;
        }

        void GetTempo(out TempoMap tempoMap, out Tempo tempo)
        {
            tempoMap = null;
            tempo = null;
            using (var tempoMapManager = MidiFile.ManageTempoMap())
            {
                tempoMap = tempoMapManager.TempoMap;
                var tempos = tempoMap.GetTempoChanges().ToList();
                foreach (var t in tempos)
                {
#warning FIXME: Need to handle multiple tempos.
                    tempo = t.Value;
                    new object();
                }
            }
        }

        void CreateTracks()
        {
            var exploded = TrackChunk.Explode();
            foreach (var chunk in exploded)
            {
                new Track(chunk,
                    this.TempoMap,
                    this.Tempo,
                    this.FileDuration);
            }
        }

    }//class
}//ns
