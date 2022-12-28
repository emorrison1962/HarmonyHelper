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
        public List<MusicXmlSection> Sections { get; set; } = new List<MusicXmlSection>();
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
            public SectionContext(params int[] parms)
            {
                MeasureCount = parms.ToList();
            }
        }
        void SplitSections(SectionContext ctx)
        {

        }
        public void CreateSections(SectionContext ctx)
        {
            var result = new List<MusicXmlSection>();
            int start = 0;
            int end = 0;
            foreach (var count in ctx.MeasureCount)
            {
                end = count;
                var lastCount = count;
                var section = new MusicXmlSection();
                var list = (from p in this.Parts
                           select new { Part = p, Measures = p.Measures })
                           .ToList();

                foreach (var item in list)
                {
                    var p = MusicXmlPart.CloneShallow(item.Part);
                    p.Measures.AddRange(item.Measures.Skip(start).Take(end));
                    section.Parts.Add(p);
                }
                result.Add(section);
                start = end;
            }
            this.Sections = result;
        }

    }//class

}//ns
