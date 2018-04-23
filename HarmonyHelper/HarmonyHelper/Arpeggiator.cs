using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public partial class Arpeggiator
	{
		#region Events
		public event EventHandler<Arpeggiator> ArpeggiationContextChanged;
		public event EventHandler<Arpeggiator> ChordChanged;
		public event EventHandler<Arpeggiator> DirectionChanged;
		public event EventHandler<Arpeggiator> CurrentNoteChanged;
		public event EventHandler<Arpeggiator> Starting;
		public event EventHandler<Arpeggiator> Ending;

		#endregion

		#region Fields
		Note _currentNote;
		DirectionEnum _direction;
		Chord _chord;
		ArpeggiationContext _currentContext;

		#endregion

		#region Properties
		public int BeatsPerBar { get; set; }
		public Note CurrentNote
		{
			get { return _currentNote; }
			set
			{
				this._currentNote = value;
				OnCurrentNoteChanged();
			}
		}

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
		public Chord CurrentChord
		{
			get { return _chord; }
			set
			{
				_chord = value;
				this.OnChordChanged();
			}
		}

		ArpeggiationContext CurrentContext
		{
			get { return _currentContext; }
			set
			{
				this._currentContext = value;
				this.CurrentChord = value.Chord;
			}
		}

		List<ArpeggiationContext> ArpeggiationContexts { get; set; } = new List<ArpeggiationContext>();

		bool UntilPatternRepeats { get; set; } = false;
		#endregion

		#region Construction
		public Arpeggiator(IEnumerable<ArpeggiationContext> contexts, DirectionEnum direction,
NoteRange noteRange, int beatsPerBar, Note startingNote = null)
		{
			this.Direction = direction;

			this.ArpeggiationContexts = new List<ArpeggiationContext>(contexts);
			this.CurrentContext = this.ArpeggiationContexts[0];
			if (null == startingNote)
				startingNote = this.CurrentChord.Root;
			this.CurrentNote = startingNote;
			this.NoteRange = noteRange;
			this.BeatsPerBar = beatsPerBar;
		}

		public Arpeggiator(IEnumerable<ArpeggiationContext> contexts, DirectionEnum direction,
	NoteRange noteRange, int beatsPerBar, Note startingNote = null, bool untilPatternRepeats = false)
			: this(contexts, direction, noteRange, beatsPerBar, startingNote)
		{
			this.UntilPatternRepeats = untilPatternRepeats;
		}

		#endregion

		public void Arpeggiate()
		{
			this.OnStarting();

			var snapshots = new List<StateSnapshot>();
			var snapshot = new StateSnapshot(this);
			snapshots.Add(snapshot);

#if DEBUG
			int ctxNo = 1;
#endif

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

			do
			{
				new object();
				foreach (var ctx in this.ArpeggiationContexts)
				{
#if DEBUG
					if (++ctxNo == 27)
						new object();
					new object();

#endif
					this.CurrentContext = ctx;
					if (firstTime)
					{
						OnDirectionChanged();
					}

					for (int i = 0; i < ctx.NotesToPlay; ++i)
					{
						if (firstTime)
						{
							OnCurrentNoteChanged();
							firstTime = false;
						}
						else
						{
							if (allowTemporayReversal)
							{
								if (0 == i)
								{
									direction |= DirectionEnum.AllowTemporayReversal;
								}
								else
								{
									direction = direction.GetMasked(DirectionEnum.Ascending | DirectionEnum.Descending);
								}
							}
#if DEBUG
							if ((ctx.NotesToPlay - 1) == i)
							{
								if (ChordToneFunctionEnum.Minor7th == this.CurrentChord.Formula
									.GetChordToneFunction(this.CurrentNote.NoteName))
								{
									new object();
								}
							}
#endif

							var closestNoteCtx = new Chord.ClosestNoteContext(this);
							if (closestNoteCtx.Direction != direction)
							{
								closestNoteCtx.Direction = direction;
							}

							this.CurrentChord.GetClosestNoteEx(closestNoteCtx);
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
							if (closestNoteCtx.TemporaryDirectionReversal)
								new object();
							this.CurrentNote = nextNote;
							if (closestNoteCtx.TemporaryDirectionReversal)
								this.Direction = direction;
							new object();

						}
						new object();
					}
					if (this.UntilPatternRepeats)
					{
						var count = snapshots.Count(x => x.Equals(this));
						if (0 < count)
						{
							repeat = false;
#if DEBUG
							snapshots.Count(x => x.Equals(this));
#endif
						}
						else
						{
							snapshots.Add(new StateSnapshot(this));
						}
					}
					if (!repeat)
						new object();
				}

				//this._currentContext = this.ArpeggiationContexts[0];
				//this._currentNote = this.CurrentChord.GetClosestNoteEx(this);

				new object();
			}
			while (repeat);

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
