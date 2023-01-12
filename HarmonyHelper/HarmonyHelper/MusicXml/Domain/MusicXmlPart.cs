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
    public class MusicXmlPart
    {
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
        public List<MusicXmlSection> Sections { get; private set; } = new List<MusicXmlSection>();

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
            if (this._Measures.Any())
            {
                //var currentMeasureNumber = this._Measures
                //    .Select(x => x.MeasureNumber)
                //    .DefaultIfEmpty(1)
                //    .LastOrDefault();
                //Debug.Assert(currentMeasureNumber < 3 * 1000 - 1);

                foreach (var measure in measures)
                {
                    var currentMeasureNumber = this._Measures.Count + 1;
                    measure.SetMeasureNumber(currentMeasureNumber);
                }
            }

            var pending = measures.Select(x => x.MeasureNumber).ToList();

            var existing = this._Measures.Where(x => pending.Contains(x.MeasureNumber))
                .ToList();
            if (existing.Any())
            {
                new object();
            }

            this._Measures.AddRange(measures);
        }

        public void Add(MusicXmlMeasure measure)
        {
            var existing = this._Measures.Where(x => x.MeasureNumber == measure.MeasureNumber)
                .ToList();
            if (existing.Any())
            {
                new object();
            }
            this._Measures.Add(measure);
        }

        public override string ToString()
        {
            return $"{nameof(MusicXmlPart)}: {Identifier}";
        }

    }//class

}//ns
