using Eric.Morrison.Harmony.Rhythm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public enum PartTypeEnum
    {
        Unknown = int.MinValue,
        Melody = 1,
        Harmony = 2
    };
    public class MusicXmlPart : IDisposable
    {
        private bool disposedValue;
        #region Properties
        public PartTypeEnum PartType { get; set; } = PartTypeEnum.Unknown;
        public List<MusicXmlStaff> Staves { get; set; } = new List<MusicXmlStaff>();
        public MusicXmlPartIdentifier Identifier { get; set; }
        List<MusicXmlMeasure> _Measures { get; set; } = new List<MusicXmlMeasure>();
        public ReadOnlyCollection<MusicXmlMeasure> Measures
        {
            get
            {
                return _Measures
                    .OrderBy(x => x.MeasureNumber)
                    .ToList()
                    .AsReadOnly();
            }
        }
        public XElement XElement { get; set; }
        public MusicXmlMeasure CurrentMeasure { get { return Measures.Last(); } }
        public KeySignature KeySignature { get; set; }
        public int Tempo { get; set; }
        List<SinglePartSection> _Sections { get; set; } = new List<SinglePartSection>();
        public ReadOnlyCollection<SinglePartSection> Sections { get { return _Sections.AsReadOnly(); } } 

        #endregion

        #region Construction
        MusicXmlPart(MusicXmlPart part)
        {
            this.PartType = part.PartType;
            this.Identifier = part.Identifier;
        }
        public MusicXmlPart(PartTypeEnum PartType)
        {
            if (PartType == PartTypeEnum.Unknown)
                throw new ArgumentOutOfRangeException(nameof(PartType));
            this.PartType = PartType;
        }
        public MusicXmlPart(PartTypeEnum PartType, MusicXmlPartIdentifier PartIdentifier)
            : this(PartType)
        {
            this.Identifier = PartIdentifier;
        }
        public MusicXmlPart(PartTypeEnum PartType, MusicXmlPartIdentifier PartIdentifier, XElement xelement)
            : this(PartType, PartIdentifier)
        {
            this.XElement = xelement;
        }
        [Obsolete("", false)]
        static public MusicXmlPart CloneShallow(MusicXmlPart part)
        {
            return new MusicXmlPart(part);
        }
        #endregion

        public void AddRange(IEnumerable<MusicXmlMeasure> measures, bool renumberMeasures = true)
        {
            this._Measures.AddRange(measures);
            this.ResetMeasureNumbers();
        }

        public void Add(MusicXmlMeasure measure)
        {
            this._Measures.Add(measure);
            this.ResetMeasureNumbers();
        }

        public void Remove(MusicXmlMeasure measure)
        {
            this._Measures.Remove(measure);
            this.ResetMeasureNumbers();
        }

        public void Add(SinglePartSection section)
        {
            this._Sections.Add(section);
        }

        public void ResetMeasureNumbers()
        {
            for (int i = 0; i < this._Measures.Count; ++i)
            {
                this._Measures[i]._MeasureNumber = i + 1;
            }
        }

        public override string ToString()
        {
            return $"{nameof(MusicXmlPart)}: {Identifier}";
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var section in this._Sections)
                    {
                        section.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        [Obsolete("", true)]
        internal void ClearMeasures()
        {
            this._Measures.Clear(); 
        }

        #endregion
    }//class

}//ns
