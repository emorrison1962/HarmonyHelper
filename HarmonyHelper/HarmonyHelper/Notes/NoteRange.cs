﻿using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class NoteRange
	{
		public static readonly NoteRange Default = new NoteRange(new Note(NoteName.C, OctaveEnum.Octave3), new Note(NoteName.C, OctaveEnum.Octave4));
		public Note LowerLimit { get; set; }
		public Note UpperLimit { get; set; }

		public List<Note> Notes { get; private set; } = new List<Note>();

		protected NoteRange()
		{
		}
		public NoteRange(Note lowerLimit, Note upperLimit)
		{
			this.LowerLimit = lowerLimit;
			this.UpperLimit = upperLimit;
			Init();
		}

		public NoteRange(Note lowerLimit, int numberOfOctaves)
		{
			this.LowerLimit = lowerLimit;
			var upperLimit = this.LowerLimit.Copy();
			var octaves = Enum.GetValues(typeof(OctaveEnum)).Cast<OctaveEnum>().ToList();

			for (int i = 0 ; i < numberOfOctaves ; ++i)
			{
				var octave = upperLimit.Octave;
				octave = octaves.FirstOrDefault(x => x > octave);
				if (OctaveEnum.Octave0 == octave)
				{
					throw new ArgumentOutOfRangeException("Invalid octave count.");
				}
				upperLimit.Octave = octave;
			}

			this.UpperLimit = upperLimit;
			Init();
		}

		protected void Init()
		{
			if (null == this.LowerLimit)
				throw new InvalidOperationException();
			if (null == this.UpperLimit)
				throw new InvalidOperationException();

			var notes = new List<Note>();
			var note = this.LowerLimit.Copy();
			notes.Add(note);

			var chromatic = new ChromaticScaleFormula(KeySignature.CMajor);
			var octave = (int)this.LowerLimit.Octave;
			bool wrapped = false;

			while (note < this.UpperLimit)
			{
				var noteName = chromatic.NoteNames.NextOrFirst(note.NoteName, ref wrapped);
				if (wrapped)
				{
					++octave;
					wrapped = false;
				}
				note = new Note(noteName, (OctaveEnum)octave);
				notes.Add(note);
				if (this.UpperLimit.Equals(note))
					break;
			}

			notes.Sort(new NoteComparer());
			this.Notes = notes;
		}

		public Note First(NoteName nn, INoteNameNormalizer normalizer)
		{
			Note result = null;
			if (null != nn)
			{
				var tmp = this.Notes.Where(x => x.NoteName.Value == nn.Value).FirstOrDefault();
				result = tmp.Copy();
				var normalized = nn;// normalizer.GetNormalized(nn, null);
				result.SetNoteName(normalized);
			}
			return result;
		}

		public List<Note> GetNotes(List<Note> requestedNotes)
		{
			var result = new List<Note>();

			#region Remove out of range octaves

			var octaves = Enum.GetValues(typeof(OctaveEnum)).OfType<OctaveEnum>().ToList();
			octaves.Where(x => x < this.LowerLimit.Octave || x > this.UpperLimit.Octave)
				.ToList().ForEach(x => octaves.Remove(x));

			#endregion

			foreach (var note in requestedNotes)
			{
				var copy = new Note(note);
				foreach (var octave in octaves)
				{
					copy = new Note(copy);
					copy.Octave = octave;

					if (copy <= this.UpperLimit)
					{
						result.Add(copy);
					}
					else
					{
						break;
					}
				}
			}

			result.Where(x => x < this.LowerLimit || x > this.UpperLimit)
				.ToList().ForEach(x => result.Remove(x));

			//this.AdjustExceptiopnalNotes(result);

			return result;
		}

		void AdjustExceptiopnalNotes(List<Note> notes)
		{
#warning HACK ALERT: NoteName.Cb or NoteName.BSharp? For programmatic convenience, adjust OctaveEnum
			#region HACK ALERT
			if (notes.Any(x => x.NoteName == NoteName.Cb))
			{
				Action<Note> fixOctave = (x) => x.Octave = ++x.Octave;
				var affected = notes.Where(x => x.NoteName == NoteName.Cb).ToList();
				affected.ForEach(x => fixOctave(x));
			}
			if (notes.Any(x => x.NoteName == NoteName.BSharp))
			{
				Action<Note> fixOctave = (x) => x.Octave = --x.Octave;
				var affected = notes.Where(x => x.NoteName == NoteName.BSharp).ToList();
				affected.ForEach(x => fixOctave(x));
			}
			#endregion
		}


		public List<Note> GetNotes(IEnumerable<NoteName> requestedNames)
		{
			var wantedNotes = new List<Note>();
			foreach (var nn in requestedNames)
			{
				var tmp = new Note(nn, OctaveEnum.Unknown);
				wantedNotes.Add(tmp);
			}
			var result = this.GetNotes(wantedNotes);
			return result;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name}: {this.LowerLimit}-{this.UpperLimit}";
		}
	}//class

	public class FiveStringBassRange : NoteRange
	{
		public FiveStringBassRange(FiveStringBassPositionEnum position)
		{
			this.SetNoteRange(position);
			base.Init();
		}

		void SetNoteRange(FiveStringBassPositionEnum position)
		{
			switch (position)
			{
				case FiveStringBassPositionEnum.FirstPosition:
					{
						this.UpperLimit = new Note(NoteName.B, OctaveEnum.Octave2);
						this.LowerLimit = new Note(NoteName.B, OctaveEnum.Octave0);
					}
					break;
				case FiveStringBassPositionEnum.FifthPosition:
					{
						this.UpperLimit = new Note(NoteName.E, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.E, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.SixthPosition:
					{
						this.UpperLimit = new Note(NoteName.Eb, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.F, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.SeventhPosition:
					{
						this.UpperLimit = new Note(NoteName.Gb, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.Gb, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.EigthPosition:
					{
						this.UpperLimit = new Note(NoteName.G, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.G, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.NinthPosition:
					{
						this.UpperLimit = new Note(NoteName.Ab, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.Ab, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.TenthPosition:
					{
						this.UpperLimit = new Note(NoteName.A, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.EleventhPosition:
					{
						this.UpperLimit = new Note(NoteName.Bb, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.Bb, OctaveEnum.Octave1);
					}
					break;
				case FiveStringBassPositionEnum.TwelfthPosition:
					{
						this.UpperLimit = new Note(NoteName.B, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.B, OctaveEnum.Octave1);
					}
					break;
				default:
					{ throw new ArgumentOutOfRangeException(); }

			}
		}

		/// <summary>
		/// C1 = B string, 1st fret
		/// C2 = B string, 13th fret
		/// C2 = E string, 8th fret
		/// C2 = A string, 3rd fret
		/// C3 = A string, 15th fret
		/// C3 = G string, 5th fret
		/// C3 = D string, 10th fret
		/// C4 (Middle C)= G string, 17th fret on of bass guitar.
		/// 
		/// 1st pos, B0, B2
		/// 5th E1, E3
		/// 9th G1, G3
		/// 12th B1, B3
		/// 
		/// </summary>

	}//class

	public class GuitarNoteRange : NoteRange
	{
		public GuitarNoteRange(GuitarPositionEnum position)
		{
			this.SetNoteRange(position);
			base.Init();
		}

		void SetNoteRange(GuitarPositionEnum position)
		{
			var openUpperLimit = new Note(NoteName.Ab, OctaveEnum.Octave3);
			var openLowerLimit = new Note(NoteName.E, OctaveEnum.Octave1);
			//var x = Enum.GetValues(typeof(GuitarPositionEnum))
			//	.Cast<int>()
			//	.ToList()
			//	.Where(x => x == (int)position)
			//	.First();

			openUpperLimit += (Interval)(int)position;
			openLowerLimit += (Interval)(int)position;
			this.UpperLimit = openUpperLimit;
			this.LowerLimit = openLowerLimit;

#if false
			switch (position)
			{
				case GuitarPositionEnum.OpenPosition:
					{
						this.UpperLimit = new Note(NoteName.E, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.Ab, OctaveEnum.Octave1);
					}
					break;
				case GuitarPositionEnum.FirstPosition:
					{
						this.UpperLimit = new Note(NoteName.E, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.Ab, OctaveEnum.Octave1);
					}
					break;
				case GuitarPositionEnum.SecondPosition:
					{
						this.UpperLimit = new Note(NoteName.F, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave1);
					}
					break;
				case GuitarPositionEnum.ThirdPosition:
					{
						this.UpperLimit = new Note(NoteName.F, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave1);
					}
					break;
				case GuitarPositionEnum.FourthPosition:
					{
						this.UpperLimit = new Note(NoteName.F, OctaveEnum.Octave3);
						this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave1);
					}
					break;
				case GuitarPositionEnum.FifthPosition:
					{
						this.UpperLimit = new Note(NoteName.Db, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.A, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.SixthPosition:
					{
						this.UpperLimit = new Note(NoteName.A, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.Db, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.SeventhPosition:
					{
						this.UpperLimit = new Note(NoteName.Bb, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.D, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.EigthPosition:
					{
						this.UpperLimit = new Note(NoteName.B, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.Eb, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.NinthPosition:
					{
						this.UpperLimit = new Note(NoteName.Db, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.Db, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.TenthPosition:
					{
						this.UpperLimit = new Note(NoteName.D, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.D, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.EleventhPosition:
					{
						this.UpperLimit = new Note(NoteName.Eb, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.Eb, OctaveEnum.Octave2);
					}
					break;
				case GuitarPositionEnum.TwelfthPosition:
					{
						this.UpperLimit = new Note(NoteName.E, OctaveEnum.Octave4);
						this.LowerLimit = new Note(NoteName.E, OctaveEnum.Octave2);
					}
					break;
				default:
					{ throw new ArgumentOutOfRangeException(); }

			} 
#endif
		}

		/// <summary>
		/// C1 = B string, 1st fret

		/// C2 = B string, 13th fret
		/// C2 = E string, 8th fret
		/// C2 = A string, 3rd fret

		/// C3 = A string, 15th fret
		/// C3 = G string, 5th fret
		/// C3 = D string, 10th fret

		/// C4 (Middle C)= G string, 17th fret on of bass guitar.
		/// 
		/// 1st pos, B0, B2
		/// 5th E1, E3
		/// 9th G1, G3
		/// 12th B1, B3
		/// 
		/// </summary>

	}//class

}//ns
