using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlModel : IDisposable, IHasIsValid
    {
        private bool disposedValue;
        #region Properties
        public MusicXmlScoreMetadata Metadata { get; set; } = new MusicXmlScoreMetadata();
        public List<Part> Parts { get; protected set; } = new List<Part>();
        public RhythmicContext Rhythm { get; set; } = new RhythmicContext(new TimeSignature(4, 4), 480).SetTempo(100);

        public bool IsValid()
        {
            bool result = true;
            if (null == this.Rhythm)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && this.Rhythm.Tempo == 0)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && this.Parts.Count == 0)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && !this.Parts.All(x => x.IsValid()))
            {
                result = false;
            }
            if (result && !this.Metadata.IsValid())
            {
                result = false;
                Debug.Assert(result);
            }
            return result;
        }

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

        #endregion

        public void Add(Part part)
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
            part.Rhythm = this.Rhythm;
            this.Parts.Add(part);
        }

        public void RenderSections()
        {
            foreach (var part in this.Parts)
            {
                foreach (var section in part.Sections)
                {
                    part.AddRange(section.Measures);
                }
            }
            new object();
        }

        #region IDisposable
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        #endregion    

    }//class

}//ns
