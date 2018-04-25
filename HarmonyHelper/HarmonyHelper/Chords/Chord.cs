using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class Chord : HarmonyEntityBase, IEquatable<Chord>, IComparable<Chord>
	{
		#region Properties

		public Note Root { get; protected set; }
		Note Third { get; set; }
		Note Fifth { get; set; }
		Note Seventh { get; set; }
		public ChordFormula Formula { get; private set; }
		public List<Note> Notes { get; private set; } = new List<Note>();
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();
		public string Name
		{
			get
			{
				var root = this.Root.NoteName.ToString();
				var chordType = this.Formula.ChordType.ToStringEx();

				var result = string.Format("{0}{1}",
					root,
					chordType);
				return result;
			}
		}

		#endregion

		#region Construction


		public Chord(ChordFormula formula, NoteRange noteRange) : base(formula.Key)
		{
			if (null == formula)
				throw new ArgumentNullException();
			if (null == formula.Key)
				throw new ArgumentNullException();
			if (null == noteRange)
				throw new ArgumentNullException();

			this.Key = formula.Key;

			this.Root = noteRange.First(formula.Root, this.Key);
			this.Third = noteRange.First(formula.Third, this.Key);
			this.Fifth = noteRange.First(formula.Fifth, this.Key);
			this.Seventh = noteRange.First(formula.Seventh, this.Key);
			this.Formula = formula;

			if (null == this.Root)
				throw new NullReferenceException();
			if (null == this.Third)
				throw new NullReferenceException();
			if (null == this.Fifth)
				throw new NullReferenceException();
			if (null == this.Seventh)
				throw new NullReferenceException();

			this.PopulateNotes(noteRange);
		}

		public Chord(Note root, Note third, Note fifth, Note seventh, NoteRange noteRange)
			: base(KeySignature.CMajor)
		{
			if (null == root)
				throw new ArgumentNullException();
			if (null == third)
				throw new ArgumentNullException();
			if (null == fifth)
				throw new ArgumentNullException();
			if (null == seventh)
				throw new ArgumentNullException();
			this.Root = root;
			this.Third = third;
			this.Fifth = fifth;
			this.Seventh = seventh;

			this.PopulateNotes(noteRange);
		}

		void PopulateNotes(NoteRange noteRange)
		{
			var notes = new List<Note>()
			{
				this.Root,
				this.Third,
				this.Fifth,
				this.Seventh,
			};
			this.NoteNames = notes.Select(x => x.NoteName).ToList();

			var result = noteRange.GetNotes(notes);
			result.ForEach(x => this.Notes.Add(x));
		}

		#endregion

		public void Set(NoteRange noteRange)
		{
			this.PopulateNotes(noteRange);
		}
		public bool IsValid()
		{
			var result = false;
			if (this.Key.UsesFlats)
			{
				if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsFlat)
					if (this.NoteNames.All(x => x.IsNatural || x.IsFlat))
						if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsFlat))
							result = true;
			}
			else if (this.Key.UsesSharps)
			{
				if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsSharp)
					if (this.NoteNames.All(x => x.IsNatural || x.IsSharp))
						if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsSharp))
							result = true;
			}
			Debug.Assert(result);
			return result;
		}

		public class ClosestNoteContext
		{
			public DirectionEnum Direction { get; set; }
			public Note LastNote { get; private set; }
			public Note ClosestNote { get; set; }
			public List<Note> Notes { get; set; }
			public bool TemporaryDirectionReversal { get; set; }
			public bool ExceededRangeLimit { get; set; }

			public ClosestNoteContext(Arpeggiator arpeggiator)
			{
				this.LastNote = arpeggiator.CurrentNote;
				this.Direction = arpeggiator.Direction;
				this.Notes = arpeggiator.CurrentChord.Notes;
			}
			public ClosestNoteContext(Arpeggiator arpeggiator, DirectionEnum direction) : this(arpeggiator)
			{
				this.Direction = direction;
			}

			public override string ToString()
			{
				var result = $"Direction={this.Direction}, LastNote={this.LastNote}, ClosestNote={this.ClosestNote}"; 
				if (this.TemporaryDirectionReversal)
					result = $"Direction={this.Direction}, TemporaryDirectionReversal={TemporaryDirectionReversal} LastNote={this.LastNote}, ClosestNote={this.ClosestNote}";
				return result;
			}
		}
		public void GetClosestNoteEx(ClosestNoteContext ctx)
		{
			var result = ctx.FindClosest();
			if (null == result)
			{
				ctx.Direction = ctx.Direction.Reverse();
				result = ctx.FindClosest();
				Debug.Assert(null != result);
			}

			Debug.Assert(ctx.LastNote.NoteName.Value != result.NoteName.Value);
			ctx.ClosestNote = result;
		}



		public override string ToString()
		{
			return $"{this.Name}: {this.Root.NoteName.ToString()},{this.Third.NoteName.ToString()},{this.Fifth.NoteName.ToString()},{this.Seventh.NoteName.ToString()}";
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is Chord)
				result = this.Equals(obj as Note);
			return result;
		}

		public bool Equals(Chord other)
		{
			var result = false;
			if (0 == this.CompareTo(other))
			{
				result = true;
			}
			return result;
		}

		public int CompareTo(Chord other)
		{
			var result = 0;
			var nonintersect = this.Notes.Except(other.Notes).Union(other.Notes.Except(this.Notes));
			var count = nonintersect.Count();
			if (count > 0)
			{
#warning HACK ALERT!!
				result = -1;
			}
			return result;
		}

		public static bool operator ==(Chord a, Chord b)
		{
			var result = a.CompareTo(b) == 0;
			return result;
		}
		public static bool operator !=(Chord a, Chord b)
		{
			var result = a.CompareTo(b) != 0;
			return result;
		}

		public override int GetHashCode()
		{
			var result = 0;
			this.Notes.ForEach(x => result ^= x.GetHashCode());
			return result;
		}

	}//class
}//ns
