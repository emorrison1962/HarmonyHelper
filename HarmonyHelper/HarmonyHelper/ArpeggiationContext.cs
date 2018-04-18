﻿using System;
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
	}//class

}//ns
