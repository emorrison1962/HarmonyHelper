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
    public class MultiPartSection : IDisposable
    {
        private bool disposedValue;
        #region Properties
        public List<SinglePartSection> Sections { get; protected set; }

        #endregion

        #region Construction
        public MultiPartSection(List<SinglePartSection> Sections)
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
    public class SinglePartSection : IDisposable
    {
        private bool disposedValue;
        #region Properties
        public MusicXmlPart Part { get; protected set; }
        public List<MusicXmlMeasure> Measures { get; set; } = new List<MusicXmlMeasure>();

        #endregion

        #region Construction
        public SinglePartSection(MusicXmlPart Part, IEnumerable<MusicXmlMeasure> measures)
        {
            if (null == Part)
                throw new ArgumentNullException(nameof(Part));
            if (!measures.Any())
                throw new ArgumentException(nameof(measures));
            this.Part = Part;
            this.Measures = measures.ToList();
        }

        #endregion

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

    public class ChordMelodyMeasurePairing
    {
        MusicXmlPart MelodyPart { get; set; }
        MusicXmlPart HarmonyPart { get; set; }
        public MusicXmlMeasure MelodyMeasure { get; set; }
        public MusicXmlMeasure HarmonyMeasure { get; set; }
        public ChordMelodyMeasurePairing(MusicXmlPart melodyPart,
            MusicXmlPart harmonyPart,
            MusicXmlMeasure melodyMeasure, 
            MusicXmlMeasure harmonyMeasure)
        {
            this.MelodyPart = melodyPart;
            this.HarmonyPart = harmonyPart;
            this.MelodyMeasure = melodyMeasure;
            this.HarmonyMeasure = harmonyMeasure;
        }
    }//class

}//ns
