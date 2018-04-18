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

			var repeat = false;
			if (this.UntilPatternRepeats)
				repeat = true;


			bool firstTime = true;
			bool allowTemporaryReversal = false;
			if (this.Direction.HasBitmask(DirectionEnum.AllowTemporayReversal))
			{
				allowTemporaryReversal = true;
				this.Direction = this.Direction.GetMasked(DirectionEnum.Ascending | DirectionEnum.Descending);
			}

			do
			{
				new object();
				foreach (var ctx in this.ArpeggiationContexts)
				{
					this.CurrentContext = ctx;

					if (firstTime)
					{
						OnDirectionChanged();
					}
					else
					{
						if (allowTemporaryReversal)
						{
							this._direction = this.Direction | DirectionEnum.AllowTemporayReversal;
						}
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
							if (this.CurrentChord.Name == "B7")
								if (this.CurrentNote.NoteName.ToString() == "C♯")
									if (0 == i)
										new object();
							var next = this.CurrentChord.GetClosestNoteEx(this);
							if (allowTemporaryReversal)
							{
								this._direction = this.Direction.GetMasked(DirectionEnum.Ascending | DirectionEnum.Descending);
							}

							Debug.Assert(null != next);
							this.CurrentNote = next;
						}
					}
					if (this.UntilPatternRepeats)
					{
						var count = snapshots.Count(x => x.Equals(this));
						if (0 < count)
						{
							repeat = false;
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
