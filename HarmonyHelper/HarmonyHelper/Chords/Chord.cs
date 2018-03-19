using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class Chord : HarmonyEntityBase
	{
		#region Properties

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

		public Note Root { get; protected set; }
		Note Third { get; set; }
		Note Fifth { get; set; }
		Note Seventh { get; set; }
		ChordFormula Formula { get; set; }

		public List<Note> Notes { get; private set; } = new List<Note>();
		public List<NoteName> NoteNames { get; private set; } = new List<NoteName>();

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

		public Note GetClosestNoteEx(Arpeggiator ctx)
		{
			var result = this.Notes.FindClosest(ctx.CurrentNote, ctx.Direction);
			if (null == result)
			{
				ctx.Direction = ctx.Direction.Next();
				result = this.Notes.FindClosest(ctx.CurrentNote, ctx.Direction);
			}

			return result;
		}

		public override string ToString()
		{
			return $"{this.Name}: {this.Root.NoteName.ToString()},{this.Third.NoteName.ToString()},{this.Fifth.NoteName.ToString()},{this.Seventh.NoteName.ToString()}";
		}
		public string Name
		{
			get
			{
				var root = this.Root.ToString();
				var chordType = this.Formula.ChordType.ToStringEx();

				var result = string.Format("{0}{1}",
					root,
					chordType);
				return result;
			}
		}
	}//class

	static public class ListExtensions
	{
		public static Note FindClosest(this List<Note> list, Note lastNote, DirectionEnum direction)
		{
			Note result;

			if (DirectionEnum.Ascending == direction)
			{
				result = list.Where(x => x > lastNote).FirstOrDefault();
			}
			else
			{
				result = list.Where(x => x < lastNote).LastOrDefault();
			}
			return result;
		}

	}

}//ns
