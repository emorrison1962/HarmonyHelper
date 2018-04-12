using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public class ModeFormula : ScaleFormulaBase
	{
		public ModeEnum Mode { get; private set; }
		public IntervalsEnum Second { get; private set; }
		public IntervalsEnum Third { get; private set; }
		public IntervalsEnum Fourth { get; private set; }
		public IntervalsEnum Fifth { get; private set; }
		public IntervalsEnum Sixth { get; private set; }
		public IntervalsEnum Seventh { get; private set; }


		public ModeFormula(KeySignature key, ModeEnum mode) : base(key)
		{
			this.Mode = mode;
			this.Init();
		}
		[Obsolete("", true)]
		ModeFormula(ModeEnum me, IntervalsEnum second, IntervalsEnum third,
			IntervalsEnum fourth, IntervalsEnum fifth, IntervalsEnum sixth, IntervalsEnum seventh, KeySignature key = null)
			: base(key)
		{
			this.Mode = me;
			this.Name = this.Mode.ToString("G");
			this.Second = second;
			this.Third = third;
			this.Fourth = fourth;
			this.Fifth = fifth;
			this.Sixth = sixth;
			this.Seventh = seventh;
		}


		[Obsolete("", true)]
		public ModeFormula(KeySignature key, ModeEnum me, IntervalsEnum second, IntervalsEnum third,
			IntervalsEnum fourth, IntervalsEnum fifth, IntervalsEnum sixth, IntervalsEnum seventh)
			: this(me, second, third, fourth, fifth, sixth, seventh, key)
		{
			var interval = this.GetDistanceFromKeyRoot(me);
			var root = key.NoteName + new IntervalContext(key, interval);
		}

		IntervalsEnum GetDistanceFromKeyRoot(ModeEnum mode)
		{
			var result = IntervalsEnum.None;
			switch (mode)
			{
				case ModeEnum.Dorian:
					result = IntervalsEnum.Major2nd;
					break;
				case ModeEnum.Phrygian:
					result = IntervalsEnum.Major3rd;
					break;
				case ModeEnum.Lydian:
					result = IntervalsEnum.Perfect4th;
					break;
				case ModeEnum.Mixolydian:
					result = IntervalsEnum.Perfect5th;
					break;
				case ModeEnum.Aeolian:
					result = IntervalsEnum.Major6th;
					break;
				case ModeEnum.Locrian:
					result = IntervalsEnum.Major7th;
					break;
				default:
					result = IntervalsEnum.None;
					break;
			}
			return result;
		}

		override protected void PopulateNoteNames()
		{
			var offsetFromKeyRoot = GetDistanceFromKeyRoot(this.Mode);

			var root = NoteNames.Get(this.Key, this.Key.NoteName, offsetFromKeyRoot);
			this.Name = root.Name + " " + this.Mode.ToString("G");

			var result = new List<NoteName>();
			result.Add(root);
			foreach (var interval in this.Intervals)
			{
				var nn = NoteNames.Get(this.Key, root, interval);
				result.Add(nn);
			}

			this.NoteNames = result;
		}





		//public override string ToString()
		//{
		//    const string FORMAT = @"{0}: {1}";
		//    var result = string.Format(FORMAT,
		//        this.Mode.ToString("G"),
		//        this.Name,
		//        string.Join(",", this.NoteNames));

		//    return result;
		//}

		public override string ToString()
		{
			var result = string.Empty;
			const string FORMAT = @"{0} {1}: {2}";
			result = string.Format(FORMAT,
				this.NoteNames[0],
				this.Mode.ToString("G"),
				string.Join(",", this.NoteNames));
			return result;
		}


		protected override void PopulateIntervals()
		{
			var result = new List<IntervalsEnum>();
			switch (this.Mode)
			{
				case ModeEnum.Ionian:
					result.AddRange(new[] { IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th });
					break;
				case ModeEnum.Dorian:
					result.AddRange(new[] { IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th });
					break;
				case ModeEnum.Phrygian:
					result.AddRange(new[] { IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th });
					break;
				case ModeEnum.Lydian:
					result.AddRange(new[] { IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Augmented4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Major7th });
					break;
				case ModeEnum.Mixolydian:
					result.AddRange(new[] { IntervalsEnum.Major2nd, IntervalsEnum.Major3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Major6th, IntervalsEnum.Minor7th });
					break;
				case ModeEnum.Aeolian:
					result.AddRange(new[] { IntervalsEnum.Major2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Perfect5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th });
					break;
				case ModeEnum.Locrian:
					result.AddRange(new[] { IntervalsEnum.Minor2nd, IntervalsEnum.Minor3rd, IntervalsEnum.Perfect4th, IntervalsEnum.Diminished5th, IntervalsEnum.Minor6th, IntervalsEnum.Minor7th });
					break;

			}
			this.Second = result[0];
			this.Third = result[1];
			this.Fourth = result[2];
			this.Fifth = result[3];
			this.Sixth = result[4];
			this.Seventh = result[5];
			this.Intervals = result;
		}

		protected override void Init()
		{
			base.InitImpl();
		}

	}
}
