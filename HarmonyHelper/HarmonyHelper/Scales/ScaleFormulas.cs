using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;

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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Perfect5th,
				Interval.Minor6th,
				Interval.Major7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Minor2nd,
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Major3rd,
				Interval.Perfect4th,
				Interval.Augmented4th,
				Interval.Perfect5th,
				Interval.Augmented5th,
				Interval.Major6th,
				Interval.Minor7th,
				Interval.Major7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Major3rd,
				Interval.Perfect5th,
				Interval.Major6th,
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
			this.Intervals = new List<Interval>() {
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Perfect5th,
				Interval.Minor7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Major3rd,
				Interval.Augmented4th,
				Interval.Augmented5th,
				Interval.Minor7th
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
			this.Intervals = new List<Interval>() {
				Interval.Minor2nd,
				Interval.Minor3rd,
				Interval.Major3rd,
				Interval.Augmented4th,
				Interval.Perfect5th,
				Interval.Major6th,
				Interval.Minor7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Diminished5th,
				Interval.Minor6th,
				Interval.Major6th,
				Interval.Major7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Minor2nd,
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Major3rd,
				Interval.Perfect4th,
				Interval.Augmented4th,
				Interval.Perfect5th,
				Interval.Augmented5th,
				Interval.Major6th,
				Interval.Minor7th,
				Interval.Major7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Major3rd,
				Interval.Perfect4th,
				Interval.Augmented4th,
				Interval.Perfect5th,
				Interval.Major6th,
				Interval.Minor7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Augmented4th,
				Interval.Perfect5th,
				Interval.Minor7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Diminished5th,
				Interval.Major6th,
				Interval.Minor7th,
			};
		}
	}


#if false
	References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif

}
