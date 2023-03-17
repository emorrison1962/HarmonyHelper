using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Chords
{
    public class ClosestNoteContext
    {
        public class DirectionChangedEventArgs : EventArgs
        {
            public DirectionEnum Current { get; set; }
            public DirectionChangedEventArgs(DirectionEnum current)
            {
                this.Current = current;
            }
        }
        public event EventHandler<DirectionChangedEventArgs> DirectionChanged;

        #region Properties
        public DirectionEnum _Direction;

        public DirectionEnum Direction
        {
            get { return _Direction; }
            private set
            {
                _Direction = value;
                this.OnDirectionChanged();
            }
        }

        private void OnDirectionChanged()
        {
            if (null != this.DirectionChanged)
                this.DirectionChanged(this, new DirectionChangedEventArgs(this.Direction));
        }

        public Chord Chord { get; set; }
        public Note LastNote { get; set; }
        public Note ClosestNote { get; set; }
        public List<Note> Notes { get; set; }
        public bool TemporaryDirectionReversal { get; set; }
        public bool ExceededRangeLimit { get; set; }

        #endregion

        #region Construction
        public ClosestNoteContext(Note lastNote, Chord chord, DirectionEnum direction)
        {
            this.LastNote = lastNote;
            this.Direction = direction;
            this.Chord = chord; 
            this.Notes = chord.Notes;
        }

        public ClosestNoteContext(Arpeggiator arpeggiator)
             : this(arpeggiator.CurrentNote, arpeggiator.CurrentChord, arpeggiator.Direction)
        { }

        #endregion

        public void SetChord(Chord chord)
        {
            this.Chord = chord;
            this.Notes = chord.Notes;
        }

        public void GetClosestNote()
        {
            var result = this.FindClosest();
            if (result is null)
            {
                this.ReverseDirection();
                result = this.FindClosest();
                Debug.Assert(result is not null);
            }

            Debug.Assert(this.LastNote.NoteName.RawValue != result.NoteName.RawValue);
            this.ClosestNote = result;
        }

        public Note? FindClosest()
        {
            Note? result = null;

            if (this.Direction.HasFlag(DirectionEnum.Ascending))
            {
                result = this.FindClosest_Impl();
                new object();
            }
            else // (this.Direction.HasFlag(DirectionEnum.Descending))
            {
                result = this.FindClosest_Impl();
                new object();
            }
            if (result is null)
            {
                this.ExceededRangeLimit = true;
                new object();
            }

            if (this.Direction.HasFlag(DirectionEnum.AllowTemporayReversalForCloserNote))
            {
                Note? option = null;

                this.ReverseDirection(false);
                option = this.FindClosest_Impl();
                this.ReverseDirection(false);

                new object();

                if (result is not null && option is not null)
                {
                    new object();
                    var optionalInterval = option - this.LastNote;
                    optionalInterval = (Interval)Math.Min(
                        (uint)optionalInterval, 
                        (uint)optionalInterval.GetInversion());

                    if (optionalInterval.FunctionalValue > IntervalFunctionalValuesEnum.Augmented4th)
                        optionalInterval = optionalInterval.GetInversion();

                    var currentInterval = result - this.LastNote;
                    currentInterval = (Interval)Math.Min(
                        (uint)currentInterval, 
                        (uint)currentInterval.GetInversion());

                    if (optionalInterval.SemiTones == 1)
                    {
                        result = option;
                        this.TemporaryDirectionReversal = true;
                        //this.ReverseDirection();
                    }
                }
                //Debug.Assert(null != result);
            }

            // Debug.Assert(null != result);
            return result;
        }

        public Note? FindClosest_Impl()
        {
            Note? result = null;
            if (this.Direction.HasFlag(DirectionEnum.Ascending))
            {
                result = this.Notes
                    .Where(x => x.RawValue > this.LastNote.RawValue && x.Octave >= this.LastNote.Octave)
                    .FirstOrDefault();
                if (result is null)
                {
                    var minValue = this.Notes.Min(x => x.RawValue);
                    var lastOctave = this.LastNote.Octave;
                    result = this.Notes.Where(x => x.RawValue == minValue && x.Octave > lastOctave)
                        .FirstOrDefault();
                }
            }
            else
            {
                result = this.Notes
                    .Where(x => x.RawValue < this.LastNote.RawValue && x.Octave <= this.LastNote.Octave)
                    .LastOrDefault();
                new object();
                if (result is null)
                {
                    var maxValue = this.Notes.Max(x => x.RawValue);
                    var lastOctave = this.LastNote.Octave;
                    result = this.Notes
                        .Where(x => x.RawValue == maxValue && x.Octave < lastOctave)
                        .LastOrDefault();
                    new object();
                }
            }
            if (result is null)
                new object();
            return result;
        }

        public override string ToString()
        {
            var result = $"Direction={this.Direction}, LastNote={this.LastNote}, ClosestNote={this.ClosestNote}";
            if (this.TemporaryDirectionReversal)
                result = $"Direction={this.Direction}, TemporaryDirectionReversal={TemporaryDirectionReversal} LastNote={this.LastNote}, ClosestNote={this.ClosestNote}";
            return result;
        }

        public void ReverseDirection(bool fireEvent = true)
        {
            var result = DirectionEnum.None;
            var allowReversal = false;
            if (this.Direction.HasFlag(DirectionEnum.AllowTemporayReversalForCloserNote))
            {
                allowReversal = true;
            }
            if (this.Direction.HasFlag(DirectionEnum.Descending))
            {
                result = DirectionEnum.Ascending;
            }
            if (this.Direction.HasFlag(DirectionEnum.Ascending))
            {
                result = DirectionEnum.Descending;
            }
            if (allowReversal)
            {
                result |= DirectionEnum.AllowTemporayReversalForCloserNote;
            }
            if (fireEvent)
                this.Direction = result;
            else
                this._Direction = result;
        }
    }//class
}//ns
