using Eric.Morrison.Harmony.Intervals;
using HarmonyHelper.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony.Chords
{
    public class Chord : ChordEntityBase, IEquatable<Chord>, IComparable<Chord>
	{
		#region Properties

		public Note Root { get; protected set; }
		//Note Third { get; set; }
		//Note Fifth { get; set; }
		//Note Seventh { get; set; }
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
		public bool IsMajor { get { return this.Formula.ChordType.IsMajor; } }
		public bool IsMinor { get { return this.Formula.ChordType.IsMinor; } }
		public bool IsDiminished { get { return this.Formula.ChordType.IsDiminished; } }

		#endregion

		#region Construction

		public Chord SetNoteRange(NoteRange noteRange)
		{
			if (null == noteRange)
				throw new ArgumentNullException();
			this.Root = noteRange.First(this.Formula.Root);
			this.PopulateNotes(noteRange);
			return this;
		}

		public Chord(ChordFormula formula, NoteRange noteRange) : base(formula.Keys)
		{
			if (null == formula)
				throw new ArgumentNullException();
			if (null == noteRange)
				throw new ArgumentNullException();

			this.Formula = formula;
			this.NoteNames = formula.NoteNames;

			this.SetNoteRange(noteRange);
		}

		public Chord(NoteRange noteRange, Note root, params Note[] notes)
			: base(KeySignature.CMajor)
		{
			if (null == root)
				throw new ArgumentNullException();
			this.Root = root;
			this.NoteNames = notes.Select(x => x.NoteName).ToList();

			this.PopulateNotes(noteRange);
		}

		void PopulateNotes(NoteRange noteRange)
		{
			var pendingNotes = noteRange.GetNotes(this.NoteNames);
			pendingNotes.ForEach(x => this.Notes.Add(x));
			this.Notes.Sort(new NoteComparer());
		}

		#endregion

		public void Set(NoteRange noteRange)
		{
			this.PopulateNotes(noteRange);
		}
		public bool IsValid()
		{
			var result = false;
			foreach (var key in this._Keys)
			{
				if (key.UsesFlats)
				{
					if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsFlatted)
						if (this.NoteNames.All(x => x.IsNatural || x.IsFlatted))
							if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsFlatted))
								result = true;
				}
				else if (key.UsesSharps)
				{
					if (this.Root.NoteName.IsNatural || this.Root.NoteName.IsSharped)
						if (this.NoteNames.All(x => x.IsNatural || x.IsSharped))
							if (this.Notes.All(x => x.NoteName.IsNatural || x.NoteName.IsSharped))
								result = true;
				}
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

			[Obsolete("", false)]
			public ClosestNoteContext(Arpeggiator arpeggiator)
			{
				this.LastNote = arpeggiator.CurrentNote;
				this.Direction = arpeggiator.Direction;
				this.Notes = arpeggiator.CurrentChord.Notes;
			}
			public ClosestNoteContext(Chord chord, Note lastNote, DirectionEnum direction)
			{
				this.Notes = chord.Notes;
				this.LastNote = lastNote;
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
		public void GetClosestNote(ClosestNoteContext ctx)
		{
			var result = ctx.FindClosest();
			if (null == result)
			{
				ctx.Direction = ctx.Direction.Reverse();
				result = ctx.FindClosest();
				Debug.Assert(null != result);
			}

			Debug.Assert(ctx.LastNote.NoteName.RawValue != result.NoteName.RawValue);
			ctx.ClosestNote = result;
		}



		public override string ToString()
		{
			return $"{this.Formula}";
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
				result = -1;
			}
			return result;
		}

		public static bool operator ==(Chord a, Chord b)
		{
			if (a is null)
				return b is null;
			var result = a.CompareTo(b) == 0;
			return result;
		}
		public static bool operator !=(Chord a, Chord b)
		{
			var result = !(a == b);
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
