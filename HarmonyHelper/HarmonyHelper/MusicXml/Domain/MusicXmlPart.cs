using Eric.Morrison.Harmony.Rhythm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlPart
    {
        #region Properties
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
        KeySignature _KeySignature = null;
        public KeySignature KeySignature 
        {
            get { return _KeySignature; }
            set 
            {
                if (null == _KeySignature)
                    _KeySignature = value;  
            } 
        }
        public int Tempo { get; set; }


        #endregion

        #region Construction
        MusicXmlPart(MusicXmlPart part)
        {
            this.Identifier = part.Identifier;
        }
        public MusicXmlPart(MusicXmlPartIdentifier PartIdentifier)
        {
            this.Identifier = PartIdentifier;
        }
        public MusicXmlPart(MusicXmlPartIdentifier PartIdentifier, XElement xelement)
            : this(PartIdentifier)
        {
            this.XElement = xelement;
        }
        [Obsolete("", false)]
        static public MusicXmlPart CloneShallow(MusicXmlPart part)
        {
            return new MusicXmlPart(part);
        }
        #endregion

        public void AddRange(IEnumerable<MusicXmlMeasure> measures)
        {
            if (this._Measures.Any())
            {
                var currentMeasureNumber = this._Measures
                    .Select(x => x.MeasureNumber)
                    .DefaultIfEmpty(1)
                    .LastOrDefault();

                measures.ToList().ForEach(x => x.AddOffset(new TimeContext(currentMeasureNumber)));
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
