using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;
using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	[Flags]
	public enum ModeEnum
	{
		Ionian = 1,
		Dorian,
		Phrygian,
		Lydian,
		Mixolydian,
		Aeolian,
		Locrian
	}

	public class Mode : ScaleBase
	{
		public NoteName Tonic { get; private set; }
		NoteName Second { get; set; }
		public NoteName Third { get; private set; }
		public NoteName Fourth { get; private set; }
		public NoteName Fifth { get; private set; }
		public NoteName Sixth { get; private set; }
		public NoteName Seventh { get; private set; }
		new public ModalScaleFormulaBase Formula { get; private set; }

		public Mode(KeySignature key, ModeEnum modeEnum, NoteRange noteRange) : base(key, noteRange)
		{
			this.Key = key;
			this.Formula = new MajorModalScaleFormula(key, modeEnum);
			this.NoteRange = noteRange;
			this.Create();

			this.Name = $"{this.Formula.NoteNames[0]} {modeEnum.ToStringEx()}";
		}

		void Create()
		{
			this.Tonic = this.Key.NoteName;

			var tonicOffset = this.GetTonicOffset();
			if (tonicOffset > Interval.Unison)
				this.Tonic = this.Key.NoteName + tonicOffset;

			var ndx = 0;
			this.Second = this.Tonic + this.Formula.Intervals[ndx++];
			this.Third = this.Tonic + this.Formula.Intervals[ndx++];
			this.Fourth = this.Tonic + this.Formula.Intervals[ndx++];
			this.Fifth = this.Tonic + this.Formula.Intervals[ndx++];
			this.Sixth = this.Tonic + this.Formula.Intervals[ndx++];
			this.Seventh = this.Tonic + this.Formula.Intervals[ndx++];

			var wantedNotes = new List<NoteName>() { this.Tonic, this.Second, this.Third, this.Fourth, this.Fifth, this.Sixth, this.Seventh };
			this.Notes = this.NoteRange.GetNotes(wantedNotes);
			
		}

		ScaleToneInterval GetTonicOffset()
		{
			var interval = this.Key.NoteName - this.Tonic;
			var result = interval.ToScaleToneInterval();
			return result;
		}
		//Interval GetTonicOffset()
		//{
		//	Interval result = Interval.Unison;
		//	switch (Formula.Mode)
		//	{
		//		case ModeEnum.Ionian:
		//			result = Interval.Unison;
		//			break;
		//		case ModeEnum.Dorian:
		//			result = Interval.Major2nd;
		//			break;
		//		case ModeEnum.Phrygian:
		//			result = Interval.Major3rd;
		//			break;
		//		case ModeEnum.Lydian:
		//			result = Interval.Perfect4th;
		//			break;
		//		case ModeEnum.Mixolydian:
		//			result = Interval.Perfect5th;
		//			break;
		//		case ModeEnum.Aeolian:
		//			result = Interval.Major6th;
		//			break;
		//		case ModeEnum.Locrian:
		//			result = Interval.Major7th;
		//			break;
		//	}
		//	return result;
		//}

		public override string ToString()
		{
			var result = string.Empty;
			const string FORMAT = @"{1} {0} Mode: {1},{2},{3},{4},{5},{6},{7}";
			result = string.Format(FORMAT,
				this.Formula.Mode.ToString(),
				this.Tonic,
				this.Second,
				this.Third,
				this.Fourth,
				this.Fifth,
				this.Sixth,
				this.Seventh);
			return result;
		}
	}//class
}//ns
