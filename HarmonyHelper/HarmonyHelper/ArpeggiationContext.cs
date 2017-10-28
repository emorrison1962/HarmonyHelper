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

        public ArpeggiationContext(Chord chord, DirectionEnum direction,
            Note nextNote, NoteRange noteRange, int maxNotes)
        {
            this.Direction = direction;
            this.Chord = chord;
            this.CurrentNote = nextNote;
            this.NoteRange = noteRange;
            this.MaxNotesPerChord = maxNotes;
        }

        public void Arpeggiate(List<Chord> chords)
        {
            this.OnStarting();

            bool firstTime = true;
            foreach (var chord in chords)
            {
                this.Chord = chord;
                if (firstTime)
                {
                    OnDirectionChanged();
                    //OnCurrentNoteChanged();
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
