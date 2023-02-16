using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class MelodyHarmonyPair<T>
    {
        public T Melody { get; set; }
        public T Harmony { get; set; }
        public MelodyHarmonyPair(
            T melodyMeasure,
            T harmonyMeasure)
        {
            this.Melody = melodyMeasure;
            this.Harmony = harmonyMeasure;
        }
    }//class

}//ns
