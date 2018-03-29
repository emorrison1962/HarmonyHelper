using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
	public class HarmonicMinorFormula : ScaleFormulaBase
	{
		public HarmonicMinorFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}

		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Minor6th,
				IntervalsEnum.Major7th,
			};

		}
	}

	public class MelodicMinorFormula : ScaleFormulaBase
	{
		public MelodicMinorFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			throw new NotImplementedException();
			//this.Intervals = new List<IntervalsEnum>() {
			//    IntervalsEnum.Minor2nd,
			//    IntervalsEnum.Major2nd,
			//    IntervalsEnum.Minor3rd,
			//    IntervalsEnum.Major3rd,
			//    IntervalsEnum.Perfect4th,
			//    IntervalsEnum.Augmented4th,
			//    IntervalsEnum.Perfect5th,
			//    IntervalsEnum.Augmented5th,
			//    IntervalsEnum.Major6th,
			//    IntervalsEnum.Minor7th,
			//    IntervalsEnum.Major7th,
			//};
		}
	}

	public abstract class PentatonicFormula : ScaleFormulaBase
	{
		public PentatonicFormula(KeySignature key) : base(key)
		{
		}
	}
	public class PentatonicMajorFormula : PentatonicFormula
	{
		public PentatonicMajorFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Major3rd,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Major6th,
			};
		}
	}

	public class PentatonicMinorFormula : PentatonicFormula
	{
		public PentatonicMinorFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Minor7th,
			};
		}
	}

	public class WholeToneFormula : ScaleFormulaBase
	{
		public WholeToneFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Major3rd,
				IntervalsEnum.Augmented4th,
				IntervalsEnum.Augmented5th,
				IntervalsEnum.Minor7th
			};
		}
	}

	public class DiminishedHalfWholeFormula : ScaleFormulaBase
	{
		public DiminishedHalfWholeFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Minor2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Major3rd,
				IntervalsEnum.Augmented4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Major6th,
				IntervalsEnum.Minor7th,
			};
		}
	}

	public class DiminishedWholeHalfFormula : ScaleFormulaBase
	{
		public DiminishedWholeHalfFormula(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Diminished5th,
				IntervalsEnum.Minor6th,
				IntervalsEnum.Major6th,
				IntervalsEnum.Major7th,
			};
		}
	}

	public class Chromatic : ScaleFormulaBase
	{
		public Chromatic(KeySignature key) : base(key)
		{
			this.Init();
		}
		protected override void Init()
		{
			base.InitImpl();
		}
		protected override void PopulateIntervals()
		{
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Minor2nd,
				IntervalsEnum.Major2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Major3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Augmented4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Augmented5th,
				IntervalsEnum.Major6th,
				IntervalsEnum.Minor7th,
				IntervalsEnum.Major7th,
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
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Major3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Augmented4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Major6th,
				IntervalsEnum.Minor7th,
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
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Augmented4th,
				IntervalsEnum.Perfect5th,
				IntervalsEnum.Minor7th,
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
			this.Intervals = new List<IntervalsEnum>() {
				IntervalsEnum.Major2nd,
				IntervalsEnum.Minor3rd,
				IntervalsEnum.Perfect4th,
				IntervalsEnum.Diminished5th,
				IntervalsEnum.Major6th,
				IntervalsEnum.Minor7th,
			};
		}
	}


#if false
	References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif

}
