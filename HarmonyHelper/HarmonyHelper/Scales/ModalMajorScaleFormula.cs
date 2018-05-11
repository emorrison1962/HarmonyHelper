using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

namespace Eric.Morrison.Harmony
{
	public class ModalMajorScaleFormula : ModalScaleFormulaBase
	{

		public ModalMajorScaleFormula(KeySignature key, ModeEnum mode) : base(key, mode)
		{
		}

		protected override void Init()
		{
			this.Intervals = new[] { ScaleToneInterval.Root, ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Major7th }.ToList();
			Debug.Assert(0 < this.Intervals.Count);
			base.InitImpl();
			Debug.Assert(0 < this.Intervals.Count);
		}


		protected override void PopulateIntervals()
		{
			Debug.Assert(0 < this.Intervals.Count);
			var tmp = this.Intervals;
			this.Intervals = new List<ScaleToneInterval>();
			var offsetNdx = (int)this.Mode - 1;
			for (int i = 0; i < Constants.COUNT_DIATONIC_SCALE_DEGREES; ++i)
			{
				var interval = tmp.NextOrFirst(ref offsetNdx);

				Debug.Write(interval);
				//if (interval == ScaleToneInterval.None)
				//{
				//	var derivedInterval = tmp[Constants.COUNT_DIATONIC_SCALE_DEGREES - 1];
				//	var baseInterval = derivedInterval.GetInversion();
				//	interval = baseInterval.ToScaleToneInterval();
				//}
				Debug.WriteLine($" : {interval}");

				if (interval != ScaleToneInterval.None)
				{
					var lowerInterval = tmp[offsetNdx - 2];
					interval = interval - lowerInterval;
					this.Intervals.Add(interval);
				}
			}

			new object();

			//switch (this.Mode)
			//{
			//	case ModeEnum.Ionian:
			//		result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Major7th });
			//		break;
			//	case ModeEnum.Dorian:
			//		result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Minor7th });
			//		break;
			//	case ModeEnum.Phrygian:
			//		result.AddRange(new[] { ScaleToneInterval.Minor2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
			//		break;
			//	case ModeEnum.Lydian:
			//		result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Augmented4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Major7th });
			//		break;
			//	case ModeEnum.Mixolydian:
			//		result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Major3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Major6th, ScaleToneInterval.Minor7th });
			//		break;
			//	case ModeEnum.Aeolian:
			//		result.AddRange(new[] { ScaleToneInterval.Major2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Perfect5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
			//		break;
			//	case ModeEnum.Locrian:
			//		result.AddRange(new[] { ScaleToneInterval.Minor2nd, ScaleToneInterval.Minor3rd, ScaleToneInterval.Perfect4th, ScaleToneInterval.Diminished5th, ScaleToneInterval.Minor6th, ScaleToneInterval.Minor7th });
			//		break;

			//}
		}
	}//class
}//ns
