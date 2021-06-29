using System.Collections.Generic;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
	public class HarmonicMinorScaleFormula : ScaleFormulaBase
	{
		public HarmonicMinorScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}

		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Minor6th,
				ScaleToneInterval.Major7th,
			};

		}
	}

	public class MelodicMinorScaleFormula : ScaleFormulaBase
	{
		public MelodicMinorScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Major7th,
			};
		}
	}

	public abstract class PentatonicScaleFormula : ScaleFormulaBase
	{
		public PentatonicScaleFormula(KeySignature key) : base(key)
		{
		}
	}
	public class PentatonicMajorScaleFormula : PentatonicScaleFormula
	{
		public PentatonicMajorScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Major3rd,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Major6th,
			};
		}
	}

	public class PentatonicMinorScaleFormula : PentatonicScaleFormula
	{
		public PentatonicMinorScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Minor7th,
			};
		}
	}

	public class WholeToneScaleFormula : ScaleFormulaBase
	{
		public WholeToneScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Major3rd,
				ScaleToneInterval.Augmented4th,
				ScaleToneInterval.Augmented5th,
				ScaleToneInterval.Minor7th
			};
		}
	}

	public class DiminishedHalfWholeScaleFormula : ScaleFormulaBase
	{
		public DiminishedHalfWholeScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Minor2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Major3rd,
				ScaleToneInterval.Augmented4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Minor7th,
			};
		}
	}

	public class DiminishedWholeHalfScaleFormula : ScaleFormulaBase
	{
		public DiminishedWholeHalfScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Diminished5th,
				ScaleToneInterval.Minor6th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Major7th,
			};
		}
	}

	public class ChromaticScaleFormula : ScaleFormulaBase
	{
		public ChromaticScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
			new object();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.AugmentedUnison,
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Augmented2nd,
				ScaleToneInterval.Major3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Augmented4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Augmented5th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Augmented6th,
				ScaleToneInterval.Major7th,
			};
		}
	}

	public class NonatonicBluesScaleFormula : ScaleFormulaBase
	{
		public NonatonicBluesScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Major3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Augmented4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Minor7th,
			};
		}
	}

	public class HexatonicBluesScaleFormula : ScaleFormulaBase
	{
		public HexatonicBluesScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Augmented4th,
				ScaleToneInterval.Perfect5th,
				ScaleToneInterval.Minor7th,
			};
		}
	}

	public class HeptatonicBluesScaleFormula : ScaleFormulaBase
	{
		public HeptatonicBluesScaleFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<ScaleToneInterval>() {
				ScaleToneInterval.Major2nd,
				ScaleToneInterval.Minor3rd,
				ScaleToneInterval.Perfect4th,
				ScaleToneInterval.Diminished5th,
				ScaleToneInterval.Major6th,
				ScaleToneInterval.Minor7th,
			};
		}
	}


#if false
	References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif

}
