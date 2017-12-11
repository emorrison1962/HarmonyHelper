using System;
using System.Collections.Generic;

namespace Eric.Morrison.Harmony
{
    public class HarmonicMinorFormula : ScaleFormulaBase
    {
        public HarmonicMinorFormula()
        {
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
        public MelodicMinorFormula()
        {
        }
        protected override void Init()
        {
            base.InitImpl();
        }
        protected override void PopulateIntervals()
        {
            throw new NotImplementedException();
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

    public class PentatonicMajorFormula : ScaleFormulaBase
    {
        public PentatonicMajorFormula()
        {
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

    public class PentatonicMinorFormula : ScaleFormulaBase
    {
        public PentatonicMinorFormula()
        {
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
        public WholeToneFormula()
        {
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
        public DiminishedHalfWholeFormula()
        {
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
        public DiminishedWholeHalfFormula()
        {
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
        public Chromatic()
        {
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


#if false
    References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif 

}
