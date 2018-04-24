using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public partial class Arpeggiator
	{
		class StateSnapshot : IEquatable<StateSnapshot>
		{
			ArpeggiationContext ArpeggiationContext { get; set; }
			Chord StartingChord { get; set; }
			DirectionEnum StartingDirection { get; set; }
			Note StartingNote { get; set; }
			List<Note> NoteHistory { get; set; } = new List<Note>();

			public StateSnapshot(Arpeggiator arp)
			{
				this.ArpeggiationContext = arp.CurrentContext;
				this.StartingChord = arp.CurrentChord;
				this.StartingNote = arp.CurrentNote;
				this.StartingDirection = arp.Direction;
				this.NoteHistory = arp.NoteHistory;

			}

			public static implicit operator StateSnapshot(Arpeggiator arp)
			{
				StateSnapshot temp = new StateSnapshot(arp);
				return temp;
			}

			public bool Equals(Arpeggiator arp)
			{
				var result = false;
				bool success = true;
				if (success)
				{
					success = this.ArpeggiationContext.Equals(arp.CurrentContext);
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingChord.Equals(arp.CurrentChord);
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingNote.Equals(arp.CurrentNote);
					if (!success) { new object(); }
				}
				if (success)
				{
					success = this.StartingDirection == arp.Direction;
					if (!success) { new object(); }
				}
				if (success)
				{
					if (this.NoteHistory.Count != arp.NoteHistory.Count)
						success = false;
					else
					{
						var count = this.NoteHistory.Count;
						for (int i = 0; i < count; ++count)
						{
							if (this.NoteHistory[i] != arp.NoteHistory[i])
							{
								success = false;
								break;
							}
						}
						if (!success) { new object(); }
					}
				}
				if (success)
				{
					result = true;
				}
#if DEBUG
#warning FIXME: debug logic start.
				else
				{
					var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.FifthPosition);
					var key = KeySignature.GMajor;
					var chord = new Chord(
						ChordFormulaFactory.Create(NoteName.A,
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

			public bool Equals(StateSnapshot other)
			{
				return this.Equals(other);
			}

			public override int GetHashCode()
			{
				var result = this.ArpeggiationContext.GetHashCode()
					^ this.StartingChord.GetHashCode()
					^ this.StartingDirection.GetHashCode()
					^ this.StartingNote.GetHashCode();
				return result;
			}

			public override bool Equals(object obj)
			{
				var result = false;
				if (obj is StateSnapshot)
					result = this.Equals(obj as Note);
				return result;
			}

			public static bool operator ==(StateSnapshot snapshot, Arpeggiator arp)
			{
				var result = snapshot.Equals(arp);
				return result;
			}

			public static bool operator !=(StateSnapshot snapshot, Arpeggiator arp)
			{
				var result = !snapshot.Equals(arp);
				return result;
			}

			public override string ToString()
			{
				return $"{base.ToString()}: StartingChord={this.StartingChord}, StartingNote={this.StartingNote}, StartingDirection={this.StartingDirection}";
			}

		}//class

	}//class
}//ns
