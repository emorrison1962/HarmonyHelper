using Eric.Morrison.Harmony.Analysis.ReHarmonizer;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Collections.Specialized.BitVector32;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlSection
    {
        #region Properties
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();

        #endregion

        #region Construction
        public MusicXmlSection(IEnumerable<MusicXmlMeasure> measures)
        {
            this.Measures = measures.ToList();
        }

        #endregion    

    }//class

    public class ChordMelodyMeasurePairing
    {
        public MusicXmlMeasure MelodyMeasure { get; set; }
        public MusicXmlMeasure HarmonyMeasure { get; set; }
        public ChordMelodyMeasurePairing(MusicXmlMeasure melodyMeasure, MusicXmlMeasure harmonyMeasure)
        {
            this.MelodyMeasure = melodyMeasure;
            this.HarmonyMeasure = harmonyMeasure;
        }
    }//class

}//ns
