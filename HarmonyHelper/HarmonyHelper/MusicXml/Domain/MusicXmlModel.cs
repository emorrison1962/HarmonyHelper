using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlModel
    {
        #region Properties
        [Obsolete("", true)]
        public SectionContext SectionContext { get; set; }
        public List<MusicXmlSection> Sections { get; set; } = new List<MusicXmlSection>();
        public MusicXmlScoreMetadata Metadata { get; set; }
        public List<MusicXmlPart> Parts { get; protected set; } = new List<MusicXmlPart>();
        public RhythmicContext Rhythm { get; set; }

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

        void SplitSections(SectionContext ctx)
        {

        }

        public void CreateSections(SectionContext ctx)
        {
            int start = 0;
            int end = 0;
            foreach (var count in ctx.MeasureCount)
            {
                end = count;
                var lastCount = count;
                var parts = (from p in this.Parts
                             select new { Part = p, Measures = p.Measures })
                           .ToList();
                foreach (var part in this.Parts)
                {
                    var measures = (part.Measures.Skip(start).Take(end));
                    var section = new MusicXmlSection(measures);
                    part.Sections.Add(section); 
                    this.Sections.Add(section);
                }
                start = end;
            }
        }

            public void MergeSections()
        {
            foreach (var part in this.Parts) 
            {
                foreach (var section in part.Sections)
                {
                    part.AddRange(section.Measures, false);
                }
            }

            //foreach (var item in seq)
            //{
            //    var part = this.Parts.First(x => x.Identifier.ID == item.Part.Identifier.ID);
            //    new object();
            //}
        }

        public void Add(MusicXmlPart part)
        {
            if (part.Measures.Count > 0)
            {
                var rhythm = (from m in part.Measures
                           from n in m.Notes
                           where n.TimeContext.Rhythm != null
                           select n.TimeContext.Rhythm).First();
                this.Rhythm = rhythm;
            }
            this.Parts.Add(part);
        }
    }//class

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
    }//class

}//ns
