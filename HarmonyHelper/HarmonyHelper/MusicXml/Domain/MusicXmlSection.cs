using Eric.Morrison.Harmony.Analysis.ReHarmonizer;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Collections.Specialized.BitVector32;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlSection
    {
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();
        public List<MusicXmlMeasure> CopyMeasures()
        {
            var result = new List<MusicXmlMeasure>();
            foreach (var part in this.Parts)
            {
                foreach (var src in part.Measures)
                {
                    var dst = new MusicXmlMeasure(src);
                    part.Copy(dst);
                    result.Add(dst);
                }
            }
            return result;
        }

        [Obsolete("", true)]
        public List<MusicXmlMeasure> GetMergedMeasures()
        {
            var result = new List<MusicXmlMeasure>();
            var seq = (from p in this.Parts
                       from m in p.Measures
                       select new { Part = p, Measure = m }).ToList();

            var groupings = seq.GroupBy(x => x.Measure.MeasureNumber).ToList();
            foreach (var grouping in groupings)
            {
                var merged = MusicXmlMeasure
                    .CreateMergedMeasure(grouping.Select(x => x.Measure)
                    .ToList());
                result.Add(merged);
            }

            return result;
        }

        public class ChordMelodyMeasurePairing
        {
            public MusicXmlMeasure MelodyMeasure { get; set; }
            public MusicXmlMeasure HarmonyMeasure { get; set; }
            public ChordMelodyMeasurePairing(MusicXmlMeasure melodyMeasure, MusicXmlMeasure harmonyMeasure)
            {
                this.MelodyMeasure = melodyMeasure;
                this.HarmonyMeasure = harmonyMeasure;
            }
        }
        public List<ChordMelodyMeasurePairing> GetChordMelodyMeasurePairings()
        {
            var result = new List<ChordMelodyMeasurePairing>();

            var melodyMeasures = this.Parts.Where(x => x.PartType == PartTypeEnum.Melody)
                .SelectMany(x => x.Measures)
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            var harmonyMeasures = this.Parts.Where(x => x.PartType == PartTypeEnum.Harmony)
                .SelectMany(x => x.Measures)
                .OrderBy(x => x.MeasureNumber)
                .ToList();
            
            Debug.Assert(melodyMeasures.Count == harmonyMeasures.Count);
            for (int i = 0; i < melodyMeasures.Count; ++i)
            {
                var cmp = new ChordMelodyMeasurePairing(melodyMeasures[i], 
                    harmonyMeasures[i]);
                result.Add(cmp);
            }

            return result;
        }


        public List<ChordMelodyPairing> GetChordMelodyPairings()
        {
            var result = new List<ChordMelodyPairing>();

            var cmmPairings = this.GetChordMelodyMeasurePairings();
            foreach (var cmmPairing in cmmPairings)
            {
                var cmPairings = MusicXmlMeasure.GetChordMelodyPairings(cmmPairing.MelodyMeasure,
                    cmmPairing.HarmonyMeasure);
                result.AddRange(cmPairings);
            }
            return result;
        }


    }//class
}//ns
