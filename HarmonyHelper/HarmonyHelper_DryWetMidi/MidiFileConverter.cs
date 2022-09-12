using HarmonyHelper_DryWetMidi.Incoming_Domain;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
//using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper_DryWetMidi
{
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
            for (int i = 0; i < Constants.MIDI_CHANNEL_MAX; i++)
            { 
                this.Tracks.Add(
                    new Track((FourBitNumber)i));
            }
        }
    }
    public class MidiFileConverter
    {
        MidiFileConverterContext Context { get; set; } = new MidiFileConverterContext();

        public void Open(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename);

            this.Context.Filename = filename;
            var midiFile = MidiFile.Read(this.Context.Filename);

            this.ReadChunks(midiFile);

            new object();
            new object();
        }

        void ReadChunks(MidiFile midiFile)
        {
            foreach (var trackChunk in midiFile.GetTrackChunks())
            {
                this.Context.TrackChunks.Add(trackChunk);
                this.InitializeTracks(midiFile);
            }
            new object();
        }

        void InitializeTracks(MidiFile midiFile)
        {
            var fileDuration = midiFile.GetDuration(TimeSpanType.BarBeatFraction);
            this.GetTempo(midiFile, out var tempoMap, out var tempo);

            Debug.Assert(1 == midiFile.GetTrackChunks().Count());
            foreach (var trackChunk in midiFile.GetTrackChunks())
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
                        this.Context.Tracks[i].FileDuration = fileDuration;
                        this.Context.Tracks[i].TempoMap = tempoMap;
                        this.Context.Tracks[i].Tempo = tempo;
                        this.Context.Tracks[i].SetEvents(
                            events.Where(x => x.Channel == i)
                                .ToList());
                    }
                    new object();
                }
            }
        }

        void GetTempo(MidiFile midiFile, out TempoMap tempoMap, out Tempo tempo)
        {
            tempoMap = null;
            tempo = null;
            using (var tempoMapManager = midiFile.ManageTempoMap())
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
    }//class
}//ns
