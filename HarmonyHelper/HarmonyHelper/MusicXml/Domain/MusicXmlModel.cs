using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlModel : IDisposable
    {
        private bool disposedValue;
        #region Properties
        [Obsolete("", true)]
        public SectionContext SectionContext { get; set; }
        List<MultiPartSection> _Sections { get; set; } = new List<MultiPartSection>();
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
        public List<TimedEventChordFormula> Get(TimeContext time)
        {
            var result = this.Parts
                .SelectMany(p => p.Measures.Where(x => x.MeasureNumber == time.MeasureNumber)
                .SelectMany(m => m.Chords))
                .ToList();
            return result;
        }

        #region Sections
        public void InitSections(SectionContext ctx)
        {
            this.TrimStart(ctx.Offset);
            ctx.Offset = 0;
            this.SetLength(ctx.MeasureCount.Sum());
            this.CreateSections(ctx);
            //this.Parts.ForEach(x => x.ClearMeasures());
        }

        void TrimStart(int count)
        {
            foreach (var part in this.Parts)
            {
                var removals = part.Measures.Take(count).ToList();
                removals.ForEach(x => part.Remove(x));
            }
        }

        void SetLength(int measureCount)
        {
            foreach (var part in this.Parts)
            {
                part.Measures.Skip(measureCount);
                var removals = part.Measures
                    .Take(part.Measures.Count - measureCount)
                    .ToList();
                removals.ForEach(x => part.Remove(x));
            }
        }

        public void CreateSections(SectionContext ctx)
        {
            this.TrimStart(ctx.Offset);
            this.SetLength(ctx.MeasureCount.Sum());

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
                    var measures = part.Measures
                        .Skip(start)
                        .Take(end)
                        .ToList();
                    var section = new MusicXmlSection(part, measures);
                    part.Add(section);
                }

                start = end;
            }
        }

        [Obsolete("", true)]
        public void MergeSections()
        {
            foreach (var part in this.Parts)
            {
                foreach (var section in part.Sections)
                {
                    part.AddRange(section.Measures);
                }
            }

            //foreach (var item in seq)
            //{
            //    var part = this.Parts.First(x => x.Identifier.ID == item.Part.Identifier.ID);
            //    new object();
            //}
        }

	    #endregion        

        public void Add(MusicXmlPart part)
        {
            if (part.Measures.Count > 0)
            {
                if (null == this.Rhythm)
                {
                    var rhythm = (from m in part.Measures
                                  from n in m.Notes
                                  where n.TimeContext.Rhythm != null
                                  select n.TimeContext.Rhythm).FirstOrDefault();
                    this.Rhythm = rhythm;
                }
            }
            this.Parts.Add(part);
        }

        [Obsolete("Get rid of this.", true)]
        public void Add(MultiPartSection section)
        {
            this._Sections.Add(section);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var part in this.Parts)
                    {
                        part.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MusicXmlModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }//class

    [Obsolete("", true)]
    public class MusicXmlModelCreationContext
    {
        public string Path { get; set; }
        public SectionContext SectionContext { get; set; }
        public string PartIdMelody { get; set; }
        public string PartIdHarmony { get; set; }

        public MusicXmlModelCreationContext(string path, SectionContext sectionContext, string melodyPart, string harmonyPart)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            this.Path = path;
            this.SectionContext = sectionContext;
            this.PartIdMelody = melodyPart;
            this.PartIdHarmony = harmonyPart;  
        }
    }
    public class SectionContext
    {
        public int Offset { get; set; }
        public List<int> MeasureCount { get; set; }

        public SectionContext(int offest, params int[] parms)
        {
            this.Offset = offest;
            this.MeasureCount = parms.ToList();
        }
    }//class

}//ns
