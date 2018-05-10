using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public class ModeFormula : ScaleFormulaBase
	{
		public ModeEnum Mode { get; private set; }
		public ScaleToneInterval Second { get; private set; }
		public ScaleToneInterval Third { get; private set; }
		public ScaleToneInterval Fourth { get; private set; }
		public ScaleToneInterval Fifth { get; private set; }
		public ScaleToneInterval Sixth { get; private set; }
		public ScaleToneInterval Seventh { get; private set; }


		public ModeFormula(KeySignature key, ModeEnum mode) : base(key)
		{
			this.Mode = mode;
			this.Init();
		}
		[Obsolete("", true)]
		ModeFormula(ModeEnum me, ScaleToneInterval second, ScaleToneInterval third,
			ScaleToneInterval fourth, ScaleToneInterval fifth, ScaleToneInterval sixth, ScaleToneInterval seventh, KeySignature key = null)
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
		public ModeFormula(KeySignature key, ModeEnum me, ScaleToneInterval second, ScaleToneInterval third,
			ScaleToneInterval fourth, ScaleToneInterval fifth, ScaleToneInterval sixth, ScaleToneInterval seventh)
			: this(me, second, third, fourth, fifth, sixth, seventh, key)
		{
			var interval = this.GetDistanceFromKeyRoot(me);
			var root = key.NoteName + new IntervalContext(key, interval);
		}

		ScaleToneInterval GetDistanceFromKeyRoot(ModeEnum mode)
		{
			var result = ScaleToneInterval.None;
			switch (mode)
			{
				case ModeEnum.Dorian:
					result = ScaleToneInterval.Major2nd;
					break;
				case ModeEnum.Phrygian:
					result = ScaleToneInterval.Major3rd;
					break;
				case ModeEnum.Lydian:
					result = ScaleToneInterval.Perfect4th;
					break;
				case ModeEnum.Mixolydian:
					result = ScaleToneInterval.Perfect5th;
					break;
				case ModeEnum.Aeolian:
					result = ScaleToneInterval.Major6th;
					break;
				case ModeEnum.Locrian:
					result = ScaleToneInterval.Major7th;
					break;
				default:
					result = ScaleToneInterval.None;
					break;
			}
			return result;
		}

		override protected void PopulateNoteNames()
		{
			var offsetFromKeyRoot = GetDistanceFromKeyRoot(this.Mode);

			var root = NoteNames.Get(this.Key.NoteName, offsetFromKeyRoot, this.Key);
			this.Name = root.Name + " " + this.Mode.ToString("G");

			var result = new List<NoteName>();
			result.Add(root);
			foreach (var interval in this.Intervals)
			{
				var nn = NoteNames.Get(root, interval, this.Key);
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
			var result = new List<ScaleToneInterval>();
			switch (this.Mode)
			{
				case ModeEnum.Ionian:
					result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Major7th });
					break;
				case ModeEnum.Dorian:
					result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Minor7th });
					break;
				case ModeEnum.Phrygian:
					result.AddRange(new[] { ScaleToneInterval.Minor2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
					break;
				case ModeEnum.Lydian:
					result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Augmented4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Major7th });
					break;
				case ModeEnum.Mixolydian:
					result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Minor7th });
					break;
				case ModeEnum.Aeolian:
					result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
					break;
				case ModeEnum.Locrian:
					result.AddRange(new[] { ScaleToneInterval.Minor2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Diminished5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
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
