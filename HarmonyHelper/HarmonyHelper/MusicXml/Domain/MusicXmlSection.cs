﻿using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Eric.Morrison.Harmony.MusicXml.Domain;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eric.Morrison.Harmony.MusicXml
{
    public class MultiPartSection : IDisposable, IHasIsValid
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

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        #endregion


    }//class
    public class MusicXmlSection : IDisposable, IHasIsValid
    {
        private bool disposedValue;
        #region Properties
        public string Name { get; protected set; }
        public MusicXmlPart Part { get; protected set; }
        public MeasureList Measures { get; set; } = new MeasureList();
        public MusicXmlRepeatContext RepeatContext { get; set; }
        public int Length { get { return this.Measures.Count; } }

        #endregion

        #region Construction
        public MusicXmlSection(string name, MusicXmlPart Part, 
            IEnumerable<MusicXmlMeasure> measures)
        {
            if (null == Part)
                throw new ArgumentNullException(nameof(Part));
            if (!measures.Any())
                throw new ArgumentException(nameof(measures));

            this.Name = name;            
            this.Part = Part;
            this.Measures = new MeasureList(measures);
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
            
            if (this.Measures.Count == 0)
                measure.IsSectionStart = true;

            if (this.Measures.Any())
            {
                if (measure.IsSectionStart)
                {
                    if (!measure.BarlineContexts
                        .Any(x => x.RepeatContext.RepeatEnum == RepeatEnum.Forward))
                    {
                        Debug.Assert(this.Measures.Last().IsSectionEnd);
                    }
                }
            }

            if (this.Measures.Any())
            {
                if (this.Measures.Last().IsSectionEnd)
                {
                    measure.IsSectionStart = true;
                }
            }

            this.Measures.Add(measure);
        }

        public bool IsValid()
        {
            var result = true;
            if (!this.Measures.All(x => x.IsValid()))
            {
                result = false;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{nameof(MusicXmlSection)}: Measures.Count={Measures.Count}";
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
