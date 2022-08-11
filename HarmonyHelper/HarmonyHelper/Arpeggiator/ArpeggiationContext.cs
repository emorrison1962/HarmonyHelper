using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public class ArpeggiationContext : IEquatable<ArpeggiationContext>, IComparable<ArpeggiationContext>
	{
		public Chord Chord { get; set; }
		public int NotesToPlay { get; set; }

		public ArpeggiationContext(Chord chord, int notesToPlay)
		{
			if (chord is null || chord == Chord.Empty)
				throw new ArgumentNullException(nameof(chord));
			this.Chord = chord;
			this.NotesToPlay = notesToPlay;
		}
		public ArpeggiationContext(ChordFormula formula, int notesToPlay)
		{
			this.Chord = new Chord(formula);
			this.NotesToPlay = notesToPlay;
		}
		public override string ToString()
		{
			return $"{this.GetType().Name}: Chord={this.Chord.ToString()}, NotesToPlay={this.NotesToPlay}";
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
			bool result = true;
			if (a is null && b is null)
				return true;
			
			if (a is null || b is null)
				result = false;

			if (result)
				result = a.CompareTo(b) == 0;
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
	}//class

}//ns
