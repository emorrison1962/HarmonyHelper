using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public partial class Arpeggiator
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
	NoteRange noteRange, int beatsPerBar, Note startingNote = null, bool untilPatternRepeats = false)
			: this(contexts, direction, noteRange, beatsPerBar, startingNote)
		{
			this.UntilPatternRepeats = untilPatternRepeats;
		}
		bool UntilPatternRepeats { get; set; } = false;

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

				this._currentContext = this.ArpeggiationContexts[0];
				this._currentNote = this.CurrentChord.GetClosestNoteEx(this);

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

	public class ArpeggiationContext : IEquatable<ArpeggiationContext>, IComparable<ArpeggiationContext>
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

		public bool Equals(ArpeggiationContext other)
		{
			var result = this.Chord.CompareTo(other.Chord) == 0;
			return result;
		}

		public int CompareTo(ArpeggiationContext other)
		{
			return this.Chord.CompareTo(other.Chord);
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is ArpeggiationContext)
				result = this.Equals(obj as Note);
			return result;
		}

		public static bool operator ==(ArpeggiationContext a, ArpeggiationContext b)
		{
			var result = a.CompareTo(b) == 0;
			return result;
		}
		public static bool operator !=(ArpeggiationContext a, ArpeggiationContext b)
		{
			var result = a.CompareTo(b) != 0;
			return result;
		}

		public override int GetHashCode()
		{
			return this.Chord.GetHashCode();
		}
	}

}//ns
