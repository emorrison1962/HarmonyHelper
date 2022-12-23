using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlModel
    {
        #region Properties
        List<MusicXmlPart> Section { get; set; } = new List<MusicXmlPart>();
        public MusicXmlScoreMetadata Metadata { get; set; }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();

        #endregion

        #region Costruction
        public MusicXmlModel()
        {

        }

        #endregion

        [Obsolete("Do we need this?")]
        public List<TimedEvent<ChordFormula>> Get(TimeContext time)
        {
            var result = this.Parts
                .SelectMany(p => p.Measures.Where(x => x.MeasureNumber == time.MeasureNumber)
                .SelectMany(m => m.Chords))
                .ToList();
            return result;
        }

        public class SectionContext
        {
            public List<int> MeasureCount { get; set; }

            public SectionContext(List<int> measureCount)
            {
                MeasureCount = measureCount;
            }
        }
        void SplitSections(SectionContext ctx)
        {

        }
        public List<MusicXmlSection> CreateSections(SectionContext ctx)
        {
            var result = new List<MusicXmlSection>();
            foreach (var count in ctx.MeasureCount)
            {
                var section = new MusicXmlSection();
                var list = (from p in this.Parts
                           select new { Part = p, Measures = p.Measures })
                           .ToList();

                foreach (var item in list)
                {
                    var p = new MusicXmlPart(item.Part);
                    p.Measures.AddRange(item.Measures);
                    section.Parts.Add(p);
                }
                result.Add(section);
            }
            return result;
        }

    }//class

    public class MusicXmlSection
    { 
        public List<MusicXmlPart> Parts {get; set;}
    }

}//ns
