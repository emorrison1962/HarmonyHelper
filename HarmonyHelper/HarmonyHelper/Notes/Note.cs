﻿using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
	public class Note : ClassBase, IEquatable<Note>, IComparable<Note>
	{
		#region Properties
		public NoteName NoteName { get; private set; }

		public OctaveEnum Octave { get; set; }

		#endregion

		#region Construction

		public Note(Note src)
		{
			if (null == src)
				throw new ArgumentNullException();
			this.NoteName = src.NoteName.Copy();
			this.Octave = src.Octave;
		}
		public Note(NoteName nn, OctaveEnum octave)
		{
			this.NoteName = nn;
			this.Octave = octave;
		}

		public Note Copy()
		{
			var result = new Note(this);
			return result;
		}
		#endregion

		public void SetNoteName(NoteName nn)
		{
			this.NoteName = nn;
		}

		public override string ToString()
		{
			//var result = this.NoteName.ToString();
			string octaveNum = string.Empty;
			switch ((int)this.Octave)
			{
				case 0: { octaveNum = "⁰"; break; }
				case 1: { octaveNum = "¹"; break; }
				case 2: { octaveNum = "²"; break; }
				case 3: { octaveNum = "³"; break; }
				case 4: { octaveNum = "⁴"; break; }
				default: 
					{
						throw new NotImplementedException();
					}
			}

			//⁰²³⁴¹
			var result = $"{this.NoteName.ToString()}{octaveNum}";

			//var result = string.Format("{0}, NoteName={1}, Octave={2}", 
			//    base.ToString(), this.NoteName, this.Octave);
			return result;
		}

		public bool Equals(Note other)
		{
			var result = false;
			if (this.NoteName.Equals(other.NoteName)
				&& this.Octave == other.Octave)
				result = true;
			return result;
		}
		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is Note)
				result = this.Equals(obj as Note);
			return result;
		}


		public static bool operator <(Note a, Note b)
		{
			var result = Compare(a, b) < 0;
			return result;
		}
		public static bool operator >(Note a, Note b)
		{
			var result = Compare(a, b) > 0;
			return result;
		}
		public static bool operator <=(Note a, Note b)
		{
			var result = Compare(a, b) <= 0;
			return result;
		}
		public static bool operator >=(Note a, Note b)
		{
			var result = Compare(a, b) >= 0;
			return result;
		}
		public static bool operator ==(Note a, Note b)
		{
			var result = Compare(a, b) == 0;
			return result;
		}
		public static bool operator !=(Note a, Note b)
		{
			var result = Compare(a, b) != 0;
			return result;
		}

		public static Note operator +(Note n, Interval interval)
		{
			n.NoteName = NoteName.TransposeUp(n.NoteName, interval);
			n.Octave += (int)interval;
			return n;
		}

		public static Interval operator -(Note a, Note b)
		{
			var result = Interval.Unison;
			result = a.NoteName - b.NoteName;
			return result;
		}

		public int CompareTo(Note other)
		{
			var result = this.CompareTo(other);
			return result;
		}
		public static int Compare(Note a, Note b)
		{
			if (a is null && b is null)
				return 0;
			else if (a is null)
				return -1;
			else if (b is null)
				return 1;

			if (a.Octave == b.Octave)
			{
				if (a.NoteName == b.NoteName)
					return 0;
				else if (a.NoteName < b.NoteName)
					return -1;
				else
					return 1;
			}
			else if (a.Octave < b.Octave)
				return -1;
			else
				return 1;
		}
		public override int GetHashCode()
		{
			var result = this.NoteName.GetHashCode()
				^ this.Octave.GetHashCode();
			return result;
		}
	}//class

	public class NoteComparer : IComparer<Note>
	{
		public int Compare(Note x, Note y)
		{
			var result = Note.Compare(x, y);
			if (0 == result)
				result = x.NoteName.AsciiSortValue.CompareTo(y.NoteName.AsciiSortValue);

			return result;
		}
	}
}//ns
