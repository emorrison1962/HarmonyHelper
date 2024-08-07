using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Melody
{
    public class MelodyGeneratorChordContext : IEquatable<MelodyGeneratorChordContext>, IComparable<MelodyGeneratorChordContext>
	{
		public Chord Chord { get; set; }
		public int NotesToPlay { get; set; }

		public MelodyGeneratorChordContext(Chord chord, int notesToPlay)
		{
			this.Chord = chord;
			this.NotesToPlay = notesToPlay;
		}
		public MelodyGeneratorChordContext(ChordFormula formula, NoteRange nr, int notesToPlay)
		{
			this.Chord = new Chord(formula, nr);
			this.NotesToPlay = notesToPlay;
		}
		public override string ToString()
		{
			return $"{this.GetType().Name}: Chord={this.Chord.ToString()}, NotesToPlay={this.NotesToPlay}";
		}

		public bool Equals(MelodyGeneratorChordContext other)
		{
			var result = this.Chord.CompareTo(other.Chord) == 0;
			return result;
		}

		public int CompareTo(MelodyGeneratorChordContext other)
		{
			return this.Chord.CompareTo(other.Chord);
		}

		public override bool Equals(object obj)
		{
			var result = false;
			if (obj is MelodyGeneratorChordContext)
				result = this.Equals(obj as Note);
			return result;
		}

		public static bool operator ==(MelodyGeneratorChordContext a, MelodyGeneratorChordContext b)
		{
			bool result = true;
			if (a is null && b is null)
				return true;
			
			if (a is null || b is null)
				result = false;

			if (result)
				result = a.CompareTo(b) == 0;
			return result;
		}
		public static bool operator !=(MelodyGeneratorChordContext a, MelodyGeneratorChordContext b)
		{
			if (null == a || null == b || null == a && null == b)
				return true;
			var result = a.CompareTo(b) != 0;
			return result;
		}

		public override int GetHashCode()
		{
			return this.Chord.GetHashCode();
		}
	}//class

}//ns
