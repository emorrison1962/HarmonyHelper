using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace HarmonyHelper_DryWetMidi.Incoming_Domain
{
    public class Track
    {
        //public GeneralMidiPatchesEnum Patch { get; set; }
        public Tempo Tempo { get; set; }
        public FourBitNumber Channel { get; set; }
        public List<Note> Notes { get; set; }
        public List<Chord> Chords { get; set; }
        public ProgramChangeEvent Patch { get; set; }
        List<ChannelEvent> Events { get; set; }

        public Track(FourBitNumber channel)
        {
            this.Channel = channel;
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
            await Task.CompletedTask;
        }

        void GetBarLines()
        { 
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

        void GetNotes()
        {
            this.Notes = this.Events.GetNotes().ToList();
        }
        void GetChords()
        {
            var chords = new List<Chord>();
            this.Chords = this.Events.GetChords()
                    .Where(x => x.Notes.Count > 1)
                    .ToList();
        }

    }//class
}//ns
