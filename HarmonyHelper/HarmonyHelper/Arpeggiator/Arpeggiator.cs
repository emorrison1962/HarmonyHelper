using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public partial class Arpeggiator
	{
		#region EventArgs<T>
		public class DirectionChangingEventArgs : EventArgs
		{
			public DirectionEnum Current { get; set; }
			public DirectionEnum Next { get; set; }
			public Arpeggiator Arpeggiator { get; set; }
			public DirectionChangingEventArgs(Arpeggiator arp, DirectionEnum current, DirectionEnum next)
			{
				this.Arpeggiator = arp;
				this.Current = current;
				this.Next = next;
			}
		}
		public class ChordChangingEventArgs : EventArgs
		{
			public Chord Current { get; set; }
			public Chord Next { get; set; }
			public Arpeggiator Arpeggiator { get; set; }
			public ChordChangingEventArgs(Arpeggiator arp, Chord current, Chord next)
			{
				this.Arpeggiator = arp;
				this.Current = current;
				this.Next = next;
			}
		}
		public class NoteChangingEventArgs : EventArgs
		{
			public Note Current { get; set; }
			public Note Next { get; set; }
			public Arpeggiator Arpeggiator { get; set; }
			public NoteChangingEventArgs(Arpeggiator arp, Note current, Note next)
			{
				this.Arpeggiator = arp;
				this.Current = current;
				this.Next = next;
			}
		}
		public class ArpeggiationContextChangingEventArgs : EventArgs
		{
			public ArpeggiationChordContext Current { get; set; }
			public ArpeggiationChordContext Next { get; set; }
			public Arpeggiator Arpeggiator { get; set; }
			public ArpeggiationContextChangingEventArgs(Arpeggiator arp, ArpeggiationChordContext current, ArpeggiationChordContext next)
			{
				this.Arpeggiator = arp;
				this.Current = current;
				this.Next = next;
			}
		}

		#endregion

		#region Events
		public event EventHandler<Arpeggiator> Starting;
		public event EventHandler<Arpeggiator> Started;

        public event EventHandler<Arpeggiator> MeasureChanging;
		public event EventHandler<Arpeggiator> MeasureChanged;

        public event EventHandler<ArpeggiationContextChangingEventArgs> ArpeggiationContextChanging;
        public event EventHandler<Arpeggiator> ArpeggiationContextChanged;

        public event EventHandler<ChordChangingEventArgs> ChordChanging;
		public event EventHandler<Arpeggiator> ChordChanged;

		public event EventHandler<DirectionChangingEventArgs> DirectionChanging;
		public event EventHandler<Arpeggiator> DirectionChanged;

		public event EventHandler<NoteChangingEventArgs> NoteChanging;
		public event EventHandler<Arpeggiator> NoteChanged;

		public event EventHandler<Arpeggiator> Ending;
		public event EventHandler<Arpeggiator> Ended;

		#endregion

		#region Fields
		Note _CurrentNote;
		DirectionEnum _Direction;
		Chord _CurrentChord;
		ArpeggiationChordContext _CurrentContext;
        int _CurrentBeat;
        int _CurrentMeasure;

        #endregion

        #region Properties
        public bool IsStarted { get; set; }
		public bool IsCompleted { get { return !this.IsStarted; } set { this.IsStarted = !value; } }	

		public int BeatsPerMeasure { get; set; }
		public List<Note> NoteHistory { get; private set; } = new List<Note>();
		public Note CurrentNote
		{
			get 
			{
				if (null == _CurrentNote)
					_CurrentNote = this.CurrentChord.Root;
				return _CurrentNote; 
			}
			set
			{
				OnNoteChanging(this._CurrentNote, value);
				this._CurrentNote = value;
				this.NoteHistory.Add(value);
				OnNoteChanged();
			}
		}

		public DirectionEnum Direction
		{
			get { return _Direction; }
			set
			{
				this.OnDirectionChanging(this._Direction, value);
				_Direction = value;
				this.OnDirectionChanged();
#if DEBUG
				// Debug.WriteLine($"Direction: {_direction} {this.CurrentChord} {this.CurrentNote}");
#endif
			}
		}
		public NoteRange NoteRange { get; set; }
		public Chord CurrentChord
		{
			get { return _CurrentChord; }
			set
			{
				this.OnChordChanging(_CurrentChord, value);
				_CurrentChord = value;
				this.OnChordChanged();
			}
		}
		public int CurrentBeat
        {
            get { return _CurrentBeat; }
            set
            {
                _CurrentBeat = value;
				if (_CurrentBeat % this.BeatsPerMeasure == 0)
				{
					this.CurrentMeasure++;
                }
            }
        }

		public int CurrentMeasure
        {
            get { return _CurrentMeasure; }
            set
            {
                this.OnMeasureChanging(_CurrentMeasure, value);
                _CurrentMeasure = value;
                this.OnMeasureChanged();
            }
        }

        ArpeggiationChordContext CurrentContext
		{
			get { return _CurrentContext; }
			set
			{
				this.OnArpeggiationContextChanging(this._CurrentContext, value);
				this._CurrentContext = value;
				this.OnArpeggiationContextChanged();
				this.CurrentChord = value.Chord;
			}
		}

		List<ArpeggiationChordContext> ChordContexts { get; set; } = new List<ArpeggiationChordContext>();

		bool UntilPatternRepeats { get; set; } = false;
		#endregion

		#region Construction
		public Arpeggiator(IEnumerable<ArpeggiationChordContext> contexts, DirectionEnum direction,
NoteRange noteRange, int beatsPerBar, Note startingNote = null)
		{
			this.Direction = direction;

            this.BeatsPerMeasure = beatsPerBar;
            this.ChordContexts = new List<ArpeggiationChordContext>(contexts);
			this.CurrentContext = this.ChordContexts[0];
			if (null == startingNote)
				startingNote = this.CurrentChord.Root;
			this.CurrentChord = this.CurrentContext.Chord;
            this.CurrentNote = startingNote;
			this.NoteRange = noteRange;
        }

        public Arpeggiator(IEnumerable<ArpeggiationChordContext> contexts, DirectionEnum direction,
	NoteRange noteRange, int beatsPerBar, Note startingNote = null, bool untilPatternRepeats = false)
			: this(contexts, direction, noteRange, beatsPerBar, startingNote)
		{
			this.UntilPatternRepeats = untilPatternRepeats;
		}

		public Arpeggiator(DirectionEnum direction,
NoteRange noteRange, int beatsPerBar, Note startingNote = null)
		{
			this.Direction = direction;
			this.CurrentNote = startingNote;
			this.NoteRange = noteRange;
			this.BeatsPerMeasure = beatsPerBar;
		}

		#endregion

		public Arpeggiator Add(ArpeggiationChordContext ctx)
		{
			if (null == this.CurrentContext)
				this.CurrentContext = ctx;
			this.ChordContexts.Add(ctx);	
			return this;
		}

		public void Arpeggiate()
		{
            var snapshots = new List<StateSnapshot>();
			var snapshot = new StateSnapshot(this);
			snapshots.Add(snapshot);

			var repeat = false;
			if (this.UntilPatternRepeats)
				repeat = true;

			bool firstTime = true;
			var direction = this.Direction;
			var allowTemporayReversal = false;
			if (direction.HasFlag(DirectionEnum.AllowTemporayReversal))
			{
				allowTemporayReversal = true;
			}


			var beat = 0;
			var seq = (from ctx in this.ChordContexts
				from notes in ctx.Chord.Notes
				select new { ChordContext=ctx, Notes= ctx.Chord.Notes, Beat=++beat, NotesToPlay = ctx.NotesToPlay }).ToList();

			new object();

			do
			{
				new object();
                if (firstTime)
                {
                    this.OnStarting();
                    this.OnDirectionChanged();
                    this.OnArpeggiationContextChanging(null, this._CurrentContext);
                    this.OnArpeggiationContextChanged();
                    this.OnStarted();
                    this.OnMeasureChanging(0, this._CurrentMeasure);
                    this.OnMeasureChanged();

                }
                foreach (var ctx in this.ChordContexts)
				{
					this.CurrentContext = ctx;

					var noteCount = ctx.NotesToPlay + 1;
                    while (0 < noteCount--)
                    //for (int i = 0; i < noteCount; ++i, --noteCount)
					{
						Debug.WriteLine(noteCount);
						if (firstTime)
						{
							OnNoteChanged();
                            firstTime = false;
						}
						else
						{
							if (allowTemporayReversal)
							{
								if (0 == noteCount)
								{
									direction |= DirectionEnum.AllowTemporayReversal;
								}
								else
								{
									direction = direction.GetMasked(DirectionEnum.Ascending | DirectionEnum.Descending);
								}
							}

							var closestNoteCtx = new Chord.ClosestNoteContext(
								this.CurrentChord, 
								this.CurrentNote, 
								this.Direction);
							if (closestNoteCtx.Direction != direction)
							{
								closestNoteCtx.Direction = direction;
							}

							this.CurrentChord.GetClosestNote(closestNoteCtx);
							var nextNote = closestNoteCtx.ClosestNote;
							if (direction != closestNoteCtx.Direction)
							{
								this.Direction = closestNoteCtx.Direction;
								if (!closestNoteCtx.Direction.HasFlag(DirectionEnum.AllowTemporayReversal))
								{
									direction = closestNoteCtx.Direction;
								}
							}

							Debug.Assert(null != nextNote);
							this.CurrentBeat = this.BeatsPerMeasure - noteCount;
							this.CurrentNote = nextNote;

							if (closestNoteCtx.TemporaryDirectionReversal)
								this.Direction = direction;
						}
					}
					if (this.UntilPatternRepeats)
					{
						if (snapshots.Any(x => x.Equals(this)))
						{
							repeat = false;
						}
						else
						{
							snapshots.Add(new StateSnapshot(this));
							this.NoteHistory.Clear();
						}
					}
				}
			}
			while (repeat);

			this.OnEnding();
			this.OnEnded();
		}

        void OnStarting()
        {
            if (null != Starting)
            {
                Starting?.Invoke(this, this);
                this.IsStarted = true;
            }
        }
        void OnStarted()
        {
            Started?.Invoke(this, this);
        }

        void OnMeasureChanging(int measure, int value)
        {
            MeasureChanging?.Invoke(this, this);
        }
        void OnMeasureChanged()
        {
            MeasureChanged?.Invoke(this, this);
        }

        void OnArpeggiationContextChanging(ArpeggiationChordContext current, ArpeggiationChordContext next)
        {
            ArpeggiationContextChanging?.Invoke(this, new ArpeggiationContextChangingEventArgs(this, current, next));
        }
        void OnArpeggiationContextChanged()
		{
			ArpeggiationContextChanged?.Invoke(this, this);
		}

        void OnChordChanging(Chord current, Chord next)
        {
            ChordChanging?.Invoke(this, new ChordChangingEventArgs(this, current, next));
        }
        void OnChordChanged()
		{
			if (null != ChordChanged)
				ChordChanged.Invoke(this, this);
		}

        void OnNoteChanging(Note current, Note next)
        {
            if (null != NoteChanging)
            {
                NoteChanging?.Invoke(this, new NoteChangingEventArgs(this, current, next));
            }
        }
		void OnNoteChanged()
		{
			if (null != NoteChanged)
				NoteChanged.Invoke(this, this);
		}

        void OnEnding()
        {
            this.IsCompleted = true;
            Ending?.Invoke(this, this);
        }
        void OnEnded()
		{
			Ended?.Invoke(this, this);
		}

        void OnDirectionChanging(DirectionEnum current, DirectionEnum next)
        {
            DirectionChanging?.Invoke(this, new DirectionChangingEventArgs(this, current, next));
        }
        void OnDirectionChanged()
        {
            DirectionChanged?.Invoke(this, this);
        }

    }//class

}//ns
