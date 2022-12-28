using Eric.Morrison.Harmony.Analysis.ReHarmonizer;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Rhythm;
using Kohoutech.Score;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class PartIdentifier
    {
        public string ID;
        public string Name;
        public PartIdentifier(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"{nameof(PartIdentifier)}: ID={ID}, Name={Name}";
        }
    }//class

    public class MusicXmlScoreMetadata
    {
        public string Title { get; set; }
        public KeySignature KeySignature { get; set; }
        public Eric.Morrison.Harmony.Rhythm.TimeSignature TimeSignatue { get; set; }
        public int Tempo { get; set; }
        public int PulsesPerQuarterNote { get; set; }
        public int PulsesPerMeasure 
        { 
            get 
            { 
                return this.TimeSignatue.BeatCount * this.PulsesPerQuarterNote; 
            } 
        }
    }//class

    public class ParsingContext
    {
        #region Properties
#if DEBUG
        MusicXmlPart CurrentPart { get; set; }
#endif
        public MusicXmlScoreMetadata Metadata { get; set; }
        public MusicXmlMeasure CurrentMeasure { get; set; }


        int _CurrentOffset = 0;
#warning FIXME: Refactor this to a backing store prop after setters are working properly.
        public int CurrentOffset
        {
            get
            {
                return _CurrentOffset;
            }
            set
            {
                _CurrentOffset = value;
                Debug.Assert(_CurrentOffset <= 481);
                Debug.Assert(_CurrentOffset >= 0);
                //Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();

        //public ConcurrentDictionary<TiedNoteContext, TiedNoteContext> TiedNotes { get; set; } = new ConcurrentDictionary<TiedNoteContext, TiedNoteContext>();

        public ChordTimeContext ChordTimeContext { get; set; } = new ChordTimeContext();

        #endregion
    }//class

    public class TimeModification
    {
        public int Normal { get; set; }
        public int Actual { get; set; }

        public TimeModification(XElement xtime_modification)
        {
#if false
        <time-modification>
            <actual-notes>3</actual-notes>
            <normal-notes>2</normal-notes>
            <normal-type>eighth</normal-type>
        </time-modification>
#endif
            this.Actual = int.Parse(xtime_modification.Element(XmlConstants.actual_notes).Value);
            this.Normal = int.Parse(xtime_modification.Element(XmlConstants.normal_notes).Value);
        }

        public int GetDuration(int duration)
        { 
            var result = (duration * this.Normal) / this.Actual;
            return result;
        }
    }//class

    public class ExportTemplateFactory
    {
        public string Now { get { return DateTime.Now.ToString("MM-dd-yyyy"); } }

        public XDocument Create(MusicXmlModel model)
        {
            var xml = MusicXmlBase.LoadEmbeddedResource("MusicXmlExportTemplate.xml");

            var work = this.GetWork(model);
            var identification = this.GetIdentification();
            
            var result = XDocument.Parse(xml);
            result.Element("score-partwise").Add(work);
            result.Element("score-partwise").Add(identification);

            return result;

        }

        XElement GetWork(MusicXmlModel model)
        {
            var template = $@" 
<work>
  <work-title>{model.Metadata.Title}</work-title>
</work>";
            var result = XElement.Parse(template);
            return result;
        }

        XElement GetIdentification()
        {
            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var template = $@"
<identification>
 <encoding>
  <encoding-date>{this.Now}</encoding-date>
  <software>{fvi.ProductName}, Version {fvi.ProductVersion}</software>
 </encoding>
</identification>";
            var result = XElement.Parse(template);
            return result;
        }

    }//class

}//ns
