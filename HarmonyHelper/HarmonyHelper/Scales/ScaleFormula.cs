using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleFormulaBase
    {
        public List<IntervalsEnum> Intervals { get; set; } = new List<IntervalsEnum>();
        abstract protected void PopulateIntervals();
        abstract protected void Init();
        public ScaleFormulaBase()
        {
            Task.Run((Action)this.InitImpl);
        }

        protected void InitImpl()
        {
            this.PopulateIntervals();
        }


    }//class
}//ns
