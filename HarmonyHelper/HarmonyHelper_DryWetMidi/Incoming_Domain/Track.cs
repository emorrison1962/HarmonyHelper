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
    /// <summary>
    /// https://melanchall.github.io/drywetmidi/api/Melanchall.DryWetMidi.Composing.PatternUtilities.html#Melanchall_DryWetMidi_Composing_PatternUtilities_TransformChords_Melanchall_DryWetMidi_Composing_Pattern_Melanchall_DryWetMidi_Composing_ChordSelection_Melanchall_DryWetMidi_Composing_ChordTransformation_System_Boolean_
    /// </summary>
    public class Track
    {
        //public GeneralMidiPatchesEnum Patch { get; set; }
        public ITimeSpan FileDuration { get; set; }
        public Tempo Tempo { get; set; }
        public TempoMap TempoMap { get; set; }
        public FourBitNumber Channel { get; set; }
        public List<Note> Notes { get; set; }
        public List<Chord> Chords { get; set; }
        public ProgramChangeEvent Patch { get; set; }
        List<ChannelEvent> Events { get; set; }
        public int BarLength { get; private set; }

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
            //while (true)
            {
                var ts = new BarBeatFractionTimeSpan(20);
                var result = this.Chords
                    .AtTime(ts, this.TempoMap, LengthedObjectPart.Entire)
                    .ToList();
                new object();
            }

        }
    }//class
}//ns
