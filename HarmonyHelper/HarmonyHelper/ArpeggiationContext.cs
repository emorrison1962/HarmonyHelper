using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
    public class ArpeggiationContext
    {
        public event EventHandler<ArpeggiationContext> ArpeggiationContextChanged;
        public event EventHandler<ArpeggiationContext> ChordChanged;
        public event EventHandler<ArpeggiationContext> DirectionChanged;
        public event EventHandler<ArpeggiationContext> CurrentNoteChanged;
        public event EventHandler<ArpeggiationContext> Starting;
        public event EventHandler<ArpeggiationContext> Ending;
        public int MaxNotesPerChord { get; set; }
        Note _currentNote;
        public Note CurrentNote
        {
            get { return _currentNote; }
            set
            {
                this._currentNote = value;
                OnCurrentNoteChanged();
            }
        }

        DirectionEnum _direction;
        public DirectionEnum Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                this.OnDirectionChanged();
            }
        }
        public NoteRange NoteRange { get; set; }
        Chord _chord;
        public Chord Chord
        {
            get { return _chord; }
            set
            {
                _chord = value;
                this.OnChordChanged();
            }
        }
        List<Chord> Chords { get; set; } = new List<Chord>();

        public ArpeggiationContext(IEnumerable<Chord> chords, DirectionEnum direction,
            NoteRange noteRange, int maxNotes, Note nextNote = null)
        {
            this.Direction = direction;

            this.Chords = new List<Chord>(chords);
            this.Chord = this.Chords[0];
            if (null == nextNote)
                nextNote = this.Chord.Root;
            this.CurrentNote = nextNote;
            this.NoteRange = noteRange;
            this.MaxNotesPerChord = maxNotes;
        }

        public void Arpeggiate()
        {
            this.OnStarting();

            bool firstTime = true;
            foreach (var chord in this.Chords)
            {
                this.Chord = chord;
                if (firstTime)
                {
                    OnDirectionChanged();
                }
                for (int i = 0; i < this.MaxNotesPerChord; ++i)
                {
                    if (firstTime)
                    {
                        OnCurrentNoteChanged();
                        firstTime = false;
                    }
                    else
                    {
                        var next = this.Chord.GetClosestNoteEx(this);
                        Debug.Assert(null != next);
                        this.CurrentNote = next;
                    }
                }
            }

            this.OnEnding();
        }


        void OnArpeggiationContextChanged()
        {
            ArpeggiationContextChanged?.Invoke(this, this);
        }
        void OnChordChanged()
        {
            ChordChanged?.Invoke(this, this);
        }
        void OnDirectionChanged()
        {
            DirectionChanged?.Invoke(this, this);
        }
        void OnCurrentNoteChanged()
        {
            CurrentNoteChanged?.Invoke(this, this);
        }

        void OnStarting()
        {
            Starting?.Invoke(this, this);
        }
        void OnEnding()
        {
            Ending?.Invoke(this, this);
        }


    }//class

}//ns
