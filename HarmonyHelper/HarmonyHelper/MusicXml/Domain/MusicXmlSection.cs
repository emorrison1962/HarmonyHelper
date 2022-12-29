using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Kohoutech.Score;
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

        public List<ChordMelodyPairing> GetChordMelodyPairings()
        {
            var result = new List<ChordMelodyPairing>();

            var measures = this.GetMergedMeasures();
            foreach (var measure in measures)
            {
                //Debug.WriteLine(measure);
                result.AddRange(measure.ChordMelodyPairings);
            }
            return result;
        }


    }//class

    public class ReHarmonizedMusicXmlSection : MusicXmlSection
    { }//class
}//ns
