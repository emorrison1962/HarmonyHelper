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
			//this.Intervals = new List<Interval>() {
			//    Interval.Minor2nd,
			//    Interval.Major2nd,
			//    Interval.Minor3rd,
			//    Interval.Major3rd,
			//    Interval.Perfect4th,
			//    Interval.Augmented4th,
			//    Interval.Perfect5th,
			//    Interval.Augmented5th,
			//    Interval.Major6th,
			//    Interval.Minor7th,
			//    Interval.Major7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Major3rd,
				Interval.Perfect5th,
				Interval.Major6th,
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
			this.Intervals = new List<Interval>() {
				Interval.Minor3rd,
				Interval.Perfect4th,
				Interval.Perfect5th,
				Interval.Minor7th,
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
			this.Intervals = new List<Interval>() {
				Interval.Major2nd,
				Interval.Major3rd,
				Interval.Augmented4th,
				Interval.Augmented5th,
				Interval.Minor7th
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
