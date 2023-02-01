using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Eric.Morrison.Harmony.MusicXml.Domain;

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
    public class MultiPartSection : IDisposable
    {
        private bool disposedValue;
        #region Properties
        public List<MusicXmlSection> Sections { get; protected set; }

        #endregion

        #region Construction
        public MultiPartSection(List<MusicXmlSection> Sections)
        {
            this.Sections = Sections;
        }

        #endregion

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Sections = null;
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
    public class MusicXmlSection : IDisposable
    {
        private bool disposedValue;
        #region Properties
        public MusicXmlPart Part { get; protected set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();
        public MusicXmlRepeatContext RepeatContext { get; set; }

        #endregion

        #region Construction
        public MusicXmlSection(MusicXmlPart Part, 
            IEnumerable<MusicXmlMeasure> measures)
        {
            if (null == Part)
                throw new ArgumentNullException(nameof(Part));
            if (!measures.Any())
                throw new ArgumentException(nameof(measures));
            this.Part = Part;
            this.Measures = measures.ToList();
        }

        public MusicXmlSection(MusicXmlPart Part,
            MusicXmlRepeatContext repeatCtx)
        {
            if (null == Part)
                throw new ArgumentNullException(nameof(Part));
            this.Part = Part;
            this.RepeatContext = repeatCtx;
        }


        public MusicXmlSection(MusicXmlPart Part)
        {
            if (null == Part)
                throw new ArgumentNullException(nameof(Part));
            this.Part = Part;
        }

        #endregion

        public void Add(MusicXmlMeasure measure)
        { 
            if (null == measure)
                throw new ArgumentNullException(nameof(measure));
            this.Measures.Add(measure);
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Part = null;
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
