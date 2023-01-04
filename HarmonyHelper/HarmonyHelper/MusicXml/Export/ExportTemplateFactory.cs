using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class ExportTemplateFactory
    {
        public string Now { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }

        public XDocument Create(MusicXmlModel model)
        {
            var xml = Helpers.LoadEmbeddedResource("MusicXmlExportTemplate.xml");

            var work = this.GetWork(model);
            var identification = this.GetIdentification();
            var partsList = this.GetPartsList(model);

            var result = XDocument.Parse(xml);
            result.Element(XmlConstants.score_partwise).Add(work);
            result.Element(XmlConstants.score_partwise).Add(identification);
            result.Element(XmlConstants.score_partwise).Add(partsList);

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

        XElement GetPartsList(MusicXmlModel model)
        {
#if false
<part-list>
   <score-part id="P1">
      <part-name>ElecPiano</part-name>
  </score-part>
   <score-part id="P2">
      <part-name>Calliope</part-name>
  </score-part>
  </part-list>
#endif
            var result = new XElement(XmlConstants.part_list);
            foreach (var part in model.Parts)
            {
                var xscore_part = new XElement(XmlConstants.score_part,
                    new XAttribute(XmlConstants.id, part.Identifier.ID));
                var xpart_name = new XElement(XmlConstants.part_name,
                    part.Identifier.Name);
                xscore_part.Add(xpart_name);
                result.Add(xscore_part);
            }
            return result;
        }
    }//class
}//ns
