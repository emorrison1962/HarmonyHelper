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
    public class Part : IDisposable, IHasIsValid
    {
        private bool disposedValue;
        #region Properties
        public PartTypeEnum PartType { get; set; } = PartTypeEnum.Unknown;
        public List<MusicXmlStaff> Staves { get; set; } = new List<MusicXmlStaff>()
            { new MusicXmlStaff(new Clef(ClefEnum.Treble, 1))};
        public PartIdentifier Identifier { get; set; } = new PartIdentifier("P1", "Part 01");
        [Obsolete("", true)]
        MeasureList _Measures { get; set; } = new MeasureList();
        public ReadOnlyCollection<Measure> Measures
        {
            get
            {
                var result = (from s in this.Sections
                           from m in s.Measures
                           select m).ToList().AsReadOnly();
                return result;
            }
        }
        public XElement XElement { get; set; }
        public Measure CurrentMeasure { get { return Measures.Last(); } }
        public KeySignature KeySignature { get; set; } = KeySignature.CMajor;
        List<Section> _Sections = new List<Section>();
        public List<Section> Sections 
        {
            get 
            { 
                if (!this._Sections.Any())
                    this._Sections.Add(new Section());
                return this._Sections;
            }
        } 
        public RhythmicContext Rhythm { get; set; }
        #endregion

        #region Construction
        public Part(PartTypeEnum PartType)
        {
            this.PartType = PartType;
        }
        public Part(PartTypeEnum PartType, PartIdentifier PartIdentifier)
            : this(PartType)
        {
            this.Identifier = PartIdentifier;
        }
        public Part(PartTypeEnum PartType, PartIdentifier PartIdentifier, XElement xelement)
            : this(PartType, PartIdentifier)
        {
            this.XElement = xelement;
        }
        public Part(PartTypeEnum PartType, PartIdentifier PartIdentifier, ClefEnum clef)
    : this(PartType, PartIdentifier)
        {
            this.Staves.Clear();
            this.Staves = new List<MusicXmlStaff>() { new MusicXmlStaff(new Clef(clef, 1)) };

        }

        #endregion

        [Obsolete("", true)]
        public void AddRange(IEnumerable<Measure> measures, bool renumberMeasures = true)
        {
            if (null == this.Rhythm)
            {
                var rhythm = measures.Select(x => x.TimedEvents
                        .Select(y => y.TimeContext.Rhythm)
                        .FirstOrDefault(x => x != null))
                    .FirstOrDefault();
                if (null != rhythm)
                    this.Rhythm = rhythm;
            }
            this._Measures.AddRange(measures);
            this.ResetMeasureNumbers();
        }

        [Obsolete("", true)]
        public void Add(Measure measure)
        {
            if (null == this.Rhythm)
            {
                var rhythm = measure.TimedEvents
                        .Select(y => y.TimeContext.Rhythm)
                        .FirstOrDefault(x => x != null);
                if (null != rhythm)
                    this.Rhythm = rhythm;
            }

            this._Measures.Add(measure);
            this.ResetMeasureNumbers();
        }

        [Obsolete("", true)]
        public void Remove(Measure measure)
        {
            this._Measures.Remove(measure);
            this.ResetMeasureNumbers();
        }

        public void Add(Section section)
        {
            this.Sections.Add(section);
            section.SetPart(this);
        }

        [Obsolete("", true)]
        public void ResetMeasureNumbers()
        {
            for (int i = 0; i < this._Measures.Count; ++i)
            {
                this._Measures[i]._MeasureNumber = i + 1;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Part)}: {Identifier}";
        }

        public bool IsValid()
        {
            var result = true;
            if (!this.Staves.Any())
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && !this.Identifier.IsValid())
            {
                result = false;
            }
            if (result && !this.Measures.All(x => x.IsValid()))
            {
                result = false;
            }
            if (result && this.KeySignature == null)
            {
                result = false;
                Debug.Assert(result);
            }
            if (result && !this.Sections.All(x => x.IsValid()))
            {
                result = false;
            }
            return result;
        }

        public XElement ToXElement()
        {
            var result = new XElement(XmlConstants.part);
            result.Add(new XAttribute(XmlConstants.id, this.Identifier.ID));

            foreach (var measure in this.Measures)
            {
                var xmeasure = measure.ToXElement();
                if (measure == this.Measures.First())
                {
                    this.GetPartMetadata(xmeasure);
                }

                result.Add(xmeasure);
            }

            foreach (var section in this.Sections)
            {
                foreach (var measure in section.Measures)
                {
                    var xmeasure = measure.ToXElement();
                    if (measure == this.Sections.First().Measures.First())
                    {
                        this.GetPartMetadata(xmeasure);
                    }

                    result.Add(xmeasure);
                }
            }
            return result;
        }

        void GetPartMetadata(XElement xmeasure)
        {
#if false
   <measure number="1">
      <attributes>
        <divisions>120</divisions>
        <key>
           <fifths>2</fifths>
        </key>
        <time>
           <beats>4</beats>
           <beat-type>4</beat-type>
        </time>
        <staves>2</staves>
        <clef number="1">
           <sign>G</sign>
           <line>2</line>
        </clef>
        <clef number="2">
           <sign>F</sign>
           <line>4</line>
        </clef>
      </attributes>
      <sound tempo="120"/>
      <forward>
         <duration>480</duration>
      </forward>
   </measure>
#endif
            var xattributes = new XElement(XmlConstants.attributes);

            if (null != this.Rhythm)
            {
                #region divisions
                var xdivisions = new XElement(XmlConstants.divisions,
                    this.Rhythm.PulsesPerMeasure /
                    this.Rhythm.TimeSignature.BeatCount);
                xattributes.Add(xdivisions);

                #endregion

                #region key
                var xkey = new XElement(XmlConstants.key);
                var fifths = 0;
                if (this.KeySignature.UsesFlats)
                {
                    fifths = -this.KeySignature.AccidentalCount;
                }
                else
                {
                    fifths = this.KeySignature.AccidentalCount;
                }
                xkey.Add(new XElement(XmlConstants.fifths, fifths));
                xattributes.Add(xkey);

                #endregion

                #region time

                var xtime = new XElement(XmlConstants.time);

                var xbeats = new XElement(XmlConstants.beats,
                    this.Rhythm.TimeSignature.BeatCount);
                xtime.Add(xbeats);
                var xbeat_type = new XElement(XmlConstants.beat_type,
                    this.Rhythm.TimeSignature.BeatUnit);
                xtime.Add(xbeat_type);
                xattributes.Add(xtime);

                #endregion
            }

            #region staves
            var xstaves = new XElement(XmlConstants.staves, this.Staves.Count);
            xattributes.Add(xstaves);

            #endregion

            #region clefs
            foreach (var staff in this.Staves)
            {
                xattributes.Add(staff.Clef.ToXml());
            }

            #endregion

            xmeasure.AddFirst(this.GetTempo());
            xmeasure.AddFirst(xattributes);

        }

        XElement GetTempo()
        {
            #region tempo
            var result = new XElement(XmlConstants.sound);
            var xtempo = new XAttribute(XmlConstants.tempo,
                this.Rhythm.Tempo);
            result.Add(xtempo);

            return result;

            #endregion
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
