using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Eric.Morrison.Harmony
{
	public class Arpeggiator
	{
		public event EventHandler<Arpeggiator> ArpeggiationContextChanged;
		public event EventHandler<Arpeggiator> ChordChanged;
		public event EventHandler<Arpeggiator> DirectionChanged;
		public event EventHandler<Arpeggiator> CurrentNoteChanged;
		public event EventHandler<Arpeggiator> Starting;
		public event EventHandler<Arpeggiator> Ending;
		public int BeatsPerBar { get; set; }
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
		public Chord CurrentChord
		{
			get { return _chord; }
			set
			{
				_chord = value;
				this.OnChordChanged();
			}
		}
		//List<Chord> Chords { get; set; } = new List<Chord>();

		ArpeggiationContext _currentContext;
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
	NoteRange noteRange, int beatsPerBar, bool untilPatternRepeats)
			: this(contexts, direction, noteRange, beatsPerBar)
		{
			this.UntilPatternRepeats = untilPatternRepeats;
		}
		bool UntilPatternRepeats { get; set; } = false;

		class StartingState
		{
			ArpeggiationContext ArpeggiationContext { get; set; }
			Chord StartingChord { get; set; }
			DirectionEnum StartingDirection { get; set; }
			Note StartingNote { get; set; }
			public StartingState(Arpeggiator arp)
			{
				this.ArpeggiationContext = arp.CurrentContext;
				this.StartingChord = arp.CurrentChord;
				this.StartingNote = arp.CurrentNote;
				this.StartingDirection = arp.Direction;
			}

			public bool Equals(Arpeggiator arp)
			{
				var result = false;
				bool success = true;
				if (success)
				{
					success = this.ArpeggiationContext == arp.CurrentContext;
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingChord == arp.CurrentChord;
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingNote == arp.CurrentNote;
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingDirection == arp.Direction;
					if (!success) { new object(); }
				}
				if (success)
				{
					result = true;
				}
#if false
#warning FIXME: debug logic start.
				else
				{
					var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
					var key = KeySignature.GMajor;
					var chord = new Chord(
						new ChordFormula(NoteName.A,
							ChordTypesEnum.Minor7th,
							key),
						noteRange);


					if (chord.ToString() == this.StartingChord.ToString()
						&& chord.ToString() == arp.CurrentChord.ToString())
					{
						new object();
					}
				}
#warning FIXME: debug logic end.
#endif
				return result;
			}
		}
		public void Arpeggiate()
		{
			this.OnStarting();

			var snapshot = new StartingState(this);
			var repeat = false;
			if (this.UntilPatternRepeats)
				repeat = true;


			bool firstTime = true;

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
					for (int i = 0; i < ctx.NotesToPlay; ++i)
					{
						if (firstTime)
						{
							OnCurrentNoteChanged();
							firstTime = false;
						}
						else
						{
							var next = this.CurrentChord.GetClosestNoteEx(this);
							Debug.Assert(null != next);
							this.CurrentNote = next;
						}
					}
					if (this.UntilPatternRepeats)
						repeat = !snapshot.Equals(this);
					if (!repeat)
						new object();
				}

				this._currentContext = this.ArpeggiationContexts[0];
				this._currentNote = this.CurrentChord.GetClosestNoteEx(this);

				new object();
				if (this.UntilPatternRepeats)
					// "this is broke. infinite repeat...."
					repeat = !snapshot.Equals(this);
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

	public class ArpeggiationContext
	{
		public Chord Chord { get; set; }
		public int NotesToPlay { get; set; }

		public ArpeggiationContext(Chord chord, int notesToPlay)
		{
			this.Chord = chord;
			this.NotesToPlay = notesToPlay;
		}
		public override string ToString()
		{
			return this.Chord.ToString();
		}
	}

}//ns
