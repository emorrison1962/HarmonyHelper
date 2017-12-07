using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class HarmonicMinor : ScaleFormulaBase
    {
        public HarmonicMinor(IEnumerable<IntervalsEnum> intervals)
        {
        }
        protected override void Init()
        {
            base.InitImpl();
        }

        protected override void PopulateIntervals()
        {
            throw new NotImplementedException();
        }
    }

    public class MelodicMinor : ScaleFormulaBase
    {
        public MelodicMinor(IEnumerable<IntervalsEnum> intervals)
        {
        }
        protected override void Init()
        {
            base.InitImpl();
        }
        protected override void PopulateIntervals()
        {
            throw new NotImplementedException();
        }
    }

    public class PentatonicMajor : ScaleFormulaBase
    {
        public PentatonicMajor(IEnumerable<IntervalsEnum> intervals)
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

    public class PentatonicMinor : ScaleFormulaBase
    {
        public PentatonicMinor(IEnumerable<IntervalsEnum> intervals)
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

    public class WholeTone : ScaleFormulaBase
    {
        public WholeTone(IEnumerable<IntervalsEnum> intervals)
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

    public class DiminishedHalfWhole : ScaleFormulaBase
    {
        public DiminishedHalfWhole(IEnumerable<IntervalsEnum> intervals)
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

    public class DiminishedWholeHalf : ScaleFormulaBase
    {
        public DiminishedWholeHalf(IEnumerable<IntervalsEnum> intervals)
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

    public class Chromatic : ScaleFormulaBase
    {
        public Chromatic(IEnumerable<IntervalsEnum> intervals)
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
