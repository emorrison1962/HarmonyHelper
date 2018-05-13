using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

namespace Eric.Morrison.Harmony.Scales
{
	public class MajorModalScaleFormula : ModalScaleFormulaBase
	{

		public MajorModalScaleFormula(KeySignature key, ModeEnum mode) : base(key, mode)
		{
		}

		protected override void Init()
		{
			base.InitImpl();
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
			this.Intervals = result;
		}

		protected override ScaleToneInterval GetDistanceFromKeyRoot(ModeEnum mode)
		{
			var result = ScaleToneInterval.Root;
			switch (mode)
			{
				case ModeEnum.Ionian:
					result = ScaleToneInterval.Root;
					break;
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
					throw new ArgumentOutOfRangeException();
					break;
			}
			return result;
		}
	}//class

}//ns
