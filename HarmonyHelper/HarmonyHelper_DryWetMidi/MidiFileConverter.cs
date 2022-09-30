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
        #region Properties
        public string Filename { get; private set; }
        public MidiFile MidiFile { get; private set; }
        public TrackChunk TrackChunk { get; private set; }
        public BarBeatFractionTimeSpan FileDuration { get; private set; }
        public TempoMap TempoMap { get; private set; }
        public Tempo Tempo { get; private set; }

        #endregion

        public MidiFileConverter(string filename)
        {
            this.Filename = filename;
            this.Open();
        }
        public void Open()
        {
            if (!File.Exists(this.Filename))
                throw new FileNotFoundException(this.Filename);

            this.MidiFile = MidiFile.Read(this.Filename);
            this.Init();
        }

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

        MidiFileConverter CreateTracks()
        {
            var exploded = TrackChunk.Explode();
            foreach (var chunk in exploded)
            {
                new Track(chunk,
                    this.TempoMap,
                    this.Tempo,
                    this.FileDuration);
            }
            return this;
        }

    }//class
}//ns
