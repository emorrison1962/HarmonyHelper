using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony.Scales
{
	public abstract class ScaleBase : HarmonyEntityBase
	{
		#region Fields

		ScaleFormulaBase _formula;
		List<NoteName> _noteNames = new List<NoteName>();

		#endregion Fields

		#region Properties
		public List<Note> Notes { get; protected set; } = new List<Note>();
		public List<NoteName> NoteNames
		{
			get { return this._noteNames; }
			protected set
			{
				if (null == value)
				{
					throw new ArgumentNullException();
				}
				if (null == this._noteNames)
				{
					this._noteNames = value;
					this.Init();
				}
			}
		}
		public Note CurrentNote { get; set; }
		public NoteRange NoteRange { get; protected set; }
		protected ScaleFormulaBase Formula
		{
			get { return _formula; }
			set
			{
				if (null == value)
				{
					throw new ArgumentNullException();
				}
				if (null == this._formula)
				{
					this._formula = value;
					this.Init();
				}
			}
		}
		virtual public string Name { get; protected set; }
		int MaxIndex
		{
			get
			{
				return this.Notes.Count - 1;
			}
		}

		#endregion Properties

		#region Construction
		protected ScaleBase(KeySignature key, NoteRange noteRange, bool runInit = true) : base(key)
		{
			if (null == key)
				throw new ArgumentNullException();
			if (null == noteRange)
				throw new ArgumentNullException();
			this.NoteRange = noteRange;
			if (runInit)
				this.Init();
		}

		protected ScaleBase(KeySignature key, ScaleFormulaBase formula, NoteRange noteRange) : this(key, noteRange, false)
		{
			if (null == formula)
				throw new ArgumentNullException();
			this.Formula = formula;
			this.Init();
		}

		void Init()
		{
			if (null != this.NoteNames
				&& null != this.Formula)
			{
				this.NoteNames.Add(this.Key.NoteName);
				foreach (var interval in this.Formula.Intervals)
				{
					var nn = this.Key.NoteName + interval;
					this.NoteNames.Add(nn);
				}

				var requestedNotes = this.NoteNames.Select(x => new Note(x, OctaveEnum.Octave0)).ToList();
				var result = this.NoteRange.GetNotes(requestedNotes);
				result.ForEach(x => this.Notes.Add(x));
			}
		}


		#endregion Construction

		public Note Next(DirectionEnum direction = DirectionEnum.Ascending)
		{
			Note result = null;
			var currentNdx = this.Notes.IndexOf(this.CurrentNote);

			if (DirectionEnum.Ascending == direction)
			{
				var nextNdx = 0;
				if (currentNdx < this.MaxIndex)
				{
					nextNdx = currentNdx + 1;
				}
				result = this.Notes[nextNdx];
			}
			else
			{
				var nextNdx = this.MaxIndex;
				if (currentNdx > 0)
				{
					nextNdx = currentNdx - 1;
				}
				result = this.Notes[nextNdx];
			}

			return result;
		}


	}//class
}//ns
