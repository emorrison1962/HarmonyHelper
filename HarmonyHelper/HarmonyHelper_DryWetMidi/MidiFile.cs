using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
//using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper_DryWetMidi
{
    class MidiFileContext
    {
        public string Filename { get; set; }
        public Tempo Tempo { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();

        public MidiFileContext()
        {
            this.Init();
        }

        void Init()
        {
            for (int i = 0; i < Constants.MIDI_CHANNEL_MAX; i++)
            { 
                this.Tracks.Add(
                    new Track { Channel = (FourBitNumber)i });
            }
        }
    }
    public class Track
    {
        //public GeneralMidiPatchesEnum Patch { get; set; }
        public FourBitNumber Channel { get; set; }
        public List<Note> Notes { get; set; }
        public List<Chord> Chords { get; set; }
        public ProgramChangeEvent Patch { get; set; }
    }
    public class MidiFileConverter
    {
        MidiFileContext Context { get; set; } = new MidiFileContext();
        List<TrackChunk> Tracks { get; set; } = new List<TrackChunk>();
        public void Open()
        {
            this.Context.Filename = @"C:\Downloads\97097.mid";
            var midiFile = MidiFile.Read(this.Context.Filename);

            this.Context.Tempo = this.GetTempo(midiFile);
            this.ReadTracks(midiFile);

            new object();
            new object();
        }

        void ReadTracks(MidiFile midiFile)
        {
            foreach (var trackChunk in midiFile.GetTrackChunks())
            {
                this.Tracks.Add(trackChunk);
                this.SplitByMidiChannel(trackChunk);
                this.GetPatches(trackChunk);
                this.GetChords(trackChunk);

                using (var notesManager = trackChunk.ManageNotes())
                {
                    var notes = notesManager.Objects.ToList();
                    var ch1 = notes.Where(x => x.Channel == 0);

                    Debug.WriteLine(notes[0].Channel);
                    //notesManager.Objects.RemoveAll(n => n.NoteName == NoteName.CSharp);
                    new object();
                }
            }
            new object();
        }

        void GetPatches(TrackChunk trackChunk)
        {
            using (var eventsManager = trackChunk.ManageTimedEvents())
            {
                var events = eventsManager.Objects.ToList();

                var pcs = eventsManager.Objects
                    .Where(x => x.Event is ProgramChangeEvent)
                    .Cast<ProgramChangeEvent>()
                    .ToList();
                foreach (var pc in pcs)
                {
                    this.Context.Tracks[pc.Channel].Patch = pc;
                }
                new object();
            }

        }
        void SplitByMidiChannel(TrackChunk trackChunk)
        {
            using (var notesManager = trackChunk.ManageNotes())
            {
                var notes = notesManager.Objects.ToList();
                var ch0 = notes.Where(x => x.Channel == 0).ToList();
                var ch1 = notes.Where(x => x.Channel == 1).ToList();
                var ch2 = notes.Where(x => x.Channel == 2).ToList();
                var ch3 = notes.Where(x => x.Channel == 3).ToList();
                var ch4 = notes.Where(x => x.Channel == 4).ToList();
                var ch5 = notes.Where(x => x.Channel == 5).ToList();
                var ch6 = notes.Where(x => x.Channel == 6).ToList();
                var ch7 = notes.Where(x => x.Channel == 7).ToList();
                var ch8 = notes.Where(x => x.Channel == 8).ToList();
                var ch9 = notes.Where(x => x.Channel == 9).ToList();
                var chA = notes.Where(x => x.Channel == 10).ToList();
                var chB = notes.Where(x => x.Channel == 11).ToList();
                var chC = notes.Where(x => x.Channel == 12).ToList();
                var chD = notes.Where(x => x.Channel == 13).ToList();
                var chE = notes.Where(x => x.Channel == 14).ToList();
                var chF = notes.Where(x => x.Channel == 15).ToList();

                Debug.WriteLine(notes[0].Channel);
                //notesManager.Objects.RemoveAll(n => n.NoteName == NoteName.CSharp);
                new object();
            }
        }

        void GetChords(TrackChunk trackChunk)
        {
            var chords = new List<Chord>();
            using (var chordsManager = trackChunk.ManageChords())
            {
                chords = chordsManager.Objects
                    .Where(x => x.Notes.Count > 1)
                    .ToList();
                new object();
            }

            for (int i = 0; i < Constants.MIDI_CHANNEL_MAX; ++i)
            {
                var channelChords = chords.Where(x => x.Channel == i).ToList();
                new object();
            }
            new object();

        }

        Tempo GetTempo(MidiFile midiFile)
        {
            Tempo result = null;
            using (var tempoMapManager = midiFile.ManageTempoMap())
            {
                var tempoMap = tempoMapManager.TempoMap;
                var tempos = tempoMap.GetTempoChanges().ToList();
                foreach (var tempo in tempos)
                {
#warning FIXME: Need to handle multiple tempos.
                    result = tempo.Value;
                    new object();
                }
            }
            return result;
        }
    }//class
}//ns
