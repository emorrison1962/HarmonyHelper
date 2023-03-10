using System.Collections.Generic;
using System.Diagnostics;

using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Scales
{
	public abstract class ModalScaleFormulaBase : HeptatonicScaleFormulaBase
	{
		#region Properties
		public ModeEnum Mode { get; private set; }
		virtual public string ModeName { get { return this.Mode.ToString(); } }

		#endregion

		#region Construction
		public ModalScaleFormulaBase(KeySignature key, ModeEnum mode) : base(key)
		{
			this.Mode = mode;
			this.Init();
		}

		protected override void Init()
		{
			base.InitImpl();
		}


		#endregion
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

		override protected void PopulateNoteNames()
		{
			var offsetFromKeyRoot = GetDistanceFromKeyRoot(this.Mode);

			var root = NoteName.TransposeUp(this.Key.NoteName, offsetFromKeyRoot, true);
			this.Name = root.Name + " " + this.Mode.ToString("G");
			this.Root = root;

			var result = new List<NoteName>();
			result.Add(root);
			foreach (var interval in this.Intervals)
			{
                var txposed = NoteName.TransposeUp(this.Root, interval, true);
				result.Add(txposed);
			}

			this.NoteNames = result;
		}

		abstract protected ScaleToneInterval GetDistanceFromKeyRoot(ModeEnum mode);

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

	}//class

}
