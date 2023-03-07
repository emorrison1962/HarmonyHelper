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
    public class MusicXmlPart : IDisposable, IHasIsValid
    {
        private bool disposedValue;
        #region Properties
        public PartTypeEnum PartType { get; set; } = PartTypeEnum.Unknown;
        public List<MusicXmlStaff> Staves { get; set; } = new List<MusicXmlStaff>();
        public MusicXmlPartIdentifier Identifier { get; set; }
        MeasureList _Measures { get; set; } = new MeasureList();
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
        public List<MusicXmlSection> Sections { get; set; } = new List<MusicXmlSection>();

        #endregion

        #region Construction
        public MusicXmlPart(PartTypeEnum PartType)
        {
            this.PartType = PartType;
            this.Sections.Add(new MusicXmlSection(this));
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

        public void Add(MusicXmlSection section)
        {
            this.Sections.Add(section);
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

        public bool IsValid()
        {
            var result = true;
            if (!this.Staves.Any())
            { 
                result = false ;
                Debug.Assert(result);
            }
            if (result && !Identifier.IsValid())
            {
                result = false;
            }
            if (result && !_Measures.All(x => x.IsValid()))
            {
                result = false;
            }
            if (result && this.KeySignature == null)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && !Sections.All(x => x.IsValid()))
            {
                result = false;
            }
            return result;
        }



        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var section in this.Sections)
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


        #endregion
    }//class

}//ns
